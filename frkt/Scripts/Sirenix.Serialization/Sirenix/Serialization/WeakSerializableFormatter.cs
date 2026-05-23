using System;
using System.Runtime.Serialization;

namespace Sirenix.Serialization
{
	public sealed class WeakSerializableFormatter : WeakBaseFormatter
	{
		private readonly Func<SerializationInfo, StreamingContext, ISerializable> ISerializableConstructor;

		private readonly WeakReflectionFormatter ReflectionFormatter;

		public WeakSerializableFormatter(Type serializedType)
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

		private SerializationInfo ReadSerializationInfo(IDataReader reader)
		{
			return null;
		}

		private void WriteSerializationInfo(SerializationInfo info, IDataWriter writer)
		{
		}
	}
}
