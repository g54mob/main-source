using UnityEngine;

public class Obj_AncientMech_WeatherController_ThunderStorm : Obj_AncientMech_Base
{
	[SerializeField]
	private Spin spin;

	[SerializeField]
	private ParticleSystem particle_WeatherEffect;

	[SerializeField]
	private int damage;

	private float damageInterval;

	private float damageTimer;

	private bool isTriggerElectricEventRegistered;

	private float soundTimer;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
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

	private void ThunderEffect(AMonsterBase monster)
	{
	}

	private void OnMonsterTriggerElectricEffect(AMonsterBase monster)
	{
	}

	protected override void OnDestoryAncientMechProc()
	{
	}
}
