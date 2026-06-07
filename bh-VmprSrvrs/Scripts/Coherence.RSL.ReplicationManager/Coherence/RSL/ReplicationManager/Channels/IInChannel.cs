using System.Collections.Generic;
using System.Numerics;
using Coherence.Brook;
using Coherence.Entities;
using Coherence.ProtocolDef;
using Coherence.RSL.EntityManager.Requests;
using Coherence.SimulationFrame;

namespace Coherence.RSL.ReplicationManager.Channels
{
	public interface IInChannel
	{
		bool Deserialize(IInBitStream stream, AbsoluteSimulationFrame packetSimulationFrame, Vector3 floatingOriginDelta);

		void FlushBuffer(List<IBaseRequest> requestBuffer, List<InternalDestroy> destroyBuffer, List<Entity> resolvableEntities);

		bool HasNothingToProcess();

		List<RefsInfo> GetRefsInfos();

		void MapResolvableEntities(List<Entity> resolvableEntities);
	}
}
