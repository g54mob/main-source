using System;
using System.Collections.Generic;
using System.Linq;
using UIScripts.UIReferences.Graphs;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace UIScripts.UIReferences.LineagePanel
{
	public class LineageWindow : MonoBehaviour
	{
		[NonSerialized]
		public static LineageWindow instance;

		public Transform axisHolder;

		public RectTransform graphRT;

		public RectTransform viewportRT;

		public GameObject linePrefab;

		public UnityEvent<Vector2> onViewportSizeChange = new UnityEvent<Vector2>();

		private RectTransform axisRT;

		private float currentScale = 1f;

		private float minScale = 0.5f;

		private float maxScale = 1.5f;

		[NonSerialized]
		public Vector2 viewportDimensions;

		private float viewportWidth;

		private float viewportHeight;

		private List<GraphLineTextReference> graphLines = new List<GraphLineTextReference>();

		private bool hasInit;

		private float defaultStep = 50f;

		private float[] linesProgress;

		private float[] linesSteps;

		public int nonInfiniteMaxN;

		private int maxN;

		private LogLikeConfig config;

		public float HeightOfPoint(int i)
		{
			return defaultStep * ((i < 0) ? 0f : ((i < nonInfiniteMaxN) ? linesProgress[i] : (linesProgress[^1] + (float)(i + 1 - nonInfiniteMaxN))));
		}

		public float StepOfPoint(int i)
		{
			return defaultStep * ((i < 0) ? 1f : ((i < nonInfiniteMaxN) ? linesSteps[i] : ((float)(i + 1 - nonInfiniteMaxN))));
		}

		public void Initialize()
		{
			if (hasInit)
			{
				return;
			}
			instance = this;
			axisRT = axisHolder.GetComponent<RectTransform>();
			config = DataLogger.SerialSpeciesConfig;
			LogLikeFormat[] formats = config.formats;
			nonInfiniteMaxN = config.formats.Sum((LogLikeFormat f) => f.size);
			linesProgress = new float[nonInfiniteMaxN];
			linesSteps = new float[nonInfiniteMaxN + 1];
			int num = 0;
			for (int num2 = 0; num2 < formats.Length; num2++)
			{
				int size = formats[num2].size;
				int feedRatio = formats[num2].feedRatio;
				float num3 = (1f + (float)num2 / 3f) / Mathf.Min(feedRatio, 3f);
				for (int num4 = 0; num4 < size; num4++)
				{
					float num5 = (float)(size - 1 - num4) / (float)(size - 1) * (1f - num3) + num3;
					linesProgress[num] = num5;
					if (num > 0)
					{
						linesSteps[num - 1] = num5;
					}
					if (num > 0)
					{
						linesProgress[num] += linesProgress[num - 1];
					}
					num++;
				}
			}
			linesSteps[num - 1] = 1f;
			SetMaxN(nonInfiniteMaxN);
			UpdateViewportDimensions();
			hasInit = true;
		}

		public void SetMaxN(int newMaxN)
		{
			maxN = Mathf.Max(maxN, newMaxN);
			while (graphLines.Count <= maxN)
			{
				GraphLineTextReference component = UnityEngine.Object.Instantiate(linePrefab, axisHolder).GetComponent<GraphLineTextReference>();
				component.InitializeLine(config.TimeOfPointInSerialConfig(graphLines.Count - 1));
				graphLines.Add(component);
			}
		}

		public void ResetView()
		{
			UpdateAxisPlacement(Vector2.one / 2f);
			ZoomToScale(1f);
			SetDimension();
		}

		public void SetDimension(float? width = null, float? height = null)
		{
			graphRT.sizeDelta = new Vector2((width ?? viewportWidth) - viewportWidth, height ?? viewportHeight);
		}

		public void SetDefaultStep(float newDefaultStep)
		{
			defaultStep = newDefaultStep;
			for (int i = -1; i < maxN; i++)
			{
				graphLines[i + 1].SetHeightAndSpace(HeightOfPoint(i), StepOfPoint(i));
			}
		}

		public void SetMinMaxZoom(float minZoom, float maxZoom)
		{
			minScale = minZoom;
			maxScale = maxZoom;
			if (currentScale < minZoom || currentScale > maxZoom)
			{
				Zoom(0f);
			}
		}

		private void Update()
		{
			float y = Input.mouseScrollDelta.y;
			if (y != 0f && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
			{
				Zoom(y / 6f);
			}
		}

		public void Zoom(float increment)
		{
			ZoomToScale(currentScale * (1f + increment));
		}

		public void ZoomToScale(float scale)
		{
			currentScale = Mathf.Clamp(scale, minScale, maxScale);
			float num = currentScale / graphRT.localScale.x;
			Vector2 anchoredPosition = graphRT.anchoredPosition;
			Vector2 vector = new Vector2(0f, viewportHeight / 2f) - anchoredPosition;
			graphRT.localScale = currentScale * Vector2.one;
			anchoredPosition += vector * (1f - num);
			graphRT.anchoredPosition = anchoredPosition;
			graphLines.ForEach(delegate(GraphLineTextReference l)
			{
				l.UpdateLineScaleToMatchParent(graphRT.localScale.x);
			});
		}

		public void UpdateViewportDimensions()
		{
			Vector2 arg = (viewportDimensions = viewportRT.rect.size);
			viewportWidth = arg.x;
			viewportHeight = arg.y;
			onViewportSizeChange.Invoke(arg);
		}

		public void UpdateAxisPlacement(Vector2 offset)
		{
			if (!hasInit)
			{
				Initialize();
			}
			float num = offset.x;
			float num2 = viewportWidth / graphRT.localScale.x - graphRT.rect.width;
			if (num2 >= 0f)
			{
				num = 0.5f;
			}
			axisRT.offsetMin = new Vector2((0f - num2) * num, axisRT.offsetMin.y);
			axisRT.offsetMax = new Vector2(num2 * (1f - num), axisRT.offsetMax.y);
		}
	}
}
