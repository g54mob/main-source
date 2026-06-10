using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.UI.Utils
{
	public static class AnimalUtils
	{
		public static string GetLocalizedName(string animalId)
		{
			return GetLocalizedName(Repository<AnimalBaseRepository, Animal>.Instance.GetByID(animalId));
		}

		public static string GetLocalizedName(Animal animal)
		{
			if (animal == null)
			{
				return string.Empty;
			}
			return UiUtils.Localize.GetText(LocKeyUtils.GetName(animal.LocKeys));
		}

		public static string GetLocalizedInfo(Animal animal)
		{
			if (animal == null)
			{
				return string.Empty;
			}
			return UiUtils.Localize.GetText(LocKeyUtils.GetInfo(animal.LocKeys));
		}

		public static string GetIconPath(Animal animal)
		{
			if (animal != null && !string.IsNullOrEmpty(animal.IconPath))
			{
				return animal.IconPath;
			}
			return "UIResources/default_fallback";
		}

		public static List<string> GetInfoLines(Animal animal)
		{
			List<string> list = new List<string>();
			list.AddIfNotNullOrEmpty(GetLocalizedBasHealth(animal));
			list.AddIfNotNullOrEmpty(GetLocalizedDiet(animal));
			return list;
		}

		public static string GetAnimalName(AnimalInstance animalInstance, bool isFullName = true)
		{
			if (!isFullName)
			{
				return animalInstance.GetFullName() + " (" + GetLocalizedName(animalInstance.Blueprint) + ")";
			}
			return GetFullName(animalInstance);
		}

		public static string GetFullName(AnimalInstance animalInstance)
		{
			string localizedType = GetLocalizedType(animalInstance);
			return GetLocalizedName(animalInstance.Blueprint) + " (" + GetLocalizedGender(animalInstance) + ") (" + localizedType + ")";
		}

		public static string GetLocalizedType(AnimalInstance animalInstance)
		{
			return UiUtils.Localize.GetText($"animal_type_{animalInstance.AnimalType}");
		}

		public static string GetLocalizedTypeInfo(AnimalInstance animalInstance)
		{
			return UiUtils.Localize.GetText($"animal_info_{animalInstance.AnimalType}");
		}

		public static string GetLocalizedGender(AnimalInstance animalInstance)
		{
			string text = ((animalInstance.Gender == BodyType.Female) ? "female" : "male");
			return UiUtils.Localize.GetText("general_" + text);
		}

		public static List<string> GetModifiers(AnimalInstance animalInstance)
		{
			List<string> list = new List<string>();
			if (animalInstance.LifePhase != null)
			{
				list.Add(UiUtils.Localize.GetText("animal_life_phase") + ": <style=AltColor>" + UiUtils.GetTimeFormatByDays(animalInstance.AgeInDays) + " " + UiUtils.Localize.GetText(LocKeyUtils.GetName(animalInstance.LifePhase.LocKeys)) + "</style>");
				int caravanStorageCapacity = animalInstance.LifePhase.CaravanStorageCapacity;
				if (caravanStorageCapacity > 0)
				{
					list.Add(string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("animal_storage_capacity"), caravanStorageCapacity));
				}
			}
			if (animalInstance.AnimalType != AnimalType.Domestic && animalInstance.AnimalType != AnimalType.Pet)
			{
				list.Add(string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("info_tamed"), animalInstance.GetTamedPercentage()));
				list.Add(string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("tame_try_left"), animalInstance.CurrentTamingAttemptsLeft));
				if (animalInstance.Blueprint.MinTameSkill > 0)
				{
					list.Add(GetLocalizedRequiredTamingSkill(animalInstance.Blueprint));
				}
				if (!WorkerManager.WorkerExistsCheckJobAndSkill(SkillType.AnimalHandling, JobType.Animal, animalInstance.Blueprint.MinTameSkill))
				{
					list.Add("<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("error_no_skilled_animal_worker") + "</style>");
				}
				string lastTamerName = animalInstance.LastTamerName;
				if (!string.IsNullOrEmpty(lastTamerName))
				{
					string text = UiUtils.Localize.GetText("tame_try_info");
					if (animalInstance.LastTamingAttemptSuccessful)
					{
						list.Add(text + ": <style=AltColor>" + UiUtils.Localize.GetText("general_successful") + " (" + lastTamerName + ")</style>");
					}
					else
					{
						list.Add(text + ": <style=AltColor>" + UiUtils.Localize.GetText("general_failed") + " (" + lastTamerName + ")</style>");
					}
				}
			}
			if (animalInstance.AnimalType == AnimalType.Domestic)
			{
				list.Add(string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("info_trained"), animalInstance.GetTrainedPercentage()));
				list.Add(string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("train_try_left"), animalInstance.CurrentTrainingAttemptsLeft));
				if (animalInstance.Blueprint.MinTrainSkill > 0)
				{
					list.Add(GetLocalizedRequiredTrainingSkill(animalInstance.Blueprint));
				}
				if (!WorkerManager.WorkerExistsCheckJobAndSkill(SkillType.AnimalHandling, JobType.Animal, animalInstance.Blueprint.MinTrainSkill))
				{
					list.Add("<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("error_no_skilled_animal_worker") + "</style>");
				}
				string lastTrainerName = animalInstance.LastTrainerName;
				if (!string.IsNullOrEmpty(lastTrainerName))
				{
					string text2 = UiUtils.Localize.GetText("train_try_info");
					if (animalInstance.LastTrainingAttemptSuccessful)
					{
						list.Add(text2 + ": <style=AltColor>" + UiUtils.Localize.GetText("general_successful") + " (" + lastTrainerName + ")</style>");
					}
					else
					{
						list.Add(text2 + ": <style=AltColor>" + UiUtils.Localize.GetText("general_failed") + " (" + lastTrainerName + ")</style>");
					}
				}
			}
			if (animalInstance.IsProtectiveAgainstPredators)
			{
				list.Add(UiUtils.Localize.GetText("lb_protector"));
			}
			if (animalInstance.AnimalType == AnimalType.Domestic || animalInstance.AnimalType == AnimalType.Pet)
			{
				foreach (AnimalProductionInstance animalProductionInstance in animalInstance.AnimalProductionInstances)
				{
					if (animalProductionInstance != null && !(animalProductionInstance.Blueprint == null))
					{
						string text3 = UiUtils.Localize.GetText(LocKeyUtils.GetName(animalProductionInstance.Blueprint.LocKeys));
						int completionPercentage = animalProductionInstance.GetCompletionPercentage();
						list.Add($"{text3} <style=AltColor>({completionPercentage}%)</style>");
					}
				}
				if (animalInstance.PetOwner != null)
				{
					list.Add(UiUtils.Localize.GetText("assigned_to") + ": " + animalInstance.PetOwner.GetCharacterInfo().FirstName);
				}
				if (!animalInstance.IsInIncognitoMode() && !animalInstance.IsProtectiveAgainstPredators)
				{
					if (animalInstance.IsProtectorInProximity())
					{
						list.Add(UiUtils.Localize.GetText("predators_cant_attack"));
						List<string> protectedBy = GetProtectedBy(animalInstance);
						if (protectedBy != null)
						{
							list.Add(UiUtils.Localize.GetText("protecting_from_predators") + ":");
							list.AddRange(protectedBy);
						}
					}
					else
					{
						WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
						long num = animalInstance.PredatorCannotTargetUntil - dateAndTime.MinutesTotal;
						if (num > 0)
						{
							list.Add(UiUtils.Localize.GetText("predators_cant_attack") + ": <style=AltColor>" + UiUtils.GetTimeFormatByMinutes(num, isDuration: true) + "</style>");
						}
					}
				}
			}
			list.Add(string.Empty);
			list.Add("<style=Desc>" + GetLocalizedTypeInfo(animalInstance) + "</style>");
			return list;
		}

		private static List<string> GetProtectedBy(AnimalInstance animalInstance)
		{
			if (CombatUtils.IsNullOrDisposed(animalInstance) || animalInstance.IsInIncognitoMode() || !animalInstance.IsProtectorInProximity())
			{
				return null;
			}
			MapNode node = animalInstance.GetNode();
			if (node == null)
			{
				return null;
			}
			VillageMap map = animalInstance.Map;
			if (map == null)
			{
				return null;
			}
			Vec3Int position = node.Position;
			List<CreatureBase> outputList = ListPool<CreatureBase>.Get();
			HashSet<WorldObject> outputSet = HashSetPool<WorldObject>.Get();
			map.ProtectorCreatureManager.GetProtectors(position, ref outputList);
			map.ProtectorBuildingManager.GetProtectors(position, ref outputSet);
			List<string> list = new List<string>();
			foreach (CreatureBase item in outputList)
			{
				if (item is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					list.Add(UiUtils.GetWorkerLink(humanoidInstance, humanoidInstance.GetFullName()));
				}
				else if (item is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsNpc())
				{
					list.Add(UiUtils.GetNPCLink(humanoidInstance2, humanoidInstance2.GetFullName()));
				}
				else if (item is AnimalInstance animalInstance2)
				{
					list.Add(UiUtils.GetAnimalLink(animalInstance2, animalInstance2.GetFullName()));
				}
			}
			foreach (WorldObject item2 in outputSet)
			{
				if (item2 is BaseBuildingInstance baseBuildingInstance)
				{
					list.Add("<style=AltColor>" + baseBuildingInstance.GetBuildingName() + "</style>");
				}
				else
				{
					list.Add("<style=AltColor>" + item2.ToString() + "</style>");
				}
			}
			ListPool<CreatureBase>.Return(outputList);
			HashSetPool<WorldObject>.Return(outputSet);
			return list;
		}

		private static string GetLocalizedRequiredTrainingSkill(Animal animal)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("needed_skills");
			int minTrainSkill = animal.MinTrainSkill;
			string spriteAsset = AssetUtils.GetSpriteAsset("animalhandling");
			return $"{text}: {spriteAsset} <style=AltColor>{minTrainSkill}</style>";
		}

		private static string GetLocalizedRequiredTamingSkill(Animal animal)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("needed_skills");
			int minTameSkill = animal.MinTameSkill;
			string spriteAsset = AssetUtils.GetSpriteAsset("animalhandling");
			return $"{text}: {spriteAsset} <style=AltColor>{minTameSkill}</style>";
		}

		private static string GetLocalizedDiet(Animal animal)
		{
			List<string> list = new List<string>();
			foreach (DietModelResource dietResource in animal.DietModel.DietResources)
			{
				switch (dietResource.Type)
				{
				case DietModelResource.DietResourceType.Resource:
					list.Add(ResourceUtils.GetLocalizedLink(dietResource.Value));
					break;
				case DietModelResource.DietResourceType.Group:
					list.Add(UiUtils.GetLocalizedAlmanacLink("resource_group_" + dietResource.Value));
					break;
				case DietModelResource.DietResourceType.Plant:
					list.Add(PlantUtils.GetLocalizedLink(dietResource.Value));
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			string text = string.Join(", ", list);
			return UiUtils.Localize.GetText("general_diet") + " " + text;
		}

		private static string GetLocalizedUnarmedDamage(Animal animal)
		{
			if (animal.LifePhases.Count == 0)
			{
				return string.Empty;
			}
			NSMedieval.StatsSystem.Attribute attribute = animal.LifePhases[0].AttributesList.Attributes.FirstOrDefault((NSMedieval.StatsSystem.Attribute a) => a.Type == AttributeType.UnarmedDamage);
			if (!(attribute == null))
			{
				return $"{UiUtils.Localize.GetText(LocKeyUtils.GetName(attribute.LocKeys))} <style=AltColor>{attribute.Value}</style>";
			}
			return string.Empty;
		}

		private static string GetLocalizedRunChance(Animal animal)
		{
			if (animal.LifePhases.Count == 0)
			{
				return string.Empty;
			}
			NSMedieval.StatsSystem.Attribute attribute = animal.LifePhases[0].AttributesList.Attributes.FirstOrDefault((NSMedieval.StatsSystem.Attribute a) => a.Type == AttributeType.HuntingRunChance);
			if ((object)attribute == null || !attribute.HideInUiSettler)
			{
				return string.Empty;
			}
			return $"{UiUtils.Localize.GetText(LocKeyUtils.GetName(attribute.LocKeys))} <style=AltColor>{attribute.Value * 100f}%</style>";
		}

		private static string GetLocalizedRetaliateChance(Animal animal)
		{
			if (animal.LifePhases.Count == 0)
			{
				return string.Empty;
			}
			NSMedieval.StatsSystem.Attribute attribute = animal.LifePhases[0].AttributesList.Attributes.FirstOrDefault((NSMedieval.StatsSystem.Attribute a) => a.Type == AttributeType.HuntingRetaliateChance);
			if ((object)attribute == null || !attribute.HideInUiSettler)
			{
				return string.Empty;
			}
			return $"{UiUtils.Localize.GetText(LocKeyUtils.GetName(attribute.LocKeys))} <style=AltColor>{attribute.Value * 100f}%</style>";
		}

		private static string GetLocalizedMoveSpeed(Animal animal)
		{
			if (animal.LifePhases == null || animal.LifePhases.Count == 0)
			{
				return string.Empty;
			}
			return string.Format("{0} <style=AltColor>{1}</style>", UiUtils.Localize.GetText("atb_name_MovementSpeed"), animal.LifePhases[0].AttributesList.GetOverride(AttributeType.MovementSpeed));
		}

		private static string GetLocalizedBasHealth(Animal animal)
		{
			return string.Format("{0} <style=AltColor>{1}</style>", UiUtils.Localize.GetText("worker_health"), animal.BaseHealth);
		}

		public static string GetLocalizedHealth(AnimalInstance tradeResourceAnimal)
		{
			if (tradeResourceAnimal == null || tradeResourceAnimal.Stats == null)
			{
				return string.Empty;
			}
			StatInstance stat = tradeResourceAnimal.Stats.GetStat(StatType.Health);
			if (stat == null)
			{
				return string.Empty;
			}
			float normalizedPercentage = stat.GetNormalizedPercentage();
			return string.Format("{0} <style=AltColor>{1:N1}%</style>", UiUtils.Localize.GetText("worker_health"), normalizedPercentage * 100f);
		}

		public static string GetTradeName(AnimalInstance animalInstance)
		{
			string localizedName = GetLocalizedName(animalInstance.Blueprint);
			if (animalInstance.IsUnnamed)
			{
				return localizedName + " (" + GetLocalizedGender(animalInstance) + ")";
			}
			string fullName = animalInstance.GetFullName();
			return MonoSingleton<LocalizationController>.Instance.GetText("animal_type_with_name").Replace("<name>", fullName).Replace("<animal>", localizedName) + " (" + GetLocalizedGender(animalInstance) + ")";
		}

		public static List<string> GetTooltipLines(AnimalInstance animalInstance)
		{
			List<string> list = new List<string>();
			list.Add(GetLocalizedName(animalInstance.Blueprint) + " (" + GetLocalizedGender(animalInstance) + ")");
			CreatureBase petOwner = animalInstance.PetOwner;
			if (petOwner != null)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("assigned_to") + ": " + petOwner.GetCharacterInfo().GetFullName());
			}
			list.Add(GetLocalizedType(animalInstance) ?? "");
			list.Add(GetLocalizedHealth(animalInstance));
			list.AddRange(GetModifiers(animalInstance));
			return list;
		}
	}
}
