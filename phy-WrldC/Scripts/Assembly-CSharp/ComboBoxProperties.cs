using System;
using TMPro;
using UnityEngine;

public class ComboBoxProperties : MonoBehaviour
{
	public Action<string> OnValueChangedEvent;

	private TextMeshProUGUI labelText;

	private TMP_Dropdown dropdown;

	private bool isAlreadyInitialized;

	private void Awake()
	{
		if (!isAlreadyInitialized)
		{
			Initialize();
		}
	}

	public void Initialize()
	{
		labelText = base.transform.FindComponent<TextMeshProUGUI>("LabelText", isRecursively: true);
		dropdown = base.transform.FindComponent<TMP_Dropdown>("Dropdown", isRecursively: true);
		dropdown.ClearOptions();
		dropdown.onValueChanged.AddListener(OnValueChangedHandler);
		isAlreadyInitialized = true;
	}

	public void SetLabel(string label)
	{
		labelText.text = label;
	}

	public void AddComboBoxOption(string option)
	{
		dropdown.options.Add(new TMP_Dropdown.OptionData(option));
	}

	public void AddComboBoxOption(string option, Sprite icon)
	{
		dropdown.options.Add(new TMP_Dropdown.OptionData(option, icon));
	}

	public void SetComboBoxIndexSelected(int index)
	{
		dropdown.SetValueWithoutNotify(index);
		dropdown.RefreshShownValue();
	}

	public void ClearOptions()
	{
		dropdown.ClearOptions();
	}

	public int GetSelectedIndex()
	{
		return dropdown.value;
	}

	public string GetSelectedValue()
	{
		return dropdown.options[dropdown.value].text;
	}

	public int GetOptionsCount()
	{
		return dropdown.options.Count;
	}

	private void OnValueChangedHandler(int index)
	{
		if (OnValueChangedEvent != null)
		{
			OnValueChangedEvent(index.ToString());
		}
	}
}
