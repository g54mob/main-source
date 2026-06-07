using UnityEngine;

public class Tower_Lightning : ABaseTower
{
	[SerializeField]
	private ParticleSystem particle_ShootLightningEffect;

	[SerializeField]
	private float jumpRange;

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
