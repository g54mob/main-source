using UnityEngine;

[RequireComponent(typeof(LaserDamage))]
public class LaserDamageStylesApplier : LaserEmitterStylesApplier
{
	private LaserDamageAudioEffect laserDamageAudioEffect;

	public override void Initialize()
	{
		base.Initialize();
		laserDamageAudioEffect = GetComponent<LaserDamageAudioEffect>();
		if (laserDamageAudioEffect == null)
		{
			laserDamageAudioEffect = base.gameObject.AddComponent<LaserDamageAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		base.UpdateStyles();
		laserDamageAudioEffect.SetAudiosByGameStyleData(gameStylesData);
	}
}
