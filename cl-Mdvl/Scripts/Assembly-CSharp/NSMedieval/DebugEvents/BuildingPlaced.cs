using System.IO;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Map;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.DebugEvents
{
	public struct BuildingPlaced : IDebugEvent
	{
		public int NodeIndex;

		public int BuildingId;

		public int BlueprintHash;

		private BaseBuildingBlueprint cachedBlueprint;

		public byte TypeId => 3;

		public DebugEventCategory Category => DebugEventCategory.Event;

		public BuildingPlaced(BaseBuildingInstance baseBuildingInstance)
		{
			if (baseBuildingInstance == null)
			{
				BlueprintHash = 0;
				BuildingId = 0;
				NodeIndex = 0;
				cachedBlueprint = null;
			}
			else
			{
				BlueprintHash = baseBuildingInstance.BlueprintId?.GetHashCode() ?? 0;
				BuildingId = baseBuildingInstance.UniqueId;
				NodeIndex = GridDataIndexTools.FastTo1DIndex(baseBuildingInstance.GridDataPosition);
				cachedBlueprint = null;
			}
		}

		public void WriteBytes(BinaryWriter writer)
		{
			writer.Write(NodeIndex);
			writer.Write(BuildingId);
			writer.Write(BlueprintHash);
		}

		public void ReadBytes(BinaryReader reader)
		{
			NodeIndex = reader.ReadInt32();
			BuildingId = reader.ReadInt32();
			BlueprintHash = reader.ReadInt32();
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "Building Placed";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			if (cachedBlueprint == null && Repository<BaseBuildingRepository, BaseBuildingBlueprint>.IsInstantiated())
			{
				foreach (BaseBuildingBlueprint allItem in Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems())
				{
					if (allItem.GetID().GetHashCode() == BlueprintHash)
					{
						cachedBlueprint = allItem;
						break;
					}
				}
			}
			return string.Format("'{0}' at {1} (id {2})", cachedBlueprint?.GetID() ?? "UNKOWN_BLUEPRINT", context.NodeIndexTo3D(NodeIndex), BuildingId);
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
