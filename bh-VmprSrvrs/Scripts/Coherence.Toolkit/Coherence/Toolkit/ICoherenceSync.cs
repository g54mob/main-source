using System;
using System.Collections.Generic;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.ProtocolDef;
using Coherence.Toolkit.Bindings;
using UnityEngine;
using UnityEngine.Events;

namespace Coherence.Toolkit
{
	public interface ICoherenceSync
	{
		UnityEvent OnInputSimulatorConnected => null;

		bool HasStateAuthority => false;

		bool IsOrphaned => false;

		bool HasInputAuthority => false;

		bool IsSynchronizedWithNetwork => false;

		CoherenceSyncConfig CoherenceSyncConfig { get; }

		NetworkEntityState EntityState { get; }

		CoherenceSync.SimulationType SimulationTypeConfig { get; }

		CoherenceSync.LifetimeType LifetimeTypeConfig { get; }

		CoherenceSync.AuthorityTransferType AuthorityTransferTypeConfig { get; }

		ICoherenceBridge CoherenceBridge { get; }

		ICoherenceSyncUpdater Updater { get; }

		string name { get; }

		Transform transform { get; }

		GameObject gameObject { get; }

		bool PreserveChildren { get; }

		bool HasInput { get; }

		bool UsesLODsAtRuntime { get; }

		string ArchetypeName { get; }

		bool HasParentWithCoherenceSync { get; }

		string ManualUniqueId { get; }

		CoherenceInput Input { get; }

		CoherenceSyncBaked BakedScript { get; }

		Vector3 coherencePosition { get; }

		bool IsUnique { get; }

		bool IsGlobal { get; }

		CoherenceSync.UniqueObjectReplacementStrategy ReplacementStrategy { get; }

		CoherenceSync.UnsyncedNetworkEntityPriority UnsyncedEntityPriority { get; }

		CoherenceSync ConnectedEntity { get; }

		CoherenceSync.InterpolationLoop InterpolationLocationConfig { get; }

		CoherenceSync.OrphanedBehavior OrphanedBehaviorConfig { get; }

		List<Binding> Bindings { get; }

		string CoherenceTag { get; set; }

		Action<Vector3, Vector3> OnFloatingOriginShifted { get; set; }

		event UnityAction OnStateAuthority
		{
			add
			{
			}
			remove
			{
			}
		}

		event UnityAction OnInputAuthority
		{
			add
			{
			}
			remove
			{
			}
		}

		event UnityAction OnStateRemote
		{
			add
			{
			}
			remove
			{
			}
		}

		bool Adopt()
		{
			return false;
		}

		bool RequestAuthority(AuthorityType authorityType)
		{
			return false;
		}

		void HandleNetworkedDestruction(bool destroyAsParent);

		void DestroyAsDuplicate();

		void ReceiveCommand(IEntityCommand command, MessageTarget target);

		void HandleDisconnected();

		void ResetInterpolation(bool setToLastSamples = false);

		void SetObservedLodLevel(int lod);

		bool RaiseOnAuthorityRequested(ClientID requesterID, AuthorityType authorityType);

		bool TryGetBindingByGuid(string bindingGuid, out Binding outBinding);

		void OnNetworkCommandReceived(object sender, byte[] data);

		void InitializeReplacedUniqueObject(SpawnInfo info);

		bool IsChildFromSyncGroup();

		T GetBakedValueBinding<T>(string bindingName = null) where T : Binding;

		void SendConnectedEntity();

		void ValidateConnectedEntity();

		bool ConnectedEntityChanged(Entity newConnectedEntityID, out bool didChangeParent);

		void ApplyNodeBindings();

		bool ShouldShift();

		bool ShiftOrigin(Vector3d delta);

		void RaiseOnConnectedEntityChanged();

		private void Warning(string message)
		{
		}
	}
}
