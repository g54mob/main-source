using System;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.SyncData
{
	public interface ISyncValue
	{
		float Delta { get; }

		Action Serialized { get; }

		void SerializeRead(Reader reader);

		void SerializeWrite(Writer writer);
	}
}
