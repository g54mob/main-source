using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtShadowSphere : SgtShadow
	{
		public int Width;

		public TextureFormat Format;

		public float SharpnessR;

		public float SharpnessG;

		public float SharpnessB;

		public float Opacity;

		public float RadiusMin;

		public float RadiusMax;

		[NonSerialized]
		private Texture2D generatedTexture;

		[SerializeField]
		[HideInInspector]
		private bool startCalled;

		public Texture2D GeneratedTexture => null;

		public override Texture GetTexture()
		{
			return null;
		}

		public void UpdateTexture()
		{
		}

		private void WriteTexture(float u, int x)
		{
		}

		public override void CalculateShadow(SgtLight light)
		{
		}

		private float GetRadius(float a, float b, float theta)
		{
			return 0f;
		}

		protected override void OnEnable()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		private void CheckUpdateCalls()
		{
		}
	}
}
