using System;
using System.Collections.Generic;
using System.Linq;
using Social;
using UnityEngine;

namespace NSEipix.Repository
{
	public class ConversationTopicRepository : DynamicJsonRepository<ConversationTopicRepository, ConversationTopic>
	{
		private class WeightSort : IComparer<KeyValuePair<string, int>>
		{
			public int Compare(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
			{
				if (a.Value == 0 || b.Value == 0)
				{
					return 0;
				}
				return a.Value.CompareTo(b.Value);
			}
		}

		private readonly System.Random random = new System.Random();

		protected override string JsonFile()
		{
			return "SocialInteraction/ConversationTopic.json";
		}

		public string GetAffectionEffectorById(string id, float threshold)
		{
			ConversationTopic byID = GetByID(id);
			for (int i = 0; i < byID.AffectionThresholds.Count; i++)
			{
				if (threshold < byID.AffectionThresholds[i])
				{
					return byID.AffectionEffectors[i];
				}
			}
			return byID.AffectionEffectors.LastOrDefault();
		}

		public string GetBeliefEffectorById(string id, float threshold)
		{
			ConversationTopic byID = GetByID(id);
			if (byID.BeliefEffectors == null || byID.BeliefEffectors.Count == 0)
			{
				return string.Empty;
			}
			for (int i = 0; i < byID.BeliefThresholds.Count; i++)
			{
				if (threshold < byID.BeliefThresholds[i])
				{
					return byID.BeliefEffectors[i];
				}
			}
			return byID.BeliefEffectors.LastOrDefault();
		}

		public string GetRandomTopicId(Dictionary<string, float> topicWeightMultipliers)
		{
			int num = 0;
			List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
			foreach (ConversationTopic allItem in GetAllItems())
			{
				float num2 = allItem.Weight;
				if (topicWeightMultipliers.ContainsKey(allItem.GetID()))
				{
					num2 *= topicWeightMultipliers[allItem.GetID()];
				}
				int num3 = Mathf.RoundToInt(num2 * 100f);
				list.Add(new KeyValuePair<string, int>(allItem.GetID(), num3));
				num += num3;
			}
			int num4 = random.Next(Mathf.RoundToInt(num));
			WeightSort comparer = new WeightSort();
			list.Sort(comparer);
			foreach (KeyValuePair<string, int> item in list)
			{
				if (num4 < item.Value)
				{
					return item.Key;
				}
				num4 -= item.Value;
			}
			return null;
		}

		public bool HasBeliefEffectors(string topicId)
		{
			List<string> list = GetByID(topicId)?.BeliefEffectors;
			if (list != null)
			{
				return list.Count > 0;
			}
			return false;
		}
	}
}
