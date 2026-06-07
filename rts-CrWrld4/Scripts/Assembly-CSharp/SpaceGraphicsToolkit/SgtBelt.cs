using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtBelt : SgtQuads
	{
		public float OrbitOffset;

		public float OrbitSpeed;

		public bool Lit;

		public Texture LightingTex;

		public Color AmbientColor;

		public bool PowerRgb;

		[NonSerialized]
		private bool renderedThisFrame;

		protected override string ShaderName => null;

		public void SetOrbitOffset(float value)
		{
		}

		public void SetOrbitSpeed(float value)
		{
		}

		public void SetLit(bool value)
		{
		}

		public void SetLightingTex(Texture value)
		{
		}

		public void SetAmbientColor(Color value)
		{
		}

		public void SetPowerRgb(bool value)
		{
		}

		public SgtBeltCustom MakeEditableCopy(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public SgtBeltCustom MakeEditableCopy(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		public virtual void UpdateLightingTex()
		{
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

		protected abstract void NextQuad(ref SgtBeltAsteroid quad, int starIndex);

		protected override void BuildMesh(Mesh mesh, int asteroidIndex, int asteroidCount)
		{
		}

		private void ObserverPreRender(SgtCamera observer)
		{
		}

		protected void CameraPreRender(Camera camera)
		{
		}
	}
}
