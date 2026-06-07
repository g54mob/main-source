using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.Toolkit
{
	public interface ICoherenceSyncUpdater
	{
		Logger logger { get; set; }

		bool TaggedForNetworkedDestruction { get; set; }

		bool ChangedConnection { get; }

		Entity NewConnection { get; }

		void InterpolateBindings();

		void InvokeCallbacks();

		void SyncAndSend();

		void SampleBindings();

		void SampleAllBindings();

		void GetComponentUpdates(List<ICoherenceComponentData> updates, bool forceSerialize = false);

		void PerformInterpolationOnAllBindings();

		void ClearAllSampleTimes();

		void OnConnectedEntityChanged();

		void ManuallySendAllChanges(bool sampleValuesBeforeSending);

		void SendTag();

		bool TryFlushPosition(bool sampleValueBeforeSending);

		void ApplyComponentDestroys(HashSet<uint> destroyedComponents);

		void ApplyComponentUpdates(ComponentUpdates componentUpdates);
	}
}
