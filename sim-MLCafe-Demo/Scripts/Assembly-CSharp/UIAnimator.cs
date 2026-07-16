using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIAnimator : MonoBehaviour
{
	public static void StopAllQuedRoutines(List<Coroutine> que, MonoBehaviour instance)
	{
		if (instance == null)
		{
			return;
		}
		que = que.Where((Coroutine x) => x != null).ToList();
		foreach (Coroutine item in que)
		{
			instance.StopCoroutine(item);
		}
		que.Clear();
	}

	public static IEnumerator SliderAnimator(Slider slider, float target, AnimationCurve curve, float time)
	{
		float start = slider.value;
		float alpha = 0f;
		while (true)
		{
			alpha += 1f / time * Time.unscaledDeltaTime;
			if (alpha >= 1f)
			{
				break;
			}
			slider.value = Mathf.Lerp(start, target, curve.Evaluate(alpha));
			yield return null;
		}
	}

	public static IEnumerator SoundAnimator(AudioSource source, float startVolume, float targetVolume, AnimationCurve curve, float time)
	{
		float alpha = 0f;
		while (true)
		{
			alpha += 1f / time * Time.deltaTime;
			if (alpha >= 1f)
			{
				break;
			}
			source.volume = Mathf.Lerp(startVolume, targetVolume, curve.Evaluate(alpha));
			yield return null;
		}
	}

	public static IEnumerator Fader(UIFieldProperties property, RectTransform anchor, Image visualArea, AnimationCurve curve, float fadeTime, Image visualBorder = null, UILabelFieldProperties labelFieldProperties = null, Image icon = null, bool isSelectable = false, bool isSelected = false, UIFieldProperties selectedProperty = null, Action onFinished = null)
	{
		Color startColor = Color.white;
		if (visualArea != null)
		{
			startColor = visualArea.color;
		}
		Color startBorderColor = Color.black;
		if (visualBorder != null)
		{
			startBorderColor = visualBorder.color;
		}
		float startCanvasOpacity = (property.useCanvasGroupOpacity ? anchor.GetComponent<CanvasGroup>().alpha : 1f);
		Vector3 startPoistion = anchor.anchoredPosition;
		Vector3 startSize = anchor.localScale;
		Color startLabelColor = Color.white;
		if (labelFieldProperties != null && property.overideLabelColor)
		{
			startLabelColor = labelFieldProperties.color;
		}
		Color startIconColor = Color.white;
		if (icon != null && property.overideIconColor)
		{
			startIconColor = icon.color;
		}
		float alpha = 0f;
		while (true)
		{
			alpha += 1f / fadeTime * Time.unscaledDeltaTime;
			if (alpha >= 1f)
			{
				break;
			}
			UIFieldInvokePoint[] invokePoints = property.invokePoints;
			foreach (UIFieldInvokePoint uIFieldInvokePoint in invokePoints)
			{
				if (alpha >= uIFieldInvokePoint.time && !uIFieldInvokePoint.fired)
				{
					uIFieldInvokePoint.fired = true;
					uIFieldInvokePoint.OnKeyframeEvent.Invoke();
				}
			}
			if (visualArea != null)
			{
				if (isSelectable)
				{
					if (isSelected)
					{
						visualArea.color = Color.Lerp(selectedProperty.color, startColor, curve.Evaluate(alpha));
					}
					else
					{
						visualArea.color = Color.Lerp(startColor, property.color, curve.Evaluate(alpha));
					}
				}
				else
				{
					visualArea.color = Color.Lerp(startColor, property.color, curve.Evaluate(alpha));
				}
			}
			if (visualBorder != null)
			{
				if (isSelectable)
				{
					if (isSelected)
					{
						visualBorder.color = Color.Lerp(selectedProperty.borderColor, startBorderColor, curve.Evaluate(alpha));
					}
					else
					{
						visualBorder.color = Color.Lerp(startBorderColor, property.borderColor, curve.Evaluate(alpha));
					}
				}
				else
				{
					visualBorder.color = Color.Lerp(startBorderColor, property.borderColor, curve.Evaluate(alpha));
				}
			}
			if (property.useCanvasGroupOpacity)
			{
				anchor.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(startCanvasOpacity, property.opacity, curve.Evaluate(alpha));
			}
			if (property.usePosition)
			{
				anchor.anchoredPosition = Vector3.Lerp(startPoistion, property.position, curve.Evaluate(alpha));
			}
			if (property.useSize)
			{
				anchor.localScale = Vector3.Lerp(startSize, property.size, curve.Evaluate(alpha));
			}
			if (labelFieldProperties != null && property.overideLabelColor)
			{
				if (isSelectable)
				{
					if (isSelected)
					{
						visualBorder.color = Color.Lerp(selectedProperty.labelColor, startLabelColor, curve.Evaluate(alpha));
					}
					else
					{
						labelFieldProperties.color = Color.Lerp(startLabelColor, property.labelColor, curve.Evaluate(alpha));
					}
				}
				else
				{
					labelFieldProperties.color = Color.Lerp(startLabelColor, property.labelColor, curve.Evaluate(alpha));
				}
			}
			if (icon != null && property.overideIconColor)
			{
				if (isSelectable)
				{
					if (isSelected)
					{
						visualBorder.color = Color.Lerp(selectedProperty.iconColor, startIconColor, curve.Evaluate(alpha));
					}
					else
					{
						startIconColor = Color.Lerp(startIconColor, property.iconColor, curve.Evaluate(alpha));
					}
				}
				else
				{
					startIconColor = Color.Lerp(startIconColor, property.iconColor, curve.Evaluate(alpha));
				}
			}
			yield return null;
		}
		property.ResetInvokePoints();
	}

	public static IEnumerator PingPong(UIFieldProperties property, RectTransform anchor, Image visualArea, AnimationCurve curve, float fadeTime, Image visualBorder = null, UILabelFieldProperties labelFieldProperties = null, Image icon = null, bool isSelectable = false)
	{
		Color startColor = visualArea.color;
		Color startBorderColor = Color.black;
		if (visualBorder != null)
		{
			startBorderColor = visualBorder.color;
		}
		float startCanvasOpacity = (property.useCanvasGroupOpacity ? anchor.GetComponent<CanvasGroup>().alpha : 1f);
		Vector3 startPoistion = anchor.anchoredPosition;
		Vector3 startSize = anchor.localScale;
		Color startLabelColor = Color.white;
		if (labelFieldProperties != null && property.overideLabelColor)
		{
			startLabelColor = labelFieldProperties.color;
		}
		Color startIconColor = Color.white;
		if (icon != null && property.overideIconColor)
		{
			startIconColor = icon.color;
		}
		float alpha = 0f;
		bool flipFlop = false;
		while (true)
		{
			alpha = ((!flipFlop) ? (alpha - 1f / fadeTime * Time.unscaledDeltaTime) : (alpha + 1f / fadeTime * Time.unscaledDeltaTime));
			if (alpha >= 1f)
			{
				alpha = 1f;
				flipFlop = false;
				property.ResetInvokePoints();
			}
			else if (alpha <= 0f)
			{
				alpha = 0f;
				flipFlop = true;
				property.ResetInvokePoints();
			}
			UIFieldInvokePoint[] invokePoints = property.invokePoints;
			foreach (UIFieldInvokePoint uIFieldInvokePoint in invokePoints)
			{
				if (alpha >= uIFieldInvokePoint.time && !uIFieldInvokePoint.fired)
				{
					uIFieldInvokePoint.fired = true;
					uIFieldInvokePoint.OnKeyframeEvent.Invoke();
				}
			}
			visualArea.color = Color.Lerp(startColor, property.color, curve.Evaluate(alpha));
			if (visualBorder != null)
			{
				visualBorder.color = Color.Lerp(startBorderColor, property.borderColor, curve.Evaluate(alpha));
			}
			if (property.useCanvasGroupOpacity)
			{
				anchor.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(startCanvasOpacity, property.opacity, curve.Evaluate(alpha));
			}
			if (property.usePosition)
			{
				anchor.anchoredPosition = Vector3.Lerp(startPoistion, property.position, curve.Evaluate(alpha));
			}
			if (property.useSize)
			{
				anchor.localScale = Vector3.Lerp(startSize, property.size, curve.Evaluate(alpha));
			}
			if (labelFieldProperties != null && property.overideLabelColor)
			{
				labelFieldProperties.color = Color.Lerp(startLabelColor, property.labelColor, curve.Evaluate(alpha));
			}
			if (icon != null && property.overideIconColor)
			{
				startIconColor = Color.Lerp(startIconColor, property.iconColor, curve.Evaluate(alpha));
			}
			yield return null;
		}
	}

	public static IEnumerator Scaler(Vector3 start, Vector3 end, Transform area, AnimationCurve curve = null, float fadeTime = 0.1f, bool hideMode = false)
	{
		if (hideMode)
		{
			area.gameObject.SetActive(value: true);
		}
		float alpha = 0f;
		while (true)
		{
			alpha += 1f / fadeTime * Time.unscaledDeltaTime;
			if (alpha >= 1f)
			{
				break;
			}
			area.localScale = Vector3.Lerp(start, end, curve.Evaluate(alpha));
			yield return null;
		}
		alpha = 1f;
		area.localScale = Vector3.Lerp(start, end, curve.Evaluate(alpha));
		if (hideMode)
		{
			area.gameObject.SetActive(value: false);
		}
	}

	public static IEnumerator AnimateContent(UIFieldProperties property, RectTransform anchor, AnimationCurve curve, float fadeTime, CanvasGroup canvasGroup = null, Image visualArea = null, Image visualBorder = null, UnityEvent trigger = null)
	{
		Color startColor = Color.black;
		if (visualArea != null)
		{
			startColor = visualArea.color;
		}
		Color startBorderColor = Color.black;
		if (visualBorder != null)
		{
			startBorderColor = visualBorder.color;
		}
		AnimationCurve activeCurve = (property.useCustomCurve ? property.animationCurve : curve);
		float startCanvasOpacity = (property.useCanvasGroupOpacity ? canvasGroup.alpha : 1f);
		Vector3 startPoistion = anchor.anchoredPosition;
		Vector3 startSize = anchor.localScale;
		float alpha = 0f;
		bool running = true;
		while (running)
		{
			alpha += 1f / fadeTime * Time.unscaledDeltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			UIFieldInvokePoint[] invokePoints = property.invokePoints;
			foreach (UIFieldInvokePoint uIFieldInvokePoint in invokePoints)
			{
				if (alpha >= uIFieldInvokePoint.time && !uIFieldInvokePoint.fired)
				{
					uIFieldInvokePoint.fired = true;
					uIFieldInvokePoint.OnKeyframeEvent.Invoke();
				}
			}
			if (visualArea != null)
			{
				visualArea.color = Color.Lerp(startColor, property.color, activeCurve.Evaluate(alpha));
			}
			if (visualBorder != null)
			{
				visualBorder.color = Color.Lerp(startBorderColor, property.borderColor, activeCurve.Evaluate(alpha));
			}
			if (property.useCanvasGroupOpacity)
			{
				float alpha2 = Mathf.Lerp(startCanvasOpacity, property.opacity, activeCurve.Evaluate(alpha));
				canvasGroup.alpha = alpha2;
			}
			if (property.usePosition)
			{
				anchor.anchoredPosition = Vector3.Lerp(startPoistion, property.position, activeCurve.Evaluate(alpha));
			}
			if (property.useSize)
			{
				anchor.localScale = Vector3.Lerp(startSize, property.size, activeCurve.Evaluate(alpha));
			}
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				trigger?.Invoke();
				property.ResetInvokePoints();
				yield return null;
			}
			yield return null;
		}
	}

	public static void ApplyState(UIFieldProperties property, RectTransform anchor, AnimationCurve curve, float fadeTime, CanvasGroup canvasGroup = null, Image visualArea = null, Image visualBorder = null)
	{
		if (visualArea != null)
		{
			visualArea.color = property.color;
		}
		if (visualBorder != null)
		{
			visualBorder.color = property.borderColor;
		}
		if (property.useCanvasGroupOpacity)
		{
			canvasGroup.alpha = property.opacity;
		}
		if (property.usePosition)
		{
			anchor.anchoredPosition = property.position;
		}
		if (property.useSize)
		{
			anchor.localScale = property.size;
		}
	}
}
