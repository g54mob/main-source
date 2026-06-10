using System.IO;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Map;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.DebugEvents
{
	public struct BuildingPhaseChanged : IDebugEvent
	{
		public int BuildingId;

		public ConstructionPhase Phase;

		public int NodeIndex;

		public byte TypeId => 4;

		public DebugEventCategory Category => DebugEventCategory.Event;

		public BuildingPhaseChanged(BaseBuildingInstance building)
		{
			if (building == null)
			{
				BuildingId = 0;
				Phase = ConstructionPhase.Finished;
				NodeIndex = 0;
			}
			else
			{
				BuildingId = building.UniqueId;
				Phase = building.ConstructionPhase;
				NodeIndex = GridDataIndexTools.FastTo1DIndex(building.GridDataPosition);
			}
		}

		public void WriteBytes(BinaryWriter writer)
		{
			writer.Write(BuildingId);
			writer.Write((int)Phase);
			writer.Write(NodeIndex);
		}

		public void ReadBytes(BinaryReader reader)
		{
			BuildingId = reader.ReadInt32();
			Phase = (ConstructionPhase)reader.ReadInt32();
			NodeIndex = reader.ReadInt32();
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "Building Phase Changed";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			return $"-> '{Phase}' at {context.NodeIndexTo3D(NodeIndex)} (id {BuildingId})";
		}

		public void DrawGizmos(DebugEventWindowContext context)
		{
			_ = context.NodeIndexTo3D(NodeIndex).ToVector3World() + Vector3.up * ((float)World.MapBlockHeight / 2f);
		}

		public void OnDoubleClick(DebugEventWindowContext context)
		{
			if (MonoSingleton<RtsCamera>.IsInstantiated())
			{
				Vec3Int input = context.NodeIndexTo3D(NodeIndex);
				MonoSingleton<RtsCamera>.Instance.JumpTo(input.ToVector3World());
			}
		}
	}
}
