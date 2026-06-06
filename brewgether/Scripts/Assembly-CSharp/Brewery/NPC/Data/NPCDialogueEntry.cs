using System;
using Brewery.Core;
using UnityEngine;

namespace Brewery.NPC.Data
{
	[Serializable]
	public class NPCDialogueEntry
	{
		[Header("Dialogue Text")]
		[SerializeField]
		[TextArea(1, 3)]
		private string m_Text;

		[Header("Trigger")]
		[Tooltip("The trigger string that activates this dialogue (e.g., 'bar_got_seat')")]
		[SerializeField]
		private string m_Trigger;

		[Header("NPC Filters")]
		[SerializeField]
		private FactionType m_Faction;

		[SerializeField]
		private bool m_AnyFaction;

		[SerializeField]
		private NPCGender m_Gender;

		[SerializeField]
		private DrunkLevel m_DrunkLevel;

		[Header("Personality Filters")]
		[SerializeField]
		private PersonalityRange m_Aggression;

		[SerializeField]
		private PersonalityRange m_Bravery;

		[Header("Priority & Weight")]
		[Tooltip("Higher priority entries are checked first. Use for specific matches.")]
		[SerializeField]
		[Range(0f, 10f)]
		private int m_Priority;

		[Tooltip("Random weight for selection among equal-priority matches.")]
		[SerializeField]
		[Range(0.1f, 10f)]
		private float m_Weight;

		public string Text => null;

		public string Trigger => null;

		public FactionType Faction => default(FactionType);

		public bool AnyFaction => false;

		public NPCGender Gender => default(NPCGender);

		public DrunkLevel DrunkLevel => default(DrunkLevel);

		public PersonalityRange Aggression => default(PersonalityRange);

		public PersonalityRange Bravery => default(PersonalityRange);

		public int Priority => 0;

		public float Weight => 0f;

		public static NPCDialogueEntry Create(string text, string trigger, FactionType faction, bool anyFaction, NPCGender gender, DrunkLevel drunkLevel, PersonalityRange aggression, PersonalityRange bravery, int priority = 5, float weight = 1f)
		{
			return null;
		}

		public bool Matches(string trigger, FactionType faction, NPCGender gender, DrunkLevel drunkLevel, float aggression, float bravery)
		{
			return false;
		}

		public bool Matches(string trigger, FactionType faction, NPCGender gender, DrunkLevel drunkLevel, SimpleNPCPersonality personality)
		{
			return false;
		}

		private static bool MatchesPersonalityRange(PersonalityRange range, float value)
		{
			return false;
		}

		public bool MatchesRelaxed(string trigger, FactionType faction, NPCGender gender, DrunkLevel drunkLevel, float aggression, float bravery, int relaxLevel)
		{
			return false;
		}

		public bool MatchesRelaxed(string trigger, FactionType faction, NPCGender gender, DrunkLevel drunkLevel, SimpleNPCPersonality personality, int relaxLevel)
		{
			return false;
		}

		public int GetSpecificityScore()
		{
			return 0;
		}
	}
}
