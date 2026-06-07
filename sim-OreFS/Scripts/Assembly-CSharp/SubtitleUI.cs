using System.Collections;
using I2.Loc;
using TMPro;
using UnityEngine;

public class SubtitleUI : MonoBehaviour
{
	public TMP_Text targetText;

	public string localizationKey;

	public float delayPerCharacter = 0.03f;

	public float commaPause = 0.3f;

	public float closeDelay = 2f;

	public bool triggerOnEnable = true;

	private string fullText;

	private Coroutine subtitleCoroutine;

	private void OnEnable()
	{
		if (triggerOnEnable)
		{
			Play();
		}
	}

	public void Play()
	{
		if (targetText == null || string.IsNullOrEmpty(localizationKey))
		{
			return;
		}
		fullText = LocalizationManager.GetTranslation(localizationKey);
		if (!string.IsNullOrEmpty(fullText))
		{
			if (subtitleCoroutine != null)
			{
				StopCoroutine(subtitleCoroutine);
			}
			subtitleCoroutine = StartCoroutine(SubtitleRoutine());
		}
	}

	public void Skip()
	{
		if (subtitleCoroutine != null)
		{
			StopCoroutine(subtitleCoroutine);
		}
		if (targetText != null)
		{
			targetText.text = fullText;
		}
	}

	private IEnumerator SubtitleRoutine()
	{
		string[] words = fullText.Split(' ');
		targetText.text = "";
		for (int i = 0; i < words.Length; i++)
		{
			if (i > 0)
			{
				targetText.text += " ";
			}
			targetText.text += words[i];
			float num = (float)words[i].Length * delayPerCharacter;
			if (words[i].EndsWith(","))
			{
				num += commaPause;
			}
			yield return new WaitForSeconds(num);
		}
		yield return new WaitForSeconds(closeDelay);
		targetText.text = "";
		base.gameObject.SetActive(value: false);
		subtitleCoroutine = null;
	}

	private void OnDisable()
	{
		if (subtitleCoroutine != null)
		{
			StopCoroutine(subtitleCoroutine);
			subtitleCoroutine = null;
		}
		targetText.text = "";
	}
}
