using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterGuiltTripFlavourText
	{
		public string TraitTermMale = "GuiltTrip/GuiltTrip_M_{0:000}";

		public string TraitTermFemale = "GuiltTrip/GuiltTrip_F_{0:000}";

		public int TraitCount = 2;

		public LocalisedString Get(Character.Sex sex)
		{
			return new LocalisedString(string.Format((sex == Character.Sex.Male) ? TraitTermMale : TraitTermFemale, Random.Range(0, TraitCount)));
		}

		public LocalisedString Debug_GetSpecific(int guiltTripKey, Character.Sex sex)
		{
			return new LocalisedString(string.Format((sex == Character.Sex.Male) ? TraitTermMale : TraitTermFemale, guiltTripKey));
		}
	}
}
