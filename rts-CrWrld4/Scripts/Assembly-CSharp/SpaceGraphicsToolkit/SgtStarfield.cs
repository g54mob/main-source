using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtStarfield : SgtQuads
	{
		public bool PowerRgb;

		public bool Stretch;

		public Vector3 StretchVector;

		public float StretchScale;

		public float StretchLimit;

		public bool Near;

		public Texture NearTex;

		public float NearThickness;

		public bool Pulse;

		public float PulseOffset;

		public float PulseSpeed;

		protected override string ShaderName => null;

		public void UpdateNearTex()
		{
		}

		public SgtStarfieldCustom MakeEditableCopy(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		public SgtStarfieldCustom MakeEditableCopy(int layer = 0, Transform parent = null)
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void BuildMaterial()
		{
		}

		protected abstract void NextQuad(ref SgtStarfieldStar quad, int starIndex);

		protected override void BuildMesh(Mesh mesh, int starIndex, int starCount)
		{
		}

		protected virtual void CameraPreCull(Camera camera)
		{
		}

		protected virtual void CameraPreRender(Camera camera)
		{
		}

		private void UpdatePulse()
		{
		}
	}
}
