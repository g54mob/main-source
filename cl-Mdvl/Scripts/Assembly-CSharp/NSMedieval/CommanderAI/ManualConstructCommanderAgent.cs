using System;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Map;
using NSMedieval.Serialization;
using NSMedieval.Tools;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.CommanderAI
{
	[FVSerializableKey("ManualConstructCommanderAgent", "")]
	public class ManualConstructCommanderAgent : CommanderAgentBase, IDisposable
	{
		public ManualConstructCommanderAgent(uint id, VillageMap map)
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
				PlaceBuilding(position);
			}
		}

		private void PlaceBuilding(Vector3 point)
		{
			if (base.UnitGroup.Units.Count != 0)
			{
				Vec3Int position = point.ToGridVec3Int();
				base.UnitGroup.Units.First().CurrentOrder = new ConstructBuildingOrder("wood_ladder", position, 0, isSiegeWeapon: false);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ManualConstructCommanderAgent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
