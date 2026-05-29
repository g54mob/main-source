using System;
using UnityEngine;

namespace StylizedWater2
{
	[Serializable]
	public class WaveParameters
	{
		private const string WavesKeyword = "_WAVES";

		private static int _Direction;

		private static int _Speed;

		private static int _WaveDistance;

		private static int _WaveSpeed;

		private static int _WaveHeight;

		private static int _WaveSteepness;

		private static int _WaveCount;

		private static int _WaveDirection;

		public Vector2 animationDirection;

		public float animationSpeed;

		public int count;

		public float distance;

		public float speed;

		public float height;

		public float steepness;

		public Vector4 direction;

		public static bool WavesEnabled(Material waterMat)
		{
			return false;
		}

		public static float GetMaxWaveHeight(Material mat)
		{
			return 0f;
		}

		public void Update(Material waterMat)
		{
		}

		public void SetAsGlobal()
		{
		}

		public void Apply(Material mat)
		{
		}
	}
}
