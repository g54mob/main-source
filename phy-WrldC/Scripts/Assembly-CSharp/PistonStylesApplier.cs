using UnityEngine;

[RequireComponent(typeof(Piston))]
public class PistonStylesApplier : StylesApplierBase
{
	private PistonAudioEffect pistonAudio;

	public override void Initialize()
	{
		if (pistonAudio == null)
		{
			pistonAudio = base.gameObject.AddComponent<PistonAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		pistonAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
