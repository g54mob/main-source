using System.Collections.Generic;

public class SeedManager : SceneBehaviour
{
	private List<DecorationProperties> _lockedDecorations;

	private List<ItemProperties> _discoveredSeeds;

	private void Start()
	{
		DecorationProperties[] decorations = GameManager.Settings.BuildableSettings.Decorations;
		_lockedDecorations = new List<DecorationProperties>(decorations.Length);
		_discoveredSeeds = new List<ItemProperties>();
		DecorationProperties[] array = decorations;
		foreach (DecorationProperties decorationProperties in array)
		{
			if (!decorationProperties.IsUnlocked() && !decorationProperties.RequiredResources.IsNullOrEmpty() && decorationProperties.RequiredResources[0].ContainsTag(Item.Tags.Seed))
			{
				_lockedDecorations.Add(decorationProperties);
			}
		}
		if (0 < _lockedDecorations.Count)
		{
			GameEventDispatcher.AddListener(GameEventType.NewItemDiscovered, OnNewItemDiscovered);
		}
	}

	private void LateUpdate()
	{
		foreach (ItemProperties discoveredSeed in _discoveredSeeds)
		{
			int count = _lockedDecorations.Count;
			while (0 < count--)
			{
				DecorationProperties decorationProperties = _lockedDecorations[count];
				if (decorationProperties.RequiredResources[0].ItemProperties == discoveredSeed)
				{
					decorationProperties.Unlock();
					_lockedDecorations.RemoveAt(count);
				}
			}
		}
		_discoveredSeeds.Clear();
		if (_lockedDecorations.Count == 0)
		{
			GameEventDispatcher.RemoveListener(GameEventType.NewItemDiscovered, OnNewItemDiscovered);
			base.enabled = false;
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.NewItemDiscovered, OnNewItemDiscovered);
	}

	private void OnNewItemDiscovered(GameEvent gameEvent)
	{
		if (gameEvent is FoundItemPropertiesEvent foundItemPropertiesEvent && (foundItemPropertiesEvent.ItemProperties.Tags & Item.Tags.Seed) == Item.Tags.Seed)
		{
			_discoveredSeeds.Add(foundItemPropertiesEvent.ItemProperties);
		}
	}
}
