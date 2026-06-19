using System.Collections;
using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class ShiftFinishedNotifUI : EntityBehaviourBase
{
	public bool passed;

	public List<Transform> bells;

	public List<Transform> bellCrossOuts;

	private ReportUI rUI = AggroManagerBase<ReportUI>.instance;

	public EasingFunction.Ease ease = EasingFunction.Ease.EaseOutBack;

	public EventReference bellPassSfx;

	public EventReference bellFailSfx;

	public EventReference gradeFSfx;

	public EventReference gradeDSfx;

	public EventReference gradeCSfx;

	public EventReference gradeBSfx;

	public EventReference gradeASfx;

	public EventReference gradeSSfx;

	public float animLengthSeconds = 0.5f;

	public float animStrength = 1f;

	public float bellDelay = 1f;

	public Sprite[] gradeSprites;

	public Image[] gradeImages;

	public void SetUp(int currentShift)
	{
		for (int i = 0; i < bells.Count; i++)
		{
			bellCrossOuts[i].gameObject.SetActive(value: false);
			bells[i].gameObject.SetActive(i < currentShift - 1);
			gradeImages[i].gameObject.SetActive(i < currentShift - 1);
			gradeImages[i].sprite = gradeSprites[(uint)(NetworkAggroManagerBase<ShiftManager>.instance.shiftScores[i] + 1)];
			gradeImages[i].color = GlobalScriptableObject<AggroSettingsObject>.instance.gradeColors[(uint)(NetworkAggroManagerBase<ShiftManager>.instance.shiftScores[i] + 1)];
			if (!passed && i == currentShift - 1)
			{
				gradeImages[i].sprite = gradeSprites[0];
				gradeImages[i].color = GlobalScriptableObject<AggroSettingsObject>.instance.gradeColors[0];
			}
		}
		EventReference gradeSfx = gradeFSfx;
		if (passed)
		{
			switch (NetworkAggroManagerBase<ShiftManager>.instance.shiftScores[currentShift - 1])
			{
			case ContractScore.D:
				gradeSfx = gradeDSfx;
				break;
			case ContractScore.C:
				gradeSfx = gradeCSfx;
				break;
			case ContractScore.B:
				gradeSfx = gradeBSfx;
				break;
			case ContractScore.A:
				gradeSfx = gradeASfx;
				break;
			case ContractScore.S:
				gradeSfx = gradeSSfx;
				break;
			}
		}
		StartCoroutine(RevealCo(currentShift, passed ? bellPassSfx : bellFailSfx, gradeSfx));
	}

	private IEnumerator RevealCo(int currentShift, EventReference bellSfx, EventReference gradeSfx)
	{
		yield return new WaitForSecondsRealtime(bellDelay);
		if (passed)
		{
			yield return GrowRevealCo(bells[currentShift - 1], ease, animLengthSeconds, bellSfx);
		}
		else
		{
			yield return GrowRevealCo(bellCrossOuts[currentShift - 1], ease, animLengthSeconds, bellSfx);
		}
		yield return GrowRevealCo(gradeImages[currentShift - 1].transform, ease, animLengthSeconds, gradeSfx);
	}

	private IEnumerator GrowRevealCo(Transform revealTransform, EasingFunction.Ease revealEase, float animLength, EventReference sfxEvent)
	{
		revealTransform.gameObject.SetActive(value: true);
		AudioManager.PlaySfx(sfxEvent);
		float animTime = 0f;
		while (animTime < animLength)
		{
			animTime += Time.unscaledDeltaTime;
			float value = animTime / animLength;
			float num = EasingFunction.Evaluate(revealEase, value) * animStrength;
			revealTransform.localScale = new Vector3(num, num, num);
			yield return null;
		}
	}
}
