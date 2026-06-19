using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	[AddComponentMenu("UI/Pie Chart", 102)]
	[ExecuteInEditMode]
	public class PieChart : MonoBehaviour
	{
		[Serializable]
		public class SegmentInternal
		{
			public Image SegmentImage;

			public Image DividerImage;

			[HideInInspector]
			public float Value;

			[HideInInspector]
			public float TargetValue;

			[HideInInspector]
			public bool IsShowing;

			[HideInInspector]
			public string Description;
		}

		[SerializeField]
		private Image _pieChartBacking;

		[SerializeField]
		private float _smoothTime = 0.15f;

		[SerializeField]
		private List<SegmentInternal> _segments = new List<SegmentInternal>();

		[SerializeField]
		private TooltipSpawner _tooltip;

		private const float Tolerance = 0.001f;

		private void Start()
		{
			_tooltip.SetDataProvider(OnTooltip);
		}

		public void SetSegmentColor(int index, Color color)
		{
			_segments[index].SegmentImage.color = color;
		}

		public void SetSegmentValue(int index, float value)
		{
			_segments[index].TargetValue = value;
		}

		public void SetSegmentShowing(int index, bool isShowing)
		{
			_segments[index].IsShowing = isShowing;
		}

		public void SetSegmentDescription(int index, string description)
		{
			_segments[index].Description = description;
		}

		private void Update()
		{
			float num = 0f;
			int num2 = 0;
			float num3 = 0f;
			foreach (SegmentInternal segment in _segments)
			{
				if (segment.IsShowing)
				{
					float currentVelocity = 0f;
					segment.Value = Mathf.SmoothDamp(segment.Value, segment.TargetValue, ref currentVelocity, _smoothTime, float.PositiveInfinity, Time.unscaledDeltaTime);
					num += segment.Value;
					num3 += segment.TargetValue;
					if (segment.Value > 0.001f)
					{
						num2++;
					}
				}
				else
				{
					float currentVelocity2 = 0f;
					segment.Value = Mathf.SmoothDamp(segment.Value, 0f, ref currentVelocity2, _smoothTime, float.PositiveInfinity, Time.unscaledDeltaTime);
					num += segment.Value;
				}
			}
			if (num3 < 0.001f)
			{
				_pieChartBacking.color = new Color(1f, 1f, 1f, 0.1f);
				{
					foreach (SegmentInternal segment2 in _segments)
					{
						segment2.Value = 0f;
						segment2.TargetValue = 0f;
						segment2.SegmentImage.fillAmount = 0f;
						GameObjectUtils.SetActive(segment2.SegmentImage.gameObject, isActive: false);
						if (segment2.DividerImage != null)
						{
							GameObjectUtils.SetActive(segment2.DividerImage.gameObject, isActive: false);
						}
					}
					return;
				}
			}
			_pieChartBacking.color = Color.white;
			float num4 = 0f;
			foreach (SegmentInternal segment3 in _segments)
			{
				bool isActive = segment3.Value > 0f;
				bool isActive2 = num2 > 1 && segment3.Value > 0.001f;
				GameObjectUtils.SetActive(segment3.SegmentImage.gameObject, isActive);
				if (segment3.DividerImage != null)
				{
					GameObjectUtils.SetActive(segment3.DividerImage.gameObject, isActive2);
				}
				float num5 = ((num > 0.001f) ? (segment3.Value / num) : 0f);
				num4 += num5;
				segment3.SegmentImage.fillAmount = num4;
				if (segment3.DividerImage != null)
				{
					segment3.DividerImage.transform.rotation = Quaternion.Euler(0f, 0f, num4 * 360f);
				}
			}
		}

		private void OnTooltip(Tooltip tooltip)
		{
			TooltipPieChart tooltipPieChart = tooltip as TooltipPieChart;
			if (!(tooltipPieChart == null))
			{
				tooltipPieChart.Setup(_segments);
			}
		}
	}
}
