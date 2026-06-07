using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtBackdrop : SgtQuads
	{
		[SgtSeed]
		public int Seed;

		public float Radius;

		public float Squash;

		public int StarCount;

		[SerializeField]
		private Gradient starColors;

		public float StarRadiusMin;

		public float StarRadiusMax;

		public float StarRadiusBias;

		public bool PowerRgb;

		public bool ClampSize;

		public float ClampSizeMin;

		private static List<Vector3> positions;

		private static List<Color32> colors32;

		private static List<Vector2> coords1;

		private static List<Vector3> coords2;

		private static List<int> indices;

		public Gradient StarColors => null;

		protected override string ShaderName => null;

		public void SetSeed(int value)
		{
		}

		public void SetRadius(float value)
		{
		}

		public void SetSquash(float value)
		{
		}

		public void SetStarCount(int value)
		{
		}

		public void SetStarCount(float value)
		{
		}

		public void SetStarRadiusMin(float value)
		{
		}

		public void SetStarRadiusMax(float value)
		{
		}

		public void SetStarRadiusBias(float value)
		{
		}

		public void SetPowerRgb(bool value)
		{
		}

		public void SetClampSize(bool value)
		{
		}

		public void SetClampSizeMin(float value)
		{
		}

		public static SgtBackdrop Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtBackdrop Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void BuildMaterial()
		{
		}

		protected override int BeginQuads()
		{
			return 0;
		}

		protected virtual void NextQuad(ref SgtBackdropQuad star, int starIndex)
		{
		}

		protected override void EndQuads()
		{
		}

		protected override void BuildMesh(Mesh mesh, int starIndex, int starCount)
		{
		}

		protected virtual void CameraPreCull(Camera camera)
		{
		}

		protected void CameraPreRender(Camera camera)
		{
		}
	}
}
