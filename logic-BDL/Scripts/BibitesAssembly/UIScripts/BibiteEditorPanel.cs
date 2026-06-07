using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using SteamIntegrations;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class BibiteEditorPanel : UIPanel
	{
		private List<FloatSettingSlider> geneSettings = new List<FloatSettingSlider>();

		private List<UnityAction> genesUpdateFunctions = new List<UnityAction>();

		private readonly Regex containsABadCharacter = new Regex("[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");

		private StringSimulationSetting speciesName = new StringSimulationSetting
		{
			Name = "Name",
			DefaultValue = "Bibite template",
			val = "Bibite template",
			HelperText = "Name that the template will be saved under"
		};

		private StringSimulationSetting speciesDesc = new StringSimulationSetting
		{
			Name = "Description",
			DefaultValue = "",
			val = "",
			HelperText = "Description saved with the bibite"
		};

		public BibiteBrainEditor brainEditor;

		public GameObject genesTab;

		public GameObject brainTab;

		public StringFieldHandle speciesNameHandle;

		public StringFieldHandle speciesDescHandle;

		public GameObject genesHolder;

		public Button saveAndContinueButton;

		public Button saveAndSubmitButton;

		public TextLineReference nameField;

		public TextLineReference descField;

		public GameObject incorrectWarning;

		public GameObject existingDefaultWarning;

		public GameObject existingWarning;

		[SerializeField]
		private BibiteEditorPreview editorPreview;

		[SerializeField]
		private ProceduralGenePreviewer previewer;

		private float[] genes;

		private List<NEATBrain.Node> nodes = new List<NEATBrain.Node>();

		private List<NEATBrain.Synaps> connections = new List<NEATBrain.Synaps>();

		private Dictionary<long, Vector2> nodeAnchors = new Dictionary<long, Vector2>();

		private bool savedUnderNewName;

		private bool anyChange;

		private UnityAction<BibiteTemplate> submitAction;

		private bool nameValid;

		public static UserActionCount savedBibiteCount = new UserActionCount("BibiteEditorSaved");

		public bool editingText
		{
			get
			{
				if (!speciesNameHandle.field.isFocused)
				{
					return speciesDescHandle.field.isFocused;
				}
				return true;
			}
		}

		public override void InitPanel()
		{
			genes = new float[BibiteGenes.NGene];
			brainEditor.Initialize();
			foreach (GeneSetting gene in BibiteEditorSettings.geneSettings)
			{
				FloatSettingSlider floatSettingSlider = new FloatSettingSlider(gene);
				floatSettingSlider.CreateUIElement(genesHolder);
				genesUpdateFunctions.Add(delegate
				{
					OnGeneSettingChanged((int)gene.gene);
				});
				gene.OnChange.AddListener(genesUpdateFunctions.Last());
				geneSettings.Add(floatSettingSlider);
			}
			speciesNameHandle = new StringFieldHandle(speciesName, nameField);
			speciesDescHandle = new StringFieldHandle(speciesDesc, descField);
			editorPreview.InitializePreview();
			previewer.InitializePreview();
			editorPreview.OpenPreview();
			editorPreview.ClosePreview();
			speciesName.Subscribe(CheckExistingBibite);
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			editorPreview.OpenPreview();
			editorPreview.ClosePreview();
			brainTab.SetActive(value: false);
			genesTab.SetActive(value: true);
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			submitAction = null;
		}

		public void OpenEditorEmpty()
		{
			EditTemplate(null);
		}

		public void EditTemplate(BibiteTemplate template, UnityAction<BibiteTemplate> actionOnSubmit = null)
		{
			OpenPanel();
			submitAction = actionOnSubmit;
			saveAndSubmitButton.gameObject.SetActive(actionOnSubmit != null);
			anyChange = false;
			if (template == null)
			{
				BibiteEditorSettings.geneSettings.ForEach(delegate(GeneSetting t)
				{
					t.ResetValue();
				});
				speciesName.ResetValue();
				speciesDesc.ResetValue();
				connections.Clear();
				nodeAnchors.Clear();
				NEATBrain.Node[] array = new NEATBrain.Node[NEATBrain.NInputs + NEATBrain.NOutputs];
				NEATBrain.SetBaseNeuronsTypeAndDesc(array);
				nodes = array.ToList();
				brainEditor.FillEditor(nodes, connections, nodeAnchors);
				return;
			}
			for (int num = 0; num < BibiteGenes.NGene; num++)
			{
				genes[num] = template.genes[num];
				BibiteEditorSettings.SettingOfGene(num).SetValue(genes[num]);
			}
			speciesName.SetValue(template.name ?? "");
			speciesDesc.SetValue(template.description);
			nodes = template.nodes.ToList();
			connections = template.synapses.ToList();
			nodeAnchors = template.nodeAnchors.ToDictionary((KeyValuePair<long, Vector2> k) => k.Key, (KeyValuePair<long, Vector2> k) => k.Value);
			brainEditor.FillEditor(nodes, connections, nodeAnchors);
		}

		private void OnGeneSettingChanged(int i)
		{
			genes[i] = BibiteEditorSettings.SettingOfGene(i).val;
			anyChange = true;
		}

		private void OnDestroy()
		{
			foreach (GeneSetting geneSetting in BibiteEditorSettings.geneSettings)
			{
				UnityAction unityAction = genesUpdateFunctions.FirstOrDefault();
				genesUpdateFunctions.Remove(unityAction);
				geneSetting.OnChange.RemoveListener(unityAction);
			}
			speciesName.UnSubscribe(CheckExistingBibite);
		}

		private void OnEditingText()
		{
		}

		public void SaveAndContinue()
		{
			SaveTemplate();
		}

		public void SaveSpriteOfBibite()
		{
			SpriteGenerator.instance.SaveSpriteOfPreview(previewer);
		}

		public string GetSavePath(string nameToCheck)
		{
			return Path.Combine(SaveSystem.bibiteTemplatePath, nameToCheck + ".bb8template");
		}

		public void CheckExistingBibite(string newName)
		{
			nameValid = !containsABadCharacter.IsMatch(newName);
			incorrectWarning.SetActive(!nameValid);
			nameValid &= !string.IsNullOrEmpty(newName);
			if (GameManager.defaultBibites.Contains(newName.ToLower()))
			{
				nameValid = false;
				existingDefaultWarning.SetActive(value: true);
			}
			else
			{
				existingDefaultWarning.SetActive(value: false);
				savedUnderNewName = !string.IsNullOrEmpty(newName) && !File.Exists(GetSavePath(newName));
				existingWarning.SetActive(!savedUnderNewName);
			}
			UpdateValidity();
		}

		public void UpdateValidity()
		{
			saveAndContinueButton.interactable = nameValid && brainEditor.valid;
			saveAndSubmitButton.interactable = nameValid && brainEditor.valid;
		}

		public BibiteTemplate SaveTemplate()
		{
			BibiteTemplate obj = new BibiteTemplate
			{
				name = speciesName.val,
				speciesName = speciesName.val,
				description = speciesDesc.val,
				genes = genes.ToArray()
			};
			brainEditor.PrepareForTemplateSave();
			obj.nodes = brainEditor.nodes.ToArray();
			obj.synapses = brainEditor.synapses.ToArray();
			obj.nodeAnchors = brainEditor.anchors.ToDictionary((KeyValuePair<NodeEditor, Vector2> k) => k.Key.node.Inov, (KeyValuePair<NodeEditor, Vector2> k) => k.Value);
			SaveSystem.SaveTemplate(obj);
			CheckExistingBibite(speciesName.val);
			if (anyChange || brainEditor.anyChange)
			{
				AchievementManager.Trigger("ACH_BIBITE_EDITOR");
				if (savedBibiteCount.Trigger() > 100)
				{
					AchievementManager.Trigger("ACH_BIBITE_EDITOR_100");
				}
			}
			return obj;
		}

		public void SaveAndSubmit()
		{
			if (submitAction != null)
			{
				submitAction(SaveTemplate());
			}
			else
			{
				SaveTemplate();
			}
			ClosePanel();
		}
	}
}
