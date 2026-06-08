using System.Collections.Generic;
using Dorfromantik;
using Dorfromantik.CreativeMode;
using UnityEngine;

[RequireComponent(typeof(GameSceneInitializer))]
public class CreativeModeConfigurationInitializer : MonoBehaviour
{
	[SerializeField]
	private World world;

	[SerializeField]
	private WorldBorder worldBorder;

	[SerializeField]
	private TileGenerator tileGenerator;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private BiomeSectionManager biomeSectionManager;

	[SerializeField]
	private CreativeModeConfiguration configuration;

	[SerializeField]
	private QuestSystemConfiguration defaultQuestConfiguration;

	private GameSceneInitializer sceneInitializer;

	private TileGenConfiguration modifiedTileGenConfiguration;

	private QuestSystemConfiguration modifiedQuestSystemConfiguration;

	private void Awake()
	{
		configuration.Reset();
		sceneInitializer = GetComponent<GameSceneInitializer>();
		configuration.OnGroupTypeProbabilitiesUpdated += ApplyUpdatedGroupTypeProbabilities;
		configuration.OnExcludedBiomesUpdated += ApplyExcludedBiomes;
	}

	private void Start()
	{
		ApplyUpdatedGroupTypeProbabilities(initial: true);
	}

	private void ApplyUpdatedGroupTypeProbabilities(bool initial)
	{
		if (OverwritingSingleton<GameSession>.Instance.GameMode.id != GameModeId.Creative)
		{
			return;
		}
		worldBorder.SetBorder(configuration.creativeModeWorldBorder);
		if (modifiedTileGenConfiguration == null)
		{
			modifiedTileGenConfiguration = Object.Instantiate(sceneInitializer.DefaultTileGenConfiguration);
		}
		if (modifiedQuestSystemConfiguration == null)
		{
			modifiedQuestSystemConfiguration = Object.Instantiate(defaultQuestConfiguration);
		}
		foreach (QuestTileCollection questTileCollection in modifiedQuestSystemConfiguration.questTileCollections)
		{
			questTileCollection.rawProbability = configuration.GetGroupTypeProbability(questTileCollection.groupType.id);
		}
		List<GroupTypeId> list = new List<GroupTypeId>();
		foreach (GroupTypeProbability groupTypeProbability in configuration.groupTypeProbabilities)
		{
			if (groupTypeProbability.probability == 0f)
			{
				list.Add(groupTypeProbability.groupType);
			}
		}
		modifiedQuestSystemConfiguration.UpdateValues();
		questManager.SetConfiguration(modifiedQuestSystemConfiguration);
		modifiedQuestSystemConfiguration.ExcludeTypes(list);
		if (configuration.usingConstantQuestProbability)
		{
			modifiedQuestSystemConfiguration.SetConstantQuestTileProbability((list.Count == configuration.groupTypeProbabilities.Count) ? 0f : configuration.constantQuestProbability);
		}
		foreach (GroupTypeConfiguration globalGroupTypeProbability in modifiedTileGenConfiguration.globalGroupTypeProbabilities)
		{
			globalGroupTypeProbability.rawProbability = configuration.GetGroupTypeProbability(globalGroupTypeProbability.groupType.id);
		}
		modifiedTileGenConfiguration.UpdateValues();
		tileGenerator.SetConfiguration(modifiedTileGenConfiguration);
	}

	public void ApplyExcludedBiomes(bool initial)
	{
		biomeSectionManager.SetupAvailableBiomes(configuration.excludedBiomes);
		biomeSectionManager.SetupSections(world.transform, randomizeSeed: false, setNewSeed: false);
		world.UpdateBiomesForAllTiles();
	}

	private void OnDestroy()
	{
		configuration.OnGroupTypeProbabilitiesUpdated -= ApplyUpdatedGroupTypeProbabilities;
		configuration.OnExcludedBiomesUpdated -= ApplyExcludedBiomes;
	}
}
