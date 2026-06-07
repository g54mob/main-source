using System.Collections.Generic;
using ManagementScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.UIReferences.LineagePanel;
using UnityEngine;

namespace UIScripts
{
	public class SpeciesTabManager : TabsManager
	{
		public SpeciesInfoPanel infoPanel;

		public SpeciesGenesPanel genesPanel;

		public SpeciesBrainPanel brainPanel;

		public SpeciesDistributionPanel distributionPanel;

		[SerializeField]
		private GameObject tabsHolder;

		public List<Species> comparableSpecies;

		public List<TMP_Dropdown> comparedSpeciesDropdowns;

		private EscapableAction speciesSelected;

		private Species targetSpecies;

		protected override void Awake()
		{
			tabs = new List<UIPanel> { infoPanel, genesPanel, brainPanel, distributionPanel };
			speciesSelected = new EscapableAction(CloseSpeciesPanels);
			base.Awake();
			FlashPanels();
			SelectSpecies(null);
			foreach (TMP_Dropdown comparedSpeciesDropdown in comparedSpeciesDropdowns)
			{
				comparedSpeciesDropdown.onValueChanged.AddListener(SelectComparedSpeciesFromDropdown);
			}
		}

		public void FlashPanels()
		{
			tabs.ForEach(delegate(UIPanel p)
			{
				p.OpenPanel();
			});
			tabs.ForEach(delegate(UIPanel p)
			{
				p.ClosePanel();
			});
		}

		public void SelectSpecies(Species species)
		{
			if (targetSpecies == null && species != null)
			{
				UINavigationManager.AddEscapableToStack(speciesSelected);
			}
			targetSpecies = species;
			if (species == null)
			{
				CloseAllPanels();
				tabs.ForEach(delegate(UIPanel p)
				{
					p.ResetState();
				});
				tabsHolder.SetActive(value: false);
				return;
			}
			tabsHolder.SetActive(value: true);
			infoPanel.SelectSpecies(species);
			genesPanel.SelectSpecies(species);
			brainPanel.SelectSpecies(species);
			distributionPanel.SelectSpecies(species);
			tabButtons[selectedIndex].Select();
			Species species2 = species.parentSpecies ?? species;
			SelectToCompareSpecies(species2);
		}

		public void RefillComparableSpecies(List<Species> displayedSpecies)
		{
			comparableSpecies = displayedSpecies;
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			foreach (Species displayedSpecy in displayedSpecies)
			{
				list.Add(new TMP_Dropdown.OptionData(displayedSpecy.name));
			}
			foreach (TMP_Dropdown comparedSpeciesDropdown in comparedSpeciesDropdowns)
			{
				comparedSpeciesDropdown.options.Clear();
				comparedSpeciesDropdown.options = list;
			}
		}

		public void SelectComparedSpeciesFromDropdown(int i)
		{
			SelectToCompareSpecies(comparableSpecies[i]);
		}

		public void SelectToCompareSpecies(Species species)
		{
			int valueWithoutNotify = comparableSpecies.IndexOf(species);
			foreach (TMP_Dropdown comparedSpeciesDropdown in comparedSpeciesDropdowns)
			{
				comparedSpeciesDropdown.SetValueWithoutNotify(valueWithoutNotify);
			}
			genesPanel.UpdateCompared(species);
			brainPanel.UpdateCompared(species);
		}

		public void SelectParent()
		{
			SpeciesPanel.instance.SelectAndFocusSpecies(targetSpecies.parentSpecies);
		}

		public void SelectRoot()
		{
			SpeciesPanel.instance.SelectAndFocusSpecies(targetSpecies.rootSpecies);
		}

		public void CloseSpeciesPanels()
		{
			UINavigationManager.RemoveEscapableFromStack(speciesSelected);
			SpeciesPanel.instance?.SelectAndFocusSpecies(null);
		}
	}
}
