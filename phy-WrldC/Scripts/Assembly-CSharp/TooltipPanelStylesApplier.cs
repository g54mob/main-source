public class TooltipPanelStylesApplier : StylesApplierBase
{
	private TooltipAudioEffect tooltipAudioEffect;

	public override void Initialize()
	{
		tooltipAudioEffect = GetComponent<TooltipAudioEffect>();
	}

	public override void UpdateStyles()
	{
		if (tooltipAudioEffect != null)
		{
			tooltipAudioEffect.Volume = gameStylesData.volumeStylesData.uiVolume;
			tooltipAudioEffect.ShowUpClip = gameStylesData.tooltipWarningClip;
		}
	}

	public override void UpdateTexts()
	{
	}
}
