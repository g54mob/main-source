using System;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.SyncData
{
	public abstract class SyncValue<T> : ISyncValue where T : struct
	{
		public abstract float Delta { get; }

		public T LastValueSent { get; protected set; }

		public Action Serialized { get; set; }

		public Func<T> Value { get; set; }

		public Action<T> ValueRead { get; set; }

		public SyncValue()
		{
		}

		public void SerializeRead(Reader reader)
		{
			T obj = SerializeValue(reader);
			ValueRead(obj);
		}

		public void SerializeWrite(Writer writer)
		{
			T val = Value();
			SerializeValue(writer, val);
			LastValueSent = val;
		}

		protected abstract T SerializeValue(Reader reader);

		protected abstract void SerializeValue(Writer writer, T value);
	}
}
