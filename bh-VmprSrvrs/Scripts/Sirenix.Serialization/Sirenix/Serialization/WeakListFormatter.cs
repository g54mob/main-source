using System;

namespace Sirenix.Serialization
{
	public class WeakListFormatter : WeakBaseFormatter
	{
		private readonly Serializer ElementSerializer;

		public WeakListFormatter(Type serializedType)
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
