using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TechTalk.SpecFlow.Utils
{
    public class SynchronizationHelper
    {
        public static TClass GetOrCreate<TClass>(ref TClass storage, object synchRoot) where TClass : class, new()
        {
            return GetOrCreate(ref storage, synchRoot, () => new TClass());
        }

        public static TInterface GetOrCreate<TInterface>(ref TInterface storage, object synchRoot, Func<TInterface> factory) where TInterface : class
        {
            if (storage == null)
            {
                lock (synchRoot)
                {
// ReSharper disable ConditionIsAlwaysTrueOrFalse
                    if (storage == null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
                    {
                        var newInstance = factory();
                        Thread.MemoryBarrier();
                        storage = newInstance;
                    }
                }
            }
            return storage;
        }
    }
}
