using System;
using System.Reflection;

namespace Sirenix.Serialization
{
	public class WeakQueueFormatter : WeakBaseFormatter
	{
		private readonly Serializer ElementSerializer;

		private readonly bool IsPlainQueue;

		private MethodInfo EnqueueMethod;

		public WeakQueueFormatter(Type serializedType)
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
