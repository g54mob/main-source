using System;
using Unity.Collections;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class TerrainTextureSettings
	{
		public AnimationCurve TextureHeightCurve;

		public AnimationCurve TextureSteepnessCurve;

		public bool UseNoise;

		public float NoiseScale = 5f;

		public float TextureWeight = 1f;

		public Vector2 NoiseOffset = Vector2.zero;

		public bool InverseNoise;

		public int TextureLayer;

		public bool Enabled = true;

		public bool LockTexture;

		public NativeArray<float> HeightCurveArray;

		public NativeArray<float> SteepnessCurveArray;

		public bool ConcaveEnable;

		public bool ConvexEnable;

		public bool ConcaveAverage = true;

		public float ConcaveMinHeightDifference = 5f;

		public float ConcaveDistance = 10f;

		public ConcaveMode ConcaveMode;
	}
}
