using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Serialization;
using NSMedieval.Tools;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.CommanderAI
{
	[FVSerializableKey("ManualInputCommanderAgent", "")]
	public class ManualInputCommanderAgent : CommanderAgentBase, IDisposable
	{
		public ManualInputCommanderAgent(uint id, VillageMap map)
			: base(id, map)
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
		}

		private void OnRightMouseDown()
		{
			if (Input.GetKey(KeyCode.LeftControl))
			{
				SelectableObject mouseHoverObject = MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject;
				if (mouseHoverObject is WorkerView { HumanoidInstance: not null } workerView && !workerView.HumanoidInstance.IsEnemy())
				{
					SetTargetToAttack(workerView.HumanoidInstance);
					return;
				}
				if (mouseHoverObject is BaseBuildingViewComponent { BaseBuildingInstance: { HasDisposed: false, FactionOwnership: FactionOwnership.Player } } baseBuildingViewComponent)
				{
					SetTargetToAttack(baseBuildingViewComponent.BaseBuildingInstance);
					return;
				}
			}
			if (RaycastUtils.RaycastFromScreen(Input.mousePosition, out var position, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				position = position.SnapToGrid(0.1f);
				MoveAllToPoint(position);
			}
		}

		public void MoveAllToPoint(Vector3 point)
		{
			if (base.UnitGroup.Units.Count == 0)
			{
				return;
			}
			Vec3Int gridPosition = point.ToGridVec3Int();
			MapNode node = base.Map.GetNode(gridPosition);
			using IEnumerator<CommanderAIUnit> enumerator = base.UnitGroup.Units.GetEnumerator();
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(node, 100f))
			{
				if (item.IsWalkable)
				{
					if (!enumerator.MoveNext())
					{
						break;
					}
					enumerator.Current.CurrentOrder = new MoveOrder(item.WorldPosition);
				}
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			if (MonoSingleton<DebugInputController>.IsInstantiated())
			{
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
			}
		}

		private void SetTargetToAttack(IDamageTakingAgent damageTakingAgent)
		{
			if (base.UnitGroup.Units.Count != 0)
			{
				CommanderAIUnit commanderAIUnit = base.UnitGroup.Units.First();
				SiegeWeaponComponentInstance siegeWeapon = commanderAIUnit.Humanoid.CombatAi?.GetState<SiegeWeaponComponentInstance>(CombatAiState.OperatingTrebuchet);
				commanderAIUnit.CurrentOrder = new AttackOrder(damageTakingAgent, siegeWeapon);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ManualInputCommanderAgent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
