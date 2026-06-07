using TMPro;

public class SliderStylesApplier : StylesApplierBase
{
	private TextMeshProUGUI labelText;

	private SliderAudioEffect sliderAudioEffect;

	public override void Initialize()
	{
		labelText = base.transform.FindComponent<TextMeshProUGUI>("Label", isRecursively: true);
		sliderAudioEffect = GetComponent<SliderAudioEffect>();
	}

	public override void UpdateStyles()
	{
		if (sliderAudioEffect != null)
		{
			sliderAudioEffect.Volume = gameStylesData.volumeStylesData.uiVolume * 0.2f;
			sliderAudioEffect.ValueChangingClip = gameStylesData.sliderValueChangingClip;
		}
	}

	public override void UpdateTexts()
	{
		if (!string.IsNullOrEmpty(baseId))
		{
			labelText.text = languages.GetText("slider.text." + baseId, labelText.text);
		}
	}
}
