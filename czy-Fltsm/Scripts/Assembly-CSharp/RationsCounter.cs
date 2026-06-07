using UnityEngine;
using UnityEngine.UI;

public class RationsCounter : SceneBehaviour
{
	[Tooltip("Text component for the food.")]
	[SerializeField]
	private Text _foodCounterText;

	[Tooltip("Text component for the water.")]
	[SerializeField]
	private Text _waterCounterText;

	private float _waterAmount;

	private float _foodAmount;

	private void Start()
	{
		Initialize();
	}

	private void Initialize()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(UpdateCounter);
		UpdateCounter();
	}

	private void OnDestroy()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateCounter);
	}

	private void UpdateCounter()
	{
		_foodAmount = Community.PlayerCommunity.Inventory.ReturnItemContainingTagCount(Item.Tags.Food);
		_waterAmount = Community.PlayerCommunity.Inventory.ReturnItemContainingTagCount(Item.Tags.Drink);
		_foodCounterText.text = _foodAmount.ToString();
		_waterCounterText.text = _waterAmount.ToString();
	}
}
