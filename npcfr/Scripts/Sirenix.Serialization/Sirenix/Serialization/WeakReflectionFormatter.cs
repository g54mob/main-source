using System;

namespace Sirenix.Serialization
{
	public class WeakReflectionFormatter : WeakBaseFormatter
	{
		public WeakReflectionFormatter(Type serializedType)
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
