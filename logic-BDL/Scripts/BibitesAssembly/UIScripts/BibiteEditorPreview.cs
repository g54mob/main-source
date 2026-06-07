using System.Collections.Generic;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.InfoHandles;
using UIScripts.UIReferences.Graphs;

namespace UIScripts
{
	public class BibiteEditorPreview : SettingPreviewer
	{
		public SingleLineGraph graphRef;

		public BibiteGrowthGraph graph = new BibiteGrowthGraph();

		public FloatValueTextHandle maturityAtBirth;

		public FloatValueTextHandle sizeAtMaturity;

		public FloatValueTextHandle lengthAtMaturity;

		public FloatValueTextHandle wombPercentage;

		public FloatValueTextHandle stomachPercentage;

		public FloatValueTextHandle fatPercentage;

		public FloatValueTextHandle armorPercentage;

		public FloatValueTextHandle throatPercentage;

		public FloatValueTextHandle jawPercentage;

		public FloatValueTextHandle moveMusclePercentage;

		public void OpenPreview()
		{
			base.gameObject.SetActive(value: true);
		}

		public void ClosePreview()
		{
			base.gameObject.SetActive(value: false);
		}

		public void ToggleOpenPreview()
		{
			base.gameObject.SetActive(!base.gameObject.activeSelf);
			graphRef.OnGraphHolderDimensionChanged();
		}

		public override void InitializePreview()
		{
			settings = new List<ChangingSetting>
			{
				BibiteEditorSettings.hatchTime,
				BibiteEditorSettings.broodTime,
				BibiteEditorSettings.sizeRatio,
				BibiteEditorSettings.speedRatio,
				BibiteEditorSettings.growthFactor,
				BibiteEditorSettings.growthMaturityExponent,
				BibiteEditorSettings.growthMaturityFactor
			};
			settings.AddRange(BibiteEditorSettings.WAGGSettings);
			graph.Init(graphRef);
			maturityAtBirth.InitFromSetup(new FloatValueFormat
			{
				SI = false,
				precisionIsSI = true,
				precision = 2
			});
			sizeAtMaturity.InitFromSetup(new FloatValueFormat
			{
				units = "u²",
				SI = false,
				precisionIsSI = true,
				precision = 2
			});
			lengthAtMaturity.InitFromSetup(new FloatValueFormat
			{
				units = "u",
				SI = true,
				precisionIsSI = true,
				precision = 2
			});
			wombPercentage.InitFromSetup(FloatValueFormat.percentage);
			stomachPercentage.InitFromSetup(FloatValueFormat.percentage);
			fatPercentage.InitFromSetup(FloatValueFormat.percentage);
			armorPercentage.InitFromSetup(FloatValueFormat.percentage);
			throatPercentage.InitFromSetup(FloatValueFormat.percentage);
			jawPercentage.InitFromSetup(FloatValueFormat.percentage);
			moveMusclePercentage.InitFromSetup(FloatValueFormat.percentage);
			base.InitializePreview();
		}

		protected override void UpdatePreview()
		{
			float[] geneArray = BibiteEditorSettings.geneArray;
			graph.UpdateCurve(geneArray);
			maturityAtBirth.UpdateValue(BibiteGenes.GrowthAtBirth(geneArray) / BibiteGenes.GrowthAtMature(geneArray));
			sizeAtMaturity.UpdateValue(BibiteGenes.AreaAtMature(geneArray));
			lengthAtMaturity.UpdateValue(BibiteGenes.LengthAtMature(geneArray));
			wombPercentage.UpdateValue(BibiteGenes.WombAreaPortion(geneArray));
			stomachPercentage.UpdateValue(BibiteGenes.StomachAreaPortion(geneArray));
			fatPercentage.UpdateValue(BibiteGenes.FatAreaPortion(geneArray));
			armorPercentage.UpdateValue(BibiteGenes.ArmorOrganAreaPortion(geneArray));
			throatPercentage.UpdateValue(BibiteGenes.ThroatAreaPortion(geneArray));
			jawPercentage.UpdateValue(BibiteGenes.JawAreaPortion(geneArray));
			moveMusclePercentage.UpdateValue(BibiteGenes.MoveMusclesAreaPortion(geneArray));
		}
	}
}
