using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionListItemSlider : MenuButton
{
	public TextMeshProUGUI keyLabel;

	public TextMeshProUGUI valueLabel;

	public Slider slider;

	public UnityAction<OptionListItemSlider> onChangedDelegate;

	public void OnSliderChanged()
	{
		onChangedDelegate?.Invoke(this);
	}
}
