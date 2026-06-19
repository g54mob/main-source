using System.Collections.Generic;
using System.Linq;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterTraitDefinition
	{
		[InspectorTooltip("A short name or keyword for for this trait")]
		public LocalisedString ShortNameLocalisedMale;

		public LocalisedString ShortNameLocalisedFemale;

		[InspectorTooltip("A longer sentence describing this trait, for the CV")]
		public LocalisedString DescriptionLocalisedMale;

		public LocalisedString DescriptionLocalisedFemale;

		[InspectorTooltip("For tooltips, describes the actual effect of this trait")]
		public LocalisedString[] EffectDescriptionLocalised;

		[InspectorTooltip("Which traits are we mutually exclusive with")]
		public readonly SharedInstance<CharacterTraitDefinition>[] MutuallyExclusive;

		[InspectorTooltip("Conditions to be met before trait is active")]
		public readonly CharacterTraitCondition[] Conditions;

		[InspectorTooltip("Modifiers to apply to the character")]
		public readonly CharacterModifier[] Modifiers;

		[InspectorTooltip("Optional staff types this trait is valid for")]
		public readonly StaffDefinition.Type[] ValidStaffTypes;

		public LocalisedString GetShortName(Character.Sex sex)
		{
			if (sex != Character.Sex.Male)
			{
				return ShortNameLocalisedFemale;
			}
			return ShortNameLocalisedMale;
		}

		public LocalisedString GetDescription(Character.Sex sex)
		{
			if (sex != Character.Sex.Male)
			{
				return DescriptionLocalisedFemale;
			}
			return DescriptionLocalisedMale;
		}

		public bool CanAdd(List<CharacterTraitDefinition> traits)
		{
			if (traits.Contains(this))
			{
				return false;
			}
			if (MutuallyExclusive != null)
			{
				SharedInstance<CharacterTraitDefinition>[] mutuallyExclusive = MutuallyExclusive;
				foreach (SharedInstance<CharacterTraitDefinition> sharedInstance in mutuallyExclusive)
				{
					if (traits.Contains(sharedInstance.Instance))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool IsActive(Character character)
		{
			if (Conditions != null)
			{
				CharacterTraitCondition[] conditions = Conditions;
				for (int i = 0; i < conditions.Length; i++)
				{
					if (!conditions[i].IsValid(character))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool IsValidFor(StaffDefinition.Type staffType)
		{
			if (ValidStaffTypes == null || ValidStaffTypes.Length == 0)
			{
				return true;
			}
			return ValidStaffTypes.Contains(staffType);
		}
	}
}
