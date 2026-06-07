using UnityEngine;
using UnityEngine.UI;

public class SalvagerPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private ChildBehaviourCache<SalvagerPanelToggle> _toggleCache;

	[SerializeField]
	private SelectableGroup _toggleSelectableGroup;

	[SerializeField]
	private Slider _progressSlider;

	[SerializeField]
	private InventoryView _exportInventoryView;

	private Salvager _salvager;

	public BuildablePanelElementId Id => BuildablePanelElementId.Fisher;

	private void OnEnable()
	{
		OnSalvageableItemsUpdated();
	}

	private void Update()
	{
		_progressSlider.value = _salvager.NormalizedSalvageProgress;
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		Deactivate();
		if (finished && buildable.TryReturnBuildableExtendable<Salvager>(out _salvager))
		{
			_salvager.SalvageableItemsUpdated += OnSalvageableItemsUpdated;
			_exportInventoryView.Initialize(_salvager.Buildable.Inventory, SubInventoryType.Export);
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		if ((bool)_salvager)
		{
			_salvager.SalvageableItemsUpdated -= OnSalvageableItemsUpdated;
		}
		base.gameObject.SetActive(value: false);
	}

	private void OnSalvageableItemsUpdated()
	{
		_toggleCache.Reset();
		Salvager.SalvageableCategory[] salvageableCategories = _salvager.SalvageableCategories;
		foreach (Salvager.SalvageableCategory salvageableCategory in salvageableCategories)
		{
			if (salvageableCategory != null)
			{
				_toggleCache.Get(active: true).Initialize(salvageableCategory);
			}
		}
		_toggleCache.Trim();
		_toggleSelectableGroup.Initialize();
	}
}
