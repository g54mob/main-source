using UnityEngine;

[RequireComponent(typeof(Grabber))]
public class GrabberStylesApplier : StylesApplierBase
{
	private GrabberAudioEffect grabberAudio;

	public override void Initialize()
	{
		if (grabberAudio == null)
		{
			grabberAudio = base.gameObject.AddComponent<GrabberAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		grabberAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
