using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class UMADefaultMeshCombiner : UMAMeshCombiner
	{
		protected List<SkinnedMeshCombiner.CombineInstance> combinedMeshList;

		protected List<UMAData.GeneratedMaterial> combinedMaterialList;

		private UMAData umaData;

		private int atlasResolution;

		private UMAClothProperties clothProperties;

		private int currentRendererIndex;

		private SkinnedMeshRenderer[] renderers;

		protected void EnsureUMADataSetup(UMAData umaData)
		{
		}

		private SkinnedMeshRenderer MakeRenderer(int i, UMAData umaData, Transform rootBone, UMARendererAsset rendererAsset = null)
		{
			return null;
		}

		public override void UpdateUMAMesh(bool updatedAtlas, UMAData umaData, int atlasResolution)
		{
		}

		public static void SetCompositingParameters(Material secondPass, UMAData.GeneratedMaterial cm)
		{
		}

		public static void CopyMaterialTextures(Material secondPass, Material material, UMAMaterial uMAMaterial)
		{
		}

		protected UMAMeshData ApplyMeshModifiers(UMAData umaData, UMAMeshData meshData, SlotData slotData)
		{
			return null;
		}

		protected void BuildCombineInstances()
		{
		}

		protected void RecalculateUV(UMAMeshData umaMesh)
		{
		}
	}
}
