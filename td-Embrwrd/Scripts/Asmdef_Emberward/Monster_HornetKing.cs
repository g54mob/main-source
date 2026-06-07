using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_HornetKing : Monster_Basic
{
	[SerializeField]
	private List<ParticleSystem> list_Particle_SoundWave;

	[SerializeField]
	private float skillRange;

	private List<ABaseTower> list_EffectedTowers;

	private bool isParticlePlaying;

	private bool isHardModeActive;

	private float detectInterval;

	private float detectTimer;

	protected override void SpawnProc()
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void DetectTowers()
	{
	}

	private void ClearAllTowers()
	{
	}

	protected override void DespawnProc()
	{
	}

	public void ToggleSoundwaveParticle(bool isOn)
	{
	}
}
