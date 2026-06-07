using UnityEngine;

public class ASingleTargetProjectile : AProjectile
{
	protected virtual Vector3 GetFlyTargetPosition(bool isAttackHeadPosition = true)
	{
		return default(Vector3);
	}

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
