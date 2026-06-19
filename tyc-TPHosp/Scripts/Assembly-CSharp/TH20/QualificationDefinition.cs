using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class QualificationDefinition
	{
		public readonly LocalisedString NameLocalised;

		[SerializeField]
		private readonly LocalisedString DescriptionLocalised;

		public readonly Sprite Icon;

		public readonly float TrainingPoints;

		public readonly StaffDefinition.Type StaffType;

		public readonly StaffDefinition.Type[] AdditionalStaffTypes;

		public readonly SharedInstance<QualificationDefinition>[] RequiredQualifications;

		public readonly CharacterModifier[] Modifiers;

		public readonly SharedInstance<ResearchProjectDefinition> RequiredResearchProject;

		public readonly SharedInstance<RoomDefinition> RequiredRoomUnlocked;

		public readonly SharedInstance<RoomDefinition> RequiredIllnessWithTreatmentRoom;

		public override string ToString()
		{
			return NameLocalised.ToString();
		}

		public bool HasQualification(List<QualificationSlot> qualificationSlots)
		{
			return qualificationSlots.Any((QualificationSlot qualification) => qualification.Definition == this);
		}

		public bool HasCompletedQualification(List<QualificationSlot> qualificationSlots)
		{
			for (int i = 0; i < qualificationSlots.Count; i++)
			{
				if (qualificationSlots[i].Definition == this && qualificationSlots[i].IsComplete())
				{
					return true;
				}
			}
			return false;
		}

		public bool ValidFor(Staff staff)
		{
			return ValidFor(staff.Definition._type, staff.MaxQualifications, staff.Qualifications, staff.Level.Metagame, staff.Level);
		}

		public bool ValidForExcludeIncomplete(Staff staff)
		{
			return ValidForExcludeIncomplete(staff.Definition._type, staff.MaxQualifications, staff.Qualifications, staff.Level.Metagame, staff.Level);
		}

		public bool ValidFor(StaffDefinition.Type staffType, int maxQualifications, List<QualificationSlot> qualificationSlots, Metagame metagame, Level level)
		{
			return ValidFor(staffType, maxQualifications, qualificationSlots, metagame, level, excludeIncomplete: false);
		}

		public bool ValidForExcludeIncomplete(StaffDefinition.Type staffType, int maxQualifications, List<QualificationSlot> qualificationSlots, Metagame metagame, Level level)
		{
			return ValidFor(staffType, maxQualifications, qualificationSlots, metagame, level, excludeIncomplete: true);
		}

		private bool ValidFor(StaffDefinition.Type staffType, int maxQualifications, List<QualificationSlot> qualificationSlots, Metagame metagame, Level level, bool excludeIncomplete)
		{
			if (StaffType != staffType && StaffType != StaffDefinition.Type.None)
			{
				return false;
			}
			if (AdditionalStaffTypes != null && AdditionalStaffTypes.Length != 0 && !AdditionalStaffTypes.Contains(staffType))
			{
				return false;
			}
			if (excludeIncomplete)
			{
				if (HasQualification(qualificationSlots) && HasCompletedQualification(qualificationSlots))
				{
					return false;
				}
				if (qualificationSlots.Count != 0 && qualificationSlots.Count == maxQualifications && qualificationSlots[qualificationSlots.Count - 1].IsComplete())
				{
					return false;
				}
			}
			else
			{
				if (HasQualification(qualificationSlots))
				{
					return !HasCompletedQualification(qualificationSlots);
				}
				if (qualificationSlots.Count == maxQualifications)
				{
					return false;
				}
			}
			if (!RequiredQualifications.IsEmpty())
			{
				bool flag = false;
				SharedInstance<QualificationDefinition>[] requiredQualifications = RequiredQualifications;
				for (int i = 0; i < requiredQualifications.Length; i++)
				{
					if (requiredQualifications[i].Instance.HasCompletedQualification(qualificationSlots))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			if (RequiredResearchProject != null && RequiredResearchProject.Instance != null && !metagame.HasCompletedResearchProject(RequiredResearchProject.Instance))
			{
				return false;
			}
			if (RequiredRoomUnlocked != null && RequiredRoomUnlocked.Instance != null)
			{
				RoomDefinition instance = RequiredRoomUnlocked.Instance;
				if (!metagame.HasUnlocked(instance))
				{
					return false;
				}
				bool num = level.IsSandbox();
				LevelRoomList levelRoomList = (num ? level.GetSandboxSettings().GetLevelRoomBlacklist() : level.Config.GetLevelRoomBlacklist());
				LevelRoomList levelRoomList2 = (num ? level.GetSandboxSettings().GetLevelRoomWhitelist() : level.Config.GetLevelRoomWhitelist());
				if (instance.MustBeWhiteListed && (!(levelRoomList2 != null) || !levelRoomList2.RoomList.Contains(RequiredRoomUnlocked)))
				{
					return false;
				}
				if (!(levelRoomList == null) && levelRoomList.RoomList.Contains(RequiredRoomUnlocked))
				{
					return false;
				}
			}
			if (RequiredIllnessWithTreatmentRoom != null && RequiredIllnessWithTreatmentRoom.Instance != null && !level.CharacterManager.IllnessWithTreatmentRoomExists(RequiredIllnessWithTreatmentRoom.Instance))
			{
				return false;
			}
			return true;
		}

		public void IterateModifiersOfType<P, T>(P param, Action<P, T> action) where T : CharacterModifier
		{
			Type typeFromHandle = typeof(T);
			CharacterModifier[] modifiers = Modifiers;
			foreach (CharacterModifier characterModifier in modifiers)
			{
				if (characterModifier.GetType() == typeFromHandle)
				{
					action(param, (T)characterModifier);
				}
			}
		}

		public string GetTooltipText()
		{
			return CharacterModifier.GetTooltipText(DescriptionLocalised.Translation, Modifiers);
		}
	}
}
