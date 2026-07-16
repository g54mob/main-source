using System;
using UnityEngine;

public class ModuleDirectionLever : Module
{
	[NonSerialized]
	public bool autoTurnOn;

	[NonSerialized]
	public bool canTurnWhileBroken;

	[NonSerialized]
	public int numberOfFreeTurns;

	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	[SerializeField]
	private Animator Anim;

	[NonSerialized]
	public float speedAmount;

	[NonSerialized]
	public float duration;

	[SerializeField]
	private Animator alertAnim;

	public override bool CanBeActivated => true;

	public event Action OnTrunLeverActivated;

	private new void Awake()
	{
		base.Awake();
		anim = Anim;
	}

	private new void Update()
	{
		base.Update();
		if (autoTurnOn)
		{
			AutoTurnLever();
		}
	}

	protected override void SetEmpSoundChannels()
	{
	}

	public override bool CanInteract()
	{
		if (GameManager.Instance.ringEventStarted)
		{
			return true;
		}
		bool valueOrDefault = LevelManager.Instance.CurrentSwitchEvent?.IsWithinRange() == true;
		if (!canTurnWhileBroken && base.IsFullyBroken)
		{
			return false;
		}
		return !base.IsEMPattached && Train.Instance.moveDirection == TrainDirections.Straight && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && valueOrDefault;
	}

	public override void Activate()
	{
		if (GameManager.Instance.ringEventStarted)
		{
			GameManager.Instance.ringMinigame.StartEvent(startedSuccessfully: true);
			return;
		}
		TrainDirections dir = LevelManager.Instance.CurrentSwitchEvent?.trackSwitchDir ?? TrainDirections.Straight;
		if (Train.Instance.moveDirection == TrainDirections.Straight || Train.Instance.moveDirection == TrainDirections.None)
		{
			SetDir(dir);
		}
		PlayModuleUniqueSound();
		if (speedAmount > 0f)
		{
			SpeedBoost();
		}
		base.Activate();
	}

	public void SetDir(TrainDirections dir)
	{
		if (anim == null)
		{
			anim = GetComponent<Animator>();
		}
		switch (dir)
		{
		case TrainDirections.Left:
			anim.Play("MidToLeft");
			this.OnTrunLeverActivated?.Invoke();
			break;
		case TrainDirections.Right:
			anim.Play("MidToRight");
			this.OnTrunLeverActivated?.Invoke();
			break;
		}
		if (dir == TrainDirections.Straight)
		{
			if (Train.Instance.moveDirection == TrainDirections.Left)
			{
				anim.Play("LeftToMid");
			}
			if (Train.Instance.moveDirection == TrainDirections.Right)
			{
				anim.Play("RightToMid");
			}
		}
		Train.Instance.moveDirection = dir;
	}

	private void LeverFullyUpOrDown()
	{
		UIManager.Instance.IndicatorUp.gameObject.SetActive(value: false);
		UIManager.Instance.IndicatorDown.gameObject.SetActive(value: false);
	}

	public void ResetDirStraight()
	{
		SetDir(TrainDirections.Straight);
	}

	public void TurnLeverAutomatically(TrackTypes tracktype)
	{
		if (!Train.Instance.isNextTurnFake && (tracktype == TrackTypes.SDL || tracktype == TrackTypes.SDR) && !autoTurnOn && numberOfFreeTurns > 0 && CanInteract())
		{
			base.Interactable.InteractStart(null);
			numberOfFreeTurns--;
		}
	}

	public void AutoTurnLever()
	{
		if (!Train.Instance.isNextTurnFake && CanInteract())
		{
			base.Interactable.InteractStart(null);
			autoTurnOn = false;
		}
	}

	public void SpeedBoost()
	{
		Train.Instance.SpeedUpBuff(speedAmount, duration, isPercent: true);
	}

	public void PlayAlert(bool play)
	{
		if (play)
		{
			alertAnim.Play("TimingRingAlertSpawn");
		}
		else
		{
			alertAnim.Play("Idle");
		}
	}

	public void PlayAlertFailed()
	{
		alertAnim.Play("TimingRingAlertFail");
	}
}
