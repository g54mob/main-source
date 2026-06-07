using Coherence.Entities;

namespace Coherence.RSL.EntityManager
{
	public struct OrphanRefData
	{
		public Entity Orphan;

		public ComponentData ComponentData;

		public uint RefHoldingComponent;

		public EntityMeta Meta;
	}
}
