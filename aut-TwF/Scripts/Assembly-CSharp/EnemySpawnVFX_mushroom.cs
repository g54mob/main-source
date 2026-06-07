using System.Collections;
using DG.Tweening;
using UnityEngine;

public class EnemySpawnVFX_mushroom : EnemySpawnVFX
{
	[SerializeField]
	private GameObject mushroomModel;

	[SerializeField]
	private ParticleSystem smokePS;

	[SerializeField]
	private float mushroomJumpHeight = 0.5f;

	[SerializeField]
	private float mushroomJumpTime = 1f;

	[SerializeField]
	private AudioData minionSpawnSound;

	[SerializeField]
	private float destroyTime = 1.5f;

	protected override void Start()
	{
		base.Start();
		StartCoroutine(SpawnCorotuine());
	}

	private IEnumerator SpawnCorotuine()
	{
		mushroomModel.transform.rotation = Quaternion.AngleAxis(Random.Range(-120, 120), mushroomModel.transform.right) * Quaternion.AngleAxis(Random.value * 360f, Vector3.up);
		mushroomModel.transform.DOLocalMoveY(mushroomJumpHeight, mushroomJumpTime).SetEase(Ease.OutBack);
		yield return new WaitForSeconds(mushroomJumpTime);
		mushroomModel.SetActive(value: false);
		smokePS.Play();
		AudioSystem.Instance.PlaySound3D(minionSpawnSound, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f);
		CallOnSpawnEnded();
		Object.Destroy(base.gameObject, destroyTime);
	}
}
