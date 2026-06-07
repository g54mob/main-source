using System.Collections.Generic;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Platform;
using GUPS.EasyPerformanceMonitor.Provider;
using UnityEngine;
using UnityEngine.UI;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public abstract class AMultiGraphRenderer : AGraphRenderer
	{
		[SerializeField]
		private bool isStacked = true;

		[SerializeField]
		private List<Image> legendImages = new List<Image>();

		private float[,] values;

		private float[] minValues;

		private float[] maxValues;

		private float[] meanValues;

		public static readonly int StackedPropertyId = Shader.PropertyToID("_Stacked");

		public bool IsStacked => isStacked;

		public List<Image> LegendImages => legendImages;

		protected float[,] Values => values;

		protected float[] MinValues => minValues;

		protected float[] MaxValues => maxValues;

		protected float[] MeanValues => meanValues;

		protected override void Awake()
		{
			base.Awake();
			int num = (IsStacked ? base.GraphValues : (base.GraphValues / base.Provider.Count));
			values = new float[base.Provider.Count, num];
			minValues = new float[base.Provider.Count];
			maxValues = new float[base.Provider.Count];
			meanValues = new float[base.Provider.Count];
		}

		protected override void OnInitializeGraph(Shader _Shader)
		{
			base.OnInitializeGraph(_Shader);
			base.Target.material.SetFloat(StackedPropertyId, IsStacked ? 1f : 0f);
			int a = base.GraphValues * ((!IsStacked) ? 1 : base.Provider.Count);
			a = ((PlatformHelper.GetCurrentPlatform() != EPlatform.Mobile) ? Mathf.Min(a, 1024) : Mathf.Min(a, 512));
			base.Target.material.SetFloatArray(AGraphRenderer.ValuesPropertyId, new float[a]);
			base.Target.material.SetFloat(AGraphRenderer.ValueCountPropertyId, a);
			int num = a / base.Provider.Count;
			float[,] array = new float[base.Provider.Count, num];
			int num2 = num - values.GetLength(1);
			int num3 = ((num > values.GetLength(1)) ? num2 : 0);
			for (int i = 0; i < base.Provider.Count; i++)
			{
				for (int j = num3; j < num; j++)
				{
					array[i, j] = values[i, j - num2];
				}
			}
			values = array;
		}

		public override void RefreshGraph()
		{
			base.RefreshGraph();
			base.Target.material.SetFloat(StackedPropertyId, IsStacked ? 1f : 0f);
			int a = base.GraphValues * ((!IsStacked) ? 1 : base.Provider.Count);
			a = ((PlatformHelper.GetCurrentPlatform() != EPlatform.Mobile) ? Mathf.Min(a, 1024) : Mathf.Min(a, 512));
			base.Target.material.SetFloatArray(AGraphRenderer.ValuesPropertyId, new float[a]);
			base.Target.material.SetFloat(AGraphRenderer.ValueCountPropertyId, a);
			int num = a / base.Provider.Count;
			float[,] array = new float[base.Provider.Count, num];
			int num2 = num - values.GetLength(1);
			int num3 = ((num > values.GetLength(1)) ? num2 : 0);
			for (int i = 0; i < base.Provider.Count; i++)
			{
				for (int j = num3; j < num; j++)
				{
					array[i, j] = values[i, j - num2];
				}
			}
			values = array;
		}

		public override void OnNext(PerformanceData _Next)
		{
			int num = base.Provider.IndexOf(_Next.Sender);
			if (num >= 0)
			{
				AddValue(num, _Next.Value);
				UpdateGraph();
			}
		}

		private void AddValue(int _Index, float _Value)
		{
			float num = float.MaxValue;
			float num2 = 0f;
			float num3 = 0f;
			int num4 = 0;
			for (int i = 0; i < values.GetLength(1); i++)
			{
				if (i < values.GetLength(1) - 1)
				{
					values[_Index, i] = values[_Index, i + 1];
				}
				else
				{
					values[_Index, i] = _Value;
				}
				if (values[_Index, i] < num)
				{
					num = values[_Index, i];
				}
				if (values[_Index, i] > num2)
				{
					num2 = values[_Index, i];
				}
				if (values[_Index, i] > 0f)
				{
					num3 += values[_Index, i];
					num4++;
				}
			}
			minValues[_Index] = num;
			meanValues[_Index] = ((num4 > 0) ? (num3 / (float)num4) : 0f);
			maxValues[_Index] = num2;
		}

		private float[] FlattenAndScaleArray(float[,] _Array)
		{
			float[] array = new float[_Array.GetLength(0) * _Array.GetLength(1)];
			for (int i = 0; i < _Array.GetLength(0); i++)
			{
				for (int j = 0; j < _Array.GetLength(1); j++)
				{
					float num = maxValues[i];
					num = ((num == 0f) ? 1f : num);
					array[i * _Array.GetLength(1) + j] = _Array[i, j] / num;
				}
			}
			return array;
		}

		protected virtual void UpdateGraph()
		{
			base.Target.material.SetFloatArray(AGraphRenderer.ValuesPropertyId, FlattenAndScaleArray(values));
		}
	}
}
