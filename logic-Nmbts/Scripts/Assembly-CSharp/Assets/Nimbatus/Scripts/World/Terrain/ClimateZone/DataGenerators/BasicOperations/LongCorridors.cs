using System;
using LibNoise;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class LongCorridors : NimbatusDataGenerator
	{
		private LibNoise.Perlin _perlinNoise;

		private LibNoise.Perlin _displacementNoise;

		private const float Lacunarity = 1.5f;

		private const int OctaveCount = 1;

		private int currentConnectionsCount;

		private float[] connectionAngle;

		[MinMaxSlider(0f, 8f, false)]
		public Vector2Int connectionsCount;

		public float connectionsHeight = 100f;

		public float perlinSize = 0.1f;

		public float displacementSize = 0.1f;

		public float displacementStrength = 10f;

		public float corridorHeight = 20f;

		public float corridorHeightDifference = 30f;

		public int corridorSteps = 3;

		public NimbatusDataGenerator corridorRadius;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			corridorRadius.Init(zone, random, ref set);
			currentConnectionsCount = RandomGenerator.Next(connectionsCount.x, connectionsCount.y + 1);
			connectionAngle = new float[currentConnectionsCount];
			for (int i = 0; i < currentConnectionsCount; i++)
			{
				connectionAngle[i] = (float)RandomGenerator.Next(0, 360) * ((float)System.Math.PI / 180f);
			}
			_perlinNoise = new LibNoise.Perlin
			{
				Seed = RandomGenerator.Next(),
				Frequency = perlinSize * 100f,
				Lacunarity = 1.5,
				OctaveCount = 1,
				NoiseQuality = NoiseQuality.Low
			};
			_displacementNoise = new LibNoise.Perlin
			{
				Seed = RandomGenerator.Next(),
				Frequency = displacementSize,
				Lacunarity = 1.5,
				OctaveCount = 1,
				NoiseQuality = NoiseQuality.Standard
			};
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			Vector2 vector = new Vector2((float)_displacementNoise.GetValue(worldPosition.x, worldPosition.y, 0.0), (float)_displacementNoise.GetValue(worldPosition.y + 1000f, worldPosition.x + 1000f, 0.0));
			Vector2 vector2 = worldPosition + vector * displacementStrength;
			float magnitude = vector2.magnitude;
			float num = Mathf.Atan2(vector2.y, vector2.x);
			num = Mathf.Repeat(num + (float)System.Math.PI * 2f, (float)System.Math.PI * 2f);
			float num2 = (float)_perlinNoise.GetValue(num / ((float)System.Math.PI * 2f), 0.0, 0.0);
			num2 = (num2 + 1f) / 2f;
			num2 = Step01(num2, corridorSteps);
			num2 = (num2 - 0.5f) * 2f;
			float x = Mathf.Cos(num) * (corridorRadius.GetValue(vector2, previousValue) + num2 * corridorHeightDifference);
			float y = Mathf.Sin(num) * (corridorRadius.GetValue(vector2, previousValue) + num2 * corridorHeightDifference);
			float num3 = Vector2.Distance(b: new Vector2(x, y), a: vector2);
			float[] array = new float[currentConnectionsCount];
			float num4 = 0f;
			float num5 = 0f;
			Vector2 zero = Vector2.zero;
			for (int i = 0; i < currentConnectionsCount; i++)
			{
				num4 = Mathf.Cos(connectionAngle[i]) * magnitude;
				num5 = Mathf.Sin(connectionAngle[i]) * magnitude;
				if (Vector2.Distance(b: new Vector2(num4, num5), a: vector2) < corridorHeight && magnitude > corridorRadius.GetValue(vector2, previousValue) - corridorHeight && magnitude < corridorRadius.GetValue(vector2, previousValue) + connectionsHeight)
				{
					array[i] = 1f;
				}
				else
				{
					array[i] = 0f;
				}
			}
			float a = Mathf.Max(array);
			float num6 = 0f;
			num6 = ((!(num3 < corridorHeight)) ? 0f : 1f);
			return Mathf.Max(a, num6);
		}

		private float Step01(float value, int steps)
		{
			return Mathf.Floor(value * (float)steps) / (float)steps;
		}
	}
}
