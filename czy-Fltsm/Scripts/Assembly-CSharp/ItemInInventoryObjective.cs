using System;
using UnityEngine;

[Serializable]
public class ItemInInventoryObjective : QuestObjectiveBase
{
	[SerializeField]
	private ItemProperties _itemProperties;

	[SerializeField]
	private int _amount;

	private CommunityInventory _inventory;

	private int _count;

	public ItemInInventoryObjective()
	{
	}

	public ItemInInventoryObjective(ItemInInventoryObjective other)
		: base(other)
	{
		_itemProperties = other._itemProperties;
		_amount = other._amount;
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.AddListener(GameEventType.CommunityInventoryUpdated, OnCommunityInventoryUpdated);
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		if (active)
		{
			_inventory = Community.PlayerCommunity.Inventory;
			UpdateCount();
			if (!IsOptional && IsCompleted())
			{
				SetCompleted(completed: true, sendEvent: false);
			}
			else
			{
				GameEventDispatcher.AddListener(GameEventType.CommunityInventoryUpdated, OnCommunityInventoryUpdated);
			}
		}
		else
		{
			GameEventDispatcher.RemoveListener(GameEventType.CommunityInventoryUpdated, OnCommunityInventoryUpdated);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Items in inventory: " + ((_itemProperties != null) ? _itemProperties.LocalizedName : "Any");
	}

	protected override bool TryGetProgressValues(out int currentValue, out int goalValue)
	{
		currentValue = _count;
		goalValue = _amount;
		return true;
	}

	public override string GetParameterValue(string param)
	{
		if (param == "ITEM")
		{
			return (_itemProperties != null) ? _itemProperties.LocalizedName : "Any";
		}
		return base.GetParameterValue(param);
	}

	public override object Clone()
	{
		return new ItemInInventoryObjective(this);
	}

	private void UpdateCount()
	{
		if (_inventory != null)
		{
			_count = Mathf.Clamp(_inventory.ReturnCount(_itemProperties), 0, _amount);
		}
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			return _amount <= _count;
		}
		return true;
	}

	private void OnCommunityInventoryUpdated(GameEvent gameEvent = null)
	{
		int count = _count;
		UpdateCount();
		if (!IsOptional && IsCompleted())
		{
			SetCompleted(completed: true);
		}
		else if (count != _count)
		{
			QuestEvent.DispatchQuestObjectiveUpdatedEvent(this);
		}
	}
}
