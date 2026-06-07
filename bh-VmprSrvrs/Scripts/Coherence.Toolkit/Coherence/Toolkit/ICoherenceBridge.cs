using System;
using System.Collections;
using Coherence.Cloud;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	public interface ICoherenceBridge
	{
		private const string StartCoroutineObsoleteMessage = "Coroutines should no longer be started via the ICoherenceBridge interface. Use a MonoBehaviour instead.";

		long ClientFixedSimulationFrame { get; }

		double NetworkTimeAsDouble { get; }

		Scene? InstantiationScene { get; }

		bool IsSimulatorOrHost { get; }

		bool IsConnected { get; }

		bool IsConnecting { get; }

		bool EnableClientConnections { get; set; }

		bool CreateGlobalQuery { get; set; }

		bool HasActiveGlobalQuery { get; }

		Transform Transform { get; }

		ClientID ClientID { get; }

		CoherenceClientConnectionManager ClientConnections { get; }

		IClient Client { get; }

		Scene Scene { get; }

		CoherenceInputManager InputManager { get; }

		INetworkTime NetworkTime { get; }

		ConnectionType ConnectionType { get; }

		EntitiesManager EntitiesManager { get; }

		UniquenessManager UniquenessManager { get; }

		AuthorityManager AuthorityManager { get; }

		CloudService CloudService { get; }

		bool AutoLoginAsGuest { get; }

		string NetworkPrefix { get; }

		Coherence.Log.Logger Logger { get; }

		FixedUpdateInput FixedUpdateInput { get; }

		event Action OnFixedNetworkUpdate;

		event Action OnLateFixedNetworkUpdate;

		event Action OnTimeReset;

		event Action<FloatingOriginShiftArgs> OnAfterFloatingOriginShifted;

		event Action<ICoherenceBridge> OnConnectedInternal;

		[Obsolete("Coroutines should no longer be started via the ICoherenceBridge interface. Use a MonoBehaviour instead.", false)]
		[Deprecated("07/2024", 1, 2, 4, Reason = "Coroutines should no longer be started via the ICoherenceBridge interface. Use a MonoBehaviour instead.")]
		Coroutine StartCoroutine(IEnumerator routine);

		CoherenceSyncConfig GetClientConnectionEntry();

		CoherenceSyncConfig GetSimulatorConnectionEntry();

		ICoherenceSync GetCoherenceSyncForEntity(Entity id);

		void OnNetworkEntityDestroyedInvoke(NetworkEntityState state, DestroyReason destroyReason);

		void OnNetworkEntityCreatedInvoke(NetworkEntityState state);

		Entity UnityObjectToEntityId(GameObject from);

		Entity UnityObjectToEntityId(Transform from);

		Entity UnityObjectToEntityId(ICoherenceSync from);

		GameObject EntityIdToGameObject(Entity from);

		Transform EntityIdToTransform(Entity from);

		RectTransform EntityIdToRectTransform(Entity from);

		CoherenceSync EntityIdToCoherenceSync(Entity from);

		void Disconnect();

		bool TranslateFloatingOrigin(Vector3d translation);

		bool TranslateFloatingOrigin(Vector3 translation);

		bool SetFloatingOrigin(Vector3d newOrigin);

		Vector3d GetFloatingOrigin();
	}
}
