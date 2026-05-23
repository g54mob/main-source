using Linework.Common.Utils;
using UnityEngine;

namespace Linework.SoftOutline
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
		private bool isActive;

		[SerializeField]
		[HideInInspector]
		private bool disableColor;

		public RenderingLayerMask RenderingLayer;

		public OutlineRenderQueue renderQueue;

		public SoftOutlineOcclusion occlusion;

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

		private void OnEnable()
		{
		}

		private void EnsureMaterialsAreInitialized()
		{
		}

		public void AssignMaterials(Material copyFrom, Material copyFromInstanced)
		{
		}

		public bool IsActive()
		{
			return false;
		}

		public void SetActive(bool active)
		{
		}

		public void SetOutlineType(OutlineType type)
		{
		}

		public void Cleanup()
		{
		}
	}
}
