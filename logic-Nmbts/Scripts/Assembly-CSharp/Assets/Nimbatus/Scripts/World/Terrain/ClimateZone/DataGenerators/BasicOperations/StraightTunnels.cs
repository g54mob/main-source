using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class StraightTunnels : NimbatusDataGenerator
	{
		private int currentTunnelCount;

		private float[] tunnelAngle;

		[MinMaxSlider(0f, 8f, false)]
		public Vector2Int tunnelCount;

		public float tunnelThickness = 100f;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			currentTunnelCount = RandomGenerator.Next(tunnelCount.x, tunnelCount.y + 1);
			tunnelAngle = new float[currentTunnelCount];
			for (int i = 0; i < currentTunnelCount; i++)
			{
				tunnelAngle[i] = (float)RandomGenerator.Next(0, 360) * ((float)Math.PI / 180f);
			}
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			if (currentTunnelCount > 0)
			{
				float[] array = new float[currentTunnelCount];
				for (int i = 0; i < currentTunnelCount; i++)
				{
					array[i] = GetNewValue(worldPosition, tunnelAngle[i]);
				}
				return Mathf.Max(array);
			}
			return 0f;
		}

		private float GetNewValue(Vector2 worldPosition, float inReferenceAngle)
		{
			Vector2 a = worldPosition;
			float magnitude = a.magnitude;
			float num = inReferenceAngle;
			num = Mathf.Repeat(num + (float)Math.PI * 2f, (float)Math.PI * 2f);
			Vector2 vector = new Vector2(Mathf.Cos(num) * magnitude, Mathf.Sin(num) * magnitude);
			Vector2 b = Mathf.Clamp01(Vector2.Dot(a.normalized, vector.normalized)) * vector;
			float value = Vector2.Distance(a, b);
			value = Mathf.InverseLerp(tunnelThickness, 0f, value);
			return Mathf.Clamp01(value);
		}
	}
}
