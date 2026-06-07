using System;
using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;
using Coherence.Toolkit.Bindings;

namespace Coherence.Toolkit
{
	public abstract class CoherenceSyncBaked : IDisposable
	{
		public abstract void Initialize(Entity entityId, CoherenceBridge bridge, IClient client, CoherenceInput input, Logger logger);

		public abstract Binding BakeValueBinding(Binding valueBinding);

		public abstract void BakeCommandBinding(CommandBinding commandBinding, CommandsHandler commandsHandler);

		public virtual void ReceiveCommand(IEntityCommand command)
		{
		}

		public abstract void CreateEntity(bool usesLodsAtRuntime, string archetypeName, AbsoluteSimulationFrame simFrame, List<ICoherenceComponentData> components);

		public virtual void SendInputState()
		{
		}

		public abstract void Dispose();
	}
}
