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
		private bool isActive;

		[SerializeField]
		[HideInInspector]
		private bool customDepthEnabled;

		[SerializeField]
		[HideInInspector]
		private bool disableWidthControl;

		public RenderingLayerMask RenderingLayer;

		public OutlineRenderQueue renderQueue;

		public WideOutlineOcclusion occlusion;

		public CullingMode cullingMode;

		public bool closedLoop;

		public bool alphaCutout;

		public Texture2D alphaCutoutTexture;

		[Range(0f, 1f)]
		public float alphaCutoutThreshold;

		public Vector4 alphaCutoutUVTransform;

		public bool gpuInstancing;

		public bool vertexAnimation;

		[ColorUsage(true, true)]
		public Color color;

		[Range(0f, 100f)]
		public float width;

		private void OnEnable()
		{
		}

		private void EnsureMaterialsAreInitialized()
		{
		}

		public void AssignMaterials(Material source, Material sourceInstanced)
		{
		}

		public bool IsActive()
		{
			return false;
		}

		public void SetActive(bool active)
		{
		}

		public void SetAdvancedOcclusionEnabled(bool enable)
		{
		}

		public void SetWidthControl(WidthControl control)
		{
		}

		public void Cleanup()
		{
		}
	}
}
