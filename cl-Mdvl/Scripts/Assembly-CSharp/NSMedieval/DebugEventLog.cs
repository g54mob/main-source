using System;
using System.Collections.Generic;
using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.DebugEvents;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval
{
	public class DebugEventLog
	{
		private struct PreviousCreatureState
		{
			public Vec3Int GridPosition;

			public Goal Goal;

			public float Health;

			public bool IsDrafted;
		}

		public const string PrimaryMapLogNamePrefix = "[primary_map]_";

		private FileStream fileStream;

		private BinaryWriter fileWriter;

		private bool isInitialized;

		private ushort nextShortCreatureId;

		private ushort tempAdvancedTimeTicks;

		private readonly Dictionary<int, ushort> creatureIdToShortId = new Dictionary<int, ushort>();

		private readonly Dictionary<int, PreviousCreatureState> previousCreatureState = new Dictionary<int, PreviousCreatureState>();

		private readonly object writeLock = new object();

		public static bool IsInitialized => Instance?.isInitialized ?? false;

		private static DebugEventLog Instance { get; set; }

		[RuntimeInitializeOnLoadMethod]
		public static void OnDomainReload()
		{
			Instance = null;
		}

		public static void Write<T>(T debugEvent) where T : struct, IDebugEvent
		{
			if (Instance == null || !IsInitialized || Instance.fileWriter == null || Instance.fileStream == null)
			{
				return;
			}
			using (ProfilerSampleJanitor.Begin("DebugEventLog.Write"))
			{
				lock (Instance.writeLock)
				{
					Instance.FlushBatchedTimeTicks();
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventLog.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Writing debug event ");
						messageBuilder.AppendFormatted(debugEvent);
					}
					Log.Trace(messageBuilder);
					Instance.fileWriter.Write(debugEvent.TypeId);
					debugEvent.WriteBytes(Instance.fileWriter);
				}
			}
		}

		public static ushort GetShortCreatureId(CreatureBase creature)
		{
			if (Instance == null)
			{
				return 0;
			}
			if (!Instance.creatureIdToShortId.TryGetValue(creature.UniqueId, out var value))
			{
				Write(new CreatureRegistered(creature));
				return Instance.creatureIdToShortId[creature.UniqueId];
			}
			return value;
		}

		public static void TickTime()
		{
			if (Instance != null && IsInitialized)
			{
				Instance.tempAdvancedTimeTicks++;
			}
		}

		public static void Write(CreatureRegistered creatureRegisteredEvent)
		{
			if (Instance == null || !IsInitialized)
			{
				return;
			}
			lock (Instance.writeLock)
			{
				Instance.FlushBatchedTimeTicks();
				creatureRegisteredEvent.CreatureShortId = Instance.nextShortCreatureId;
				Instance.nextShortCreatureId++;
				Instance.creatureIdToShortId[creatureRegisteredEvent.CreatureId] = creatureRegisteredEvent.CreatureShortId;
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventLog.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Writing debug event ");
					messageBuilder.AppendFormatted(creatureRegisteredEvent);
				}
				Log.Trace(messageBuilder);
				Instance.fileWriter.Write(creatureRegisteredEvent.TypeId);
				creatureRegisteredEvent.WriteBytes(Instance.fileWriter);
			}
		}

		public static void Initialize()
		{
			if (Instance == null || Instance.isInitialized)
			{
				return;
			}
			Log.Info("Initializing DebugEventLog...", "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventLog.cs");
			lock (Instance.writeLock)
			{
				Instance.OpenTempFileStream();
				Instance.isInitialized = true;
			}
		}

		public static void SampleCreatureState(CreatureBase creature)
		{
			if (Instance == null || !IsInitialized || creature == null || creature.HasDiedOrFainted || creature.HasDisposed)
			{
				return;
			}
			lock (Instance.writeLock)
			{
				int uniqueId = creature.UniqueId;
				Vec3Int rhs = creature.GetGridPosition();
				Goal goal = creature.GetGoapAgent()?.GetCurrentGoal();
				int goalNameHash = 0;
				float num = creature.GetStat(StatType.Health)?.Current ?? 0f;
				bool flag = creature is HumanoidInstance humanoidInstance && humanoidInstance.IsWorker() && humanoidInstance.WorkerBehaviour.IsDrafting;
				ChangedFields changedFields = ChangedFields.None;
				Vec3Int lhs;
				if (!Instance.previousCreatureState.TryGetValue(uniqueId, out var value))
				{
					value = new PreviousCreatureState
					{
						GridPosition = rhs,
						Goal = goal,
						Health = num,
						IsDrafted = flag
					};
					changedFields = ChangedFields.All;
					lhs = value.GridPosition;
				}
				else
				{
					if (value.GridPosition != rhs)
					{
						changedFields |= ChangedFields.Position;
					}
					if (value.Goal != goal && goal != null)
					{
						goalNameHash = goal.Id?.GetHashCode() ?? 0;
						changedFields |= ChangedFields.Goal;
					}
					if (value.Health != num)
					{
						changedFields |= ChangedFields.Health;
					}
					if (value.IsDrafted != flag)
					{
						changedFields |= ChangedFields.Drafted;
					}
					lhs = value.GridPosition;
					value.GridPosition = rhs;
					value.Goal = goal;
					value.Health = num;
					value.IsDrafted = flag;
				}
				Instance.previousCreatureState[uniqueId] = value;
				switch (changedFields)
				{
				case ChangedFields.None:
					return;
				case ChangedFields.Position:
					if (lhs != rhs && rhs.y == lhs.y)
					{
						int num2 = rhs.x - lhs.x;
						int num3 = rhs.z - lhs.z;
						if (Math.Abs(num2) <= 7 && Math.Abs(num3) <= 7)
						{
							Write(new CreatureXZPositionChanged8(GetShortCreatureId(creature), num2, num3));
							return;
						}
					}
					break;
				}
				Write(new CreatureChanged(creature, rhs, goalNameHash, num, flag, changedFields));
			}
		}

		public static void WriteGoapEvent(GoapAction actionOwner, GoapDebugEventCode eventCode)
		{
			if (actionOwner.Goal.AgentOwner is CreatureBase creature)
			{
				Write(new GoapDebugEvent(creature, eventCode));
			}
		}

		public static void FinalizeToFile(VillageSaveData saveData, string fileNamePrefix = null)
		{
			if (Instance == null || !IsInitialized || saveData == null)
			{
				return;
			}
			lock (Instance.writeLock)
			{
				string directoryName = Path.GetDirectoryName(GlobalSaveController.GetAbsoluteSaveFilename(saveData.FileName, saveData.FolderName));
				string text = saveData.FileName.Replace(".sav", ".gmevents");
				if (fileNamePrefix != null)
				{
					text = fileNamePrefix + text;
				}
				FinalizeToFile(Path.Combine(directoryName, text));
			}
		}

		public static void FinalizeToFile(string filePath)
		{
			if (Instance == null || !IsInitialized || Instance.fileStream == null)
			{
				return;
			}
			lock (Instance.writeLock)
			{
				Instance.FlushBatchedTimeTicks();
				bool isEnabled;
				try
				{
					string name = Instance.fileStream.Name;
					Instance.fileStream?.Dispose();
					if (File.Exists(name))
					{
						File.Copy(name, filePath, overwrite: true);
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventLog.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Debug events saved to '");
							messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(filePath));
							messageBuilder.AppendLiteral("'");
						}
						Log.Info(messageBuilder);
					}
					else
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(125, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventLog.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Failed to copy current gmevents to destination file path because the 'current' file doesn't exist at the expected location '");
							messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(name));
							messageBuilder2.AppendLiteral("'");
						}
						Log.Error(messageBuilder2);
					}
				}
				catch (Exception ex)
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(58, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventLog.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Failed to save debug event tracker to file '");
						messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(filePath));
						messageBuilder2.AppendLiteral("', exception: ");
						messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(ex.ToString()));
					}
					Log.Error(messageBuilder2);
				}
				finally
				{
					Instance.OpenTempFileStream();
				}
			}
		}

		public static (DebugEventsHeader header, List<IDebugEvent> events) Load(string filePath)
		{
			using FileStream fileStream = File.OpenRead(filePath);
			using BinaryReader binaryReader = new BinaryReader(fileStream);
			DebugEventsHeader item = DebugEventsHeader.ReadBytes(binaryReader);
			List<IDebugEvent> list = new List<IDebugEvent>();
			while (binaryReader.BaseStream.Position < fileStream.Length)
			{
				IDebugEvent debugEvent = DebugEventTypeId.CreateObject(binaryReader.ReadByte());
				debugEvent.ReadBytes(binaryReader);
				list.Add(debugEvent);
			}
			return (header: item, events: list);
		}

		public DebugEventLog()
		{
			Instance = this;
		}

		public void Dispose()
		{
			isInitialized = false;
			fileStream?.Dispose();
			fileStream = null;
			Reset();
			Instance = null;
		}

		private void Reset()
		{
			creatureIdToShortId.Clear();
			previousCreatureState.Clear();
			nextShortCreatureId = 0;
			tempAdvancedTimeTicks = 0;
		}

		private void FlushBatchedTimeTicks()
		{
			if (!IsInitialized || tempAdvancedTimeTicks == 0)
			{
				return;
			}
			if (tempAdvancedTimeTicks == 1)
			{
				Log.Trace("Writing TimeTick", "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventLog.cs");
				TimeTicked timeTicked = default(TimeTicked);
				Instance.fileWriter.Write(timeTicked.TypeId);
				timeTicked.WriteBytes(Instance.fileWriter);
			}
			else
			{
				TimeTickedBatched timeTickedBatched = new TimeTickedBatched
				{
					Ticks = tempAdvancedTimeTicks
				};
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventLog.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Writing TimeAdvanced ");
					messageBuilder.AppendFormatted(timeTickedBatched.Ticks);
				}
				Log.Trace(messageBuilder);
				Instance.fileWriter.Write(timeTickedBatched.TypeId);
				timeTickedBatched.WriteBytes(Instance.fileWriter);
			}
			tempAdvancedTimeTicks = 0;
		}

		private void OpenTempFileStream()
		{
			lock (writeLock)
			{
				Reset();
				fileStream?.Dispose();
				string path = Path.Combine(Application.persistentDataPath, "VillageSaves", "__current.gmevents");
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				Directory.CreateDirectory(Path.GetDirectoryName(path));
				fileStream = File.Create(path);
				fileWriter = new BinaryWriter(fileStream);
				VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
				new DebugEventsHeader
				{
					GameVersion = Application.version,
					TickIntervalMinutes = 1,
					StartTimeMinutes = currentVillageData.DateAndTime.MinutesTotal,
					MapSizeX = currentVillageData.MapSize.x,
					MapSizeY = currentVillageData.MapSize.y,
					MapSizeZ = currentVillageData.MapSize.z
				}.WriteBytes(fileWriter);
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventLog.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Opened file stream at new temp file path '");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
			}
		}
	}
}
