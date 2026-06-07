using UnityEngine;

public class Obj_AncientMech_WeatherController_SnowStorm : Obj_AncientMech_Base
{
	[SerializeField]
	private Spin spin;

	[SerializeField]
	private ParticleSystem particle_WeatherEffect;

	private float damageInterval;

	private float damageTimer;

	protected override void OnEnableProc()
	{
	}

	protected override void OnEffectActivateProc()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}

	private void Update()
	{
	}

	protected override void OnDestoryAncientMechProc()
	{
	}
}
