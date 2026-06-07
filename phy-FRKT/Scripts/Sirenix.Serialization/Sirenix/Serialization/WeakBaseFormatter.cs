using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Sirenix.Serialization
{
	public abstract class WeakBaseFormatter : IFormatter
	{
		protected delegate void SerializationCallback(object value, StreamingContext context);

		protected readonly Type SerializedType;

		protected readonly SerializationCallback[] OnSerializingCallbacks;

		protected readonly SerializationCallback[] OnSerializedCallbacks;

		protected readonly SerializationCallback[] OnDeserializingCallbacks;

		protected readonly SerializationCallback[] OnDeserializedCallbacks;

		protected readonly bool IsValueType;

		protected readonly bool ImplementsISerializationCallbackReceiver;

		protected readonly bool ImplementsIDeserializationCallback;

		protected readonly bool ImplementsIObjectReference;

		Type IFormatter.SerializedType => null;

		public WeakBaseFormatter(Type serializedType)
		{
		}

		private static SerializationCallback[] GetCallbacks(MethodInfo[] methods, Type callbackAttribute, ref List<SerializationCallback> list)
		{
			return null;
		}

		private static SerializationCallback CreateCallback(MethodInfo info)
		{
			return null;
		}

		public void Serialize(object value, IDataWriter writer)
		{
		}

		public object Deserialize(IDataReader reader)
		{
			return null;
		}

		protected void RegisterReferenceID(object value, IDataReader reader)
		{
		}

		protected void InvokeOnDeserializingCallbacks(object value, DeserializationContext context)
		{
		}

		protected virtual object GetUninitializedObject()
		{
			return null;
		}

		protected abstract void DeserializeImplementation(ref object value, IDataReader reader);

		protected abstract void SerializeImplementation(ref object value, IDataWriter writer);
	}
}
