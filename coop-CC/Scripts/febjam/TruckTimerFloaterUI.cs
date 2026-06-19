using System.Collections;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TruckTimerFloaterUI : EntityBehaviourBase
{
	public FloaterUI floaterUI;

	public OutboundBay assignedOutboundBay;

	public TextMeshProUGUI bayNumberText;

	public Animator animator;

	public Image[] timerImages;

	public Image[] timerStages;

	private static readonly int Warn = Animator.StringToHash("warn");

	private static readonly int Emergency = Animator.StringToHash("emergency");

	private int _previousStage = 3;

	private bool tutorial;

	public float normalizedTime;

	public float tutorialDemoTimeSec = 10f;

	public DialogueObject timerDemoIntroDialogue;

	public DialogueObject timerDemoBonusDialogue;

	public DialogueObject timerDemoDontFailDialogue;

	public ParticleSystem bonusParticles;

	public StudioEventEmitter warningSfx;

	public IEnumerator TutorialRunTimerDemoCo()
	{
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(timerDemoIntroDialogue);
		tutorial = true;
		yield return TimerSequence(1f, 0.85f);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(timerDemoBonusDialogue);
		yield return TimerSequence(0.85f, 0.15f);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(timerDemoDontFailDialogue);
		yield return TimerSequence(0.15f, 0f);
	}

	public IEnumerator TimerSequence(float start, float end)
	{
		float time = tutorialDemoTimeSec * start;
		normalizedTime = start;
		while (normalizedTime > end)
		{
			time -= Time.deltaTime;
			normalizedTime = time / tutorialDemoTimeSec;
			yield return null;
		}
		normalizedTime = end;
	}

	public void PlayBonusParticles()
	{
		bonusParticles.Play();
	}

	protected override void OnUpdatePresentationEarly()
	{
		if (!tutorial)
		{
			normalizedTime = assignedOutboundBay.normalizedStrikeTime;
		}
		if (assignedOutboundBay.state == OutboundBay.BayState.Outbound || tutorial)
		{
			floaterUI.SetVisibleThisFrame();
		}
		bayNumberText.text = assignedOutboundBay.bayID;
		Image[] array = timerImages;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].fillAmount = normalizedTime;
		}
		int num = Mathf.Min(Mathf.FloorToInt((1f - normalizedTime) * (float)timerStages.Length), timerStages.Length - 1);
		for (int j = 0; j < timerStages.Length; j++)
		{
			timerStages[j].gameObject.SetActive(j == num);
		}
		if (num != _previousStage)
		{
			if (!GameUtil.isTutorial && assignedOutboundBay.state == OutboundBay.BayState.Outbound && base.isServer)
			{
				bool isA = assignedOutboundBay.bayID == "A";
				NetworkAggroManagerBase<VoiceOverManager>.instance.ServerTimerWarningPhase(num, isA);
			}
			if (num == timerStages.Length - 1)
			{
				animator.SetBool(Emergency, value: true);
				animator.SetTrigger(Warn);
				warningSfx.Play();
			}
			else
			{
				animator.SetTrigger(Warn);
				animator.SetBool(Emergency, value: false);
			}
			_previousStage = num;
		}
	}
}
