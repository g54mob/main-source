using UnityEngine;

public class Obj_AncientMech_WeatherController_Sunny : Obj_AncientMech_Base
{
	[SerializeField]
	private Spin spin;

	[SerializeField]
	private ParticleSystem particle_WeatherEffect;

	[SerializeField]
	private GameObject prefab_FireTornado;

	[SerializeField]
	private float fireTornadoInterval_Min;

	[SerializeField]
	private float fireTornadoInterval_Max;

	private float fireTornadoTimer;

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
