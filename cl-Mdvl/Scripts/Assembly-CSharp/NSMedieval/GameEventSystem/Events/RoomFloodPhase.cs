using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.Tools;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("RoomFloodPhase", "")]
	public class RoomFloodPhase : SingleExecutePhaseBase
	{
		[SerializeField]
		private uint newsMessageId;

		private readonly int highestPossibleNode;

		private Room randomRoom;

		public RoomFloodPhase()
		{
			highestPossibleNode = GlobalSaveController.CurrentVillageData.MapSize.y;
		}

		public RoomFloodPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}

		public override void OnLoaded(bool fromSave)
		{
			Subscribe();
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
		}

		public override void OnEnd()
		{
			Unsubscribe();
		}

		public static bool RoomFloodCheck(Room room)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(40, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Checking Room Flood Phase: at center: ");
				messageBuilder.AppendFormatted(room.Center);
				messageBuilder.AppendLiteral(", ");
				messageBuilder.AppendFormatted(room.RoomType);
			}
			Log.Debug(messageBuilder);
			int num = 0;
			foreach (MapNode wallNode in room.WallNodes)
			{
				if (!room.CornerWallNodes.Contains(wallNode) && !(wallNode.VoxelType == null) && (!(wallNode.VoxelType.GetID() != "Dirt") || !(wallNode.VoxelType.GetID() != "WetlandDirt") || !(wallNode.VoxelType.GetID() != "Rocky")))
				{
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Floodable Wall Node found (");
						messageBuilder2.AppendFormatted(wallNode.Position);
						messageBuilder2.AppendLiteral("): ");
						messageBuilder2.AppendFormatted(wallNode.VoxelType.GetID());
					}
					Log.Trace(messageBuilder2);
					num++;
				}
			}
			if (num == 0)
			{
				FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Room  (");
					messageBuilder2.AppendFormatted(room.Center);
					messageBuilder2.AppendLiteral(") has no floodable walls! Exiting...");
				}
				Log.Trace(messageBuilder2);
				return false;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(44, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Room (");
				messageBuilder.AppendFormatted(room.Center);
				messageBuilder.AppendLiteral(") has ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" wall voxels which are floodable");
			}
			Log.Debug(messageBuilder);
			int num2 = int.MaxValue;
			foreach (MapNode belowFloorNode in room.BelowFloorNodes)
			{
				if (belowFloorNode.GetNodeAbove().HasWaterTag)
				{
					messageBuilder = new FVLogDebugInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Room node ");
						messageBuilder.AppendFormatted(belowFloorNode.GetNodeAbove().Position);
						messageBuilder.AppendLiteral(" already has WaterTag, Not a valid room.");
					}
					Log.Debug(messageBuilder);
					isEnabled = false;
					return isEnabled;
				}
				if (belowFloorNode.Position.y < num2)
				{
					num2 = belowFloorNode.Position.y;
				}
			}
			messageBuilder = new FVLogDebugInterpolationHandler(30, 1, out var isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
			if (isEnabled2)
			{
				messageBuilder.AppendLiteral("Room lowest floor Y position: ");
				messageBuilder.AppendFormatted(num2);
			}
			Log.Debug(messageBuilder);
			int num3 = 0;
			foreach (int item in VillageManager.ActiveVillage.Map.WaterManager.WaterSimLogic.NodesInVolumePublic)
			{
				if (GridDataIndexTools.GetY(item) > num3)
				{
					num3 = GridDataIndexTools.GetY(item);
				}
			}
			messageBuilder = new FVLogDebugInterpolationHandler(27, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
			if (isEnabled2)
			{
				messageBuilder.AppendLiteral("Highest water node result: ");
				messageBuilder.AppendFormatted(num3);
			}
			Log.Debug(messageBuilder);
			if (num2 >= num3)
			{
				FVLogger logger = GameEventPhaseBase.Logger;
				messageBuilder = new FVLogDebugInterpolationHandler(39, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
				if (isEnabled2)
				{
					messageBuilder.AppendLiteral("Lowest floor ");
					messageBuilder.AppendFormatted(num2);
					messageBuilder.AppendLiteral(" is not below ");
					messageBuilder.AppendFormatted(num3);
					messageBuilder.AppendLiteral(". Exiting...");
				}
				logger.Debug(in messageBuilder);
				return false;
			}
			return true;
		}

		protected override void Execute()
		{
			Room room = VillageManager.ActiveVillage.Map.RoomDetection.FindBestRoomSafe(RoomFloodCheck, RoomYLevelScore);
			if (room == null)
			{
				Log.Error("Room could not be found, this should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
				Dispose();
				return;
			}
			randomRoom = null;
			float num = RoomYLevelScore(room);
			HashSet<Room> hashSet = new HashSet<Room>();
			bool isEnabled;
			foreach (Room item in VillageManager.ActiveVillage.Map.RoomDetection.IterateRoomsSafe())
			{
				if (!RoomFloodCheck(item))
				{
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Room: (");
						messageBuilder.AppendFormatted(item.Center);
						messageBuilder.AppendLiteral(") can't be flooded. Continuing...");
					}
					Log.Debug(messageBuilder);
				}
				else if (RoomYLevelScore(item) < num)
				{
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(39, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Room: (");
						messageBuilder.AppendFormatted(item.Center);
						messageBuilder.AppendLiteral(") is higher than ");
						messageBuilder.AppendFormatted(room.Center);
						messageBuilder.AppendLiteral(". Continuing...");
					}
					Log.Debug(messageBuilder);
				}
				else
				{
					hashSet.Add(item);
				}
			}
			randomRoom = hashSet.PickRandom();
			foreach (Room item2 in hashSet)
			{
				Vec3Int vec3Int = new Vec3Int(0, highestPossibleNode, 0);
				foreach (MapNode belowFloorNode in item2.BelowFloorNodes)
				{
					int num2 = belowFloorNode.Position.y + 1;
					if (num2 < vec3Int.y)
					{
						vec3Int = new Vec3Int(belowFloorNode.Position.x, num2, belowFloorNode.Position.z);
					}
				}
				FillWaterToPosition(vec3Int);
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Flooding Room: ");
					messageBuilder.AppendFormatted(item2.Center);
					messageBuilder.AppendLiteral(" at ");
					messageBuilder.AppendFormatted(vec3Int);
				}
				Log.Debug(messageBuilder);
			}
			newsMessageId = GameEventUtil.PublishNews(base.EventInstance, 0);
		}

		private void FillWaterToPosition(Vec3Int pos, float topWaterLevel = 0.056f)
		{
			FVLogger logger = GameEventPhaseBase.Logger;
			Vec3Int vec3Int = pos;
			logger.Debug("Filling water to " + vec3Int.ToString());
			Queue<Vec3Int> queue = new Queue<Vec3Int>();
			queue.Enqueue(pos);
			HashSet<Vec3Int> hashSet = new HashSet<Vec3Int>();
			WaterSimLogic waterSimLogic = VillageManager.ActiveVillage.Map.WaterManager.WaterSimLogic;
			WaterManager waterManager = VillageManager.ActiveVillage.Map.WaterManager;
			NSMedieval.RoomDetection.RoomDetection roomDetection = VillageManager.ActiveVillage.Map.RoomDetection;
			while (queue.Count > 0)
			{
				Vec3Int b = queue.Dequeue();
				if (roomDetection.GetRoom(b) == null)
				{
					continue;
				}
				float num = ((topWaterLevel <= 0f) ? 0f : ((b.y == pos.y) ? topWaterLevel : 1f));
				waterSimLogic.SetWaterAt(b.x, b.y, b.z, num);
				Vec3Int[] neighbors3DNonDiagonal = MapNodeUtils.Neighbors3DNonDiagonal;
				for (int i = 0; i < neighbors3DNonDiagonal.Length; i++)
				{
					Vec3Int a = neighbors3DNonDiagonal[i];
					if (a.y > 0)
					{
						continue;
					}
					Vec3Int vec3Int2 = a + b;
					if (hashSet.Add(vec3Int2) && GridDataIndexTools.InRange(vec3Int2.x, vec3Int2.y, vec3Int2.z))
					{
						int nodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(vec3Int2);
						int obstacle = waterManager.GetObstacle(nodeIndex);
						if (obstacle != 1 && (obstacle != 2 || !(num <= 0.5f)) && (a.y >= 0 || obstacle != 3))
						{
							queue.Enqueue(vec3Int2);
						}
					}
				}
			}
		}

		private float RoomYLevelScore(Room room)
		{
			float num = 0f;
			foreach (MapNode belowFloorNode in room.BelowFloorNodes)
			{
				float num2 = highestPossibleNode - belowFloorNode.Position.y;
				if (num2 > num)
				{
					num = num2;
				}
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(23, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\RoomFloodPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Room Score: ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" at height ");
				messageBuilder.AppendFormatted((float)highestPossibleNode - num);
			}
			Log.Debug(messageBuilder);
			return num;
		}

		private void Subscribe()
		{
			MonoSingleton<NewsManager>.Instance.OnDialogClosed += OnNewsDialogClosed;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<NewsManager>.IsInstantiated())
			{
				MonoSingleton<NewsManager>.Instance.OnDialogClosed -= OnNewsDialogClosed;
			}
		}

		private void OnNewsDialogClosed(uint newsId, int chosenOptionIndex)
		{
			if (newsId == newsMessageId && randomRoom != null && chosenOptionIndex == 1)
			{
				MonoSingleton<RtsCamera>.Instance.JumpTo(randomRoom.GetAveragePosition());
			}
		}
	}
}
