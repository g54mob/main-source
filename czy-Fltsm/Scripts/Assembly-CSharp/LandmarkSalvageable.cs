using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

public class LandmarkSalvageable : LandmarkInteractableWithComposition
{
	[Header("Visual Prefab")]
	[SerializeField]
	[NestedReference]
	private VisualPrefab _visualPrefab;

	[SerializeField]
	private bool _destroyOnEmpty = true;

	[SerializeField]
	private LandmarkSalvageableCategory _category;

	[SerializeField]
	private LandmarkSalvageable[] _variations;

	public VisualPrefab VisualPrefab { get; private set; }

	public LandmarkSalvageableCategory Category { get; private set; }

	public int VariationIndex { get; private set; }

	public void InitializeComposition(int variationIndex, CountedItemProperty[] composition = null)
	{
		SetVariationIndex(variationIndex);
		InitializeInventory(composition);
		InitializeVisualPrefab();
	}

	public void Restore(InventoryPersistentData inventoryToPersist, int variationIndex)
	{
		SetVariationIndex((_variations.IsNullOrEmpty() || _variations.Length <= variationIndex) ? (-1) : variationIndex);
		RestoreInventory(inventoryToPersist);
		InitializeVisualPrefab();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if ((bool)base.Inventory)
		{
			base.Inventory.CompositionUpdatedEvent -= OnCompositionUpdated;
		}
	}

	public void InitializeItemFilter(Dictionary<ItemProperties, bool> itemFilter)
	{
		foreach (Item item in _compositionInventory.ReturnAllItems())
		{
			if (!itemFilter.ContainsKey(item.Properties))
			{
				itemFilter.Add(item.Properties, value: true);
			}
		}
	}

	protected override void OnCompositionUpdated(float progress)
	{
		if ((bool)VisualPrefab)
		{
			VisualPrefab.SetProgress(progress);
			if (_destroyOnEmpty && progress == 0f)
			{
				if (_visualPrefab.gameObject.scene.isLoaded)
				{
					Object.Destroy(VisualPrefab.gameObject);
				}
				else
				{
					Debug.LogErrorFormat("LandmarkSalvageable '{0}' its VisualPrefabs is referencing an asset instead of the nested GameObject. Please FIX NOW!", base.name);
				}
			}
		}
		base.OnCompositionUpdated(progress);
	}

	private void SetVariationIndex(int variationIndex)
	{
		VariationIndex = variationIndex;
		if (variationIndex < 0)
		{
			VisualPrefab = _visualPrefab;
			Category = _category;
			Initialize(null);
			return;
		}
		_visualPrefab.gameObject.SetActive(value: false);
		LandmarkSalvageable landmarkSalvageable = _variations[variationIndex];
		VisualPrefab = Object.Instantiate(landmarkSalvageable._visualPrefab, _visualPrefab.transform.parent);
		VisualPrefab.transform.localPosition = _visualPrefab.transform.localPosition;
		VisualPrefab.transform.localRotation = _visualPrefab.transform.localRotation;
		VisualPrefab.transform.localScale = _visualPrefab.transform.localScale;
		Category = landmarkSalvageable._category;
		base.Composition = landmarkSalvageable.ReturnAssetComposition();
	}

	private void InitializeVisualPrefab()
	{
		if ((bool)VisualPrefab)
		{
			OnCompositionUpdated(_compositionInventory.ReturnProgress());
			base.Inventory.CompositionUpdatedEvent += OnCompositionUpdated;
		}
		else
		{
			Debug.LogErrorFormat("Salvageable '{0}' with Landmark path '{1}' has no visual prefab set.", base.gameObject.name, Debugger.ReturnPathFromComponentInParent<Landmark>(this));
		}
	}

	public int ReturnRandomVariationIndex()
	{
		if (!_variations.IsNullOrEmpty())
		{
			return Random.Range(-1, _variations.Length);
		}
		return -1;
	}

	public LandmarkSalvageableCategory ReturnCategoryAsset(int variationIndex)
	{
		if (variationIndex <= -1 || _variations.Length <= variationIndex)
		{
			return _category;
		}
		return _variations[variationIndex]._category;
	}

	public List<CountedItemProperty> ReturnAssetComposition(int variationIndex)
	{
		if (_variations.IsNullOrEmpty() || variationIndex < 0 || _variations.Length <= variationIndex)
		{
			return ReturnAssetComposition();
		}
		return _variations[variationIndex].ReturnAssetComposition();
	}
}
