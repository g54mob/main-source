using System.IO;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.DebugEvents
{
	public struct OrderIssued : IDebugEvent
	{
		public OrderType OrderType;

		public bool IsDragSelect;

		public int MinNodeIndex;

		public int MaxNodeIndex;

		public int WorldObjectId;

		public byte TypeId => 2;

		public DebugEventCategory Category => DebugEventCategory.Event;

		public OrderIssued(Vec3Int p1, Vec3Int p2, OrderType orderType)
		{
			Vec3Int gridPosition = p1.Min(p2);
			Vec3Int gridPosition2 = p1.Max(p2);
			gridPosition.y /= World.MapBlockHeight;
			gridPosition2.y /= World.MapBlockHeight;
			IsDragSelect = true;
			WorldObjectId = 0;
			MinNodeIndex = GridDataIndexTools.FastTo1DIndex(gridPosition);
			MaxNodeIndex = GridDataIndexTools.FastTo1DIndex(gridPosition2);
			OrderType = orderType;
		}

		public OrderIssued(WorldObject worldObject, OrderType orderType)
		{
			OrderType = orderType;
			IsDragSelect = false;
			WorldObjectId = worldObject.UniqueId;
			MinNodeIndex = GridDataIndexTools.FastTo1DIndex(worldObject.GridDataPosition);
			MaxNodeIndex = 0;
		}

		public void WriteBytes(BinaryWriter writer)
		{
			writer.Write((int)OrderType);
			writer.Write(IsDragSelect);
			if (IsDragSelect)
			{
				writer.Write(MinNodeIndex);
				writer.Write(MaxNodeIndex);
			}
			else
			{
				writer.Write(WorldObjectId);
				writer.Write(MinNodeIndex);
			}
		}

		public void ReadBytes(BinaryReader reader)
		{
			OrderType = (OrderType)reader.ReadInt32();
			IsDragSelect = reader.ReadBoolean();
			if (IsDragSelect)
			{
				MinNodeIndex = reader.ReadInt32();
				MaxNodeIndex = reader.ReadInt32();
				WorldObjectId = 0;
			}
			else
			{
				WorldObjectId = reader.ReadInt32();
				MinNodeIndex = reader.ReadInt32();
			}
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "Order Issued";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			if (IsDragSelect)
			{
				Vec3Int vec3Int = context.NodeIndexTo3D(MinNodeIndex);
				Vec3Int vec3Int2 = context.NodeIndexTo3D(MaxNodeIndex);
				return $"'{OrderType}' drag select {vec3Int} -> {vec3Int2}";
			}
			Vec3Int vec3Int3 = context.NodeIndexTo3D(MinNodeIndex);
			return $"'{OrderType}' on world object ({WorldObjectId}) at {vec3Int3}";
		}

		public void DrawGizmos(DebugEventWindowContext context)
		{
			Color yellow = Color.yellow;
			yellow.a = 0.2f;
			if (IsDragSelect)
			{
				Vector3 vector = context.NodeIndexTo3D(MinNodeIndex).ToVector3World();
				vector.x -= 0.5f;
				vector.z -= 0.5f;
				Vector3 vector2 = context.NodeIndexTo3D(MaxNodeIndex).ToVector3World();
				vector2.y += World.MapBlockHeight;
				vector2.x += 0.5f;
				vector2.z += 0.5f;
				Vector3 vector3 = vector2 - vector;
				vector3.y = 0.1f;
				Vector3 vector4 = (vector + vector2) / 2f;
				vector4.y = vector.y + vector3.y / 2f;
			}
			else
			{
				Vector3 vector5 = context.NodeIndexTo3D(MinNodeIndex).ToVector3World();
				Vector3 vector6 = new Vector3(1f, 0.1f, 1f);
				_ = vector5 + Vector3.up * (vector6.y / 2f);
			}
		}

		public void OnDoubleClick(DebugEventWindowContext context)
		{
			if (MonoSingleton<RtsCamera>.IsInstantiated())
			{
				Vec3Int input = context.NodeIndexTo3D(MinNodeIndex);
				MonoSingleton<RtsCamera>.Instance.JumpTo(input.ToVector3World());
			}
		}
	}
}
