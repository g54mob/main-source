using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweenerManager : MonoBehaviour
{
	private Dictionary<string, Coroutine> que = new Dictionary<string, Coroutine>();

	[SerializeField]
	private float defaultDuration = 0.5f;

	[SerializeField]
	private AnimationCurve defaultLinearCurve;

	[SerializeField]
	private AnimationCurve defaultEasingCurve;

	[SerializeField]
	private int queCount;

	private static TweenerManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
		UnityEngine.Object.DontDestroyOnLoad(instance);
	}

	public static void StopTweenWithContainingKey(string key)
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Coroutine> item in instance.que)
		{
			if (item.Key.Contains(key))
			{
				if (item.Value != null)
				{
					instance.StopCoroutine(item.Value);
				}
				list.Add(item.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			instance.que.Remove(list[i]);
		}
		list.Clear();
	}

	private static string GenerateKeyID(string key)
	{
		if (instance.que.ContainsKey(key))
		{
			key = key + "_" + UnityEngine.Random.Range(0, int.MaxValue);
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		return key;
	}

	private static Action Cleanup(string key)
	{
		return delegate
		{
			instance.StopCoroutine(instance.que.GetValueOrDefault(key));
			instance.que.Remove(key);
			instance.queCount = instance.que.Count;
		};
	}

	public static float GetDefaultDuration()
	{
		return instance.defaultDuration;
	}

	public static AnimationCurve GetDefaultEaseCurve()
	{
		return instance.defaultEasingCurve;
	}

	public static AnimationCurve GetDefaultLinearCurve()
	{
		return instance.defaultLinearCurve;
	}

	public static void Tween(string key, Transform value, Transform source, Transform target, float duration, AnimationCurve curve = null, Action executeOnFinish = null)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, 4);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Action onFinsihed = delegate
		{
			if (executeOnFinish != null)
			{
				executeOnFinish();
			}
			instance.StopCoroutine(instance.que.GetValueOrDefault(key));
			instance.que.Remove(key);
			instance.queCount = instance.que.Count;
		};
		Coroutine value2 = instance.StartCoroutine(LerpTransform(value, source, target, duration, curve, onFinsihed));
		instance.que.Add(key, value2);
		instance.queCount = instance.que.Count;
	}

	public static void TweenUI(string key, UIFieldProperties value, RectTransform anchor, Image visualArea, AnimationCurve curve = null, float fadeTime = 0.5f, Image visualBorder = null, UILabelFieldProperties labelFieldProperties = null, Image icon = null, bool isSelectable = false, bool isSelected = false, UIFieldProperties selectionProperties = null, Action executeOnFinished = null)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, 4);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Action onFinished = delegate
		{
			if (executeOnFinished != null)
			{
				executeOnFinished();
			}
			instance.StopCoroutine(instance.que.GetValueOrDefault(key));
			instance.que.Remove(key);
			instance.queCount = instance.que.Count;
		};
		Coroutine value2 = instance.StartCoroutine(UIFader(value, anchor, visualArea, curve, fadeTime, visualBorder, labelFieldProperties, icon, isSelectable, isSelected, selectionProperties, onFinished));
		instance.que.Add(key, value2);
		instance.queCount = instance.que.Count;
	}

	public static void TweenUIPingPong(string key, UIFieldProperties property, RectTransform anchor, Image visualArea, AnimationCurve curve, float fadeTime, Image visualBorder = null, UILabelFieldProperties labelFieldProperties = null, Image icon = null, bool isSelectable = false, Action executeOnFinished = null)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, 4);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Action onFinished = delegate
		{
			if (executeOnFinished != null)
			{
				executeOnFinished();
			}
			instance.StopCoroutine(instance.que.GetValueOrDefault(key));
			instance.que.Remove(key);
			instance.queCount = instance.que.Count;
		};
		Coroutine value = instance.StartCoroutine(UIPingPong(property, anchor, visualArea, curve, fadeTime, visualBorder, labelFieldProperties, icon, isSelectable, onFinished));
		instance.que.Add(key, value);
		instance.queCount = instance.que.Count;
	}

	public static void TweenWithScale(string key, Transform value, Transform source, Transform target, float scale, float duration, AnimationCurve curve = null, Vector3 preferEuler = default(Vector3))
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, 4);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Action onFinsihed = delegate
		{
			instance.StopCoroutine(instance.que.GetValueOrDefault(key));
			instance.que.Remove(key);
			instance.queCount = instance.que.Count;
		};
		if (preferEuler != Vector3.zero)
		{
			target.localRotation = Quaternion.Euler(preferEuler);
			Coroutine value2 = instance.StartCoroutine(LerpWithTargetScale(value, source, target, scale, duration, curve, onFinsihed));
			instance.que.Add(key, value2);
		}
		else
		{
			Coroutine value3 = instance.StartCoroutine(LerpWithTargetScale(value, source, target, scale, duration, curve, onFinsihed));
			instance.que.Add(key, value3);
		}
		instance.queCount = instance.que.Count;
	}

	public static void TweenPosition(string key, Transform value, Vector3 start, Vector3 end, float duration, AnimationCurve curve = null, Space space = Space.World, Action onFinished = null)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, 4);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Action onFinsihed = delegate
		{
			if (onFinished != null)
			{
				onFinished();
			}
			instance.StopCoroutine(instance.que.GetValueOrDefault(key));
			instance.que.Remove(key);
			instance.queCount = instance.que.Count;
		};
		Coroutine value2 = instance.StartCoroutine(LerpPosition(value, start, end, duration, curve, onFinsihed, space));
		instance.que.Add(key, value2);
		instance.queCount = instance.que.Count;
	}

	public static void TweenRotation(string key, Transform value, Quaternion start, Quaternion end, float duration, AnimationCurve curve = null, Space space = Space.World, Action onFinished = null)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, 4);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Action onFinsihed = delegate
		{
			if (onFinished != null)
			{
				onFinished();
			}
			instance.StopCoroutine(instance.que.GetValueOrDefault(key));
			instance.que.Remove(key);
			instance.queCount = instance.que.Count;
		};
		Coroutine value2 = instance.StartCoroutine(LerpRotation(value, start, end, duration, curve, onFinsihed, space));
		instance.que.Add(key, value2);
		instance.queCount = instance.que.Count;
	}

	public static void TweenScale(string key, Transform value, Vector3 start, Vector3 end, float duration, AnimationCurve curve = null)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, 4);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Action onFinsihed = delegate
		{
			instance.StopCoroutine(instance.que.GetValueOrDefault(key));
			instance.que.Remove(key);
			instance.queCount = instance.que.Count;
		};
		Coroutine value2 = instance.StartCoroutine(LerpScale(value, start, end, duration, curve, onFinsihed));
		instance.que.Add(key, value2);
		instance.queCount = instance.que.Count;
	}

	public static void TweenTimeAction(string key, float duration, Action action)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, int.MaxValue);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		if (action == null)
		{
			Debug.LogError("WaitTime Action WILL BE Null");
		}
		Coroutine value = instance.StartCoroutine(instance.WaitTime(duration, action));
		instance.que.Add(key, value);
		instance.queCount = instance.que.Count;
	}

	public static void TweenFloat(string key, out float value, float start, float target, float duration, AnimationCurve curve)
	{
		value = start;
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, int.MaxValue);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Action onFinsihed = delegate
		{
			instance.StopCoroutine(instance.que.GetValueOrDefault(key));
			instance.que.Remove(key);
			instance.queCount = instance.que.Count;
		};
		Coroutine value2 = instance.StartCoroutine(LerpFloat(value, start, target, duration, curve, onFinsihed));
		instance.que.Add(key, value2);
		instance.queCount = instance.que.Count;
	}

	public static void TweenBlendShape(string key, SkinnedMeshRenderer value, int blendShapeIndex, float start, float target, float duration, AnimationCurve curve, Action action)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, int.MaxValue);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Coroutine value2 = instance.StartCoroutine(LerpBlendShape(value, blendShapeIndex, start, target, duration, curve, action));
		instance.que.Add(key, value2);
		instance.queCount = instance.que.Count;
	}

	public static void TweenMaterialColor(string key, Material value, string shaderProperty, Color start, Color target, float duration, AnimationCurve curve, Action action)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, int.MaxValue);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Coroutine value2 = instance.StartCoroutine(LerpMaterialColor(value, shaderProperty, start, target, duration, curve, action));
		instance.que.Add(key, value2);
		instance.queCount = instance.que.Count;
	}

	public static void TweenAudioSourceFade(string key, AudioSource value, float start, float target, float duration, AnimationCurve curve, Action action)
	{
		if (instance.que.ContainsKey(key))
		{
			int num = UnityEngine.Random.Range(0, int.MaxValue);
			key = key + "_" + num;
			if (instance.que.ContainsKey(key))
			{
				key += UnityEngine.Random.Range(0, int.MaxValue);
			}
		}
		Coroutine value2 = instance.StartCoroutine(LerpAudioSource(value, start, target, duration, curve, action));
		instance.que.Add(key, value2);
		instance.queCount = instance.que.Count;
	}

	public static void TweenText(string key, string dialog, TMP_Text label, float textAnimationSpeed = 0.1f, Action onFinished = null)
	{
		key = GenerateKeyID(key);
		Action onFinsihed = delegate
		{
			if (onFinished != null)
			{
				onFinished();
			}
			Cleanup(key);
		};
		Coroutine value = instance.StartCoroutine(TextAnimation(dialog, label, textAnimationSpeed, onFinsihed));
		instance.que.Add(key, value);
		instance.queCount = instance.que.Count;
	}

	public static IEnumerator LerpTransform(Transform value, Transform source, Transform target, float duration = 1f, AnimationCurve curve = null, Action onFinsihed = null)
	{
		Vector3 startPos = source.position;
		Quaternion startRot = source.rotation;
		float alpha = 0f;
		bool running = true;
		while (running)
		{
			alpha += 1f / duration * Time.deltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float t = curve?.Evaluate(alpha) ?? alpha;
			value.position = Vector3.Lerp(startPos, target.position, t);
			value.rotation = Quaternion.Lerp(startRot, target.rotation, t);
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinsihed();
	}

	public static IEnumerator LerpPosition(Transform value, Vector3 start, Vector3 end, float duration = 1f, AnimationCurve curve = null, Action onFinsihed = null, Space space = Space.World)
	{
		float alpha = 0f;
		bool running = true;
		while (running)
		{
			alpha += 1f / duration * Time.deltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float t = curve?.Evaluate(alpha) ?? alpha;
			if (space == Space.World)
			{
				value.position = Vector3.Lerp(start, end, t);
			}
			else
			{
				value.localPosition = Vector3.Lerp(start, end, t);
			}
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinsihed();
	}

	public static IEnumerator LerpRotation(Transform value, Quaternion start, Quaternion end, float duration = 1f, AnimationCurve curve = null, Action onFinsihed = null, Space space = Space.World)
	{
		float alpha = 0f;
		bool running = true;
		Quaternion startRot = start;
		switch (space)
		{
		case Space.World:
			startRot = value.rotation;
			break;
		case Space.Self:
			startRot = value.localRotation;
			break;
		}
		while (running)
		{
			alpha += 1f / duration * Time.deltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float evaluatedAlpha = curve?.Evaluate(alpha) ?? alpha;
			if (value == null)
			{
				running = false;
				yield return null;
			}
			switch (space)
			{
			case Space.World:
				value.rotation = Quaternion.Lerp(startRot, end, evaluatedAlpha);
				break;
			case Space.Self:
				value.localRotation = Quaternion.Lerp(startRot, end, evaluatedAlpha);
				break;
			}
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinsihed();
	}

	public static IEnumerator LerpScale(Transform value, Vector3 start, Vector3 end, float duration = 1f, AnimationCurve curve = null, Action onFinsihed = null)
	{
		float alpha = 0f;
		bool running = true;
		while (running)
		{
			alpha += 1f / duration * Time.deltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float t = curve?.Evaluate(alpha) ?? alpha;
			value.localScale = Vector3.Lerp(start, end, t);
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinsihed();
	}

	public static IEnumerator LerpFloat(float value, float start, float end, float duration = 1f, AnimationCurve curve = null, Action onFinsihed = null)
	{
		float alpha = 0f;
		bool running = true;
		while (running)
		{
			alpha += 1f / duration * Time.deltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float t = curve?.Evaluate(alpha) ?? alpha;
			value = Mathf.Lerp(start, end, t);
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinsihed?.Invoke();
	}

	public static IEnumerator LerpBlendShape(SkinnedMeshRenderer value, int blendShapeIndex, float start, float end, float duration = 1f, AnimationCurve curve = null, Action onFinsihed = null)
	{
		float alpha = 0f;
		bool running = true;
		while (running)
		{
			alpha += 1f / duration * Time.deltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float t = curve?.Evaluate(alpha) ?? alpha;
			value.SetBlendShapeWeight(blendShapeIndex, Mathf.Lerp(start, end, t));
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinsihed?.Invoke();
	}

	public static IEnumerator LerpMaterialColor(Material value, string key, Color start, Color end, float duration = 1f, AnimationCurve curve = null, Action onFinsihed = null)
	{
		float alpha = 0f;
		bool running = true;
		while (running)
		{
			alpha += 1f / duration * Time.deltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float t = curve?.Evaluate(alpha) ?? alpha;
			value.SetColor(key, Color.Lerp(start, end, t));
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinsihed?.Invoke();
	}

	public static IEnumerator LerpAudioSource(AudioSource value, float start, float end, float duration = 1f, AnimationCurve curve = null, Action onFinsihed = null)
	{
		float alpha = 0f;
		bool running = true;
		while (running)
		{
			alpha += 1f / duration * Time.deltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float t = curve?.Evaluate(alpha) ?? alpha;
			if (value != null)
			{
				value.volume = Mathf.Lerp(start, end, t);
			}
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinsihed?.Invoke();
	}

	public static IEnumerator LerpWithTargetScale(Transform value, Transform source, Transform target, float scale, float duration = 1f, AnimationCurve curve = null, Action onFinsihed = null)
	{
		Vector3 startPos = source.position;
		Quaternion startRot = source.rotation;
		Vector3 startScale = source.localScale;
		Vector3 targetScale = new Vector3(scale, scale, scale);
		float alpha = 0f;
		bool running = true;
		while (running)
		{
			alpha += 1f / duration * Time.deltaTime;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float t = curve?.Evaluate(alpha) ?? alpha;
			value.position = Vector3.Lerp(startPos, target.position, t);
			value.rotation = Quaternion.Lerp(startRot, target.rotation, t);
			value.localScale = Vector3.Lerp(startScale, targetScale, t);
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinsihed();
	}

	public static IEnumerator TextAnimation(string dialog, TMP_Text label, float textAnimationSpeed = 1f, Action onFinsihed = null)
	{
		yield return new WaitForSeconds(textAnimationSpeed);
		string command = "";
		int index = 0;
		while (label.text != dialog && index < dialog.Length)
		{
			if (dialog[index] == '<')
			{
				for (; dialog[index] != '>'; index++)
				{
					command += dialog[index];
				}
				label.text += command;
				command = "";
			}
			label.text += dialog[index];
			index++;
			yield return new WaitForSeconds(textAnimationSpeed);
		}
		onFinsihed?.Invoke();
	}

	private IEnumerator WaitTime(float duration, Action execute)
	{
		yield return new WaitForSeconds(duration);
		if (execute == null)
		{
			Debug.LogError("WaitTimeExecution Is Null");
		}
		execute();
	}

	public static IEnumerator UIFader(UIFieldProperties property, RectTransform anchor, Image visualArea, AnimationCurve curve, float fadeTime, Image visualBorder = null, UILabelFieldProperties labelFieldProperties = null, Image icon = null, bool isSelectable = false, bool isSelected = false, UIFieldProperties selectedProperty = null, Action onFinished = null)
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
		bool running = true;
		while (running)
		{
			alpha += 1f / fadeTime * Time.unscaledDeltaTime;
			if (alpha >= 1f)
			{
				alpha = 1f;
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
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinished?.Invoke();
	}

	public static IEnumerator UIPingPong(UIFieldProperties property, RectTransform anchor, Image visualArea, AnimationCurve curve, float fadeTime, Image visualBorder = null, UILabelFieldProperties labelFieldProperties = null, Image icon = null, bool isSelectable = false, Action onFinished = null)
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
		bool running = true;
		while (running)
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
			if (alpha >= 1f)
			{
				alpha = 1f;
				running = false;
				yield return null;
			}
			yield return null;
		}
		onFinished?.Invoke();
	}
}
