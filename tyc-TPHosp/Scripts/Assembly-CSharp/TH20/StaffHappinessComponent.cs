#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffHappinessComponent : CharacterHappinessComponent
	{
		private Staff _staff;

		private float _targetHappiness;

		private bool _threatenToLeave;

		private static Character.Sex _traitGender;

		protected override Type ValidEntityType()
		{
			return typeof(Staff);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_staff = GetOwner<Staff>();
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffStopThreateningToLeave = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffStopThreateningToLeave, new Action<Staff>(OnStaffStopThreateningToLeave));
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffStopThreateningToLeave = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffStopThreateningToLeave, new Action<Staff>(OnStaffStopThreateningToLeave));
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffStopThreateningToLeave = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffStopThreateningToLeave, new Action<Staff>(OnStaffStopThreateningToLeave));
			base.Destroy();
		}

		protected override void TickInternal(float deltaTime)
		{
			if (_staff == null || _staff.Definition == null || _staff.Level == null || _staff.Level.CharacterEvents == null)
			{
				return;
			}
			AttributeFloat happiness = _staff.Happiness;
			if (happiness != null)
			{
				float num = happiness.Value();
				_targetHappiness = CalculateTargetHappiness();
				float modifyValue = (_targetHappiness - num) * _staff.Definition.HappinessRateOfChange * deltaTime;
				happiness.Modify(modifyValue, 1f);
				if (!_staff.HasBeenFired() && happiness.Value() < GameAlgorithms.Config.StaffLowHappinessThreshold && _targetHappiness < GameAlgorithms.Config.StaffLowHappinessThreshold && !_threatenToLeave)
				{
					_threatenToLeave = true;
					_staff.Level.CharacterEvents.OnStaffThreatenToLeave.InvokeSafe(_staff);
				}
			}
		}

		private void OnStaffStopThreateningToLeave(Staff staff)
		{
			if (staff == _staff && _threatenToLeave)
			{
				_threatenToLeave = false;
			}
		}

		private float CalculateTargetHappiness()
		{
			Stats.Clear();
			CalcEnergyModifier();
			CalculateNeedsModifier();
			CalculateEnvironmentalModifier();
			CalculateRoomPrestigeModifier();
			CalculatePaySatisfactionModifier();
			CalculateTrainingSlotsModifier();
			CalculatePromotionWantedModifier();
			CalculateStatusEffectsModifier();
			CalculateQualificationModifier();
			CalculateTraitsModifier();
			CalculateLevelModifier();
			CalculateStaffRankModifier();
			float num = 50f;
			foreach (StatModifier stat in Stats)
			{
				num += stat.Value;
			}
			return num;
		}

		private void CalcEnergyModifier()
		{
			if (_staff.Energy == null)
			{
				Logging.Error(LogChannels.AI, "CalcEnergyModifier has staff with null energy.  Staff: {0}", _staff.Name);
				return;
			}
			if (_staff.Definition == null)
			{
				Logging.Error(LogChannels.AI, "CalcEnergyModifier has staff with null definition.  Staff: {0}", _staff.Name);
				return;
			}
			float num = _staff.Energy.Value();
			if (num >= _staff.Definition.EnergyThresholdEnergised)
			{
				Stats.Add(new StatModifier
				{
					Term = "Staff/UnhappyFlavour/EnergyEnergised_CS",
					Value = _staff.Definition.HappinessEnergised
				});
			}
			else if (num <= _staff.Definition.EnergyThresholdExhausted)
			{
				Stats.Add(new StatModifier
				{
					Term = "Staff/UnhappyFlavour/EnergyExhausted_CS",
					Value = _staff.Definition.HappinessExhausted
				});
			}
			else if (num <= _staff.Definition.EnergyThresholdTired)
			{
				Stats.Add(new StatModifier
				{
					Term = "Staff/UnhappyFlavour/EnergyTired_CS",
					Value = _staff.Definition.HappinessTired
				});
			}
		}

		private void CalculateRoomPrestigeModifier()
		{
			Room roomUsing = _staff.RoomUsing;
			if (roomUsing != null && !roomUsing.Definition.IsHospitalOrBay)
			{
				RoomPrestige roomPrestige = GameAlgorithms.CalculateRoomPrestige(roomUsing.FloorPlan);
				if (roomPrestige.Data != null)
				{
					Stats.Add(new StatModifier
					{
						Term = roomPrestige.Data.HappinessDescription.Term,
						Value = roomPrestige.Data.HappinessModifier
					});
				}
			}
		}

		private void CalculatePaySatisfactionModifier()
		{
			StaffDefinition.Satisfaction satisfactionLevel;
			float value = GameAlgorithms.CalculatePaySatisfactionValue(_staff.Definition, _staff.GetDesiredSalaryDifference(), out satisfactionLevel);
			string term = satisfactionLevel switch
			{
				StaffDefinition.Satisfaction.VeryUnhappy => "Staff/UnhappyFlavour/PaySatisfaction_VeryUnhappy_CS", 
				StaffDefinition.Satisfaction.Unhappy => "Staff/UnhappyFlavour/PaySatisfaction_Unhappy_CS", 
				StaffDefinition.Satisfaction.Satisfied => "Staff/UnhappyFlavour/PaySatisfaction_Satisfied_CS", 
				StaffDefinition.Satisfaction.Happy => "Staff/UnhappyFlavour/PaySatisfaction_Happy_CS", 
				StaffDefinition.Satisfaction.VeryHappy => "Staff/UnhappyFlavour/PaySatisfaction_VeryHappy_CS", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			Stats.Add(new StatModifier
			{
				Term = term,
				Value = value
			});
		}

		private void CalculateTrainingSlotsModifier()
		{
			int num = _staff.MaxQualifications - _staff.Qualifications.Count;
			if (num != 0 && _staff.CurrentMode != Staff.Mode.Trained && base.Level.Metagame.HasUnlockedRoomOfType(RoomDefinition.Type.Training))
			{
				Stats.Add(new StatModifier
				{
					Term = "Staff/UnhappyFlavour/TrainingSlots_CS",
					Value = (float)num * _staff.Definition.HappinessEmptyTrainingSlot
				});
			}
		}

		private void CalculatePromotionWantedModifier()
		{
			if (_staff.IsReadyForPromotion)
			{
				Stats.Add(new StatModifier
				{
					Term = "Staff/UnhappyFlavour/PromotionWanted_CS",
					Value = _staff.Definition.HappinessReadyForPromotion
				});
			}
		}

		private void CalculateQualificationModifier()
		{
			foreach (QualificationSlot qualification in _staff.Qualifications)
			{
				CharacterModifierHappiness characterModifierHappiness = null;
				CharacterModifier[] modifiers = qualification.Definition.Modifiers;
				for (int i = 0; i < modifiers.Length; i++)
				{
					characterModifierHappiness = modifiers[i] as CharacterModifierHappiness;
					if (characterModifierHappiness != null)
					{
						break;
					}
				}
				if (characterModifierHappiness != null)
				{
					Stats.Add(new StatModifier
					{
						Term = qualification.Definition.NameLocalised.Term,
						Value = characterModifierHappiness.Percent
					});
				}
			}
		}

		private void CalculateTraitsModifier()
		{
			if (_staff.Traits != null)
			{
				_traitGender = _staff.Gender;
				_staff.Traits.IterateActiveModifiers(Stats, delegate(List<StatModifier> stats, CharacterModifierHappiness happiness, CharacterTraitDefinition trait)
				{
					stats.Add(new StatModifier
					{
						Term = trait.GetShortName(_traitGender).Term,
						Value = happiness.Percent,
						HideInGUI = true
					});
				});
			}
		}

		private void CalculateLevelModifier()
		{
			float staffHappinessModifier = _staff.Level.Config.StaffHappinessModifier;
			if (staffHappinessModifier > 0f)
			{
				Stats.Add(new StatModifier
				{
					Term = "Staff/UnhappyFlavour/LevelIsNice_CS",
					Value = staffHappinessModifier
				});
			}
			else
			{
				Stats.Add(new StatModifier
				{
					Term = "Staff/UnhappyFlavour/Level_CS",
					Value = staffHappinessModifier
				});
			}
		}

		private void CalculateStaffRankModifier()
		{
			string term = string.Empty;
			switch (_staff.Definition._type)
			{
			case StaffDefinition.Type.Doctor:
				switch (_staff.Rank)
				{
				case 0:
					term = "Staff/UnhappyFlavour/StaffRankDoctor1_CS";
					break;
				case 1:
					term = "Staff/UnhappyFlavour/StaffRankDoctor2_CS";
					break;
				case 2:
					term = "Staff/UnhappyFlavour/StaffRankDoctor3_CS";
					break;
				case 3:
					term = "Staff/UnhappyFlavour/StaffRankDoctor4_CS";
					break;
				case 4:
					term = "Staff/UnhappyFlavour/StaffRankDoctor5_CS";
					break;
				}
				break;
			case StaffDefinition.Type.Nurse:
				switch (_staff.Rank)
				{
				case 0:
					term = "Staff/UnhappyFlavour/StaffRankNurse1_CS";
					break;
				case 1:
					term = "Staff/UnhappyFlavour/StaffRankNurse2_CS";
					break;
				case 2:
					term = "Staff/UnhappyFlavour/StaffRankNurse3_CS";
					break;
				case 3:
					term = "Staff/UnhappyFlavour/StaffRankNurse4_CS";
					break;
				case 4:
					term = "Staff/UnhappyFlavour/StaffRankNurse5_CS";
					break;
				}
				break;
			case StaffDefinition.Type.Assistant:
				switch (_staff.Rank)
				{
				case 0:
					term = "Staff/UnhappyFlavour/StaffRankAssistant1_CS";
					break;
				case 1:
					term = "Staff/UnhappyFlavour/StaffRankAssistant2_CS";
					break;
				case 2:
					term = "Staff/UnhappyFlavour/StaffRankAssistant3_CS";
					break;
				case 3:
					term = "Staff/UnhappyFlavour/StaffRankAssistant4_CS";
					break;
				case 4:
					term = "Staff/UnhappyFlavour/StaffRankAssistant5_CS";
					break;
				}
				break;
			case StaffDefinition.Type.Janitor:
				switch (_staff.Rank)
				{
				case 0:
					term = "Staff/UnhappyFlavour/StaffRankJanitor1_CS";
					break;
				case 1:
					term = "Staff/UnhappyFlavour/StaffRankJanitor2_CS";
					break;
				case 2:
					term = "Staff/UnhappyFlavour/StaffRankJanitor3_CS";
					break;
				case 3:
					term = "Staff/UnhappyFlavour/StaffRankJanitor4_CS";
					break;
				case 4:
					term = "Staff/UnhappyFlavour/StaffRankJanitor5_CS";
					break;
				}
				break;
			}
			if (_staff.RankDefinition != null)
			{
				Stats.Add(new StatModifier
				{
					Term = term,
					Value = _staff.RankDefinition.HappinessModifier,
					HideInGUI = true
				});
			}
		}

		protected override string FixupStatName(string statName)
		{
			if (statName != null)
			{
				return statName.Replace("{[LEVELNAME]}", _staff.Level.Config.GetLocalisedDisplayName());
			}
			return "???";
		}

		public string GetAsDebugString()
		{
			int num = 0;
			string empty = string.Empty;
			empty = empty + "Target Happiness: " + _targetHappiness + "\n";
			foreach (StatModifier stat in Stats)
			{
				empty += $"\"{GetTranslatedStatName(stat.Term)}\": {stat.Value}, ";
				if (num++ == 4)
				{
					num = 0;
					empty += "\n";
				}
			}
			return empty;
		}
	}
}
