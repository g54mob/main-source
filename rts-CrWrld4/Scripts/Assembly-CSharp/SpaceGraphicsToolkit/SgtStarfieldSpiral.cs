using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtStarfieldSpiral : SgtStarfield
	{
		[SgtSeed]
		public int Seed;

		public float Radius;

		public int ArmCount;

		public float Twist;

		public float ThicknessInner;

		public float ThicknessOuter;

		public float ThicknessPower;

		public int StarCount;

		public Gradient StarColors;

		public float StarRadiusMin;

		public float StarRadiusMax;

		public float StarRadiusBias;

		public float StarPulseMax;

		private static float armStep;

		private static float twistStep;

		public static SgtStarfieldSpiral Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtStarfieldSpiral Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
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
