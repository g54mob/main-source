using System;
using System.Text.RegularExpressions;
using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UIScripts.UIReferences;
using UIScripts.UIReferences.LineagePanel;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
	public class SpeciesInfoPanel : UIPanel
	{
		[SerializeField]
		private RectTransform nameGroup;

		[SerializeField]
		private TextMeshProUGUI speciesName;

		[SerializeField]
		private TextMeshProUGUI speciesID;

		[SerializeField]
		private TMP_InputField speciesNameEditor;

		[SerializeField]
		private LayoutElement nameEditorLayout;

		[SerializeField]
		private GameObject formatWarning;

		private Regex speciesTest = new Regex("^[A-Z][a-z]+ [a-z]+$");

		[SerializeField]
		private GameObject parentSpeciesButton;

		[SerializeField]
		private GameObject parentSpeciesNone;

		[SerializeField]
		private TextMeshProUGUI parentSpeciesName;

		[SerializeField]
		private TextMeshProUGUI rootSpeciesName;

		[SerializeField]
		private TMP_InputField speciesNotes;

		[SerializeField]
		private Toggle favoriteToggle;

		[SerializeField]
		private Button selectButton;

		[SerializeField]
		private Button pruneButton;

		[SerializeField]
		private TooltipTrigger selectTooltip;

		[SerializeField]
		private TextMeshProUGUI timeOfCreation;

		[SerializeField]
		private FloatValueTextHandle genOfCreation;

		[SerializeField]
		private BibiteTemplateGenePreviewer preview;

		[SerializeField]
		private FloatValueTextHandle memberCount;

		[SerializeField]
		private FloatValueTextHandle descendantCount;

		private Species targetSpecies;

		public override void InitPanel()
		{
			preview.InitializePreview();
		}

		public void SelectSpecies(Species species)
		{
			targetSpecies = species;
			FillPanel();
		}

		public override void FillPanel()
		{
			speciesName.text = targetSpecies.name;
			speciesID.text = targetSpecies.speciesID.ToString();
			preview.UpdateTemplate(targetSpecies.template);
			speciesNotes.SetTextWithoutNotify(targetSpecies.description);
			Species parentSpecies = targetSpecies.parentSpecies;
			if (parentSpecies == null)
			{
				parentSpeciesButton.SetActive(value: false);
				parentSpeciesNone.SetActive(value: true);
			}
			else
			{
				parentSpeciesButton.SetActive(value: true);
				parentSpeciesNone.SetActive(value: false);
				parentSpeciesName.text = parentSpecies.name;
			}
			rootSpeciesName.text = targetSpecies.rootSpecies.name;
			memberCount.UpdateValue(targetSpecies.count);
			descendantCount.UpdateValue(targetSpecies.GetDescendantCount());
			favoriteToggle.isOn = targetSpecies.favorite;
			bool flag = targetSpecies.count > 0;
			selectButton.interactable = flag;
			pruneButton.interactable = !targetSpecies.absoluteKeep && !flag && targetSpecies.speciesData.totalIndexOfDisappearance > 0;
			selectTooltip.UpdateText("Select Bibite of Species", (targetSpecies.count > 1) ? "" : "There are no bibites of this species");
			formatWarning.SetActive(value: false);
			TimeSpan timeSpan = TimeSpan.FromSeconds(targetSpecies.timeCreation);
			timeOfCreation.text = $"{timeSpan.Days}d {timeSpan.Hours}:{timeSpan.Minutes}";
			genOfCreation.UpdateValue(targetSpecies.generationOfFirstSpecimen);
		}

		public void EditSpeciesName()
		{
			float width = nameGroup.rect.width;
			nameGroup.gameObject.SetActive(value: false);
			speciesNameEditor.gameObject.SetActive(value: true);
			speciesNameEditor.text = targetSpecies.name;
			speciesNameEditor.Select();
			nameEditorLayout.minWidth = width;
			UserControl.SetKeyboardBlockFromSource("SpeciesNameEdit", block: true);
		}

		public void OnNameEdit()
		{
			formatWarning.SetActive(!AssertSpeciesFormat(speciesNameEditor.text));
		}

		public void OnNotesEdit(string val)
		{
			targetSpecies.description = val;
		}

		public void FinishEditing()
		{
			UserControl.SetKeyboardBlockFromSource("SpeciesNameEdit", block: false);
			string text = speciesNameEditor.text;
			if (AssertSpeciesFormat(text))
			{
				string[] array = text.Split(' ');
				targetSpecies.genericName = array[0];
				targetSpecies.specificName = array[1];
				targetSpecies.template.name = text;
				targetSpecies.template.speciesName = text;
				targetSpecies.Changed();
				speciesName.text = text;
			}
			nameGroup.gameObject.SetActive(value: true);
			speciesNameEditor.gameObject.SetActive(value: false);
			formatWarning.SetActive(value: false);
		}

		public bool AssertSpeciesFormat(string text)
		{
			bool flag = speciesTest.IsMatch(text);
			formatWarning.SetActive(!flag);
			return flag;
		}

		public void SetFavorite(bool value)
		{
			targetSpecies.favorite = value;
			pruneButton.interactable = !targetSpecies.absoluteKeep && targetSpecies.count > 0 && targetSpecies.speciesData.totalIndexOfDisappearance > 0;
		}

		public void PruneSpecies()
		{
			PopupManager.DisplayActionWarning(ActionWarnings.pruneSpeciesActionWarning, ActuallyPruneSpecies);
		}

		private void ActuallyPruneSpecies()
		{
			Species mergeIntoSpecies = GlobalLineageManager.Instance.PruneSpeciesFromTree(targetSpecies);
			SpeciesPanel.instance.OnSpeciesPruned(targetSpecies, mergeIntoSpecies);
		}

		public void SaveSpecies()
		{
			targetSpecies.template.description = targetSpecies.description;
			targetSpecies.template.generation = targetSpecies.generationOfFirstSpecimen;
			SaveController.Instance.SaveTemplateOfBibite(targetSpecies.template);
		}

		public void PlaceSpecies()
		{
			SpeciesPanel.instance.ClosePanel();
			BibitePlacer.instance.PlaceBibitesFromTemplate(targetSpecies.template);
		}

		public void SelectRandomOfSpecies()
		{
			if (targetSpecies.count >= 1)
			{
				SpeciesPanel.instance.ClosePanel();
				UserControl.Instance.SelectRandomBibiteOfSpecies(targetSpecies);
			}
		}
	}
}
