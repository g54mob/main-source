using System;
using System.Collections;
using System.Collections.Generic;
using AudioSystem;
using UnityEngine;

public class Sandstorm : MonoBehaviour
{
	[SerializeField]
	[Range(0f, 1f)]
	private float slowPercent;

	[SerializeField]
	private float retreatRange;

	[SerializeField]
	private float maxDistance;

	[SerializeField]
	[Range(0f, 1f)]
	private float overfillSpeedMatching;

	[SerializeField]
	private SpriteRenderer sr;

	[SerializeField]
	private LevelDialogueSO tutorialDialogue;

	[SerializeField]
	private List<ParticleSystem> particles;

	[SerializeField]
	private SoundData sandstormFarSFX;

	[SerializeField]
	private SoundData sandstormCloseSFX;

	private float RegularSpeed;

	private float timer;

	private float slowRangeModifier;

	private Vector2 lastFramePos;

	private Vector3 rightEdgeViewportPos;

	private float distance;

	private SoundBuilder soundBuilder;

	private SoundEmitter sandstormFar;

	private SoundEmitter sandstormClose;

	private float overfillSpeedBoost;

	private ModuleFurnace furnace;

	[field: SerializeField]
	public float PercentDamagePerTick { get; private set; }

	[field: SerializeField]
	public float TickTime { get; private set; }

	public Vector2 Position { get; private set; }

	public float CurrentSpeed { get; private set; }

	public float CurrentProgress => Mathf.Clamp01(distance / LevelManager.Instance.CurrentLevel.LevelDistance);

	private void Start()
	{
		RegularSpeed = GameManager.Instance.CurrentGameSpeed;
		CurrentSpeed = RegularSpeed;
		timer = TickTime;
		distance = sr.bounds.extents.x;
		LevelManager.Instance.LevelStarted += ResetDistance;
		LevelManager.Instance.LevelCompleted += TurnOff;
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
		sandstormClose = soundBuilder.Play(sandstormCloseSFX);
		sandstormFar = soundBuilder.Play(sandstormFarSFX);
		furnace = Train.Instance.GetModuleByType<ModuleFurnace>();
		ModuleFurnace moduleFurnace = furnace;
		moduleFurnace.OverfillEffectEnabled = (Action)Delegate.Combine(moduleFurnace.OverfillEffectEnabled, new Action(AddOverfillSpeedBoost));
		ModuleFurnace moduleFurnace2 = furnace;
		moduleFurnace2.OverfillEffectDisabled = (Action)Delegate.Combine(moduleFurnace2.OverfillEffectDisabled, new Action(ResetOverfillSpeedBoost));
	}

	private void Update()
	{
		float num = base.transform.position.x + sr.bounds.extents.x;
		rightEdgeViewportPos = Camera.main.WorldToViewportPoint(new Vector3(num, base.transform.position.y, base.transform.position.z));
		if (rightEdgeViewportPos.x >= 0f && num > Train.Instance.TrainBackPosX)
		{
			timer -= Time.deltaTime;
			if (timer < 0f)
			{
				Train.Instance.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, Train.Instance.HealthComponent, 0f - PercentDamagePerTick * (1f + DifficultyManager.Instance.stormDamageMultiplier), isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
				timer = TickTime;
				if (!LevelManager.Instance.SandstormTutorialFinished)
				{
					LevelManager.Instance.SandstormTutorialFinished = true;
					DialogueManager.Instance.StartDialogue(tutorialDialogue);
				}
			}
			HUD.Instance.SandstormWarning.SetActive(value: true);
			sandstormClose.MuteAudio(mute: false);
		}
		else
		{
			HUD.Instance.SandstormWarning.SetActive(value: false);
			sandstormClose.MuteAudio(mute: true);
		}
	}

	private void FixedUpdate()
	{
		if (rightEdgeViewportPos.x >= 0f + slowRangeModifier - 1f)
		{
			sandstormFar.MuteAudio(mute: false);
		}
		else
		{
			sandstormFar.MuteAudio(mute: true);
		}
		if (rightEdgeViewportPos.x >= 0f + slowRangeModifier)
		{
			CurrentSpeed = (RegularSpeed + overfillSpeedBoost) * slowPercent;
		}
		else
		{
			CurrentSpeed = RegularSpeed + overfillSpeedBoost;
		}
		Position = new Vector3(base.transform.position.x + (CurrentSpeed - Train.Instance.SpeedCurrent) * Time.deltaTime, base.transform.position.y, base.transform.position.z);
		if (Position.x <= maxDistance)
		{
			base.transform.position = Position;
			distance += CurrentSpeed * Time.deltaTime;
		}
		if (Position.x >= lastFramePos.x)
		{
			slowRangeModifier = 0f;
		}
		else
		{
			slowRangeModifier = retreatRange;
		}
		lastFramePos = Position;
	}

	private void ResetDistance()
	{
		distance = sr.bounds.extents.x;
	}

	public void TurnOff()
	{
		StartCoroutine(SandstormFadeOut());
	}

	private IEnumerator SandstormFadeOut()
	{
		ModuleFurnace moduleFurnace = furnace;
		moduleFurnace.OverfillEffectEnabled = (Action)Delegate.Remove(moduleFurnace.OverfillEffectEnabled, new Action(AddOverfillSpeedBoost));
		ModuleFurnace moduleFurnace2 = furnace;
		moduleFurnace2.OverfillEffectDisabled = (Action)Delegate.Remove(moduleFurnace2.OverfillEffectDisabled, new Action(ResetOverfillSpeedBoost));
		LevelManager.Instance.LevelStarted -= ResetDistance;
		LevelManager.Instance.LevelCompleted -= TurnOff;
		EffectsUtils.PlayMultipleParticles(particles, play: false);
		sandstormFar.MuteAudio(mute: true);
		sandstormClose.MuteAudio(mute: true);
		yield return new WaitForSecondsRealtime(2f);
		UnityEngine.Object.Destroy(base.gameObject);
		HUD.Instance.SandstormWarning.SetActive(value: false);
	}

	private void AddOverfillSpeedBoost()
	{
		overfillSpeedBoost = furnace.OverfillSpeedUpValue * overfillSpeedMatching * GameManager.Instance.GameSpeedModifier;
	}

	private void ResetOverfillSpeedBoost()
	{
		overfillSpeedBoost = 0f;
	}
}
