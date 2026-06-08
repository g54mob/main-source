using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CProgressionRequest : IComponentData
	{
		public UnlockGroup Group;
	}
}
