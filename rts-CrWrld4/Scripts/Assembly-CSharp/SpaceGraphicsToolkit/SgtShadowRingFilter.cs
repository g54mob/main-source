using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtShadowRingFilter : MonoBehaviour
	{
		public Texture2D Source;

		public TextureFormat Format;

		public int Iterations;

		public bool ShareRGB;

		public bool Invert;

		[NonSerialized]
		private Texture2D generatedTexture;

		[NonSerialized]
		private SgtShadowRing cachedShadowRing;

		[NonSerialized]
		private bool cachedShadowRingSet;

		[NonSerialized]
		private static Color[] bufferA;

		[NonSerialized]
		private static Color[] bufferB;

		public Texture2D GeneratedTexture => null;

		public SgtShadowRing CachedShadowRing => null;

		public void UpdateTexture()
		{
		}

		public void ApplyTexture()
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

		private void WritePixel(int x)
		{
		}

		private void SwapBuffers()
		{
		}
	}
}
