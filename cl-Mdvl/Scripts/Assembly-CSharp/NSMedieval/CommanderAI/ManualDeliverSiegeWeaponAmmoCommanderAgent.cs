using System;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.CommanderAI
{
	[FVSerializableKey("ManualDeliverSiegeWeaponAmmoCommanderAgent", "")]
	public class ManualDeliverSiegeWeaponAmmoCommanderAgent : CommanderAgentBase, IDisposable
	{
		private ResourcePileInstance ammo;

		private SiegeWeaponComponentInstance siegeWeaponComponentInstance;

		public ManualDeliverSiegeWeaponAmmoCommanderAgent(uint id, VillageMap map)
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
			Vec3Int vec3Int = point.ToGridVec3Int();
			CommanderAIUnit commanderAIUnit = base.UnitGroup.Units.First();
			SiegeWeaponComponentInstance componentInstance = VillageManager.ActiveVillage.Map.SiegeWeaponComponentManager.GetComponentInstance(vec3Int);
			if (componentInstance != null && !componentInstance.HasDisposed)
			{
				BaseBuildingInstance ownerBuilding = componentInstance.OwnerBuilding;
				if (ownerBuilding != null && !ownerBuilding.HasDisposed && ownerBuilding.FactionOwnership == FactionOwnership.Enemy)
				{
					siegeWeaponComponentInstance = componentInstance;
				}
			}
			if (siegeWeaponComponentInstance != null)
			{
				ResourcePileInstance pileByGridPosition = MonoSingleton<ResourcePileManager>.Instance.GetPileByGridPosition(vec3Int);
				if (pileByGridPosition != null && !pileByGridPosition.HasDisposed && pileByGridPosition.FactionOwnership == FactionOwnership.Enemy && siegeWeaponComponentInstance.ResourcesFilter.IsValid(pileByGridPosition.Blueprint))
				{
					ammo = pileByGridPosition;
					commanderAIUnit.CurrentOrder = new DeliverSiegeWeaponAmmoOrder(siegeWeaponComponentInstance, ammo);
				}
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ManualDeliverSiegeWeaponAmmoCommanderAgent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
