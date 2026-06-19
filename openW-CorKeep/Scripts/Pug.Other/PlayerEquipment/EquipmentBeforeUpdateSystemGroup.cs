using Unity.Entities;
using UnityEngine.Scripting;

namespace PlayerEquipment
{
	[UpdateBefore(typeof(EquipmentUpdateSystemGroup))]
	[UpdateInGroup(typeof(EquipmentSystemGroup))]
	public class EquipmentBeforeUpdateSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public EquipmentBeforeUpdateSystemGroup()
		{
		}
	}
}
