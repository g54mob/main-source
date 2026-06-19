using System.Runtime.InteropServices;
using Unity.Entities;

namespace PlayerEquipment
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct AttackWithEquipmentTag : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
