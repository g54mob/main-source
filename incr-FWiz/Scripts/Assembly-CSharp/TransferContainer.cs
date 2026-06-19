using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class TransferContainer : BuildingBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPassItemsCoroutine_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TransferContainer _003C_003E4__this;

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
		public _003CPassItemsCoroutine_003Ed__34(int _003C_003E1__state)
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

	[SerializeField]
	protected DropCollector _dropCollector;

	[SerializeField]
	protected PickupSupplier _pickupSupplier;

	public TransferContainerUI TransferContainerUI;

	public ItemSendPipe OutputPipe;

	public float OutputInterval;

	public Coroutine ItemOutputCoroutine;

	public TransferContainerLightPing PingAnimation;

	public EventReference TransferSound;

	[field: SerializeField]
	public ItemStack ItemStack { get; private set; }

	[field: SerializeField]
	public int Capacity { get; private set; }

	public ItemType ItemType => null;

	public bool Empty => false;

	public bool Full => false;

	public override void SetBuilding(Building building)
	{
	}

	public IEnumerable<ItemStack> GetStorageItemsForDeconstruction()
	{
		return null;
	}

	public override void Initiate()
	{
	}

	public virtual void OnDestroy()
	{
	}

	public virtual bool CanCollect(ItemType itemType)
	{
		return false;
	}

	public void AddItem(ItemType itemType)
	{
	}

	public ItemType Peek()
	{
		return null;
	}

	public bool RemoveItem()
	{
		return false;
	}

	public void UpdateUI()
	{
	}

	private void InitiateNewStack(ItemType itemType)
	{
	}

	public void AddCapacity(int capacity)
	{
	}

	public void TryStartPassingItems()
	{
	}

	[IteratorStateMachine(typeof(_003CPassItemsCoroutine_003Ed__34))]
	public virtual IEnumerator PassItemsCoroutine()
	{
		return null;
	}

	public virtual bool TrySendItem()
	{
		return false;
	}

	public bool TrySendItem(ItemSendPipe pipe)
	{
		return false;
	}
}
