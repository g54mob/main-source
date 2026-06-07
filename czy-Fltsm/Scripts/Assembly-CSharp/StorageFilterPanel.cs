using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StorageFilterPanel : MonoBehaviour, IBuildablePanelElement
{
	[Tooltip("The prefab that we use to instantiate the filters.")]
	public GameObject ResourcePrefab;

	[SerializeField]
	private Transform _resourceParent;

	[Tooltip("The toggle that we will use to disable and enable the filterWindow.")]
	public Toggle FilterToggle;

	[SerializeField]
	private Button _copyButton;

	[SerializeField]
	private Button _pasteButton;

	[SerializeField]
	private InventoryTagToggle[] _tagToggles;

	[SerializeField]
	private SelectableGroup _tagToggleSelectableGroup;

	[SerializeField]
	[FormerlySerializedAs("_selectableGroup")]
	private SelectableGroup _itemSlotSelectableGroup;

	private Storage _storage;

	private List<FilterUIInteractable> _filters = new List<FilterUIInteractable>();

	private bool _isInitialized;

	private bool _updateFilters;

	public BuildablePanelElementId Id => BuildablePanelElementId.StorageFilter;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.NewItemDiscovered, UpdateFilters);
		UIEvent.Dispatch(UIEvent.Type.StorageFilter);
		OnFilterUpdate();
	}

	private void LateUpdate()
	{
		if (_updateFilters)
		{
			OnFilterUpdate();
			_updateFilters = false;
		}
		if (FlotsamInputManager.GetUISubmit() && _itemSlotSelectableGroup.TryGetSelectedComponent(_filters, out var selectedComponent))
		{
			selectedComponent.Interact();
		}
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.NewItemDiscovered, UpdateFilters);
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		if (buildable.TryReturnBuildableExtendable<Storage>(out _storage) && _storage.ShowFilterPanel)
		{
			if (!_isInitialized)
			{
				Transform parent = (_resourceParent ? _resourceParent : base.transform);
				ItemProperties[] itemProperties = GameManager.Settings.ItemSettings.ItemProperties;
				foreach (ItemProperties itemProperties2 in itemProperties)
				{
					if (!itemProperties2.IsSuperItem && !itemProperties2.ExcludeFromItemFilter)
					{
						FilterUIInteractable component = Object.Instantiate(ResourcePrefab, parent).GetComponent<FilterUIInteractable>();
						_filters.Add(component);
						component.InitializeItem(itemProperties2);
						component.gameObject.SetActive(value: false);
					}
				}
				_isInitialized = true;
			}
			bool active = !(_storage is TownheartStorage);
			_copyButton.gameObject.SetActive(active);
			_pasteButton.gameObject.SetActive(active);
			_updateFilters = true;
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
		FilterToggle.gameObject.SetActive(value: false);
		_storage = null;
	}

	private void UpdateFilters(GameEvent gameEvent)
	{
		_updateFilters = true;
	}

	public void OnFilterUpdate()
	{
		if (_storage == null)
		{
			return;
		}
		int num = 0;
		InventoryTagToggle[] tagToggles = _tagToggles;
		foreach (InventoryTagToggle inventoryTagToggle in tagToggles)
		{
			if ((_storage.Filter.Tags & inventoryTagToggle.ItemTags) == 0)
			{
				inventoryTagToggle.gameObject.SetActive(value: false);
				continue;
			}
			inventoryTagToggle.gameObject.SetActive(value: true);
			inventoryTagToggle.SetIsOnValueWithoutNotify(_storage.AcceptsTags(inventoryTagToggle.ItemTags));
			num++;
		}
		foreach (FilterUIInteractable filter in _filters)
		{
			if (_storage.AcceptsTags(filter.ItemProperties.Tags))
			{
				filter.Initialize(_storage.Filter);
				filter.gameObject.SetActive(value: true);
			}
			else
			{
				filter.gameObject.SetActive(value: false);
			}
		}
		if (num <= 1)
		{
			_tagToggleSelectableGroup.gameObject.SetActive(value: false);
		}
		else
		{
			_tagToggleSelectableGroup.gameObject.SetActive(value: true);
			_tagToggleSelectableGroup.Initialize();
		}
		_itemSlotSelectableGroup.Initialize();
		_pasteButton.interactable = _storage.Filter.CanPaste();
	}

	public void ToggleSelectedTag()
	{
		if (_tagToggleSelectableGroup.Selected is Toggle toggle)
		{
			toggle.isOn = !toggle.isOn;
		}
	}

	public void FilterSwitch(bool activate)
	{
		foreach (FilterUIInteractable filter in _filters)
		{
			if (_storage.AcceptsTags(filter.ItemProperties.Tags))
			{
				filter.ActivateFilter(activate);
			}
		}
	}

	public void Copy()
	{
		_storage.Filter.Copy();
		_updateFilters = true;
	}

	public void Paste()
	{
		if (_storage.Filter.Paste())
		{
			_updateFilters = true;
		}
	}

	public void ToggleTags(Item.Tags tags, bool enabled)
	{
		if ((bool)_storage)
		{
			if (enabled)
			{
				_storage.Filter.AddAcceptedTags(tags);
			}
			else
			{
				_storage.Filter.RemoveAcceptedTags(tags);
			}
			_updateFilters = true;
		}
	}
}
