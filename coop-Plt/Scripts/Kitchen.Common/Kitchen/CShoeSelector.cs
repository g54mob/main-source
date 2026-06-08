using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CShoeSelector : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public PlayerShoe Shoe;

		public int Available;

		public int Max;
	}
}
