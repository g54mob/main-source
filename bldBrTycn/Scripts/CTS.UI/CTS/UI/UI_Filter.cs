using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	[DefaultExecutionOrder(-1)]
	public class UI_Filter : MonoBehaviour
	{
		private ToggleGroup _toggleGroup;

		private CanvasGroupController _canvasGroupController;

		private LayoutGroup _layoutGroup;

		private RectTransform _rectTransform;

		private List<FilterButton> _filters = new List<FilterButton>();

		[SerializeField]
		private FilterButton _filterButtonPrefab;

		public event Action OnInit;

		public event Action OnDestroyed;

		public event Action<FilterButton> OnActiveFilterUpdated;

		public event Action<bool, int> OnFilterUpdated;

		private void Awake()
		{
			_canvasGroupController = GetComponent<CanvasGroupController>();
			_rectTransform = GetComponent<RectTransform>();
			_layoutGroup = GetComponent<LayoutGroup>();
			_toggleGroup = GetComponent<ToggleGroup>();
		}

		public void Init(AbsFilterElement[] filterButtonsElemnts)
		{
			for (int i = 0; i < filterButtonsElemnts.Length; i++)
			{
				FilterButton filterButton = CTSFactory.Instantiate(_filterButtonPrefab, base.transform, instantiateInWorldSpace: false, true);
				filterButton.SetButtoninfo(filterButtonsElemnts[i].Icon, "", filterButtonsElemnts[i].GetIntTag());
				filterButton.SetTooltipsData(filterButtonsElemnts[i].Title, filterButtonsElemnts[i].ToolTipsText);
				filterButton.OnToggleChanged = OnFilterChanged;
				filterButton.SetToggleGroup(_toggleGroup);
				_filters.Add(filterButton);
			}
			_filters[0].IsOn = true;
			UpdateContentSize();
			this.OnInit?.Invoke();
		}

		private void OnDestroy()
		{
			this.OnDestroyed?.Invoke();
		}

		public void Show()
		{
			_canvasGroupController?.QuickShow();
			UpdateActiveFilter();
		}

		public void Hide()
		{
			_canvasGroupController?.QuickHide();
		}

		public void UpdateContentSize()
		{
			if (!(_layoutGroup == null))
			{
				if (_layoutGroup is HorizontalLayoutGroup)
				{
					float x = _filterButtonPrefab.GetComponent<RectTransform>().sizeDelta.x * (float)_filters.Count + (float)_layoutGroup.padding.left + (float)_layoutGroup.padding.right;
					_rectTransform.sizeDelta = new Vector2(x, _rectTransform.sizeDelta.y);
				}
				else if (_layoutGroup is VerticalLayoutGroup)
				{
					float y = _filterButtonPrefab.GetComponent<RectTransform>().sizeDelta.y * (float)_filters.Count + (float)_layoutGroup.padding.top + (float)_layoutGroup.padding.bottom;
					_rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, y);
				}
			}
		}

		public void UpdateActiveFilter()
		{
			for (int i = 0; i < _filters.Count; i++)
			{
				if (_filters[i].IsOn)
				{
					SetActiveFilter(_filters[i].ToggleValue);
					break;
				}
			}
		}

		private void SetActiveFilter(int type)
		{
			for (int i = 0; i < _filters.Count; i++)
			{
				if (_filters[i].ToggleValue == type)
				{
					_filters[i].SetToggled(toggled: true);
					this.OnActiveFilterUpdated?.Invoke(_filters[i]);
					break;
				}
			}
		}

		private void OnFilterChanged(bool p_value, int p_tag)
		{
			this.OnFilterUpdated?.Invoke(p_value, p_tag);
		}
	}
}
