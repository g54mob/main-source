using Unity.Entities;

namespace PlayerEquipment
{
	public struct EquipmentData
	{
		public BlobArray<EquipmentInfo> equipmentInfo;

		public ref EquipmentInfo GetEquipmentInfo(EquipmentSlotType equipmentSlotType)
		{
			return ref equipmentInfo[(int)equipmentSlotType];
		}
	}
}
