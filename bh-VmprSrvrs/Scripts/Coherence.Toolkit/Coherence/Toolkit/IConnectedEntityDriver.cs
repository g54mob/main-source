using UnityEngine;

namespace Coherence.Toolkit
{
	public interface IConnectedEntityDriver
	{
		bool HasStateAuthority { get; }

		CoherenceSync ConnectedEntity { get; }

		event CoherenceSync.ConnectedEntityChangeHandler ConnectedEntityChangeOverride;

		event CoherenceSync.ConnectedEntitySentHandler DidSendConnectedEntity;

		void SetParent(Transform parent);
	}
}
