using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class DropdownController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform dropdownRect;

	public RectTransform dropdownArrow;

	public TMP_Dropdown dropdown;

	public RectTransform buttonsRect;

	public ButtonController prevButton;

	public ButtonController nextButton;

	[Header("Configuration")]
	public string playerPrefsID;

	public List<string> staticOptionReference;

	[Header("State")]
	public bool isInteractable;

	[ReadOnly]
	public float normalWidth;

	private void Start()
	{
	}

	public void AddOptions(List<string> newOptions, bool useDictionary, List<string> newListedOptions = null)
	{
	}

	public void SelectFromStaticOption(string staticOption)
	{
	}

	public string GetCurrentSelectedStaticOption()
	{
		return null;
	}

	public void OnControlModeChange()
	{
	}

	public void OnNextButton()
	{
	}

	public void OnPreviousButton()
	{
	}

	public void OnValueChange()
	{
	}

	public void SetInteractalbe(bool val)
	{
	}
}
