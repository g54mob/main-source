using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval;
using NSMedieval.CommanderAI;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Village.Map;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using Raid.Config;
using UnityEngine;

[FVSerializableKey("BehaviourTreeCommanderAgent", "")]
public class BehaviourTreeCommanderAgent : CommanderAgentBase
{
	private BehaviourTreeOwner behaviourTree;

	private SiegePathfinderPenaltyModifiers siegePathfinderModifiers;

	public ActiveRaidInfo LinkedRaid => linkedRaid;

	public BehaviourTreeCommanderAgent(uint id, VillageMap map, SiegePathfinderPenaltyModifiers siegePathfinderModifiers)
		: base(id, map)
	{
		this.siegePathfinderModifiers = siegePathfinderModifiers;
		Initialize();
	}

	private void Initialize()
	{
		bool isEnabled;
		FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(74, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\Agents\\BehaviourTreeCommanderAgent.cs");
		if (isEnabled)
		{
			messageBuilder.AppendLiteral("Initializing BehaviourTreeCommanderAgent with siege pathfinder modifiers: ");
			messageBuilder.AppendFormatted(siegePathfinderModifiers);
		}
		Log.Info(messageBuilder);
		GameObject original = ((!GlobalSaveController.CurrentVillageData.IsSecondMap) ? MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("CommanderAIBehaviourTree") : MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("EnemyCampCommanderAIBehaviourTree"));
		GameObject gameObject = Object.Instantiate(original);
		CommanderAgentProxy component = gameObject.GetComponent<CommanderAgentProxy>();
		component.Agent = this;
		component.SiegePathfinderModifiers = siegePathfinderModifiers;
		behaviourTree = gameObject.GetComponent<BehaviourTreeOwner>();
		behaviourTree.updateMode = Graph.UpdateMode.Manual;
		behaviourTree.updateInterval = 0.25f;
	}

	public override void InitAfterLoad()
	{
		base.InitAfterLoad();
		Initialize();
	}

	protected override void OnTick()
	{
		behaviourTree.Tick();
	}

	public override void Dispose()
	{
		base.Dispose();
		if (behaviourTree != null)
		{
			Object.Destroy(behaviourTree.gameObject);
		}
	}

	public void RestartTree()
	{
		Log.Info("Restarting behaviour tree", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\Agents\\BehaviourTreeCommanderAgent.cs");
		behaviourTree.RestartBehaviour();
	}

	public override void Serialize(FVSerializer serializer)
	{
		base.Serialize(serializer);
		serializer.Write("siegePathfinderModifiers", siegePathfinderModifiers);
	}

	public BehaviourTreeCommanderAgent(FVDeserializer deserializer)
		: base(deserializer)
	{
		siegePathfinderModifiers = deserializer.ReadObject<SiegePathfinderPenaltyModifiers>("siegePathfinderModifiers");
		if (siegePathfinderModifiers == null)
		{
			siegePathfinderModifiers = SingletonModel<RaidSpawnSettings, RaidSpawnSettingsData>.I.StandardSiegePathfinderSettings;
		}
	}
}
