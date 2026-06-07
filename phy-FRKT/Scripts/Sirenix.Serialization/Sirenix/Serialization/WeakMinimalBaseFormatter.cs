using System;

namespace Sirenix.Serialization
{
	public abstract class WeakMinimalBaseFormatter : IFormatter
	{
		protected readonly Type SerializedType;

		protected readonly bool IsValueType;

		Type IFormatter.SerializedType => null;

		public WeakMinimalBaseFormatter(Type serializedType)
		{
		}

		public object Deserialize(IDataReader reader)
		{
			return null;
		}

		public void Serialize(object value, IDataWriter writer)
		{
		}

		protected virtual object GetUninitializedObject()
		{
			return null;
		}

		protected abstract void Read(ref object value, IDataReader reader);

		protected abstract void Write(ref object value, IDataWriter writer);

		protected void RegisterReferenceID(object value, IDataReader reader)
		{
		}
	}
}
