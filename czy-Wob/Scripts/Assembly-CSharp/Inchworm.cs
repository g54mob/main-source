using System;
using System.Collections.Generic;
using UnityEngine;

public class Inchworm : MonoBehaviour
{
	public enum EaseStyle
	{
		QuadraticIn = 1,
		QuadraticOut = 2,
		Sin = 3,
		Linear = 4,
		ElasticOut = 5,
		ElasticIn = 6,
		OutBack = 7,
		InBack = 8,
		CircIn = 9,
		CircOut = 10,
		QuartIn = 11,
		QuartOut = 12,
		EaseOutBounce = 13,
		BouncePast = 14
	}

	public enum EaseType
	{
		Position = 1,
		Scale = 2,
		BatchScale = 3
	}

	public enum EasePriority
	{
		Normal = 1,
		Critical = 2
	}

	public delegate float GetEaseValue(float easeTime, float start, float totalChange, float duration);

	public delegate void EaseCallback();

	private List<Segment> segments = new List<Segment>();

	private float deltaTime;

	private void Update()
	{
		deltaTime = Time.unscaledDeltaTime;
		for (int num = segments.Count - 1; num >= 0; num--)
		{
			Segment segment = segments[num];
			if (segment.easeObj == null && segment.easeType != EaseType.BatchScale)
			{
				segments.RemoveAt(num);
			}
			else if (segment.isEasing)
			{
				Ease(ref segment, deltaTime);
			}
		}
	}

	public void CancelAllEases(EaseCallback callback = null, EasePriority highestCancelPriority = EasePriority.Normal)
	{
		List<Segment> list = new List<Segment>();
		Segment[] array = new Segment[segments.Count];
		segments.CopyTo(array);
		for (int i = 0; i < array.Length; i++)
		{
			Segment segment = array[i];
			if (segment.priority <= highestCancelPriority)
			{
				CancelEase(ref segment);
			}
			else
			{
				list.Add(segment);
			}
		}
		segments.Clear();
		segments = list;
		callback?.Invoke();
	}

	public void CancelAndFinishEase(ref Segment segment, bool callCallback = false)
	{
		if (segment == null)
		{
			Debug.LogError("Invalid call to CancelAndFinishEase.");
			return;
		}
		segment.isEasing = false;
		if (!callCallback)
		{
			segment.easeCallback = null;
		}
		if (segment.easeObj == null && segment.easeType != EaseType.BatchScale)
		{
			segments.Remove(segment);
			segment = null;
		}
		else
		{
			FinishEase(ref segment);
		}
	}

	public Segment RequestEaseToScale(GameObject objectToScale, Vector3 targetScale, float scaleTime, EaseStyle easeStyle = EaseStyle.QuadraticOut, EaseCallback callback = null, EasePriority priority = EasePriority.Normal, float startDelay = 0f, bool invisibleBeforeStart = false)
	{
		List<GameObject> objectsToEase = new List<GameObject> { objectToScale };
		return RequestEase(objectsToEase, targetScale, scaleTime, adjustStartingPos: false, easeStyle, EaseType.Scale, callback, priority, keepSameParent: false, startDelay, invisibleBeforeStart);
	}

	public Segment RequestEase(GameObject objectToEase, Vector3 easeVector, float duration, bool adjustStartingPos = true, EaseStyle easeStyle = EaseStyle.QuadraticOut, EaseType easeType = EaseType.Position, EaseCallback callback = null, EasePriority priority = EasePriority.Normal, bool keepSameParent = false, float startDelay = 0f, bool invisibleBeforeStart = false, bool useLocalPosition = false)
	{
		List<GameObject> objectsToEase = new List<GameObject> { objectToEase };
		return RequestEase(objectsToEase, easeVector, duration, adjustStartingPos, easeStyle, easeType, callback, priority, keepSameParent, startDelay, invisibleBeforeStart, useLocalPosition);
	}

	public Segment RequestEase(List<GameObject> objectsToEase, Vector3 easeVector, float duration, bool adjustStartingPos = true, EaseStyle easeStyle = EaseStyle.QuadraticOut, EaseType easeType = EaseType.Position, EaseCallback callback = null, EasePriority priority = EasePriority.Normal, bool keepSameParent = false, float startDelay = 0f, bool invisibleBeforeStart = false, bool useLocalPosition = false)
	{
		Segment segment = new Segment();
		segment.easeType = easeType;
		segment.priority = priority;
		segment.startDelay = startDelay;
		segment.useLocalPosition = useLocalPosition;
		if (easeType != EaseType.BatchScale)
		{
			segment.easeObj = new GameObject("InchwormObject");
		}
		segment.originalEaseObjs = new List<GameObject>();
		segment.originalParents = new List<Transform>();
		switch (easeType)
		{
		case EaseType.Position:
			segment.currentEaseStart = -easeVector;
			segment.easeObj.transform.position = segment.currentEaseStart;
			segment.currentEaseEnd = Vector3.zero;
			if (keepSameParent)
			{
				segment.easeObj.transform.SetParent(objectsToEase[0].transform.parent);
			}
			if (useLocalPosition)
			{
				segment.easeObj.transform.localPosition = segment.currentEaseStart;
			}
			break;
		case EaseType.Scale:
			segment.currentEaseStart = objectsToEase[0].transform.localScale;
			segment.easeObj.transform.SetParent(objectsToEase[0].transform.parent);
			segment.easeObj.transform.position = objectsToEase[0].transform.position;
			segment.easeObj.transform.rotation = objectsToEase[0].transform.rotation;
			segment.easeObj.transform.localScale = segment.currentEaseStart;
			segment.currentEaseEnd = easeVector;
			break;
		case EaseType.BatchScale:
			segment.batchEaseObjs = new List<GameObject>();
			segment.currentEaseStart = objectsToEase[0].transform.localScale;
			segment.currentEaseEnd = easeVector;
			break;
		}
		segment.isEasing = true;
		segment.originalEaseObjs = objectsToEase;
		foreach (GameObject item in objectsToEase)
		{
			segment.originalParents.Add(item.transform.parent);
			switch (easeType)
			{
			case EaseType.Position:
				if (adjustStartingPos && !useLocalPosition)
				{
					item.transform.position -= easeVector;
				}
				item.transform.SetParent(segment.easeObj.transform);
				if (adjustStartingPos && useLocalPosition)
				{
					item.transform.localPosition -= easeVector;
				}
				break;
			case EaseType.Scale:
				item.transform.SetParent(segment.easeObj.transform);
				item.transform.localScale = Vector3.one;
				item.transform.localPosition = Vector3.zero;
				break;
			case EaseType.BatchScale:
			{
				GameObject gameObject = new GameObject("InchwormObject_BatchScale");
				gameObject.transform.position = item.transform.position;
				gameObject.transform.localScale = segment.currentEaseStart;
				item.transform.SetParent(gameObject.transform);
				item.transform.localScale = Vector3.one;
				segment.batchEaseObjs.Add(gameObject);
				break;
			}
			}
			if (invisibleBeforeStart && startDelay > 0f && easeType != EaseType.BatchScale)
			{
				segment.easeObj.SetActive(value: false);
			}
		}
		AssignEasingFunction(easeStyle, ref segment);
		segment.easeCallback = callback;
		segment.currentEaseTime = 0f;
		segment.currentEaseDuration = duration;
		segment.easeCallback = callback;
		segments.Add(segment);
		return segment;
	}

	private void AssignEasingFunction(EaseStyle easeStyle, ref Segment segment)
	{
		switch (easeStyle)
		{
		case EaseStyle.QuadraticIn:
			segment.getEaseValue = GetQuadraticInValue;
			break;
		case EaseStyle.QuadraticOut:
			segment.getEaseValue = GetQuadraticOutValue;
			break;
		case EaseStyle.Sin:
			segment.getEaseValue = GetSinusoidalValue;
			break;
		case EaseStyle.Linear:
			segment.getEaseValue = GetLinearEasingValue;
			break;
		case EaseStyle.ElasticOut:
			segment.getEaseValue = GetEaseOutElasticValue;
			break;
		case EaseStyle.ElasticIn:
			segment.getEaseValue = GetEaseInElasticValue;
			break;
		case EaseStyle.OutBack:
			segment.getEaseValue = GetEaseOutBackValue;
			break;
		case EaseStyle.InBack:
			segment.getEaseValue = GetEaseInBackValue;
			break;
		case EaseStyle.CircIn:
			segment.getEaseValue = GetEaseInCircValue;
			break;
		case EaseStyle.CircOut:
			segment.getEaseValue = GetEaseOutCircValue;
			break;
		case EaseStyle.QuartIn:
			segment.getEaseValue = GetEaseInQuartValue;
			break;
		case EaseStyle.QuartOut:
			segment.getEaseValue = GetEaseOutQuartValue;
			break;
		case EaseStyle.EaseOutBounce:
			segment.getEaseValue = GetEaseOutBounceValue;
			break;
		case EaseStyle.BouncePast:
			segment.getEaseValue = GetBouncePastValue;
			break;
		}
	}

	private void Ease(ref Segment segment, float deltaTime)
	{
		segment.currentEaseTime += deltaTime;
		float num = segment.currentEaseTime - segment.startDelay;
		if (num > segment.currentEaseDuration)
		{
			num = segment.currentEaseDuration;
		}
		float x = segment.getEaseValue(num, segment.currentEaseStart.x, segment.currentEaseStart.x - segment.currentEaseEnd.x, segment.currentEaseDuration);
		float y = segment.getEaseValue(num, segment.currentEaseStart.y, segment.currentEaseStart.y - segment.currentEaseEnd.y, segment.currentEaseDuration);
		float z = segment.getEaseValue(num, segment.currentEaseStart.z, segment.currentEaseStart.z - segment.currentEaseEnd.z, segment.currentEaseDuration);
		if (!segment.easeObj.activeSelf && num > 0f)
		{
			segment.easeObj.SetActive(value: true);
		}
		if (segment.easeType == EaseType.Position)
		{
			if (segment.useLocalPosition)
			{
				segment.easeObj.transform.localPosition = new Vector3(x, y, z);
			}
			else
			{
				segment.easeObj.transform.position = new Vector3(x, y, z);
			}
		}
		else if (segment.easeType == EaseType.Scale)
		{
			segment.easeObj.transform.localScale = new Vector3(x, y, z);
		}
		else if (segment.easeType == EaseType.BatchScale)
		{
			Vector3 localScale = new Vector3(x, y, z);
			for (int i = 0; i < segment.batchEaseObjs.Count; i++)
			{
				segment.batchEaseObjs[i].transform.localScale = localScale;
			}
		}
		if (num >= segment.currentEaseDuration)
		{
			FinishEase(ref segment);
		}
	}

	public void CancelEase(ref Segment segment, bool restoreParents = true)
	{
		try
		{
			if (restoreParents)
			{
				for (int i = 0; i < segment.originalEaseObjs.Count; i++)
				{
					segment.originalEaseObjs[i].transform.SetParent(segment.originalParents[i]);
				}
			}
		}
		finally
		{
			segment.originalEaseObjs.Clear();
			segment.isEasing = false;
			UnityEngine.Object.Destroy(segment.easeObj);
			segments.Remove(segment);
		}
	}

	private void FinishEase(ref Segment segment)
	{
		if (segment.easeType == EaseType.Position)
		{
			if (segment.useLocalPosition)
			{
				segment.easeObj.transform.localPosition = segment.currentEaseEnd;
			}
			else
			{
				segment.easeObj.transform.position = segment.currentEaseEnd;
			}
		}
		else if (segment.easeType == EaseType.Scale)
		{
			segment.easeObj.transform.localScale = segment.currentEaseEnd;
		}
		else if (segment.easeType == EaseType.BatchScale)
		{
			for (int i = 0; i < segment.batchEaseObjs.Count; i++)
			{
				segment.batchEaseObjs[i].transform.localScale = segment.currentEaseEnd;
			}
		}
		for (int j = 0; j < segment.originalEaseObjs.Count; j++)
		{
			GameObject gameObject = segment.originalEaseObjs[j];
			if (gameObject == null)
			{
				segment.easeCallback = null;
				continue;
			}
			gameObject.transform.SetParent(segment.originalParents[j]);
			if (segment.easeType == EaseType.Scale || segment.easeType == EaseType.BatchScale)
			{
				gameObject.transform.localScale = segment.currentEaseEnd;
			}
		}
		segment.originalEaseObjs.Clear();
		if (segment.easeType == EaseType.BatchScale)
		{
			GameObject[] array = new GameObject[segment.batchEaseObjs.Count];
			segment.batchEaseObjs.CopyTo(array);
			for (int k = 0; k < array.Length; k++)
			{
				UnityEngine.Object.Destroy(segment.batchEaseObjs[k]);
			}
			segment.batchEaseObjs.Clear();
		}
		segment.isEasing = false;
		if (segment.easeCallback != null)
		{
			segment.easeCallback();
		}
		UnityEngine.Object.Destroy(segment.easeObj);
		segments.Remove(segment);
		segment = null;
	}

	public static float GetLinearEasingValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime < 0f)
		{
			return start;
		}
		return (0f - totalChange) * (easeTime / duration) + start;
	}

	public static float GetQuadraticInValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime < 0f)
		{
			return start;
		}
		easeTime /= duration;
		return (0f - totalChange) * easeTime * easeTime + start;
	}

	public static float GetQuadraticOutValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime < 0f)
		{
			return start;
		}
		easeTime /= duration;
		return totalChange * easeTime * (easeTime - 2f) + start;
	}

	public static float GetSinusoidalValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime < 0f)
		{
			return start;
		}
		return totalChange / 2f * (Mathf.Cos((float)Math.PI * (easeTime / duration)) - 1f) + start;
	}

	public static float GetEaseOutElasticValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		float num = 1.70158f;
		float num2 = 0f;
		float num3 = totalChange;
		if ((easeTime /= duration) == 1f)
		{
			return start + totalChange;
		}
		num2 = duration * 0.3f;
		if (num3 < Mathf.Abs(totalChange))
		{
			num = num2 / 4f;
		}
		else
		{
			num = num2 / ((float)Math.PI * 2f);
			num = ((num3 != 0f) ? (num * Mathf.Asin(totalChange / num3)) : 0f);
		}
		return num3 * Mathf.Pow(2f, -10f * easeTime) * Mathf.Sin((easeTime * duration - num) * ((float)Math.PI * 2f) / num2) + totalChange + start;
	}

	public static float GetEaseInElasticValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		if ((easeTime /= duration) == 1f)
		{
			return start + totalChange;
		}
		float num = duration * 0.3f;
		float num2 = totalChange;
		float num3 = num / 4f;
		return 0f - num2 * Mathf.Pow(2f, 10f * (easeTime -= 1f)) * Mathf.Sin((easeTime * duration - num3) * ((float)Math.PI * 2f) / num) + start;
	}

	public static float GetEaseOutBackValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		if ((easeTime /= duration) == 1f)
		{
			return start + totalChange;
		}
		float num = 1.70158f;
		return ((easeTime -= 1f) * easeTime * ((num + 1f) * easeTime + num) + 1f) * totalChange + start;
	}

	public static float GetEaseOutBounceValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		if ((easeTime /= duration) == 1f)
		{
			return start + totalChange;
		}
		return (1f - Mathf.Pow(2f, -6f * easeTime) * Mathf.Abs(Mathf.Cos(easeTime * (float)Math.PI * 3.5f))) * totalChange + start;
	}

	public static float GetBouncePastValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		if ((easeTime /= duration) == 1f)
		{
			return start + totalChange;
		}
		if (easeTime < 0.36363637f)
		{
			return 7.5625f * easeTime * easeTime * totalChange + start;
		}
		if (easeTime < 0.72727275f)
		{
			return (2f - (7.5625f * (easeTime -= 0.54545456f) * easeTime + 0.75f)) * totalChange + start;
		}
		if (easeTime < 0.90909094f)
		{
			return (2f - (7.5625f * (easeTime -= 0.8181818f) * easeTime + 0.9375f)) * totalChange + start;
		}
		return (2f - (7.5625f * (easeTime -= 21f / 22f) * easeTime + 63f / 64f)) * totalChange + start;
	}

	public static float GetEaseInBackValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		if ((easeTime /= duration) == 1f)
		{
			return start + totalChange;
		}
		float num = 1.70158f;
		return easeTime * easeTime * ((num + 1f) * easeTime - num) * totalChange + start;
	}

	public static float GetEaseInCircValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		float num = (easeTime /= duration);
		if (num == 1f)
		{
			return start + totalChange;
		}
		return totalChange * (0f - (Mathf.Sqrt(1f - num * num) - 1f)) + start;
	}

	public static float GetEaseOutCircValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		float num = (easeTime /= duration);
		if (num == 1f)
		{
			return start + totalChange;
		}
		return totalChange * Mathf.Sqrt(1f - Mathf.Pow(num - 1f, 2f)) + start;
	}

	public static float GetEaseInQuartValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		float num = (easeTime /= duration);
		if (num == 1f)
		{
			return start + totalChange;
		}
		return totalChange * Mathf.Pow(num, 4f) + start;
	}

	public static float GetEaseOutQuartValue(float easeTime, float start, float totalChange, float duration)
	{
		if (easeTime <= 0f)
		{
			return start;
		}
		totalChange *= -1f;
		float num = (easeTime /= duration);
		if (num == 1f)
		{
			return start + totalChange;
		}
		return totalChange * (0f - (Mathf.Pow(num - 1f, 4f) - 1f)) + start;
	}
}
