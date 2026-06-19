using Unity.NetCode;

namespace PlayerEquipment
{
	public struct EquipmentLateUpdateSharedData
	{
		public NetworkTick tick;

		public PugDatabase.DatabaseBankCD databaseBank;
	}
}
