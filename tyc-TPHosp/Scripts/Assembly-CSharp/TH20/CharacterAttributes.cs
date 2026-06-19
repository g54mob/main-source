using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	public class CharacterAttributes : Attributes
	{
		public enum Type
		{
			None = 0,
			Hunger = 1,
			Thirst = 2,
			Toilet = 3,
			Boredom = 4,
			Litter = 5,
			Energy = 6,
			Health = 7,
			Happiness = 8,
			XP = 9,
			Nausea = 10,
			Hygiene = 11,
			Temperature = 12
		}

		public class Needs : List<KeyValuePair<Type, AttributeFloat>>
		{
			public Needs()
			{
			}

			public Needs(Needs other)
				: base((IEnumerable<KeyValuePair<Type, AttributeFloat>>)other)
			{
			}

			public void OrderHighestFirst()
			{
				Sort((KeyValuePair<Type, AttributeFloat> lhs, KeyValuePair<Type, AttributeFloat> rhs) => lhs.Value.Value().CompareTo(rhs.Value.Value()));
			}
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Definition
		{
			public Type _type;

			public float _initialMinValue;

			public float _initialMaxValue;
		}

		public const int MaxCharacterAttributes = 13;

		public static readonly string[] TypeNames = new string[13]
		{
			"None", "Hunger", "Thirst", "Toilet", "Boredom", "Litter", "Energy", "Health", "Happiness", "XP",
			"Nausea", "Hygiene", "Temperature"
		};

		public static readonly string[] TypeNameLocTerms = new string[13]
		{
			"Challenges/RewardsNone_CS", "Character/Attributes/01_Hunger_CS", "Character/Attributes/02_Thirst_CS", "Character/Attributes/03_Toilet_CS", "Character/Attributes/04_Boredom_CS", "Character/Attributes/05_Litter_CS", "Character/Attributes/06_Energy_CS", "Character/Attributes/07_Health_CS", "Character/Attributes/08_Happiness_CS", "Character/Attributes/09_XP_CS",
			"Character/Attributes/10_Nausea_CS", "Character/Attributes/11_Hygiene_CS", "Character/Attributes/12_Temperature_CS"
		};

		public static readonly int[] TypeHashCodes = new int[13]
		{
			"None".GetHashCode(),
			"Hunger".GetHashCode(),
			"Thirst".GetHashCode(),
			"Toilet".GetHashCode(),
			"Boredom".GetHashCode(),
			"Litter".GetHashCode(),
			"Energy".GetHashCode(),
			"Health".GetHashCode(),
			"Happiness".GetHashCode(),
			"XP".GetHashCode(),
			"Nausea".GetHashCode(),
			"Hygiene".GetHashCode(),
			"Temperature".GetHashCode()
		};

		private static readonly Type[] _needs = new Type[6]
		{
			Type.Hunger,
			Type.Thirst,
			Type.Toilet,
			Type.Boredom,
			Type.Litter,
			Type.Nausea
		};

		private static readonly int Toilet_CS;

		private string EnumToString(Type type)
		{
			return GetAttributeNameLoc(type);
		}

		public CharacterAttributes(IAttributesInterface owner)
			: base(owner, TypeNames)
		{
		}

		public void Add(Type type, AttributeFloat attribute)
		{
			Add((int)type, attribute);
		}

		public void Remove(Type type)
		{
			Remove((int)type);
		}

		public AttributeFloat GetAttribute(Type type)
		{
			return GetAttribute((int)type);
		}

		public static string GetAttributeNameLoc(Type type)
		{
			return LocalizationManager.GetTranslation(TypeNameLocTerms[(int)type]);
		}

		public void GetNeeds(float threshold, ref Needs results)
		{
			results.Clear();
			for (int i = 0; i < _needs.Length; i++)
			{
				AttributeFloat attribute = GetAttribute((int)_needs[i]);
				if (attribute != null && attribute.Value() >= threshold)
				{
					results.Add(new KeyValuePair<Type, AttributeFloat>(_needs[i], attribute));
				}
			}
			if (results.Count != 0)
			{
				results.OrderHighestFirst();
			}
		}
	}
}
