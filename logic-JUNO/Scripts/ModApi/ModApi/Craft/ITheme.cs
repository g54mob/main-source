using System;
using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Craft
{
	public interface ITheme
	{
		Material[] PartMaterialsAttached { get; }

		Material[] PartMaterialsBdm { get; }

		Material[] PartMaterialsCollision { get; }

		Material[] PartMaterialsDefault { get; }

		Material[] PartMaterialsDisconnected { get; }

		Material[] PartMaterialsHidden { get; }

		Material[] PartMaterialsHighlighted { get; }

		Material[] PartMaterialsSelected { get; }

		Material[] PartMaterialsTransparent { get; }

		IPartStateColors PartStateColors { get; }

		event EventHandler<EventArgs> PartMaterialsChanged;

		Material[] GetDefaultPartTMProMaterial(string materialKey);

		float GetMaterialIndex(int materialId);

		void RefreshAll();

		void RefreshMaterialProperties();

		void ReleaseDefaultPartMaterialInstance(Material material);

		void ReleasePartTMProMaterialInstance(string materialKey, Material material);

		void ReleaseTransparentPartMaterialInstance(Material material);

		Material RequestDefaultPartMaterialInstance();

		Material RequestPartTMProMaterialInstance(string materialKey);

		Material RequestTransparentPartMaterialInstance();

		void UpdateMaterialRenderQueues(Material[] partMaterials, PartMeshRenderQueue renderQueue);

		void UpdateThemeMaterial(int materialId);

		void UpdateThemeMaterial(int materialId, Color color, float smoothness, float metallicness, float detailStrength, float emissionStrength);
	}
}
