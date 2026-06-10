using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class BaseBuildablePreview : MonoBehaviour
	{
		[SerializeField]
		private List<SlotMeshFilterPair> meshSlots;

		[SerializeField]
		private List<MeshRenderer> previewMeshRenderers = new List<MeshRenderer>();

		[NonSerialized]
		private BaseBuildingBlueprint blueprint;

		public BaseBuildingBlueprint Blueprint => blueprint;

		public event Action<BaseBuildingBlueprint> InitializeEvent;

		public event Action UpdateEvent;

		private void OnDestroy()
		{
			this.InitializeEvent = null;
			this.UpdateEvent = null;
			blueprint = null;
		}

		public void Initialize(BaseBuildingBlueprint blueprint)
		{
			this.blueprint = blueprint;
			this.InitializeEvent?.Invoke(this.blueprint);
		}

		public void Refresh()
		{
			this.UpdateEvent?.Invoke();
		}

		public void SetMesh(BaseBuildingBlueprint blueprint)
		{
			if (string.IsNullOrEmpty(blueprint.GetDefaultMeshId()))
			{
				return;
			}
			Mesh meshByAddress = MonoRepository<MeshRepository, KeyGameObjectPair>.Instance.GetMeshByAddress(blueprint.GetDefaultMeshId());
			if (!(meshByAddress == null))
			{
				MeshFilter component = GetComponent<MeshFilter>();
				if (!(component == null))
				{
					component.mesh = meshByAddress;
				}
			}
		}

		public void UpdateMeshVariations(IReadOnlyList<string> variationsApplied, BaseBuildingBlueprint blueprint)
		{
			if (variationsApplied == null || variationsApplied.Count == 0)
			{
				return;
			}
			foreach (string item in variationsApplied)
			{
				UpdateMeshVariation(item, blueprint);
			}
		}

		public void UpdateMeshVariation(string meshVariationName, BaseBuildingBlueprint blueprint)
		{
			if (meshSlots == null || meshSlots.Count == 0)
			{
				return;
			}
			MeshVariation meshVariation = blueprint.GetMeshVariation(meshVariationName);
			if (meshVariation == null || !meshVariation.HasMeshSlots)
			{
				return;
			}
			foreach (SlotMeshFilterPair meshSlot in meshSlots)
			{
				if (meshSlot != null)
				{
					string meshName = meshVariation.GetMeshName(meshSlot.SlotName);
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(37, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\BaseBuildablePreview.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Setting mesh ");
						messageBuilder.AppendFormatted(meshName);
						messageBuilder.AppendLiteral(" for slot ");
						messageBuilder.AppendFormatted(meshSlot.SlotName);
						messageBuilder.AppendLiteral(". VARIATION:  ");
						messageBuilder.AppendFormatted(meshVariation.Name);
					}
					Log.Info(messageBuilder);
					meshSlot.ApplyMeshById(meshName);
				}
			}
		}

		public void UpdateMeshRotation(BaseBuildingInstance buildableBaseObject)
		{
			foreach (SlotMeshFilterPair meshSlot in meshSlots)
			{
				meshSlot.ApplyRotation(buildableBaseObject.RotateMeshVariation, buildableBaseObject.FlipXMeshVariation, buildableBaseObject.FlipZMeshVariation);
			}
		}

		public void SetReplacementView(float shaderValue, int layer)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetFloat("_materialChange", shaderValue);
			foreach (MeshRenderer previewMeshRenderer in previewMeshRenderers)
			{
				if (!(previewMeshRenderer == null))
				{
					previewMeshRenderer.SetPropertyBlock(materialPropertyBlock);
					previewMeshRenderer.gameObject.layer = layer;
				}
			}
		}
	}
}
