using UnityEngine;
using UnityEngine.UI;

public class ClickedToolButton : MonoBehaviour
{
	[SerializeField]
	private Image _outline;

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private Image _background;

	[SerializeField]
	private float fadeInSpeed = 2f;

	private float fadeTime;

	private bool isFadingIn = true;

	private void OnEnable()
	{
		fadeTime = 0f;
		isFadingIn = true;
		SetAlphaForAllImages(0f);
	}

	private void Update()
	{
		if (isFadingIn)
		{
			FadeInImages();
		}
	}

	private void FadeInImages()
	{
		if (fadeTime >= 1f)
		{
			isFadingIn = false;
			return;
		}
		fadeTime += Time.deltaTime * fadeInSpeed;
		float a = Mathf.Lerp(0f, 1f, fadeTime);
		float a2 = Mathf.Lerp(0f, 1f, fadeTime);
		float a3 = Mathf.Lerp(0f, 1f, fadeTime);
		_outline.color = new Color(_outline.color.r, _outline.color.g, _outline.color.b, a);
		_icon.color = new Color(_icon.color.r, _icon.color.g, _icon.color.b, a2);
		_background.color = new Color(_background.color.r, _background.color.g, _background.color.b, a3);
	}

	private void SetAlphaForAllImages(float alpha)
	{
		_outline.color = new Color(_outline.color.r, _outline.color.g, _outline.color.b, alpha);
		_icon.color = new Color(_icon.color.r, _icon.color.g, _icon.color.b, alpha);
		_background.color = new Color(_background.color.r, _background.color.g, _background.color.b, alpha);
	}
}
