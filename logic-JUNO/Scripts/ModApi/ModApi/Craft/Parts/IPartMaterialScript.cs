using System;
using System.Collections.Generic;
using ModApi.Craft.Parts.Events;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface IPartMaterialScript
	{
		bool FoundAttachPoint { get; set; }

		bool IsCollidingInDesigner { get; set; }

		bool IsDisabled { get; set; }

		bool IsDisconnected { get; set; }

		bool IsHighlighted { get; set; }

		bool IsSelected { get; set; }

		bool IsVisible { get; set; }

		Material[] OverrideMaterials { get; set; }

		IPartGroupScript PartGroup { get; }

		List<IRendererMaterialMap> RendererMaps { get; }

		event EventHandler<RendererEventArgs> RendererAdded;

		event EventHandler<RendererEventArgs> RendererRemoved;

		event EventHandler<EventArgs> StateChanged;

		void AddRenderer(Renderer renderer, bool? excludeFromCombine = null, bool? excludeFromDrag = null, Material[] originalMaterials = null);

		PartMaterial GetPartMaterial(int level);

		float GetPartMaterialIndex(int level);

		void OnMaterialsChanged();

		void RemoveRenderer(Renderer renderer);

		void SetMaterial(int material, int level);

		void UpdateRenderers();

		void UpdateTextureData();
	}
}
