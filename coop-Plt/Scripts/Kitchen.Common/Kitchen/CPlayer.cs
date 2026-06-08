using Unity.Entities;

namespace Kitchen
{
	public struct CPlayer : IComponentData
	{
		public int ID;

		public int Index;

		public float Speed;

		public int InputSource;
	}
}
