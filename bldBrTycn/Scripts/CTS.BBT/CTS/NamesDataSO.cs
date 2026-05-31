using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Metadata;
using UnityEngine.Localization.Tables;

namespace CTS
{
	[Serializable]
	[CreateAssetMenu(fileName = "NamesData", menuName = "CTS/NameAgentLocalized/Data")]
	public class NamesDataSO : ScriptableObject
	{
		[Serializable]
		public struct StructListSpecies
		{
			public ENameSpecies species;

			public List<StructListGender> _listgender;
		}

		[Serializable]
		public struct StructListGender
		{
			public ENameGender Gender;

			public List<LocalizedString> GenderName;
		}

		public enum ENameGender
		{
			None = 0,
			Male = 1,
			Female = 2,
			Both = 3
		}

		public enum ENameSpecies
		{
			None = 0,
			Human = 1,
			Vampire = 2,
			BothSpecies = 3
		}

		public LocalizedStringTable localizedStringTable;

		public StringTable StringTableByDefault;

		public List<StructListSpecies> structListSpecies;

		[Button(null, EButtonEnableMode.Always)]
		public void SortEntriesByGender()
		{
			if (localizedStringTable == null)
			{
				Debug.LogError("Table de localisation non définie");
				return;
			}
			CleanAllList();
			UpdateInEditor(StringTableByDefault);
		}

		private void UpdateInEditor(StringTable table)
		{
			foreach (KeyValuePair<long, StringTableEntry> item in table)
			{
				long key = item.Key;
				SharedTableData.SharedTableEntry entry = table.SharedData.GetEntry(key);
				if (entry == null || entry.Metadata == null)
				{
					continue;
				}
				Comment metadata = entry.Metadata.GetMetadata<Comment>();
				if (metadata == null)
				{
					continue;
				}
				ENameSpecies speciesFromEntry = GetSpeciesFromEntry(metadata.CommentText);
				ENameGender genderFromEntry = GetGenderFromEntry(metadata.CommentText);
				foreach (StructListSpecies structListSpecy in structListSpecies)
				{
					if (speciesFromEntry == ENameSpecies.BothSpecies || structListSpecy.species == speciesFromEntry)
					{
						ArrangeGenderList(structListSpecy, genderFromEntry, key);
					}
				}
			}
		}

		private void ArrangeGenderList(StructListSpecies item, ENameGender eNameGender, long entryKey)
		{
			foreach (StructListGender item2 in item._listgender)
			{
				if (item2.Gender == eNameGender)
				{
					AddLocalizedStringToGenderList(item2, entryKey);
				}
			}
		}

		private void AddLocalizedStringToGenderList(StructListGender genderItem, long entryKey)
		{
			LocalizedString item = new LocalizedString
			{
				TableReference = localizedStringTable.TableReference,
				TableEntryReference = entryKey
			};
			genderItem.GenderName.Add(item);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void CleanAllList()
		{
			foreach (StructListSpecies structListSpecy in structListSpecies)
			{
				foreach (StructListGender item in structListSpecy._listgender)
				{
					item.GenderName.Clear();
				}
			}
		}

		private ENameGender GetGenderFromEntry(string entry)
		{
			if (entry.Contains("Male"))
			{
				return ENameGender.Male;
			}
			if (entry.Contains("Female"))
			{
				return ENameGender.Female;
			}
			if (entry.Contains("Both"))
			{
				return ENameGender.Both;
			}
			return ENameGender.None;
		}

		private ENameSpecies GetSpeciesFromEntry(string entry)
		{
			if (entry.Contains("Human"))
			{
				return ENameSpecies.Human;
			}
			if (entry.Contains("Vampire"))
			{
				return ENameSpecies.Vampire;
			}
			if (entry.Contains("Both"))
			{
				return ENameSpecies.BothSpecies;
			}
			return ENameSpecies.None;
		}

		public LocalizedString NeedName(Agent agent, CTS.BBT.AI.EGender Gender)
		{
			StructListSpecies structListSpecies = default(StructListSpecies);
			StructListGender structListGender = default(StructListGender);
			foreach (StructListSpecies structListSpecy in this.structListSpecies)
			{
				if (agent.IsHuman && structListSpecy.species == ENameSpecies.Human)
				{
					structListSpecies = structListSpecy;
					break;
				}
				if (!agent.IsHuman || agent is Worker)
				{
					if (structListSpecy.species == ENameSpecies.Vampire)
					{
						structListSpecies = structListSpecy;
						break;
					}
				}
				else
				{
					Debug.LogError("SPECIES IS NOT HERE " + agent.IsHuman);
				}
			}
			foreach (StructListGender item in structListSpecies._listgender)
			{
				switch (Gender)
				{
				case CTS.BBT.AI.EGender.Female:
					if (item.Gender == ENameGender.Female)
					{
						structListGender = item;
					}
					break;
				case CTS.BBT.AI.EGender.Male:
					if (item.Gender == ENameGender.Male)
					{
						structListGender = item;
					}
					break;
				case CTS.BBT.AI.EGender.NonBinary:
					if (item.Gender == ENameGender.Both)
					{
						structListGender = item;
					}
					break;
				default:
					Debug.LogError("Gender IS NOT HERE " + Gender);
					break;
				}
			}
			int index = UnityEngine.Random.Range(0, structListGender.GenderName.Count);
			return structListGender.GenderName[index];
		}
	}
}
