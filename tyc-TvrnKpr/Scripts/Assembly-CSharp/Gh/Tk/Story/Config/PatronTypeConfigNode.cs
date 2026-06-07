using UnityEngine;

namespace Gh.Tk.Story.Config
{
	public class PatronTypeConfigNode : StoryNode
	{
		public string patronType;

		[DropDownChoice(typeof(StoryHelper), "GetNamedDayCurves")]
		public string dayPatternPreset;

		public PatronSpawnOccurence rarity;

		public GameObject[] tier1Models;

		public GameObject[] tier2Models;

		public GameObject[] tier3Models;

		public GameObject[] tier4Models;

		public GameObject[] tier5Models;

		public float spawningGroupChance;

		public int maxGroupSize;

		public float GetWeightingForRarity()
		{
			return 0f;
		}

		public GameObject[] GetModelsForTier(int tier)
		{
			return null;
		}

		public float GetEffectiveSpawningGroupChance()
		{
			return 0f;
		}

		public AnimationCurve GetEffectiveDayPattern()
		{
			return null;
		}

		internal string GetPrefab(int tier, string race)
		{
			return null;
		}

		protected override void GenerateI18nEntriesInternal(string context)
		{
		}
	}
}
