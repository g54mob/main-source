using UnityEngine;

[RequireComponent(typeof(LaserRayBase))]
public class LaserEmitterStylesApplier : StylesApplierBase
{
	private LaserEmitterAudioEffect laserEmitterAudioEffect;

	public override void Initialize()
	{
		laserEmitterAudioEffect = GetComponent<LaserEmitterAudioEffect>();
		if (laserEmitterAudioEffect == null)
		{
			laserEmitterAudioEffect = base.gameObject.AddComponent<LaserEmitterAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		laserEmitterAudioEffect.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
