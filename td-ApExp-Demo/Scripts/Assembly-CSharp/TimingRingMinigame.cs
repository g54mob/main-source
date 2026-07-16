using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TimingRingMinigame : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private Image outerRing;

	[SerializeField]
	private Image targetRing;

	[SerializeField]
	public GameObject background;

	[SerializeField]
	public UnitAudioController unitAudioController;

	[SerializeField]
	private Image hotkey;

	[Header("Settings")]
	[SerializeField]
	private AnimationCurve shrinkCurve;

	[SerializeField]
	private float shrinkDuration = 2f;

	private float elapsedTime;

	[SerializeField]
	private float startScale = 3f;

	[SerializeField]
	private float targetScale = 1f;

	[SerializeField]
	private float maxSuccessScale = 1.2f;

	[SerializeField]
	private float minSuccessScale = 0.5f;

	[SerializeField]
	private List<int> turnDirections;

	[SerializeField]
	private float inputBlockTime = 1f;

	[Header("Animators")]
	[SerializeField]
	private Animator outerRingAnim;

	[SerializeField]
	private Animator leverAnim;

	private float inputBlockTimer;

	private bool inputBlocked;

	private float currentScale;

	private bool isPlaying;

	private float leverInteractionTime = 5f;

	private float leverInteractionTimer;

	[NonSerialized]
	public bool lastRingOutcome;

	[NonSerialized]
	public int numberOfTurnsMade;

	[NonSerialized]
	public SpecialTrackTurn straightTrack = SpecialTrackTurn.StraightBot;

	[NonSerialized]
	public SpecialTrackTurn otherTrack = SpecialTrackTurn.MtoT;

	[NonSerialized]
	public int currentTrackID = 2;

	[NonSerialized]
	public SpecialTrack currentTrack;

	private ModuleFurnace furnace;

	private ModuleDirectionLever lever;

	private bool animReset;

	private bool ringTooBig;

	public event Action OnTriggersReset;

	public event Action OnEndMinigame;

	public event Action OnStartMinigame;

	private void Start()
	{
		outerRing.transform.localScale = Vector3.one * startScale;
		currentScale = startScale;
		InputManager.Instance.OnAPressed += InteractButtonPressed;
		furnace = Train.Instance.GetModuleByType<ModuleFurnace>();
		lever = Train.Instance.GetModuleByType<ModuleDirectionLever>();
	}

	private void Update()
	{
		if (GameManager.Instance.ringEventStarted)
		{
			leverInteractionTimer -= Time.deltaTime;
			if (leverInteractionTimer < 0f && !isPlaying && !GameManager.Instance.minigameTracksReady)
			{
				StartEvent(startedSuccessfully: false);
			}
		}
		if (currentScale > startScale / 2f || !isPlaying)
		{
			ringTooBig = true;
			hotkey.color = ColorUtils.HexToColor("777777");
		}
		else
		{
			ringTooBig = false;
			hotkey.color = Color.white;
		}
		inputBlockTimer -= Time.deltaTime;
		if (inputBlockTimer > 0f)
		{
			inputBlocked = true;
		}
		else
		{
			inputBlocked = false;
		}
		if (isPlaying)
		{
			if (!animReset)
			{
				leverAnim.Play("TimingRingLeverReturnToStart");
				outerRingAnim.Play("TimingOuterRingIdle");
				animReset = true;
			}
			outerRing.enabled = true;
			elapsedTime += Time.deltaTime;
			float time = Mathf.Clamp01(elapsedTime / (shrinkDuration * (MenuManager.Instance.GetMenu(MenuType.Options).gameObject.GetComponent<MenuSettings>().gameSpeedSettings["Normal"] / GameManager.Instance.TopGameSpeed)));
			float t = shrinkCurve.Evaluate(time);
			currentScale = Mathf.Lerp(startScale, 0.4f, t);
			outerRing.transform.localScale = Vector3.one * currentScale;
			CheckForAutoFail();
		}
	}

	public void StartEvent(bool startedSuccessfully)
	{
		if (startedSuccessfully)
		{
			lever.PlayAlert(play: false);
		}
		animReset = false;
		Train.Instance.CoalSeconds += 100f;
		inputBlockTimer = inputBlockTime;
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.canMove = false;
			if ((bool)player.interactor.ActiveInteractable && (player.interactor.ActiveInteractable.isAimable || (bool)player.interactor.ActiveInteractable.gameObject.GetComponent<ModuleShield>()))
			{
				player.interactor.ActiveInteractable.InteractEnd(player.interactor);
			}
			player.interactor.InteractorState = InteractorStates.Disabled;
		}
		Debug.Log("EVENTTTTT START");
		GetComponent<Bombardment>().ready = true;
		GameManager.Instance.ringEventStarted = false;
		GameManager.Instance.minigameTracksReady = true;
		if (startedSuccessfully)
		{
			background.SetActive(value: true);
			isPlaying = true;
			outerRing.transform.localScale = Vector3.one * startScale;
			currentScale = startScale;
			elapsedTime = 0f;
			outerRingAnim.Play("TimingOuterRingIdle");
		}
		else
		{
			lever.PlayAlertFailed();
			EndEvent(success: false);
			numberOfTurnsMade++;
		}
	}

	private IEnumerator EndEvent(bool success)
	{
		Debug.Log("EVENTTTTT END");
		isPlaying = false;
		if (success)
		{
			if (currentTrackID > turnDirections[numberOfTurnsMade])
			{
				Train.Instance.DirectionLever.SetDir(TrainDirections.Right);
			}
			else if (currentTrackID < turnDirections[numberOfTurnsMade])
			{
				Train.Instance.DirectionLever.SetDir(TrainDirections.Left);
			}
		}
		numberOfTurnsMade++;
		yield return new WaitForSeconds(1.25f);
		if (numberOfTurnsMade >= 5)
		{
			background.SetActive(value: false);
			GetComponent<Bombardment>().ready = false;
		}
	}

	private void InteractButtonPressed(int playerIndex, InputAction.CallbackContext ctx)
	{
		if (isPlaying && !inputBlocked && !ringTooBig)
		{
			if (outerRing.rectTransform.localScale.x >= minSuccessScale && outerRing.rectTransform.localScale.x <= maxSuccessScale)
			{
				lastRingOutcome = true;
				GameManager.Instance.minigameTurnReady = true;
				outerRingAnim.Play("TimingOuterRingSuccess");
				leverAnim.Play("TimingRingLeverSuccess");
				unitAudioController.PlayOnChannel(0);
				StartCoroutine(EndEvent(success: true));
			}
			else
			{
				lastRingOutcome = false;
				GameManager.Instance.minigameTurnReady = false;
				outerRingAnim.Play("TimingOuterRingFail");
				leverAnim.Play("TimingRingLeverFail");
				unitAudioController.PlayOnChannel(1);
				StartCoroutine(EndEvent(success: false));
			}
		}
	}

	public void CheckForAutoFail()
	{
		if (currentScale < minSuccessScale)
		{
			lastRingOutcome = false;
			GameManager.Instance.minigameTurnReady = false;
			outerRingAnim.Play("TimingOuterRingFail");
			leverAnim.Play("TimingRingLeverFail");
			unitAudioController.PlayOnChannel(1);
			StartCoroutine(EndEvent(success: false));
		}
	}

	public void ResetAllTriggers()
	{
		this.OnTriggersReset?.Invoke();
	}

	public void ForceEndEvent()
	{
		GameManager.Instance.minigameTurnReady = false;
		StartCoroutine(EndEvent(success: false));
	}

	public void StartMinigame()
	{
		ResetAllTriggers();
		lever.PlayAlert(play: true);
		leverInteractionTimer = leverInteractionTime;
		Train.Instance.LockMaxSpeed(isLocked: true, MenuManager.Instance.GetMenu(MenuType.Options).gameObject.GetComponent<MenuSettings>().gameSpeedSettings["Normal"] - 1f);
		furnace.HealthComponent.Res(new HealthChangeInfo(this, new Health(), 5f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		furnace.HealthComponent.Heal(furnace.HealthComponent.HealthMax);
		furnace.HealthComponent.ApplyImmunityBuff(999f);
		Train.Instance.CoalSeconds += 100f;
		lever.HealthComponent.Res(new HealthChangeInfo(this, new Health(), 5f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		lever.HealthComponent.Heal(furnace.HealthComponent.HealthMax);
		lever.HealthComponent.ApplyImmunityBuff(999f);
		TrackManager.Instance.RemoveNextTurnEvent();
		TrackManager.Instance.RemoveNextResourceEvent();
		currentTrackID = 2;
		numberOfTurnsMade = 0;
		GameManager.Instance.minigameInProgress = true;
		GetComponent<UnitAudioController>().PlayMain();
		GameManager.Instance.ringEventStarted = true;
		leverInteractionTimer = leverInteractionTime;
		this.OnStartMinigame?.Invoke();
	}

	public void EndMinigame()
	{
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.canMove = true;
			player.interactor.InteractorState = InteractorStates.Standard;
		}
		GameManager.Instance.minigameTracksReady = false;
		GameManager.Instance.minigameInProgress = false;
		GameManager.Instance.ringEventStarted = false;
		Train.Instance.LockMaxSpeed(isLocked: false);
		furnace.HealthComponent.RemoveImmunityBuff();
		lever.HealthComponent.RemoveImmunityBuff();
		this.OnEndMinigame?.Invoke();
	}
}
