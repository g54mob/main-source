using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct CharacterData
	{
		[SerializeField]
		public ESpecies Species;

		[SerializeField]
		public ESubSpecies SubSpecies;

		[SerializeField]
		public EEthnics Ethnics;

		[SerializeField]
		public EGender Gender;

		public int hairMatIndex;

		public int hairMeshIndex;

		public int eyesMaterialIndex;

		public int headSkinMaterialIndex;

		public int headBlendIndex;

		public int bodySkinMaterialIndex;

		public int bodyDataIndex;

		public int bodyMaterialGroupIndex;

		public bool IsValid(EGender gender, ESpecies species, EEthnics ethnics, ESubSpecies subspecies)
		{
			if (!Gender.HasFlagNonAlloc(gender))
			{
				return false;
			}
			if (!Species.HasFlagNonAlloc(species))
			{
				return false;
			}
			if (!Ethnics.HasFlagNonAlloc(ethnics))
			{
				return false;
			}
			if (!SubSpecies.HasFlagNonAlloc(subspecies))
			{
				return false;
			}
			return true;
		}

		public bool IsValid(CharacterData data)
		{
			if (!Gender.HasFlagNonAlloc(data.Gender))
			{
				return false;
			}
			if (!Species.HasFlagNonAlloc(data.Species))
			{
				return false;
			}
			if (!Ethnics.HasFlagNonAlloc(data.Ethnics))
			{
				return false;
			}
			if (!SubSpecies.HasFlagNonAlloc(data.SubSpecies))
			{
				return false;
			}
			return true;
		}

		public static void GetRandomIfMultiflags(ref CharacterData data)
		{
		}

		public static CharacterData? GetRandomIfMultiflags(EGender gender, ESpecies species, EEthnics ethnics, ESubSpecies subspecies)
		{
			CharacterData value = default(CharacterData);
			int? oneOfMultiplesFlags = GetOneOfMultiplesFlags(Enum.GetValues(typeof(EGender)), gender);
			if (!oneOfMultiplesFlags.HasValue)
			{
				return null;
			}
			value.Gender = (EGender)oneOfMultiplesFlags.Value;
			int? oneOfMultiplesFlags2 = GetOneOfMultiplesFlags(Enum.GetValues(typeof(ESpecies)), species);
			if (!oneOfMultiplesFlags2.HasValue)
			{
				return null;
			}
			value.Species = (ESpecies)oneOfMultiplesFlags2.Value;
			int? oneOfMultiplesFlags3 = GetOneOfMultiplesFlags(Enum.GetValues(typeof(EEthnics)), ethnics);
			if (!oneOfMultiplesFlags3.HasValue)
			{
				return null;
			}
			value.Ethnics = (EEthnics)oneOfMultiplesFlags3.Value;
			int? oneOfMultiplesFlags4 = GetOneOfMultiplesFlags(Enum.GetValues(typeof(ESubSpecies)), subspecies);
			if (!oneOfMultiplesFlags4.HasValue)
			{
				return null;
			}
			value.SubSpecies = (ESubSpecies)oneOfMultiplesFlags4.Value;
			return value;
		}

		private static int? GetOneOfMultiplesFlags<T>(Array array, T en) where T : Enum
		{
			List<int> list = new List<int>();
			foreach (int item in array)
			{
				if (typeof(T) == typeof(EGender))
				{
					if (en.HasFlag((EGender)item))
					{
						list.Add(item);
					}
				}
				else if (typeof(T) == typeof(ESpecies))
				{
					if (en.HasFlag((ESpecies)item))
					{
						list.Add(item);
					}
				}
				else if (typeof(T) == typeof(EEthnics))
				{
					if (en.HasFlag((EEthnics)item))
					{
						list.Add(item);
					}
				}
				else if (typeof(T) == typeof(ESubSpecies) && en.HasFlag((ESubSpecies)item))
				{
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public override string ToString()
		{
			return "[" + Species.ToString() + ", " + SubSpecies.ToString() + ", " + Ethnics.ToString() + ", " + Gender.ToString() + "]";
		}
	}
}
