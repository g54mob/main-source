using System;
using System.Runtime.CompilerServices;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	internal struct BakedCurve : IEffectCurve
	{
		public const int DefaultBakeSize = 360;

		private readonly int bakeSize;

		private readonly IEffectCurve original;

		private bool hasBeenBaked;

		private float[] bakedValues01;

		private float[] bakedValuesRange;

		public int BakeResolution
		{
			get
			{
				throw new Exception("Baking a baked curve should never be invoked.");
			}
		}

		public BakedCurve(IEffectCurve original)
		{
			this.original = original;
			bakedValues01 = null;
			bakedValuesRange = null;
			hasBeenBaked = false;
			bakeSize = ((original.BakeResolution > 0) ? original.BakeResolution : 360);
		}

		public void Bake()
		{
			if (!hasBeenBaked)
			{
				if (bakedValues01 == null)
				{
					bakedValues01 = new float[bakeSize];
				}
				if (bakedValuesRange == null)
				{
					bakedValuesRange = new float[bakeSize];
				}
				for (int i = 0; i < bakeSize; i++)
				{
					float time = (float)i / (float)(bakeSize - 1);
					bakedValues01[i] = original.Evaluate01(time);
					bakedValuesRange[i] = original.EvaluateRange(time);
				}
				hasBeenBaked = true;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate01(float time)
		{
			if (!hasBeenBaked)
			{
				return original.Evaluate01(time);
			}
			if (time < 0f)
			{
				time = 0f;
			}
			else if (time > 1f)
			{
				time = 1f;
			}
			float num = time * (float)(bakeSize - 1);
			int num2 = (int)num;
			float num3 = num - (float)num2;
			if (num2 >= bakeSize - 1)
			{
				return bakedValues01[bakeSize - 1];
			}
			return bakedValues01[num2] + (bakedValues01[num2 + 1] - bakedValues01[num2]) * num3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateRange(float time)
		{
			if (!hasBeenBaked)
			{
				return original.EvaluateRange(time);
			}
			if (time < 0f)
			{
				time = 0f;
			}
			else if (time > 1f)
			{
				time = 1f;
			}
			float num = time * (float)(bakeSize - 1);
			int num2 = (int)num;
			float num3 = num - (float)num2;
			if (num2 >= bakeSize - 1)
			{
				return bakedValuesRange[bakeSize - 1];
			}
			return bakedValuesRange[num2] + (bakedValuesRange[num2 + 1] - bakedValuesRange[num2]) * num3;
		}

		public void Initialize()
		{
		}
	}
}
