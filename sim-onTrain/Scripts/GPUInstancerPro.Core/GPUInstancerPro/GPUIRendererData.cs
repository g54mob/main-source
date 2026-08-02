using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	[Serializable]
	public class GPUIRendererData : IGPUIDisposable, IDisposable
	{
		public Mesh rendererMesh;

		public Material[] rendererMaterials;

		public Matrix4x4 transformOffset;

		public int layer;

		public ShadowCastingMode shadowCastingMode = ShadowCastingMode.On;

		public bool receiveShadows;

		public MotionVectorGenerationMode motionVectorGenerationMode;

		public bool isSkinnedMesh;

		public bool doesNotContributeToBounds;

		public uint renderingLayerMask;

		[NonSerialized]
		public Material[] replacementMaterials;

		[NonSerialized]
		public Mesh replacementMesh;

		public bool IsShadowCasting => shadowCastingMode != ShadowCastingMode.Off;

		public bool IsShadowsOnly => shadowCastingMode == ShadowCastingMode.ShadowsOnly;

		public GPUIRendererData()
		{
			transformOffset = Matrix4x4.identity;
			rendererMaterials = new Material[0];
		}

		public GPUIRendererData(Mesh mesh, Material[] materials, Matrix4x4 transformOffset, int layer, ShadowCastingMode shadowCastingMode, bool receiveShadows, MotionVectorGenerationMode motionVectorGenerationMode, bool isSkinnedMesh, bool doesNotContributeToBounds, uint renderingLayerMask)
		{
			if (transformOffset == Matrix4x4.zero)
			{
				transformOffset = Matrix4x4.identity;
			}
			rendererMesh = mesh;
			rendererMaterials = materials;
			this.transformOffset = transformOffset;
			this.layer = layer;
			this.shadowCastingMode = shadowCastingMode;
			this.receiveShadows = receiveShadows;
			this.motionVectorGenerationMode = motionVectorGenerationMode;
			this.isSkinnedMesh = isSkinnedMesh;
			this.doesNotContributeToBounds = doesNotContributeToBounds;
			this.renderingLayerMask = renderingLayerMask;
		}

		public void InitializeReplacementMaterials(GPUIMaterialProvider materialProvider)
		{
			replacementMaterials = new Material[rendererMaterials.Length];
		}

		public Mesh GetMesh()
		{
			if (replacementMesh != null)
			{
				return replacementMesh;
			}
			return rendererMesh;
		}

		public void ReleaseBuffers()
		{
		}

		public void Dispose()
		{
			if (replacementMesh != null)
			{
				replacementMesh.DestroyGeneric();
			}
		}
	}
}
