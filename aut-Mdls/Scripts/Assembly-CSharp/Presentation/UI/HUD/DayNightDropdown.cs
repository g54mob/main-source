using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.Variables;
using Logic.Lighting;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.HUD
{
	public class DayNightDropdown : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _dropdown;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private RectTransform _arrow;

		[SerializeField]
		private DayNightDropdownOption _optionTemplate;

		[SerializeField]
		private List<DayNightOptionData> _options;

		[SerializeField]
		private SerializedDictionary<DayNightCycleManager.CycleState, int> _stateLookup;

		[SerializeField]
		private IntVariableSO _dayNightCycleStateSO;

		private List<DayNightDropdownOption> _optionViews = new List<DayNightDropdownOption>();

		private bool _dropdownOpen;

		private int _selectedOptionIndex = -1;

		private void Awake()
		{
			_button.onClick.AddListener(OnToggleDropdown);
			_dayNightCycleStateSO.ValueChanged += OnDayNightCycleValueChanged;
			Initialize();
		}

		private void Initialize()
		{
			for (int i = 0; i < _options.Count; i++)
			{
				DayNightDropdownOption dayNightDropdownOption = ((i != 0) ? UnityEngine.Object.Instantiate(_optionTemplate, _optionTemplate.transform.parent) : _optionTemplate);
				dayNightDropdownOption.Setup(i, _options[i]);
				dayNightDropdownOption.OnSelected = (Action<int>)Delegate.Combine(dayNightDropdownOption.OnSelected, new Action<int>(OnOptionSelected));
				dayNightDropdownOption.gameObject.SetActive(value: true);
				_optionViews.Add(dayNightDropdownOption);
			}
			_dropdown.SetActive(value: false);
		}

		private void OnDayNightCycleValueChanged(int value)
		{
			int indexOfOption = GetIndexOfOption((DayNightCycleManager.CycleState)value);
			SelectOption(indexOfOption);
		}

		private int GetIndexOfOption(DayNightCycleManager.CycleState state)
		{
			return _options.FindIndex((DayNightOptionData o) => o.State == state);
		}

		private void OnDisable()
		{
			OpenDropdown(open: false);
		}

		private void OnDestroy()
		{
			_button.onClick.AddListener(OnToggleDropdown);
			_dayNightCycleStateSO.ValueChanged -= OnDayNightCycleValueChanged;
			for (int i = 0; i < _optionViews.Count; i++)
			{
				DayNightDropdownOption dayNightDropdownOption = _optionViews[i];
				dayNightDropdownOption.OnSelected = (Action<int>)Delegate.Remove(dayNightDropdownOption.OnSelected, new Action<int>(OnOptionSelected));
			}
		}

		private void OnOptionSelected(int selectedOptionIndex)
		{
			if (selectedOptionIndex == _selectedOptionIndex)
			{
				OpenDropdown(open: false);
			}
			else
			{
				_dayNightCycleStateSO.SetValue((int)_options[selectedOptionIndex].State);
			}
		}

		private void SelectOption(int selectedOptionIndex)
		{
			OpenDropdown(open: false);
			if (_selectedOptionIndex >= 0)
			{
				_optionViews[_selectedOptionIndex].SetSelected(value: false);
			}
			_selectedOptionIndex = selectedOptionIndex;
			UpdateSelectedOption();
		}

		private void UpdateSelectedOption()
		{
			_icon.sprite = _options[_selectedOptionIndex].IconSprite;
			_icon.color = _options[_selectedOptionIndex].IconColor;
			_optionViews[_selectedOptionIndex].SetSelected(value: true);
		}

		private void OnToggleDropdown()
		{
			OpenDropdown(!_dropdownOpen);
		}

		public void OpenDropdown(bool open)
		{
			if (_dropdownOpen != open)
			{
				_dropdownOpen = open;
				_dropdown.SetActive(_dropdownOpen);
				Vector3 localScale = _arrow.transform.localScale;
				localScale.y = (_dropdownOpen ? (-1f) : 1f);
				_arrow.transform.localScale = localScale;
			}
		}
	}
}
