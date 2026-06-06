using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Map
{
	[RequireComponent(typeof(NetworkObject))]
	public class MapIconManager : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CInitializeDelayed_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MapIconManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CInitializeDelayed_003Ed__17(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Update Settings")]
		[Tooltip("Delay before first scan after initialization (allows scene to settle)")]
		[Range(0f, 2f)]
		public float initialScanDelay;

		[Header("References")]
		[SerializeField]
		private CustomMapController mapController;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private IMapController _activeController;

		private Transform iconContainer;

		private Dictionary<MapIconTarget, MapIcon> activeIcons;

		private bool isInitialized;

		private Coroutine initCoroutine;

		private bool cachedIsMapOpen;

		private bool cachedIsTransitioning;

		private Vector3 cachedCameraPosition;

		public static MapIconManager Instance { get; private set; }

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		[IteratorStateMachine(typeof(_003CInitializeDelayed_003Ed__17))]
		private IEnumerator InitializeDelayed()
		{
			return null;
		}

		private void Initialize()
		{
		}

		private void HandleTargetRegistered(MapIconTarget target)
		{
		}

		private void HandleTargetUnregistered(MapIconTarget target)
		{
		}

		private void LateUpdate()
		{
		}

		private void PopulateInitialIcons()
		{
		}

		private void UpdateAllIcons()
		{
		}

		private void SpawnIcon(MapIconTarget target)
		{
		}

		private static void SetLayerRecursive(GameObject obj, int layer)
		{
		}

		private void CleanupAllIcons()
		{
		}

		public override void OnDestroy()
		{
		}

		public int GetActiveIconCount()
		{
			return 0;
		}

		public void ForceRefresh()
		{
		}

		public void RefreshIcon(MapIconTarget target)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
