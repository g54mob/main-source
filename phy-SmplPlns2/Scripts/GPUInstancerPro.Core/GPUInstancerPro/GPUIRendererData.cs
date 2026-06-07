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

		public int optionalRendererNo;

		public LightProbeUsage lightProbeUsage;

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

		public GPUIRendererData(Mesh mesh, Material[] materials, Matrix4x4 transformOffset, int layer, ShadowCastingMode shadowCastingMode, bool receiveShadows, MotionVectorGenerationMode motionVectorGenerationMode, bool isSkinnedMesh, bool doesNotContributeToBounds, uint renderingLayerMask, LightProbeUsage lightProbeUsage, int forceMeshLod = -1)
		{
			if (transformOffset == Matrix4x4.zero || isSkinnedMesh)
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
			this.lightProbeUsage = ((lightProbeUsage != LightProbeUsage.Off) ? LightProbeUsage.BlendProbes : LightProbeUsage.Off);
		}

		public void InitializeReplacementMaterials(GPUIMaterialProvider materialProvider)
		{
			replacementMaterials = new Material[rendererMaterials.Length];
		}

		public void RemoveReplacementMaterials()
		{
			if (replacementMaterials != null)
			{
				for (int i = 0; i < replacementMaterials.Length; i++)
				{
					replacementMaterials[i] = null;
				}
			}
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
