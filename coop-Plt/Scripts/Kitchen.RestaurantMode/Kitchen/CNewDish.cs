using Unity.Entities;

namespace Kitchen
{
	public struct CNewDish : IComponentData
	{
		public int ID;

		public bool ShowRecipe;
	}
}
