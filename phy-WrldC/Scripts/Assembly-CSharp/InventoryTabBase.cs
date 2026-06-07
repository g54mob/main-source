using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryTabBase : MonoBehaviour
{
	[SerializeField]
	private Color textIsOnColor;

	[SerializeField]
	private Color textIsOffColor;

	private Toggle tabToggle;

	private TextMeshProUGUI text;

	private ToggleStylesApplier toggleStylesApplier;

	public event Action<bool> OnTabSelectedEvent;

	private void Awake()
	{
		tabToggle = GetComponent<Toggle>();
		text = base.transform.FindComponent<TextMeshProUGUI>("Text", isRecursively: true);
		toggleStylesApplier = GetComponent<ToggleStylesApplier>();
		tabToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SetToggleStyles(isOn);
			this.OnTabSelectedEvent?.Invoke(isOn);
		});
		SetToggleStyles(tabToggle.isOn);
	}

	public void SetConfiguration(string categoryName, ToggleGroup toggleGroup)
	{
		this.OnTabSelectedEvent = null;
		tabToggle.group = toggleGroup;
		SetTabIconAndTooltip(categoryName);
	}

	private void SetTabIconAndTooltip(string categoryName)
	{
		ToggleStylesApplier component = GetComponent<ToggleStylesApplier>();
		(string icon, string baseId) iconAndTooltipTextId = GetIconAndTooltipTextId(categoryName);
		string item = iconAndTooltipTextId.icon;
		string item2 = iconAndTooltipTextId.baseId;
		string sourceText = item;
		component.BaseId = item2;
		text.SetText(sourceText);
	}

	protected abstract (string icon, string baseId) GetIconAndTooltipTextId(string categoryName);

	public void SetToggleValue(bool isOn)
	{
		if (tabToggle.isOn != isOn)
		{
			tabToggle.SetValue(isOn);
		}
		SetToggleStyles(isOn);
	}

	private void SetToggleStyles(bool isOn)
	{
		text.color = (isOn ? textIsOnColor : textIsOffColor);
		toggleStylesApplier?.SetToggleStyles(isOn);
	}
}
