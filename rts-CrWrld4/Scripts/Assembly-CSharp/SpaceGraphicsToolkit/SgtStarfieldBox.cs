using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtStarfieldBox : SgtStarfield
	{
		[SgtSeed]
		public int Seed;

		public Vector3 Extents;

		public float Offset;

		public float Bias;

		public int StarCount;

		public Gradient StarColors;

		public float StarRadiusMin;

		public float StarRadiusMax;

		public float StarRadiusBias;

		public float StarPulseMax;

		public static SgtStarfieldBox Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtStarfieldBox Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		protected override int BeginQuads()
		{
			return 0;
		}

		protected override void NextQuad(ref SgtStarfieldStar star, int starIndex)
		{
		}

		protected override void EndQuads()
		{
		}
	}
}
