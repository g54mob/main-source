using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.PajamaLlama;

[CreateAssetMenu(menuName = "Flotsam/Settings/Item Settings")]
public class ItemSettings : ScriptableObject
{
	[Serializable]
	private struct TagsActivity
	{
		public Item.Tags Tags;

		public Activity Activity;
	}

	public ItemProperties[] ItemProperties;

	[Space]
	public Color DisabledColor = Color.white;

	[Header("No Fuel properties")]
	[Tooltip("The sprite that shows when the no fuel option is selected.")]
	public Sprite NoFuelItemSprite;

	[Tooltip("The tooltip text for the no fuel item.")]
	public LocalizedString NoFuelItemTooltip;

	[Tooltip("The tooltip text when a recipe is waiting for resources.")]
	public LocalizedString WaitingForResourceTooltip;

	public LocalizedString CategoryText = null;

	public LocalizedString QualityText = null;

	public LocalizedString WeightText = null;

	public LocalizedString PollutionText = null;

	[Tooltip("The default production limit that the game will start with.")]
	public int DefaultProductionLimit = -1;

	[Header("Activities based on Item.Tags")]
	[SerializeField]
	[NamedArrayElement("Tags", "Activity", " -> ")]
	private TagsActivity[] _consumeActivities;

	[SerializeField]
	private Activity _consumeActivityDefault = Activity.Eating;

	[Header("Persistence hacks!")]
	[SerializeField]
	private ItemProperties[] _producerFuelItems;

	private Dictionary<Item.Tags, List<ItemProperties>> _taggedItemProperties = new Dictionary<Item.Tags, List<ItemProperties>>();

	public bool ReturnIsFuelImporterItem(Item item)
	{
		if (_producerFuelItems == null)
		{
			return false;
		}
		ItemProperties[] producerFuelItems = _producerFuelItems;
		foreach (ItemProperties itemProperties in producerFuelItems)
		{
			if (item.Properties == itemProperties)
			{
				return true;
			}
		}
		return false;
	}

	public List<ItemProperties> ReturnItemPropertiesWithTag(Item.Tags tag)
	{
		if (!_taggedItemProperties.TryGetValue(tag, out var value))
		{
			value = new List<ItemProperties>();
			ItemProperties[] itemProperties = ItemProperties;
			foreach (ItemProperties itemProperties2 in itemProperties)
			{
				if (itemProperties2.Tags.HasFlag(tag))
				{
					value.Add(itemProperties2);
				}
			}
			_taggedItemProperties.Add(tag, value);
		}
		return value;
	}

	public List<ItemProperties> ReturnFoodItemProperties()
	{
		return ReturnItemPropertiesWithTag(Item.Tags.Food);
	}

	public Activity GetConsumeActivity(Item item)
	{
		TagsActivity[] consumeActivities = _consumeActivities;
		for (int i = 0; i < consumeActivities.Length; i++)
		{
			TagsActivity tagsActivity = consumeActivities[i];
			if ((tagsActivity.Tags & item.Properties.Tags) != Item.Tags.None)
			{
				return tagsActivity.Activity;
			}
		}
		Debug.LogException(new Exception($"No consume activity was found for Item.Tags: {item.Properties.Tags}. Returning consume activity default: {_consumeActivityDefault}"));
		return _consumeActivityDefault;
	}

	private int SortByQuality(ItemProperties lhs, ItemProperties rhs)
	{
		return lhs.Quality.Value.CompareTo(rhs.Quality.Value);
	}
}
