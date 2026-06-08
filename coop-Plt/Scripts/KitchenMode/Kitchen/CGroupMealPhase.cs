using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CGroupMealPhase : IComponentData
	{
		public MenuPhase Phase;

		public static implicit operator MenuPhase(CGroupMealPhase p)
		{
			return p.Phase;
		}
	}
}
