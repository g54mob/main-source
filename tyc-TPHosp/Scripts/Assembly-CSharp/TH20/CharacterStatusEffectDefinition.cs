using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterStatusEffectDefinition
	{
		private class ValidCharacterParam
		{
			public bool Valid;

			public CharacterStatusEffectDefinition This;
		}

		public LocalisedString NameLocalisedMale;

		public LocalisedString NameLocalisedFemale;

		public LocalisedString DescriptionLocalisedMale;

		public LocalisedString DescriptionLocalisedFemale;

		[InspectorTooltip("Duration the status effect lasts. 0 == forever!")]
		public readonly float Duration;

		[InspectorTooltip("Is this status effect displayed in character GUI")]
		public readonly bool DisplayInGUI = true;

		[InspectorTooltip("Modifiers to apply for this status effect")]
		public readonly CharacterModifier[] Modifiers;

		private static readonly ValidCharacterParam _validCharacterParam = new ValidCharacterParam();

		public virtual bool HasFinished(float startTime, float timeNow, Character character)
		{
			if (Duration > 0f)
			{
				return timeNow >= startTime + Duration;
			}
			return false;
		}

		public bool IsValidForCharacter(Character character)
		{
			CharacterModifiersComponent modifiersComponent = character.ModifiersComponent;
			if (modifiersComponent != null)
			{
				_validCharacterParam.This = this;
				_validCharacterParam.Valid = true;
				modifiersComponent.IterateModifiersOfType(_validCharacterParam, delegate(ValidCharacterParam param, CharacterModifierIgnoreStatusEffect modifier)
				{
					if (modifier.StatusEffect.NotNull() && modifier.StatusEffect.Instance == param.This)
					{
						param.Valid = false;
					}
				});
				return _validCharacterParam.Valid;
			}
			return true;
		}
	}
}
