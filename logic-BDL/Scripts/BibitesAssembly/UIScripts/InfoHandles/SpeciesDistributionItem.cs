using System;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts.InfoHandles
{
	public class SpeciesDistributionItem : PoolableDictItem<Species, SpeciesDistributionItem>
	{
		private RectTransform rt;

		private RectTransform parentRT;

		private float parentRadius;

		private float radius;

		private Rect rect;

		public Material baseMat;

		private Material mat;

		private Vector2 center;

		private Vector2 xAxis;

		private Vector2 yAxis;

		private static readonly FloatSetting SimulationSize = ScenarioIndependentSettings.Instance.SimulationSize;

		private static float simulationSize = SimulationSize.SubscribeTo<FloatSetting, float>(UpdateSimulationSize);

		private float simSizeEq;

		private static void UpdateSimulationSize(float val)
		{
			simulationSize = val;
		}

		public override void Initialize()
		{
			base.Initialize();
			rt = GetComponent<RectTransform>();
			parentRT = base.transform.parent.GetComponent<RectTransform>();
			if (baseMat != null)
			{
				mat = UnityEngine.Object.Instantiate(baseMat);
				GetComponent<Image>().material = mat;
			}
		}

		public void UpdatePoint(SpeciesDataPoint point)
		{
			simSizeEq = parentRT.sizeDelta.x / 2f;
			float num = Mathf.Clamp(point.posStdDev.x, simulationSize * 0.03f, simulationSize);
			float num2 = Mathf.Clamp(point.posStdDev.y, simulationSize * 0.03f, simulationSize);
			float num3 = Mathf.Clamp(point.posCor, -0.999f, 0.999f);
			if (num3 == 0f || float.IsNaN(num3))
			{
				num3 = 1E-07f;
			}
			center = point.avgPos;
			float num4 = MathF.PI / 4f - 0.5f * Mathf.Atan((num * num - num2 * num2) / (2f * num3 * num * num2));
			if ((num3 >= 0f && num2 >= num) || (num3 < 0f && num2 < num))
			{
				num4 -= MathF.PI / 2f;
			}
			float num5 = Mathf.Sqrt(num2 * num2 - num3 * num * num2 * Mathf.Tan(num4));
			float num6 = num * num2 / num5 * Mathf.Sqrt(1f - num3 * num3) / simulationSize;
			num5 /= simulationSize;
			xAxis = Mathf.Max(num6, 0.03f, 0.2f * num5) * Vector2.right.Rotate(num4);
			yAxis = Mathf.Max(num5, 0.03f, 0.2f * num6) * Vector2.up.Rotate(num4);
			center = point.avgPos / simulationSize;
			Vector2 vector = Mathf.Min(point.avgPos.magnitude / simulationSize, 1.5f - Mathf.Max(num, num2) / simulationSize) * point.avgPos.normalized;
			rt.localRotation = Quaternion.Euler(0f, 0f, 57.29578f * num4);
			rt.anchoredPosition = simSizeEq * vector;
			rt.sizeDelta = 2f * simSizeEq * new Vector2(num6, num5);
		}

		public ZoneMatch GetOverlapWithZone(ZoneSettings zone)
		{
			return new ZoneMatch(zone, center, xAxis, yAxis);
		}

		private void OnDestroy()
		{
			if (mat != null)
			{
				UnityEngine.Object.Destroy(mat);
			}
		}
	}
}
