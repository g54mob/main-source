using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterFlavourTraits
	{
		public string TraitTermMale = "Traits/Trait_{0:000}";

		public string TraitTermFemale = "Traits/Trait_{0:000}";

		public int TraitCount = 63;

		public string GenerateFlavour(int numTraits, Character.Sex sex)
		{
			string text = string.Empty;
			string format = ((sex == Character.Sex.Male) ? TraitTermMale : TraitTermFemale);
			for (int i = 0; i < numTraits; i++)
			{
				string text2 = string.Format(format, Random.Range(0, TraitCount));
				text = text + text2 + ".";
			}
			return text;
		}

		public string Debug_GenerateSpecificFlavour(int traitID, Character.Sex sex)
		{
			_ = string.Empty;
			return LocalizationManager.GetTranslation(string.Format((sex == Character.Sex.Male) ? TraitTermMale : TraitTermFemale, traitID)) + ". ";
		}
	}
}
