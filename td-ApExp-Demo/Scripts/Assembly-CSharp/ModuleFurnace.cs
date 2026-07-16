using System;
using AudioSystem;
using UnityEngine;
using UnityEngine.Localization;

public class ModuleFurnace : Module
{
	[Header("Special SFX")]
	[SerializeField]
	private SoundData overfillSound;

	[SerializeField]
	private ParticleSystem[] pss;

	[NonSerialized]
	public bool continueDuringDeath;

	[SerializeField]
	private GameObject psGo;

	public float OverfillSpeedUpValue = 3f;

	public float OverfillTimeNeeded = 3f;

	public float OverfillTimeNow;

	public float OverfillTimeLoweringBySecond = 1f;

	public float CoalSecondsOverfillStart = 10f;

	[SerializeField]
	private float ScreenShakeTimeNeeded = 0.1f;

	private float ScreenShakeTimeNow;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString openMapKey;

	[SerializeField]
	private LocalizedString shovelCoalKey;

	[NonSerialized]
	public bool chargingOverfill;

	private GameObject timingBar;

	public Action OverfillEffectEnabled;

	public Action OverfillEffectDisabled;

	private float snotModifier = 1f;

	public event Action<Interactor> FurnaceReady;

	private new void Awake()
	{
		base.Awake();
		OverfillEffectEnabled = (Action)Delegate.Combine(OverfillEffectEnabled, new Action(EnableStandardOverfillEffect));
		OverfillEffectDisabled = (Action)Delegate.Combine(OverfillEffectDisabled, new Action(DisableStandardOverfillEffect));
	}

	private new void Update()
	{
		base.Update();
		float num = GetUpgradedStatValueByStatType(StatTypes.consumption) * (1f + DifficultyManager.Instance.coalDrainPercent);
		if (!ResourceManager.Instance.DebugIsInfiniteCoal && !base.CurrentInteractor && !base.IsEMPattached && !Train.Instance.pauseCoal && (!base.IsFullyBroken || continueDuringDeath))
		{
			Train.Instance.CoalSeconds -= num * Time.deltaTime;
		}
		if (OverfillTimeNow > 0f && Train.Instance.IsOverfillEnabled && !Train.Instance.IsInOverfill && (double)Train.Instance.CoalSeconds < (double)Train.Instance.CoalSecondsCapacity - 0.001)
		{
			OverfillTimeNow = Math.Max(OverfillTimeNow - Time.deltaTime, 0f);
		}
	}

	protected override void SetEmpSoundChannels()
	{
	}

	protected override void Break(HealthChangeInfo info)
	{
		base.Break(info);
		GameManager.Instance.isOverfillStationConditionMet = false;
		UnityEngine.Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.333f, 0f);
		Train.Instance.PlayStoppingClip();
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		if (Time.frameCount != MenuManager.Instance.GetMenu(MenuType.Map).GetComponent<Map>().mapClosedFrame)
		{
			base.OnInteractStart(interactor);
			if (LevelManager.Instance.IsAtDestination && LevelManager.Instance.NextLevel == null)
			{
				MenuManager.Instance.OpenMenu(MenuType.Map);
				MenuManager.Instance.GetMenu(MenuType.Map).GetComponent<Map>().openedViaFurnace = true;
			}
		}
	}

	protected override void OnInteractUpdate(Interactor interactor)
	{
		if (LevelManager.Instance.IsAtDestination)
		{
			return;
		}
		PlayerController component = interactor.GetComponent<PlayerController>();
		component.isShoveling = true;
		float num = 4.5f * component.speedModifierShovel * Time.deltaTime;
		if (!Train.Instance.pauseCoal && !Train.Instance.preventCoalGain)
		{
			Train.Instance.CoalSeconds += num;
		}
		if (Train.Instance.IsOverfillEnabled && !Train.Instance.IsInOverfill && Train.Instance.CoalSeconds == Train.Instance.CoalSecondsCapacity)
		{
			OverfillTimeNow += Time.deltaTime;
			ScreenShakeTimeNow += Time.deltaTime;
			if (ScreenShakeTimeNow >= ScreenShakeTimeNeeded)
			{
				CameraController.Instance.Shake(ScreenShakeTimeNeeded, OverfillTimeNow / OverfillTimeNeeded * 0.1f);
				ScreenShakeTimeNow = 0f;
			}
			if (OverfillTimeNow > OverfillTimeNeeded)
			{
				Train.Instance.IsInOverfill = true;
				Train.Instance.OverfillStatusChanged(isInOverfill: true);
				Train.Instance.CoalSeconds = CoalSecondsOverfillStart;
				OverfillTimeNow = 0f;
				OverfillEffectEnabled?.Invoke();
				anim.Play("FurnaceOverfill");
				Train.Instance.locomotiveTopCoalAnimator.Play("LocomotiveTopCoalOverfill");
				Train.Instance.fireTrainAnimator.Play("FireTrainOverfill");
				soundBuilder.Play(overfillSound);
			}
		}
	}

	public void EnableStandardOverfillEffect()
	{
		Train.Instance.SpeedChange(OverfillSpeedUpValue);
	}

	public void DisableStandardOverfillEffect()
	{
		Train.Instance.SpeedChange(0f - OverfillSpeedUpValue);
	}

	protected override void OnInteractEnd(Interactor interactor)
	{
		if (!(interactor == null))
		{
			interactor.GetComponent<PlayerController>().isShoveling = false;
			base.OnInteractEnd(interactor);
		}
	}

	public void PlayParticleSystems()
	{
		ParticleSystem[] array = pss;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Play();
		}
	}

	public void PlaySound()
	{
		PlayModuleUniqueSound();
	}

	public override void HandleDestinationReached()
	{
		base.HandleDestinationReached();
		base.Interactable.actionNameLocalized = openMapKey;
		base.Interactable.startOnly = true;
		base.Interactable.interactAnim = Interactable.InteractAnims.Idle;
	}

	protected override void HandleNextLevelSelected()
	{
		base.Interactable.actionNameLocalized = shovelCoalKey;
		base.Interactable.startOnly = false;
		base.Interactable.interactAnim = Interactable.InteractAnims.Shovel;
		if (PlayerManager.Instance.IsCoop)
		{
			float num = Vector3.Distance(PlayerManager.Instance.Players[0].transform.position, base.transform.position);
			float num2 = Vector3.Distance(PlayerManager.Instance.Players[1].transform.position, base.transform.position);
			if (num < num2)
			{
				this.FurnaceReady?.Invoke(PlayerManager.Instance.Players[0].GetComponent<Interactor>());
			}
			else
			{
				this.FurnaceReady?.Invoke(PlayerManager.Instance.Players[1].GetComponent<Interactor>());
			}
		}
		else
		{
			this.FurnaceReady?.Invoke(PlayerManager.Instance.Players[0].GetComponent<Interactor>());
		}
		psGo.SetActive(value: false);
	}

	protected override void HandleLevelStarted()
	{
		psGo.SetActive(value: true);
	}

	public void TurnOverfillOff()
	{
		OverfillTimeNow = 0f;
		Train.Instance.IsInOverfill = false;
		Train.Instance.OverfillStatusChanged(isInOverfill: false);
		OverfillEffectDisabled?.Invoke();
		Train.Instance.CoalSeconds = Train.Instance.CoalSecondsCapacity;
		Train.Instance.isOverfillSpeedDial = false;
		anim.Play("FurnaceIdle");
		Train.Instance.locomotiveTopCoalAnimator.Play("LocomotiveTopCoalIdle");
		Train.Instance.fireTrainAnimator.Play("FireTrainIdle");
		UIManager.Instance.HUD.OverfillWarning.SetActive(value: false);
	}

	public void TurnOverfillOffOnDestinationReached()
	{
		OverfillTimeNow = 0f;
		Train.Instance.IsInOverfill = false;
		Train.Instance.OverfillStatusChanged(isInOverfill: false);
		Train.Instance.isOverfillSpeedDial = false;
		Train.Instance.CoalSeconds = 0f;
		OverfillEffectDisabled?.Invoke();
		anim.Play("FurnaceIdle");
		Train.Instance.locomotiveTopCoalAnimator.Play("LocomotiveTopCoalIdle");
		Train.Instance.fireTrainAnimator.Play("FireTrainIdle");
		UIManager.Instance.HUD.OverfillWarning.SetActive(value: false);
	}

	protected override void ApplySnot(float strength)
	{
		base.ApplySnot(strength);
		snotModifier = strength;
	}

	protected override void RemoveSnot(float strength)
	{
		base.RemoveSnot(strength);
		snotModifier = 1f;
	}
}
