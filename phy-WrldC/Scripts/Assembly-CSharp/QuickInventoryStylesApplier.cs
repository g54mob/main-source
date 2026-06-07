public class QuickInventoryStylesApplier : StylesApplierBase
{
	private QuickInventoryAudioEffect audioEffect;

	public override void Initialize()
	{
		audioEffect = GetComponent<QuickInventoryAudioEffect>();
	}

	public override void UpdateStyles()
	{
		if (audioEffect != null)
		{
			audioEffect.Volume = gameStylesData.volumeStylesData.uiVolume;
			audioEffect.ToggleOnClip = gameStylesData.toggleOnClip;
		}
	}

	public override void UpdateTexts()
	{
	}
}
