using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;

namespace UIScripts
{
	public class SpeciesGenesPanel : UIPanel
	{
		[SerializeField]
		private FloatValueTextHandle parentGeneDistance;

		[SerializeField]
		private FloatValueTextHandle comparedGeneDistance;

		[SerializeField]
		private TextMeshProUGUI speciesName;

		[SerializeField]
		private GameObject parentSpeciesButton;

		[SerializeField]
		private GameObject parentSpeciesNone;

		[SerializeField]
		private TextMeshProUGUI parentSpeciesName;

		[SerializeField]
		private Transform genesHolder;

		[SerializeField]
		private GameObject genesLinePrefab;

		private readonly List<GeneLineInfo> geneLines = new List<GeneLineInfo>();

		private Species targetSpecies;

		private Species comparedSpecies;

		public override void InitPanel()
		{
			if (geneLines.Count > 0)
			{
				return;
			}
			foreach (GeneSetting geneSetting in BibiteEditorSettings.geneSettings)
			{
				GeneLineInfo component = Object.Instantiate(genesLinePrefab, genesHolder).GetComponent<GeneLineInfo>();
				component.Init(geneSetting);
				component.SetFontSize(14f);
				component.SetTitle("Difference from target");
				geneLines.Add(component);
			}
		}

		public void SelectSpecies(Species species)
		{
			targetSpecies = species;
			FillPanel();
		}

		public override void FillPanel()
		{
			speciesName.text = targetSpecies.name;
			Species parentSpecies = targetSpecies.parentSpecies;
			if (parentSpecies == null)
			{
				parentGeneDistance.gameObject.SetActive(value: false);
				parentSpeciesButton.SetActive(value: false);
				parentSpeciesNone.SetActive(value: true);
			}
			else
			{
				parentGeneDistance.gameObject.SetActive(value: true);
				parentGeneDistance.UpdateValue(targetSpecies.GeneDistanceToIndividual(parentSpecies.template.genes) / GlobalLineageManager.usedSpeciesSpan);
				parentSpeciesButton.SetActive(value: true);
				parentSpeciesNone.SetActive(value: false);
				parentSpeciesName.text = parentSpecies.name;
			}
			targetSpecies.onSpeciesChange.AddListener(UpdateName);
		}

		public void UpdateCompared(Species toCompare)
		{
			comparedSpecies = toCompare;
			geneLines.ForEach(delegate(GeneLineInfo g)
			{
				g.SetGene(targetSpecies.template.genes, comparedSpecies?.template.genes);
			});
			float max = geneLines.Max((GeneLineInfo g) => g.contributionToSpeciation);
			geneLines.ForEach(delegate(GeneLineInfo g)
			{
				g.UpdateDifferenceColor(max);
			});
			comparedGeneDistance.UpdateValue(targetSpecies.GeneDistanceToIndividual(toCompare.template.genes));
		}

		public override void ResetState()
		{
			targetSpecies?.onSpeciesChange.RemoveListener(UpdateName);
		}

		private void UpdateName()
		{
			speciesName.text = targetSpecies.name;
		}

		protected override void UpdatePanel()
		{
		}
	}
}
