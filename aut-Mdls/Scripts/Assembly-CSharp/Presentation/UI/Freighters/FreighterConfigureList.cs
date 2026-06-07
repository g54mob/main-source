#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Freighter;
using Data.Operator;
using Data.Variables;
using Presentation.Locators;
using Presentation.UI.Buttons;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.Freighters
{
	public class FreighterConfigureList : MonoBehaviour
	{
		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private IntVariableSO _selectedFreighterInUI;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectData _freightHubData;

		[SerializeField]
		private BoolVariableSO _unsavedFreighterChanges;

		[Space]
		[SerializeField]
		private FreighterConfigureItem _prefab;

		[SerializeField]
		private Button _addButton;

		[SerializeField]
		private Button _applyButton;

		[SerializeField]
		private ButtonEnabler _applyButtonEnabler;

		[Space]
		[SerializeField]
		private GameObject _addFreighterContent;

		[SerializeField]
		private GameObject _selectAFreighterToConfigureContent;

		[SerializeField]
		private ScrollRect _scrollRect;

		private readonly List<TMP_Dropdown.OptionData> _freightHubOptions = new List<TMP_Dropdown.OptionData>();

		private readonly Dictionary<int, int> _freightHubReferenceIdToOptionIndex = new Dictionary<int, int>();

		private readonly List<FreighterConfigureItem> _freeItems = new List<FreighterConfigureItem>();

		private readonly List<FreighterConfigureItem> _usedItems = new List<FreighterConfigureItem>();

		private void Awake()
		{
			_addButton.onClick.AddListener(AddEmptyStop);
			_applyButton.onClick.AddListener(ApplyConfigurationToFreighter);
			_freeItems.Add(_prefab);
			_prefab.gameObject.SetActive(value: false);
		}

		private void OnDestroy()
		{
			_addButton.onClick.RemoveListener(AddEmptyStop);
			_applyButton.onClick.RemoveListener(ApplyConfigurationToFreighter);
		}

		private void OnEnable()
		{
			_freightHubOptions.Clear();
			_freightHubReferenceIdToOptionIndex.Clear();
			List<FactoryObject> objectsFromData = _factoryLayer.GetObjectsFromData(_freightHubData);
			for (int i = 0; i < objectsFromData.Count; i++)
			{
				ReferenceFactoryObjectBehaviour factoryObjectBehaviour = objectsFromData[i].GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>();
				FreightHubBehaviour factoryObjectBehaviour2 = objectsFromData[i].GetFactoryObjectBehaviour<FreightHubBehaviour>();
				_freightHubOptions.Add(new TMP_Dropdown.OptionData
				{
					text = factoryObjectBehaviour2.CustomName
				});
				_freightHubReferenceIdToOptionIndex.Add(factoryObjectBehaviour.ReferenceID, i);
			}
			foreach (FreighterConfigureItem usedItem in _usedItems)
			{
				usedItem.Initalize(_freightHubReferenceIdToOptionIndex, _freightHubOptions, OnStopChanged, RemoveStopAtIndex);
			}
			foreach (FreighterConfigureItem freeItem in _freeItems)
			{
				freeItem.Initalize(_freightHubReferenceIdToOptionIndex, _freightHubOptions, OnStopChanged, RemoveStopAtIndex);
			}
			_selectedFreighterInUI.ValueChanged += OnSelectedFreighterChanged;
			ResetToCurrentFreighter();
			SetContentVisibility();
		}

		private void SetContentVisibility()
		{
			FreighterObject freighterObject;
			bool flag = _freightersManagerLocator.Manager.TryGetFreighter(_selectedFreighterInUI.Value, out freighterObject);
			_selectAFreighterToConfigureContent.SetActive(!flag);
			_addFreighterContent.SetActive(flag);
		}

		private void OnDisable()
		{
			_selectedFreighterInUI.ValueChanged -= OnSelectedFreighterChanged;
		}

		private void OnSelectedFreighterChanged(int createdId)
		{
			SetContentVisibility();
			DisableApplyButton();
			if (!_freightersManagerLocator.Manager.TryGetFreighter(createdId, out var freighterObject) || freighterObject.Path.Stops.Count == 0)
			{
				ClearUsedItems();
			}
			else
			{
				PopulateList(freighterObject.Path);
			}
		}

		private void PopulateList(FreighterPathBehaviour path)
		{
			int num = 0;
			foreach (FreighterStopConfiguration stop in path.Stops)
			{
				_ = stop;
				GetOrCreateItem().Populate(num, path);
				num++;
			}
			ClearUsedItems(num);
		}

		private void ClearUsedItems(int startIndex = 0)
		{
			while (_usedItems.Count > startIndex)
			{
				ReturnItemToFree(_usedItems[0]);
			}
		}

		private void AddEmptyStop()
		{
			if (_freightersManagerLocator.Manager.TryGetFreighter(_selectedFreighterInUI.Value, out var freighterObject))
			{
				FreighterConfigureItem orCreateItem = GetOrCreateItem();
				orCreateItem.PopulateEmpty(_usedItems.Count - 1, freighterObject.Path);
				ScrollTo(_scrollRect, orCreateItem.transform as RectTransform);
				TryEnableApplyButton();
			}
		}

		private void ScrollTo(ScrollRect scrollRect, RectTransform target)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
			Vector2 vector = target.localPosition;
			float height = scrollRect.content.rect.height;
			float height2 = scrollRect.viewport.rect.height;
			float verticalNormalizedPosition = 1f - Mathf.Clamp01(vector.y * -1f / (height - height2));
			scrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
		}

		private void ApplyConfigurationToFreighter()
		{
			DisableApplyButton();
			if (!_freightersManagerLocator.Manager.TryGetFreighter(_selectedFreighterInUI.Value, out var freighterObject))
			{
				this.DevException($"Failed: Selected Freighter \"{_selectedFreighterInUI.Value}\" was not found", "ApplyConfigurationToFreighter", 170);
				return;
			}
			List<FreighterStopConfiguration> list = new List<FreighterStopConfiguration>();
			foreach (FreighterConfigureItem usedItem in _usedItems)
			{
				list.Add(usedItem.CreateStopConfiguration());
			}
			freighterObject.Path.SetStopConfigurations(list);
			_selectedFreighterInUI.SetValue(-1);
		}

		private void ResetToCurrentFreighter()
		{
			DisableApplyButton();
			OnSelectedFreighterChanged(_selectedFreighterInUI.Value);
		}

		private void OnStopChanged(int stopIndex)
		{
			TryEnableApplyButton();
		}

		private void RemoveStopAtIndex(int stopIndex)
		{
			ReturnItemToFree(_usedItems[stopIndex]);
			for (int i = 0; i < _usedItems.Count; i++)
			{
				_usedItems[i].ChangeStopIndex(i);
			}
			TryEnableApplyButton();
		}

		private FreighterConfigureItem GetOrCreateItem()
		{
			FreighterConfigureItem freighterConfigureItem;
			if (_freeItems.Count > 0)
			{
				freighterConfigureItem = _freeItems[0];
				_freeItems.RemoveAtSwapBack(0);
			}
			else
			{
				freighterConfigureItem = Object.Instantiate(_prefab, _prefab.transform.parent, worldPositionStays: true);
				freighterConfigureItem.Initalize(_freightHubReferenceIdToOptionIndex, _freightHubOptions, OnStopChanged, RemoveStopAtIndex);
			}
			freighterConfigureItem.transform.SetSiblingIndex(freighterConfigureItem.transform.parent.childCount - 3);
			freighterConfigureItem.gameObject.SetActive(value: true);
			_usedItems.Add(freighterConfigureItem);
			return freighterConfigureItem;
		}

		private void ReturnItemToFree(FreighterConfigureItem item)
		{
			if (!_usedItems.Remove(item))
			{
				this.DevException("Failed to remove " + item.name + " from _usedItems", "ReturnItemToFree", 228);
				return;
			}
			_freeItems.Add(item);
			item.gameObject.SetActive(value: false);
		}

		private void TryEnableApplyButton()
		{
			foreach (FreighterConfigureItem usedItem in _usedItems)
			{
				if (!usedItem.IsStopConfigurationValid())
				{
					this.LogWarning("Can't enable apply button, one or more configurations are not valid", "TryEnableApplyButton", 241);
					DisableApplyButton();
					return;
				}
			}
			_applyButtonEnabler.Interactable = true;
			_unsavedFreighterChanges.SetValue(value: true);
		}

		private void DisableApplyButton()
		{
			_applyButtonEnabler.Interactable = false;
			_unsavedFreighterChanges.SetValue(value: false);
		}
	}
}
