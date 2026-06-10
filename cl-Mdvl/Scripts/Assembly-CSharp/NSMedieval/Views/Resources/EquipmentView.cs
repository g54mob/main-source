using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class EquipmentView : MonoBehaviour
	{
		[SerializeField]
		protected MeshVariationHandler meshVariationHandler;

		[SerializeField]
		protected MaterialMeshParameters materialMeshParameters;

		[SerializeField]
		protected Transform meshPrefabParent;

		private Resource blueprint;

		public virtual void Setup(Resource resource)
		{
			blueprint = resource;
			blueprint.GetEquippedTransformSettings()?.ApplyToTransform(meshPrefabParent);
			materialMeshParameters.UpdateParameters(resource.Material);
			ChangeMeshAccordingToResourceQuality();
			UpdateMaterialParameters();
		}

		private void ChangeMeshAccordingToResourceQuality()
		{
			if (!MeshVariationUtils.GetQualityVariations(blueprint.VariationsById, out var variationList))
			{
				return;
			}
			if (!TryParseProductQuality(blueprint.GetID(), out var quality))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\EquipmentView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Couldn't parse ");
					messageBuilder.AppendFormatted(blueprint.GetID());
				}
				Log.Error(messageBuilder);
			}
			else
			{
				int num = Mathf.Clamp((int)(quality - 1), 0, EnumValues.ProductionQualities.Length);
				num = ((variationList.Variations.Count >= num) ? num : 0);
				meshVariationHandler.UpdateVariationByIndex(variationList, num, null);
			}
		}

		private void UpdateMaterialParameters()
		{
			if (!MeshVariationUtils.GetMaterialParameters(blueprint.VariationsById, out var variationList))
			{
				return;
			}
			if (meshVariationHandler == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(0, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\EquipmentView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(blueprint.GetID());
				}
				Log.Error(messageBuilder);
			}
			else
			{
				meshVariationHandler.UpdateAllFromList(variationList, null);
			}
		}

		private bool TryParseProductQuality(string input, out ProductQuality quality)
		{
			quality = ProductQuality.None;
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			string[] array = input.Split('_');
			foreach (string str in array)
			{
				if (Enum.TryParse(typeof(ProductQuality), Capitalize(str), ignoreCase: true, out var result))
				{
					quality = (ProductQuality)result;
					return true;
				}
			}
			return false;
			static string Capitalize(string text)
			{
				return char.ToUpper(text[0]) + text.Substring(1).ToLower();
			}
		}
	}
}
