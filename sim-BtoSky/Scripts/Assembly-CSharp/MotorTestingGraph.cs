using System;
using System.Collections.Generic;
using UnityEngine;

public class MotorTestingGraph : MonoBehaviour
{
	public AnimationCurve curve;

	public RectTransform graphParent;

	public GameObject pointPrefab;

	public GameObject linePrefab;

	private List<GameObject> points = new List<GameObject>();

	private List<GameObject> lines = new List<GameObject>();

	private Vector2 prevPoint;

	private bool firstPoint = true;

	private float timer;

	private float width;

	private float height;

	private float totalTime;

	private bool isDrawing;

	private void Start()
	{
		width = graphParent.rect.width;
		height = graphParent.rect.height;
		GameManager.S.OnGrainIgnited += Gm_OnGrainIgnited;
	}

	private void OnDestroy()
	{
		GameManager.S.OnGrainIgnited -= Gm_OnGrainIgnited;
	}

	public void SetCurve(AnimationCurve newCurve)
	{
		curve = newCurve;
		totalTime = curve.keys[curve.length - 1].time - curve.keys[0].time;
	}

	public void SetAndDrawCurve(AnimationCurve newCurve)
	{
		curve = newCurve;
		totalTime = curve.keys[curve.length - 1].time - curve.keys[0].time;
		StartDraw();
	}

	private void Gm_OnGrainIgnited(object sender, EventArgs e)
	{
		StartDraw();
	}

	private void FixedUpdate()
	{
		if (!isDrawing)
		{
			return;
		}
		if (timer > totalTime)
		{
			isDrawing = false;
			return;
		}
		float num = timer + curve.keys[0].time;
		float num2 = curve.Evaluate(num);
		float x = (num - curve.keys[0].time) / totalTime * width;
		float y = num2 / GetMaxValue() * height;
		Vector2 vector = new Vector2(x, y);
		GameObject gameObject = UnityEngine.Object.Instantiate(pointPrefab, graphParent);
		points.Add(gameObject);
		gameObject.GetComponent<RectTransform>().anchoredPosition = vector;
		if (!firstPoint)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(linePrefab, graphParent);
			lines.Add(gameObject2);
			RectTransform component = gameObject2.GetComponent<RectTransform>();
			component.anchoredPosition = (prevPoint + vector) / 2f;
			float x2 = Vector2.Distance(prevPoint, vector);
			component.sizeDelta = new Vector2(x2, component.sizeDelta.y);
			float z = Mathf.Atan2(vector.y - prevPoint.y, vector.x - prevPoint.x) * 57.29578f;
			component.localRotation = Quaternion.Euler(0f, 0f, z);
		}
		else
		{
			firstPoint = false;
		}
		prevPoint = vector;
		timer += Time.fixedDeltaTime;
	}

	private float GetMaxValue()
	{
		float num = float.MinValue;
		Keyframe[] keys = curve.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Keyframe keyframe = keys[i];
			if (keyframe.value > num)
			{
				num = keyframe.value;
			}
		}
		return num;
	}

	public void StartDraw()
	{
		isDrawing = true;
	}

	public void ClearGraph()
	{
		curve = null;
		isDrawing = false;
		if (points == null)
		{
			return;
		}
		foreach (GameObject point in points)
		{
			UnityEngine.Object.Destroy(point);
		}
		foreach (GameObject line in lines)
		{
			UnityEngine.Object.Destroy(line);
		}
		points.Clear();
		lines.Clear();
		timer = 0f;
		firstPoint = true;
		prevPoint = Vector2.zero;
	}

	public void DrawGraphInstantly()
	{
		if (curve == null || curve.length < 2)
		{
			return;
		}
		width = graphParent.rect.width;
		height = graphParent.rect.height;
		if ((width <= 0f || height <= 0f) && width <= 0f)
		{
			return;
		}
		firstPoint = true;
		prevPoint = Vector2.zero;
		int num = 50;
		_ = totalTime / (float)num;
		for (int i = 0; i <= num; i++)
		{
			float num2 = (float)i / (float)num * totalTime;
			float time = num2 + curve.keys[0].time;
			float num3 = curve.Evaluate(time);
			float x = num2 / totalTime * width;
			float y = num3 / GetMaxValue() * height;
			Vector2 vector = new Vector2(x, y);
			CreatePoint(vector);
			if (!firstPoint)
			{
				CreateLine(prevPoint, vector);
			}
			else
			{
				firstPoint = false;
			}
			prevPoint = vector;
		}
	}

	private void CreatePoint(Vector2 pos)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(pointPrefab, graphParent);
		points.Add(gameObject);
		gameObject.GetComponent<RectTransform>().anchoredPosition = pos;
	}

	private void CreateLine(Vector2 start, Vector2 end)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(linePrefab, graphParent);
		lines.Add(gameObject);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.anchoredPosition = (start + end) / 2f;
		float x = Vector2.Distance(start, end);
		component.sizeDelta = new Vector2(x, component.sizeDelta.y);
		float z = Mathf.Atan2(end.y - start.y, end.x - start.x) * 57.29578f;
		component.localRotation = Quaternion.Euler(0f, 0f, z);
	}
}
