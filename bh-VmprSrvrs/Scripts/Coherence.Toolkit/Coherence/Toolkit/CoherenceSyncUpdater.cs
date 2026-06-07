using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;
using Coherence.SimulationFrame;
using Coherence.Toolkit.Bindings;
using Coherence.Toolkit.Bindings.TransformBindings;
using UnityEngine;

namespace Coherence.Toolkit
{
	internal class CoherenceSyncUpdater : ICoherenceSyncUpdater
	{
		private bool hasTriggeredMissingBridgeWarning;

		private string lastSerializedCoherenceUUID;

		private string lastSerializedTag;

		private readonly ICoherenceSync coherenceSync;

		private readonly IClient client;

		private const float minTimeBetweenAdoptionRequests = 0.5f;

		private readonly List<Binding> valueBindings;

		private readonly Dictionary<string, List<Binding>> valueBindingsByComponent;

		private PositionBinding positionBinding;

		private bool initialSampleDone;

		private bool initialSyncDone;

		private bool changedConnection;

		private Entity newConnection;

		private bool didChangeParent;

		private readonly List<ICoherenceComponentData> queuedUpdates;

		public Coherence.Log.Logger logger { get; set; }

		public bool TaggedForNetworkedDestruction { get; set; }

		public bool ChangedConnection => false;

		public Entity NewConnection => default(Entity);

		public CoherenceSyncUpdater(ICoherenceSync coherenceSync, IClient client)
		{
		}

		public void InterpolateBindings()
		{
		}

		public void InvokeCallbacks()
		{
		}

		public void SampleBindings()
		{
		}

		public void SyncAndSend()
		{
		}

		public void GetComponentUpdates(List<ICoherenceComponentData> updates, bool forceSerialize = false)
		{
		}

		public void PerformInterpolationOnAllBindings()
		{
		}

		public void SampleAllBindings()
		{
		}

		private void InvokeValueSyncCallbacksOnAllBindings()
		{
		}

		public void ClearAllSampleTimes()
		{
		}

		public void OnConnectedEntityChanged()
		{
		}

		public void ManuallySendAllChanges(bool sampleValuesBeforeSending)
		{
		}

		public void ApplyComponentDestroys(HashSet<uint> destroyedComponents)
		{
		}

		public void ApplyComponentUpdates(ComponentUpdates componentUpdates)
		{
		}

		private void ApplySingleUpdate(ComponentChange change, Vector3 floatingOriginDelta)
		{
		}

		private bool ApplyInternalUpdate(string componentName, ICoherenceComponentData newComponentData)
		{
			return false;
		}

		private bool EnsureEntityInitializedAndReady()
		{
			return false;
		}

		private void ProcessOrphanedBehavior()
		{
		}

		private void ProcessInitialSync()
		{
		}

		private void UpdateValueBindings()
		{
		}

		private ICoherenceComponentData SerializeBinding(Binding binding, ICoherenceComponentData inst, AbsoluteSimulationFrame simulationFrame)
		{
			return null;
		}

		public void SendTag()
		{
		}

		private void SendComponentUpdates(bool forceSerialize = false)
		{
		}

		public bool TryFlushPosition(bool sampleValueBeforeSending)
		{
			return false;
		}
	}
}
