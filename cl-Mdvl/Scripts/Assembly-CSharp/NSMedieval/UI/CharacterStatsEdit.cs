using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Types;
using NSMedieval.UI.ScenarioEditor;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class CharacterStatsEdit : MonoBehaviour
	{
		[SerializeField]
		private CharactersView charactersView;

		[SerializeField]
		private SoundButton backgroundRandomizeButton;

		[SerializeField]
		private ButtonLayoutItemView backstorySelectButton;

		[SerializeField]
		private ButtonLayoutItemView backgroundSelectButton;

		[SerializeField]
		private SoundButton pseudonymRandomizeButton;

		[SerializeField]
		private ButtonLayoutItemView pseudonymSelectButton;

		[SerializeField]
		private TMP_Text skillsTitle;

		[SerializeField]
		private SoundButton skillsRandomizeButton;

		[SerializeField]
		private TMP_Text perksTitle;

		[SerializeField]
		private SoundButton perksRandomizeButton;

		[SerializeField]
		private SoundButton perkAddButton;

		[SerializeField]
		private EditableInputGroupLayoutItemView religiousEditView;

		[SerializeField]
		private EditableInputGroupLayoutItemView ageEditView;

		[SerializeField]
		private EditableInputGroupLayoutItemView weightEditView;

		[SerializeField]
		private EditableInputGroupLayoutItemView heightEditView;

		[SerializeField]
		private SoundButton reRollWorkerButton;

		[SerializeField]
		private SoundButton loadWorkerButton;

		[SerializeField]
		private SoundButton saveWorkerButton;

		private readonly int maxPerks = 10;

		private CharacterEditController EditController => MonoSingleton<CharacterEditController>.Instance;

		private BodyType SelectedBodyType => EditController.SelectedHumanoid.Info.BodyType;

		private void Start()
		{
			backgroundRandomizeButton.onClick.AddListener(delegate
			{
				EditController.SetBackground(string.Empty);
				EditController.SetBackstory(string.Empty);
			});
			backstorySelectButton.Button.onClick.AddListener(OnBackstorySelectClick);
			backgroundSelectButton.Button.onClick.AddListener(OnBackgroundSelectClick);
			pseudonymRandomizeButton.onClick.AddListener(delegate
			{
				EditController.SetPseudonym(string.Empty);
			});
			pseudonymSelectButton.Button.onClick.AddListener(OnPseudonymSelectClick);
			skillsRandomizeButton.onClick.AddListener(EditController.RerollSkills);
			perksRandomizeButton.onClick.AddListener(EditController.RerollPerks);
			perkAddButton.onClick.AddListener(OnPerkAddClick);
			reRollWorkerButton.onClick.AddListener(ReRollWorker);
		}

		private void OnEnable()
		{
			CharacterEditController editController = EditController;
			editController.SelectedWorkerChangedAction = (Action)Delegate.Combine(editController.SelectedWorkerChangedAction, new Action(OnSelectedWorkerChanged));
			CharacterEditController editController2 = EditController;
			editController2.PerksChangedAction = (Action)Delegate.Combine(editController2.PerksChangedAction, new Action(UpdateAddPerkButton));
			CharacterEditController editController3 = EditController;
			editController3.EditModeEnabledAction = (Action<bool>)Delegate.Combine(editController3.EditModeEnabledAction, new Action<bool>(OnEditModeEnabled));
		}

		private void OnDisable()
		{
			if (MonoSingleton<CharacterEditController>.IsInstantiated())
			{
				CharacterEditController editController = EditController;
				editController.SelectedWorkerChangedAction = (Action)Delegate.Remove(editController.SelectedWorkerChangedAction, new Action(OnSelectedWorkerChanged));
				CharacterEditController editController2 = EditController;
				editController2.PerksChangedAction = (Action)Delegate.Remove(editController2.PerksChangedAction, new Action(UpdateAddPerkButton));
				CharacterEditController editController3 = EditController;
				editController3.EditModeEnabledAction = (Action<bool>)Delegate.Remove(editController3.EditModeEnabledAction, new Action<bool>(OnEditModeEnabled));
			}
		}

		private void ReRollWorker()
		{
			if (!charactersView.WorkerChanged)
			{
				EditController.ReRollWorker();
				return;
			}
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", delegate
				{
					EditController.ReRollWorker();
				}),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("re_roll_settler_prompt", buttonActions), handleInput: false);
		}

		private void OnSelectedWorkerChanged()
		{
			BackStory byID = Repository<BackStoryRepository, BackStory>.Instance.GetByID(EditController.SelectedHumanoid.Info.BackStoryId);
			backstorySelectButton.SetTextData(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(byID.LocKeys), SelectedBodyType).CapitalizeFirst(), HumanoidUtils.GetBackstoryTooltipLines(byID.GetID(), EditController.SelectedHumanoid));
			Background byID2 = Repository<BackgroundRepository, Background>.Instance.GetByID(EditController.SelectedHumanoid.Info.BackgroundId);
			backgroundSelectButton.SetTextData(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(byID2.LocKeys), SelectedBodyType).CapitalizeFirst(), HumanoidUtils.GetBackgroundTooltipLines(byID2.GetID(), EditController.SelectedHumanoid));
			string text = ((EditController.SelectedHumanoid.Info.PseudonymId == string.Empty) ? MonoSingleton<LocalizationController>.Instance.GetText("general_none") : HumanoidUtils.GetPseudonymLocalized(EditController.SelectedHumanoid));
			pseudonymSelectButton.SetTextData(text, HumanoidUtils.GetPseudonymTooltipLines(EditController.SelectedHumanoid, showCharacterPoints: true));
			religiousEditView.SetData("", null, EditController.ModifyReligiousAlignment);
			SetAge();
			SetWeight();
			SetHeight();
		}

		private void SetAge()
		{
			int num = Mathf.RoundToInt(EditController.SelectedHumanoid.Info.Age);
			ageEditView.SetData(num.ToString(), EditController.SetAge, EditController.ModifyAge);
			ageEditView.MinusButton.interactable = num > Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.AgeRange.Min;
			ageEditView.PlusButton.interactable = num < Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.AgeRange.Max;
		}

		private void SetHeight()
		{
			int num = Mathf.RoundToInt(EditController.SelectedHumanoid.Info.Height);
			heightEditView.SetData(num.ToString(CultureInfo.CurrentUICulture), EditController.SetHeight, EditController.ModifyHeight);
			heightEditView.MinusButton.interactable = num > Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.HeightRange.Min;
			heightEditView.PlusButton.interactable = num < Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.HeightRange.Max;
		}

		private void SetWeight()
		{
			int num = Mathf.RoundToInt(EditController.SelectedHumanoid.Info.GetWeight());
			weightEditView.SetData(num.ToString(CultureInfo.CurrentUICulture), EditController.SetWeight, EditController.ModifyWeight);
			weightEditView.MinusButton.interactable = num > Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.WeightRange.Min;
			weightEditView.PlusButton.interactable = num < Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.WeightRange.Max;
		}

		private void OnPerkAddClick()
		{
			List<ListPopupItemData> list = new List<ListPopupItemData>();
			list.AddRange(from perk in Repository<PerkRepository, Perk>.Instance.GetAvailableOnStartPerks()
				orderby UiUtils.Localize.GetText(LocKeyUtils.GetName(perk.LocKeys))
				select ListPopupItemData.CreateInstance(perk.GetID(), UiUtils.Localize.GetText(LocKeyUtils.GetName(perk.LocKeys), SelectedBodyType), delegate
				{
					EditController.AddPerk(perk.GetID());
				}, HumanoidUtils.GetPerkTooltipLines(perk.GetID(), EditController.SelectedHumanoid, includeDescription: true, includeCreationData: true), perk.IconPath));
			List<string> list2 = new List<string>();
			foreach (Perk perk in EditController.SelectedHumanoid.Perks)
			{
				list2.Add(perk.GetID());
				foreach (Perk item in Repository<PerkRepository, Perk>.Instance.GetAllFromCategory(perk))
				{
					list2.Add(item.GetID());
				}
			}
			ListPopupData data = ListPopupData.CreateInstance(UiUtils.Localize.GetText("menu_perks"), list, list2, EditController.SelectedHumanoid);
			EditController.NotifyShowPerksPopupList(data);
		}

		private void OnBackstorySelectClick()
		{
			List<ListPopupItemData> list = new List<ListPopupItemData>();
			list.AddRange(from backstory in Repository<BackStoryRepository, BackStory>.Instance.GetAllItems().ToList()
				orderby UiUtils.Localize.GetText(LocKeyUtils.GetName(backstory.LocKeys), SelectedBodyType)
				select ListPopupItemData.CreateInstance(backstory.GetID(), UiUtils.Localize.GetText(LocKeyUtils.GetName(backstory.LocKeys), SelectedBodyType), delegate
				{
					EditController.SetBackstory(backstory.GetID());
				}, HumanoidUtils.GetBackstoryTooltipLines(backstory.GetID(), EditController.SelectedHumanoid)));
			List<string> selectedId = new List<string> { EditController.SelectedHumanoid.Info.BackStoryId };
			ListPopupData data = ListPopupData.CreateInstance(UiUtils.Localize.GetText("menu_backstory"), list, selectedId, EditController.SelectedHumanoid);
			EditController.NotifyShowPopupList(data);
		}

		private void OnBackgroundSelectClick()
		{
			List<ListPopupItemData> list = new List<ListPopupItemData>();
			list.AddRange(from background in Repository<BackgroundRepository, Background>.Instance.GetAvailableBackgrounds(CharacteristicTypes())
				orderby UiUtils.Localize.GetText(LocKeyUtils.GetName(background.LocKeys), SelectedBodyType)
				select ListPopupItemData.CreateInstance(background.GetID(), UiUtils.Localize.GetText(LocKeyUtils.GetName(background.LocKeys), SelectedBodyType).CapitalizeFirst(), delegate
				{
					EditController.SetBackground(background.GetID());
				}, HumanoidUtils.GetBackgroundTooltipLines(background.GetID(), EditController.SelectedHumanoid)));
			List<string> selectedId = new List<string> { EditController.SelectedHumanoid.Info.BackgroundId };
			ListPopupData data = ListPopupData.CreateInstance(UiUtils.Localize.GetText("menu_background"), list, selectedId, EditController.SelectedHumanoid);
			EditController.NotifyShowPopupList(data);
		}

		private void OnPseudonymSelectClick()
		{
			List<ListPopupItemData> list = new List<ListPopupItemData> { ListPopupItemData.CreateInstance("none", UiUtils.Localize.GetText("general_none"), delegate
			{
				EditController.SetPseudonym("none");
			}) };
			list.AddRange(from pseudonym in Repository<PseudonymRepository, Pseudonym>.Instance.GetAvailablePseudonyms(CharacteristicTypes())
				orderby UiUtils.Localize.GetText(pseudonym.GetID() + "_name")
				select ListPopupItemData.CreateInstance(pseudonym.GetID(), UiUtils.Localize.GetText(LocKeyUtils.GetName(pseudonym.LocKeys), SelectedBodyType), delegate
				{
					EditController.SetPseudonym(pseudonym.GetID());
				}, HumanoidUtils.GetPseudonymTooltipLines(pseudonym, EditController.SelectedHumanoid, showCharacterPoints: true)));
			List<string> selectedId = new List<string> { EditController.SelectedHumanoid.Info.PseudonymId };
			ListPopupData data = ListPopupData.CreateInstance(UiUtils.Localize.GetText("menu_pseudonym"), list, selectedId, EditController.SelectedHumanoid);
			EditController.NotifyShowPopupList(data);
		}

		private List<WorkerCharacteristicType> CharacteristicTypes()
		{
			return HumanoidUtils.GetPhysicalIgnoreTypes(new List<WorkerCharacteristicType>(), SelectedBodyType, EditController.SelectedHumanoid.Info.Height, EditController.SelectedHumanoid.Info.WeightCoefficient);
		}

		private void UpdateAddPerkButton()
		{
			perkAddButton.gameObject.SetActive(EditController.EditModeEnabled && EditController.SelectedHumanoid.Perks.Count < maxPerks);
			perkAddButton.transform.SetAsLastSibling();
		}

		private void OnEditModeEnabled(bool enabled)
		{
			UpdateAddPerkButton();
		}
	}
}
