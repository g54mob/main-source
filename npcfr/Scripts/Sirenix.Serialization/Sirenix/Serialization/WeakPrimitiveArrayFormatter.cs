using System;
using System.Collections.Generic;

namespace Sirenix.Serialization
{
	public sealed class WeakPrimitiveArrayFormatter : WeakMinimalBaseFormatter
	{
		public enum PrimitiveArrayType
		{
			PrimitiveArray_char = 0,
			PrimitiveArray_sbyte = 1,
			PrimitiveArray_short = 2,
			PrimitiveArray_int = 3,
			PrimitiveArray_long = 4,
			PrimitiveArray_byte = 5,
			PrimitiveArray_ushort = 6,
			PrimitiveArray_uint = 7,
			PrimitiveArray_ulong = 8,
			PrimitiveArray_decimal = 9,
			PrimitiveArray_bool = 10,
			PrimitiveArray_float = 11,
			PrimitiveArray_double = 12,
			PrimitiveArray_Guid = 13
		}

		private static readonly Dictionary<Type, PrimitiveArrayType> PrimitiveTypes;

		private readonly Type ElementType;

		private readonly PrimitiveArrayType PrimitiveType;

		public WeakPrimitiveArrayFormatter(Type arrayType, Type elementType)
			: base(null)
		{
		}

		protected override object GetUninitializedObject()
		{
			return null;
		}

		protected override void Read(ref object value, IDataReader reader)
		{
		}

		protected override void Write(ref object value, IDataWriter writer)
		{
		}
	}
}
