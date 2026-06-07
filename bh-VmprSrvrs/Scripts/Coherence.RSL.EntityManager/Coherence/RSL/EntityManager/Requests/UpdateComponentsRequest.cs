using Coherence.Entities;
using Coherence.Log;

namespace Coherence.RSL.EntityManager.Requests
{
	public class UpdateComponentsRequest : RequestInfo
	{
		private ICoherenceComponentData[] comps;

		public UpdateComponentsRequest(Entity entity, uint participant, FloatingOrigin origin, EntityMeta meta, bool isInternal, ICoherenceComponentData[] comps)
			: base(default(Entity), 0u, default(FloatingOrigin), default(EntityMeta), isInternal: false)
		{
		}

		public ICoherenceComponentData[] GetComponentData()
		{
			return null;
		}

		public void SetComponentData(ICoherenceComponentData[] comps)
		{
		}

		public override RefsInfo GetReferenceInfo()
		{
			return default(RefsInfo);
		}

		public override IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}
	}
}
