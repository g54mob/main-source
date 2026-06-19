using System.Collections;
using Aggro.Core;
using UnityEngine;
using UnityEngine.UI;

public class EaseUI : EntityBehaviourBase
{
	public EasingFunction.Ease ease = EasingFunction.Ease.EaseInOutQuad;

	public float durationSec = 1f;

	public bool startHidden = true;

	public bool transitioning;

	public bool blorb;

	public bool visible;

	public float animSpeed = 1f;

	public float animStrength = 1f;

	private float _animTime;

	public bool show;

	public float delay;

	private float _timer;

	public Image fadeImage;

	public float _fadeImageOriginalOpacity;

	[SerializeField]
	public LayoutElement layoutElement;

	public bool useUnscaledDeltaTime;

	protected override void OnEntityCreated()
	{
		if (startHidden)
		{
			base.transform.localScale = Vector3.zero;
			if (fadeImage != null)
			{
				_fadeImageOriginalOpacity = fadeImage.color.a;
				fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
			}
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (show)
		{
			_timer += (useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime);
		}
		else
		{
			_timer = 0f;
		}
		if (_timer > delay && show && !visible && !transitioning)
		{
			EaseIn();
		}
		if (!show && visible && !transitioning)
		{
			EaseOut();
		}
		if (visible && !transitioning && blorb)
		{
			base.transform.localScale = Vector3.one * (1f + Mathf.Sin(_animTime * animSpeed) / 2f * animStrength);
			_animTime += (useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime);
		}
		if (layoutElement != null)
		{
			layoutElement.ignoreLayout = !visible;
		}
	}

	public void EaseIn()
	{
		StopAllCoroutines();
		StartCoroutine(EaseInCo());
	}

	private IEnumerator EaseInCo()
	{
		show = true;
		transitioning = true;
		visible = true;
		for (float time = 0f; time < durationSec; time += (useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime))
		{
			base.transform.localScale = Vector3.one * EasingFunction.Evaluate(ease, time / durationSec);
			if (fadeImage != null)
			{
				fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, _fadeImageOriginalOpacity * (time / durationSec));
			}
			yield return null;
		}
		base.transform.localScale = Vector3.one;
		if (fadeImage != null)
		{
			fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, _fadeImageOriginalOpacity);
		}
		transitioning = false;
		_animTime = 0f;
	}

	private IEnumerator EaseOutCo()
	{
		show = false;
		transitioning = true;
		for (float time = 0f; time < durationSec; time += (useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime))
		{
			base.transform.localScale = Vector3.one * EasingFunction.Evaluate(ease, 1f - time / durationSec);
			if (fadeImage != null)
			{
				fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, _fadeImageOriginalOpacity * (1f - time / durationSec));
			}
			yield return null;
		}
		base.transform.localScale = Vector3.zero;
		if (fadeImage != null)
		{
			fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
		}
		transitioning = false;
		visible = false;
	}

	public void EaseOut()
	{
		if (visible)
		{
			StopAllCoroutines();
			StartCoroutine(EaseOutCo());
		}
	}
}
