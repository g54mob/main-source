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
		private bool isActive = true;

		public RenderingLayerMask RenderingLayer = RenderingLayerMask.defaultRenderingLayerMask;

		public LayerMask layerMask = -1;

		public OutlineRenderQueue renderQueue;

		public Occlusion occlusion;

		public BlendingMode blendMode;

		public bool alphaCutout;

		public Texture2D alphaCutoutTexture;

		[Range(0f, 1f)]
		public float alphaCutoutThreshold = 0.5f;

		public MaterialType materialType;

		public Material customMaterial;

		public Pattern pattern = Pattern.Dots;

		[ColorUsage(true, true)]
		public Color primaryColor = Color.green;

		[ColorUsage(true, true)]
		public Color secondaryColor = Color.red;

		public Texture2D texture;

		public Channel channel;

		[Range(0.1f, 200f)]
		public float frequencyX = 40f;

		[Range(0.1f, 5f)]
		public float frequencyY = 2f;

		[Range(0f, 1f)]
		public float density = 0.5f;

		[Range(0f, 360f)]
		public float rotation;

		[Range(0f, 360f)]
		public float direction;

		[Range(0f, 1f)]
		public float offset;

		[Range(0f, 0.2f)]
		public float speed = 0.02f;

		[Range(0.1f, 100f)]
		public float scale = 1f;

		[Range(0f, 1f)]
		public float width = 0.3f;

		[Range(0f, 1f)]
		public float softness;

		[Range(0f, 2f)]
		public float power = 0.8f;

		private void OnEnable()
		{
			EnsureMaterialInitialized();
		}

		private void EnsureMaterialInitialized()
		{
			if (material == null)
			{
				Shader shader = Shader.Find("Hidden/Outlines/Fill");
				if (shader != null)
				{
					material = new Material(shader)
					{
						hideFlags = HideFlags.HideAndDontSave
					};
				}
			}
		}

		public void AssignMaterial(Material copyFrom)
		{
			EnsureMaterialInitialized();
			material.CopyPropertiesFromMaterial(copyFrom);
		}

		public bool IsActive()
		{
			return isActive;
		}

		public void SetActive(bool active)
		{
			isActive = active;
		}

		public void Cleanup()
		{
			if (material != null)
			{
				Object.DestroyImmediate(material);
				material = null;
			}
		}
	}
}
