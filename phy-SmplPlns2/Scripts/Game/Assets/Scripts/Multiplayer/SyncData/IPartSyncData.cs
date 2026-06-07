using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.SyncData
{
	public interface IPartSyncData
	{
		int Count { get; }

		float Delta { get; }

		void CalculateDelta(float physicsTime);

		void SerializeRead(Reader reader);

		void SerializeWrite(Writer writer, float physicsTime);
	}
}
