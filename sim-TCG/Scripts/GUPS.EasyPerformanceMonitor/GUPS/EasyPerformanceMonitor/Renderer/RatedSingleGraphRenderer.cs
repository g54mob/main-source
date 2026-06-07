using System.Collections.Generic;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Platform;
using GUPS.EasyPerformanceMonitor.Provider;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public class RatedSingleGraphRenderer : ASingleGraphRenderer
	{
		[SerializeField]
		private bool highIsGood = true;

		[SerializeField]
		private List<Color> colors = new List<Color>();

		[SerializeField]
		private List<float> desktopThresholds;

		[SerializeField]
		private List<float> mobileThresholds;

		[SerializeField]
		private List<float> consoleThresholds;

		private float[] currentThresholds;

		private float[] values;

		private float minValue;

		private float maxValue;

		private float meanValue;

		public static readonly int HighIsGoodPropertyId = Shader.PropertyToID("_HighIsGood");

		public static readonly int ThresholdsPropertyId = Shader.PropertyToID("_Thresholds");

		public static readonly int ColorsPropertyId = Shader.PropertyToID("_Colors");

		public static readonly int ColorCountPropertyId = Shader.PropertyToID("_ColorCount");

		public bool HighIsGood => highIsGood;

		public List<Color> GoodColor => colors;

		public List<float> DesktopThresholds => desktopThresholds;

		public List<float> MobileThresholds => mobileThresholds;

		public List<float> ConsoleThresholds => consoleThresholds;

		protected override void Awake()
		{
			base.Awake();
			values = new float[base.GraphValues];
		}

		protected override void OnInitializeGraph(Shader _Shader)
		{
			base.OnInitializeGraph(_Shader);
			base.Target.material.SetFloat(HighIsGoodPropertyId, highIsGood ? 1f : 0f);
			switch (PlatformHelper.GetCurrentPlatform())
			{
			case EPlatform.Desktop:
				currentThresholds = desktopThresholds.ToArray();
				break;
			case EPlatform.Mobile:
				currentThresholds = mobileThresholds.ToArray();
				break;
			case EPlatform.Console:
				currentThresholds = consoleThresholds.ToArray();
				break;
			default:
				currentThresholds = desktopThresholds.ToArray();
				break;
			}
			base.Target.material.SetFloatArray(ThresholdsPropertyId, currentThresholds);
			base.Target.material.SetColorArray(ColorsPropertyId, colors);
			base.Target.material.SetFloat(ColorCountPropertyId, colors.Count);
		}

		public override void RefreshGraph()
		{
			base.RefreshGraph();
			base.Target.material.SetFloat(HighIsGoodPropertyId, highIsGood ? 1f : 0f);
			switch (PlatformHelper.GetCurrentPlatform())
			{
			case EPlatform.Desktop:
				currentThresholds = desktopThresholds.ToArray();
				break;
			case EPlatform.Mobile:
				currentThresholds = mobileThresholds.ToArray();
				break;
			case EPlatform.Console:
				currentThresholds = consoleThresholds.ToArray();
				break;
			default:
				currentThresholds = desktopThresholds.ToArray();
				break;
			}
			base.Target.material.SetFloatArray(ThresholdsPropertyId, currentThresholds);
			base.Target.material.SetColorArray(ColorsPropertyId, colors);
			base.Target.material.SetFloat(ColorCountPropertyId, colors.Count);
			float[] array = new float[base.GraphValues];
			int num = base.GraphValues - values.Length;
			for (int i = ((base.GraphValues > values.Length) ? num : 0); i < base.GraphValues; i++)
			{
				array[i] = values[i - num];
			}
			values = array;
		}

		public override void OnNext(PerformanceData _Next)
		{
			AddValue(_Next.Value);
			UpdateGraph();
			UpdateLegend();
		}

		private void AddValue(float _Value)
		{
			float num = float.MaxValue;
			float num2 = 0f;
			float num3 = 0f;
			int num4 = 0;
			int num5 = base.GraphValues;
			for (int i = 0; i < num5; i++)
			{
				if (i < num5 - 1)
				{
					values[i] = values[i + 1];
				}
				else
				{
					values[i] = _Value;
				}
				if (values[i] < num)
				{
					num = values[i];
				}
				if (values[i] > num2)
				{
					num2 = values[i];
				}
				if (values[i] > 0f)
				{
					num3 += values[i];
					num4++;
				}
			}
			minValue = num;
			meanValue = ((num4 > 0) ? (num3 / (float)num4) : 0f);
			maxValue = num2;
		}

		private void UpdateGraph()
		{
			float[] array = new float[values.Length];
			for (int i = 0; i < values.Length; i++)
			{
				array[i] = values[i] / maxValue;
			}
			float[] array2 = new float[currentThresholds.Length];
			for (int j = 0; j < currentThresholds.Length; j++)
			{
				array2[j] = currentThresholds[j] / maxValue;
			}
			base.Target.material.SetFloatArray(ThresholdsPropertyId, array2);
			base.Target.material.SetFloatArray(AGraphRenderer.ValuesPropertyId, array);
		}

		private void UpdateLegend()
		{
			if (!(base.LegendImage == null))
			{
				Color color = colors[0];
				color = (highIsGood ? ((meanValue > currentThresholds[0]) ? colors[0] : ((!(meanValue > currentThresholds[1])) ? colors[2] : colors[1])) : ((meanValue > currentThresholds[1]) ? colors[2] : ((!(meanValue > currentThresholds[0])) ? colors[0] : colors[1])));
				base.LegendImage.color = color;
			}
		}
	}
}
