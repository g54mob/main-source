using System.Collections.Generic;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public class JobApplicant
	{
		private float _recruitmentFeePercentage;

		public StaffDefinition Definition { get; private set; }

		public Character.Sex Sex { get; private set; }

		public CharacterName Name { get; private set; }

		public int Rank { get; private set; }

		public float Happiness { get; private set; }

		public float Experience { get; private set; }

		public List<QualificationSlot> Qualifications { get; private set; }

		public List<CharModule.CharModuleAssets> CharModuleAssets { get; private set; }

		public CharacterTraits Traits { get; private set; }

		public Material EyeMaterial { get; private set; }

		public Material SkinMaterial { get; private set; }

		public LocalisedString GuiltTripFlavourText { get; private set; }

		public ModularMeshMaterialBindings HairMeshMaterialBindings { get; private set; }

		public StaffRank RankDefinition => Definition._rank[Rank];

		public int Salary => GameAlgorithms.CalculateDesiredSalary(Definition, Rank, Experience, Qualifications, Traits, RankDefinition.SalaryPremiumMultiplier);

		public int RecruitmentFee => Mathf.CeilToInt((float)Salary * (_recruitmentFeePercentage / 100f));

		public int MaxQualifications => Rank + 1;

		public override string ToString()
		{
			return $"{Name.GetCharacterFirstNameDebug()} {Name.GetCharacterLastNameDebug()}:\n  Rank: {Rank}\n  Happiness: {Happiness}\n  Experience: {Experience}\n  Qualifications: {Qualifications.Count}";
		}

		public JobApplicant(StaffDefinition definition, CharacterNameGenerator nameGenerator, float recruitmentFeePercentage, int chanceOfEmptyTrainingSlot, int rank, WeightedList<QualificationDefinition> qualifications, CharacterTraitsManager traitsManager, Metagame metagame, Level level)
		{
			Definition = definition;
			_recruitmentFeePercentage = recruitmentFeePercentage;
			if (definition._forcedGender != Character.Sex.None)
			{
				Sex = definition._forcedGender;
			}
			else
			{
				Sex = ((RandomUtils.GlobalRandomInstance.Next(0, 2) != 0) ? Character.Sex.Female : Character.Sex.Male);
			}
			if (!definition._characterFirstNameOverride.IsNull() && !definition._characterLastNameOverride.IsNull())
			{
				Name = new CharacterName
				{
					FirstName = definition._characterFirstNameOverride,
					LastName = definition._characterLastNameOverride
				};
			}
			else
			{
				Name = nameGenerator.Generate(Sex);
			}
			Rank = rank;
			Happiness = RandomUtils.GlobalRandomInstance.NextFloat(50f, 100f);
			Experience = RandomUtils.GlobalRandomInstance.NextFloat(0f, RankDefinition.MaximumXP * 0.75f);
			Traits = traitsManager.GenerateRandomTraits(definition._type, Sex);
			GuiltTripFlavourText = traitsManager.GetGuiltTripFlavourText(Sex);
			AssignRandomQualifications(qualifications, metagame, level, chanceOfEmptyTrainingSlot);
			SetupVisuals(definition);
		}

		public JobApplicant(GuestTrainerDefinition definition)
		{
			Definition = definition;
			Name = definition.Name;
			Sex = definition.Sex;
			Rank = definition.Rank;
			Happiness = RandomUtils.GlobalRandomInstance.NextFloat(50f, 100f);
			Experience = RandomUtils.GlobalRandomInstance.NextFloat(0f, RankDefinition.MaximumXP * 0.75f);
			Traits = new CharacterTraits(definition.Traits);
			Qualifications = new List<QualificationSlot>();
			GuestTrainerDefinition.Skill[] skills = definition.Skills;
			foreach (GuestTrainerDefinition.Skill skill in skills)
			{
				Qualifications.Add(new QualificationSlot(skill.Qualification.Instance, complete: true));
			}
			SetupVisuals(definition);
		}

		public JobApplicant(RoboJanitorDefinition definition)
		{
			Definition = definition;
			Name = definition.Name;
			Rank = definition.Rank;
			Happiness = RandomUtils.GlobalRandomInstance.NextFloat(50f, 100f);
			Experience = RankDefinition.MaximumXP + 1f;
			Traits = new CharacterTraits(definition.Traits);
			Qualifications = new List<QualificationSlot>();
			SharedInstance<QualificationDefinition>[] qualifications = definition.Qualifications;
			foreach (SharedInstance<QualificationDefinition> sharedInstance in qualifications)
			{
				Qualifications.Add(new QualificationSlot(sharedInstance.Instance, complete: true));
			}
			SetupVisuals(definition);
		}

		private void SetupVisuals(StaffDefinition definition)
		{
			CharModuleUtils.GetCoreRandomAssets(definition.SkinHairMaterialDatabase, definition.EyeMaterialSelection, out var eyeMaterial, out var skinToneMaterial, out var hairMeshMaterialBindings);
			SkinMaterial = skinToneMaterial;
			EyeMaterial = eyeMaterial;
			HairMeshMaterialBindings = hairMeshMaterialBindings;
			CharModuleAssets = new List<CharModule.CharModuleAssets>(CharModule.CharModuleAssets.InitListCapicity);
			definition.RootModule.GetRandomCharacterData(definition.GetModularCategory(Sex), EyeMaterial, SkinMaterial, HairMeshMaterialBindings, CharModuleAssets);
		}

		private void AssignRandomQualifications(WeightedList<QualificationDefinition> qualifications, Metagame metagame, Level level, int chanceOfEmptyTrainingSlot)
		{
			int num = MaxQualifications - 1;
			if (RandomUtils.GlobalRandomInstance.Next(0, 100) > chanceOfEmptyTrainingSlot)
			{
				num++;
			}
			Qualifications = new List<QualificationSlot>(num);
			for (int i = 0; i < num; i++)
			{
				WeightedList<QualificationDefinition> weightedList = new WeightedList<QualificationDefinition>();
				foreach (KeyValuePair<QualificationDefinition, int> item in qualifications.List)
				{
					if (item.Key.ValidFor(Definition._type, MaxQualifications, Qualifications, metagame, level))
					{
						weightedList.Add(item.Key, item.Value);
					}
				}
				QualificationDefinition qualificationDefinition = weightedList.Choose(null, RandomUtils.GlobalRandomInstance);
				if (qualificationDefinition != null)
				{
					Qualifications.Add(new QualificationSlot(qualificationDefinition, complete: true));
				}
			}
		}

		public void Debug_SetTraits(CharacterTraits newTraits)
		{
			Traits = newTraits;
		}
	}
}
