using System.IO;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Map;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.DebugEvents
{
	public struct BuildingRemoved : IDebugEvent
	{
		public int BuildingId;

		public int NodeIndex;

		public byte TypeId => 5;

		public DebugEventCategory Category => DebugEventCategory.Event;

		public BuildingRemoved(BaseBuildingInstance baseBuildingInstance)
		{
			if (baseBuildingInstance == null)
			{
				BuildingId = 0;
				NodeIndex = 0;
			}
			else
			{
				BuildingId = baseBuildingInstance.UniqueId;
				NodeIndex = GridDataIndexTools.FastTo1DIndex(baseBuildingInstance.GridDataPosition);
			}
		}

		public void WriteBytes(BinaryWriter writer)
		{
			writer.Write(BuildingId);
			writer.Write(NodeIndex);
		}

		public void ReadBytes(BinaryReader reader)
		{
			BuildingId = reader.ReadInt32();
			NodeIndex = reader.ReadInt32();
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "Building Removed";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			return $"At {context.NodeIndexTo3D(NodeIndex)} (id {BuildingId})";
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
