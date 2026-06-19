using Unity.Entities;
using UnityEngine.Scripting;

namespace PlayerEquipment
{
	[UpdateInGroup(typeof(EquipmentSystemGroup))]
	public class EquipmentUpdateSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public EquipmentUpdateSystemGroup()
		{
		}
	}
}
