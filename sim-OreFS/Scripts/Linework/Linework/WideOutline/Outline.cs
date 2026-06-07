using Linework.Common.Utils;
using UnityEngine;

namespace Linework.WideOutline
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

		[SerializeField]
		[HideInInspector]
		private bool customDepthEnabled = true;

		public RenderingLayerMask RenderingLayer = RenderingLayerMask.defaultRenderingLayerMask;

		public WideOutlineOcclusion occlusion;

		public CullingMode cullingMode;

		public bool closedLoop;

		public bool alphaCutout;

		public Texture2D alphaCutoutTexture;

		[Range(0f, 1f)]
		public float alphaCutoutThreshold = 0.5f;

		public bool gpuInstancing;

		public bool vertexAnimation;

		[ColorUsage(true, true)]
		public Color color = Color.green;

		private void OnEnable()
		{
			EnsureMaterialsAreInitialized();
		}

		private void EnsureMaterialsAreInitialized()
		{
			if (material == null)
			{
				Shader shader = Shader.Find("Hidden/Outlines/Wide Outline/Silhouette");
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
				Shader shader2 = Shader.Find("Hidden/Outlines/Wide Outline/Silhouette Instanced");
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

		public void SetAdvancedOcclusionEnabled(bool enable)
		{
			customDepthEnabled = enable;
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
