using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceGhost : IComponentData
	{
		public int ID;

		public bool IsHappy;

		public bool IsSale;

		public Entity FromPlayer;
	}
}
