using UnityEngine;

public class Tower_StaticField : ABaseTower
{
	[SerializeField]
	private ParticleSystem particle_StaticEffect;

	private Vector3 headModelForward;

	private void Start()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void ShootProc()
	{
	}
}
