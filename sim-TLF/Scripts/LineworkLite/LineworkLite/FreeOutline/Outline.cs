using LineworkLite.Common.Utils;
using UnityEngine;

namespace LineworkLite.FreeOutline
{
	public class Outline : ScriptableObject
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

		public Occlusion occlusion = Occlusion.WhenNotOccluded;

		public MaskingStrategy maskingStrategy;

		[ColorUsage(true, true)]
		public Color color = Color.green;

		public bool enableOcclusion;

		[ColorUsage(true, true)]
		public Color occludedColor = Color.red;

		public BlendingMode blendMode;

		public ExtrusionMethod extrusionMethod = ExtrusionMethod.ClipSpaceNormalVector;

		public Scaling scaling;

		[Range(0f, 100f)]
		public float width = 20f;

		[Range(0f, 100f)]
		public float minWidth;

		public bool scaleWithResolution;

		public Resolution referenceResolution;

		public float customResolution;

		public MaterialType materialType;

		public Material customMaterial;

		private void OnEnable()
		{
			EnsureMaterialsAreInitialized();
		}

		private void EnsureMaterialsAreInitialized()
		{
			if (material == null)
			{
				Shader shader = Shader.Find("Hidden/Outlines/Free Outline/Outline");
				if (shader != null)
				{
					material = new Material(shader)
					{
						hideFlags = HideFlags.HideAndDontSave
					};
				}
			}
		}

		public void AssignMaterials(Material copyFrom)
		{
			EnsureMaterialsAreInitialized();
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
