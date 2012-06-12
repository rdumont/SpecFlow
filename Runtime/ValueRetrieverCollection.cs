using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace TechTalk.SpecFlow
{
    public class ValueRetrieverCollection
    {
        public Dictionary<Type, Func<TableRow, Type, object>> TypeHandlersForFieldValuePairs { get; private set; }

        public ValueRetrieverCollection()
        {
            TypeHandlersForFieldValuePairs = new Dictionary<Type, Func<TableRow, Type, object>>
                {
                    {typeof (string), (TableRow row, Type instanceType) => new StringValueRetriever().GetValue(row[1])},
                    {typeof (byte), (TableRow row, Type instanceType) => new ByteValueRetriever().GetValue(row[1])},
                    {typeof (byte?), (TableRow row, Type instanceType) => new NullableByteValueRetriever(v => new ByteValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (sbyte), (TableRow row, Type instanceType) => new SByteValueRetriever().GetValue(row[1])},
                    {typeof (sbyte?), (TableRow row, Type instanceType) => new NullableSByteValueRetriever(v => new SByteValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (int), (TableRow row, Type instanceType) => new IntValueRetriever().GetValue(row[1])},
                    {typeof (int?), (TableRow row, Type instanceType) => new NullableIntValueRetriever(v => new IntValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (uint), (TableRow row, Type instanceType) => new UIntValueRetriever().GetValue(row[1])},
                    {typeof (uint?), (TableRow row, Type instanceType) => new NullableUIntValueRetriever(v => new UIntValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (short), (TableRow row, Type instanceType) => new ShortValueRetriever().GetValue(row[1])},
                    {typeof (short?), (TableRow row, Type instanceType) => new NullableShortValueRetriever(v => new ShortValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (ushort), (TableRow row, Type instanceType) => new UShortValueRetriever().GetValue(row[1])},
                    {typeof (ushort?), (TableRow row, Type instanceType) => new NullableUShortValueRetriever(v => new UShortValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (long), (TableRow row, Type instanceType) => new LongValueRetriever().GetValue(row[1])},
                    {typeof (long?), (TableRow row, Type instanceType) => new NullableLongValueRetriever(v => new LongValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (ulong), (TableRow row, Type instanceType) => new ULongValueRetriever().GetValue(row[1])},
                    {typeof (ulong?), (TableRow row, Type instanceType) => new NullableULongValueRetriever(v => new ULongValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (float), (TableRow row, Type instanceType) => new FloatValueRetriever().GetValue(row[1])},
                    {typeof (float?), (TableRow row, Type instanceType) => new NullableFloatValueRetriever(v => new FloatValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (double), (TableRow row, Type instanceType) => new DoubleValueRetriever().GetValue(row[1])},
                    {typeof (double?), (TableRow row, Type instanceType) => new NullableDoubleValueRetriever(v => new DoubleValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (decimal), (TableRow row, Type instanceType) => new DecimalValueRetriever().GetValue(row[1])},
                    {typeof (decimal?), (TableRow row, Type instanceType) => new NullableDecimalValueRetriever(v => new DecimalValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (char), (TableRow row, Type instanceType) => new CharValueRetriever().GetValue(row[1])},
                    {typeof (char?), (TableRow row, Type instanceType) => new NullableCharValueRetriever(v => new CharValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (bool), (TableRow row, Type instanceType) => new BoolValueRetriever().GetValue(row[1])},
                    {typeof (bool?), (TableRow row, Type instanceType) => new NullableBoolValueRetriever(v => new BoolValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (DateTime), (TableRow row, Type instanceType) => new DateTimeValueRetriever().GetValue(row[1])},
                    {typeof (DateTime?), (TableRow row, Type instanceType) => new NullableDateTimeValueRetriever(v => new DateTimeValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (Guid), (TableRow row, Type instanceType) => new GuidValueRetriever().GetValue(row[1])},
                    {typeof (Guid?), (TableRow row, Type instanceType) => new NullableGuidValueRetriever(v => new GuidValueRetriever().GetValue(v)).GetValue(row[1])},
                    {typeof (Enum), (TableRow row, Type instanceType) => new EnumValueRetriever().GetValue(row[1], instanceType.GetProperties().First(x => x.Name.MatchesThisColumnName(row[0])).PropertyType)},
                };
        }
    }
}