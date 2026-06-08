using Unity.Entities;

namespace Kitchen
{
	public struct CPlayerDirtyShoes : IComponentData
	{
		public float TimeUntil;

		public int MessID;
	}
}
