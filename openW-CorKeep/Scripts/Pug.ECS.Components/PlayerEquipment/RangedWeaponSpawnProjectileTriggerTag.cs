using System.Runtime.InteropServices;
using Unity.Entities;

namespace PlayerEquipment
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct RangedWeaponSpawnProjectileTriggerTag : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
