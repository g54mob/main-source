using System;
using System.Collections;
using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReportUI : AggroManagerBase<ReportUI>, IInputController, IShiftChanged
{
	public Animator animator;

	public List<Transform> bells;

	public List<Transform> bellCrossOuts;

	public CostumeUnlockedUI costumeUnlockedUI;

	public ContractUnlockedUI contractUnlockedUI;

	public float tallyTime = 1f;

	public float animLengthSeconds = 1f;

	public float animLengthStamp = 0.2f;

	public EasingFunction.Ease ease = EasingFunction.Ease.EaseInOutBack;

	public EasingFunction.Ease easeStamp = EasingFunction.Ease.EaseInOutBack;

	public float animStrength = 1f;

	public LocalizedText contractTitleText;

	public Image[] boxImages;

	public Image[] modifierAImages;

	public Image[] modifierBImages;

	[Header("TEST DATA")]
	public List<PlayerResult> testPlayerResults = new List<PlayerResult>();

	public bool testPass;

	public int testCurrentShift = 3;

	public ContractObject testContract;

	public GameObject testModifierA;

	public GameObject testModifierB;

	[Header("PLAYER DATA OBJECTS")]
	public List<GameObject> playerIconObjects;

	public List<TextMeshProUGUI> playerNameTexts;

	public List<GameObject> crashoutCountObjects;

	public List<GameObject> nitroCountObjects;

	public List<GameObject> driftCountObjects;

	public List<GameObject> upgradeCountObjects;

	public List<TextMeshProUGUI> crashoutCountTexts;

	public List<TextMeshProUGUI> nitroCountTexts;

	public List<TextMeshProUGUI> driftCountTexts;

	public List<TextMeshProUGUI> upgradeCountTexts;

	public List<Image> playerIconImages;

	public List<Image> playerHighlightImages;

	[Header("SFX")]
	public StudioEventEmitter clipboardInSFX;

	public StudioEventEmitter clipboardOutSFX;

	public StudioEventEmitter bellSFX;

	public StudioEventEmitter crashoutSFX;

	public StudioEventEmitter nitroSFX;

	public StudioEventEmitter driftSFX;

	public StudioEventEmitter upgradeSFX;

	public StudioEventEmitter passStampSFX;

	public StudioEventEmitter failStampSFX;

	[Header("Grade SFX")]
	public EventReference gradeFSfx;

	public EventReference gradeDSfx;

	public EventReference gradeCSfx;

	public EventReference gradeBSfx;

	public EventReference gradeASfx;

	public EventReference gradeSSfx;

	public StudioEventEmitter bellFailSFXEmitter;

	public StudioEventEmitter winSFX;

	public PlayerProceedUI playerProceedUI;

	public EaseUI newRecord;

	[SerializeField]
	private bool _skipped;

	public ParticleSystem[] confettiBursts;

	public ParticleSystem confettiRain;

	private bool _gotNewRecord;

	private int previousHighScore;

	private ContractScore previousHighContractScore;

	public Transform finalGradeContainer;

	public Image finalGradeImage;

	public Image finalGradeDillyImage;

	public Sprite[] gradeSprites;

	public Sprite[] gradeDillySprites;

	public Image[] gradeImages;

	[Header("Best Time")]
	public TextMeshProUGUI bestTimeText;

	public IEnumerator StartSequenceCo(bool passed, int currentShift, ContractObject contract, ContractScore score, TimeSpan shiftTime, ContractScore[] shiftScores, Sprite modifierSeen1, Sprite modifierSeen2, ShiftOrderObject[] ordersSeen, PlayerResult[] playerResults, CostumeObject[] costumesUnlocked, ContractObject[] contractsUnlocked)
	{
		SetUp(passed, currentShift, contract, modifierSeen1, modifierSeen2, ordersSeen, playerResults, score, shiftScores, shiftTime);
		clipboardInSFX.Play();
		animator.SetBool("show", value: true);
		yield return FullSequenceCo(passed, currentShift, score, playerResults, costumesUnlocked, contractsUnlocked);
	}

	public void Hide()
	{
		StartCoroutine(HideCo());
	}

	private IEnumerator HideCo()
	{
		animator.SetTrigger("proceed");
		ParticleSystem[] array = confettiBursts;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
		ParticleSystem.EmissionModule emission = confettiRain.emission;
		emission.enabled = false;
		yield return new WaitForSeconds(0.5f);
		clipboardOutSFX.Play();
		animator.SetBool("show", value: false);
		playerProceedUI.Hide();
		animator.SetTrigger("congratsOut");
		newRecord.EaseOut();
	}

	public void SetUp(bool passed, int currentShift, ContractObject contractObject, Sprite modifierA, Sprite modifierB, ShiftOrderObject[] ordersSeen, PlayerResult[] playerResults, ContractScore contractScore, ContractScore[] shiftScores, TimeSpan contractTime)
	{
		contractTitleText.SetIndex(contractObject.title);
		Image[] array = boxImages;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
		for (int j = 0; j < ordersSeen.Length; j++)
		{
			boxImages[j].sprite = ordersSeen[j].UIImage;
			boxImages[j].gameObject.SetActive(value: true);
		}
		modifierAImages[0].sprite = modifierA;
		modifierAImages[0].gameObject.SetActive(modifierA != null);
		modifierBImages[0].sprite = modifierB;
		modifierBImages[0].gameObject.SetActive(modifierB != null);
		for (int k = 0; k < bells.Count; k++)
		{
			bellCrossOuts[k].gameObject.SetActive(value: false);
			bells[k].gameObject.SetActive(value: false);
		}
		int num = playerResults.Length;
		for (int l = 0; l < 4; l++)
		{
			playerIconObjects[l].SetActive(l < num);
			crashoutCountObjects[l].SetActive(l < num);
			nitroCountObjects[l].SetActive(l < num);
			driftCountObjects[l].SetActive(l < num);
			upgradeCountObjects[l].SetActive(l < num);
		}
		for (int m = 0; m < playerResults.Length; m++)
		{
			playerIconImages[m].color = playerResults[m].color;
			playerNameTexts[m].color = playerResults[m].color * 0.5f;
			playerNameTexts[m].text = playerResults[m].name;
			playerHighlightImages[m].color = new Color(playerResults[m].color.r * 0.9f, playerResults[m].color.g * 0.9f, playerResults[m].color.b * 0.9f, 0.5f);
		}
		_skipped = false;
		_gotNewRecord = false;
		if (GameUtil.contract.type == ContractType.Explicit)
		{
			if (previousHighScore < 5 && passed)
			{
				_gotNewRecord = true;
			}
			if ((int)(passed ? contractScore : ContractScore.D) > (int)previousHighContractScore)
			{
				_gotNewRecord = true;
			}
		}
		for (int n = 0; n < gradeImages.Length; n++)
		{
			gradeImages[n].gameObject.SetActive(value: false);
			gradeImages[n].sprite = gradeSprites[(uint)(shiftScores[n] + 1)];
			gradeImages[n].color = GlobalScriptableObject<AggroSettingsObject>.instance.gradeColors[(uint)(shiftScores[n] + 1)];
			if (!passed && n == currentShift - 1)
			{
				gradeImages[n].sprite = gradeSprites[0];
				gradeImages[n].color = GlobalScriptableObject<AggroSettingsObject>.instance.gradeColors[0];
			}
		}
		finalGradeContainer.gameObject.SetActive(value: false);
		finalGradeImage.sprite = gradeSprites[(uint)(passed ? (contractScore + 1) : ContractScore.D)];
		finalGradeDillyImage.sprite = gradeDillySprites[(uint)(passed ? (contractScore + 1) : ContractScore.D)];
		finalGradeDillyImage.gameObject.SetActive(value: false);
		finalGradeImage.color = GlobalScriptableObject<AggroSettingsObject>.instance.gradeColors[(uint)(passed ? (contractScore + 1) : ContractScore.D)];
		if (passed)
		{
			bestTimeText.text = contractTime.ToString("mm\\:ss\\:ff");
		}
		else
		{
			bestTimeText.text = "--:--:--";
		}
	}

	private IEnumerator FullSequenceCo(bool passed, int currentShift, ContractScore contractScore, PlayerResult[] playerResults, CostumeObject[] costumesUnlocked, ContractObject[] contractsUnlocked)
	{
		for (int i = 0; i < costumesUnlocked.Length; i++)
		{
			yield return costumeUnlockedUI.ShowUnlockCo(costumesUnlocked[i]);
		}
		for (int i = 0; i < contractsUnlocked.Length; i++)
		{
			yield return contractUnlockedUI.ShowUnlockCo(contractsUnlocked[i]);
		}
		if (_skipped || AggroInputManager.input.QuotaReport.Skip.WasPressedThisFrame())
		{
			_skipped = true;
		}
		if (!_skipped)
		{
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < currentShift - 1; i++)
		{
			EventReference gradeSfx = gradeFSfx;
			switch (NetworkAggroManagerBase<ShiftManager>.instance.shiftScores[i])
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
			bellSFX.Play();
			bellSFX.SetParameter("pitch-Up", (float)i / 4f);
			yield return GrowRevealCo(bells[i], ease, animLengthSeconds);
			AudioManager.PlaySfx(gradeSfx);
			yield return GrowRevealCo(gradeImages[i].transform, ease, animLengthSeconds);
		}
		if (passed)
		{
			bellSFX.Play();
			bellSFX.SetParameter("pitch-Up", 1f);
			yield return GrowRevealCo(bells[currentShift - 1], ease, animLengthSeconds);
			EventReference eventRef = gradeFSfx;
			switch (NetworkAggroManagerBase<ShiftManager>.instance.shiftScores[currentShift - 1])
			{
			case ContractScore.D:
				eventRef = gradeDSfx;
				break;
			case ContractScore.C:
				eventRef = gradeCSfx;
				break;
			case ContractScore.B:
				eventRef = gradeBSfx;
				break;
			case ContractScore.A:
				eventRef = gradeASfx;
				break;
			case ContractScore.S:
				eventRef = gradeSSfx;
				break;
			}
			AudioManager.PlaySfx(eventRef);
			yield return GrowRevealCo(gradeImages[currentShift - 1].transform, ease, animLengthSeconds);
		}
		else
		{
			bellFailSFXEmitter.Play();
			AudioManager.PlaySfx(gradeFSfx);
			yield return GrowRevealCo(bellCrossOuts[currentShift - 1], ease, animLengthSeconds);
			yield return GrowRevealCo(gradeImages[currentShift - 1].transform, ease, animLengthSeconds);
		}
		EventReference eventRef2 = gradeFSfx;
		switch (contractScore)
		{
		case ContractScore.D:
			eventRef2 = gradeDSfx;
			break;
		case ContractScore.C:
			eventRef2 = gradeCSfx;
			break;
		case ContractScore.B:
			eventRef2 = gradeBSfx;
			break;
		case ContractScore.A:
			eventRef2 = gradeASfx;
			break;
		case ContractScore.S:
			eventRef2 = gradeSSfx;
			break;
		}
		AudioManager.PlaySfx(eventRef2);
		yield return GrowRevealCo(finalGradeContainer, ease, animLengthSeconds);
		yield return GrowRevealCo(finalGradeDillyImage.transform, ease, animLengthSeconds);
		if (_gotNewRecord)
		{
			newRecord.EaseIn();
		}
		int[] array = new int[4];
		int[] nitroCounts = new int[4];
		int[] driftCounts = new int[4];
		int[] upgradeCounts = new int[4];
		for (int j = 0; j < playerResults.Length; j++)
		{
			array[j] = playerResults[j].crashOuts;
			nitroCounts[j] = playerResults[j].nitroCount;
			driftCounts[j] = playerResults[j].driftDistanceCount;
			upgradeCounts[j] = playerResults[j].upgradeCount;
		}
		if (passed)
		{
			passStampSFX.Play();
		}
		else
		{
			failStampSFX.Play();
		}
		if (passed)
		{
			winSFX.Play();
			animator.SetTrigger("congratsIn");
			ParticleSystem[] array2 = confettiBursts;
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k].Play();
			}
			ParticleSystem.EmissionModule emission = confettiRain.emission;
			emission.enabled = true;
		}
		yield return AddUpCountCo("", "", crashoutCountTexts.ToArray(), new int[4], array, crashoutSFX, 0.2f);
		yield return AddUpCountCo("", "", nitroCountTexts.ToArray(), new int[4], nitroCounts, nitroSFX, 0.2f);
		yield return AddUpCountCo("", "m", driftCountTexts.ToArray(), new int[4], driftCounts, driftSFX, 0.2f);
		yield return AddUpCountCo("", "", upgradeCountTexts.ToArray(), new int[4], upgradeCounts, upgradeSFX, 1f);
		playerProceedUI.Show();
	}

	public IEnumerator GrowRevealCo(Transform revealTransform, EasingFunction.Ease revealEase, float animLength)
	{
		revealTransform.gameObject.SetActive(value: true);
		float animTime = 0f;
		while (animTime < animLength)
		{
			if (_skipped)
			{
				revealTransform.localScale = Vector3.one;
				break;
			}
			animTime += Time.deltaTime;
			float value = animTime / animLength;
			float num = EasingFunction.Evaluate(revealEase, value) * animStrength;
			revealTransform.localScale = new Vector3(num, num, num);
			yield return null;
		}
	}

	private IEnumerator AddUpCountCo(string prefix, string suffix, TextMeshProUGUI[] texts, int[] starts, int[] ends, StudioEventEmitter sfxEvent, float sfxRate, bool invertPitchDirection = false)
	{
		sfxEvent.Play();
		for (int i = 0; i < texts.Length; i++)
		{
			texts[i].text = prefix + "0" + suffix;
		}
		float accumulatedTime = 0f;
		int[] previousValues = new int[4];
		do
		{
			yield return null;
			if (_skipped)
			{
				for (int j = 0; j < texts.Length; j++)
				{
					texts[j].text = prefix + ends[j] + suffix;
				}
				break;
			}
			accumulatedTime += Time.deltaTime;
			float num = accumulatedTime / tallyTime;
			for (int k = 0; k < texts.Length; k++)
			{
				int num2 = Mathf.RoundToInt(Mathf.Lerp(starts[k], ends[k], Mathf.Clamp01(num)));
				texts[k].text = prefix + num2 + suffix;
				if (num2 != previousValues[k])
				{
					sfxEvent.SetParameter("pitch-Up", invertPitchDirection ? (1f - num) : num);
					if (UnityEngine.Random.Range(0f, 1f) > 1f - sfxRate)
					{
						sfxEvent.Play();
					}
				}
				previousValues[k] = num2;
			}
		}
		while (accumulatedTime < tallyTime);
	}

	protected override void OnUpdatePresentation()
	{
		if (AggroInputManager.input.QuotaReport.Skip.WasPressedThisFrame())
		{
			_skipped = true;
		}
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.QuotaReport.Enable();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.QuotaReport.Disable();
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		if (phase == ShiftPhase.BreakRoom && shift == 1)
		{
			int num = 0;
			if (GameUtil.contract != null && GameUtil.contract.type == ContractType.Explicit && !SaveManager.data.TryGetContractBellCount(GameUtil.contract, out num))
			{
				num = 0;
			}
			ContractScore score = ContractScore.D;
			if (GameUtil.contract != null && GameUtil.contract.type == ContractType.Explicit && !SaveManager.data.TryGetContractScore(GameUtil.contract, out score))
			{
				num = 0;
			}
			previousHighScore = num;
			previousHighContractScore = score;
		}
	}
}
