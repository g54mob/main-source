using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtBeltLightingTex : MonoBehaviour
	{
		public int Width;

		public TextureFormat Format;

		public float FrontPower;

		public float BackPower;

		public float BackStrength;

		public float BaseStrength;

		[NonSerialized]
		private SgtBelt cachedBelt;

		[NonSerialized]
		private bool cachedBeltSet;

		[NonSerialized]
		private Texture2D generatedTexture;

		public Texture2D GeneratedTexture => null;

		public void SetWidth(int value)
		{
		}

		public void SetFormat(TextureFormat value)
		{
		}

		public void SetFrontPower(float value)
		{
		}

		public void SetBackPower(float value)
		{
		}

		public void SetBackStrength(float value)
		{
		}

		public void SetBaseStrength(float value)
		{
		}

		public void UpdateTexture()
		{
		}

		private void WritePixel(float u, int x)
		{
		}

		public void ApplyTexture()
		{
		}

		public void RemoveTexture()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
