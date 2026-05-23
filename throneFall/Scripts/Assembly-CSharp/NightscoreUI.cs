using System.Collections;
using MPUIKIT;
using TMPro;
using UnityEngine;

public class NightscoreUI : MonoBehaviour
{
	public GameObject nightScorePanel;

	public TextMeshProUGUI baseScore;

	public TextMeshProUGUI timeBonus;

	public TextMeshProUGUI protectionPercentage;

	public TextMeshProUGUI protectionScore;

	public TextMeshProUGUI overallScore;

	public AudioSource pointSFXSource;

	[Header("ANIMATION")]
	public MPImage backgroundImage;

	public RectTransform content;

	public RectTransform nightSurviveText;

	public RectTransform nightSurviveNumber;

	public RectTransform timeText;

	public RectTransform timeNumber;

	public RectTransform protectionText;

	public RectTransform protectionNumber;

	public RectTransform overallScoreBG;

	public RectTransform overallScoreNumber;

	public AnimationCurve popCurve;

	public AnimationCurve expandCurve;

	public AnimationCurve bumpCurve;

	public AnimationCurve simpleQuad;

	public static NightscoreUI instance;

	private float initialWaitTime = 3f;

	private float completeWaitTime = 3f;

	private float buildUpSFXVol = 0.8f;

	private float clock;

	private bool shown;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		nightScorePanel.SetActive(value: false);
		ScoreManager.Instance.OnNightScoreAdd.AddListener(ShowNightScore);
		UIFrameManager.instance.onFrameOpen.AddListener(StopPointFillSoundOnPause);
	}

	private void StopPointFillSoundOnPause()
	{
		pointSFXSource.Stop();
	}

	public void ShowNightScore(int _baseScore, int _timeBonus, float _protectionPercentage, int _protectionBonus)
	{
		if (EnemySpawner.instance.Wavenumber < EnemySpawner.instance.waves.Count - 1)
		{
			shown = true;
			StopAllCoroutines();
			clock = 0f;
			StartCoroutine(PlayPopUpAnimation(_baseScore, _timeBonus, _protectionPercentage, _protectionBonus));
		}
	}

	public void HideNightScore()
	{
		shown = false;
		pointSFXSource.Stop();
		StopAllCoroutines();
		StartCoroutine(PlayHideAnimation());
	}

	private IEnumerator PlayPopUpAnimation(int basescore, int timebonus, float protectionpercent, int protectionbonus)
	{
		nightScorePanel.SetActive(value: true);
		Vector2 contentSizeDelta = content.sizeDelta;
		int currentScore = ScoreManager.Instance.CurrentScore - basescore - timebonus - protectionbonus;
		int nextScore = currentScore;
		baseScore.text = "+" + basescore;
		timeBonus.text = "+" + timebonus;
		protectionPercentage.text = TextTranslator.Translate("Menu/Realm") + " " + Mathf.RoundToInt(protectionpercent * 100f) + "% " + TextTranslator.Translate("Menu/Protected");
		protectionScore.text = "+" + protectionbonus;
		overallScore.text = currentScore.ToString();
		contentSizeDelta.y = 0f;
		content.sizeDelta = contentSizeDelta;
		nightSurviveText.localScale = Vector3.zero;
		nightSurviveNumber.localScale = Vector3.zero;
		timeText.localScale = Vector3.zero;
		timeNumber.localScale = Vector3.zero;
		protectionText.localScale = Vector3.zero;
		protectionNumber.localScale = Vector3.zero;
		overallScoreBG.localScale = Vector3.zero;
		overallScoreNumber.localScale = Vector3.zero;
		yield return new WaitForSeconds(initialWaitTime);
		float animTime = 0.5f;
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			overallScoreBG.localScale = Vector3.one * popCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			overallScoreNumber.localScale = Vector3.one * popCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		overallScoreBG.localScale = Vector3.one;
		overallScoreNumber.localScale = Vector3.one;
		yield return new WaitForSeconds(0.25f);
		pointSFXSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointScreenBuildB, buildUpSFXVol);
		animTime = 0.5f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			content.sizeDelta = contentSizeDelta + Vector2.up * 55f * expandCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		content.sizeDelta = contentSizeDelta + Vector2.up * 55f;
		contentSizeDelta = content.sizeDelta;
		pointSFXSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointScreenBuildC, buildUpSFXVol);
		animTime = 0.5f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			nightSurviveText.localScale = Vector3.one * popCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			nightSurviveNumber.localScale = Vector3.one * popCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		nightSurviveText.localScale = Vector3.one;
		nightSurviveNumber.localScale = Vector3.one;
		pointSFXSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointScreenBuildB, buildUpSFXVol);
		animTime = 0.5f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			content.sizeDelta = contentSizeDelta + Vector2.up * 30f * expandCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		content.sizeDelta = contentSizeDelta + Vector2.up * 30f;
		contentSizeDelta = content.sizeDelta;
		pointSFXSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointScreenBuildC, buildUpSFXVol);
		animTime = 0.5f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			protectionText.localScale = Vector3.one * popCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			protectionNumber.localScale = Vector3.one * popCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		protectionText.localScale = Vector3.one;
		protectionNumber.localScale = Vector3.one;
		pointSFXSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointScreenBuildB, buildUpSFXVol);
		animTime = 0.5f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			content.sizeDelta = contentSizeDelta + Vector2.up * 30f * expandCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		content.sizeDelta = contentSizeDelta + Vector2.up * 30f;
		_ = content.sizeDelta;
		pointSFXSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointScreenBuildC, buildUpSFXVol);
		animTime = 0.5f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			timeText.localScale = Vector3.one * popCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			timeNumber.localScale = Vector3.one * popCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		timeText.localScale = Vector3.one;
		timeNumber.localScale = Vector3.one;
		pointSFXSource.Play();
		animTime = 1.5f;
		timer = 0f;
		nextScore += basescore + protectionbonus + timebonus;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			overallScore.text = Mathf.RoundToInt(Mathf.Lerp(currentScore, nextScore, Mathf.InverseLerp(0f, animTime, timer))).ToString();
			yield return null;
		}
		currentScore = nextScore;
		overallScore.text = currentScore.ToString();
		pointSFXSource.Stop();
		pointSFXSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointLockInMinor);
		animTime = 0.5f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			overallScoreBG.localScale = Vector3.one * bumpCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		overallScoreBG.localScale = Vector3.one;
		yield return new WaitForSeconds(completeWaitTime);
		HideNightScore();
	}

	private IEnumerator PlayHideAnimation()
	{
		pointSFXSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PointScreenBuildB, buildUpSFXVol);
		Vector2 contentSizeDelta = content.sizeDelta;
		nightSurviveText.localScale = Vector3.one;
		nightSurviveNumber.localScale = Vector3.one;
		timeText.localScale = Vector3.one;
		timeNumber.localScale = Vector3.one;
		protectionText.localScale = Vector3.one;
		protectionNumber.localScale = Vector3.one;
		overallScoreBG.localScale = Vector3.one;
		overallScoreNumber.localScale = Vector3.one;
		timeText.localScale = Vector3.zero;
		timeNumber.localScale = Vector3.zero;
		float animTime = 0.4f;
		float timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			content.sizeDelta = contentSizeDelta - Vector2.up * 30f * expandCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		content.sizeDelta = contentSizeDelta - Vector2.up * 30f;
		contentSizeDelta = content.sizeDelta;
		protectionText.localScale = Vector3.zero;
		protectionNumber.localScale = Vector3.zero;
		animTime = 0.4f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			content.sizeDelta = contentSizeDelta - Vector2.up * 30f * expandCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		content.sizeDelta = contentSizeDelta - Vector2.up * 30f;
		contentSizeDelta = content.sizeDelta;
		nightSurviveText.localScale = Vector3.zero;
		nightSurviveNumber.localScale = Vector3.zero;
		animTime = 0.4f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			if (Mathf.InverseLerp(0f, animTime, timer) > 0.425f)
			{
				backgroundImage.enabled = false;
			}
			content.sizeDelta = contentSizeDelta - Vector2.up * 55f * expandCurve.Evaluate(Mathf.InverseLerp(0f, animTime, timer));
			yield return null;
		}
		content.sizeDelta = contentSizeDelta - Vector2.up * 55f;
		backgroundImage.enabled = true;
		animTime = 0.2f;
		timer = 0f;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			overallScoreNumber.localScale = Vector3.one * simpleQuad.Evaluate(Mathf.InverseLerp(animTime, 0f, timer));
			overallScoreBG.localScale = Vector3.one * simpleQuad.Evaluate(Mathf.InverseLerp(animTime, 0f, timer));
			yield return null;
		}
		overallScoreNumber.localScale = Vector3.zero;
		overallScoreBG.localScale = Vector2.zero;
		nightScorePanel.SetActive(value: false);
	}
}
