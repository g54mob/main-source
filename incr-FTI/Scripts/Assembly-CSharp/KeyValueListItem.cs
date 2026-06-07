using System;
using TMPro;
using UnityEngine.UI;

public class KeyValueListItem : MenuElement
{
	private float displayedValue = float.MinValue;

	private float displayedAvailable = float.MinValue;

	public TextMeshProUGUI keyLabel;

	public TextMeshProUGUI valueLabel;

	[NonSerialized]
	public string localizationKey;

	public Image iconImage;

	public void ReloadLabel()
	{
		if (!string.IsNullOrEmpty(localizationKey))
		{
			keyLabel.text = localizationKey.Localized();
		}
	}

	public void TryUpdateWithValue(float nextValue, float available)
	{
		if (GameUtility.NotEquals(displayedValue, nextValue) || GameUtility.NotEquals(displayedAvailable, available))
		{
			if (GameUtility.IsNearlyZero(available))
			{
				TextDisplay.SetNumber(valueLabel, nextValue);
			}
			else
			{
				valueLabel.text = TextDisplay.LocalizedNumber(nextValue) + " (" + TextDisplay.LocalizedNumber(available) + ")";
			}
			displayedValue = nextValue;
			displayedAvailable = available;
		}
	}
}
