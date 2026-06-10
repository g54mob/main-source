using System;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Map;
using NSMedieval.Serialization;
using NSMedieval.Tools;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.CommanderAI
{
	[FVSerializableKey("ManualOperateSiegeWeaponCommanderAgent", "")]
	public class ManualOperateSiegeWeaponCommanderAgent : CommanderAgentBase, IDisposable
	{
		public ManualOperateSiegeWeaponCommanderAgent(uint id, VillageMap map)
			: base(id, map)
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (MonoSingleton<DebugInputController>.IsInstantiated())
			{
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
			}
		}

		private void OnRightMouseDown()
		{
			if (RaycastUtils.RaycastFromScreen(Input.mousePosition, out var position, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				position = position.SnapToGrid(0.1f);
				OperateSiegeWeapon(position);
			}
		}

		private void OperateSiegeWeapon(Vector3 point)
		{
			if (base.UnitGroup.Units.Count == 0)
			{
				return;
			}
			Vec3Int pos = point.ToGridVec3Int();
			CommanderAIUnit commanderAIUnit = base.UnitGroup.Units.First();
			SiegeWeaponComponentInstance componentInstance = base.Map.SiegeWeaponComponentManager.GetComponentInstance(pos);
			if (componentInstance != null && !componentInstance.HasDisposed)
			{
				BaseBuildingInstance ownerBuilding = componentInstance.OwnerBuilding;
				if (ownerBuilding != null && !ownerBuilding.HasDisposed && ownerBuilding.FactionOwnership == FactionOwnership.Enemy)
				{
					commanderAIUnit.CurrentOrder = new OperateSiegeWeaponOrder(componentInstance);
				}
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ManualOperateSiegeWeaponCommanderAgent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
