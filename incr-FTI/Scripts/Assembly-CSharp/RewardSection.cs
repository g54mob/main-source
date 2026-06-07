using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardSection : MonoBehaviour
{
	public TextMeshProUGUI countLabel;

	public Image iconImage;

	private TextValueChangeAnimation textValueChangeAnimation;

	private TextColorChangeAnimation textColorChangeAnimation;

	private double accumulatedValue;

	public void Initialize()
	{
		textValueChangeAnimation = new TextValueChangeAnimation(countLabel);
		textColorChangeAnimation = new TextColorChangeAnimation();
	}

	public void UpdateDynamicDisplay()
	{
		textValueChangeAnimation.UpdateAnimation();
	}

	public void SetValue(float v)
	{
		accumulatedValue = v;
		textValueChangeAnimation.DisplayValue(v);
	}

	public void AnimateAddition(double addedValue)
	{
		accumulatedValue += addedValue;
		AnimateToValue(accumulatedValue);
	}

	public void AnimateToValue(double v)
	{
		textValueChangeAnimation.AnimateToValue(v);
		textColorChangeAnimation.Run(countLabel);
	}
}
