using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickedBigButton : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _text;

	[SerializeField]
	private RawImage _background;

	[SerializeField]
	private float fadeSpeed = 2f;

	private Coroutine fadeCoroutine;

	private void OnEnable()
	{
		if (fadeCoroutine != null)
		{
			StopCoroutine(fadeCoroutine);
		}
		fadeCoroutine = StartCoroutine(FadeIn());
	}

	private IEnumerator FadeIn()
	{
		Color textColor = _text.color;
		Color backgroundColor = _background.color;
		textColor.a = 0f;
		backgroundColor.a = 0f;
		_text.color = textColor;
		_background.color = backgroundColor;
		float time = 0f;
		while (time < 1f)
		{
			time += Time.deltaTime * fadeSpeed;
			backgroundColor.a = (textColor.a = Mathf.Lerp(0f, 1f, time));
			_text.color = textColor;
			_background.color = backgroundColor;
			yield return null;
		}
		textColor.a = 1f;
		backgroundColor.a = 1f;
		_text.color = textColor;
		_background.color = backgroundColor;
	}
}
