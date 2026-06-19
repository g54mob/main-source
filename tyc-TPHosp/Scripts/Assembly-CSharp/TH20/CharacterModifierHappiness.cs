using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierHappiness : CharacterModifier
	{
		public float Percent;

		[SerializeField]
		private bool _staffOnly;

		[SerializeField]
		private LocalisedString _statusText;

		public string StatusTerm()
		{
			if (_statusText.Term != null)
			{
				return _statusText.Term;
			}
			return string.Empty;
		}

		public string StatusText()
		{
			if (_statusText.Term != null)
			{
				return _statusText.Translation;
			}
			return Description();
		}

		public override string Description()
		{
			return LocalisedString.Replace(ScriptLocalization.Character_Modifiers.Happiness_Description_CS, "{[PERCENT]}", StringUtils.FormatPercentageValue(Percent / 100f, prefixPlus: true));
		}

		public bool IsValidFor(Character character)
		{
			if (_staffOnly)
			{
				return character is Staff;
			}
			return true;
		}
	}
}
