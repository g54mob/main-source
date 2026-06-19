using Unity.Entities;
using Unity.NetCode;

namespace PlayerCommand
{
	public struct UpdatePlayerCustomizationRpc : IRpcCommand, IComponentData, IQueryTypeParameter
	{
		public PlayerCustomization playerCustomization;

		public Entity entity;
	}
}
