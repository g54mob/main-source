using System.Collections.Generic;
using DefaultNamespace.Data.TechTree;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.TechTree
{
	public class TechTreeFilterView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _collapsed;

		[SerializeField]
		private GameObject _expanded;

		[SerializeField]
		private Button _openFilterViewButton;

		[SerializeField]
		private Button _closeFilterViewButton;

		[SerializeField]
		private Transform _filterList;

		[SerializeField]
		private Button _allOnButton;

		[SerializeField]
		private Button _allOffButton;

		[SerializeField]
		private FilterToggle filterToggleOri;

		private List<FilterToggle> _filterTagButtons = new List<FilterToggle>();

		[SerializeField]
		private TechTreeUI _techTreeUIRef;

		[SerializeField]
		private TechTreeTagsDatabase _tagsDatabase;

		private Tag _currentFilters;

		private List<TagLocalization> _availableTags;

		public Tag CurrentFilters => _currentFilters;

		private void Awake()
		{
			_openFilterViewButton.onClick.AddListener(OpenFilterView);
			_closeFilterViewButton.onClick.AddListener(CloseFilterView);
			_allOnButton.onClick.AddListener(ToggleAllOn);
			_allOffButton.onClick.AddListener(ToggleAllOff);
			_filterTagButtons = new List<FilterToggle>();
			_filterTagButtons.Add(filterToggleOri);
			_availableTags = _tagsDatabase.TagsLocalization;
			BuildFilterList();
		}

		private void OnDestroy()
		{
			_openFilterViewButton.onClick.RemoveListener(OpenFilterView);
			_closeFilterViewButton.onClick.RemoveListener(CloseFilterView);
			_allOnButton.onClick.RemoveListener(ToggleAllOn);
			_allOffButton.onClick.RemoveListener(ToggleAllOff);
			for (int i = 0; i < _filterTagButtons.Count; i++)
			{
				_filterTagButtons[i].OnFilterChanged.RemoveListener(ToggleFilter);
			}
		}

		private void BuildFilterList()
		{
			_currentFilters = (Tag)0;
			for (int i = 0; i < _filterTagButtons.Count; i++)
			{
				_filterTagButtons[i].gameObject.SetActive(value: false);
			}
			for (int j = 0; j < _availableTags.Count; j++)
			{
				FilterToggle filterToggle;
				if (j >= _filterTagButtons.Count)
				{
					filterToggle = Object.Instantiate(filterToggleOri, _filterList);
					_filterTagButtons.Add(filterToggle);
				}
				else
				{
					filterToggle = _filterTagButtons[j];
				}
				filterToggle.OnFilterChanged.AddListener(ToggleFilter);
				filterToggle.SetContent(_availableTags[j].LocaKey, _availableTags[j].Tag);
				filterToggle.gameObject.SetActive(value: true);
				if (filterToggle.IsOn)
				{
					_currentFilters |= _availableTags[j].Tag;
				}
			}
		}

		private void ToggleFilter(bool isOn, Tag filterTag)
		{
			if (isOn)
			{
				_currentFilters |= filterTag;
			}
			else
			{
				_currentFilters &= ~filterTag;
			}
			_techTreeUIRef.ReShowCurrentTree();
		}

		private void OpenFilterView()
		{
			_collapsed.SetActive(value: false);
			_expanded.SetActive(value: true);
		}

		private void CloseFilterView()
		{
			_collapsed.SetActive(value: true);
			_expanded.SetActive(value: false);
		}

		public void ToggleAllOn()
		{
			ToggleAll(value: true);
		}

		private void ToggleAllOff()
		{
			ToggleAll(value: false);
		}

		private void ToggleAll(bool value)
		{
			for (int i = 0; i < _filterTagButtons.Count; i++)
			{
				_filterTagButtons[i].SetIsOnWithoutNotify(value);
			}
			_currentFilters = (value ? Tag.All : ((Tag)0));
			_techTreeUIRef.ReShowCurrentTree();
		}
	}
}
