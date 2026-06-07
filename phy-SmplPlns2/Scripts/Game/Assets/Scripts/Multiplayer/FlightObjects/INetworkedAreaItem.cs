using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public interface INetworkedAreaItem
	{
		bool IsActive { get; set; }

		byte ItemID { get; }

		float TimeSinceLastWrite { get; }

		float CalculateDelta();

		void InitializeArea(INetworkedArea area, byte itemID);

		void ReadState(PooledReader reader, float timeDelta);

		void UpdateLastWriteTime();

		void WriteState(PooledWriter writer);
	}
}
