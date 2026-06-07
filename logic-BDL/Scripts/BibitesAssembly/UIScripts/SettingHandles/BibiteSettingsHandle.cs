using System;
using ManagementScripts;
using SettingScripts;
using TMPro;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Utility;

namespace UIScripts.SettingHandles
{
	public class BibiteSettingsHandle : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[NonSerialized]
		public BibiteSettings settings;

		[NonSerialized]
		public BibiteTemplate template;

		[NonSerialized]
		public UnityEvent<BibiteSettingsHandle> onItemClicked = new UnityEvent<BibiteSettingsHandle>();

		[NonSerialized]
		public UnityEvent<BibiteSettingsHandle> onItemDelete = new UnityEvent<BibiteSettingsHandle>();

		[SerializeField]
		private TextMeshProUGUI bibiteName;

		[SerializeField]
		private SettingDropdownReference targetDropdownRef;

		[SerializeField]
		private SettingDropdownReference taggingDropdownRef;

		[SerializeField]
		private TextLineReference customTagRef;

		[SerializeField]
		private SettingSliderReference prioritySliderRef;

		[SerializeField]
		private SettingSliderReference minimumSliderRef;

		[SerializeField]
		private SettingDropdownReference randomGeneDropdownRef;

		[SerializeField]
		private SettingDropdownReference growthAtSpawnDropdownRef;

		[SerializeField]
		private SettingDropdownReference spawnTypeDropdownRef;

		private TargetZoneDropdown targetDropdown;

		private SettingDropdown<ChoiceSetting<Tagging>, Tagging> taggingDropdown;

		private StringFieldHandle customTagField;

		private LogFloatSettingSlider prioritySlider;

		private LogIntSettingSlider minimumSlider;

		private SettingDropdown<ChoiceSetting<RandomizeGenes>, RandomizeGenes> randomizeGenesDropdown;

		private ChoiceSettingDropdown<ChoiceSetting<GrowthAtSpawn>, GrowthAtSpawn> growthDropdown;

		private ChoiceSettingDropdown<ChoiceSetting<SpawnType>, SpawnType> spawnTypeDropdown;

		[SerializeField]
		private GameObject customTagSection;

		[SerializeField]
		private GameObject editSection;

		[SerializeField]
		private GameObject deleteButton;

		private bool selected;

		private bool deleting;

		private void Awake()
		{
			if (!selected)
			{
				CloseEditSection();
			}
		}

		public void InitializeItem(BibiteSettings bibiteSettings, BibiteTemplate bibiteTemplate = null)
		{
			settings = bibiteSettings;
			if (bibiteTemplate == null)
			{
				if (!string.IsNullOrEmpty(settings.filePath))
				{
					template = new BibiteTemplate(settings.filePath, settings.isExternal);
				}
			}
			else
			{
				template = bibiteTemplate;
			}
			if (template != null)
			{
				bibiteName.text = template.name;
			}
			targetDropdown = new TargetZoneDropdown(settings.spawnZone);
			taggingDropdown = new ChoiceSettingDropdown<ChoiceSetting<Tagging>, Tagging>(settings.tagging);
			prioritySlider = new LogFloatSettingSlider(settings.spawnPriority, 10f, wholeNumbers: false, simple: false, 4f);
			minimumSlider = new LogIntSettingSlider(settings.minimumNumber, 10f, wholeNumbers: false, simple: false, 2.1f);
			if (GameManager.activeScene == BibiteScenes.Simulation)
			{
				minimumSlider.onlyChangeSettingOnEndDrag = true;
			}
			randomizeGenesDropdown = new ChoiceSettingDropdown<ChoiceSetting<RandomizeGenes>, RandomizeGenes>(settings.randomizeGenes);
			growthDropdown = new ChoiceSettingDropdown<ChoiceSetting<GrowthAtSpawn>, GrowthAtSpawn>(settings.growthAtSpawn);
			spawnTypeDropdown = new ChoiceSettingDropdown<ChoiceSetting<SpawnType>, SpawnType>(settings.spawnType);
			customTagField = new StringFieldHandle(settings.customTag);
			targetDropdown.InitUIElement(targetDropdownRef);
			taggingDropdown.InitUIElement(taggingDropdownRef);
			customTagField.InitUIElement(customTagRef);
			prioritySlider.InitUIElement(prioritySliderRef);
			minimumSlider.InitUIElement(minimumSliderRef);
			randomizeGenesDropdown.InitUIElement(randomGeneDropdownRef);
			growthDropdown.InitUIElement(growthAtSpawnDropdownRef);
			spawnTypeDropdown.InitUIElement(spawnTypeDropdownRef);
			spawnTypeDropdown.onValueChangedByUser.AddListener(OnChangeSpawnType);
			settings.tagging.Subscribe(TaggingChanged);
			TaggingChanged(settings.tagging.val);
		}

		public void InitializeForChampion(BibiteSettings bibiteSettings)
		{
			InitializeItem(bibiteSettings);
			bibiteName.text = "Champion Spawn Settings";
			SelectItem();
			deleteButton.SetActive(value: false);
			taggingDropdownRef.dropdown.interactable = false;
			customTagRef.lineField.interactable = false;
		}

		public void OnChangeSpawnType(SpawnType type)
		{
			if (type == SpawnType.OneTime && GameManager.activeScene == BibiteScenes.Simulation)
			{
				settings.minimumNumber.SetValue(0);
			}
		}

		public void UnbindListeners()
		{
			targetDropdown.ReleaseDependencies();
		}

		public void DeleteItem()
		{
			if (!deleting)
			{
				onItemDelete.Invoke(this);
				UnityEngine.Object.Destroy(base.gameObject);
				deleting = true;
			}
		}

		private void OnDestroy()
		{
			settings.tagging.UnSubscribe(TaggingChanged);
		}

		private void TaggingChanged(Tagging newVal)
		{
			customTagSection.SetActive(newVal == Tagging.CustomTagging);
		}

		public void SelectItem()
		{
			selected = true;
			editSection.SetActive(value: true);
			deleteButton.SetActive(value: true);
		}

		public void CloseEditSection()
		{
			selected = false;
			deleteButton.SetActive(value: false);
			editSection.SetActive(value: false);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!editSection.activeSelf)
			{
				onItemClicked.Invoke(this);
			}
		}
	}
}
