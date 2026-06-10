using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.ScenarioEditor;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Controllers
{
	public class CharacterEditController : MonoSingleton<CharacterEditController>
	{
		public Action CharacterUpdatedAction;

		public Action<IntRange> CreationPointsUpdatedAction;

		public Action<bool> EditModeEnabledAction;

		public Action<bool> GeneratingWorkersAction;

		public Action HidePopupListAction;

		public Action PerksChangedAction;

		public Action SelectedWorkerChangedAction;

		public Action<ListPopupData> ShowAppearancePopupListAction;

		public Action<ListPopupData> ShowPerksPopupListAction;

		public Action ShowLoadPresetPopupAction;

		public Action<ListPopupData> ShowPopupListAction;

		public Action ShowSavePresetPopupAction;

		public Action SkillChangedAction;

		public bool EditModeEnabled { get; private set; }

		public int Selected { get; private set; }

		public List<HumanoidInstance> Workers { get; private set; } = new List<HumanoidInstance>();

		public HumanoidInstance SelectedHumanoid
		{
			get
			{
				if (Workers.Count <= Selected)
				{
					return Workers.FirstOrDefault();
				}
				return Workers[Selected];
			}
			private set
			{
				Workers[Selected] = value;
			}
		}

		public void OnGameStart()
		{
			MonoSingleton<HumanoidIconManager>.Instance.Clear();
			Workers = new List<HumanoidInstance>();
			EditModeEnabled = false;
		}

		public void NotifySelectedWorkerChanged()
		{
			SelectedWorkerChangedAction?.Invoke();
		}

		public void NotifyEditModeEnabled(bool enabled)
		{
			EditModeEnabledAction?.Invoke(enabled);
		}

		public void NotifyShowPopupList(ListPopupData data)
		{
			ShowPopupListAction?.Invoke(data);
		}

		public void NotifyGroupPointsUpdate()
		{
			CreationPointsUpdatedAction?.Invoke(GetGroupPoints());
		}

		public void SetSelected(int selected)
		{
			Selected = selected;
			if (Workers != null && !((decimal)Workers.Count == 0m))
			{
				NotifySelectedWorkerChanged();
			}
		}

		public void EnableEditMode(bool enable)
		{
			EditModeEnabled = enable;
			NotifyEditModeEnabled(EditModeEnabled);
		}

		public void OnAppearanceUpdated()
		{
			NotifyCharacterUpdated();
		}

		public void UpdateCurrentImage()
		{
			MonoSingleton<HumanoidIconManager>.Instance.GenerateAndCacheIcon(SelectedHumanoid);
		}

		public void NotifyHidePopupList()
		{
			HidePopupListAction?.Invoke();
		}

		public void NotifyShowPerksPopupList(ListPopupData data)
		{
			ShowPerksPopupListAction?.Invoke(data);
		}

		public void NotifyShowAppearancePopupList(ListPopupData data)
		{
			ShowAppearancePopupListAction?.Invoke(data);
		}

		public void NotifyCharacterUpdated()
		{
			if (Workers != null && Workers.Count != 0)
			{
				CharacterUpdatedAction?.Invoke();
			}
		}

		public void NotifyPerksChanged()
		{
			PerksChangedAction?.Invoke();
		}

		public void NotifySkillChanged()
		{
			SkillChangedAction?.Invoke();
		}

		public void NotifyGeneratingWorkers(bool generatingStart)
		{
			GeneratingWorkersAction?.Invoke(generatingStart);
		}

		public void ReRollAllWorkers()
		{
			NotifyGeneratingWorkers(generatingStart: true);
			if (Workers != null && Workers.Count > 0)
			{
				MonoSingleton<HumanoidIconManager>.Instance.Clear();
			}
			Workers = new List<HumanoidInstance>();
			for (int i = 0; i < MonoSingleton<GameStartController>.Instance.SelectedScenario.VillagerConstraints.NumberOfVillagers; i++)
			{
				HumanoidInstance item = GenerateWorker();
				Workers.Add(item);
				Vector3 spawnPosition = Workers[i].WorkerBehaviour.WorkerBlueprint.SpawnPosition;
				Workers[i].SetPosition(new Vector3(spawnPosition.x + (float)i, spawnPosition.y, spawnPosition.z));
			}
			SetSelected(0);
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(NotifyGroupPointsUpdate).ThenWaitFor(0.1f)
				.Then(delegate
				{
					NotifyGeneratingWorkers(generatingStart: false);
				});
		}

		public void ReRollWorker()
		{
			NotifyGeneratingWorkers(generatingStart: true);
			MonoSingleton<HumanoidIconManager>.Instance.Clear();
			Workers[Selected] = GenerateWorker();
			Vector3 spawnPosition = SelectedHumanoid.WorkerBehaviour.WorkerBlueprint.SpawnPosition;
			SelectedHumanoid.SetPosition(new Vector3(spawnPosition.x + (float)Selected, spawnPosition.y, spawnPosition.z));
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(NotifyGroupPointsUpdate).ThenWaitFor(0.1f)
				.Then(delegate
				{
					NotifyGeneratingWorkers(generatingStart: false);
				});
		}

		private HumanoidInstance GenerateWorker()
		{
			List<SerializableIdValuePair> list = new List<SerializableIdValuePair>();
			foreach (Perk allItem in Repository<PerkRepository, Perk>.Instance.GetAllItems())
			{
				if (allItem.ForbidOnStart)
				{
					list.Add(new SerializableIdValuePair(allItem.GetID(), 0f));
				}
			}
			return MonoSingleton<WorkerGenerator>.Instance.GenerateWorker(list);
		}

		public void ApplyPreset(WorkerInstancePreset currentPreset)
		{
			if (currentPreset == null || currentPreset.Instance?.Info == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\CharacterEditController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot apply preset: ");
					messageBuilder.AppendFormatted((currentPreset == null) ? "null" : currentPreset.GetID());
				}
				Log.Error(messageBuilder);
				return;
			}
			NotifyGeneratingWorkers(generatingStart: true);
			CreateWorker(MonoSingleton<WorkerGenerator>.Instance.GenerateWorker(currentPreset.Instance.Info.BodyType));
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				SetFirstName(currentPreset.Instance.Info.FirstName);
				SetLastName(currentPreset.Instance.Info.LastName);
				SetSkinColor(currentPreset.Instance.GetCharacterInfo().PhysicalLook.GetSkinColor(), updateImmediate: false);
				SetHairColor(currentPreset.Instance.GetCharacterInfo().PhysicalLook.GetHairColor(), updateImmediate: false);
				SetHairType(currentPreset.Instance.GetCharacterInfo().PhysicalLook.GetHairType(), updateImmediate: false);
				SetHeadType(currentPreset.Instance.GetCharacterInfo().PhysicalLook.GetHeadType(), updateImmediate: false);
				SetBeardType(currentPreset.Instance.GetCharacterInfo().PhysicalLook.GetBeardType(), updateImmediate: false);
				SetMoustacheType(currentPreset.Instance.GetCharacterInfo().PhysicalLook.GetMoustacheType(), updateImmediate: false);
				SetBackground(currentPreset.Instance.Info.BackgroundId, newWorker: true);
				SetBackstory(currentPreset.Instance.Info.BackStoryId, newWorker: true);
				SetFreshPseudonym(currentPreset.Instance.Info.PseudonymId, newWorker: true);
				SetFreshPerks(currentPreset.Instance.Perks, newWorker: true);
				SetFreshSkills(currentPreset.Instance.Skills, newWorker: true);
				SetReligiousAlignment(currentPreset.Instance.Info.ReligiousAlignment);
				SetAge(currentPreset.Instance.Info.Age);
				SetHeight((int)currentPreset.Instance.Info.Height);
				SetWeight((int)currentPreset.Instance.Info.GetWeight());
			}).ThenWaitFor(0.2f)
				.Then(delegate
				{
					UpdateGroupPoints();
					OnAppearanceUpdated();
					UpdateCurrentImage();
					NotifyGeneratingWorkers(generatingStart: false);
				});
		}

		public void SetGender(string value)
		{
			if (Enum.TryParse<BodyType>(value, ignoreCase: true, out var result) && result != SelectedHumanoid.Info.BodyType)
			{
				NotifyHidePopupList();
				NotifyGeneratingWorkers(generatingStart: true);
				WorkerCharacteristicType type = ((result == BodyType.Male) ? WorkerCharacteristicType.Male : WorkerCharacteristicType.Female);
				string background = (SelectedHumanoid.Info.Background.IgnoreCharacteristicType.Contains(type) ? string.Empty : SelectedHumanoid.Info.Background.GetID());
				string backstory = (SelectedHumanoid.Info.BackStory.IgnoreCharacteristicType.Contains(type) ? string.Empty : SelectedHumanoid.Info.BackStory.GetID());
				string pseudonym = SelectedHumanoid.Info.PseudonymId;
				List<Perk> perks = new List<Perk>(SelectedHumanoid.Perks.FindAll((Perk perk) => !perk.IgnoreCharacteristicType.Contains(type)));
				string lastName = SelectedHumanoid.Info.LastName;
				string skinColor = SelectedHumanoid.GetCharacterInfo().PhysicalLook.GetSkinColor();
				string hairColor = SelectedHumanoid.GetCharacterInfo().PhysicalLook.GetHairColor();
				float religiousAlignment = SelectedHumanoid.Info.ReligiousAlignment;
				WorkerSkills skills = SelectedHumanoid.Skills;
				CreateWorker(MonoSingleton<WorkerGenerator>.Instance.GenerateWorker(result));
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					SetLastName(lastName);
					SetBackground(background, newWorker: true);
					SetBackstory(backstory, newWorker: true);
					SetFreshPseudonym(pseudonym, newWorker: true);
					SetFreshPerks(perks, newWorker: true);
					SetFreshSkills(skills, newWorker: true);
					SetSkinColor(skinColor);
					SetHairColor(hairColor);
					SetReligiousAlignment(religiousAlignment);
				}).ThenWaitFor(0.02f)
					.Then(delegate
					{
						UpdateGroupPoints();
						OnAppearanceUpdated();
						NotifyGeneratingWorkers(generatingStart: false);
					});
			}
		}

		public void SetFirstName()
		{
			SetFirstName(Repository<NameRepository, Names>.Instance.GetFirstName(SelectedHumanoid.Info.BodyType));
		}

		public void SetLastName()
		{
			SetLastName(Repository<NameRepository, Names>.Instance.GetLastName());
		}

		public void SetFirstName(string name)
		{
			SelectedHumanoid.Info.SetFirstName(name);
			NotifyCharacterUpdated();
		}

		public void SetLastName(string lastName)
		{
			SelectedHumanoid.Info.SetLastName(lastName);
			NotifyCharacterUpdated();
		}

		public void SetSkinColor(string color, bool updateImmediate = true)
		{
			SelectedHumanoid.GetCharacterInfo().PhysicalLook.SetSkinColor(color);
			if (updateImmediate)
			{
				UpdateCurrentImage();
			}
			OnAppearanceUpdated();
		}

		public void SetHairColor(string color, bool updateImmediate = true)
		{
			SelectedHumanoid.GetCharacterInfo().PhysicalLook.SetHairColor(color);
			if (updateImmediate)
			{
				UpdateCurrentImage();
			}
			OnAppearanceUpdated();
		}

		public void SetHairType(string type, bool updateImmediate = true)
		{
			SelectedHumanoid.GetCharacterInfo().PhysicalLook.SetHairType(type);
			if (updateImmediate)
			{
				UpdateCurrentImage();
			}
			OnAppearanceUpdated();
		}

		public void SetHeadType(string type, bool updateImmediate = true)
		{
			SelectedHumanoid.GetCharacterInfo().PhysicalLook.SetHeadType(type);
			if (updateImmediate)
			{
				UpdateCurrentImage();
			}
			OnAppearanceUpdated();
		}

		public void SetBeardType(string type, bool updateImmediate = true)
		{
			SelectedHumanoid.GetCharacterInfo().PhysicalLook.SetBeardType(type);
			if (updateImmediate)
			{
				UpdateCurrentImage();
			}
		}

		public void SetMoustacheType(string type, bool updateImmediate = true)
		{
			SelectedHumanoid.GetCharacterInfo().PhysicalLook.SetMoustacheType(type);
			if (updateImmediate)
			{
				UpdateCurrentImage();
			}
		}

		public void SetFacialHairType(StringStringPair groupTypePair, bool updateImmediate = true)
		{
			switch (groupTypePair.Key)
			{
			case "none":
				SetBeardType("none");
				SetMoustacheType("none");
				break;
			case "moustaches":
				SetBeardType("none");
				SetMoustacheType(groupTypePair.Value);
				break;
			case "beards":
				SetBeardType(groupTypePair.Value);
				SetMoustacheType("none");
				break;
			default:
				Log.Warning(groupTypePair.Key + " body part does not exist!", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\CharacterEditController.cs");
				break;
			}
			if (updateImmediate)
			{
				UpdateCurrentImage();
			}
			OnAppearanceUpdated();
		}

		public List<string> GetAllowedBodyParts(string groupName)
		{
			return Repository<HumanAppearanceRepository, HumanAppearance>.Instance.GetByID("default").BodyParts.FirstOrDefault((HumanAppearanceBodyPartsGroup part) => part.GroupName.Equals(groupName))?.AllowedItems;
		}

		public List<string> GetPossibleBodyParts(string groupName)
		{
			return GetAllowedBodyParts(groupName).FindAll((string item) => SelectedHumanoid.GetCharacterInfo().PhysicalLook.PossibleBodyParts.Contains(item));
		}

		public void SetBackground(string id, bool newWorker = false)
		{
			List<SkillValuePair> list = SelectedHumanoid.Info.Background?.SkillModifiers;
			SelectedHumanoid = HumanoidUtils.SetBackground(SelectedHumanoid, GetSafeBackground(id));
			if (list != null)
			{
				OnSkillModifierRemoved(list);
			}
			NotifyHidePopupList();
			UpdateSkillMinimum();
			NotifyCharacterUpdated();
			if (!newWorker)
			{
				UpdateGroupPoints();
			}
			RerollSkillGoalPreferences();
		}

		private Background GetSafeBackground(string backgroundId)
		{
			if (string.IsNullOrEmpty(backgroundId))
			{
				return Repository<BackgroundRepository, Background>.Instance.GetBackground(SelectedHumanoid.Info.IgnoredTypes, (SelectedHumanoid.Info.ReligiousAlignment > 0.5f) ? 1 : (-1));
			}
			Background byID = Repository<BackgroundRepository, Background>.Instance.GetByID(backgroundId);
			if (!(byID != null))
			{
				return Repository<BackgroundRepository, Background>.Instance.GetBackground(SelectedHumanoid.Info.IgnoredTypes, (SelectedHumanoid.Info.ReligiousAlignment > 0.5f) ? 1 : (-1));
			}
			return byID;
		}

		public void SetBackstory(string id, bool newWorker = false)
		{
			List<SkillValuePair> list = SelectedHumanoid.Info.BackStory?.SkillModifiers;
			if (id.Equals(string.Empty))
			{
				SelectedHumanoid = HumanoidUtils.SetBackStory(SelectedHumanoid, Repository<BackStoryRepository, BackStory>.Instance.GetBackground(SelectedHumanoid.Info.IgnoredTypes, (SelectedHumanoid.Info.ReligiousAlignment > 0.5f) ? 1 : (-1)));
			}
			else
			{
				SelectedHumanoid = HumanoidUtils.SetBackStory(SelectedHumanoid, Repository<BackStoryRepository, BackStory>.Instance.GetByID(id));
			}
			if (list != null)
			{
				OnSkillModifierRemoved(list);
			}
			NotifyHidePopupList();
			UpdateSkillMinimum();
			NotifyCharacterUpdated();
			if (!newWorker)
			{
				UpdateGroupPoints();
			}
			RerollSkillGoalPreferences();
		}

		public void SetFreshPseudonym(string id, bool newWorker = false)
		{
			SelectedHumanoid = HumanoidUtils.SetPseudonym(SelectedHumanoid, id);
			NotifyCharacterUpdated();
			if (!newWorker)
			{
				UpdateGroupPoints();
			}
		}

		public void SetPseudonym(string id, bool newWorker = false)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\CharacterEditController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("SetPseudonym: ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(" pseudonym: ");
				messageBuilder.AppendFormatted(SelectedHumanoid.Info.PseudonymId);
			}
			Log.Trace(messageBuilder);
			if (id.Equals(string.Empty))
			{
				id = Repository<PseudonymRepository, Pseudonym>.Instance.GetPseudonym(SelectedHumanoid.Info.IgnoredTypes, (SelectedHumanoid.Info.ReligiousAlignment > 0.5f) ? 1 : (-1));
			}
			Pseudonym pseudonym = null;
			if (id.Equals("none"))
			{
				pseudonym = Repository<PseudonymRepository, Pseudonym>.Instance.GetPseudonym(SelectedHumanoid.Info.PseudonymId);
			}
			SelectedHumanoid = HumanoidUtils.SetPseudonym(SelectedHumanoid, id);
			if (pseudonym != null)
			{
				OnSkillModifierRemoved(pseudonym.SkillModifiers);
			}
			NotifyHidePopupList();
			UpdateSkillMinimum();
			NotifyCharacterUpdated();
			if (!newWorker)
			{
				UpdateGroupPoints();
			}
			RerollSkillGoalPreferences();
		}

		public void RerollPerks()
		{
			foreach (Perk item in new List<Perk>(SelectedHumanoid.Perks))
			{
				RemovePerk(item.GetID());
			}
			foreach (Perk randomPerk in HumanoidUtils.GetRandomPerks(SelectedHumanoid, MonoSingleton<WorkerGenerator>.Instance.Constraints.ForcedPerks))
			{
				AddPerk(randomPerk.GetID());
			}
			NotifyPerksChanged();
		}

		public void SetFreshPerks(List<Perk> perks, bool newWorker = false)
		{
			SelectedHumanoid.SetPerks(perks.ToList());
			NotifyCharacterUpdated();
			if (!newWorker)
			{
				UpdateGroupPoints();
			}
			NotifyPerksChanged();
			RerollSkillGoalPreferences();
		}

		public void AddPerk(string perkId, bool newWorker = false)
		{
			Perk byID = Repository<PerkRepository, Perk>.Instance.GetByID(perkId);
			List<Perk> perks = SelectedHumanoid.Perks;
			if (!(byID == null) && !perks.Contains(byID))
			{
				perks.Add(byID);
				SelectedHumanoid.SetPerks(perks);
				NotifyHidePopupList();
				UpdateSkillMinimum();
				NotifyCharacterUpdated();
				if (!newWorker)
				{
					UpdateGroupPoints();
				}
				RerollSkillGoalPreferences();
			}
		}

		public void RemovePerk(string perkId, bool newWorker = false)
		{
			if (SelectedHumanoid.RemovePerk(perkId))
			{
				Perk byID = Repository<PerkRepository, Perk>.Instance.GetByID(perkId);
				if (byID != null)
				{
					OnSkillModifierRemoved(byID.SkillModifiers);
				}
				UpdateSkillMinimum();
				NotifyCharacterUpdated();
				if (!newWorker)
				{
					UpdateGroupPoints();
				}
				RerollSkillGoalPreferences();
			}
		}

		public int GetTotalSkillPoints()
		{
			int num = 0;
			foreach (WorkerSkill skill in SelectedHumanoid.Skills.Skills)
			{
				num += skill.Level;
			}
			return num;
		}

		public void RerollSkills()
		{
			RerollSkillGoalPreferences();
			HumanoidUtils.GenerateSkillLevels(SelectedHumanoid);
			NotifyCharacterUpdated();
			UpdateGroupPoints(balance: true);
		}

		private void RerollSkillGoalPreferences()
		{
			SelectedHumanoid.RecalcuateGoalPreferencesAndSkillModifiers();
		}

		private void SetFreshSkills(WorkerSkills skills, bool newWorker = false)
		{
			if (skills == null)
			{
				return;
			}
			foreach (WorkerSkill skill in skills.Skills)
			{
				if (skill.Id != SkillType.None)
				{
					SelectedHumanoid.GoalPreferences.SetGoalPreferenceSkillModifier(skill.Id, skill.GetGoalPreferenceLevel());
					SelectedHumanoid.SetSkillLevel(skill.Id, skill.Level);
				}
			}
			UpdateSkillMinimum();
			NotifySkillChanged();
			if (!newWorker)
			{
				UpdateGroupPoints(balance: true);
			}
		}

		private void OnSkillModifierRemoved(List<SkillValuePair> skillModifiers)
		{
			if (skillModifiers == null)
			{
				return;
			}
			foreach (SkillValuePair skillModifier in skillModifiers)
			{
				int num = (int)skillModifier.Value * -1;
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(36, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\CharacterEditController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Modifying skill ");
					messageBuilder.AppendFormatted(skillModifier.Key);
					messageBuilder.AppendLiteral(" with ");
					messageBuilder.AppendFormatted(skillModifier.Value);
					messageBuilder.AppendLiteral(" skill level: ");
					messageBuilder.AppendFormatted(num);
				}
				Log.Trace(messageBuilder);
				ModifySkillLevel(SelectedHumanoid.Skills.GetSkill(skillModifier.Key), num);
			}
		}

		private void UpdateSkillMinimum()
		{
			foreach (WorkerSkill skill in SelectedHumanoid.Skills.Skills)
			{
				if (skill.Level < HumanoidUtils.GetBaseSkillPoints(SelectedHumanoid, skill))
				{
					SetSkillLevel(skill, HumanoidUtils.GetBaseSkillPoints(SelectedHumanoid, skill), newWorker: true);
				}
			}
			NotifySkillChanged();
		}

		public void ModifySkillLevel(WorkerSkill skill, int modifier)
		{
			int level = SelectedHumanoid.Skills.GetSkill(skill.Id).Level + modifier;
			SetSkillLevel(skill, level);
		}

		public void SetSkillLevel(WorkerSkill skill, int level, bool newWorker = false)
		{
			if (level <= HumanoidUtils.GetBaseSkillPoints(SelectedHumanoid, skill))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(41, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\CharacterEditController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Modifying skill ");
					messageBuilder.AppendFormatted(skill.Id);
					messageBuilder.AppendLiteral(" with ");
					messageBuilder.AppendFormatted(level);
					messageBuilder.AppendLiteral(" skill base level: ");
					messageBuilder.AppendFormatted(HumanoidUtils.GetBaseSkillPoints(SelectedHumanoid, skill));
				}
				Log.Trace(messageBuilder);
				level = HumanoidUtils.GetBaseSkillPoints(SelectedHumanoid, skill);
			}
			SelectedHumanoid.SetSkillLevel(skill.Id, level);
			NotifySkillChanged();
			if (!newWorker)
			{
				UpdateGroupPoints();
			}
		}

		public void ModifyReligiousAlignment(int modifier)
		{
			float religiousAlignment = Mathf.Clamp01(SelectedHumanoid.Info.ReligiousAlignment + (float)modifier / 100f);
			SetReligiousAlignment(religiousAlignment);
		}

		public void SetReligiousAlignment(float value)
		{
			SelectedHumanoid.Info.ReligiousAlignment = value;
			NotifyCharacterUpdated();
		}

		public void ModifyAge(int modifier)
		{
			SetAge(SelectedHumanoid.Info.Age + modifier);
		}

		public void SetAge(int value)
		{
			SelectedHumanoid.Info.SetAge(value);
			NotifyCharacterUpdated();
		}

		public void ModifyWeight(int modifier)
		{
			SetWeight(Mathf.RoundToInt(SelectedHumanoid.Info.GetWeight()) + modifier);
		}

		public void SetWeight(int value)
		{
			SelectedHumanoid.Info.SetWeight(value);
			MonoSingleton<HumanoidIconManager>.Instance.OnHumanoidScaleChanged(SelectedHumanoid);
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().WaitForNextFrame().Then(delegate
			{
				UpdateCurrentImage();
				OnAppearanceUpdated();
			});
		}

		public void ModifyHeight(int modifier)
		{
			SetHeight(Mathf.RoundToInt(SelectedHumanoid.Info.Height) + modifier);
		}

		public void SetHeight(int value)
		{
			SelectedHumanoid.Info.SetHeight(value);
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				SetWeight(Mathf.RoundToInt(SelectedHumanoid.Info.GetWeight()));
			});
		}

		public void ShowLoadPresetPopup()
		{
			ShowLoadPresetPopupAction?.Invoke();
		}

		public void ShowSavePresetPopup()
		{
			ShowSavePresetPopupAction?.Invoke();
		}

		private void UpdateGroupPoints(bool balance = false)
		{
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				UpdateCreationPointsTotal(SelectedHumanoid, balance);
			}).ThenWaitFor(0.1f)
				.Then(NotifyGroupPointsUpdate);
		}

		private void UpdateCreationPointsTotal(HumanoidInstance humanoidInstance, bool balance)
		{
			HumanoidUtils.UpdateCreationPoints(humanoidInstance, balance);
		}

		public int GetSkillCreationPoints(HumanoidInstance humanoid, WorkerSkill skill)
		{
			int skillCreationPoints = HumanoidUtils.GetSkillCreationPoints(humanoid, skill);
			if (EditModeEnabled)
			{
				return Mathf.Clamp(skillCreationPoints, 0, Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.MaxCreationPoints);
			}
			return skillCreationPoints;
		}

		public IntRange GetGroupPoints()
		{
			int max = Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.MaxCreationPoints * Workers.Count;
			int num = 0;
			foreach (HumanoidInstance worker in Workers)
			{
				num += worker.Info.CreationPoints;
			}
			return new IntRange(num, max);
		}

		private void CreateWorker(HumanoidInstance newHumanoid)
		{
			SelectedHumanoid = newHumanoid;
			Vector3 spawnPosition = SelectedHumanoid.WorkerBehaviour.WorkerBlueprint.SpawnPosition;
			SelectedHumanoid.SetPosition(new Vector3(spawnPosition.x + (float)Selected, spawnPosition.y, spawnPosition.z));
		}

		private void SetSpawnPosition()
		{
			Vector3 spawnPosition = SelectedHumanoid.WorkerBehaviour.WorkerBlueprint.SpawnPosition;
			SelectedHumanoid.SetPosition(new Vector3(spawnPosition.x + (float)Selected, spawnPosition.y, spawnPosition.z));
		}
	}
}
