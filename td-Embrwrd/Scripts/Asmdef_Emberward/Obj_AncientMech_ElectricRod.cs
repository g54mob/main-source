using UnityEngine;

public class Obj_AncientMech_ElectricRod : Obj_AncientMech_Base
{
	[SerializeField]
	private Renderer renderer_ElectricRod;

	[SerializeField]
	private Material mat_ElectricRod_Unactive;

	[SerializeField]
	private Material mat_ElectricRod_Active;

	[SerializeField]
	private ParticleSystem particle_ActiveEffect_SecondPillar;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void OnEffectActivateProc()
	{
	}

	private void Update()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}

	private void UpdateElectricMaterial(bool isOn)
	{
	}
}
