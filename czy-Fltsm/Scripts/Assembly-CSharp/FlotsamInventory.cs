using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlotsamInventory : InventoryBase
{
	[Header("Transfers")]
	public int TransferAnimationCycles = 1;

	public Activity Pickup = Activity.ItemTaking;

	public Activity Dropoff = Activity.ItemDropping;

	private CompositionInventory _composition;

	private bool _compositionUpdated;

	private Target _target;

	public override InventoryType Type => InventoryType.Flotsam;

	public override Target Target => _target;

	public override Activity PickupActivity => Pickup;

	public override Activity DropoffActivity => Dropoff;

	public override int AnimationCycles => TransferAnimationCycles;

	public Item.Tags Tags { get; private set; }

	public event UnityAction<float> CompositionUpdatedEvent;

	public void Initialize(CompositionInventory composition)
	{
		_composition = composition;
		_composition.UpdatedEvent += OnCompositionUpdatedEvent;
		Tags = Item.Tags.None;
		foreach (Item item in _composition.ReturnAllItems())
		{
			item.SetInventory(this, SubInventoryType.Composition);
			Tags |= item.Properties.Tags;
		}
		_target = GetComponent<Target>();
	}

	public void Initialize(IEnumerable<CountedItemProperty> composition)
	{
		_composition = new CompositionInventory(composition);
		_composition.Fill(this, composition);
		Initialize(_composition);
	}

	public void Initialize(List<Item> composition)
	{
		Initialize(new CompositionInventory(composition));
	}

	private void LateUpdate()
	{
		if (_compositionUpdated && this.CompositionUpdatedEvent != null)
		{
			this.CompositionUpdatedEvent(_composition.ReturnProgress());
			_compositionUpdated = false;
		}
	}

	private void OnDisable()
	{
		if (_composition != null)
		{
			_composition.UpdatedEvent -= OnCompositionUpdatedEvent;
		}
	}

	private void OnDestroy()
	{
		this.CompositionUpdatedEvent = null;
	}

	public override bool AddItem(Item item, SubInventoryType subInventory)
	{
		throw new NotSupportedException("Items can't be added to a Flotsam Inventory!");
	}

	public override Item TakeItem(Item item)
	{
		Item item2 = _composition.TakeItem(item);
		if (item2 == null)
		{
			return null;
		}
		item2 = item2.ReturnSubItem();
		ItemEvent.Dispatch(GameEventType.FlotsamItemSalvage, item2);
		return item2;
	}

	public void Count(InventoryAuditor auditor)
	{
		auditor.CountInventory(_composition);
	}

	public List<Item> ReturnAllItems()
	{
		if (_composition == null)
		{
			throw new NotSupportedException();
		}
		return _composition.ReturnAllItems();
	}

	public float ReturnCompositionProgress()
	{
		if (_composition == null)
		{
			return 0f;
		}
		return _composition.ReturnProgress();
	}

	public List<Item> ReturnItemsWithTags(Item.Tags tags, List<Item> listToPopulate = null, bool includeReserved = true)
	{
		if (_composition == null)
		{
			return null;
		}
		return _composition.ReturnItemsWithTags(tags, listToPopulate, includeReserved);
	}

	private void OnCompositionUpdatedEvent(float progress)
	{
		_compositionUpdated = true;
	}
}
