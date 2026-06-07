using UnityEngine;

[RequireComponent(typeof(LaserButton))]
public class LaserButtonStylesApplier : StylesApplierBase
{
	private LaserButtonAudioEffect laserButtonAudioEffect;

	public override void Initialize()
	{
		laserButtonAudioEffect = GetComponent<LaserButtonAudioEffect>();
		if (laserButtonAudioEffect == null)
		{
			laserButtonAudioEffect = base.gameObject.AddComponent<LaserButtonAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		laserButtonAudioEffect.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
