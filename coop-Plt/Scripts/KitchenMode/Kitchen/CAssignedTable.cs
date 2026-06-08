using Unity.Entities;

namespace Kitchen
{
	public struct CAssignedTable : IComponentData
	{
		public Entity Table;

		public static implicit operator Entity(CAssignedTable h)
		{
			return h.Table;
		}
	}
}
