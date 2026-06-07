using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtStarfieldNebula : SgtStarfield
	{
		public enum SourceType
		{
			None = 0,
			Red = 1,
			Green = 2,
			Blue = 3,
			Alpha = 4,
			AverageRgb = 5,
			MinRgb = 6,
			MaxRgb = 7
		}

		[SgtSeed]
		public int Seed;

		public Texture SourceTex;

		public float Threshold;

		public int Samples;

		public float Jitter;

		public SourceType HeightSource;

		public SourceType ScaleSource;

		public Vector3 Size;

		public float HorizontalBrightness;

		public float HorizontalPower;

		public int StarCount;

		public float StarRadiusMin;

		public float StarRadiusMax;

		public float StarRadiusBias;

		public float StarPulseMax;

		private static Texture2D sourceTex2D;

		private static Vector3 halfSize;

		public static SgtStarfieldNebula Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtStarfieldNebula Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		protected override int BeginQuads()
		{
			return 0;
		}

		protected override void NextQuad(ref SgtStarfieldStar quad, int starIndex)
		{
		}

		protected override void EndQuads()
		{
		}

		protected override void CameraPreCull(Camera camera)
		{
		}

		private float GetWeight(SourceType source, Color pixel, float defaultWeight)
		{
			return 0f;
		}
	}
}
