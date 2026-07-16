using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
	[SerializeField]
	private UIContentAnimator transitionBlend;

	[SerializeField]
	private UIContentAnimator transitionDayCounter;

	[SerializeField]
	private UIContentAnimator transitionBudget;

	[SerializeField]
	private UIContentAnimator transitionBudgetUpkeepRemoval;

	[SerializeField]
	private float transitionDurationDayCounter = 4f;

	[SerializeField]
	private TMP_Text labelDayCounter;

	[SerializeField]
	private Color colorChangedDay;

	[SerializeField]
	private string soundOnDayChange;

	[SerializeField]
	private TMP_Text labelBudget;

	[SerializeField]
	private TMP_Text labelUpkeep;

	[SerializeField]
	private TMP_Text labelTurnover;

	[SerializeField]
	private TMP_Text labelTips;

	[Header("Game Save Message")]
	[SerializeField]
	private UIContentAnimator transitionGameSavedMessage;

	[SerializeField]
	private TMP_Text labelGameSaved;

	[SerializeField]
	private Image iconSaving;

	[SerializeField]
	private Sprite[] spritesSavingProgress;

	[SerializeField]
	private string isSaving;

	[SerializeField]
	private string hasSaved;

	[SerializeField]
	private Color colorIsSaving;

	[SerializeField]
	private Color colorSaved;

	[SerializeField]
	private string soundSaved;

	private float transitionFadeInDuration = 0.5f;

	private float transitionFadeOutDuration = 0.5f;

	private TransitionStateMachine transitionStateMachine;

	private static TransitionManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			UnityEngine.Object.Destroy(this);
		}
		transitionStateMachine = GetComponent<TransitionStateMachine>();
		ShowBlend();
	}

	public static void ShowBlend()
	{
		instance.transitionBlend.BeginWithTargetState();
	}

	public static void HideBlend()
	{
		instance.transitionBlend.BeginWithNormalState();
	}

	public static bool IsTransitioning()
	{
		return instance.transitionBlend.IsPlayingFullyTracked();
	}

	private static void ResetTransitionElementsToNormal()
	{
	}

	public static void TriggerTransitionEnter(float duration = 1f)
	{
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.DisableInput);
		instance.transitionBlend.gameObject.SetActive(value: true);
		instance.transitionFadeInDuration = duration;
		instance.transitionBlend.SetFadeTime(instance.transitionFadeInDuration);
		instance.transitionBlend.OnPlay();
		ResetTransitionElementsToNormal();
	}

	public static void TriggerTransitionEnter(float duration = 1f, UnityEvent onFinished = null)
	{
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.DisableInput);
		instance.transitionBlend.gameObject.SetActive(value: true);
		instance.transitionFadeInDuration = duration;
		instance.transitionBlend.SetFadeTime(instance.transitionFadeInDuration);
		instance.transitionBlend.OnPlay(onFinished);
		ResetTransitionElementsToNormal();
	}

	public static void TriggerTransitionEnter(float duration = 1f, Action onFinished = null)
	{
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.DisableInput);
		instance.transitionBlend.gameObject.SetActive(value: true);
		instance.transitionFadeInDuration = duration;
		instance.transitionBlend.SetFadeTime(instance.transitionFadeInDuration);
		instance.transitionBlend.OnPlay();
		TweenerManager.TweenTimeAction("OnTriggerPlayFinishedInvoke", instance.transitionFadeInDuration, onFinished);
		ResetTransitionElementsToNormal();
	}

	public static void TriggerTransitionExit(float duration = 1f)
	{
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.CharacterMode);
		instance.transitionFadeInDuration = duration;
		instance.transitionBlend.SetFadeTime(instance.transitionFadeInDuration);
		instance.transitionBlend.OnReverse();
	}

	public static void TriggerTransitionExit(float duration = 1f, Action onFinished = null)
	{
		TriggerTransitionExit(duration);
		TweenerManager.TweenTimeAction("OnTriggerReversedFinishedInvoke", instance.transitionFadeInDuration, onFinished);
	}

	public static void TriggerTransitionFlipFlop()
	{
		instance.transitionBlend.PlayFlipFlop();
	}

	public static void TriggerState(string stateName)
	{
		TransitionState stateByName = instance.transitionStateMachine.GetStateByName(stateName);
		if (!(stateByName == null))
		{
			instance.transitionStateMachine.ChangeState(stateByName);
		}
	}

	public static bool IsInStateType<T>()
	{
		return instance.transitionStateMachine.currentState.GetType() == typeof(T);
	}

	public static T GetTriggerStateByType<T>()
	{
		return (T)Convert.ChangeType(instance.transitionStateMachine.GetRegisteredStates().ToList().Find((TransitionState x) => x.GetType() == typeof(T)), typeof(T));
	}
}
