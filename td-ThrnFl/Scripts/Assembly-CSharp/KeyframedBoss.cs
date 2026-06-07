using System.Collections;
using UnityEngine;

public class KeyframedBoss : MonoBehaviour
{
	[SerializeField]
	private HealthbarMulti hpBarMulti;

	[SerializeField]
	private Hp hp;

	[SerializeField]
	private Transform stratKeyframe;

	[SerializeField]
	private Transform cutsceneKeyframe;

	[SerializeField]
	private float cutsceneHoldPosition = 4f;

	[SerializeField]
	private Transform[] mainKeyframes;

	[SerializeField]
	private Transform[] transitionalKeyframes;

	[SerializeField]
	private float animationDuration;

	[SerializeField]
	private float cutsceneAnimationDuration;

	[SerializeField]
	private DestroyOrDisableOnEnable disablerComponent;

	private int bossStage;

	private bool coroutineRunning;

	[SerializeField]
	private WigglerAnimationState wigglerAnimationState;

	[SerializeField]
	private float spawnWarningTime = 2f;

	[SerializeField]
	private Wave waveToSpawn;

	[SerializeField]
	private float waveToSpawnInterval;

	[SerializeField]
	private float waveToSpawnIntervalIncrease = 2f;

	private float waveToSpawnIntervalCurrent;

	private float cooldownToEnemySpawn;

	private bool waveRunning;

	private bool cutSceneAnimation;

	[SerializeField]
	private AudioSource audioSourceSpawnsAndScream;

	private ThronefallAudioManager audioManager;

	private AudioSet audioSet;

	[SerializeField]
	private float takeDamageDuringEnemySpawn = 100f;

	private void Start()
	{
		audioManager = ThronefallAudioManager.Instance;
		audioSet = audioManager.audioContent;
		waveToSpawnIntervalCurrent = waveToSpawnInterval;
		base.transform.localPosition = stratKeyframe.localPosition;
		base.transform.localRotation = stratKeyframe.localRotation;
		StopAllCoroutines();
		StartCoroutine(StartAnimation());
	}

	private IEnumerator StartAnimation()
	{
		hp.invulnerable = true;
		coroutineRunning = true;
		yield return TransitionTo(cutsceneKeyframe, cutsceneAnimationDuration);
		hp.invulnerable = true;
		coroutineRunning = true;
		cutSceneAnimation = true;
		disablerComponent.enabled = true;
		yield return new WaitForSeconds(cutsceneHoldPosition);
		cutSceneAnimation = false;
		yield return TransitionTo(mainKeyframes[0], animationDuration / 2f);
		coroutineRunning = false;
		hp.invulnerable = false;
		hp.TakeDamage(1f);
		hpBarMulti.UpdateDisplay();
	}

	private void Update()
	{
		if (hp.HpPercentage <= (float)(mainKeyframes.Length - (bossStage + 1)) / (float)mainKeyframes.Length)
		{
			hp.HpPercentage = (float)(mainKeyframes.Length - (bossStage + 1)) / (float)mainKeyframes.Length;
			waveToSpawnIntervalCurrent = waveToSpawnInterval;
			bossStage++;
			StopAllCoroutines();
			StartCoroutine(TransitionOverTo(transitionalKeyframes[bossStage], mainKeyframes[bossStage], animationDuration));
		}
		cooldownToEnemySpawn -= Time.deltaTime;
		if (cooldownToEnemySpawn <= 0f && !coroutineRunning && !waveRunning)
		{
			cooldownToEnemySpawn = waveToSpawnIntervalCurrent;
			waveToSpawnIntervalCurrent += waveToSpawnIntervalIncrease;
			waveToSpawn.Reset();
			waveRunning = true;
		}
		if (waveRunning)
		{
			hp.TakeDamage(Time.deltaTime * takeDamageDuringEnemySpawn, null, causedByPlayer: false, invokeFeedbackEvents: false);
			waveToSpawn.Update();
			if (waveToSpawn.HasFinished())
			{
				waveRunning = false;
			}
		}
		if (waveRunning || (cooldownToEnemySpawn <= spawnWarningTime && !coroutineRunning))
		{
			if (wigglerAnimationState.animationState != 1)
			{
				audioSourceSpawnsAndScream.PlayOneShot(audioSet.EismolochSpawnUnits.clips[Random.Range(0, audioSet.EismolochSpawnUnits.clips.Length)]);
				if (Random.value <= 0.33f)
				{
					audioSourceSpawnsAndScream.PlayOneShot(audioSet.EismolochScream.clips[Random.Range(0, audioSet.EismolochScream.clips.Length)]);
				}
			}
			wigglerAnimationState.animationState = 1;
		}
		else if (cutSceneAnimation)
		{
			wigglerAnimationState.animationState = 1;
		}
		else
		{
			wigglerAnimationState.animationState = 0;
		}
	}

	private IEnumerator TransitionOverTo(Transform _transitionOver, Transform _transitionTo, float _animationDuration = 5f)
	{
		coroutineRunning = true;
		yield return TransitionTo(_transitionOver, _animationDuration / 2f);
		coroutineRunning = true;
		yield return TransitionTo(_transitionTo, _animationDuration / 2f);
		coroutineRunning = false;
	}

	private IEnumerator TransitionTo(Transform _transitionTo, float _animationDuration = 5f)
	{
		hp.invulnerable = true;
		hpBarMulti.UpdateDisplay();
		coroutineRunning = true;
		Vector3 startPosition = base.transform.localPosition;
		Quaternion startRotation = base.transform.localRotation;
		for (float animProgress = 0f; animProgress < _animationDuration; animProgress += Time.deltaTime)
		{
			float f = animProgress / _animationDuration;
			f = 3f * Mathf.Pow(f, 2f) - 2f * Mathf.Pow(f, 3f);
			base.transform.localPosition = Vector3.Lerp(startPosition, _transitionTo.localPosition, f);
			base.transform.localRotation = Quaternion.Lerp(startRotation, _transitionTo.localRotation, f);
			yield return null;
		}
		base.transform.localPosition = _transitionTo.localPosition;
		base.transform.localRotation = _transitionTo.localRotation;
		coroutineRunning = false;
		hp.invulnerable = false;
		hpBarMulti.UpdateDisplay();
	}
}
