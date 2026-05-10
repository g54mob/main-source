using System;
using System.Collections.Generic;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[RequireComponent(typeof(ToggleGroup))]
	public class FilterZone : MonoBehaviour
	{
		[SerializeField]
		[Required(null)]
		private FilterButton _prefab;

		[SerializeField]
		private bool _autoResize = true;

		private ToggleGroup _toggleGroup;

		private LayoutGroup _layout;

		private RectTransform _rectTransform;

		public Action<bool, int> OnToggleChanged;

		public List<FilterButton> Toggles { get; private set; } = new List<FilterButton>();

		private void Awake()
		{
			_toggleGroup = GetComponent<ToggleGroup>();
			_rectTransform = GetComponent<RectTransform>();
			_layout = GetComponent<LayoutGroup>();
		}

		public void Populate(FilterElement[] p_elements, bool _multiselection = false, int p_defaultSelected = 0)
		{
			for (int i = 0; i < p_elements.Length; i++)
			{
				FilterButton filterButton = UnityEngine.Object.Instantiate(_prefab, base.transform);
				filterButton.SetButtoninfo(p_elements[i]._icon, p_elements[i]._text, p_elements[i]._tags);
				filterButton.OnToggleChanged = SetFilter;
				Toggles.Add(filterButton);
				if (!_multiselection && _toggleGroup != null)
				{
					filterButton.SetToggleGroup(_toggleGroup);
				}
			}
			if (!_multiselection && Toggles.Count > 0)
			{
				Toggles[(p_defaultSelected >= 0 && p_defaultSelected < p_elements.Length) ? p_defaultSelected : 0].SetToggled(toggled: true);
			}
			UpdateSize();
		}

		public int GetCurrentToggledTags()
		{
			for (int i = 0; i < Toggles.Count; i++)
			{
				if (Toggles[i].IsOn)
				{
					return Toggles[i].ToggleValue;
				}
			}
			return 0;
		}

		private void SetFilter(bool p_value, int p_tag)
		{
			OnToggleChanged?.Invoke(p_value, p_tag);
		}

		private void UpdateSize()
		{
			if (_autoResize)
			{
				float y = _rectTransform.sizeDelta.y;
				float x = _rectTransform.sizeDelta.x;
				if (_layout is VerticalLayoutGroup)
				{
					y = _prefab.GetComponent<RectTransform>().sizeDelta.y * (float)Toggles.Count + (float)_layout.padding.top + (float)_layout.padding.bottom;
				}
				else if (_layout is HorizontalLayoutGroup)
				{
					x = _prefab.GetComponent<RectTransform>().sizeDelta.y * (float)Toggles.Count + (float)_layout.padding.left + (float)_layout.padding.right;
				}
				_rectTransform.sizeDelta = new Vector2(x, y);
			}
		}
	}
}
