using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class Larder_Tile : Prop, IAcceptedSlotItemKeyProvider
	{
		[CompilerGenerated]
		private sealed class _003CGetContextMenuItems_003Ed__40 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Larder_Tile _003C_003E4__this;

			private IEnumerator<ContextMenuItem> _003C_003E7__wrap1;

			ContextMenuItem IEnumerator<ContextMenuItem>.Current
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
			public _003CGetContextMenuItems_003Ed__40(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ContextMenuItem> IEnumerable<ContextMenuItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public string DefaultEmptyTileLabelKey;

		public static HashSet<Larder_Tile> AllLarder_Tiles;

		public static EventHandler<EventArgs> AllLarder_TilesChanged;

		public bool AllowConfiguration;

		public bool ConfigurationIsMandatory;

		public List<string> allowedItemsToStore;

		public List<string> disallowedItemsToStore;

		public string allowedItemSize;

		private Transform[] _dropTargets;

		public List<Transform> reservedVisualTargets;

		[PersistenceOptIn]
		private Dictionary<int, int> _storedItemIds;

		private Dictionary<int, GameObject> _acceptedItemVisuals;

		public GameObject reservedVisualPrefab;

		[PersistenceOptIn]
		public Dictionary<int, string> AcceptedItemTemplateIds { get; private set; }

		public string GetAcceptedItemKey(int index)
		{
			return null;
		}

		public int GetSlotCount()
		{
			return 0;
		}

		public override void Start()
		{
		}

		private void AddSpawnItemContextMenus()
		{
		}

		public bool CanStoreItemType(GameItem item, bool ignoreItemSize = false)
		{
			return false;
		}

		public bool IsAvailableToStoreItem(GameItem item, bool ignoreAmount = false)
		{
			return false;
		}

		public void SetAcceptedItemAtSlots_UICallback(Dictionary<int, string> items)
		{
		}

		public virtual void SetAcceptedItemAtSlot(GameItemTemplate template, int slot)
		{
		}

		private void RemoveUnacceptedItems()
		{
		}

		public void CheckReservedSpotsAndCreateMoveItemToStorageJobs()
		{
		}

		private bool IsItemOnReservedSpot(GameItem gameItem)
		{
			return false;
		}

		public override int GetPositionFor(GameItemTemplate template, int amount, bool ignoreOverride = true)
		{
			return 0;
		}

		public int GetPositionForPickup(GameItem item, bool ignoreOverride = true)
		{
			return 0;
		}

		public int GetPositionFor(GameItem item, bool ignoreOverride = true)
		{
			return 0;
		}

		public void ReplaceItem(GameItem source, GameItem target, bool silently = false, bool removeReservation = false)
		{
		}

		private void UpdatePositions()
		{
		}

		public virtual void UpdateVisuals()
		{
		}

		private void UpdateReservationVisual()
		{
		}

		public void InventoryChanged()
		{
		}

		public override GameItem[] GetInventoryContentOrdered()
		{
			return null;
		}

		private void Inventory_ItemRemoved(object sender, GameItemEventArgs e)
		{
		}

		public void TryFill(GameItemTemplate template)
		{
		}

		private void Inventory_ItemAdded(object sender, GameItemEventArgs e)
		{
		}

		[IteratorStateMachine(typeof(_003CGetContextMenuItems_003Ed__40))]
		public override IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		public override void OnDestroy()
		{
		}

		public IEnumerable<ContextMenuItem> CreateSlotMenu(int slotIndex)
		{
			return null;
		}
	}
}
