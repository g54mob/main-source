using System.Collections.Generic;

public class StoredBuildableCreation : BuildableCreation
{
	public override void Initialize(GameEvent gameEvent = null)
	{
		base.Initialize(gameEvent);
		Community.PlayerCommunity.OnStoredBuildableAdded.AddListener(IncrementStoredBuildableToggle);
		Community.PlayerCommunity.OnStoredBuildableRemoved.AddListener(DecrementStoredBuildableToggle);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		Community.PlayerCommunity.OnStoredBuildableAdded.RemoveListener(IncrementStoredBuildableToggle);
		Community.PlayerCommunity.OnStoredBuildableRemoved.RemoveListener(DecrementStoredBuildableToggle);
	}

	protected override void MakeCreationToggles()
	{
		for (int i = 0; i < GameManager.Settings.BuildableSettings.Buildables.Length; i++)
		{
			MakeStoredBuildableToggle(GameManager.Settings.BuildableSettings.Buildables[i]);
		}
		foreach (KeyValuePair<BuildableProperties, List<Buildable>> storedBuildable in Community.PlayerCommunity.StoredBuildables)
		{
			IncrementStoredBuildableToggle(storedBuildable.Key, storedBuildable.Value.Count);
		}
		foreach (KeyValuePair<DecorationProperties, List<Decoration>> storedDecoration in Community.PlayerCommunity.StoredDecorations)
		{
			if (storedDecoration.Key is EnergyPoleDecorationProperties)
			{
				IncrementStoredBuildableToggle(storedDecoration.Key, storedDecoration.Value.Count);
			}
		}
	}

	private void MakeStoredBuildableToggle(IPlaceable placeable)
	{
		if (!placeable.Category)
		{
			return;
		}
		using List<BuildableCreationCategoryToggle>.Enumerator enumerator = _categoryToggles.GetEnumerator();
		while (enumerator.MoveNext() && !enumerator.Current.TryAddStoredBuildableToggle(placeable))
		{
		}
	}

	public void IncrementStoredBuildableToggle(IPlaceable placeable, bool toggleCategory = true)
	{
		IncrementStoredBuildableToggle(placeable, 1, toggleCategory);
	}

	public void IncrementStoredBuildableToggle(IPlaceable placeable, int amount, bool toggleCategory = true)
	{
		if (!TryReturnCategoryToggle(placeable.Category, out var categoryToggle))
		{
			return;
		}
		if (placeable is BuildableProperties buildableProperties && buildableProperties == GameManager.Settings.BuildableSettings.EnergyPoleBuildableProperties)
		{
			placeable = GameManager.Settings.BuildableSettings.EnergyPoleDecorationProperties;
		}
		foreach (BuildableToggle buildableToggle in categoryToggle.BuildableToggles)
		{
			if (buildableToggle.Placeable == placeable)
			{
				if (buildableToggle is StoredBuildableToggle storedBuildableToggle)
				{
					storedBuildableToggle.Add(amount);
				}
				if (toggleCategory)
				{
					categoryToggle.SetEnabled(enabled: true, isOn: true);
				}
				UpdateCategories();
				break;
			}
		}
	}

	public void DecrementStoredBuildableToggle(IPlaceable placeable)
	{
		DecrementStoredBuildableToggle(placeable, 1);
	}

	public void DecrementStoredBuildableToggle(IPlaceable placeable, int amount)
	{
		if (!TryReturnCategoryToggle(placeable.Category, out var categoryToggle))
		{
			return;
		}
		if (placeable is BuildableProperties buildableProperties && buildableProperties == GameManager.Settings.BuildableSettings.EnergyPoleBuildableProperties)
		{
			placeable = GameManager.Settings.BuildableSettings.EnergyPoleDecorationProperties;
		}
		bool flag = true;
		foreach (BuildableToggle buildableToggle in categoryToggle.BuildableToggles)
		{
			if (buildableToggle is StoredBuildableToggle storedBuildableToggle)
			{
				if (storedBuildableToggle.Placeable == placeable)
				{
					storedBuildableToggle.Remove(amount);
				}
				if (storedBuildableToggle.Count > 0)
				{
					flag = false;
				}
			}
		}
		if (flag)
		{
			categoryToggle.isOn = false;
			UpdateCategories();
		}
	}
}
