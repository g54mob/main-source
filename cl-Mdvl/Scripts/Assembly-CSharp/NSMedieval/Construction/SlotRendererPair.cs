using System;
using System.Collections.Generic;
using Managers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.Construction
{
	[Serializable]
	public class SlotRendererPair
	{
		[SerializeField]
		private string slotName;

		[SerializeField]
		private string textureSlot;

		[FormerlySerializedAs("meshRenderers")]
		[SerializeField]
		private List<Renderer> renderers;

		public string SlotName => slotName;

		public List<Renderer> Renderers => renderers;

		public void AddRenderer(Renderer renderer)
		{
			if (renderers == null)
			{
				renderers = new List<Renderer>();
			}
			renderers.Add(renderer);
		}

		public void ApplyTexture(string textureName, MeshVariation meshVariation, string materialVariationsApplied)
		{
			if (string.IsNullOrEmpty(textureName) || !MonoSingleton<MaterialPropertyBlockManager>.IsInstantiated() || renderers == null)
			{
				return;
			}
			Texture byAddress = MonoRepository<TextureRepository, KeyTexturePair>.Instance.GetByAddress(textureName);
			string materialVariationsApplied2 = ((!string.IsNullOrEmpty(materialVariationsApplied)) ? materialVariationsApplied : meshVariation.GetHashCode().ToString());
			if (byAddress == null)
			{
				return;
			}
			foreach (Renderer renderer in renderers)
			{
				if (renderer == null)
				{
					continue;
				}
				List<Material> materials = MeshVariationMaterialManager.GetMaterials(renderer, materialVariationsApplied2);
				foreach (Material item in materials)
				{
					if (item.HasProperty(textureSlot) && byAddress != null)
					{
						item.SetTexture(textureSlot, byAddress);
					}
				}
				renderer.SetSharedMaterials(materials);
			}
		}
	}
}
