using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Goap;
using NSMedieval.Serialization;
using NSMedieval.Village.Map;

namespace NSMedieval.State
{
	[FVSerializableKey("RoleVisitorBehaviour", "RoleVisitorBehavior")]
	public class RoleVisitorBehaviour : HumanoidBehaviour
	{
		private const string FvsTargetNode = "targetNode";

		protected virtual string CombatAiAgentId => "TraderAgent";

		protected override string HumanTypeId => "enemy";

		public override string IndicatorPrefabName => "visitor_indicator";

		public override BehaviourType BehaviourType => BehaviourType.RoleVisitor;

		public MapNode TargetNode { get; set; }

		public RoleVisitorBehaviour()
		{
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			base.Humanoid.SetWalkableModel(base.Humanoid.CurrentHumanType.WalkableModelFriendly);
			base.Humanoid.SetCombatAiAgent(CombatAiAgentId);
			base.Humanoid.CombatAi.SetState(CombatAiState.IsAggressive, false);
		}

		public override void OnSpawn()
		{
			base.OnSpawn();
			if (GlobalSaveController.CurrentVillageData.FirstEnter)
			{
				return;
			}
			List<EquipmentInstance> list = new List<EquipmentInstance>();
			list.AddRange(base.Inventory.GetEquipments());
			foreach (EquipmentInstance item in list)
			{
				MonoSingleton<NPCController>.Instance.EquipItem(item, base.Inventory);
			}
		}

		protected override Agent CreateGoapAgent()
		{
			return null;
		}

		public override string GetGoapAgentId()
		{
			return "visitor";
		}

		public override string GetMultiselectName()
		{
			return "visitor";
		}

		public override void OnTrapTriggered(TrapComponentInstance trap)
		{
		}

		public override void Dispose()
		{
		}

		public Vec3Int GetGridPosition()
		{
			return base.Humanoid.GetGridPosition();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("targetNode", TargetNode);
		}

		public RoleVisitorBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
			TargetNode = deserializer.ReadObject<MapNode>("targetNode");
		}
	}
}
