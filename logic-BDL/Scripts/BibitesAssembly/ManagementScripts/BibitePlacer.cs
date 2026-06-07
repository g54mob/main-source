using Newtonsoft.Json.Linq;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.EventSystems;
using Utility;

namespace ManagementScripts
{
	public class BibitePlacer : UIPanel
	{
		private string templateJsonContent;

		private JObject json;

		public GameObject placementPanel;

		public static BibitePlacer instance;

		private static readonly BibiteSettings settings = new BibiteSettings();

		private ChoiceSettingDropdown<ChoiceSetting<Tagging>, Tagging> taggingDropdown = new ChoiceSettingDropdown<ChoiceSetting<Tagging>, Tagging>(settings.tagging);

		private ChoiceSettingDropdown<ChoiceSetting<RandomizeGenes>, RandomizeGenes> randomizeGenesDropdown = new ChoiceSettingDropdown<ChoiceSetting<RandomizeGenes>, RandomizeGenes>(settings.randomizeGenes);

		private ChoiceSettingDropdown<ChoiceSetting<GrowthAtSpawn>, GrowthAtSpawn> growthAtSpawnDropdown = new ChoiceSettingDropdown<ChoiceSetting<GrowthAtSpawn>, GrowthAtSpawn>(settings.growthAtSpawn);

		private StringFieldHandle customTag = new StringFieldHandle(settings.customTag);

		[SerializeField]
		private SettingDropdownReference taggingDropdownRef;

		[SerializeField]
		private TextLineReference customTagRef;

		[SerializeField]
		private SettingDropdownReference randomGeneDropdownRef;

		[SerializeField]
		private SettingDropdownReference stageDropdownRef;

		private bool placementModeEnabled;

		private BibiteTemplate template;

		private Camera cam;

		public override void InitPanel()
		{
			randomizeGenesDropdown.InitUIElement(randomGeneDropdownRef);
			taggingDropdown.InitUIElement(taggingDropdownRef);
			growthAtSpawnDropdown.InitUIElement(stageDropdownRef);
			customTag.InitUIElement(customTagRef);
			settings.tagging.Subscribe(TaggingChanged);
			TaggingChanged(settings.tagging.val);
			placementPanel.SetActive(value: false);
			instance = this;
			cam = Camera.main;
		}

		protected override void UpdatePanel()
		{
			if (placementModeEnabled && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
			{
				Vector3 value = cam.ScreenToWorldPoint(Input.mousePosition);
				value.z = 0f;
				WorldObjectsSpawner worldObjectsSpawner = WorldObjectsSpawner.Instance;
				BibiteTemplate bibiteTemplate = template;
				RandomizeGenes val = settings.randomizeGenes.val;
				Tagging val2 = settings.tagging.val;
				GrowthAtSpawn val3 = settings.growthAtSpawn.val;
				Vector3? pos = value;
				string val4 = settings.customTag.val;
				worldObjectsSpawner.SpawnBibiteFromTemplate(bibiteTemplate, val, val2, val3, pos, null, val4);
			}
		}

		private void TaggingChanged(Tagging newVal)
		{
			customTagRef.gameObject.SetActive(newVal == Tagging.CustomTagging);
		}

		public void ButtonFromTemplatePressed()
		{
			settings.customTag.ResetValue();
			BibiteTemplateSelectorPanel.instance.OpenWithCallBacks(PlaceBibitesFromTemplate, RemoveSelectorListeners);
			TimeController.Instance.TogglePauseGame("bibitePlacer");
		}

		public void PlaceBibitesFromTemplate(BibiteTemplate bibiteTemplate)
		{
			template = bibiteTemplate;
			if (!GlobalLineageManager.Instance.TemplateAlreadyHasSpecies(template))
			{
				template.AlignInnovationsWithSim();
			}
			else
			{
				Species species = GlobalLineageManager.Instance.FindSpeciesFromTemplate(template);
				template.AlignInnovationsWithTemplate(species.template);
			}
			RemoveSelectorListeners();
			placementModeEnabled = true;
			OpenPanel();
		}

		private void RemoveSelectorListeners()
		{
			TimeController.Instance.TogglePauseGame("bibitePlacer", isUnpause: true);
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			placementModeEnabled = false;
		}
	}
}
