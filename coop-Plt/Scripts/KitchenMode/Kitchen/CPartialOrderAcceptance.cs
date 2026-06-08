using Unity.Entities;

namespace Kitchen
{
	public struct CPartialOrderAcceptance : IComponentData
	{
		public int OrderIndex;

		public int MemberIndex;

		public Entity Group;

		public Entity Source;

		public int MaxSharers;

		public int ComponentServed;
	}
}
