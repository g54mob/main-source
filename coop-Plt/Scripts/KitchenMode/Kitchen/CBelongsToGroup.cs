using Unity.Entities;

namespace Kitchen
{
	public struct CBelongsToGroup : IComponentData
	{
		public Entity Group;

		public int IndexInGroup;
	}
}
