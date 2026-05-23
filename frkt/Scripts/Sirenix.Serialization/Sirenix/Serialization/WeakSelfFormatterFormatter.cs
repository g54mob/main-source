using System;

namespace Sirenix.Serialization
{
	public sealed class WeakSelfFormatterFormatter : WeakBaseFormatter
	{
		public WeakSelfFormatterFormatter(Type serializedType)
			: base(null)
		{
		}

		protected override void DeserializeImplementation(ref object value, IDataReader reader)
		{
		}

		protected override void SerializeImplementation(ref object value, IDataWriter writer)
		{
		}
	}
}
