using System;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.CommanderAI
{
	[FVSerializableKey("ManualCutPlantCommanderAgent", "")]
	public class ManualCutPlantCommanderAgent : CommanderAgentBase, IDisposable
	{
		public ManualCutPlantCommanderAgent(uint id, VillageMap map)
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
				SetPlantToChop(position);
			}
		}

		private void SetPlantToChop(Vector3 point)
		{
			Vec3Int gridPos = point.ToGridVec3Int();
			PlantMapResourceInstance plant = MonoSingleton<PlantResourceManager>.Instance.GetPlant(gridPos);
			if (plant != null && !plant.HasDisposed && base.UnitGroup.Units.Count != 0)
			{
				base.UnitGroup.Units.First().CurrentOrder = new CutPlantOrder(plant);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ManualCutPlantCommanderAgent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
