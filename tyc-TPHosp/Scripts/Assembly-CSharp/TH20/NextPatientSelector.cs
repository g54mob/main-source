using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH20.EventAwardStar;
using UnityEngine;

namespace TH20
{
	public class NextPatientSelector : MustCallDestroy, Interface, IGameEventCallback
	{
		public struct IllnessDebugInfo
		{
			public string Name;

			public float CurrentScore;

			public float MinScoreAdd;

			public float MaxScoreAdd;

			public float MinWeight;

			public float MaxWeight;

			public float Reputation;

			public float Marketing;
		}

		private readonly Level _level;

		private readonly ReputationTracker _reputationTracker;

		private readonly List<MarketingCampaignComponent> _marketingCampaigns;

		private readonly CharacterManager.Config _config;

		private readonly Dictionary<IllnessDefinition, float> _scores;

		private readonly List<int> _numPatientsWhenStarAwarded;

		private int _numPatientsSpawned;

		public NextPatientSelector(Level level, ReputationTracker reputationTracker, List<MarketingCampaignComponent> marketingCampaigns, CharacterManager.Config config)
		{
			_level = level;
			_reputationTracker = reputationTracker;
			_marketingCampaigns = marketingCampaigns;
			_config = config;
			_scores = new Dictionary<IllnessDefinition, float>();
			_numPatientsWhenStarAwarded = new List<int>();
			_numPatientsWhenStarAwarded.Add(_numPatientsSpawned);
			_level.Metagame.OnStarAwarded.Add(this);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			int num = _level.Metagame.GetHospitalRecord(_level.Config)?.TotalLevelStars() ?? 0;
			while (_numPatientsWhenStarAwarded.Count <= num)
			{
				_numPatientsWhenStarAwarded.Add(_numPatientsSpawned);
			}
			_level.Metagame.OnStarAwarded.Add(this);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
		}

		public override void Destroy()
		{
			_level.Metagame.OnStarAwarded.Remove(this);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			base.Destroy();
		}

		private void OnPatientSpawned(Patient patient)
		{
			_numPatientsSpawned++;
		}

		public void OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			_numPatientsWhenStarAwarded.Add(_numPatientsSpawned);
		}

		private int GetNumPatientsSpawnedAfterStarAwarded(int starIndex)
		{
			if (starIndex >= _numPatientsWhenStarAwarded.Count)
			{
				return 0;
			}
			return _numPatientsSpawned - _numPatientsWhenStarAwarded[starIndex];
		}

		public IllnessDefinition NextIllness(Dictionary<IllnessDefinition, WeightedIllness> illnesses)
		{
			if (illnesses.Count <= 0)
			{
				return null;
			}
			IllnessDefinition illnessDefinition = null;
			float num = float.MinValue;
			int numLevelStars = _level.Metagame.GetHospitalRecord(_level.Config)?.TotalLevelStars() ?? 0;
			foreach (KeyValuePair<IllnessDefinition, WeightedIllness> illness in illnesses)
			{
				WeightedIllness value = illness.Value;
				if (!IllnessPrerequisitesValid(value, numLevelStars))
				{
					continue;
				}
				IllnessDefinition key = illness.Key;
				if (!_scores.TryGetValue(key, out var value2))
				{
					value2 = CalculateStartingScore(value, illnesses);
				}
				float num2 = Mathf.Lerp(value.MinWeight, value.MaxWeight, _reputationTracker.GetIllnessReputation(key));
				float num3 = (float)value.MinWeight + (float)(value.MaxWeight - value.MinWeight) * 0.5f;
				num2 += num3 * RandomUtils.GlobalRandomInstance.NextFloat(0f - _config._patientSelectionRandomJitter, _config._patientSelectionRandomJitter);
				float num4 = 1f;
				foreach (MarketingCampaignComponent marketingCampaign in _marketingCampaigns)
				{
					num4 += marketingCampaign.CalculateIllnessMultiplier(key);
				}
				num2 *= num4;
				value2 += num2;
				_scores[key] = value2;
				if (num < value2)
				{
					num = value2;
					illnessDefinition = key;
				}
			}
			if (illnessDefinition != null)
			{
				_scores[illnessDefinition] = 0f;
			}
			return illnessDefinition;
		}

		private bool IllnessPrerequisitesValid(WeightedIllness illness, int numLevelStars)
		{
			bool num = numLevelStars >= illness.MinStarRating;
			bool flag = GetNumPatientsSpawnedAfterStarAwarded(illness.MinStarRating) >= illness.MinPatientsSpawned;
			return num && flag;
		}

		private float CalculateStartingScore(WeightedIllness illness, Dictionary<IllnessDefinition, WeightedIllness> illnesses)
		{
			float num = 0f;
			foreach (KeyValuePair<IllnessDefinition, float> score in _scores)
			{
				num = Mathf.Max(score.Value, num);
			}
			float num2 = 0f;
			foreach (WeightedIllness value in illnesses.Values)
			{
				num2 += (float)value.MinWeight + (float)(value.MaxWeight - value.MinWeight) * 0.5f;
			}
			num2 = ((illnesses.Count > 0) ? (num2 / (float)illnesses.Count) : 0f);
			float num3 = (float)illness.MinWeight + (float)(illness.MaxWeight - illness.MinWeight) * 0.5f;
			return ((num2 <= 0f) ? 1f : Mathf.Clamp01(num3 / num2 * 2f)) * num;
		}

		public void RunSimulation(int numSimulations, int numPatients, Dictionary<IllnessDefinition, WeightedIllness> illnesses, out string csvTable, out string csvIllnessList)
		{
			List<Dictionary<IllnessDefinition, int>> list = new List<Dictionary<IllnessDefinition, int>>();
			List<List<IllnessDefinition>> list2 = new List<List<IllnessDefinition>>();
			_scores.Clear();
			for (int i = 0; i < numSimulations; i++)
			{
				Dictionary<IllnessDefinition, int> dictionary = new Dictionary<IllnessDefinition, int>();
				List<IllnessDefinition> list3 = new List<IllnessDefinition>();
				for (int j = 0; j < numPatients; j++)
				{
					IllnessDefinition illnessDefinition = NextIllness(illnesses);
					list3.Add(illnessDefinition);
					dictionary.TryGetValue(illnessDefinition, out var value);
					dictionary[illnessDefinition] = value + 1;
				}
				list.Add(dictionary);
				list2.Add(list3);
				_scores.Clear();
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Index,");
			foreach (KeyValuePair<IllnessDefinition, WeightedIllness> illness in illnesses)
			{
				stringBuilder.AppendFormat("{0},", illness.Key.Name);
			}
			stringBuilder.AppendLine();
			for (int k = 0; k < list.Count; k++)
			{
				stringBuilder.AppendFormat("{0},", k + 1);
				foreach (KeyValuePair<IllnessDefinition, WeightedIllness> illness2 in illnesses)
				{
					list[k].TryGetValue(illness2.Key, out var value2);
					stringBuilder.AppendFormat("{0},", value2);
				}
				stringBuilder.AppendLine();
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.Append("Index,");
			for (int l = 0; l < numSimulations; l++)
			{
				stringBuilder2.AppendFormat("Simulation {0},", l + 1);
			}
			stringBuilder2.AppendLine();
			for (int m = 0; m < numPatients; m++)
			{
				stringBuilder2.AppendFormat("{0},", m);
				for (int n = 0; n < list2.Count; n++)
				{
					stringBuilder2.AppendFormat("{0},", list2[n][m].Name);
				}
				stringBuilder2.AppendLine();
			}
			csvTable = stringBuilder.ToString();
			csvIllnessList = stringBuilder2.ToString();
		}

		public List<IllnessDebugInfo> GetIllnessDebugInfo(Dictionary<IllnessDefinition, WeightedIllness> illnesses)
		{
			List<IllnessDebugInfo> list = new List<IllnessDebugInfo>();
			int numLevelStars = _level.Metagame.GetHospitalRecord(_level.Config)?.TotalLevelStars() ?? 0;
			foreach (KeyValuePair<IllnessDefinition, WeightedIllness> illness in illnesses)
			{
				IllnessDefinition definition = illness.Key;
				WeightedIllness value = illness.Value;
				bool num = _scores.ContainsKey(definition);
				bool flag = IllnessPrerequisitesValid(value, numLevelStars);
				if (!num || !flag)
				{
					list.Add(new IllnessDebugInfo
					{
						Name = definition.Name.ToString(),
						MinScoreAdd = 0f,
						MaxScoreAdd = 0f,
						CurrentScore = 0f,
						Marketing = 0f,
						MaxWeight = value.MaxWeight,
						MinWeight = value.MinWeight,
						Reputation = 0f
					});
					continue;
				}
				float num2 = (float)value.MinWeight + (float)(value.MaxWeight - value.MinWeight) * 0.5f;
				float num3 = Mathf.Lerp(value.MinWeight, value.MaxWeight, _reputationTracker.GetIllnessReputation(definition));
				float illnessReputation = _reputationTracker.GetIllnessReputation(definition);
				float num4 = 1f + _marketingCampaigns.Sum((MarketingCampaignComponent campaign) => campaign.CalculateIllnessMultiplier(definition));
				float currentScore = _scores[definition];
				float minScoreAdd = (num3 + num2 * (0f - _config._patientSelectionRandomJitter)) * num4;
				float maxScoreAdd = (num3 + num2 * _config._patientSelectionRandomJitter) * num4;
				list.Add(new IllnessDebugInfo
				{
					Name = definition.Name.ToString(),
					MinScoreAdd = minScoreAdd,
					MaxScoreAdd = maxScoreAdd,
					CurrentScore = currentScore,
					Marketing = num4,
					MaxWeight = value.MaxWeight,
					MinWeight = value.MinWeight,
					Reputation = illnessReputation
				});
			}
			list.Sort((IllnessDebugInfo illness1, IllnessDebugInfo illness2) => illness2.CurrentScore.CompareTo(illness1.CurrentScore));
			return list;
		}

		public bool IsIllnessAvailable(IllnessDefinition illnessDefinition, Dictionary<IllnessDefinition, WeightedIllness> illnesses)
		{
			if (illnesses.TryGetValue(illnessDefinition, out var value))
			{
				int numLevelStars = _level.Metagame.GetHospitalRecord(_level.Config)?.TotalLevelStars() ?? 0;
				return IllnessPrerequisitesValid(value, numLevelStars);
			}
			return false;
		}

		public void ModifiySpawnedPatientCount(int numPatients)
		{
			_numPatientsSpawned -= numPatients;
		}
	}
}
