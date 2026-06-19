using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterNameGenerator : ScriptableObjectWithID
	{
		public string NameTermMale = "Names/Male_{0:000}";

		public string NameTermFemale = "Names/Female_{0:000}";

		public string NameTermSurname = "Names/Surname_{0:000}";

		public int NameMaleCount = 165;

		public int NameFemaleCount = 230;

		public int NameSurnameCount = 436;

		[SerializeField]
		private CharacterName[] _fixedMaleNames;

		[SerializeField]
		private CharacterName[] _fixedFemaleNames;

		[SerializeField]
		private bool _useFixedNames;

		public CharacterName Generate(Character.Sex sex)
		{
			if (_useFixedNames && RandomUtils.GlobalRandomInstance.Next(0, 100) == 0)
			{
				CharacterName[] array = ((sex == Character.Sex.Male) ? _fixedMaleNames : _fixedFemaleNames);
				if (array != null && array.Length != 0)
				{
					return array.RandomItem();
				}
			}
			int maxExclusive = ((sex == Character.Sex.Male) ? NameMaleCount : NameFemaleCount);
			string firstNameTerm = string.Format((sex == Character.Sex.Male) ? NameTermMale : NameTermFemale, Random.Range(0, maxExclusive));
			string lastNameTerm = string.Format(NameTermSurname, Random.Range(0, NameSurnameCount));
			CharacterName result = default(CharacterName);
			result.UpdateLocalisedFirstName(firstNameTerm);
			result.UpdateLocalisedLastName(lastNameTerm);
			return result;
		}
	}
}
