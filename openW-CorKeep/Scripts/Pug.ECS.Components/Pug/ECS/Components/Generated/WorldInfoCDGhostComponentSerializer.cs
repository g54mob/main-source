using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.NetCode;
using Unity.NetCode.LowLevel.Unsafe;

namespace Pug.ECS.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct WorldInfoCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint greatWallHasBeenLowered;

			public uint slimeMerchantExists;

			public uint coreIsActivated;

			public uint guestMode;

			public uint simulationDisabled;

			public uint coreBossHasBeenKilled;

			public uint wallBossHasBeenKilled;

			public uint birdBossBeenKilled;

			public uint octopusBossHasBeenKilled;

			public uint scarabHasBeenKilled;

			public uint hydraBossNatureHasBeenKilled;

			public uint hydraBossSeaHasBeenKilled;

			public uint hydraBossDesertHasBeenKilled;

			public uint giantCicadaBossHasBeenKilled;

			public uint robotBossHasBeenKilled;

			public int bossesKilled;

			public int numberPlayers;

			public int worldModeMask;

			public uint pvpEnabled;

			public uint hostConsoleEnabled;

			public uint consoleCommandUsedThisSession;
		}

		private const int ChangeMaskBits = 21;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 21;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<WorldInfoCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<WorldInfoCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CalculateChangeMask([NoAlias][ReadOnly] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			CalculateChangeMaskGenerated(in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshot), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline), changeMaskData, startOffset);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void PredictDelta([NoAlias] IntPtr snapshotData, [NoAlias] IntPtr baseline1Data, [NoAlias] IntPtr baseline2Data, ref GhostDeltaPredictor predictor)
		{
			PredictDeltaGenerated(ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotData), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline1Data), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline2Data), ref predictor);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SerializeWithPredictedBaseline([ReadOnly][NoAlias] IntPtr snapshot, [ReadOnly][NoAlias] IntPtr baseline0, [ReadOnly][NoAlias] IntPtr baseline1, [ReadOnly][NoAlias] IntPtr baseline2, ref GhostDeltaPredictor predictor, [NoAlias][ReadOnly] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			Snapshot snapshot2 = GhostComponentSerializer.TypeCast<Snapshot>(baseline0);
			PredictDeltaGenerated(ref snapshot2, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline1), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline2), ref predictor);
			SerializeCombinedGenerated(in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshot), in snapshot2, changeMaskData, startOffset, ref writer, in compressionModel);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SerializeCombined([ReadOnly][NoAlias] IntPtr snapshot, [ReadOnly][NoAlias] IntPtr baseline, [NoAlias][ReadOnly] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			SerializeCombinedGenerated(in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshot), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline), changeMaskData, startOffset, ref writer, in compressionModel);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Serialize([ReadOnly][NoAlias] IntPtr snapshot, [ReadOnly][NoAlias] IntPtr baseline, [NoAlias][ReadOnly] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			SerializeGenerated(in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshot), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline), changeMaskData, startOffset, ref writer, in compressionModel);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Deserialize(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMask, int startOffset, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr baseline)
		{
			DeserializeGenerated(ref reader, in compressionModel, changeMask, startOffset, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(baseline));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RestoreFromBackup([NoAlias] IntPtr component, [NoAlias][ReadOnly] IntPtr backup)
		{
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<WorldInfoCD>(component), in GhostComponentSerializer.TypeCastReadonly<WorldInfoCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in WorldInfoCD component)
		{
			snapshot.greatWallHasBeenLowered = (component.greatWallHasBeenLowered ? 1u : 0u);
			snapshot.slimeMerchantExists = (component.slimeMerchantExists ? 1u : 0u);
			snapshot.coreIsActivated = (component.coreIsActivated ? 1u : 0u);
			snapshot.guestMode = (component.guestMode ? 1u : 0u);
			snapshot.simulationDisabled = (component.simulationDisabled ? 1u : 0u);
			snapshot.coreBossHasBeenKilled = (component.coreBossHasBeenKilled ? 1u : 0u);
			snapshot.wallBossHasBeenKilled = (component.wallBossHasBeenKilled ? 1u : 0u);
			snapshot.birdBossBeenKilled = (component.birdBossBeenKilled ? 1u : 0u);
			snapshot.octopusBossHasBeenKilled = (component.octopusBossHasBeenKilled ? 1u : 0u);
			snapshot.scarabHasBeenKilled = (component.scarabHasBeenKilled ? 1u : 0u);
			snapshot.hydraBossNatureHasBeenKilled = (component.hydraBossNatureHasBeenKilled ? 1u : 0u);
			snapshot.hydraBossSeaHasBeenKilled = (component.hydraBossSeaHasBeenKilled ? 1u : 0u);
			snapshot.hydraBossDesertHasBeenKilled = (component.hydraBossDesertHasBeenKilled ? 1u : 0u);
			snapshot.giantCicadaBossHasBeenKilled = (component.giantCicadaBossHasBeenKilled ? 1u : 0u);
			snapshot.robotBossHasBeenKilled = (component.robotBossHasBeenKilled ? 1u : 0u);
			snapshot.bossesKilled = component.bossesKilled;
			snapshot.numberPlayers = component.numberPlayers;
			snapshot.worldModeMask = (int)component.worldModeMask;
			snapshot.pvpEnabled = (component.pvpEnabled ? 1u : 0u);
			snapshot.hostConsoleEnabled = (component.hostConsoleEnabled ? 1u : 0u);
			snapshot.consoleCommandUsedThisSession = (component.consoleCommandUsedThisSession ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref WorldInfoCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.greatWallHasBeenLowered = snapshotBefore.greatWallHasBeenLowered != 0;
			component.slimeMerchantExists = snapshotBefore.slimeMerchantExists != 0;
			component.coreIsActivated = snapshotBefore.coreIsActivated != 0;
			component.guestMode = snapshotBefore.guestMode != 0;
			component.simulationDisabled = snapshotBefore.simulationDisabled != 0;
			component.coreBossHasBeenKilled = snapshotBefore.coreBossHasBeenKilled != 0;
			component.wallBossHasBeenKilled = snapshotBefore.wallBossHasBeenKilled != 0;
			component.birdBossBeenKilled = snapshotBefore.birdBossBeenKilled != 0;
			component.octopusBossHasBeenKilled = snapshotBefore.octopusBossHasBeenKilled != 0;
			component.scarabHasBeenKilled = snapshotBefore.scarabHasBeenKilled != 0;
			component.hydraBossNatureHasBeenKilled = snapshotBefore.hydraBossNatureHasBeenKilled != 0;
			component.hydraBossSeaHasBeenKilled = snapshotBefore.hydraBossSeaHasBeenKilled != 0;
			component.hydraBossDesertHasBeenKilled = snapshotBefore.hydraBossDesertHasBeenKilled != 0;
			component.giantCicadaBossHasBeenKilled = snapshotBefore.giantCicadaBossHasBeenKilled != 0;
			component.robotBossHasBeenKilled = snapshotBefore.robotBossHasBeenKilled != 0;
			component.bossesKilled = snapshotBefore.bossesKilled;
			component.numberPlayers = snapshotBefore.numberPlayers;
			component.worldModeMask = (WorldMode)snapshotBefore.worldModeMask;
			component.pvpEnabled = snapshotBefore.pvpEnabled != 0;
			component.hostConsoleEnabled = snapshotBefore.hostConsoleEnabled != 0;
			component.consoleCommandUsedThisSession = snapshotBefore.consoleCommandUsedThisSession != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref WorldInfoCD component, in WorldInfoCD backup)
		{
			component.greatWallHasBeenLowered = backup.greatWallHasBeenLowered;
			component.slimeMerchantExists = backup.slimeMerchantExists;
			component.coreIsActivated = backup.coreIsActivated;
			component.guestMode = backup.guestMode;
			component.simulationDisabled = backup.simulationDisabled;
			component.coreBossHasBeenKilled = backup.coreBossHasBeenKilled;
			component.wallBossHasBeenKilled = backup.wallBossHasBeenKilled;
			component.birdBossBeenKilled = backup.birdBossBeenKilled;
			component.octopusBossHasBeenKilled = backup.octopusBossHasBeenKilled;
			component.scarabHasBeenKilled = backup.scarabHasBeenKilled;
			component.hydraBossNatureHasBeenKilled = backup.hydraBossNatureHasBeenKilled;
			component.hydraBossSeaHasBeenKilled = backup.hydraBossSeaHasBeenKilled;
			component.hydraBossDesertHasBeenKilled = backup.hydraBossDesertHasBeenKilled;
			component.giantCicadaBossHasBeenKilled = backup.giantCicadaBossHasBeenKilled;
			component.robotBossHasBeenKilled = backup.robotBossHasBeenKilled;
			component.bossesKilled = backup.bossesKilled;
			component.numberPlayers = backup.numberPlayers;
			component.worldModeMask = backup.worldModeMask;
			component.pvpEnabled = backup.pvpEnabled;
			component.hostConsoleEnabled = backup.hostConsoleEnabled;
			component.consoleCommandUsedThisSession = backup.consoleCommandUsedThisSession;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.greatWallHasBeenLowered = (uint)predictor.PredictInt((int)snapshot.greatWallHasBeenLowered, (int)baseline1.greatWallHasBeenLowered, (int)baseline2.greatWallHasBeenLowered);
			snapshot.slimeMerchantExists = (uint)predictor.PredictInt((int)snapshot.slimeMerchantExists, (int)baseline1.slimeMerchantExists, (int)baseline2.slimeMerchantExists);
			snapshot.coreIsActivated = (uint)predictor.PredictInt((int)snapshot.coreIsActivated, (int)baseline1.coreIsActivated, (int)baseline2.coreIsActivated);
			snapshot.guestMode = (uint)predictor.PredictInt((int)snapshot.guestMode, (int)baseline1.guestMode, (int)baseline2.guestMode);
			snapshot.simulationDisabled = (uint)predictor.PredictInt((int)snapshot.simulationDisabled, (int)baseline1.simulationDisabled, (int)baseline2.simulationDisabled);
			snapshot.coreBossHasBeenKilled = (uint)predictor.PredictInt((int)snapshot.coreBossHasBeenKilled, (int)baseline1.coreBossHasBeenKilled, (int)baseline2.coreBossHasBeenKilled);
			snapshot.wallBossHasBeenKilled = (uint)predictor.PredictInt((int)snapshot.wallBossHasBeenKilled, (int)baseline1.wallBossHasBeenKilled, (int)baseline2.wallBossHasBeenKilled);
			snapshot.birdBossBeenKilled = (uint)predictor.PredictInt((int)snapshot.birdBossBeenKilled, (int)baseline1.birdBossBeenKilled, (int)baseline2.birdBossBeenKilled);
			snapshot.octopusBossHasBeenKilled = (uint)predictor.PredictInt((int)snapshot.octopusBossHasBeenKilled, (int)baseline1.octopusBossHasBeenKilled, (int)baseline2.octopusBossHasBeenKilled);
			snapshot.scarabHasBeenKilled = (uint)predictor.PredictInt((int)snapshot.scarabHasBeenKilled, (int)baseline1.scarabHasBeenKilled, (int)baseline2.scarabHasBeenKilled);
			snapshot.hydraBossNatureHasBeenKilled = (uint)predictor.PredictInt((int)snapshot.hydraBossNatureHasBeenKilled, (int)baseline1.hydraBossNatureHasBeenKilled, (int)baseline2.hydraBossNatureHasBeenKilled);
			snapshot.hydraBossSeaHasBeenKilled = (uint)predictor.PredictInt((int)snapshot.hydraBossSeaHasBeenKilled, (int)baseline1.hydraBossSeaHasBeenKilled, (int)baseline2.hydraBossSeaHasBeenKilled);
			snapshot.hydraBossDesertHasBeenKilled = (uint)predictor.PredictInt((int)snapshot.hydraBossDesertHasBeenKilled, (int)baseline1.hydraBossDesertHasBeenKilled, (int)baseline2.hydraBossDesertHasBeenKilled);
			snapshot.giantCicadaBossHasBeenKilled = (uint)predictor.PredictInt((int)snapshot.giantCicadaBossHasBeenKilled, (int)baseline1.giantCicadaBossHasBeenKilled, (int)baseline2.giantCicadaBossHasBeenKilled);
			snapshot.robotBossHasBeenKilled = (uint)predictor.PredictInt((int)snapshot.robotBossHasBeenKilled, (int)baseline1.robotBossHasBeenKilled, (int)baseline2.robotBossHasBeenKilled);
			snapshot.bossesKilled = predictor.PredictInt(snapshot.bossesKilled, baseline1.bossesKilled, baseline2.bossesKilled);
			snapshot.numberPlayers = predictor.PredictInt(snapshot.numberPlayers, baseline1.numberPlayers, baseline2.numberPlayers);
			snapshot.worldModeMask = predictor.PredictInt(snapshot.worldModeMask, baseline1.worldModeMask, baseline2.worldModeMask);
			snapshot.pvpEnabled = (uint)predictor.PredictInt((int)snapshot.pvpEnabled, (int)baseline1.pvpEnabled, (int)baseline2.pvpEnabled);
			snapshot.hostConsoleEnabled = (uint)predictor.PredictInt((int)snapshot.hostConsoleEnabled, (int)baseline1.hostConsoleEnabled, (int)baseline2.hostConsoleEnabled);
			snapshot.consoleCommandUsedThisSession = (uint)predictor.PredictInt((int)snapshot.consoleCommandUsedThisSession, (int)baseline1.consoleCommandUsedThisSession, (int)baseline2.consoleCommandUsedThisSession);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.greatWallHasBeenLowered != baseline.greatWallHasBeenLowered) ? 1u : 0u);
			num |= (uint)((snapshot.slimeMerchantExists != baseline.slimeMerchantExists) ? 2 : 0);
			num |= (uint)((snapshot.coreIsActivated != baseline.coreIsActivated) ? 4 : 0);
			num |= (uint)((snapshot.guestMode != baseline.guestMode) ? 8 : 0);
			num |= (uint)((snapshot.simulationDisabled != baseline.simulationDisabled) ? 16 : 0);
			num |= (uint)((snapshot.coreBossHasBeenKilled != baseline.coreBossHasBeenKilled) ? 32 : 0);
			num |= (uint)((snapshot.wallBossHasBeenKilled != baseline.wallBossHasBeenKilled) ? 64 : 0);
			num |= (uint)((snapshot.birdBossBeenKilled != baseline.birdBossBeenKilled) ? 128 : 0);
			num |= (uint)((snapshot.octopusBossHasBeenKilled != baseline.octopusBossHasBeenKilled) ? 256 : 0);
			num |= (uint)((snapshot.scarabHasBeenKilled != baseline.scarabHasBeenKilled) ? 512 : 0);
			num |= (uint)((snapshot.hydraBossNatureHasBeenKilled != baseline.hydraBossNatureHasBeenKilled) ? 1024 : 0);
			num |= (uint)((snapshot.hydraBossSeaHasBeenKilled != baseline.hydraBossSeaHasBeenKilled) ? 2048 : 0);
			num |= (uint)((snapshot.hydraBossDesertHasBeenKilled != baseline.hydraBossDesertHasBeenKilled) ? 4096 : 0);
			num |= (uint)((snapshot.giantCicadaBossHasBeenKilled != baseline.giantCicadaBossHasBeenKilled) ? 8192 : 0);
			num |= (uint)((snapshot.robotBossHasBeenKilled != baseline.robotBossHasBeenKilled) ? 16384 : 0);
			num |= (uint)((snapshot.bossesKilled != baseline.bossesKilled) ? 32768 : 0);
			num |= (uint)((snapshot.numberPlayers != baseline.numberPlayers) ? 65536 : 0);
			num |= (uint)((snapshot.worldModeMask != baseline.worldModeMask) ? 131072 : 0);
			num |= (uint)((snapshot.pvpEnabled != baseline.pvpEnabled) ? 262144 : 0);
			num |= (uint)((snapshot.hostConsoleEnabled != baseline.hostConsoleEnabled) ? 524288 : 0);
			num |= (uint)((snapshot.consoleCommandUsedThisSession != baseline.consoleCommandUsedThisSession) ? 1048576 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 21);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 21);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.greatWallHasBeenLowered, baseline.greatWallHasBeenLowered, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.slimeMerchantExists, baseline.slimeMerchantExists, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.coreIsActivated, baseline.coreIsActivated, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.guestMode, baseline.guestMode, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.simulationDisabled, baseline.simulationDisabled, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.coreBossHasBeenKilled, baseline.coreBossHasBeenKilled, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.wallBossHasBeenKilled, baseline.wallBossHasBeenKilled, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.birdBossBeenKilled, baseline.birdBossBeenKilled, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.octopusBossHasBeenKilled, baseline.octopusBossHasBeenKilled, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.scarabHasBeenKilled, baseline.scarabHasBeenKilled, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hydraBossNatureHasBeenKilled, baseline.hydraBossNatureHasBeenKilled, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hydraBossSeaHasBeenKilled, baseline.hydraBossSeaHasBeenKilled, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hydraBossDesertHasBeenKilled, baseline.hydraBossDesertHasBeenKilled, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.giantCicadaBossHasBeenKilled, baseline.giantCicadaBossHasBeenKilled, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.robotBossHasBeenKilled, baseline.robotBossHasBeenKilled, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bossesKilled, baseline.bossesKilled, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.numberPlayers, baseline.numberPlayers, in compressionModel);
			}
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.worldModeMask, baseline.worldModeMask, in compressionModel);
			}
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pvpEnabled, baseline.pvpEnabled, in compressionModel);
			}
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hostConsoleEnabled, baseline.hostConsoleEnabled, in compressionModel);
			}
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.consoleCommandUsedThisSession, baseline.consoleCommandUsedThisSession, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.greatWallHasBeenLowered != baseline.greatWallHasBeenLowered) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.greatWallHasBeenLowered, baseline.greatWallHasBeenLowered, in compressionModel);
			}
			num |= (uint)((snapshot.slimeMerchantExists != baseline.slimeMerchantExists) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.slimeMerchantExists, baseline.slimeMerchantExists, in compressionModel);
			}
			num |= (uint)((snapshot.coreIsActivated != baseline.coreIsActivated) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.coreIsActivated, baseline.coreIsActivated, in compressionModel);
			}
			num |= (uint)((snapshot.guestMode != baseline.guestMode) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.guestMode, baseline.guestMode, in compressionModel);
			}
			num |= (uint)((snapshot.simulationDisabled != baseline.simulationDisabled) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.simulationDisabled, baseline.simulationDisabled, in compressionModel);
			}
			num |= (uint)((snapshot.coreBossHasBeenKilled != baseline.coreBossHasBeenKilled) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.coreBossHasBeenKilled, baseline.coreBossHasBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.wallBossHasBeenKilled != baseline.wallBossHasBeenKilled) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.wallBossHasBeenKilled, baseline.wallBossHasBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.birdBossBeenKilled != baseline.birdBossBeenKilled) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.birdBossBeenKilled, baseline.birdBossBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.octopusBossHasBeenKilled != baseline.octopusBossHasBeenKilled) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.octopusBossHasBeenKilled, baseline.octopusBossHasBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.scarabHasBeenKilled != baseline.scarabHasBeenKilled) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.scarabHasBeenKilled, baseline.scarabHasBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.hydraBossNatureHasBeenKilled != baseline.hydraBossNatureHasBeenKilled) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hydraBossNatureHasBeenKilled, baseline.hydraBossNatureHasBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.hydraBossSeaHasBeenKilled != baseline.hydraBossSeaHasBeenKilled) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hydraBossSeaHasBeenKilled, baseline.hydraBossSeaHasBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.hydraBossDesertHasBeenKilled != baseline.hydraBossDesertHasBeenKilled) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hydraBossDesertHasBeenKilled, baseline.hydraBossDesertHasBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.giantCicadaBossHasBeenKilled != baseline.giantCicadaBossHasBeenKilled) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.giantCicadaBossHasBeenKilled, baseline.giantCicadaBossHasBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.robotBossHasBeenKilled != baseline.robotBossHasBeenKilled) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.robotBossHasBeenKilled, baseline.robotBossHasBeenKilled, in compressionModel);
			}
			num |= (uint)((snapshot.bossesKilled != baseline.bossesKilled) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.bossesKilled, baseline.bossesKilled, in compressionModel);
			}
			num |= (uint)((snapshot.numberPlayers != baseline.numberPlayers) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.numberPlayers, baseline.numberPlayers, in compressionModel);
			}
			num |= (uint)((snapshot.worldModeMask != baseline.worldModeMask) ? 131072 : 0);
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.worldModeMask, baseline.worldModeMask, in compressionModel);
			}
			num |= (uint)((snapshot.pvpEnabled != baseline.pvpEnabled) ? 262144 : 0);
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.pvpEnabled, baseline.pvpEnabled, in compressionModel);
			}
			num |= (uint)((snapshot.hostConsoleEnabled != baseline.hostConsoleEnabled) ? 524288 : 0);
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.hostConsoleEnabled, baseline.hostConsoleEnabled, in compressionModel);
			}
			num |= (uint)((snapshot.consoleCommandUsedThisSession != baseline.consoleCommandUsedThisSession) ? 1048576 : 0);
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.consoleCommandUsedThisSession, baseline.consoleCommandUsedThisSession, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 21);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 21);
			if ((num & 1) != 0)
			{
				snapshot.greatWallHasBeenLowered = reader.ReadPackedUIntDelta(baseline.greatWallHasBeenLowered, in compressionModel);
			}
			else
			{
				snapshot.greatWallHasBeenLowered = baseline.greatWallHasBeenLowered;
			}
			if ((num & 2) != 0)
			{
				snapshot.slimeMerchantExists = reader.ReadPackedUIntDelta(baseline.slimeMerchantExists, in compressionModel);
			}
			else
			{
				snapshot.slimeMerchantExists = baseline.slimeMerchantExists;
			}
			if ((num & 4) != 0)
			{
				snapshot.coreIsActivated = reader.ReadPackedUIntDelta(baseline.coreIsActivated, in compressionModel);
			}
			else
			{
				snapshot.coreIsActivated = baseline.coreIsActivated;
			}
			if ((num & 8) != 0)
			{
				snapshot.guestMode = reader.ReadPackedUIntDelta(baseline.guestMode, in compressionModel);
			}
			else
			{
				snapshot.guestMode = baseline.guestMode;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.simulationDisabled = reader.ReadPackedUIntDelta(baseline.simulationDisabled, in compressionModel);
			}
			else
			{
				snapshot.simulationDisabled = baseline.simulationDisabled;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.coreBossHasBeenKilled = reader.ReadPackedUIntDelta(baseline.coreBossHasBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.coreBossHasBeenKilled = baseline.coreBossHasBeenKilled;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.wallBossHasBeenKilled = reader.ReadPackedUIntDelta(baseline.wallBossHasBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.wallBossHasBeenKilled = baseline.wallBossHasBeenKilled;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.birdBossBeenKilled = reader.ReadPackedUIntDelta(baseline.birdBossBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.birdBossBeenKilled = baseline.birdBossBeenKilled;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.octopusBossHasBeenKilled = reader.ReadPackedUIntDelta(baseline.octopusBossHasBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.octopusBossHasBeenKilled = baseline.octopusBossHasBeenKilled;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.scarabHasBeenKilled = reader.ReadPackedUIntDelta(baseline.scarabHasBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.scarabHasBeenKilled = baseline.scarabHasBeenKilled;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.hydraBossNatureHasBeenKilled = reader.ReadPackedUIntDelta(baseline.hydraBossNatureHasBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.hydraBossNatureHasBeenKilled = baseline.hydraBossNatureHasBeenKilled;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.hydraBossSeaHasBeenKilled = reader.ReadPackedUIntDelta(baseline.hydraBossSeaHasBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.hydraBossSeaHasBeenKilled = baseline.hydraBossSeaHasBeenKilled;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.hydraBossDesertHasBeenKilled = reader.ReadPackedUIntDelta(baseline.hydraBossDesertHasBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.hydraBossDesertHasBeenKilled = baseline.hydraBossDesertHasBeenKilled;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.giantCicadaBossHasBeenKilled = reader.ReadPackedUIntDelta(baseline.giantCicadaBossHasBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.giantCicadaBossHasBeenKilled = baseline.giantCicadaBossHasBeenKilled;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.robotBossHasBeenKilled = reader.ReadPackedUIntDelta(baseline.robotBossHasBeenKilled, in compressionModel);
			}
			else
			{
				snapshot.robotBossHasBeenKilled = baseline.robotBossHasBeenKilled;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.bossesKilled = reader.ReadPackedIntDelta(baseline.bossesKilled, in compressionModel);
			}
			else
			{
				snapshot.bossesKilled = baseline.bossesKilled;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.numberPlayers = reader.ReadPackedIntDelta(baseline.numberPlayers, in compressionModel);
			}
			else
			{
				snapshot.numberPlayers = baseline.numberPlayers;
			}
			if ((num & 0x20000) != 0)
			{
				snapshot.worldModeMask = reader.ReadPackedIntDelta(baseline.worldModeMask, in compressionModel);
			}
			else
			{
				snapshot.worldModeMask = baseline.worldModeMask;
			}
			if ((num & 0x40000) != 0)
			{
				snapshot.pvpEnabled = reader.ReadPackedUIntDelta(baseline.pvpEnabled, in compressionModel);
			}
			else
			{
				snapshot.pvpEnabled = baseline.pvpEnabled;
			}
			if ((num & 0x80000) != 0)
			{
				snapshot.hostConsoleEnabled = reader.ReadPackedUIntDelta(baseline.hostConsoleEnabled, in compressionModel);
			}
			else
			{
				snapshot.hostConsoleEnabled = baseline.hostConsoleEnabled;
			}
			if ((num & 0x100000) != 0)
			{
				snapshot.consoleCommandUsedThisSession = reader.ReadPackedUIntDelta(baseline.consoleCommandUsedThisSession, in compressionModel);
			}
			else
			{
				snapshot.consoleCommandUsedThisSession = baseline.consoleCommandUsedThisSession;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 7377599826395273518uL,
					ComponentType = ComponentType.ReadWrite<WorldInfoCD>(),
					ComponentSize = UnsafeUtility.SizeOf<WorldInfoCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 21,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 1349408334882915226uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<WorldInfoCD, Snapshot, WorldInfoCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
			}
			return s_State;
		}

		void IGhostSerializer.CopyToSnapshot(in GhostSerializerState serializerState, IntPtr snapshot, IntPtr component)
		{
			CopyToSnapshot(in serializerState, snapshot, component);
		}

		void IGhostSerializer.CopyFromSnapshot(in GhostDeserializerState serializerState, IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, IntPtr snapshotBefore, IntPtr snapshotAfter)
		{
			CopyFromSnapshot(in serializerState, component, snapshotInterpolationFactor, snapshotInterpolationFactorRaw, snapshotBefore, snapshotAfter);
		}

		void IGhostSerializer.SerializeCombined(IntPtr snapshot, IntPtr baseline, IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			SerializeCombined(snapshot, baseline, changeMaskData, startOffset, ref writer, in compressionModel);
		}

		void IGhostSerializer.SerializeWithPredictedBaseline(IntPtr snapshot, IntPtr baseline0, IntPtr baseline1, IntPtr baseline2, ref GhostDeltaPredictor predictor, IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			SerializeWithPredictedBaseline(snapshot, baseline0, baseline1, baseline2, ref predictor, changeMaskData, startOffset, ref writer, in compressionModel);
		}

		void IGhostSerializer.Serialize(IntPtr snapshot, IntPtr baseline, IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			Serialize(snapshot, baseline, changeMaskData, startOffset, ref writer, in compressionModel);
		}

		void IGhostSerializer.Deserialize(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMask, int startOffset, IntPtr snapshot, IntPtr baseline)
		{
			Deserialize(ref reader, in compressionModel, changeMask, startOffset, snapshot, baseline);
		}
	}
}
