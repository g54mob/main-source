using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CEffectRangeTiles : IEffectRange, IAttachableProperty, IComponentData
	{
		public bool PassThroughWalls;

		public int Tiles;
	}
}
