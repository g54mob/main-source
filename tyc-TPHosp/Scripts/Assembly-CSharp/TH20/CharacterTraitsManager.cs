using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	public class CharacterTraitsManager
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public readonly WeightedCharacterTraitList CharacterTraits;

			public readonly int GameplayTraitsMin = 2;

			public readonly int GameplayTraitsMax = 5;

			public readonly int FlavourTraitsMin = 2;

			public readonly int FlavourTraitsMax = 3;

			public SharedInstance<CharacterFlavourTraits> FlavourTraits;

			public SharedInstance<CharacterGuiltTripFlavourText> GuiltTripFlavourText;
		}

		private readonly Config _config;

		private readonly WeightedList<CharacterTraitDefinition> _traits;

		public WeightedList<CharacterTraitDefinition> AllTraits => _traits;

		public CharacterTraitsManager(Config config, Level level)
		{
			_config = config;
			_traits = new WeightedList<CharacterTraitDefinition>();
			if (config.CharacterTraits != null)
			{
				WeightedCharacterTraitList.Entry[] list = config.CharacterTraits.List;
				for (int i = 0; i < list.Length; i++)
				{
					WeightedCharacterTraitList.Entry entry = list[i];
					_traits.Add(entry.Definition.Instance, entry.Weight);
					level.Debug_RegisterAssignTrait(entry.Definition.Instance);
				}
			}
		}

		public CharacterTraits GenerateRandomTraits(StaffDefinition.Type staffType, Character.Sex sex)
		{
			List<CharacterTraitDefinition> list = new List<CharacterTraitDefinition>();
			int num = RandomUtils.GlobalRandomInstance.Next(_config.GameplayTraitsMin, _config.GameplayTraitsMax + 1);
			int numTraits = RandomUtils.GlobalRandomInstance.Next(_config.FlavourTraitsMin, _config.FlavourTraitsMax + 1);
			for (int i = 0; i < num; i++)
			{
				CharacterTraitDefinition characterTraitDefinition = _traits.Choose(null, RandomUtils.GlobalRandomInstance);
				if (characterTraitDefinition != null && characterTraitDefinition.CanAdd(list) && characterTraitDefinition.IsValidFor(staffType))
				{
					list.Add(characterTraitDefinition);
				}
			}
			return new CharacterTraits(list, _config.FlavourTraits.Instance.GenerateFlavour(numTraits, sex));
		}

		public LocalisedString GetGuiltTripFlavourText(Character.Sex sex)
		{
			return _config.GuiltTripFlavourText.Instance.Get(sex);
		}

		public LocalisedString Debug_GetSpecificGuiltTrip(Character.Sex sex, int guiltTripKey)
		{
			return _config.GuiltTripFlavourText.Instance.Debug_GetSpecific(guiltTripKey, sex);
		}

		public CharacterTraits Debug_GenerateSpecificFlavourTrait(StaffDefinition.Type staffType, Character.Sex sex, int flavourKey)
		{
			List<CharacterTraitDefinition> list = new List<CharacterTraitDefinition>();
			int num = RandomUtils.GlobalRandomInstance.Next(_config.GameplayTraitsMin, _config.GameplayTraitsMax + 1);
			for (int i = 0; i < num; i++)
			{
				CharacterTraitDefinition characterTraitDefinition = _traits.Choose(null, RandomUtils.GlobalRandomInstance);
				if (characterTraitDefinition != null && characterTraitDefinition.CanAdd(list) && characterTraitDefinition.IsValidFor(staffType))
				{
					list.Add(characterTraitDefinition);
				}
			}
			return new CharacterTraits(list, _config.FlavourTraits.Instance.Debug_GenerateSpecificFlavour(flavourKey, sex));
		}
	}
}
