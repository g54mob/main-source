using System;

namespace Sirenix.Serialization
{
	public abstract class MinimalBaseFormatter<T> : IFormatter<T>, IFormatter
	{
		protected static readonly bool IsValueType;

		public Type SerializedType => null;

		public T Deserialize(IDataReader reader)
		{
			return default(T);
		}

		public void Serialize(T value, IDataWriter writer)
		{
		}

		void IFormatter.Serialize(object value, IDataWriter writer)
		{
		}

		object IFormatter.Deserialize(IDataReader reader)
		{
			return null;
		}

		protected virtual T GetUninitializedObject()
		{
			return default(T);
		}

		protected abstract void Read(ref T value, IDataReader reader);

		protected abstract void Write(ref T value, IDataWriter writer);

		protected void RegisterReferenceID(T value, IDataReader reader)
		{
		}
	}
}
