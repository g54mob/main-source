using Unity.Entities;
using UnityEngine.Scripting;

namespace PlayerEquipment
{
	[UpdateAfter(typeof(EquipmentUpdateSystemGroup))]
	[UpdateInGroup(typeof(EquipmentSystemGroup))]
	public class EquipmentAfterUpdateSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public EquipmentAfterUpdateSystemGroup()
		{
		}
	}
}
