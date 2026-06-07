using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface IRendererMaterialMap
	{
		float AlphaOverride { get; set; }

		int CombinedMeshVertexCount { get; set; }

		int CombinedMeshVertexOffset { get; set; }

		Texture2D DecalTexture { get; set; }

		Vector4i DecalTextureMaterialLevels { get; set; }

		Vector4 DecalTextureOffsetAndTiling { get; set; }

		float EmissiveOverride { get; set; }

		bool ExcludeFromDragModel { get; }

		bool ExcludeFromMeshCombine { get; set; }

		bool HasCustomMaterial { get; }

		bool HasDecal { get; }

		bool HasTransparency { get; }

		bool IsTMProRenderer { get; }

		Mesh Mesh { get; }

		Material[] OriginalMaterials { get; }

		IPartMaterialScript PartMaterialScript { get; }

		bool RenderBeforeDepthMask { get; }

		Renderer Renderer { get; }

		bool[] TrimLevelsUsed { get; }

		bool UsesAlphaOverride { get; set; }

		bool UsesEmissiveOverride { get; set; }

		bool WasMeshCombined { get; set; }

		void ApplyDecalTexture();

		void ApplyEmissiveOverride();

		void ApplyMaterials();

		void Destroy();

		void EndTempRender();

		void ReplaceOriginalMaterials(Material material, bool setAsCurrent);

		void SetRendererMaterial(Material[] materials);

		void SetRendererMaterial(Material material);

		void StartTempRender(int layer, Material material);

		void UpdateMaterialPropertyBlock(MaterialPropertyBlock materialPropertyBlock);
	}
}
