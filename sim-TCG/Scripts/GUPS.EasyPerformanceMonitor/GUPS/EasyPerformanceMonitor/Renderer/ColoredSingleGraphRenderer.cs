using System.Reflection;
using GUPS.EasyPerformanceMonitor.Provider;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public class ColoredSingleGraphRenderer : ASingleGraphRenderer
	{
		[SerializeField]
		private Color color;

		private float[] values;

		private float minValue;

		private float maxValue;

		private float meanValue;

		public static readonly int ColorPropertyId = Shader.PropertyToID("_GraphColor");

		public Color Color => color;

		protected override void Awake()
		{
			base.Awake();
			values = new float[base.GraphValues];
		}

		protected override void OnInitializeGraph(Shader _Shader)
		{
			base.OnInitializeGraph(_Shader);
			base.Target.material.SetColor(ColorPropertyId, color);
		}

		public override void RefreshGraph()
		{
			base.RefreshGraph();
			base.Target.material.SetColor(ColorPropertyId, color);
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
			base.Target.material.SetFloatArray(AGraphRenderer.ValuesPropertyId, array);
		}

		private void UpdateLegend()
		{
			if (!(base.LegendImage == null))
			{
				Color color = this.color;
				base.LegendImage.color = color;
			}
		}
	}
}
