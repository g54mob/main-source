using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Stations.Components.Interfaces;
using InventorySystem;

namespace Brewery.Stations.Components.Adapters
{
	public sealed class InventoryManagerAdapter : IInventoryQuery, IInventoryModifier
	{
		[CompilerGenerated]
		private sealed class _003CEnumerate_003Ed__4 : IEnumerable<InventorySlotSnapshot>, IEnumerable, IEnumerator<InventorySlotSnapshot>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private InventorySlotSnapshot _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public InventoryManagerAdapter _003C_003E4__this;

			private InventorySlot[] _003Cslots_003E5__2;

			private int _003Ci_003E5__3;

			InventorySlotSnapshot IEnumerator<InventorySlotSnapshot>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(InventorySlotSnapshot);
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
			public _003CEnumerate_003Ed__4(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<InventorySlotSnapshot> IEnumerable<InventorySlotSnapshot>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private readonly InventoryManager inventory;

		public InventoryManagerAdapter(InventoryManager inventory)
		{
		}

		public int GetQuantity(string itemId)
		{
			return 0;
		}

		public bool HasItem(string itemId, int quantity)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CEnumerate_003Ed__4))]
		public IEnumerable<InventorySlotSnapshot> Enumerate()
		{
			return null;
		}

		public bool TryRemoveItem(string itemId, int quantity)
		{
			return false;
		}

		public bool TryAddItem(string itemId, int quantity)
		{
			return false;
		}
	}
}
