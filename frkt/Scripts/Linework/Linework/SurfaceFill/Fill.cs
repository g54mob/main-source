using Linework.Common.Utils;
using UnityEngine;

namespace Linework.SurfaceFill
{
	public class Fill : ScriptableObject
	{
		[SerializeField]
		[HideInInspector]
		public Material material;

		[SerializeField]
		[HideInInspector]
		private bool isActive;

		public RenderingLayerMask RenderingLayer;

		public Occlusion occlusion;

		public BlendingMode blendMode;

		public bool alphaCutout;

		public Texture2D alphaCutoutTexture;

		[Range(0f, 1f)]
		public float alphaCutoutThreshold;

		public MaterialType materialType;

		public Material customMaterial;

		public Pattern pattern;

		[ColorUsage(true, true)]
		public Color primaryColor;

		[ColorUsage(true, true)]
		public Color secondaryColor;

		public Texture2D texture;

		public Channel channel;

		[Range(0.1f, 200f)]
		public float frequencyX;

		[Range(0.1f, 5f)]
		public float frequencyY;

		[Range(0f, 1f)]
		public float density;

		[Range(0f, 360f)]
		public float rotation;

		[Range(0f, 360f)]
		public float direction;

		[Range(0f, 1f)]
		public float offset;

		[Range(0f, 0.2f)]
		public float speed;

		[Range(0.1f, 100f)]
		public float scale;

		[Range(0f, 1f)]
		public float width;

		[Range(0f, 1f)]
		public float softness;

		[Range(0f, 2f)]
		public float power;

		private void OnEnable()
		{
		}

		private void EnsureMaterialInitialized()
		{
		}

		public void AssignMaterial(Material copyFrom)
		{
		}

		public bool IsActive()
		{
			return false;
		}

		public void SetActive(bool active)
		{
		}

		public void Cleanup()
		{
		}
	}
}
