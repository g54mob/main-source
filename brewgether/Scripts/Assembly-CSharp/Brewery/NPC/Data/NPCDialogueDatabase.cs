using System.Collections.Generic;
using Brewery.Core;
using UnityEngine;

namespace Brewery.NPC.Data
{
	[CreateAssetMenu(fileName = "NPCDialogueDatabase", menuName = "Brewery/NPC/Dialogue Database")]
	public class NPCDialogueDatabase : ScriptableObject
	{
		[Header("Dialogue Entries")]
		[SerializeField]
		private List<NPCDialogueEntry> m_Entries;

		[Header("Settings")]
		[Tooltip("If true, log when no matching dialogue is found")]
		[SerializeField]
		private bool m_LogMisses;

		private Dictionary<string, List<NPCDialogueEntry>> m_TriggerCache;

		private bool m_CacheBuilt;

		public IReadOnlyList<NPCDialogueEntry> Entries => null;

		public int Count => 0;

		private void OnEnable()
		{
		}

		private void OnValidate()
		{
		}

		private void BuildCache()
		{
		}

		public string GetDialogue(string trigger, FactionType faction, NPCGender gender, DrunkLevel drunkLevel, SimpleNPCPersonality personality)
		{
			return null;
		}

		public string GetDialogue(string trigger, FactionType faction, NPCGender gender, DrunkLevel drunkLevel, float aggression, float bravery)
		{
			return null;
		}

		public string GetDialogueDeterministic(string trigger, FactionType faction, NPCGender gender, DrunkLevel drunkLevel, SimpleNPCPersonality personality, int additionalSeed = 0)
		{
			return null;
		}

		public bool HasDialogueForTrigger(string trigger)
		{
			return false;
		}

		public int GetEntryCount(string trigger)
		{
			return 0;
		}

		public List<string> GetAllTriggers()
		{
			return null;
		}

		private string SelectWeightedRandom(List<NPCDialogueEntry> matches)
		{
			return null;
		}

		private string SelectWeightedRandomDeterministic(List<NPCDialogueEntry> matches, int seed)
		{
			return null;
		}

		public void AddEntry(NPCDialogueEntry entry)
		{
		}

		public void ClearEntries()
		{
		}

		public void SetEntries(List<NPCDialogueEntry> entries)
		{
		}

		public void RebuildCache()
		{
		}
	}
}
