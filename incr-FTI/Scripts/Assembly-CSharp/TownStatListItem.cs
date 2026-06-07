using System;
using TMPro;
using UnityEngine.UI;

public class TownStatListItem : MenuButton
{
	private float displayedTotal = float.MinValue;

	private float displayedAvailable = float.MinValue;

	public TextMeshProUGUI totalLabel;

	public TextMeshProUGUI availableLabel;

	[NonSerialized]
	public string localizationKeyTotal;

	public Image iconImage;

	public TextFlashAnimation textFlashAnimation;

	public void ConfigureTextAnimation()
	{
		textFlashAnimation = new TextFlashAnimation(availableLabel);
	}

	public void ReloadLabel()
	{
		totalLabel.gameObject.SetActive(value: false);
		TextDisplay.SetNumber(availableLabel, displayedAvailable);
	}

	protected override void Update()
	{
		base.Update();
		textFlashAnimation?.UpdateAnimation();
	}

	public void SetHighlighted(bool nextState)
	{
		base.buttonState = (nextState ? CustomButtonState.Default : CustomButtonState.Background);
	}

	public void TryUpdateWithValue(float total, float available)
	{
		if (GameUtility.NotEquals(displayedTotal, total))
		{
			TextDisplay.SetNumber(totalLabel, total);
			displayedTotal = total;
		}
		if (GameUtility.NotEquals(displayedAvailable, available))
		{
			displayedAvailable = available;
			ReloadLabel();
		}
	}
}
