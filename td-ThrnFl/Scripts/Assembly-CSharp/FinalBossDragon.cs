using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossDragon : MonoBehaviour
{
	[SerializeField]
	private Hp hp;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private List<string> animationTriggers;

	private int healthSegments;

	private int currentSegment;

	[SerializeField]
	private List<Wave> waves;

	[SerializeField]
	private GameObject stage2SpawnerObj;

	[SerializeField]
	private Transform spawnFromPosition;

	[SerializeField]
	private Wave immediateWaveOnDeath;

	[SerializeField]
	private AudioClip[] bossScreams;

	[SerializeField]
	private AudioSource screamAudioSource;

	[SerializeField]
	private Transform castleCenter;

	[SerializeField]
	private float minDistanceStage2 = 40f;

	[SerializeField]
	private ParticleSystem puke;

	[SerializeField]
	private GameObject pukingLogic;

	private float invulnerableFor;

	private void Start()
	{
		healthSegments = animationTriggers.Count;
		currentSegment = 0;
		OnLoseHealthSegment(0, triggerTransition: false);
		hp.OnKillOrKnockout.AddListener(SpawnSecondBossStage);
		screamAudioSource.PlayOneShot(bossScreams[0]);
	}

	private void Update()
	{
		float num = hp.maxHp / (float)healthSegments;
		float hpValue = hp.HpValue;
		int value = Mathf.FloorToInt((float)healthSegments - hpValue / num);
		value = Mathf.Clamp(value, 0, healthSegments - 1);
		if (value != currentSegment)
		{
			currentSegment = value;
			OnLoseHealthSegment(currentSegment, triggerTransition: true);
		}
		invulnerableFor -= Time.deltaTime;
		if (invulnerableFor < 0f)
		{
			hp.invulnerable = false;
		}
	}

	public void EnablePuke()
	{
		ParticleSystem.EmissionModule emission = puke.emission;
		emission.enabled = true;
		pukingLogic.SetActive(value: true);
	}

	public void DisablePuke()
	{
		ParticleSystem.EmissionModule emission = puke.emission;
		emission.enabled = false;
		pukingLogic.SetActive(value: false);
	}

	private void OnLoseHealthSegment(int _segmentNr, bool triggerTransition)
	{
		if (_segmentNr >= 0 && _segmentNr < animationTriggers.Count)
		{
			hp.invulnerable = true;
			invulnerableFor = 7f;
			animator.SetBool("AttackLeft", value: false);
			animator.SetBool("AttackRight", value: false);
			animator.SetBool("AttackMiddle", value: false);
			animator.SetBool(animationTriggers[_segmentNr], value: true);
			screamAudioSource.PlayOneShot(bossScreams[_segmentNr]);
			if (triggerTransition)
			{
				animator.SetTrigger("NewAttack");
			}
			StartCoroutine(SpawnWave(waves[_segmentNr]));
		}
	}

	private IEnumerator SpawnWave(Wave _wave)
	{
		_wave.Reset();
		while (!_wave.HasFinished())
		{
			_wave.Update();
			yield return null;
		}
	}

	private void SpawnSecondBossStage()
	{
		stage2SpawnerObj.transform.position = EnemySpawner.GetValidSpawnPointForEnemy(large: false, flying: false, spawnFromPosition.position);
		Vector3 vector = stage2SpawnerObj.transform.position - castleCenter.transform.position;
		if (vector.magnitude < minDistanceStage2)
		{
			stage2SpawnerObj.transform.position = castleCenter.transform.position + vector.normalized * minDistanceStage2;
			stage2SpawnerObj.transform.position = EnemySpawner.GetValidSpawnPointForEnemy(large: false, flying: false, stage2SpawnerObj.transform.position);
		}
		stage2SpawnerObj.SetActive(value: true);
		immediateWaveOnDeath.Reset();
		while (!immediateWaveOnDeath.HasFinished())
		{
			immediateWaveOnDeath.Update();
		}
	}
}
