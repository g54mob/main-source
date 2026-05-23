using System.Collections;
using Rewired;
using TMPro;
using UnityEngine;

public class EternalTrialsVictoryUI : IUIAnimationSequence
{
	public GameObject parentObject;

	public GameObject dividerParent;

	public ThronefallUIElement continueButton;

	public TextMeshProUGUI stageDisplay;

	public TextMeshProUGUI baseScore;

	public TextMeshProUGUI baseScoreName;

	public TextMeshProUGUI goldScore;

	public TextMeshProUGUI goldBonusName;

	public TextMeshProUGUI overallScore;

	public TextMeshProUGUI victoryDisplay;

	public AnimationCurve popShowCurve;

	public AnimationCurve bumpCurve;

	public AnimationCurve scoreFillWiggle;

	public AudioSource audioSource;

	public CanvasGroup backgroundCG;

	private bool inScoreUnroll;

	private int baseScoreThisRound;

	private int goldScoreThisRound;

	private int overallScoreThisRound;

	private int animationNextScore;

	private float defaultWaitStep = 0.5f;

	private float minorWaitStep = 0.25f;

	private float animationStepA = 1.5f;

	private float animationStepB = 0.5f;

	private Coroutine currentScoringAnimation;

	private bool skipScoringAnimation;

	private bool inAnimation;

	private Player input;

	private void Update()
	{
		if (input == null)
		{
			input = ReInput.players.GetPlayer(0);
		}
		if (input != null && input.GetButtonDown("Interact") && inScoreUnroll)
		{
			if (currentScoringAnimation != null)
			{
				StopCoroutine(currentScoringAnimation);
			}
			currentScoringAnimation = null;
			audioSource.Stop();
			skipScoringAnimation = true;
			inScoreUnroll = false;
		}
	}

	public override IEnumerator PlayAnimation(UIFrame contextFrame)
	{
		inScoreUnroll = false;
		skipScoringAnimation = false;
		parentObject.SetActive(value: true);
		victoryDisplay.text = TextTranslator.Translate("Menu/Victory") + ".";
		stageDisplay.text = "<style=Body Bold>" + TextTranslator.Translate("Menu/Stage") + "<style=Body Numerals> " + EternalTrialsRunManager.CurrentRun.stage;
		baseScore.gameObject.SetActive(value: false);
		baseScoreName.gameObject.SetActive(value: false);
		goldScore.gameObject.SetActive(value: false);
		goldBonusName.gameObject.SetActive(value: false);
		dividerParent.SetActive(value: false);
		backgroundCG.alpha = 0f;
		parentObject.SetActive(value: true);
		float mainFrameFadeTimer = 0f;
		float fadeTime = 0.25f;
		while (mainFrameFadeTimer < fadeTime)
		{
			mainFrameFadeTimer += Time.unscaledDeltaTime;
			backgroundCG.alpha = mainFrameFadeTimer / fadeTime;
			yield return null;
		}
		backgroundCG.alpha = 1f;
		Time.timeScale = 0f;
		currentScoringAnimation = StartCoroutine(UnrollScores());
		while (currentScoringAnimation != null)
		{
			yield return null;
		}
		if (skipScoringAnimation)
		{
			SkipUnrollScores();
		}
		inAnimation = false;
		contextFrame.Select(continueButton);
		yield return null;
	}

	public override void Reset()
	{
		parentObject.SetActive(value: false);
	}

	private IEnumerator UnrollScores()
	{
		inScoreUnroll = true;
		baseScoreThisRound = SceneTransitionManager.instance.IngameScoreFromLastMatch;
		goldScoreThisRound = SceneTransitionManager.instance.GoldBonusScoreFromLastMatch;
		overallScoreThisRound = EternalTrialsRunManager.CurrentRun.score - baseScoreThisRound - goldScoreThisRound;
		animationNextScore = overallScoreThisRound;
		baseScore.text = baseScoreThisRound.ToString();
		goldScore.text = goldScoreThisRound.ToString();
		overallScore.text = overallScoreThisRound.ToString();
		dividerParent.SetActive(value: true);
		StartCoroutine(PopShowTransform(dividerParent.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildB, popShowCurve, animationStepB));
		baseScoreName.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(baseScoreName.transform, null, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		baseScore.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(baseScore.transform, null, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		yield return AddToOverallScore(baseScoreThisRound, animationStepA);
		goldBonusName.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(goldBonusName.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildC, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		goldScore.gameObject.SetActive(value: true);
		StartCoroutine(PopShowTransform(goldScore.transform, ThronefallAudioManager.Instance.audioContent.PointScreenBuildA, popShowCurve, animationStepB));
		yield return new WaitForSecondsRealtime(minorWaitStep);
		yield return AddToOverallScore(goldScoreThisRound, animationStepA);
		currentScoringAnimation = null;
	}

	private void SkipUnrollScores()
	{
		baseScoreThisRound = SceneTransitionManager.instance.IngameScoreFromLastMatch;
		goldScoreThisRound = SceneTransitionManager.instance.GoldBonusScoreFromLastMatch;
		overallScoreThisRound = EternalTrialsRunManager.CurrentRun.score;
		baseScore.text = baseScoreThisRound.ToString();
		goldScore.text = goldScoreThisRound.ToString();
		overallScore.text = overallScoreThisRound.ToString();
		dividerParent.SetActive(value: true);
		baseScoreName.gameObject.SetActive(value: true);
		baseScore.gameObject.SetActive(value: true);
		goldBonusName.gameObject.SetActive(value: true);
		goldScore.gameObject.SetActive(value: true);
		dividerParent.transform.localScale = Vector3.one;
		baseScoreName.transform.localScale = Vector3.one;
		baseScore.transform.localScale = Vector3.one;
		goldBonusName.transform.localScale = Vector3.one;
		goldScore.transform.localScale = Vector3.one;
		overallScore.transform.localScale = Vector3.one;
		StartCoroutine(LockInScoreBump(0.5f));
	}

	private IEnumerator AddToOverallScore(int scoreToAdd, float animTime)
	{
		if (scoreToAdd == 0)
		{
			yield return new WaitForSecondsRealtime(0.15f);
			yield break;
		}
		audioSource.clip = ThronefallAudioManager.Instance.audioContent.PointFill;
		audioSource.loop = true;
		audioSource.Play();
		animationNextScore += scoreToAdd;
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.unscaledDeltaTime;
			overallScore.text = Mathf.RoundToInt(Mathf.Lerp(overallScoreThisRound, animationNextScore, Mathf.InverseLerp(0f, animTime, timer))).ToString();
			yield return null;
		}
		overallScoreThisRound = animationNextScore;
		overallScore.text = overallScoreThisRound.ToString();
		audioSource.Stop();
		audioSource.loop = false;
		yield return StartCoroutine(LockInScoreBump(0.5f));
	}

	private IEnumerator LockInScoreBump(float animTime)
	{
		audioSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointLockInMajor, 0.85f);
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.unscaledDeltaTime;
			overallScore.transform.localScale = Vector3.one * bumpCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		overallScore.transform.localScale = Vector3.one;
	}

	private IEnumerator Bump(float animTime, Transform target, AudioClip clip)
	{
		if ((bool)clip)
		{
			audioSource.PlayOneShot(clip);
		}
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.unscaledDeltaTime;
			target.transform.localScale = Vector3.one * bumpCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		target.transform.localScale = Vector3.one;
	}

	private IEnumerator PopShowTransform(Transform target, AudioClip clip, AnimationCurve curve, float animTime)
	{
		if ((bool)clip)
		{
			audioSource.PlayOneShot(clip);
		}
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.unscaledDeltaTime;
			target.localScale = Vector3.one * curve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		target.localScale = Vector3.one;
	}
}
