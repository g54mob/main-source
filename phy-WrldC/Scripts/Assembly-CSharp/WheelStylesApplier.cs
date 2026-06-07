using UnityEngine;

[RequireComponent(typeof(Wheel))]
public class WheelStylesApplier : StylesApplierBase
{
	private WheelAudioEffect wheelAudio;

	public override void Initialize()
	{
		if (wheelAudio == null)
		{
			wheelAudio = base.gameObject.AddComponent<WheelAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		wheelAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
