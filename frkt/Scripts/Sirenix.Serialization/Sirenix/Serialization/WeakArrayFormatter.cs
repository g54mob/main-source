using System;

namespace Sirenix.Serialization
{
	public sealed class WeakArrayFormatter : WeakBaseFormatter
	{
		private readonly Serializer ValueReaderWriter;

		private readonly Type ElementType;

		public WeakArrayFormatter(Type arrayType, Type elementType)
			: base(null)
		{
		}

		protected override object GetUninitializedObject()
		{
			return null;
		}

		protected override void DeserializeImplementation(ref object value, IDataReader reader)
		{
		}

		protected override void SerializeImplementation(ref object value, IDataWriter writer)
		{
		}
	}
}
