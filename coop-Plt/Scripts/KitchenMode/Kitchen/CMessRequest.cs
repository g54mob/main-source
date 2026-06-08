using Unity.Entities;

namespace Kitchen
{
	public struct CMessRequest : IComponentData
	{
		public int ID;

		public bool OverwriteOtherMesses;
	}
}
