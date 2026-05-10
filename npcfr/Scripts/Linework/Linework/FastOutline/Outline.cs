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
		private bool isActive;

		public RenderingLayerMask RenderingLayer;

		public OutlineRenderQueue renderQueue;

		public Occlusion occlusion;

		public MaskingStrategy maskingStrategy;

		[ColorUsage(true, true)]
		public Color color;

		public bool enableOcclusion;

		[ColorUsage(true, true)]
		public Color occludedColor;

		public BlendingMode blendMode;

		public bool gpuInstancing;

		public ExtrusionMethod extrusionMethod;

		public Scaling scaling;

		[Range(0f, 100f)]
		public float width;

		[Range(0f, 100f)]
		public float minWidth;

		public MaterialType materialType;

		public Material customMaterial;

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

		public void Cleanup()
		{
		}
	}
}
