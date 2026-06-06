using System;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class CurveSerializeData
	{
		public float value;

		public bool useCurve;

		public AnimationCurve curve;

		public CurveSerializeData()
		{
		}

		public CurveSerializeData(float value)
		{
		}

		public CurveSerializeData(float value, float curveStart, float curveEnd, bool useCurve = true)
		{
		}

		public CurveSerializeData(float value, AnimationCurve curve)
		{
		}

		public void SetValue(float value)
		{
		}

		public void SetValue(float value, float curveStart, float curveEnd, bool useCurve = true)
		{
		}

		public void SetValue(float value, AnimationCurve curve)
		{
		}

		public void DataValidate(float min, float max)
		{
		}

		public float Evaluate(float time)
		{
			return 0f;
		}

		public float4x4 ConvertFloatArray()
		{
			return default(float4x4);
		}

		public CurveSerializeData Clone()
		{
			return null;
		}
	}
}
