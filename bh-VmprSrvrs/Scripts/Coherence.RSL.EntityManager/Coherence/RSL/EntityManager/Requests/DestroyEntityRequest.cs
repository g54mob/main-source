using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Requests
{
	public class DestroyEntityRequest : RequestInfo
	{
		private DestroyReason reason;

		public DestroyEntityRequest(Entity entity, uint participant, FloatingOrigin origin, EntityMeta meta, bool isInternal, DestroyReason reason)
			: base(default(Entity), 0u, default(FloatingOrigin), default(EntityMeta), isInternal: false)
		{
		}

		public DestroyReason GetDestroyReason()
		{
			return default(DestroyReason);
		}
	}
}
