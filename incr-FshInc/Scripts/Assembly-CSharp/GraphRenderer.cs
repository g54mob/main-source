using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DefaultNamespace.Analytics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class GraphRenderer : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	[Header("UI References")]
	public Image dotPrefab;

	public Image linePrefab;

	public TMP_Text titleText;

	public TMP_Text maxMoneyText;

	public TMP_Text timeDurationText;

	[Header("Axis References")]
	public RectTransform xAxisLabelContainer;

	public RectTransform yAxisLabelContainer;

	public TMP_Text labelPrefab;

	[Header("Graph Settings")]
	public Color graphColor = Color.green;

	public float dotSize = 10f;

	public float lineWidth = 2f;

	public bool useLogarithmicScale = true;

	public int numberOfXLabels = 10;

	public int numberOfYLabels = 5;

	public float axisLabelOffset = 10f;

	[Header("Zoom Settings")]
	public float zoomSpeed = 0.1f;

	public float minZoom = 0.5f;

	public float maxZoom = 5f;

	private float currentZoom = 1f;

	private List<LogEntry> graphData = new List<LogEntry>();

	private List<GameObject> spawnedGraphElements = new List<GameObject>();

	private ScrollRect scrollRect;

	private RectTransform graphContainer;

	public string fileName;

	private void Awake()
	{
		scrollRect = GetComponent<ScrollRect>();
		if (scrollRect != null && scrollRect.content != null)
		{
			graphContainer = scrollRect.content;
			graphContainer.pivot = new Vector2(0f, 0f);
			graphContainer.anchorMin = new Vector2(0f, 0f);
			graphContainer.anchorMax = new Vector2(0f, 0f);
			if (xAxisLabelContainer != null && xAxisLabelContainer.parent != graphContainer)
			{
				Debug.LogError("xAxisLabelContainer MUST be a child of the GraphContainer (ScrollRect Content)!");
			}
			if (yAxisLabelContainer != null && yAxisLabelContainer.parent != graphContainer)
			{
				Debug.LogError("yAxisLabelContainer MUST be a child of the GraphContainer (ScrollRect Content)!");
			}
		}
		else
		{
			Debug.LogError("GraphRenderer requires a ScrollRect component with valid Content assigned!");
			base.enabled = false;
		}
	}

	private void Start()
	{
		LoadAndDrawGraph();
	}

	public void RefreshGraph()
	{
		LoadAndDrawGraph();
	}

	private void LoadAndDrawGraph()
	{
		graphData.Clear();
		string text = Path.Combine(Application.persistentDataPath, fileName + ".csv");
		if (!File.Exists(text))
		{
			Debug.LogError("Money log file not found at: " + text);
			if (titleText != null)
			{
				titleText.text = "Error: Log file not found!";
			}
			ClearGraphElements();
			return;
		}
		try
		{
			string[] array = File.ReadAllLines(text);
			graphData.Clear();
			for (int i = 1; i < array.Length; i++)
			{
				string text2 = array[i].Trim();
				if (string.IsNullOrEmpty(text2))
				{
					continue;
				}
				string[] array2 = Regex.Split(text2, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = array2[j].Trim('"');
				}
				if (array2.Length >= 13 && float.TryParse(array2[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var result) && long.TryParse(array2[1], out var _))
				{
					LogEntry item = new LogEntry(array2.ToArray());
					if (!graphData.Any() || result > graphData.Last().Timestamp)
					{
						graphData.Add(item);
					}
				}
				else
				{
					Debug.LogWarning("Skipping malformed line: " + text2);
				}
			}
			graphData = graphData.OrderBy((LogEntry d) => d.Timestamp).ToList();
			Debug.Log($"Loaded {graphData.Count} data points.");
			DrawGraph();
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed to load/parse log: " + ex.Message);
			if (titleText != null)
			{
				titleText.text = "Error loading log!";
			}
			ClearGraphElements();
		}
	}

	private void DrawGraph()
	{
		ClearGraphElements();
		if (graphData.Count < 2)
		{
			Debug.LogWarning("Not enough data points for graph.");
			if (titleText != null)
			{
				titleText.text = "Not enough data.";
			}
			return;
		}
		Rect rect = scrollRect.viewport.rect;
		float width = rect.width;
		float height = rect.height;
		float num = width * currentZoom;
		float num2 = height * currentZoom;
		graphContainer.sizeDelta = new Vector2(num, num2);
		float timestamp = graphData[0].Timestamp;
		float timestamp2 = graphData[graphData.Count - 1].Timestamp;
		float num3 = timestamp2 - timestamp;
		if (num3 <= 0f)
		{
			num3 = 1f;
		}
		int num4 = Mathf.RoundToInt(graphData.Max((LogEntry point) => point.TotalMoney));
		if (num4 <= 0)
		{
			num4 = 1;
		}
		float num5 = Mathf.Log10(Mathf.Max(1, num4));
		if (num5 <= 0f)
		{
			num5 = 1f;
		}
		Vector2? vector = null;
		for (int num6 = 0; num6 < graphData.Count; num6++)
		{
			float x = (graphData[num6].Timestamp - timestamp) / num3 * num;
			float value;
			if (useLogarithmicScale)
			{
				float num7 = Mathf.Log10(Mathf.Max(1f, graphData[num6].TotalMoney));
				value = ((num5 > 0f) ? (num7 / num5) : 0f);
			}
			else
			{
				value = (float)graphData[num6].TotalMoney / (float)num4;
			}
			value = Mathf.Clamp01(value);
			float y = value * num2;
			Vector2 vector2 = new Vector2(x, y);
			if (dotPrefab != null)
			{
				Image image = UnityEngine.Object.Instantiate(dotPrefab, graphContainer);
				image.rectTransform.anchorMin = new Vector2(0f, 0f);
				image.rectTransform.anchorMax = new Vector2(0f, 0f);
				image.rectTransform.pivot = new Vector2(0.5f, 0.5f);
				image.rectTransform.anchoredPosition = vector2;
				image.rectTransform.sizeDelta = new Vector2(dotSize, dotSize);
				image.color = graphColor;
				spawnedGraphElements.Add(image.gameObject);
				GraphDotInstance component = image.transform.GetChild(0).gameObject.GetComponent<GraphDotInstance>();
				component.eventTitle = graphData[num6].EventType;
				component.ConstructEventData(graphData[num6]);
			}
			if (vector.HasValue && linePrefab != null)
			{
				CreateLineConnector(vector.Value, vector2);
			}
			vector = vector2;
		}
		DrawAxisLabels(timestamp, timestamp2, 0, num4, num, num2);
		if (titleText != null)
		{
			titleText.text = "Money vs. Time Played (" + (useLogarithmicScale ? "Log Scale" : "Linear Scale") + ")";
		}
		if (maxMoneyText != null)
		{
			maxMoneyText.text = "Peak Money: " + FormatMoney(num4) + "g";
		}
		if (timeDurationText != null)
		{
			timeDurationText.text = "Time Logged: " + FormatTime(num3);
		}
		Debug.Log($"Graph drawn. Zoom: {currentZoom:F2}, Max Money: {num4}, Time: {num3:F1}s");
	}

	private void DrawAxisLabels(float minTime, float maxTime, int minMoney, int maxMoney, float currentGraphWidth, float currentGraphHeight)
	{
		if (labelPrefab == null)
		{
			return;
		}
		float num = maxTime - minTime;
		if (num <= 0f)
		{
			num = 1f;
		}
		if (xAxisLabelContainer != null)
		{
			for (int i = 0; i <= numberOfXLabels; i++)
			{
				float num2 = (float)i / (float)numberOfXLabels;
				float num3 = minTime + num2 * num;
				float x = num2 * currentGraphWidth;
				TMP_Text tMP_Text = UnityEngine.Object.Instantiate(labelPrefab, xAxisLabelContainer);
				tMP_Text.rectTransform.anchorMin = new Vector2(0f, 0f);
				tMP_Text.rectTransform.anchorMax = new Vector2(0f, 0f);
				tMP_Text.rectTransform.pivot = new Vector2(0.5f, 1f);
				tMP_Text.rectTransform.anchoredPosition = new Vector2(x, 0f - axisLabelOffset);
				tMP_Text.text = FormatTime(num3 - minTime);
				spawnedGraphElements.Add(tMP_Text.gameObject);
			}
		}
		if (!(yAxisLabelContainer != null))
		{
			return;
		}
		for (int j = 0; j <= numberOfYLabels; j++)
		{
			float num4 = (float)j / (float)numberOfYLabels;
			float y = num4 * currentGraphHeight;
			float f;
			if (useLogarithmicScale)
			{
				float num5 = Mathf.Log10(Mathf.Max(1, maxMoney));
				if (num5 <= 0f)
				{
					num5 = 1f;
				}
				f = Mathf.Pow(10f, num4 * num5);
			}
			else
			{
				f = num4 * (float)maxMoney;
			}
			TMP_Text tMP_Text2 = UnityEngine.Object.Instantiate(labelPrefab, yAxisLabelContainer);
			tMP_Text2.rectTransform.anchorMin = new Vector2(0f, 0f);
			tMP_Text2.rectTransform.anchorMax = new Vector2(0f, 0f);
			tMP_Text2.rectTransform.pivot = new Vector2(1f, 0.5f);
			tMP_Text2.rectTransform.anchoredPosition = new Vector2(0f - axisLabelOffset, y);
			tMP_Text2.text = FormatMoney(Mathf.RoundToInt(f));
			spawnedGraphElements.Add(tMP_Text2.gameObject);
		}
	}

	public void OnScroll(PointerEventData eventData)
	{
		float y = eventData.scrollDelta.y;
		if (Mathf.Abs(y) > 0.1f)
		{
			float num = 1f + y * zoomSpeed;
			float b = currentZoom;
			currentZoom = Mathf.Clamp(currentZoom * num, minZoom, maxZoom);
			if (!Mathf.Approximately(currentZoom, b))
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(graphContainer, eventData.position, eventData.pressEventCamera, out var localPoint);
				Vector2 vector = new Vector2(localPoint.x / graphContainer.rect.width, localPoint.y / graphContainer.rect.height);
				Vector2 vector2 = graphContainer.sizeDelta * (num - 1f);
				Vector2 vector3 = new Vector2(vector2.x * vector.x, vector2.y * vector.y);
				Vector2 anchoredPosition = graphContainer.anchoredPosition;
				DrawGraph();
				graphContainer.anchoredPosition = anchoredPosition - vector3;
				ClampContentPosition();
			}
		}
	}

	private void ClampContentPosition()
	{
		Vector2 anchoredPosition = graphContainer.anchoredPosition;
		Rect rect = scrollRect.viewport.rect;
		float a = 0f - (graphContainer.sizeDelta.x - rect.width);
		float a2 = 0f - (graphContainer.sizeDelta.y - rect.height);
		a = Mathf.Min(a, 0f);
		a2 = Mathf.Min(a2, 0f);
		anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, a, 0f);
		anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, a2, 0f);
		graphContainer.anchoredPosition = anchoredPosition;
	}

	private void CreateLineConnector(Vector2 pointA, Vector2 pointB)
	{
		Image image = UnityEngine.Object.Instantiate(linePrefab, graphContainer);
		image.color = graphColor;
		RectTransform rectTransform = image.rectTransform;
		Vector2 normalized = (pointB - pointA).normalized;
		float x = Vector2.Distance(pointA, pointB);
		float z = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
		rectTransform.pivot = new Vector2(0f, 0.5f);
		rectTransform.anchorMin = new Vector2(0f, 0f);
		rectTransform.anchorMax = new Vector2(0f, 0f);
		rectTransform.anchoredPosition = pointA;
		rectTransform.localEulerAngles = new Vector3(0f, 0f, z);
		rectTransform.sizeDelta = new Vector2(x, lineWidth);
		spawnedGraphElements.Add(image.gameObject);
	}

	private void ClearGraphElements()
	{
		foreach (GameObject spawnedGraphElement in spawnedGraphElements)
		{
			if (spawnedGraphElement != null)
			{
				UnityEngine.Object.Destroy(spawnedGraphElement);
			}
		}
		spawnedGraphElements.Clear();
		if (xAxisLabelContainer != null)
		{
			foreach (Transform item in xAxisLabelContainer)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
		if (!(yAxisLabelContainer != null))
		{
			return;
		}
		foreach (Transform item2 in yAxisLabelContainer)
		{
			UnityEngine.Object.Destroy(item2.gameObject);
		}
	}

	private string FormatMoney(int amount)
	{
		if (amount <= 0)
		{
			return "0";
		}
		if (amount >= 1000000000)
		{
			return ((float)amount / 1E+09f).ToString("0.#B");
		}
		if (amount >= 1000000)
		{
			return ((float)amount / 1000000f).ToString("0.#M");
		}
		if (amount >= 1000)
		{
			return ((float)amount / 1000f).ToString("0.#k");
		}
		return amount.ToString();
	}

	private string FormatTime(float totalSeconds)
	{
		if (totalSeconds < 0f)
		{
			totalSeconds = 0f;
		}
		int num = Mathf.FloorToInt(totalSeconds / 60f);
		int num2 = Mathf.FloorToInt(totalSeconds % 60f);
		return $"{num}m{num2:00}s";
	}
}
