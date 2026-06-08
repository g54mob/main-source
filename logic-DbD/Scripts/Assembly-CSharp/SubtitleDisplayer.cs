using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class SubtitleDisplayer : MonoBehaviour
{
	public TextAsset Subtitle;

	public TextMeshProUGUI Text;

	public TextMeshProUGUI Text2;

	[Range(0f, 1f)]
	public float FadeTime;

	private bool _isPaused;

	private bool _isPausedTimeSet;

	private float _pausedTime;

	private void Start()
	{
		StartCoroutine(Begin());
	}

	public IEnumerator Begin()
	{
		TextMeshProUGUI currentlyDisplayingText = Text;
		TextMeshProUGUI fadedOutText = Text2;
		currentlyDisplayingText.text = string.Empty;
		fadedOutText.text = string.Empty;
		currentlyDisplayingText.gameObject.SetActive(value: true);
		fadedOutText.gameObject.SetActive(value: true);
		yield return FadeTextOut(currentlyDisplayingText);
		yield return FadeTextOut(fadedOutText);
		SRTParser parser = new SRTParser(Subtitle);
		float startTime = Time.time;
		SubtitleBlock currentSubtitle = null;
		while (true)
		{
			if (_isPaused)
			{
				if (!_isPausedTimeSet)
				{
					_pausedTime = Time.time;
					_isPausedTimeSet = true;
				}
				yield return null;
				continue;
			}
			if (_isPausedTimeSet)
			{
				startTime += Time.time - _pausedTime;
				_isPausedTimeSet = false;
			}
			float time = Time.time - startTime;
			SubtitleBlock forTime = parser.GetForTime(time);
			if (forTime == null)
			{
				break;
			}
			if (!forTime.Equals(currentSubtitle))
			{
				currentSubtitle = forTime;
				TextMeshProUGUI textMeshProUGUI = currentlyDisplayingText;
				currentlyDisplayingText = fadedOutText;
				fadedOutText = textMeshProUGUI;
				currentlyDisplayingText.text = currentSubtitle.Text;
				StartCoroutine(FadeTextOut(fadedOutText));
				yield return new WaitForSeconds(FadeTime / 3f);
				yield return FadeTextIn(currentlyDisplayingText);
			}
			yield return null;
		}
		StartCoroutine(FadeTextOut(currentlyDisplayingText));
		yield return FadeTextOut(fadedOutText);
		currentlyDisplayingText.gameObject.SetActive(value: false);
		fadedOutText.gameObject.SetActive(value: false);
	}

	private void OnValidate()
	{
		FadeTime = (float)(int)(FadeTime * 10f) / 10f;
	}

	private IEnumerator FadeTextOut(TextMeshProUGUI text)
	{
		Color color = text.color;
		color.a = 0f;
		yield return Fade(text, color, Ease.OutSine);
	}

	private IEnumerator FadeTextIn(TextMeshProUGUI text)
	{
		Color color = text.color;
		color.a = 1f;
		yield return Fade(text, color, Ease.InSine);
	}

	private IEnumerator Fade(TextMeshProUGUI text, Color toColor, Ease ease)
	{
		yield return DOTween.To(() => text.color, delegate(Color color)
		{
			text.color = color;
		}, toColor, FadeTime).SetEase(ease).WaitForCompletion();
	}
}
