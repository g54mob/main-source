using Linework.Common.Utils;
using UnityEngine;

namespace Linework.FastOutline
{
	public class Outline : ScriptableObject
	{
		[SerializeField]
		[HideInInspector]
		public Material material;

		[SerializeField]
		[HideInInspector]
		public Material materialInstanced;

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

		public bool gpuInstancing;

		public ExtrusionMethod extrusionMethod = ExtrusionMethod.ClipSpaceNormalVector;

		public Scaling scaling;

		[Range(0f, 100f)]
		public float width = 20f;

		[Range(0f, 100f)]
		public float minWidth;

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
				Shader shader = Shader.Find("Hidden/Outlines/Fast Outline/Outline");
				if (shader != null)
				{
					material = new Material(shader)
					{
						hideFlags = HideFlags.HideAndDontSave
					};
				}
			}
			if (materialInstanced == null)
			{
				Shader shader2 = Shader.Find("Hidden/Outlines/Fast Outline/Outline Instanced");
				if (shader2 != null)
				{
					materialInstanced = new Material(shader2)
					{
						hideFlags = HideFlags.HideAndDontSave,
						enableInstancing = true
					};
				}
			}
		}

		public void AssignMaterials(Material copyFrom, Material copyFromInstanced)
		{
			EnsureMaterialsAreInitialized();
			material.CopyPropertiesFromMaterial(copyFrom);
			materialInstanced.CopyPropertiesFromMaterial(copyFromInstanced);
			materialInstanced.enableInstancing = gpuInstancing;
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
			if (materialInstanced != null)
			{
				Object.DestroyImmediate(materialInstanced);
				materialInstanced = null;
			}
		}
	}
}
