using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Items;
using Brewery.Systems;
using InventorySystem;
using UnityEngine;

namespace Brewery.Shelf
{
	public class ShelfDisplayController : MonoBehaviour
	{
		private class ShelfDisplayEntry
		{
			public Item item;

			public List<GameObject> spawnedObjects;

			public bool isStackable;

			public bool isScaleByQuantity;

			public int slotIndex;

			public int quantity;
		}

		[CompilerGenerated]
		private sealed class _003CRefreshAllItemsWhenNetworkReady_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ShelfDisplayController _003C_003E4__this;

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
			public _003CRefreshAllItemsWhenNetworkReady_003Ed__22(int _003C_003E1__state)
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
		private ShelfInventoryManager inventoryManager;

		[SerializeField]
		private Transform itemsContainer;

		[SerializeField]
		private MoneyConfig moneyConfig;

		[Header("Display Settings")]
		[SerializeField]
		private bool randomRotation;

		[SerializeField]
		private Vector3 rotationRange;

		[SerializeField]
		private float itemScale;

		[Header("Realtime Adjustment")]
		[Tooltip("When enabled, item offsets are updated every frame for tweaking in play mode")]
		[SerializeField]
		private bool realtimeOffsetAdjustment;

		[Header("Gizmos")]
		[SerializeField]
		private bool showGizmos;

		[SerializeField]
		private float gizmoSphereSize;

		[SerializeField]
		private bool showSlotNumbers;

		[SerializeField]
		private Color gizmoColor;

		private readonly Dictionary<int, List<GameObject>> spawnedItems;

		private readonly Dictionary<int, ShelfDisplayEntry> displayEntries;

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

		[IteratorStateMachine(typeof(_003CRefreshAllItemsWhenNetworkReady_003Ed__22))]
		private IEnumerator RefreshAllItemsWhenNetworkReady()
		{
			return null;
		}

		private void OnInventoryFullyUpdated()
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnInventorySlotChanged(int slotIndex, InventorySlot slot)
		{
		}

		private void RefreshAllItems()
		{
		}

		private void UpdateItemAtSlot(int slotIndex, InventorySlot slot)
		{
		}

		private void SpawnSingleItem(int slotIndex, Item item)
		{
		}

		private void SpawnBottleGrid(int slotIndex, Item item, int quantity, InventorySlot slot = null)
		{
		}

		private void SpawnScaledSingleItem(int slotIndex, Item item, int quantity)
		{
		}

		private void SpawnMoneyStack(int slotIndex, MoneyItem moneyItem, int quantity)
		{
		}

		internal static float CalculateQuantityScale(ShelfDisplaySettings settings, int quantity, int maxStack)
		{
			return 0f;
		}

		internal static int CalculateDisplayCount(int quantity, int maxStack, int maxDisplayCount)
		{
			return 0;
		}

		private void HandleCrateDisplay(int slotIndex, GameObject crateObject)
		{
		}

		private void ProcessPendingCrateDisplays()
		{
		}

		private Vector3 CalculateSlotPosition(int slotIndex)
		{
			return default(Vector3);
		}

		private Quaternion CalculateSlotRotation()
		{
			return default(Quaternion);
		}

		private void EnableBarrelDispenser(GameObject barrelObj)
		{
		}

		private void DisablePhysicsAndInteraction(GameObject obj)
		{
		}

		public void ClearDisplay()
		{
		}
	}
}
