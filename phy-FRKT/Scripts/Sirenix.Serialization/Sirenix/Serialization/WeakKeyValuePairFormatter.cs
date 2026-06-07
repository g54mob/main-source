using System;
using System.Reflection;

namespace Sirenix.Serialization
{
	public sealed class WeakKeyValuePairFormatter : WeakBaseFormatter
	{
		private readonly Serializer KeySerializer;

		private readonly Serializer ValueSerializer;

		private readonly PropertyInfo KeyProperty;

		private readonly PropertyInfo ValueProperty;

		public WeakKeyValuePairFormatter(Type serializedType)
			: base(null)
		{
		}

		protected override void SerializeImplementation(ref object value, IDataWriter writer)
		{
		}

		protected override void DeserializeImplementation(ref object value, IDataReader reader)
		{
		}
	}
}
