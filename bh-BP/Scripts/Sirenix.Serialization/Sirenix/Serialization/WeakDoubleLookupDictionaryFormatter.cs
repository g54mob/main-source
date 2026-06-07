using System;

namespace Sirenix.Serialization
{
	internal sealed class WeakDoubleLookupDictionaryFormatter : WeakBaseFormatter
	{
		private readonly Serializer PrimaryReaderWriter;

		private readonly Serializer InnerReaderWriter;

		public WeakDoubleLookupDictionaryFormatter(Type serializedType)
			: base(null)
		{
		}

		protected override object GetUninitializedObject()
		{
			return null;
		}

		protected override void SerializeImplementation(ref object value, IDataWriter writer)
		{
		}

		protected override void DeserializeImplementation(ref object value, IDataReader reader)
		{
		}
	}
}
