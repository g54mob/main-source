using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class CharactersView : GameStartView
	{
		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private LayoutGroupView workerTabGroup;

		[SerializeField]
		private LayoutGroupView workerSkillGroup;

		[SerializeField]
		private LayoutGroupView groupSkillGroup;

		[SerializeField]
		private List<AlignmentLayoutItemView> alignments;

		[SerializeField]
		private SoundButton randomNameButton;

		[SerializeField]
		private SoundButton randomLastNameButton;

		[SerializeField]
		private SoundButton reRollWorkerButton;

		[SerializeField]
		private SoundButton reRollAllButton;

		[SerializeField]
		private SoundButton loadPresetButton;

		[SerializeField]
		private SoundButton savePresetButton;

		[SerializeField]
		private TMP_InputField workerName;

		[SerializeField]
		private TMP_InputField workerLastname;

		[SerializeField]
		private List<TMP_Text> workerInfo;

		[SerializeField]
		private TMP_Text workerBackground;

		[SerializeField]
		private TMP_Text workerPseudonym;

		[SerializeField]
		private JobPreferencesPanelView jobPreferencesPanelView;

		[SerializeField]
		private LayoutGroupView workerPerkGroup;

		[SerializeField]
		private RectTransform avatarRectTransform;

		[SerializeField]
		private CustomToggle advancedModeToggle;

		[SerializeField]
		private TMP_Text groupPointsText;

		[SerializeField]
		private GameObject[] editModeObjects;

		[SerializeField]
		private GameObject[] standardModeObjects;

		private readonly List<GroupSkillLayoutItemView> groupSkills = new List<GroupSkillLayoutItemView>();

		private readonly List<EditablePerkItemView> workerPerks = new List<EditablePerkItemView>();

		private readonly List<EditableSkillLayoutItemView> workerSkills = new List<EditableSkillLayoutItemView>();

		private readonly List<LayoutGroupItemView> workerTabs = new List<LayoutGroupItemView>();

		private CharacterEditController characterEditController;

		private byte[] savedScenarioHash;

		public bool WorkerChanged { get; private set; }

		private CharacterEditController EditController
		{
			get
			{
				if (characterEditController == null)
				{
					characterEditController = MonoSingleton<CharacterEditController>.Instance;
				}
				return characterEditController;
			}
		}

		protected override void OnClickPrevious()
		{
			MonoSingleton<BlackBarMessageController>.Instance.HideAllMessages();
			advancedModeToggle.isOn = false;
			base.OnClickPrevious();
		}

		private void Start()
		{
			title.text = base.Localize.GetText("characters_creation");
			randomNameButton.onClick.AddListener(delegate
			{
				EditController.SetFirstName();
				Refresh();
			});
			randomLastNameButton.onClick.AddListener(delegate
			{
				EditController.SetLastName();
				Refresh();
			});
			reRollWorkerButton.onClick.AddListener(ReRollWorker);
			reRollAllButton.onClick.AddListener(ReRollAllWorkers);
			loadPresetButton.onClick.AddListener(EditController.ShowLoadPresetPopup);
			savePresetButton.onClick.AddListener(EditController.ShowSavePresetPopup);
			advancedModeToggle.onValueChanged.AddListener(EditController.EnableEditMode);
			workerName.onEndEdit.AddListener(OnWorkerNameInput);
			workerLastname.onEndEdit.AddListener(OnWorkerLastnameInput);
		}

		private void OnWorkerNameInput(string newName)
		{
			if (newName.Equals(string.Empty))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(base.Localize.GetText("warning_choose_settler_name"));
				workerName.text = EditController.SelectedHumanoid.Info.FirstName;
				return;
			}
			string text = newName.TrimStart();
			if (string.CompareOrdinal(newName, text) != 0)
			{
				workerName.text = text;
			}
			text = text.TrimEnd();
			EditController.SetFirstName(text);
		}

		private void OnWorkerLastnameInput(string newLastname)
		{
			if (newLastname.Equals(string.Empty))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(base.Localize.GetText("warning_choose_settler_name"));
				workerLastname.text = EditController.SelectedHumanoid.Info.LastName;
				return;
			}
			string text = newLastname.TrimStart();
			if (string.CompareOrdinal(newLastname, text) != 0)
			{
				workerName.text = text;
			}
			text = text.TrimEnd();
			EditController.SetLastName(text);
		}

		public override void Show()
		{
			CharacterEditController editController = EditController;
			editController.EditModeEnabledAction = (Action<bool>)Delegate.Combine(editController.EditModeEnabledAction, new Action<bool>(OnEditModeEnabled));
			CharacterEditController editController2 = EditController;
			editController2.CharacterUpdatedAction = (Action)Delegate.Combine(editController2.CharacterUpdatedAction, new Action(OnCharacterUpdated));
			CharacterEditController editController3 = EditController;
			editController3.SkillChangedAction = (Action)Delegate.Combine(editController3.SkillChangedAction, new Action(OnSkillChanged));
			CharacterEditController editController4 = EditController;
			editController4.CreationPointsUpdatedAction = (Action<IntRange>)Delegate.Combine(editController4.CreationPointsUpdatedAction, new Action<IntRange>(OnCreationPointsUpdate));
			CharacterEditController editController5 = EditController;
			editController5.GeneratingWorkersAction = (Action<bool>)Delegate.Combine(editController5.GeneratingWorkersAction, new Action<bool>(OnWorkerGeneration));
			MonoSingleton<UIClosableController>.Instance.CloseAll();
			ResetGlobalShaderVariables();
			MonoSingleton<WorkerIconCamera>.Instance.Camera.SetActive(value: true);
			base.Show();
			if (ScenarioChanged() || EditController.Workers == null || EditController.Workers.Count < 1)
			{
				MonoSingleton<UniqueIdManager>.Instance.ClearData();
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(EditController.ReRollAllWorkers);
			}
			OnCreationPointsUpdate(EditController.GetGroupPoints());
			base.MoreInfoPanel.Show();
			CharacterEditController editController6 = EditController;
			if ((object)editController6 != null && editController6.Workers?.Count > 0)
			{
				Refresh();
			}
		}

		public override void Hide()
		{
			CharacterEditController editController = EditController;
			editController.EditModeEnabledAction = (Action<bool>)Delegate.Remove(editController.EditModeEnabledAction, new Action<bool>(OnEditModeEnabled));
			CharacterEditController editController2 = EditController;
			editController2.CharacterUpdatedAction = (Action)Delegate.Remove(editController2.CharacterUpdatedAction, new Action(OnCharacterUpdated));
			CharacterEditController editController3 = EditController;
			editController3.SkillChangedAction = (Action)Delegate.Remove(editController3.SkillChangedAction, new Action(OnSkillChanged));
			CharacterEditController editController4 = EditController;
			editController4.GeneratingWorkersAction = (Action<bool>)Delegate.Remove(editController4.GeneratingWorkersAction, new Action<bool>(OnWorkerGeneration));
			CharacterEditController editController5 = EditController;
			editController5.CreationPointsUpdatedAction = (Action<IntRange>)Delegate.Remove(editController5.CreationPointsUpdatedAction, new Action<IntRange>(OnCreationPointsUpdate));
			MonoSingleton<WorkerIconCamera>.Instance.Camera.SetActive(value: false);
			base.Hide();
		}

		private void OnWorkerGeneration(bool workersGenerating)
		{
			WorkerChanged = false;
			if (workersGenerating)
			{
				SetNextButtonInteractable();
				return;
			}
			SetNextButtonInteractable();
			Refresh();
		}

		protected override void OnClickNext()
		{
			if (EditController.Workers.Count == MonoSingleton<GameStartController>.Instance.SelectedScenario.VillagerConstraints.NumberOfVillagers)
			{
				base.StartController.Workers = EditController.Workers;
				base.OnClickNext();
			}
		}

		private void OnEditModeEnabled(bool enabled)
		{
			if (EditController.SelectedHumanoid != null)
			{
				GameObject[] array = standardModeObjects;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(!enabled);
				}
				array = editModeObjects;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(enabled);
				}
				if (enabled)
				{
					workerPseudonym.gameObject.SetActive(value: false);
				}
				else if (string.IsNullOrEmpty(EditController.SelectedHumanoid.Info.PseudonymId))
				{
					workerPseudonym.gameObject.SetActive(value: false);
				}
				else
				{
					workerPseudonym.gameObject.SetActive(value: true);
					UIView.SetText(workerPseudonym, EditController.SelectedHumanoid.Info.PseudonymId, HumanoidUtils.GetPseudonymLocalized(EditController.SelectedHumanoid));
				}
				HandleGroupPointsDisplay();
			}
		}

		private void HandleGroupPointsDisplay()
		{
			if (MonoSingleton<CharacterEditController>.Instance.EditModeEnabled)
			{
				groupPointsText.gameObject.SetActive(value: true);
			}
			else
			{
				groupPointsText.gameObject.SetActive(characterEditController.GetGroupPoints().Min > characterEditController.GetGroupPoints().Max);
			}
		}

		private void OnCharacterUpdated()
		{
			WorkerChanged = true;
			Refresh();
		}

		private void Refresh()
		{
			loadPresetButton.interactable = Repository<CharacterPresetRepository, WorkerInstancePreset>.Instance.UserPresets.Count > 0;
			UpdateTabs(EditController.Selected);
			HandleGroupPointsDisplay();
			SetGroupSkills();
		}

		private void ReRollWorker()
		{
			if (!WorkerChanged)
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

		private void ReRollAllWorkers()
		{
			if (!WorkerChanged)
			{
				EditController.ReRollAllWorkers();
				return;
			}
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", delegate
				{
					EditController.ReRollAllWorkers();
				}),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("re_roll_settlers_prompt", buttonActions), handleInput: false);
		}

		private void UpdateTabs(int selectedIndex = 0)
		{
			workerTabs.SetAllActive(active: false);
			for (int i = 0; i < EditController.Workers.Count; i++)
			{
				int index = i;
				LayoutGroupItemView next = workerTabs.GetNext(workerTabGroup);
				next.gameObject.SetActive(value: true);
				next.SetText(EditController.Workers[i].Info.FirstName + "\n" + EditController.Workers[i].Info.LastName);
				next.GroupItems[1].GetComponent<Image>().sprite = MonoSingleton<HumanoidIconManager>.Instance.GetCachedIcon(EditController.Workers[i]);
				next.GroupItems[2].SetActive(i == selectedIndex);
				next.GetComponent<SoundButton>().AddCleanListener(delegate
				{
					UpdateTabs(index);
				});
			}
			EditController.SetSelected(selectedIndex);
			ShowWorker();
		}

		private void ShowWorker()
		{
			SetWorkerSkills();
			SetWorkerInfo();
			SetBackground();
			SetJobPreferences();
			SetPerks();
			MonoSingleton<HumanoidIconManager>.Instance.ShowHumanoid(EditController.SelectedHumanoid.UniqueId);
		}

		private void OnSkillChanged()
		{
			OnSkillUpdated();
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(SetGroupSkills);
		}

		private void OnSkillUpdated()
		{
			foreach (EditableSkillLayoutItemView workerSkill in workerSkills)
			{
				workerSkill.SetSkillData(EditController.SelectedHumanoid, workerSkill.Skill);
				workerSkill.EditLevelGroup.MinusButton.interactable = workerSkill.Skill.Level > HumanoidUtils.GetBaseSkillPoints(EditController.SelectedHumanoid, workerSkill.Skill) && workerSkill.Skill.Level > 0;
				workerSkill.EditLevelGroup.PlusButton.interactable = workerSkill.Skill.Level < Repository<SkillLevelsRepository, SkillLevels>.Instance.GetXpRequirements(workerSkill.Skill.Id).Length - 1;
			}
		}

		private void SetWorkerSkills()
		{
			List<WorkerSkill> skillsOrdered = EditController.SelectedHumanoid.SkillsOrdered;
			workerSkills.SetAllActive(active: false);
			int num = 0;
			foreach (WorkerSkill item in skillsOrdered.Where((WorkerSkill skill) => skill.Id != SkillType.None))
			{
				EditableSkillLayoutItemView next = workerSkills.GetNext(workerSkillGroup);
				next.SetSkillData(EditController.SelectedHumanoid, item, num);
				next.EditLevelGroup.MinusButton.interactable = item.Level > HumanoidUtils.GetBaseSkillPoints(EditController.SelectedHumanoid, item) && item.Level > 0;
				next.EditLevelGroup.PlusButton.interactable = item.Level < Repository<SkillLevelsRepository, SkillLevels>.Instance.GetXpRequirements(item.Id).Length - 1;
				num++;
			}
		}

		private void SetWorkerInfo()
		{
			workerName.text = EditController.SelectedHumanoid.Info.FirstName;
			workerLastname.text = EditController.SelectedHumanoid.Info.LastName;
			workerInfo[1].SetText(EditController.SelectedHumanoid.Info.Age.ToString());
			workerInfo[2].SetText(string.Format("{0} {1}", (int)EditController.SelectedHumanoid.Info.GetWeight(), base.Localize.GetText("general_kg")));
			workerInfo[3].SetText(string.Format("{0} {1}", (int)EditController.SelectedHumanoid.Info.Height, base.Localize.GetText("general_cm")));
			alignments.FirstOrDefault()?.SetAlignmentData(StatType.ReligiousAlignment, EditController.SelectedHumanoid.Info.ReligiousAlignment, EditController.SelectedHumanoid);
		}

		private void SetBackground()
		{
			HumanoidInstance selectedHumanoid = EditController.SelectedHumanoid;
			string backgroundNameMerged = HumanoidUtils.GetBackgroundNameMerged(selectedHumanoid);
			UIView.SetText(workerBackground, selectedHumanoid.Info.BackgroundId, backgroundNameMerged, selectedHumanoid);
			workerBackground.GetComponent<BackgroundTooltipView>().SetTooltipData(selectedHumanoid.Info.BackgroundId, selectedHumanoid);
			if (selectedHumanoid.Info.PseudonymId.Equals(string.Empty) || EditController.EditModeEnabled)
			{
				workerPseudonym.gameObject.SetActive(value: false);
				return;
			}
			workerPseudonym.gameObject.SetActive(value: true);
			UIView.SetText(workerPseudonym, selectedHumanoid.Info.PseudonymId, HumanoidUtils.GetPseudonymLocalized(selectedHumanoid));
			workerPseudonym.GetComponent<PseudonymTooltipView>().SetOwner(selectedHumanoid);
		}

		private void SetJobPreferences()
		{
			jobPreferencesPanelView.UpdateData(EditController.SelectedHumanoid);
		}

		private void SetPerks()
		{
			workerPerks.SetAllActive(active: false);
			foreach (Perk perk in EditController.SelectedHumanoid.Perks)
			{
				workerPerks.GetNext(workerPerkGroup).SetData(perk.IconPath, perk.Name, EditController.SelectedHumanoid, delegate
				{
					EditController.RemovePerk(perk.Name);
				});
			}
			EditController.NotifyPerksChanged();
		}

		private void SetGroupSkills()
		{
			List<WorkerSkill> list = EditController.Workers[0].Skills.Skills.OrderBy((WorkerSkill workerSkill) => base.Localize.GetText(workerSkill.GetSkillTextKey())).ToList();
			groupSkills.SetAllActive(active: false);
			foreach (WorkerSkill item in list)
			{
				GroupSkillLayoutItemView next = groupSkills.GetNext(groupSkillGroup);
				string tooltipText = base.Localize.GetText("no_skilled_worker") + " " + base.Localize.GetText($"skill_name_{item.Id}");
				int num = 0;
				int num2 = 0;
				WorkerSkill skill = item;
				foreach (HumanoidInstance worker in EditController.Workers)
				{
					WorkerSkill skill2 = worker.Skills.GetSkill(item.Id);
					if (skill2.Level >= num)
					{
						skill = skill2;
						num = skill2.Level;
						tooltipText = GetGroupSkillLocalized(base.Localize.GetText("most_skilled"), base.Localize.GetText($"skill_name_{item.Id}"), worker.Info.GetDefaultDisplayName());
					}
					if (skill2.GetGoalPreferenceLevel() > num2)
					{
						num2 = skill2.GetGoalPreferenceLevel();
						if (skill2.Level >= num)
						{
							tooltipText = GetGroupSkillLocalized(base.Localize.GetText("most_passionate"), base.Localize.GetText($"skill_name_{item.Id}"), worker.Info.GetDefaultDisplayName());
						}
					}
				}
				next.SetSkillData(skill, tooltipText);
				next.gameObject.SetActive(item.Id != SkillType.None);
			}
		}

		private string GetGroupSkillLocalized(string reason, string skillId, string workerName)
		{
			string result = reason + " " + skillId + ": " + workerName;
			if (base.Localize.GetCurrentLanguageEnum() == Language.Chinese)
			{
				result = skillId + " " + reason + ": " + workerName;
			}
			if (base.Localize.GetCurrentLanguageEnum() == Language.Japanese)
			{
				result = skillId + reason + ": " + workerName;
			}
			return result;
		}

		private bool ScenarioChanged()
		{
			if (savedScenarioHash == null)
			{
				savedScenarioHash = MonoSingleton<GameStartController>.Instance.SelectedScenario.GetWorkerConstraintsHash();
				return true;
			}
			byte[] workerConstraintsHash = MonoSingleton<GameStartController>.Instance.SelectedScenario.GetWorkerConstraintsHash();
			if (workerConstraintsHash.Length == savedScenarioHash.Length)
			{
				int i;
				for (i = 0; i < workerConstraintsHash.Length && workerConstraintsHash[i] == savedScenarioHash[i]; i++)
				{
				}
				savedScenarioHash = workerConstraintsHash;
				return i != workerConstraintsHash.Length;
			}
			savedScenarioHash = workerConstraintsHash;
			return true;
		}

		private void OnCreationPointsUpdate(IntRange points)
		{
			SetNextButtonInteractable();
			string arg = ((points.Min > points.Max) ? ColorUtils.GetColorHex("red") : ColorUtils.GetColorHex("yellow"));
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<b>" + UiUtils.Localize.GetText("character_group_points").ToUpper(CultureInfo.CurrentCulture) + "</b>");
			stringBuilder.AppendLine($"<style=Normal><size=24><color=#{arg}>{points.Min}/{points.Max}</color></size></style>");
			stringBuilder.AppendLine(string.Empty);
			groupPointsText.SetText(stringBuilder.ToString());
			groupPointsText.GetComponent<TooltipViewNew>().AppendLine("test");
		}

		private void SetNextButtonInteractable()
		{
			IntRange groupPoints = characterEditController.GetGroupPoints();
			bool flag = groupPoints.Min <= groupPoints.Max;
			base.NextButton.interactable = flag;
			if (!flag)
			{
				base.NextButton.AddCleanNonInteractableListener(delegate
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(base.Localize.GetText("character_point_limit"));
				});
			}
		}

		private static string ByteArrayToString(byte[] arrInput)
		{
			StringBuilder stringBuilder = new StringBuilder(arrInput.Length);
			for (int i = 0; i < arrInput.Length; i++)
			{
				stringBuilder.Append(arrInput[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		private void ResetGlobalShaderVariables()
		{
			Shader.SetGlobalFloat("_WorldLayer", 16f);
			Shader.SetGlobalInt("_TreesHidden", 0);
			Shader.SetGlobalFloat("_Rain_amount", 0f);
			Shader.SetGlobalFloat("_RimLightStrength", 1f);
			Shader.SetGlobalFloat("_windGlobalBend", 0.3f);
			WorldMapViewHomeScene.OnStartSeasonChanged(MonoSingleton<GameStartController>.Instance.SelectedScenario.StartSeason);
		}
	}
}
