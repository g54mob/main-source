using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace InventorySystem
{
	public class VehicleBedItemDisplay : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CRefreshAllItemsWhenNetworkReady_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleBedItemDisplay _003C_003E4__this;

			private float _003CmaxWait_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CRefreshAllItemsWhenNetworkReady_003Ed__18(int _003C_003E1__state)
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

		[Header("References")]
		[SerializeField]
		private VehicleInventoryManager inventoryManager;

		[Header("Display Settings")]
		[SerializeField]
		private bool spawnItemsOnStart;

		[SerializeField]
		private float itemHeightOffset;

		[Header("Box Display Overrides")]
		[Tooltip("Visual offset for cardboard box items in the vehicle bed")]
		[SerializeField]
		private Vector3 boxVisualOffset;

		[Tooltip("Visual rotation (Euler angles) for cardboard box items in the vehicle bed")]
		[SerializeField]
		private Vector3 boxVisualRotation;

		[Tooltip("Scale multiplier for cardboard box items in the vehicle bed (1 = default prefab scale)")]
		[SerializeField]
		private float boxScale;

		[Tooltip("Extra spacing between box items, scaled by grid position (e.g. X=0.1 pushes columns apart)")]
		[SerializeField]
		private Vector3 boxSpacingOffset;

		[Header("Realtime Preview")]
		[Tooltip("When enabled in Play Mode, changing Inspector values will live-refresh all displayed items")]
		[SerializeField]
		private bool realtimePreview;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private readonly Dictionary<int, GameObject> spawnedItems;

		private readonly Dictionary<int, GameObject> pendingCrateDisplays;

		private readonly Dictionary<int, int> crateDisplayRetryCount;

		private const int MAX_CRATE_DISPLAY_RETRIES = 5;

		private const float CRATE_DISPLAY_RETRY_DELAY = 0.1f;

		private bool _isNetworkReady;

		private readonly HashSet<int> _pendingSlotUpdates;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CRefreshAllItemsWhenNetworkReady_003Ed__18))]
		private IEnumerator RefreshAllItemsWhenNetworkReady()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void OnInventorySlotChanged(int slotIndex, InventorySlot slot)
		{
		}

		private void RefreshAllItems()
		{
		}

		public void ForceRefreshAllItems()
		{
		}

		private void UpdateItemAtSlot(int slotIndex, InventorySlot slot)
		{
		}

		private void SpawnItemAtSlot(int slotIndex, InventorySlot slot)
		{
		}

		private void HandleCrateDisplay(int slotIndex, GameObject crateObject)
		{
		}

		private void ProcessPendingCrateDisplays()
		{
		}

		private void ClearItemAtSlot(int slotIndex)
		{
		}

		private void ClearAllItems()
		{
		}

		private void DisablePhysicsAndInteraction(GameObject itemObject)
		{
		}

		[ContextMenu("Refresh All Items")]
		private void EditorRefreshAllItems()
		{
		}

		[ContextMenu("Clear All Items")]
		private void EditorClearAllItems()
		{
		}
	}
}
