using UnityEngine;

public class ThrusterStylesApplier : StylesApplierBase
{
	private ThrusterAudioEffect thrusterAudioEffect;

	public override void Initialize()
	{
		if (thrusterAudioEffect == null)
		{
			thrusterAudioEffect = base.gameObject.AddComponent<ThrusterAudioEffect>();
		}
		Transform transform = base.transform.Find("Propeller");
		if (transform != null)
		{
			transform.gameObject.AddComponent<ThrusterRotator>();
		}
	}

	public override void UpdateStyles()
	{
		thrusterAudioEffect.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
