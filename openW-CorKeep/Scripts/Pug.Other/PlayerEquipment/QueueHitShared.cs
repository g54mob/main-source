using Unity.NetCode;

namespace PlayerEquipment
{
	public struct QueueHitShared
	{
		public NetworkTick currentTick;

		public int ridingAnimID;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public uint tickRate;
	}
}
