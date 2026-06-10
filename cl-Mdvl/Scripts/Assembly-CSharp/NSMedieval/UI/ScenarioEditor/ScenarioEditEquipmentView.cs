using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditEquipmentView : ScenarioEditResourceView
	{
		[SerializeField]
		private DropdownLayoutItemView qualityDropdown;

		[SerializeField]
		private DropdownLayoutItemView materialDropdown;

		private ProductQuality quality = ProductQuality.Good;

		private string material;

		private List<string> materials;

		public void SetDefaults(string itemId, IntRange minMaxRange, int currentValue)
		{
			if (minMaxRange.Min == minMaxRange.Max)
			{
				base.IntInput.gameObject.SetActive(value: false);
			}
			Resource protoItemById = Repository<ResourceRepository, Resource>.Instance.GetProtoItemById(itemId);
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(itemId);
			bool isEnabled;
			if (protoItemById == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\ScenarioEditEquipmentView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(itemId);
					messageBuilder.AppendLiteral(" resource is null!");
				}
				Log.Error(messageBuilder);
				return;
			}
			SetDefaults(protoItemById, minMaxRange, currentValue);
			IEnumerable<string> optionValues = from quality in EnumValues.ProductionQualities.ToList().FindAll((ProductQuality quality) => quality != ProductQuality.None)
				select base.Localize.GetText($"quality_{quality}");
			quality = ((byID == null || byID.Quality == ProductQuality.None) ? quality : byID.Quality);
			qualityDropdown.SetData(optionValues, OnQualityValueChange);
			qualityDropdown.SetValueWithoutNotify((int)(quality - 1));
			materialDropdown.gameObject.SetActive(value: false);
			if (protoItemById.Materials != null && protoItemById.Materials.Length != 0 && !protoItemById.Materials.Any((string s) => s.Equals(string.Empty)))
			{
				materialDropdown.gameObject.SetActive(value: true);
				materials = protoItemById.Materials.ToList();
				List<string> list = new List<string>();
				foreach (string material in materials)
				{
					MaterialSettings byID2 = Repository<MaterialSettingsRepository, MaterialSettings>.Instance.GetByID(material);
					if (byID2 == null)
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\ScenarioEditEquipmentView.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("MaterialSettings not found for id '");
							messageBuilder.AppendFormatted(material);
							messageBuilder.AppendLiteral("', skipping.");
						}
						Log.Error(messageBuilder);
					}
					else
					{
						list.Add(base.Localize.GetText(LocKeyUtils.GetName(byID2.LocKeys)));
					}
				}
				materialDropdown.SetData(list, OnMaterialValueChange);
				this.material = ((byID == null) ? materials.FirstOrDefault() : byID.Material);
				materialDropdown.SetValueWithoutNotify(materials.IndexOf(this.material));
			}
			OnInputValueChanged(base.IntInput.text);
		}

		protected override void OnInputValueChanged(string value)
		{
			int value2 = ScenarioEditEntryView.Clamp(value, base.MinMaxRange);
			base.IntInput.SetTextWithoutNotify(value2.ToString());
			StringBuilder stringBuilder = new StringBuilder(quality.ToString().ToLower());
			if (!string.IsNullOrEmpty(material))
			{
				stringBuilder.Append("_" + material);
			}
			stringBuilder.Append("_" + base.ResourceID);
			Notify(value2, stringBuilder.ToString());
		}

		private void OnQualityValueChange(int i)
		{
			quality = (ProductQuality)(i + 1);
			OnInputValueChanged(base.IntInput.text);
		}

		private void OnMaterialValueChange(int i)
		{
			material = materials[i];
			OnInputValueChanged(base.IntInput.text);
		}
	}
}
