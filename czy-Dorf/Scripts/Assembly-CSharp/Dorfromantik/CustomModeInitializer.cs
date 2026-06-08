using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	public class CustomModeInitializer : MonoBehaviour
	{
		[SerializeField]
		private CustomModeConfiguration configuration;

		[SerializeField]
		private TileGenerator tileGenerator;

		[SerializeField]
		private QuestManager questManager;

		[FormerlySerializedAs("demoTileCap")]
		[SerializeField]
		private TileLimiter tileLimiter;

		[SerializeField]
		private TileStack tileStack;

		[SerializeField]
		private WorldBorder worldBorder;

		private TileGenConfiguration modifiedTileGenConfiguration;

		private QuestSystemConfiguration modifiedQuestSystemConfiguration;

		private GameSceneInitializer sceneInitializer;

		private GameSession gameSession;

		private void Awake()
		{
			configuration.OnUpdated += Initialize;
		}

		public void Initialize()
		{
			sceneInitializer = GetComponent<GameSceneInitializer>();
			gameSession = GetComponent<GameSession>();
			tileGenerator.SetSeed(configuration.seed);
			if (modifiedTileGenConfiguration == null)
			{
				modifiedTileGenConfiguration = Object.Instantiate(sceneInitializer.DefaultTileGenConfiguration);
			}
			if (modifiedQuestSystemConfiguration == null)
			{
				modifiedQuestSystemConfiguration = Object.Instantiate(sceneInitializer.DefaultQuestSystemConfiguration);
			}
			List<GroupTypeId> list = new List<GroupTypeId>();
			foreach (QuestTileCollection questTileCollection in modifiedQuestSystemConfiguration.questTileCollections)
			{
				if ((questTileCollection.rawProbability = configuration.GetValue(questTileCollection.groupType.customRuleType)) == 0f)
				{
					list.Add(questTileCollection.groupType.id);
				}
			}
			foreach (QuestTileCollection questTileCollection2 in modifiedQuestSystemConfiguration.questTileCollections)
			{
				foreach (QuestTileSubCollection subCollection in questTileCollection2.subCollections)
				{
					subCollection.subCollectionRawProbability *= Mathf.Pow(configuration.GetValue(CustomRuleType.Density), subCollection.occupiedEdges + 1);
				}
			}
			modifiedQuestSystemConfiguration.SetGlobalMultiplierValues(configuration.GetValue(CustomRuleType.QuestProbability), configuration.GetValue(CustomRuleType.QuestDifficulty), configuration.GetValue(CustomRuleType.FlagQuestProbability));
			modifiedQuestSystemConfiguration.UpdateValues();
			questManager.SetConfiguration(modifiedQuestSystemConfiguration);
			modifiedQuestSystemConfiguration.ExcludeTypes(list);
			foreach (GroupTypeConfiguration globalGroupTypeProbability in modifiedTileGenConfiguration.globalGroupTypeProbabilities)
			{
				globalGroupTypeProbability.rawProbability = configuration.GetValue(globalGroupTypeProbability.groupType.customRuleType);
			}
			foreach (TilePresetConfiguration allTilePreset in modifiedTileGenConfiguration.allTilePresets)
			{
				allTilePreset.rawProbability *= Mathf.Pow(configuration.GetValue(CustomRuleType.Density), allTilePreset.occupiedEdges + 1);
			}
			modifiedTileGenConfiguration.UpdateValues();
			tileGenerator.SetConfiguration(modifiedTileGenConfiguration);
			tileStack.SetInfinite(configuration.HasInfiniteTileStack);
			int num = Mathf.RoundToInt(configuration.GetValue(CustomRuleType.WorldBorderRadius));
			worldBorder.SetBorder(num);
			int num2 = Mathf.RoundToInt(configuration.GetValue(CustomRuleType.TileLimit));
			bool flag = gameSession.GameMode.canHaveTileLimit && (num <= 0 || !WorldBorder.MaxTilesByWorldBorder.ContainsKey(num) || WorldBorder.MaxTilesByWorldBorder[num] - 1 > num2);
			tileLimiter.Setup(flag ? num2 : (-1));
		}

		private void OnDestroy()
		{
			configuration.OnUpdated -= Initialize;
		}
	}
}
