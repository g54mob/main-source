using UnityEngine;

public class Monster_Demon : Monster_Basic
{
	[SerializeField]
	private float range;

	[SerializeField]
	private ParticleSystem particle_Heal;

	private float detectInterval;

	private float detectTimer;

	private Vector3Int lastGridPosition;

	private bool isHardModeActive;

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void DetectCorruptTile()
	{
	}
}
