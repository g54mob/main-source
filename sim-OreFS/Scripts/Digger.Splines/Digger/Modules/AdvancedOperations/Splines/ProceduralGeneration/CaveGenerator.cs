using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.AdvancedOperations.Splines.ProceduralGeneration
{
	public class CaveGenerator
	{
		private float minY;

		private float maxY;

		private float altitudeVariationFrequency;

		private float horizontalVariationFrequency;

		private float step;

		private int stepCount;

		private int seed1;

		private int seed2;

		private int seed3;

		public CaveGenerator(float step = 4f, int stepCount = 100, float minY = -20f, float maxY = 20f, float altitudeVariationFrequency = 0.03f, float horizontalVariationFrequency = 0.05f, int seed1 = 1337, int seed2 = 13, int seed3 = 17)
		{
			this.stepCount = stepCount;
			this.step = step;
			this.minY = minY;
			this.maxY = maxY;
			this.altitudeVariationFrequency = altitudeVariationFrequency;
			this.horizontalVariationFrequency = horizontalVariationFrequency;
			this.seed1 = seed1;
			this.seed2 = seed2;
			this.seed3 = seed3;
		}

		public void GeneratePoints(Vector3 startPosition, BezierSpline spline)
		{
			FastNoise fastNoise = new FastNoise(seed1, horizontalVariationFrequency);
			FastNoise fastNoise2 = new FastNoise(seed2, horizontalVariationFrequency);
			FastNoise fastNoise3 = new FastNoise(seed3, altitudeVariationFrequency);
			float3 float5 = new float3(startPosition);
			spline.transform.position = float5;
			float num = math.lerp(minY, maxY, math.clamp(fastNoise3.GetSimplex(float5.x, float5.z) * 0.5f + 0.5f, 0f, 1f));
			startPosition.y -= num;
			for (int i = 0; i < stepCount; i++)
			{
				float5.x += fastNoise.GetSimplex(i, 0f) * step;
				float5.z += fastNoise2.GetSimplex(i, 0f) * step;
				float5.y = startPosition.y + math.lerp(minY, maxY, math.clamp(fastNoise3.GetSimplex(float5.x, float5.z) * 0.5f + 0.5f, 0f, 1f));
				if (i == 0)
				{
					spline.ForceReset(float5);
				}
				else
				{
					spline.AddCurve(BezierControlPointMode.Aligned, float5);
				}
			}
		}
	}
}
