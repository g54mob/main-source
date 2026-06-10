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
	[FVSerializableKey("ManualDigCommanderAgent", "")]
	public class ManualDigCommanderAgent : CommanderAgentBase, IDisposable
	{
		public ManualDigCommanderAgent(uint id, VillageMap map)
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
				SetVoxelToDig(position);
			}
		}

		private void SetVoxelToDig(Vector3 point)
		{
			if (base.UnitGroup.Units.Count != 0)
			{
				Vec3Int a = point.ToGridVec3Int();
				base.UnitGroup.Units.First().CurrentOrder = new DigVoxelOrder(a, a + Vec3Int.forward);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ManualDigCommanderAgent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
