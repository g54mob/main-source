using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

public class DiscountPanel : MonoBehaviour
{
	public Slider discountSlider;

	public TMP_Text discountText;

	public GamePadUIPanel gamepadUIPanel;

	private Pricing pricingData => null;

	private void OnEnable()
	{
	}

	public void Initialize(float currentDiscount)
	{
	}

	private void OnSliderChanged(float value)
	{
	}

	public void GamepadSlider(bool increase)
	{
	}

	private void ApplyDiscount(int value)
	{
	}

	public void ClosePanel()
	{
	}

	public void GamePadClosePanel()
	{
	}
}
