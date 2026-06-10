using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Construction;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class MeshVariationHandler : MonoBehaviour
	{
		[SerializeField]
		private List<SlotMeshFilterPair> meshSlots;

		[SerializeField]
		private List<SlotRendererPair> meshRenderers;

		public void AssignMeshes(MeshFilter meshFilter)
		{
			foreach (SlotMeshFilterPair meshSlot in meshSlots)
			{
				meshSlot.ApplyFilter(meshFilter);
			}
		}

		public void AssignMeshes(Mesh mesh)
		{
			foreach (SlotMeshFilterPair meshSlot in meshSlots)
			{
				meshSlot.ApplyMesh(mesh);
			}
		}

		public void AssignRenderer(Renderer renderer)
		{
			foreach (SlotRendererPair meshRenderer in meshRenderers)
			{
				meshRenderer.AddRenderer(renderer);
			}
		}

		public void UpdateAllFromList(MeshVariationList variationList, string materialVariationsApplied)
		{
			if (variationList.IsRandom)
			{
				int index = Random.Range(0, variationList.Variations.Count);
				UpdateMeshVariation(variationList.Variations[index], materialVariationsApplied);
				return;
			}
			foreach (MeshVariation variation in variationList.Variations)
			{
				UpdateMeshVariation(variation, materialVariationsApplied);
			}
		}

		public void UpdateVariationByIndex(MeshVariationList variationList, int variationIndex, string materialVariationsApplied)
		{
			MeshVariation meshVariation = variationList.Variations.FirstOrDefault();
			if (meshVariation != null)
			{
				if (variationList.Variations.Count > 1)
				{
					int index = ((variationList.Variations.Count > variationIndex) ? variationIndex : 0);
					meshVariation = variationList.Variations[index];
				}
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\MeshVariationHandler.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Mesh Variation [");
					messageBuilder.AppendFormatted(variationIndex);
					messageBuilder.AppendLiteral("] : ");
					messageBuilder.AppendFormatted(meshVariation.Name);
				}
				Log.Trace(messageBuilder);
				UpdateMeshVariation(meshVariation, materialVariationsApplied);
			}
		}

		public void UpdateMeshVariation(MeshVariation meshVariation, string materialVariationsApplied)
		{
			if (meshVariation == null)
			{
				Log.Warning("Mesh variation is null!", "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\MeshVariationHandler.cs");
				return;
			}
			UpdateMesh(meshVariation);
			UpdateTextures(meshVariation, materialVariationsApplied);
			foreach (SlotPropertySetter slot in meshVariation.Slots)
			{
				if (slot.SlotType != SlotType.ShaderParam || slot.ShaderParam == null)
				{
					continue;
				}
				SlotRendererPair slotRendererPair = null;
				for (int i = 0; i < meshRenderers.Count; i++)
				{
					SlotRendererPair slotRendererPair2 = meshRenderers[i];
					if (slotRendererPair2.SlotName.Equals(slot.Slot))
					{
						slotRendererPair = slotRendererPair2;
						break;
					}
				}
				if (slotRendererPair == null)
				{
					continue;
				}
				foreach (Renderer renderer in slotRendererPair.Renderers)
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(49, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\MeshVariationHandler.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Applying shader parameter ");
						messageBuilder.AppendFormatted(renderer);
						messageBuilder.AppendLiteral(" for slot ");
						messageBuilder.AppendFormatted(slotRendererPair.SlotName);
						messageBuilder.AppendLiteral(". VARIATION: ");
						messageBuilder.AppendFormatted(meshVariation.Name);
					}
					Log.Trace(messageBuilder);
					slot.ShaderParam.TryApply(renderer);
				}
			}
		}

		private void UpdateTextures(MeshVariation meshVariation, string materialVariationsApplied)
		{
			if (!meshVariation.HasTextureSlots)
			{
				return;
			}
			foreach (SlotRendererPair meshRenderer in meshRenderers)
			{
				if (meshRenderer != null)
				{
					string textureName = meshVariation.GetTextureName(meshRenderer.SlotName);
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(40, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\MeshVariationHandler.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Applying texture ");
						messageBuilder.AppendFormatted(textureName);
						messageBuilder.AppendLiteral(" for slot ");
						messageBuilder.AppendFormatted(meshRenderer.SlotName);
						messageBuilder.AppendLiteral(". VARIATION: ");
						messageBuilder.AppendFormatted(meshVariation.Name);
					}
					Log.Trace(messageBuilder);
					meshRenderer.ApplyTexture(textureName, meshVariation, materialVariationsApplied);
				}
			}
		}

		private void UpdateMesh(MeshVariation variation)
		{
			if (!variation.HasMeshSlots)
			{
				return;
			}
			foreach (SlotMeshFilterPair meshSlot in meshSlots)
			{
				if (meshSlot != null)
				{
					string meshName = variation.GetMeshName(meshSlot.SlotName);
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(36, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\MeshVariationHandler.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Setting mesh ");
						messageBuilder.AppendFormatted(meshName);
						messageBuilder.AppendLiteral(" for slot ");
						messageBuilder.AppendFormatted(meshSlot.SlotName);
						messageBuilder.AppendLiteral(". VARIATION: ");
						messageBuilder.AppendFormatted(variation.Name);
					}
					Log.Trace(messageBuilder);
					meshSlot.ApplyMeshById(meshName);
				}
			}
		}

		public void UpdateMeshRotation(float rotation, bool flipX, bool flipZ)
		{
			foreach (SlotMeshFilterPair meshSlot in meshSlots)
			{
				meshSlot.ApplyRotation(rotation, flipX, flipZ);
			}
		}
	}
}
