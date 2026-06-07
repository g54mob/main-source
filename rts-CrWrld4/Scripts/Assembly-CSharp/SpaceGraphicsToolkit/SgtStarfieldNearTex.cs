using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtStarfieldNearTex : MonoBehaviour
	{
		public int Width;

		public TextureFormat Format;

		public SgtEase.Type Ease;

		public float Sharpness;

		public float Offset;

		[NonSerialized]
		private Texture2D generatedTexture;

		[NonSerialized]
		private SgtStarfield cachedStarfield;

		[NonSerialized]
		private bool cachedStarfieldSet;

		public Texture2D GeneratedTexture => null;

		public void UpdateTexture()
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

		private void WritePixel(float u, int x)
		{
		}
	}
}
