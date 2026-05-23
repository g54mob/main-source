using Linework.Common.Utils;
using UnityEngine;

namespace Linework.WideOutline
{
	public class Outline : ScriptableObject
	{
		[SerializeField]
		[HideInInspector]
		public Material silhouetteMaterial;

		[SerializeField]
		[HideInInspector]
		public Material silhouetteMaterialInstanced;

		[SerializeField]
		[HideInInspector]
		public Material informationMaterial;

		[SerializeField]
		[HideInInspector]
		public Material informationMaterialInstanced;

		[SerializeField]
		[HideInInspector]
		private bool isActive = true;

		[SerializeField]
		[HideInInspector]
		private bool customDepthEnabled = true;

		[SerializeField]
		[HideInInspector]
		private bool disableWidthControl = true;

		public RenderingLayerMask RenderingLayer = RenderingLayerMask.defaultRenderingLayerMask;

		public LayerMask layerMask = -1;

		public OutlineRenderQueue renderQueue;

		public WideOutlineOcclusion occlusion;

		public CullingMode cullingMode;

		public bool closedLoop;

		public bool alphaCutout;

		public Texture2D alphaCutoutTexture;

		[Range(0f, 1f)]
		public float alphaCutoutThreshold = 0.5f;

		public Vector4 alphaCutoutUVTransform = Vector4.zero;

		public bool gpuInstancing;

		public bool vertexAnimation;

		[ColorUsage(true, true)]
		public Color color = Color.green;

		[Range(0f, 100f)]
		public float width = 20f;

		private void OnEnable()
		{
			EnsureMaterialsAreInitialized();
		}

		private void EnsureMaterialsAreInitialized()
		{
			if (silhouetteMaterial == null)
			{
				Shader shader = Shader.Find("Hidden/Outlines/Wide Outline/Silhouette");
				if (shader != null)
				{
					silhouetteMaterial = new Material(shader)
					{
						hideFlags = HideFlags.HideAndDontSave
					};
				}
			}
			if (silhouetteMaterialInstanced == null)
			{
				Shader shader2 = Shader.Find("Hidden/Outlines/Wide Outline/Silhouette Instanced");
				if (shader2 != null)
				{
					silhouetteMaterialInstanced = new Material(shader2)
					{
						hideFlags = HideFlags.HideAndDontSave,
						enableInstancing = true
					};
				}
			}
			if (informationMaterial == null)
			{
				Shader shader3 = Shader.Find("Hidden/Outlines/Wide Outline/Silhouette");
				if (shader3 != null)
				{
					informationMaterial = new Material(shader3)
					{
						hideFlags = HideFlags.HideAndDontSave
					};
				}
			}
			if (informationMaterialInstanced == null)
			{
				Shader shader4 = Shader.Find("Hidden/Outlines/Wide Outline/Silhouette Instanced");
				if (shader4 != null)
				{
					informationMaterialInstanced = new Material(shader4)
					{
						hideFlags = HideFlags.HideAndDontSave,
						enableInstancing = true
					};
				}
			}
		}

		public void AssignMaterials(Material source, Material sourceInstanced)
		{
			EnsureMaterialsAreInitialized();
			silhouetteMaterial.CopyPropertiesFromMaterial(source);
			silhouetteMaterialInstanced.CopyPropertiesFromMaterial(sourceInstanced);
			silhouetteMaterialInstanced.enableInstancing = gpuInstancing;
			informationMaterial.CopyPropertiesFromMaterial(source);
			informationMaterialInstanced.CopyPropertiesFromMaterial(sourceInstanced);
			informationMaterialInstanced.enableInstancing = gpuInstancing;
		}

		public bool IsActive()
		{
			return isActive;
		}

		public void SetActive(bool active)
		{
			isActive = active;
		}

		public void SetAdvancedOcclusionEnabled(bool enable)
		{
			customDepthEnabled = enable;
		}

		public void SetWidthControl(WidthControl control)
		{
			disableWidthControl = control == WidthControl.Shared;
		}

		public void Cleanup()
		{
			if (silhouetteMaterial != null)
			{
				Object.DestroyImmediate(silhouetteMaterial);
				silhouetteMaterial = null;
			}
			if (silhouetteMaterialInstanced != null)
			{
				Object.DestroyImmediate(silhouetteMaterialInstanced);
				silhouetteMaterialInstanced = null;
			}
			if (informationMaterial != null)
			{
				Object.DestroyImmediate(informationMaterial);
				informationMaterial = null;
			}
			if (informationMaterialInstanced != null)
			{
				Object.DestroyImmediate(informationMaterialInstanced);
				informationMaterialInstanced = null;
			}
		}
	}
}
