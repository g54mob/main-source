using System;
using System.Collections.Generic;
using System.Numerics;
using Coherence.Brook;
using Coherence.Entities;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;

namespace Coherence.Core.Channels
{
	internal interface IInNetworkChannel
	{
		event Action<List<IncomingEntityUpdate>> OnEntityUpdate;

		event Action<IEntityCommand, MessageTarget, Entity> OnCommand;

		event Action<IEntityInput, long, Entity> OnInput;

		bool Deserialize(IInBitStream stream, AbsoluteSimulationFrame packetSimulationFrame, Vector3 floatingOriginDelta);

		List<RefsInfo> GetRefsInfos();

		void FlushBuffer(IReadOnlyCollection<Entity> resolvableEntities);

		void Clear();
	}
}
