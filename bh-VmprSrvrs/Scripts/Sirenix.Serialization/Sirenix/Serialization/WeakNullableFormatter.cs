using System;

namespace Sirenix.Serialization
{
	public sealed class WeakNullableFormatter : WeakBaseFormatter
	{
		private readonly Serializer ValueSerializer;

		public WeakNullableFormatter(Type nullableType)
			: base(null)
		{
		}

		protected override void DeserializeImplementation(ref object value, IDataReader reader)
		{
		}

		protected override void SerializeImplementation(ref object value, IDataWriter writer)
		{
		}

		protected override object GetUninitializedObject()
		{
			return null;
		}
	}
}
