using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UIScripts.UIPanels;
using UIScripts.UIReferences.LineagePanel;
using UnityEngine;

namespace UIScripts
{
	public class GenesPanel : BibitePanel
	{
		[SerializeField]
		private FloatValueTextHandle geneDistance;

		[SerializeField]
		private TextMeshProUGUI speciesName;

		[SerializeField]
		private Transform genesHolder;

		[SerializeField]
		private GameObject genesLinePrefab;

		private readonly List<GeneLineInfo> geneLines = new List<GeneLineInfo>();

		private BibiteGenes genes;

		public override BibitePanels PanelIndex => BibitePanels.GenesPanel;

		public override void InitPanel()
		{
			foreach (GeneSetting geneSetting in BibiteEditorSettings.geneSettings)
			{
				GeneLineInfo component = Object.Instantiate(genesLinePrefab, genesHolder).GetComponent<GeneLineInfo>();
				component.Init(geneSetting);
				component.SetFontSize(16f);
				component.SetTitle("Difference from Species");
				geneLines.Add(component);
			}
		}

		public override void ResetState()
		{
			if (genes != null)
			{
				genes.species.onSpeciesChange.RemoveListener(UpdateName);
			}
		}

		public override void FillPanel()
		{
			genes = bibite.GetComponent<BibiteGenes>();
			if (!(genes == null))
			{
				Species species = genes.species;
				speciesName.text = species.name;
				geneDistance.UpdateValue(species.GeneDistanceToIndividual(genes.genes) / GlobalLineageManager.usedSpeciesSpan);
				geneLines.ForEach(delegate(GeneLineInfo g)
				{
					g.SetGene(genes.genes, species.template.genes);
				});
				float max = geneLines.Max((GeneLineInfo g) => g.contributionToSpeciation);
				geneLines.ForEach(delegate(GeneLineInfo g)
				{
					g.UpdateDifferenceColor(max);
				});
				species.onSpeciesChange.AddListener(UpdateName);
			}
		}

		public void OpenLineagePanelAndSelectSpecies()
		{
			SpeciesPanel.instance.OpenAndSelectSpecies(genes.species);
		}

		private void UpdateName()
		{
			speciesName.text = genes.species.name;
		}

		protected override void UpdatePanel()
		{
		}
	}
}
