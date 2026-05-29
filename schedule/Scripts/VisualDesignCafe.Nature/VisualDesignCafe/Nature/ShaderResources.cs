using System;
using UnityEngine;

namespace VisualDesignCafe.Nature
{
	[Serializable]
	public class ShaderResources
	{
		private const int _perlinNoiseResolution = 2048;

		private const float _perlinNoiseScale = 256f;

		private const float _perlinNoiseWhiteBalance = 1.2f;

		[SerializeField]
		private Texture2D _perlinNoise;

		public Texture2D PerlinNoise => null;

		public void SetFloatingOrigin(double x, double z)
		{
		}

		internal void Initialize()
		{
		}

		internal void Destroy()
		{
		}

		private Texture2D GeneratePerlinNoiseTexture()
		{
			return null;
		}
	}
}
