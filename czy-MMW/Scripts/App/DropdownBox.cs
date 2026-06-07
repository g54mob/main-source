using System.Collections.Generic;
using Factory;
using Motorways.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownBox : MonoBehaviour
{
	public LocalizedTextUI selectedElementText;

	public GameObject dropdownList;

	public TouchToggle itemTemplate;

	public Transform itemParent;

	public int selectedOption;

	public TouchToggle headerButton;

	public TMP_Dropdown.DropdownEvent onOptionSelected;

	public ToggleButtonGroup group;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private bool _scrollToOptionSelected;

	private readonly List<TouchToggle> _buttons = new List<TouchToggle>();

	private Selectable _oldNavigationTargetDown;

	private IScope _scope;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("DropdownBox");

	private bool IsOpen => dropdownList.activeInHierarchy;

	private void Start()
	{
		SetDropdownListActive(active: false);
	}

	public void PopulateList(List<string> options, int initiallySelectedOption, IScope scope, bool loadAsStringIds = false)
	{
		_scope = scope;
		group.ClearToggles();
		_buttons.Clear();
		selectedOption = initiallySelectedOption;
		Log.Info("Initialising DropdownBox with {0} options of which option {1} is chosen, which is {2}", options.Count, selectedOption, (selectedOption > 0 && selectedOption < options.Count) ? options[selectedOption] : "Invalid");
		while (itemParent.childCount > 0)
		{
			Transform child = itemParent.GetChild(0);
			child.SetParent(null);
			Object.DestroyImmediate(child.gameObject);
		}
		for (int i = 0; i < options.Count; i++)
		{
			string text = options[i];
			TouchToggle newOptionToggle = Object.Instantiate(itemTemplate, itemParent, worldPositionStays: false);
			LocalizedTextUI componentInChildren = newOptionToggle.GetComponentInChildren<LocalizedTextUI>();
			componentInChildren.startingStringIdString = (loadAsStringIds ? text : StringId.None.ToString());
			if (loadAsStringIds)
			{
				componentInChildren.Awake();
				componentInChildren.HandleParentAllocated(scope);
			}
			else
			{
				componentInChildren.TextField.text = text;
			}
			_buttons.Add(newOptionToggle);
			group.RegisterToggle(newOptionToggle);
			if (i == selectedOption)
			{
				newOptionToggle.IsOn = true;
				OnOptionButtonPressed(newOptionToggle, invokeOptionSelected: false);
			}
			newOptionToggle.onValueChanged.AddListener(delegate(bool isOn)
			{
				if (isOn)
				{
					OnOptionButtonPressed(newOptionToggle);
				}
			});
			newOptionToggle.AddOnSelectedEvent(delegate
			{
				OnOptionSelected(newOptionToggle);
			});
			newOptionToggle.name = $"Option {i}: {text}";
			Navigation navigation = newOptionToggle.navigation;
			navigation.mode = Navigation.Mode.Explicit;
			if (i > 0)
			{
				TouchToggle touchToggle = (TouchToggle)(navigation.selectOnUp = _buttons[i - 1]);
				Navigation navigation2 = touchToggle.navigation;
				navigation2.selectOnDown = newOptionToggle;
				touchToggle.navigation = navigation2;
			}
			newOptionToggle.navigation = navigation;
		}
	}

	public void SetDropdownListActive(bool active)
	{
		dropdownList.SetActive(active);
		headerButton.Set(active, sendCallback: false);
		if (selectedOption < 0 || selectedOption >= _buttons.Count)
		{
			selectedOption = 0;
		}
		MenuNavigation menuNavigation = _scope.Get<MenuNavigation>();
		if (active)
		{
			SetScrollToCurrentOption();
			if (menuNavigation.GetCurrentFocus() != _buttons[selectedOption])
			{
				menuNavigation.SetNewFocus(_buttons[selectedOption]);
			}
		}
		else if (menuNavigation.GetCurrentFocus() != headerButton)
		{
			menuNavigation.SetNewFocus(headerButton);
		}
	}

	private void SetScrollToCurrentOption()
	{
		_scrollRect.verticalNormalizedPosition = 1f - (float)selectedOption / ((float)_buttons.Count - 1f);
	}

	private void OnOptionButtonPressed(TouchToggle button, bool invokeOptionSelected = true)
	{
		SetDropdownListActive(active: false);
		LocalizedTextUI componentInChildren = button.GetComponentInChildren<LocalizedTextUI>();
		selectedElementText.LocString = componentInChildren.LocString;
		selectedElementText.TextField.text = componentInChildren.TextField.text;
		OnOptionSelected(_buttons.IndexOf(button), invokeOptionSelected);
	}

	public void OnOptionSelected(TouchToggle button)
	{
		if (_scrollToOptionSelected)
		{
			_scrollRect.verticalNormalizedPosition = 1f - (float)_buttons.IndexOf(button) / ((float)_buttons.Count - 1f);
		}
	}

	private void OnOptionSelected(int option, bool invokeOptionSelected)
	{
		selectedOption = option;
		if (invokeOptionSelected)
		{
			onOptionSelected.Invoke(option);
		}
	}

	public void SetSelectedOption(int newSelectedOption)
	{
		if (!Diagnostics.Verify(newSelectedOption >= 0 && newSelectedOption < _buttons.Count, "{0} is an invalid option! Defaulting to zero", newSelectedOption))
		{
			newSelectedOption = 0;
		}
		OnOptionButtonPressed(_buttons[newSelectedOption], invokeOptionSelected: false);
	}

	public void DismissDropdown()
	{
		SetDropdownListActive(active: false);
	}
}
