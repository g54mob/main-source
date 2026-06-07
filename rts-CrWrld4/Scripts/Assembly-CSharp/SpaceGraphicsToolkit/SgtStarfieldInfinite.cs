using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtStarfieldInfinite : SgtStarfield
	{
		public float Softness;

		public bool Far;

		public Texture FarTex;

		public float FarRadius;

		public float FarThickness;

		[SgtSeed]
		public int Seed;

		public Vector3 Size;

		public int StarCount;

		public Gradient StarColors;

		public float StarRadiusMin;

		public float StarRadiusMax;

		public float StarRadiusBias;

		public float StarPulseMax;

		protected override string ShaderName => null;

		public void UpdateFarTex()
		{
		}

		public static SgtStarfieldInfinite Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtStarfieldInfinite Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void FloatingCameraSnap(SgtFloatingCamera floatingCamera, Vector3 delta)
		{
		}

		protected override void BuildMaterial()
		{
		}

		protected override int BeginQuads()
		{
			return 0;
		}

		protected override void NextQuad(ref SgtStarfieldStar star, int starIndex)
		{
		}

		protected override void BuildMesh(Mesh mesh, int starIndex, int starCount)
		{
		}

		protected override void EndQuads()
		{
		}

		protected override void CameraPreCull(Camera camera)
		{
		}

		protected override void CameraPreRender(Camera camera)
		{
		}
	}
}
