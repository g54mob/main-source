using UnityEngine;

public class Tower_Scrap : ABaseTower
{
	private Vector3 headModelForward;

	[SerializeField]
	private ParticleSystem particle_SelfDestruct;

	[SerializeField]
	private ParticleSystem particle_Smoke;

	[SerializeField]
	private GameObject obj_ProgressBar_Yellow;

	[SerializeField]
	private GameObject obj_ProgressBar_Red;

	[SerializeField]
	private Transform node_ProgressBarScaler;

	[SerializeField]
	private GameObject node_TowerModel;

	private readonly int SELF_DESTRUCT_ROUND_LIMIT;

	private int ammoCount;

	private int fullAmmoCount;

	private float progressBarT;

	protected override void CannonSpawnProc()
	{
	}

	protected override void OnRoundStartProc()
	{
	}

	public void AddAmmo(int ammo)
	{
	}

	private void SelfDestruct()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void ShootProc()
	{
	}

	private void Update3DProgressBar()
	{
	}

	public override int GetSellValue()
	{
		return 0;
	}

	public override string GetExtraTowerControlStat()
	{
		return null;
	}
}
