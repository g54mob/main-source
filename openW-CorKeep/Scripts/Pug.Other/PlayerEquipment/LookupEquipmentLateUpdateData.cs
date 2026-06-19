using Unity.Collections;
using Unity.Entities;

namespace PlayerEquipment
{
	public struct LookupEquipmentLateUpdateData
	{
		[ReadOnly]
		public ComponentLookup<CustomAttackSoundCD> customAttackSoundLookup;
	}
}
