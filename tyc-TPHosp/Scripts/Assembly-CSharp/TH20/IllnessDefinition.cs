using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IllnessDefinition : IPriceModifier
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class DiagnosisType
		{
			public float _durationMultiplier = 1f;

			public float _diagnosisCertaintyIncrease = 10f;

			public SharedInstance<RoomDefinition> _room;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class DiagnosisUpgrade
		{
			public float _durationMultiplier = 1f;

			public float _diagnosisCertaintyMultiplier = 1f;

			public SharedInstance<ResearchProjectDefinition> _research;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class TreatmentType
		{
			public int _treatmentCost = 100;

			public float _durationMultiplier = 1f;

			public float _effectiveness = 50f;

			public float _effectivenessMax = 100f;

			public SharedInstance<RoomDefinition> _room;

			public SharedInstance<ResearchProjectDefinition> _research;
		}

		public enum ParticleRoot
		{
			Head = 0,
			Core = 1,
			Spine = 2
		}

		public LocalisedString Name;

		public LocalisedString Description;

		[SerializeField]
		private OSManager.Platform _specificPlatforms;

		[InspectorMargin(8)]
		public readonly float _diagnosisCertaintyDefaultIncrease = 10f;

		public readonly float _diagnosisSessionDurationMultiplier = 1f;

		public readonly float _diagnosisCertaintyRevisitGP = 1f;

		[InspectorMargin(8)]
		[FullInspector.InspectorName("Diagnosis Rooms")]
		public readonly DiagnosisType[] _diagnosisTypes;

		[InspectorMargin(8)]
		[InspectorHeader("Upgrades")]
		[FullInspector.InspectorName("Diagnosis Upgrades")]
		public readonly DiagnosisUpgrade[] _diagnosisUpgrades;

		[FullInspector.InspectorName("Treatment Upgrades")]
		public readonly TreatmentType[] _treatmentTypes;

		[InspectorMargin(8)]
		public readonly float _treatmentChanceOfDeathOnFailure = 50f;

		public readonly float _chanceOfGhostOnDeath = 50f;

		[InspectorMargin(8)]
		[InspectorHeader("Research")]
		public readonly float ResearchPointsDiagnosis = 1f;

		public readonly float ResearchPointsTreatmentDeath = 1f;

		public readonly float ResearchPointsTreatmentIneffective = 2f;

		public readonly float ResearchPointsTreatmentCured = 3f;

		public readonly float ResearchPointsGhostCapture = 1f;

		[InspectorMargin(8)]
		[InspectorHeader("Reputation Modifiers")]
		public readonly float _reputationTreatmentSuccess = 1f;

		public readonly float _reputationTreatmentIneffective = -0.5f;

		public readonly float _reputationTreatmentDeath = -1f;

		public readonly float _reputationTreatmentSentHome = -0.25f;

		public readonly float _reputationPatientRageQuit = -0.5f;

		public readonly float _reputationPatientWaitTooLong = -0.25f;

		[InspectorMargin(8)]
		[InspectorHeader("Appearance")]
		public SharedInstance<CharModule.Mask> ModularMask;

		public readonly string _animGraphPostfixOverride;

		public readonly ModularSkinMaterialSelection SkinSelectionOverride;

		public readonly float SirenHeightOffset;

		public readonly GameObject particleFX;

		public readonly ParticleRoot particleRoot;

		[InspectorMargin(8)]
		[InspectorHeader("Need Multipliers")]
		public float _needHungerMultiplier = 1f;

		public float _needThirstMultiplier = 1f;

		public float _needToiletMultiplier = 1f;

		public float _needBoredomMultiplier = 1f;

		public float _needHealthMultiplier = 1f;

		public float _needHappinessMultiplier = 1f;

		[InspectorMargin(8)]
		public float _initialHappinessMin = 50f;

		public float _initialHappinessMax = 100f;

		[InspectorMargin(8)]
		public EntityComponent[] _components;

		[InspectorMargin(8)]
		[InspectorHeader("Treatment Status Effects")]
		[SerializeField]
		private SharedInstance<CharacterStatusEffectDefinition> _statusEffectCured;

		[SerializeField]
		private SharedInstance<CharacterStatusEffectDefinition> _statusEffectIneffective;

		[SerializeField]
		private SharedInstance<CharacterStatusEffectDefinition> _statusEffectDeath;

		[InspectorMargin(8)]
		public SharedInstance<CharacterTraitDefinition>[] _traits;

		public SharedInstance<IllnessMarketingCampaignDefinition> MarketingCampaign;

		public RoomDefinition.Type[] ExcludedDiagnosisRooms;

		[InspectorTooltip("The DLC package that is required to access this illness. null means no DLC required")]
		public SharedInstance<DLCItemDefinition> DLCPackRequired;

		[InspectorMargin(8)]
		[InspectorHeader("Alternative Illness")]
		public float AlternativeIllnessPercentage = 50f;

		public int AlternativeIllnessSpawnCount = 5;

		public SharedInstance<IllnessDefinition> AlternativeIllness;

		[InspectorMargin(8)]
		[InspectorHeader("Achievements")]
		public bool TriggerAchievementOnCured;

		[InspectorShowIf("TriggerAchievementOnCured")]
		public AchievementId Achievement;

		public override string ToString()
		{
			return Name.ToString();
		}

		public void ApplyTreatmentStatusEffect(Patient patient, Treatment.Outcome outcome)
		{
			CharacterStatusEffectDefinition characterStatusEffectDefinition = null;
			switch (outcome)
			{
			case Treatment.Outcome.Cured:
				characterStatusEffectDefinition = (_statusEffectCured.NotNull() ? _statusEffectCured.Instance : null);
				break;
			case Treatment.Outcome.Ineffective:
				characterStatusEffectDefinition = (_statusEffectIneffective.NotNull() ? _statusEffectIneffective.Instance : null);
				break;
			case Treatment.Outcome.Death:
				characterStatusEffectDefinition = (_statusEffectDeath.NotNull() ? _statusEffectDeath.Instance : null);
				break;
			}
			if (characterStatusEffectDefinition != null && patient.ModifiersComponent != null)
			{
				patient.ModifiersComponent.AddStatusEffect(characterStatusEffectDefinition);
			}
		}

		public float GetTreatmentReputationModifier(Treatment.Outcome outcome)
		{
			return outcome switch
			{
				Treatment.Outcome.Cured => _reputationTreatmentSuccess, 
				Treatment.Outcome.Ineffective => _reputationTreatmentIneffective, 
				Treatment.Outcome.Death => _reputationTreatmentDeath, 
				Treatment.Outcome.Unknown => _reputationTreatmentSentHome, 
				_ => 0f, 
			};
		}

		private DiagnosisUpgrade GetDiagnosisUpgrade(ResearchManager researchManager)
		{
			DiagnosisUpgrade result = null;
			if (_diagnosisUpgrades != null)
			{
				DiagnosisUpgrade[] diagnosisUpgrades = _diagnosisUpgrades;
				foreach (DiagnosisUpgrade diagnosisUpgrade in diagnosisUpgrades)
				{
					ResearchProject researchProject = (diagnosisUpgrade._research ? researchManager.GetProject(diagnosisUpgrade._research.Instance) : null);
					if (researchProject == null || researchProject.IsComplete())
					{
						result = diagnosisUpgrade;
					}
				}
			}
			return result;
		}

		private DiagnosisType GetDiagnosisType(Room room)
		{
			if (_diagnosisTypes != null)
			{
				DiagnosisType[] diagnosisTypes = _diagnosisTypes;
				foreach (DiagnosisType diagnosisType in diagnosisTypes)
				{
					if (diagnosisType._room.NotNull() && room.Definition == diagnosisType._room.Instance)
					{
						return diagnosisType;
					}
				}
			}
			return null;
		}

		public float GetDiagnosisCertainty(Room room, Patient patient, ResearchManager researchManager, ref DiagnosisCalculationBreakdown breakdown)
		{
			DiagnosisUpgrade diagnosisUpgrade = GetDiagnosisUpgrade(researchManager);
			float num = (breakdown.Illness = GetDiagnosisType(room)?._diagnosisCertaintyIncrease ?? _diagnosisCertaintyDefaultIncrease);
			if (diagnosisUpgrade != null)
			{
				num *= diagnosisUpgrade._diagnosisCertaintyMultiplier;
				breakdown.UpgradeMultiplier = diagnosisUpgrade._diagnosisCertaintyMultiplier;
			}
			else
			{
				breakdown.UpgradeMultiplier = 1f;
			}
			num *= room.DiagnosisMultiplier;
			breakdown.RoomMultiplier = room.DiagnosisMultiplier;
			if (room.Definition._type == RoomDefinition.Type.GPOffice && patient.DiagnosisCertainty > 0f)
			{
				num *= patient.Illness._diagnosisCertaintyRevisitGP;
				breakdown.RevistGP = patient.Illness._diagnosisCertaintyRevisitGP;
			}
			else
			{
				breakdown.RevistGP = 1f;
			}
			if (patient.Interaction != null)
			{
				float itemMultiplier = 1f;
				patient.Interaction.ParentRoomItem.IterateModifiers(delegate(RoomModifierDiagnosis diagnosis)
				{
					if (!diagnosis.RoomWide)
					{
						itemMultiplier += diagnosis.Percentage / 100f;
					}
				});
				num *= itemMultiplier;
				breakdown.ItemMultiplier = itemMultiplier;
			}
			return num;
		}

		public float GetDiagnosisDuration(Room room, ResearchManager researchManager)
		{
			DiagnosisUpgrade diagnosisUpgrade = GetDiagnosisUpgrade(researchManager);
			DiagnosisType diagnosisType = GetDiagnosisType(room);
			float num = room.Definition._sessionDurationDefault * _diagnosisSessionDurationMultiplier;
			if (diagnosisUpgrade != null)
			{
				num *= diagnosisUpgrade._durationMultiplier;
			}
			if (diagnosisType != null)
			{
				num *= diagnosisType._durationMultiplier;
			}
			return num;
		}

		public bool UsesTreatmentRoom(RoomDefinition room)
		{
			TreatmentType[] treatmentTypes = _treatmentTypes;
			foreach (TreatmentType treatmentType in treatmentTypes)
			{
				if (treatmentType._room.NotNull() && treatmentType._room.Instance == room)
				{
					return true;
				}
			}
			return false;
		}

		public TreatmentType GetBestTreatmentType(RoomDefinition roomType, ResearchManager researchManager)
		{
			TreatmentType result = null;
			TreatmentType[] treatmentTypes = _treatmentTypes;
			foreach (TreatmentType treatmentType in treatmentTypes)
			{
				if (roomType == null || (treatmentType._room.NotNull() && treatmentType._room.Instance == roomType))
				{
					ResearchProject researchProject = ((treatmentType._research != null) ? researchManager.GetProject(treatmentType._research.Instance) : null);
					if (researchProject == null || researchProject.IsComplete())
					{
						result = treatmentType;
					}
				}
			}
			return result;
		}

		public float GetTreatmentDuration(Room room, ResearchManager researchManager)
		{
			TreatmentType bestTreatmentType = GetBestTreatmentType(room.Definition, researchManager);
			if (bestTreatmentType == null)
			{
				return room.Definition._sessionDurationDefault;
			}
			return room.Definition._sessionDurationDefault * bestTreatmentType._durationMultiplier;
		}

		public int GetTreatmentCostForRoom(RoomDefinition roomDefinition, ResearchManager researchManager, FinanceManager financeManager)
		{
			TreatmentType bestTreatmentType = GetBestTreatmentType(roomDefinition, researchManager);
			if (bestTreatmentType == null)
			{
				return 0;
			}
			return Mathf.CeilToInt((float)bestTreatmentType._treatmentCost * financeManager.LocalMarketRateModifier);
		}

		public void GetTreatmentChanceOfSuccessRange(Patient patient, out float chanceMin, out float chanceMax)
		{
			TreatmentType bestTreatmentType = GetBestTreatmentType(null, patient.Level.ResearchManager);
			chanceMin = bestTreatmentType._effectiveness * patient.DiagnosisCertainty / 100f;
			chanceMax = bestTreatmentType._effectivenessMax * patient.DiagnosisCertainty / 100f;
		}

		public RoomDefinition GetTreatmentRoom(Patient patient, ResearchManager researchManager)
		{
			return GetBestTreatmentType(null, researchManager)?._room.Instance;
		}

		public float GetAttributeMultiplier(CharacterAttributes.Type type)
		{
			return type switch
			{
				CharacterAttributes.Type.Hunger => _needHungerMultiplier, 
				CharacterAttributes.Type.Thirst => _needThirstMultiplier, 
				CharacterAttributes.Type.Toilet => _needToiletMultiplier, 
				CharacterAttributes.Type.Boredom => _needBoredomMultiplier, 
				CharacterAttributes.Type.Health => _needHealthMultiplier, 
				CharacterAttributes.Type.Happiness => _needHappinessMultiplier, 
				_ => 1f, 
			};
		}

		public float GetInitialHappiness()
		{
			return RandomUtils.GlobalRandomInstance.NextFloat(_initialHappinessMin, _initialHappinessMax);
		}

		public float GetTreatmentResearchPoints(Treatment.Outcome outcome)
		{
			return outcome switch
			{
				Treatment.Outcome.Cured => ResearchPointsTreatmentCured, 
				Treatment.Outcome.Ineffective => ResearchPointsTreatmentIneffective, 
				Treatment.Outcome.Death => ResearchPointsTreatmentDeath, 
				_ => throw new ArgumentOutOfRangeException("outcome", outcome, null), 
			};
		}

		public bool DLCIsValid()
		{
			if (!DLCPackRequired.IsNull())
			{
				return DLCUtils.IsDLCInstalled(DLCPackRequired.Instance);
			}
			return true;
		}

		public IllnessDefinition ChooseDefinition(int numSpawned)
		{
			if (AlternativeIllness.IsNull())
			{
				return this;
			}
			if (AlternativeIllness.Instance.IsPlatformValid(OSManager.GetPlatform()) && UnityEngine.Random.Range(0f, 100f) < AlternativeIllnessPercentage && numSpawned > AlternativeIllnessSpawnCount)
			{
				return AlternativeIllness.Instance;
			}
			return this;
		}

		public bool IsPlatformValid(OSManager.Platform platform)
		{
			bool num = _specificPlatforms.HasFlag(OSManager.GetPlatform());
			bool flag = _specificPlatforms.Equals(OSManager.Platform.None);
			return num || flag;
		}
	}
}
