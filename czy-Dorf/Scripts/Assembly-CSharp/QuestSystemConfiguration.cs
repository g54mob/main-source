using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class QuestSystemConfiguration : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<QuestTileSubCollection, bool> _003C_003E9__25_1;

		public static Func<QuestProbability, bool> _003C_003E9__26_1;

		public static Func<QuestProbability, Quest> _003C_003E9__26_2;

		public static Func<KeyValuePair<QuestTile, SessionQuestReward>, QuestTile> _003C_003E9__30_1;

		public static Func<KeyValuePair<QuestTile, SessionQuestReward>, SessionQuestReward> _003C_003E9__30_2;

		internal bool _003CGetRandomQuestTile_003Eb__25_1(QuestTileSubCollection x)
		{
			return x.occupiedEdges < 5;
		}

		internal bool _003CSelectRandomQuest_003Eb__26_1(QuestProbability x)
		{
			return x.quest.conditions[0].equalityComparer == EqualityComparison.MoreThan;
		}

		internal Quest _003CSelectRandomQuest_003Eb__26_2(QuestProbability x)
		{
			return x.quest;
		}

		internal QuestTile _003CGetLockedQuestTile_003Eb__30_1(KeyValuePair<QuestTile, SessionQuestReward> x)
		{
			return x.Key;
		}

		internal SessionQuestReward _003CGetLockedQuestTile_003Eb__30_2(KeyValuePair<QuestTile, SessionQuestReward> y)
		{
			return y.Value;
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public QuestTileData_002 loadedData;

		public int level;

		internal bool _003CSelectRandomQuest_003Eb__0(QuestProbability x)
		{
			return x.quest.id == loadedData.questId;
		}

		internal float _003CSelectRandomQuest_003Eb__3(QuestProbability y)
		{
			return y.probabilityCurve.Evaluate(level);
		}
	}

	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public SessionQuest filterChallenge;

		internal bool _003CGetLockedQuestTile_003Eb__0(KeyValuePair<QuestTile, SessionQuestReward> x)
		{
			if (x.Value != null)
			{
				if (!(filterChallenge == null))
				{
					return x.Value.sessionQuest == filterChallenge;
				}
				return true;
			}
			return false;
		}
	}

	[FormerlySerializedAs("availableQuestTiles")]
	[SerializeField]
	private bool autoUpdate = true;

	[SerializeField]
	private AnimationCurve questTileProbabilityCurve;

	[SerializeField]
	private int displayLevel;

	[SerializeField]
	private List<QuestProbability> questProbabilities;

	[SerializeField]
	private QuestProbability globalLockQuestProbability;

	[SerializeField]
	private float globalQuestProbabilityMultiplier = 1f;

	[SerializeField]
	private float globalFlagQuestProbabilityMultiplier = 0.3f;

	[SerializeField]
	private float exponentialDifficultyIncreaseFactor = 1f;

	[SerializeField]
	private int questSpawnTileLimit = -1;

	[FormerlySerializedAs("questTiles")]
	[SerializeField]
	public List<QuestTileCollection> questTileCollections;

	[SerializeField]
	private RewardSystem rewardSystem;

	public Dictionary<QuestTileId, QuestTile> QuestTileById;

	private Dictionary<QuestTileId, List<QuestProbability>> questsByQuestTileId;

	private Dictionary<QuestTile, SessionQuestReward> rewardByQuestTile = new Dictionary<QuestTile, SessionQuestReward>();

	[SerializeField]
	private List<GroupTypeId> excludedGroupTypes;

	private readonly Dictionary<char, GroupTypeId> groupTypeIdByLetter = new Dictionary<char, GroupTypeId>
	{
		{
			'V',
			GroupTypeId.Village
		},
		{
			'F',
			GroupTypeId.Forest
		},
		{
			'A',
			GroupTypeId.Agriculture
		},
		{
			'T',
			GroupTypeId.TrainTracks
		},
		{
			'W',
			GroupTypeId.Water
		}
	};

	private float _003CGlobalQuestDifficultyMultiplier_003Ek__BackingField = 1f;

	public float GlobalQuestDifficultyMultiplier
	{
		get
		{
			return _003CGlobalQuestDifficultyMultiplier_003Ek__BackingField;
		}
		private set
		{
			_003CGlobalQuestDifficultyMultiplier_003Ek__BackingField = value;
		}
	}

	public float ExponentialQuestDifficultyFactor => exponentialDifficultyIncreaseFactor;

	public float QuestTileProbability(int activeQuestCount)
	{
		if (questSpawnTileLimit > 0 && OverwritingSingleton<IngameUi>.Instance.world.TotalTileCount >= questSpawnTileLimit)
		{
			return 0f;
		}
		return questTileProbabilityCurve.Evaluate(activeQuestCount) * globalQuestProbabilityMultiplier;
	}

	public void SetConstantQuestTileProbability(float constantValue)
	{
		questTileProbabilityCurve = AnimationCurve.Constant(0f, 1f, constantValue);
	}

	public void Setup()
	{
		Dictionary<Quest, QuestProbability> dictionary = new Dictionary<Quest, QuestProbability>();
		foreach (QuestProbability questProbability in questProbabilities)
		{
			dictionary.Add(questProbability.quest, questProbability);
		}
		QuestTileById = new Dictionary<QuestTileId, QuestTile>();
		questsByQuestTileId = new Dictionary<QuestTileId, List<QuestProbability>>();
		rewardByQuestTile = new Dictionary<QuestTile, SessionQuestReward>();
		excludedGroupTypes = new List<GroupTypeId>();
		foreach (QuestTileCollection questTileCollection in questTileCollections)
		{
			foreach (QuestTileSubCollection subCollection in questTileCollection.subCollections)
			{
				foreach (QuestTileOption questTile in subCollection.questTiles)
				{
					if (questTile.questTile == null)
					{
						Debug.LogError($"{base.name} {questTileCollection.groupType} {subCollection.name} is missing a QuestTile");
					}
					QuestTile component = questTile.questTile.GetComponent<QuestTile>();
					if (QuestTileById.ContainsKey(component.id))
					{
						Debug.LogWarning($"Duplicate id! {component.questTileId} - identical tiles: {component} & {QuestTileById[component.id]}");
						Debug.LogWarning($"Checking in questTileCollection {questTileCollection.groupType}, subCollection {subCollection.name}");
						continue;
					}
					QuestTileById.Add(component.id, component);
					if (questsByQuestTileId.ContainsKey(component.id))
					{
						Debug.LogError($"Duplicate entry! {questTile.questTile}");
					}
					questsByQuestTileId.Add(component.id, new List<QuestProbability>());
					rewardByQuestTile.Add(component, questTile.unlockReward);
					if (questTile.questOptions != null && questTile.questOptions.Count > 0)
					{
						foreach (Quest questOption in questTile.questOptions)
						{
							questsByQuestTileId[component.id].Add(dictionary[questOption]);
						}
						continue;
					}
					foreach (Quest defaultQuestOption in questTileCollection.defaultQuestOptions)
					{
						questsByQuestTileId[component.id].Add(dictionary[defaultQuestOption]);
					}
				}
			}
		}
	}

	public QuestTile GetRandomQuestTile(out SessionQuestReward reward, TileGenFilter usedFilter = TileGenFilter.None, int seed = -1)
	{
		if (seed != -1)
		{
			UnityEngine.Random.InitState(seed * 2);
		}
		List<QuestTileSubCollection> list = Randomizer.SelectWeightedRandom(questTileCollections).subCollections;
		if (excludedGroupTypes.Count > 0)
		{
			list = Enumerable.ToList(Enumerable.Where(list, (QuestTileSubCollection x) => !ListHelper.ListsContainAMatchingValue(x.allSegmentTypes, excludedGroupTypes)));
		}
		if (usedFilter != TileGenFilter.None && usedFilter == TileGenFilter.AtLeastTwoEmptyEdges)
		{
			list = Enumerable.ToList(Enumerable.Where(list, (QuestTileSubCollection x) => x.occupiedEdges < 5));
		}
		QuestTile component = Randomizer.SelectWeightedRandom(Randomizer.SelectWeightedRandom(list).questTiles).questTile.GetComponent<QuestTile>();
		reward = null;
		if (rewardByQuestTile.ContainsKey(component))
		{
			reward = rewardByQuestTile[component];
		}
		else
		{
			Debug.LogError($"rewardByQuestTile doesn't contain {component}");
		}
		Randomizer.RandomizeSeed();
		return component;
	}

	public Quest SelectRandomQuest(QuestTile questTile, int level, QuestTileData_002 loadedData = null)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals7.loadedData = loadedData;
		CS_0024_003C_003E8__locals7.level = level;
		if (CS_0024_003C_003E8__locals7.loadedData != null && CS_0024_003C_003E8__locals7.loadedData.questId != QuestId.Undefined && CS_0024_003C_003E8__locals7.loadedData.questQueueIndex == 0)
		{
			return Enumerable.First(questsByQuestTileId[questTile.id], (QuestProbability x) => x.quest.id == CS_0024_003C_003E8__locals7.loadedData.questId).quest;
		}
		UnityEngine.Random.InitState(questTile.Seed);
		List<QuestProbability> source = questsByQuestTileId[questTile.id];
		if (questTile.QuestWatcher.UnlockingSessionQuest != null)
		{
			source = Enumerable.ToList(Enumerable.Where(source, (QuestProbability x) => x.quest.conditions[0].equalityComparer == EqualityComparison.MoreThan));
		}
		Quest result = Randomizer.SelectWeightedRandom(Enumerable.ToDictionary(source, (QuestProbability x) => x.quest, (QuestProbability y) => y.probabilityCurve.Evaluate(CS_0024_003C_003E8__locals7.level)));
		Randomizer.RandomizeSeed();
		return result;
	}

	private void OnValidate()
	{
		if (autoUpdate)
		{
			UpdateValues(updateSegmentTypes: true);
		}
	}

	public void UpdateValues(bool updateSegmentTypes = false)
	{
		Dictionary<GroupType, float> dictionary = new Dictionary<GroupType, float>();
		foreach (QuestProbability questProbability in questProbabilities)
		{
			if (!(questProbability.quest.groupType == null))
			{
				if (!dictionary.ContainsKey(questProbability.quest.groupType))
				{
					dictionary.Add(questProbability.quest.groupType, 0f);
				}
				dictionary[questProbability.quest.groupType] += questProbability.probabilityCurve.Evaluate(displayLevel);
			}
		}
		foreach (QuestProbability questProbability2 in questProbabilities)
		{
			if (questProbability2.quest.groupType == null)
			{
				questProbability2._displayProbability = questProbability2.probabilityCurve.Evaluate(displayLevel);
			}
			else
			{
				questProbability2._displayProbability = questProbability2.probabilityCurve.Evaluate(displayLevel) / dictionary[questProbability2.quest.groupType];
			}
		}
		globalLockQuestProbability._displayProbability = globalLockQuestProbability.probabilityCurve.Evaluate(displayLevel);
		float num = Randomizer.TotalProbability(questTileCollections);
		foreach (QuestTileCollection questTileCollection in questTileCollections)
		{
			questTileCollection.collectionProbability = ((num == 0f) ? 0f : (questTileCollection.Probability / num));
			questTileCollection._displayProbability = questTileCollection.collectionProbability * 500f;
			float num2 = Randomizer.TotalProbability(questTileCollection.subCollections);
			foreach (QuestTileSubCollection subCollection in questTileCollection.subCollections)
			{
				subCollection.subCollectionProbability = ((num2 == 0f) ? 0f : (subCollection.Probability / num2 * questTileCollection.collectionProbability));
				subCollection._displayProbability = subCollection.subCollectionProbability * 500f;
				subCollection.groupType = questTileCollection.groupType;
				subCollection.occupiedEdges = 0;
				if (subCollection.questTiles.Count > 0 && (bool)subCollection.questTiles[0]?.questTile)
				{
					ElementGroupSegment[] componentsInChildren = subCollection.questTiles[0].questTile.GetComponentsInChildren<ElementGroupSegment>();
					foreach (ElementGroupSegment elementGroupSegment in componentsInChildren)
					{
						subCollection.occupiedEdges += elementGroupSegment.SegmentType.edges.Count;
					}
				}
				if (!updateSegmentTypes)
				{
					continue;
				}
				subCollection.allSegmentTypes = new List<GroupTypeId> { questTileCollection.groupType.id };
				subCollection.name = subCollection.name.Trim(' ');
				int num3 = 0;
				for (int j = 0; j < subCollection.name.Length; j++)
				{
					if (subCollection.name[j] == ' ')
					{
						if (num3 == 3)
						{
							if (!groupTypeIdByLetter.ContainsKey(subCollection.name[j - 1]))
							{
								Debug.LogWarning($"Key missing {subCollection.name[j - 1]} for subcollection {subCollection.name}");
							}
							else if (!subCollection.allSegmentTypes.Contains(groupTypeIdByLetter[subCollection.name[j - 1]]))
							{
								subCollection.allSegmentTypes.Add(groupTypeIdByLetter[subCollection.name[j - 1]]);
							}
						}
						num3 = 0;
					}
					else
					{
						num3++;
					}
				}
				if (num3 == 3)
				{
					if (!groupTypeIdByLetter.ContainsKey(subCollection.name[subCollection.name.Length - 1]))
					{
						Debug.LogWarning($"Key missing {subCollection.name[subCollection.name.Length - 1]} for subcollection {subCollection.name}");
					}
					else if (!subCollection.allSegmentTypes.Contains(groupTypeIdByLetter[subCollection.name[subCollection.name.Length - 1]]))
					{
						subCollection.allSegmentTypes.Add(groupTypeIdByLetter[subCollection.name[subCollection.name.Length - 1]]);
					}
				}
			}
		}
	}

	public Quest GetFlagQuest(Quest quest, float randomValue, int level)
	{
		float num = globalLockQuestProbability.probabilityCurve.Evaluate(level) * globalFlagQuestProbabilityMultiplier;
		if (!(randomValue <= quest.lockQuestProbability * num))
		{
			return null;
		}
		return globalLockQuestProbability.quest;
	}

	public QuestTile GetLockedQuestTile(out SessionQuestReward reward, SessionQuest filterChallenge = null)
	{
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass30_0();
		CS_0024_003C_003E8__locals4.filterChallenge = filterChallenge;
		List<QuestTile> list = Enumerable.ToList(Enumerable.ToDictionary(Enumerable.Where(rewardByQuestTile, (KeyValuePair<QuestTile, SessionQuestReward> x) => x.Value != null && (CS_0024_003C_003E8__locals4.filterChallenge == null || x.Value.sessionQuest == CS_0024_003C_003E8__locals4.filterChallenge)), (KeyValuePair<QuestTile, SessionQuestReward> x) => x.Key, (KeyValuePair<QuestTile, SessionQuestReward> y) => y.Value).Keys);
		if (list.Count == 0)
		{
			Debug.LogError($"no locked quest tile connected to challenge {CS_0024_003C_003E8__locals4.filterChallenge}");
			reward = null;
			return null;
		}
		QuestTile questTile = list[UnityEngine.Random.Range(0, list.Count)];
		reward = rewardByQuestTile[questTile];
		return questTile;
	}

	public QuestTile GetQuestTile(QuestTileId tileId, out SessionQuestReward reward, out SessionQuest unlockChallenge)
	{
		QuestTile questTile = QuestTileById[tileId];
		reward = rewardByQuestTile[questTile];
		unlockChallenge = (reward.compositeSessionQuest ? reward.compositeSessionQuest : reward.sessionQuest);
		return questTile;
	}

	public void ExcludeTypes(List<GroupTypeId> excludedTypes)
	{
		excludedGroupTypes = excludedTypes;
	}

	public void SetGlobalMultiplierValues(float questProbabilityMultiplier, float questDifficultyMultiplier, float flagQuestProbabilityMultiplier)
	{
		globalQuestProbabilityMultiplier = questProbabilityMultiplier;
		GlobalQuestDifficultyMultiplier = questDifficultyMultiplier;
		globalFlagQuestProbabilityMultiplier = flagQuestProbabilityMultiplier;
		if (globalFlagQuestProbabilityMultiplier >= 0.5f)
		{
			globalLockQuestProbability.probabilityCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));
		}
	}

	public void SetExponentialFactor(float exponentialFactor)
	{
		exponentialDifficultyIncreaseFactor = exponentialFactor;
	}

	public void SetQuestSpawnTileLimit(int limit)
	{
		questSpawnTileLimit = limit;
	}

	private bool _003CGetRandomQuestTile_003Eb__25_0(QuestTileSubCollection x)
	{
		return !ListHelper.ListsContainAMatchingValue(x.allSegmentTypes, excludedGroupTypes);
	}
}
