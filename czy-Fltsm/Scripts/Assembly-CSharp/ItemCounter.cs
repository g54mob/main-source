using TMPro;
using UnityEngine;

public class ItemCounter : SceneBehaviour
{
	[Header("Properties")]
	[Tooltip("Item properties this counter will use to count. If null the tags will be used for counting")]
	[SerializeField]
	private ItemProperties _itemToCount;

	[Tooltip("Tag this counter will count.")]
	[EnumFlag(1)]
	[SerializeField]
	private Item.Tags _tagToCount;

	[Tooltip("The threshold will be multiplied with the agent count to make sure every agent has enough items.")]
	[SerializeField]
	private bool _thresholdPerAgent;

	[Tooltip("Amount threshold to show warning.")]
	[SerializeField]
	private int _warningThreshold = 5;

	[Header("Components")]
	[Tooltip("Text component for the counter.")]
	[SerializeField]
	private TextMeshProUGUI _text;

	private float _amount = -1f;

	private Animator _animator;

	private void Start()
	{
		_animator = GetComponentInChildren<Animator>();
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(UpdateCounter);
		UpdateCounter();
	}

	private void OnDestroy()
	{
		if (Community.PlayerCommunity != null)
		{
			Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateCounter);
		}
	}

	private void UpdateCounter()
	{
		bool flag = false;
		UpdateAmount();
		flag = ((!_thresholdPerAgent) ? (_amount < (float)_warningThreshold) : (_amount < (float)(Community.PlayerCommunity.Agents.Count * _warningThreshold)));
		if (_animator != null)
		{
			_animator.SetBool("Warning", flag);
		}
	}

	private void UpdateAmount()
	{
		float num = ((((_tagToCount & Item.Tags.Drink) | Item.Tags.Liquid) != Item.Tags.None) ? Community.PlayerCommunity.Inventory.ReturnNutritionalValue(_tagToCount) : (((_tagToCount & Item.Tags.Food) != Item.Tags.None) ? Community.PlayerCommunity.Inventory.ReturnNutritionalValue(_tagToCount) : ((!(_itemToCount == null)) ? ((float)Community.PlayerCommunity.Inventory.ReturnCount(_itemToCount)) : ((float)Community.PlayerCommunity.Inventory.ReturnItemContainingTagCount(_tagToCount)))));
		if (num != _amount)
		{
			_amount = num;
			_text.text = _amount.ToString();
		}
	}
}
