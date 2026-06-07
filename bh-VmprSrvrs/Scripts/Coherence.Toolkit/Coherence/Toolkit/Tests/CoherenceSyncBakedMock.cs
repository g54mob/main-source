using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;
using Coherence.Toolkit.Bindings;
using UnityEngine;

namespace Coherence.Toolkit.Tests
{
	[DisallowMultipleComponent]
	internal class CoherenceSyncBakedMock : CoherenceSyncBaked
	{
		private readonly Dictionary<string, int> callCountByName;

		public int TimesCalled(string methodName)
		{
			return 0;
		}

		public override Binding BakeValueBinding(Binding valueBinding)
		{
			return null;
		}

		public override void BakeCommandBinding(CommandBinding commandBinding, CommandsHandler commandsHandler)
		{
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
		}

		public override void Initialize(Entity entityId, CoherenceBridge bridge, IClient client, CoherenceInput input, Coherence.Log.Logger logger)
		{
		}

		public override void CreateEntity(bool usesLodsAtRuntime, string archetypeName, AbsoluteSimulationFrame simFrame, List<ICoherenceComponentData> components)
		{
		}

		public override void Dispose()
		{
		}

		private void AddCall(string methodName)
		{
		}
	}
}
