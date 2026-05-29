using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Documenting;
using FishNet.Managing.Server;
using FishNet.Object;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.Serialization;

namespace FishNet.Observing
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	[AddComponentMenu("FishNet/Component/NetworkObserver")]
	public sealed class NetworkObserver : MonoBehaviour
	{
		public enum ConditionOverrideType
		{
			AddMissing = 1,
			UseManager = 2,
			IgnoreManager = 3
		}

		[Tooltip("How ObserverManager conditions are used.")]
		[SerializeField]
		private ConditionOverrideType _overrideType;

		[SerializeField]
		[Tooltip("True to update visibility for clientHost based on if they are an observer or not.")]
		[FormerlySerializedAs("_setHostVisibility")]
		private bool _updateHostVisibility;

		[SerializeField]
		[Tooltip("Conditions connections must met to be added as an observer. Multiple conditions may be used.")]
		internal List<ObserverCondition> _observerConditions;

		private List<ObserverCondition> _timedConditions;

		private HashSet<NetworkConnection> _nonTimedMet;

		private NetworkObject _networkObject;

		private bool _registeredAsTimed;

		private bool _initializedPreviously;

		private bool _lastParentVisible;

		private ServerManager _serverManager;

		private bool _hasNormalConditions;

		public ConditionOverrideType OverrideType
		{
			get
			{
				return default(ConditionOverrideType);
			}
			internal set
			{
			}
		}

		public bool UpdateHostVisibility
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public IReadOnlyList<ObserverCondition> ObserverConditions => null;

		[APIExclude]
		internal List<ObserverCondition> ObserverConditionsInternal
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal void Deinitialize(bool destroyed)
		{
		}

		internal void Initialize(NetworkObject networkObject)
		{
		}

		public ObserverCondition GetObserverCondition<T>() where T : ObserverCondition
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal ObserverStateChange RebuildObservers(NetworkConnection connection, bool timedOnly)
		{
			return default(ObserverStateChange);
		}

		private void RegisterTimedConditions()
		{
		}

		private void UnregisterTimedConditions()
		{
		}

		private ObserverStateChange ReturnFailedCondition(bool currentlyAdded)
		{
			return default(ObserverStateChange);
		}

		private ObserverStateChange ReturnPassedConditions(bool currentlyAdded)
		{
			return default(ObserverStateChange);
		}

		private void ServerManager_OnRemoteConnectionState(NetworkConnection conn, RemoteConnectionStateArgs arg2)
		{
		}

		public void SetUpdateHostVisibility(bool value)
		{
		}
	}
}
