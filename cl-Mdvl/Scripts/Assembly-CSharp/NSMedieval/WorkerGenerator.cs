using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NSMedieval
{
	public class WorkerGenerator : MonoSingleton<WorkerGenerator>
	{
		private System.Random random;

		public Scenario.WorkerConstraints Constraints
		{
			get
			{
				if (SceneManager.GetActiveScene().name == "HomeScene" || GlobalSaveController.CurrentVillageData == null || (object)GlobalSaveController.CurrentVillageData.Scenario == null)
				{
					return MonoSingleton<GameStartController>.Instance.SelectedScenario.VillagerConstraints;
				}
				return GlobalSaveController.CurrentVillageData.Scenario.VillagerConstraints;
			}
		}

		private void Start()
		{
			random = new System.Random();
		}

		public HumanoidInstance GenerateWorker(List<SerializableIdValuePair> forcedPerks = null)
		{
			return GenerateWorker(Constraints.DefaultClothes.GetRandom(), string.Empty, forcedPerks);
		}

		public HumanoidInstance GenerateWorker(BodyType defaultBodyType, List<SerializableIdValuePair> forcedPerks = null)
		{
			return GenerateWorker(Constraints.DefaultClothes.GetRandom(), defaultBodyType.ToString(), forcedPerks);
		}

		public HumanoidInstance GenerateWorker(string defaultClothes, string defaultGender, List<SerializableIdValuePair> forcedPerks = null)
		{
			BodyType bodyType = ((random.Next(0, 100) >= Constraints.ForceBodyType) ? BodyType.Male : BodyType.Female);
			if (!string.IsNullOrEmpty(defaultGender) && Enum.TryParse<BodyType>(defaultGender, ignoreCase: true, out var result))
			{
				bodyType = result;
			}
			HumanoidInstance humanoidInstance = new HumanoidInstance("humanoid", Vector3.zero, producedFromGenerator: true);
			humanoidInstance.SetActiveBehaviour<WorkerBehaviour>(activate: false).EquipItemOnSpawn = defaultClothes;
			float height = GetHeight(bodyType);
			float weightCoefficient = GetWeightCoefficient(height);
			List<WorkerCharacteristicType> physicalIgnoreTypes = HumanoidUtils.GetPhysicalIgnoreTypes(new List<WorkerCharacteristicType>(), bodyType, height, weightCoefficient);
			int randomReligiousAlignment = GetRandomReligiousAlignment();
			Background background = Repository<BackgroundRepository, Background>.Instance.GetBackground(physicalIgnoreTypes, randomReligiousAlignment);
			BackStory background2 = Repository<BackStoryRepository, BackStory>.Instance.GetBackground(physicalIgnoreTypes, randomReligiousAlignment);
			humanoidInstance.SetInfo(new HumanoidInfo(bodyType, GetAge(background), HumanoidUtils.GetBirthday(), height, weightCoefficient, Repository<VillageNameRepository, VillageNames>.Instance.GetRandomOldName(), background.GetID(), background2.GetID(), 0.5f));
			humanoidInstance.Info.SetPhysicalLook(GetPhysicalLook(humanoidInstance));
			humanoidInstance.Info.SetIgnoredTypes(physicalIgnoreTypes);
			humanoidInstance = HumanoidUtils.SetBackground(humanoidInstance, background);
			humanoidInstance = HumanoidUtils.SetBackStory(humanoidInstance, background2);
			humanoidInstance = HumanoidUtils.SetPseudonym(humanoidInstance);
			if (forcedPerks == null)
			{
				forcedPerks = new List<SerializableIdValuePair>();
			}
			forcedPerks.AddRange(Constraints.ForcedPerks);
			humanoidInstance = HumanoidUtils.SetPerks(humanoidInstance, forcedPerks);
			humanoidInstance.RecalcuateGoalPreferencesAndSkillModifiers();
			HumanoidUtils.GenerateSkillLevels(humanoidInstance);
			HumanoidUtils.UpdateCreationPoints(humanoidInstance, balance: true);
			return humanoidInstance;
		}

		private float GetWeightCoefficient(float height)
		{
			if (Constraints.WeightRange.Max > 0)
			{
				return (float)Constraints.WeightRange.RandomMaxInclusive() / Mathf.Pow(height / 100f, 2f);
			}
			return Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.WeightCoefficientRange.Random();
		}

		private WorkerPhysicalLook GetPhysicalLook(HumanoidInstance humanoid)
		{
			WorkerBodyPreview componentInChildren = UnityEngine.Object.Instantiate(MonoRepository<HumanoidImageRepository, KeyGameObjectPair>.Instance.GetPrefab(humanoid.Info.GetPhysicalLookKey()), new Vector3(-1000f, -1000f, -1000f), Quaternion.identity, base.gameObject.transform).GetComponentInChildren<WorkerBodyPreview>();
			componentInChildren.Setup(humanoid);
			componentInChildren.RandomizeAppearance();
			WorkerPhysicalLook workerPhysicalLook = new WorkerPhysicalLook();
			workerPhysicalLook.Initialize();
			workerPhysicalLook.SetWorkerBody(componentInChildren.Instance.Info.PhysicalLook.WorkerBody);
			workerPhysicalLook.SetBodyColors(componentInChildren.Instance.Info.PhysicalLook.BodyColors);
			workerPhysicalLook.SetPossibleBodyParts(componentInChildren.GetPossibleParts());
			UnityEngine.Object.Destroy(componentInChildren.transform.parent.parent.gameObject);
			return workerPhysicalLook;
		}

		private int GetRandomReligiousAlignment()
		{
			if (!(UnityEngine.Random.Range(0f, 100f) >= (float)Constraints.ForceReligion + 0.001f))
			{
				return -1;
			}
			return 1;
		}

		private float GetHeight(BodyType bodyType)
		{
			if (Constraints.HeightRange.Max > 0)
			{
				return Constraints.HeightRange.RandomMaxInclusive();
			}
			return Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.DefaultHeight[(int)bodyType] + Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.DefaultHeight[(int)bodyType] / 100f * Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.HeightFactor.Random();
		}

		private int GetAge(Background background)
		{
			if (Constraints.AgeRange.Max > 0)
			{
				return Constraints.AgeRange.RandomMaxInclusive();
			}
			if (background.AgeRange.Max != 0)
			{
				return background.AgeRange.RandomMaxInclusive();
			}
			return Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.AgeRange.RandomMaxInclusive();
		}
	}
}
