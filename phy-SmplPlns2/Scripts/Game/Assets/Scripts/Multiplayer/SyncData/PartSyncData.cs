using System.Collections.Generic;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.SyncData
{
	public class PartSyncData : IPartSyncData
	{
		private float _lastPhysicsTime;

		private List<ISyncValue> _partSyncValues = new List<ISyncValue>();

		public int Count => _partSyncValues.Count;

		public float Delta { get; private set; }

		public void CalculateDelta(float physicsTime)
		{
			float num = physicsTime - _lastPhysicsTime;
			float num2 = 0f;
			foreach (ISyncValue partSyncValue in _partSyncValues)
			{
				num2 += partSyncValue.Delta;
			}
			Delta = num2 * num;
		}

		public void RegisterValue(ISyncValue value)
		{
			_partSyncValues.Add(value);
		}

		public void SerializeRead(Reader reader)
		{
			foreach (ISyncValue partSyncValue in _partSyncValues)
			{
				partSyncValue.SerializeRead(reader);
			}
		}

		public void SerializeWrite(Writer writer, float physicsTime)
		{
			_lastPhysicsTime = physicsTime;
			foreach (ISyncValue partSyncValue in _partSyncValues)
			{
				partSyncValue.SerializeWrite(writer);
				partSyncValue.Serialized?.Invoke();
			}
		}
	}
}
