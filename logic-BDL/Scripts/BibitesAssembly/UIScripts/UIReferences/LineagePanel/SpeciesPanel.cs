using System.Collections.Generic;
using ManagementScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.InfoHandles;
using UnityEngine;
using Utility;

namespace UIScripts.UIReferences.LineagePanel
{
	public class SpeciesPanel : UIPanel
	{
		public static SpeciesPanel instance;

		[SerializeField]
		private LineageWindow lineageWindow;

		[SerializeField]
		private LineageMeshPanel meshPanel;

		[SerializeField]
		private LineageTreePanel treePanel;

		[SerializeField]
		private GameObject switchToDataButton;

		[SerializeField]
		private GameObject switchToTreeButton;

		[SerializeField]
		private SpeciesTabManager speciesTabManager;

		[SerializeField]
		private FloatValueTextHandle nRecordedSpecies;

		[SerializeField]
		private FloatValueTextHandle nDisplayedSpecies;

		public bool treeOrMesh = true;

		public LineagePanelSettingsManager lineageSettingsPanel;

		private Species selectedSpecies;

		public List<Species> displayedSpecies;

		public override void InitPanel()
		{
			if (!hasInit)
			{
				base.InitPanel();
				instance = this;
				lineageSettingsPanel.LoadUISettingsHandles();
				lineageWindow.Initialize();
				treePanel.InitPanel();
				meshPanel.InitPanel();
				switchToDataButton.SetActive(treeOrMesh);
				switchToTreeButton.SetActive(!treeOrMesh);
			}
		}

		public override void OpenPanel()
		{
			if (GlobalLineageManager.Instance.nRecords < 5)
			{
				PopupManager.DisplayDialog("Species Panel", "Not enough data collected, try again in a few minutes");
				return;
			}
			base.OpenPanel();
			lineageSettingsPanel.ClosePanel();
			UserControl.AllowControl = false;
			TimeController.Instance.TogglePauseGame("SpeciesPanel");
			speciesTabManager.SelectSpecies(null);
			nRecordedSpecies.UpdateValue(GlobalLineageManager.Instance.recordedSpecies.Count);
			GlobalLineageManager.Instance.UpdateEffectiveSpeciesSpan();
			lineageSettingsPanel.ShowSettingsOfType(treeOrMesh);
			if (treeOrMesh)
			{
				treePanel.SelectAndFocusSpecies();
			}
			else
			{
				meshPanel.SelectAndFocusSpecies();
			}
			if (treeOrMesh)
			{
				treePanel.OpenPanel();
			}
			else
			{
				meshPanel.OpenPanel();
			}
			if ((treeOrMesh && !treePanel.treeBuilt) || (!treeOrMesh && meshPanel.empty))
			{
				PopupManager.DisplayDialog("Species Panel", "Not enough data collected, try again in a few minutes");
				ClosePanel();
			}
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			if (treeOrMesh)
			{
				treePanel.ClosePanel();
			}
			else
			{
				meshPanel.ClosePanel();
			}
			speciesTabManager.CloseSpeciesPanels();
			lineageSettingsPanel.ClosePanel();
			selectedSpecies = null;
			UserControl.AllowControl = true;
			TimeController.Instance.TogglePauseGame("SpeciesPanel", isUnpause: true);
		}

		public void SelectPanel(bool tree)
		{
			treeOrMesh = tree;
			switchToDataButton.SetActive(treeOrMesh);
			switchToTreeButton.SetActive(!treeOrMesh);
			lineageWindow.ResetView();
			lineageSettingsPanel.ShowSettingsOfType(treeOrMesh);
			if (tree)
			{
				meshPanel.ClosePanel();
				treePanel.OpenPanel();
				if (selectedSpecies != null)
				{
					treePanel.SelectAndFocusSpecies(selectedSpecies);
				}
			}
			else
			{
				treePanel.ClosePanel();
				meshPanel.OpenPanel();
				if (selectedSpecies != null)
				{
					meshPanel.SelectAndFocusSpecies(selectedSpecies);
				}
			}
		}

		public void UpdateDisplayedSpecies(List<Species> displayed)
		{
			displayedSpecies = displayed;
			nDisplayedSpecies.UpdateValue(displayed.Count);
			speciesTabManager.RefillComparableSpecies(displayedSpecies);
		}

		public void OpenAndSelectSpecies(Species species)
		{
			OpenPanel();
			SelectAndFocusSpecies(species);
		}

		public void SelectAndFocusSpecies(Species species)
		{
			if (base.isActiveAndEnabled)
			{
				selectedSpecies = species;
				speciesTabManager.SelectSpecies(species);
				if (treeOrMesh)
				{
					treePanel.SelectAndFocusSpecies(species);
				}
				else
				{
					meshPanel.SelectAndFocusSpecies(species);
				}
			}
		}

		public void EditBibite()
		{
			BibiteTemplate bibiteToEdit = new BibiteTemplate(selectedSpecies.template);
			BibiteTemplateSelectorPanel.instance.OpenForBibiteEditor(bibiteToEdit);
		}

		public void OnSpeciesPruned(Species speciesPruned, Species mergeIntoSpecies)
		{
			if (treeOrMesh)
			{
				treePanel.BuildTree();
			}
			else
			{
				meshPanel.ResetState();
				meshPanel.GenerateMesh();
			}
			SelectAndFocusSpecies(mergeIntoSpecies);
		}
	}
}
