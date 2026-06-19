using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
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
	public struct FishingMiniGameStateCDGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint beginMiniGameTimer_startTick;

			public uint beginMiniGameTimer_targetTicks;

			public uint beginMiniGameTimer_stopTick;

			public uint miniGameOverTimer_startTick;

			public uint miniGameOverTimer_targetTicks;

			public uint miniGameOverTimer_stopTick;

			public uint fishStruggleTimer_startTick;

			public uint fishStruggleTimer_targetTicks;

			public uint fishStruggleTimer_stopTick;

			public int miniGameOutcome;

			public int fishStruggleIndex;

			public uint isInFishingMiniGame;

			public uint fishIsStruggling;

			public uint playerReeling;

			public uint prevPlayerReeling;

			public float struggleBlend;

			public float reelVolume;

			public float lineTension;

			public float struggleAudioFadeOutTime;

			public float fishPosition;

			public int fishLevel;
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
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<FishingMiniGameStateCD>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<FishingMiniGameStateCD>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<FishingMiniGameStateCD>(component), in GhostComponentSerializer.TypeCastReadonly<FishingMiniGameStateCD>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in FishingMiniGameStateCD component)
		{
			snapshot.beginMiniGameTimer_startTick = component.beginMiniGameTimer.startTick.SerializedData;
			snapshot.beginMiniGameTimer_targetTicks = component.beginMiniGameTimer.targetTicks;
			snapshot.beginMiniGameTimer_stopTick = component.beginMiniGameTimer.stopTick.SerializedData;
			snapshot.miniGameOverTimer_startTick = component.miniGameOverTimer.startTick.SerializedData;
			snapshot.miniGameOverTimer_targetTicks = component.miniGameOverTimer.targetTicks;
			snapshot.miniGameOverTimer_stopTick = component.miniGameOverTimer.stopTick.SerializedData;
			snapshot.fishStruggleTimer_startTick = component.fishStruggleTimer.startTick.SerializedData;
			snapshot.fishStruggleTimer_targetTicks = component.fishStruggleTimer.targetTicks;
			snapshot.fishStruggleTimer_stopTick = component.fishStruggleTimer.stopTick.SerializedData;
			snapshot.miniGameOutcome = (int)component.miniGameOutcome;
			snapshot.fishStruggleIndex = component.fishStruggleIndex;
			snapshot.isInFishingMiniGame = (component.isInFishingMiniGame ? 1u : 0u);
			snapshot.fishIsStruggling = (component.fishIsStruggling ? 1u : 0u);
			snapshot.playerReeling = (component.playerReeling ? 1u : 0u);
			snapshot.prevPlayerReeling = (component.prevPlayerReeling ? 1u : 0u);
			snapshot.struggleBlend = component.struggleBlend;
			snapshot.reelVolume = component.reelVolume;
			snapshot.lineTension = component.lineTension;
			snapshot.struggleAudioFadeOutTime = component.struggleAudioFadeOutTime;
			snapshot.fishPosition = component.fishPosition;
			snapshot.fishLevel = component.fishLevel;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref FishingMiniGameStateCD component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.beginMiniGameTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.beginMiniGameTimer_startTick
			};
			component.beginMiniGameTimer.targetTicks = snapshotBefore.beginMiniGameTimer_targetTicks;
			component.beginMiniGameTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.beginMiniGameTimer_stopTick
			};
			component.miniGameOverTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.miniGameOverTimer_startTick
			};
			component.miniGameOverTimer.targetTicks = snapshotBefore.miniGameOverTimer_targetTicks;
			component.miniGameOverTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.miniGameOverTimer_stopTick
			};
			component.fishStruggleTimer.startTick = new NetworkTick
			{
				SerializedData = snapshotBefore.fishStruggleTimer_startTick
			};
			component.fishStruggleTimer.targetTicks = snapshotBefore.fishStruggleTimer_targetTicks;
			component.fishStruggleTimer.stopTick = new NetworkTick
			{
				SerializedData = snapshotBefore.fishStruggleTimer_stopTick
			};
			component.miniGameOutcome = (MiniGameOutcome)snapshotBefore.miniGameOutcome;
			component.fishStruggleIndex = snapshotBefore.fishStruggleIndex;
			component.isInFishingMiniGame = snapshotBefore.isInFishingMiniGame != 0;
			component.fishIsStruggling = snapshotBefore.fishIsStruggling != 0;
			component.playerReeling = snapshotBefore.playerReeling != 0;
			component.prevPlayerReeling = snapshotBefore.prevPlayerReeling != 0;
			component.struggleBlend = snapshotBefore.struggleBlend;
			component.reelVolume = snapshotBefore.reelVolume;
			component.lineTension = snapshotBefore.lineTension;
			component.struggleAudioFadeOutTime = snapshotBefore.struggleAudioFadeOutTime;
			component.fishPosition = snapshotBefore.fishPosition;
			component.fishLevel = snapshotBefore.fishLevel;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref FishingMiniGameStateCD component, in FishingMiniGameStateCD backup)
		{
			component.beginMiniGameTimer.startTick = backup.beginMiniGameTimer.startTick;
			component.beginMiniGameTimer.targetTicks = backup.beginMiniGameTimer.targetTicks;
			component.beginMiniGameTimer.stopTick = backup.beginMiniGameTimer.stopTick;
			component.miniGameOverTimer.startTick = backup.miniGameOverTimer.startTick;
			component.miniGameOverTimer.targetTicks = backup.miniGameOverTimer.targetTicks;
			component.miniGameOverTimer.stopTick = backup.miniGameOverTimer.stopTick;
			component.fishStruggleTimer.startTick = backup.fishStruggleTimer.startTick;
			component.fishStruggleTimer.targetTicks = backup.fishStruggleTimer.targetTicks;
			component.fishStruggleTimer.stopTick = backup.fishStruggleTimer.stopTick;
			component.miniGameOutcome = backup.miniGameOutcome;
			component.fishStruggleIndex = backup.fishStruggleIndex;
			component.isInFishingMiniGame = backup.isInFishingMiniGame;
			component.fishIsStruggling = backup.fishIsStruggling;
			component.playerReeling = backup.playerReeling;
			component.prevPlayerReeling = backup.prevPlayerReeling;
			component.struggleBlend = backup.struggleBlend;
			component.reelVolume = backup.reelVolume;
			component.lineTension = backup.lineTension;
			component.struggleAudioFadeOutTime = backup.struggleAudioFadeOutTime;
			component.fishPosition = backup.fishPosition;
			component.fishLevel = backup.fishLevel;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.beginMiniGameTimer_startTick = (uint)predictor.PredictInt((int)snapshot.beginMiniGameTimer_startTick, (int)baseline1.beginMiniGameTimer_startTick, (int)baseline2.beginMiniGameTimer_startTick);
			snapshot.beginMiniGameTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.beginMiniGameTimer_targetTicks, (int)baseline1.beginMiniGameTimer_targetTicks, (int)baseline2.beginMiniGameTimer_targetTicks);
			snapshot.beginMiniGameTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.beginMiniGameTimer_stopTick, (int)baseline1.beginMiniGameTimer_stopTick, (int)baseline2.beginMiniGameTimer_stopTick);
			snapshot.miniGameOverTimer_startTick = (uint)predictor.PredictInt((int)snapshot.miniGameOverTimer_startTick, (int)baseline1.miniGameOverTimer_startTick, (int)baseline2.miniGameOverTimer_startTick);
			snapshot.miniGameOverTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.miniGameOverTimer_targetTicks, (int)baseline1.miniGameOverTimer_targetTicks, (int)baseline2.miniGameOverTimer_targetTicks);
			snapshot.miniGameOverTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.miniGameOverTimer_stopTick, (int)baseline1.miniGameOverTimer_stopTick, (int)baseline2.miniGameOverTimer_stopTick);
			snapshot.fishStruggleTimer_startTick = (uint)predictor.PredictInt((int)snapshot.fishStruggleTimer_startTick, (int)baseline1.fishStruggleTimer_startTick, (int)baseline2.fishStruggleTimer_startTick);
			snapshot.fishStruggleTimer_targetTicks = (uint)predictor.PredictInt((int)snapshot.fishStruggleTimer_targetTicks, (int)baseline1.fishStruggleTimer_targetTicks, (int)baseline2.fishStruggleTimer_targetTicks);
			snapshot.fishStruggleTimer_stopTick = (uint)predictor.PredictInt((int)snapshot.fishStruggleTimer_stopTick, (int)baseline1.fishStruggleTimer_stopTick, (int)baseline2.fishStruggleTimer_stopTick);
			snapshot.miniGameOutcome = predictor.PredictInt(snapshot.miniGameOutcome, baseline1.miniGameOutcome, baseline2.miniGameOutcome);
			snapshot.fishStruggleIndex = predictor.PredictInt(snapshot.fishStruggleIndex, baseline1.fishStruggleIndex, baseline2.fishStruggleIndex);
			snapshot.isInFishingMiniGame = (uint)predictor.PredictInt((int)snapshot.isInFishingMiniGame, (int)baseline1.isInFishingMiniGame, (int)baseline2.isInFishingMiniGame);
			snapshot.fishIsStruggling = (uint)predictor.PredictInt((int)snapshot.fishIsStruggling, (int)baseline1.fishIsStruggling, (int)baseline2.fishIsStruggling);
			snapshot.playerReeling = (uint)predictor.PredictInt((int)snapshot.playerReeling, (int)baseline1.playerReeling, (int)baseline2.playerReeling);
			snapshot.prevPlayerReeling = (uint)predictor.PredictInt((int)snapshot.prevPlayerReeling, (int)baseline1.prevPlayerReeling, (int)baseline2.prevPlayerReeling);
			snapshot.fishLevel = predictor.PredictInt(snapshot.fishLevel, baseline1.fishLevel, baseline2.fishLevel);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.beginMiniGameTimer_startTick != baseline.beginMiniGameTimer_startTick) ? 1u : 0u);
			num |= (uint)((snapshot.beginMiniGameTimer_targetTicks != baseline.beginMiniGameTimer_targetTicks) ? 2 : 0);
			num |= (uint)((snapshot.beginMiniGameTimer_stopTick != baseline.beginMiniGameTimer_stopTick) ? 4 : 0);
			num |= (uint)((snapshot.miniGameOverTimer_startTick != baseline.miniGameOverTimer_startTick) ? 8 : 0);
			num |= (uint)((snapshot.miniGameOverTimer_targetTicks != baseline.miniGameOverTimer_targetTicks) ? 16 : 0);
			num |= (uint)((snapshot.miniGameOverTimer_stopTick != baseline.miniGameOverTimer_stopTick) ? 32 : 0);
			num |= (uint)((snapshot.fishStruggleTimer_startTick != baseline.fishStruggleTimer_startTick) ? 64 : 0);
			num |= (uint)((snapshot.fishStruggleTimer_targetTicks != baseline.fishStruggleTimer_targetTicks) ? 128 : 0);
			num |= (uint)((snapshot.fishStruggleTimer_stopTick != baseline.fishStruggleTimer_stopTick) ? 256 : 0);
			num |= (uint)((snapshot.miniGameOutcome != baseline.miniGameOutcome) ? 512 : 0);
			num |= (uint)((snapshot.fishStruggleIndex != baseline.fishStruggleIndex) ? 1024 : 0);
			num |= (uint)((snapshot.isInFishingMiniGame != baseline.isInFishingMiniGame) ? 2048 : 0);
			num |= (uint)((snapshot.fishIsStruggling != baseline.fishIsStruggling) ? 4096 : 0);
			num |= (uint)((snapshot.playerReeling != baseline.playerReeling) ? 8192 : 0);
			num |= (uint)((snapshot.prevPlayerReeling != baseline.prevPlayerReeling) ? 16384 : 0);
			num |= (uint)((snapshot.struggleBlend != baseline.struggleBlend) ? 32768 : 0);
			num |= (uint)((snapshot.reelVolume != baseline.reelVolume) ? 65536 : 0);
			num |= (uint)((snapshot.lineTension != baseline.lineTension) ? 131072 : 0);
			num |= (uint)((snapshot.struggleAudioFadeOutTime != baseline.struggleAudioFadeOutTime) ? 262144 : 0);
			num |= (uint)((snapshot.fishPosition != baseline.fishPosition) ? 524288 : 0);
			num |= (uint)((snapshot.fishLevel != baseline.fishLevel) ? 1048576 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 21);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 21);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beginMiniGameTimer_startTick, baseline.beginMiniGameTimer_startTick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beginMiniGameTimer_targetTicks, baseline.beginMiniGameTimer_targetTicks, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beginMiniGameTimer_stopTick, baseline.beginMiniGameTimer_stopTick, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.miniGameOverTimer_startTick, baseline.miniGameOverTimer_startTick, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.miniGameOverTimer_targetTicks, baseline.miniGameOverTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.miniGameOverTimer_stopTick, baseline.miniGameOverTimer_stopTick, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishStruggleTimer_startTick, baseline.fishStruggleTimer_startTick, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishStruggleTimer_targetTicks, baseline.fishStruggleTimer_targetTicks, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishStruggleTimer_stopTick, baseline.fishStruggleTimer_stopTick, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.miniGameOutcome, baseline.miniGameOutcome, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.fishStruggleIndex, baseline.fishStruggleIndex, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isInFishingMiniGame, baseline.isInFishingMiniGame, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishIsStruggling, baseline.fishIsStruggling, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerReeling, baseline.playerReeling, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.prevPlayerReeling, baseline.prevPlayerReeling, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.struggleBlend, baseline.struggleBlend, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.reelVolume, baseline.reelVolume, in compressionModel);
			}
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.lineTension, baseline.lineTension, in compressionModel);
			}
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.struggleAudioFadeOutTime, baseline.struggleAudioFadeOutTime, in compressionModel);
			}
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.fishPosition, baseline.fishPosition, in compressionModel);
			}
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.fishLevel, baseline.fishLevel, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.beginMiniGameTimer_startTick != baseline.beginMiniGameTimer_startTick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beginMiniGameTimer_startTick, baseline.beginMiniGameTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.beginMiniGameTimer_targetTicks != baseline.beginMiniGameTimer_targetTicks) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beginMiniGameTimer_targetTicks, baseline.beginMiniGameTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.beginMiniGameTimer_stopTick != baseline.beginMiniGameTimer_stopTick) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.beginMiniGameTimer_stopTick, baseline.beginMiniGameTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.miniGameOverTimer_startTick != baseline.miniGameOverTimer_startTick) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.miniGameOverTimer_startTick, baseline.miniGameOverTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.miniGameOverTimer_targetTicks != baseline.miniGameOverTimer_targetTicks) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.miniGameOverTimer_targetTicks, baseline.miniGameOverTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.miniGameOverTimer_stopTick != baseline.miniGameOverTimer_stopTick) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.miniGameOverTimer_stopTick, baseline.miniGameOverTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.fishStruggleTimer_startTick != baseline.fishStruggleTimer_startTick) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishStruggleTimer_startTick, baseline.fishStruggleTimer_startTick, in compressionModel);
			}
			num |= (uint)((snapshot.fishStruggleTimer_targetTicks != baseline.fishStruggleTimer_targetTicks) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishStruggleTimer_targetTicks, baseline.fishStruggleTimer_targetTicks, in compressionModel);
			}
			num |= (uint)((snapshot.fishStruggleTimer_stopTick != baseline.fishStruggleTimer_stopTick) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishStruggleTimer_stopTick, baseline.fishStruggleTimer_stopTick, in compressionModel);
			}
			num |= (uint)((snapshot.miniGameOutcome != baseline.miniGameOutcome) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedIntDelta(snapshot.miniGameOutcome, baseline.miniGameOutcome, in compressionModel);
			}
			num |= (uint)((snapshot.fishStruggleIndex != baseline.fishStruggleIndex) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedIntDelta(snapshot.fishStruggleIndex, baseline.fishStruggleIndex, in compressionModel);
			}
			num |= (uint)((snapshot.isInFishingMiniGame != baseline.isInFishingMiniGame) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.isInFishingMiniGame, baseline.isInFishingMiniGame, in compressionModel);
			}
			num |= (uint)((snapshot.fishIsStruggling != baseline.fishIsStruggling) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.fishIsStruggling, baseline.fishIsStruggling, in compressionModel);
			}
			num |= (uint)((snapshot.playerReeling != baseline.playerReeling) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.playerReeling, baseline.playerReeling, in compressionModel);
			}
			num |= (uint)((snapshot.prevPlayerReeling != baseline.prevPlayerReeling) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.prevPlayerReeling, baseline.prevPlayerReeling, in compressionModel);
			}
			num |= (uint)((snapshot.struggleBlend != baseline.struggleBlend) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.struggleBlend, baseline.struggleBlend, in compressionModel);
			}
			num |= (uint)((snapshot.reelVolume != baseline.reelVolume) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.reelVolume, baseline.reelVolume, in compressionModel);
			}
			num |= (uint)((snapshot.lineTension != baseline.lineTension) ? 131072 : 0);
			if ((num & 0x20000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.lineTension, baseline.lineTension, in compressionModel);
			}
			num |= (uint)((snapshot.struggleAudioFadeOutTime != baseline.struggleAudioFadeOutTime) ? 262144 : 0);
			if ((num & 0x40000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.struggleAudioFadeOutTime, baseline.struggleAudioFadeOutTime, in compressionModel);
			}
			num |= (uint)((snapshot.fishPosition != baseline.fishPosition) ? 524288 : 0);
			if ((num & 0x80000) != 0)
			{
				writer.WritePackedFloatDelta(snapshot.fishPosition, baseline.fishPosition, in compressionModel);
			}
			num |= (uint)((snapshot.fishLevel != baseline.fishLevel) ? 1048576 : 0);
			if ((num & 0x100000) != 0)
			{
				writer.WritePackedIntDelta(snapshot.fishLevel, baseline.fishLevel, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 21);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 21);
			if ((num & 1) != 0)
			{
				snapshot.beginMiniGameTimer_startTick = reader.ReadPackedUIntDelta(baseline.beginMiniGameTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.beginMiniGameTimer_startTick = baseline.beginMiniGameTimer_startTick;
			}
			if ((num & 2) != 0)
			{
				snapshot.beginMiniGameTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.beginMiniGameTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.beginMiniGameTimer_targetTicks = baseline.beginMiniGameTimer_targetTicks;
			}
			if ((num & 4) != 0)
			{
				snapshot.beginMiniGameTimer_stopTick = reader.ReadPackedUIntDelta(baseline.beginMiniGameTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.beginMiniGameTimer_stopTick = baseline.beginMiniGameTimer_stopTick;
			}
			if ((num & 8) != 0)
			{
				snapshot.miniGameOverTimer_startTick = reader.ReadPackedUIntDelta(baseline.miniGameOverTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.miniGameOverTimer_startTick = baseline.miniGameOverTimer_startTick;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.miniGameOverTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.miniGameOverTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.miniGameOverTimer_targetTicks = baseline.miniGameOverTimer_targetTicks;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.miniGameOverTimer_stopTick = reader.ReadPackedUIntDelta(baseline.miniGameOverTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.miniGameOverTimer_stopTick = baseline.miniGameOverTimer_stopTick;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.fishStruggleTimer_startTick = reader.ReadPackedUIntDelta(baseline.fishStruggleTimer_startTick, in compressionModel);
			}
			else
			{
				snapshot.fishStruggleTimer_startTick = baseline.fishStruggleTimer_startTick;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.fishStruggleTimer_targetTicks = reader.ReadPackedUIntDelta(baseline.fishStruggleTimer_targetTicks, in compressionModel);
			}
			else
			{
				snapshot.fishStruggleTimer_targetTicks = baseline.fishStruggleTimer_targetTicks;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.fishStruggleTimer_stopTick = reader.ReadPackedUIntDelta(baseline.fishStruggleTimer_stopTick, in compressionModel);
			}
			else
			{
				snapshot.fishStruggleTimer_stopTick = baseline.fishStruggleTimer_stopTick;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.miniGameOutcome = reader.ReadPackedIntDelta(baseline.miniGameOutcome, in compressionModel);
			}
			else
			{
				snapshot.miniGameOutcome = baseline.miniGameOutcome;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.fishStruggleIndex = reader.ReadPackedIntDelta(baseline.fishStruggleIndex, in compressionModel);
			}
			else
			{
				snapshot.fishStruggleIndex = baseline.fishStruggleIndex;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.isInFishingMiniGame = reader.ReadPackedUIntDelta(baseline.isInFishingMiniGame, in compressionModel);
			}
			else
			{
				snapshot.isInFishingMiniGame = baseline.isInFishingMiniGame;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.fishIsStruggling = reader.ReadPackedUIntDelta(baseline.fishIsStruggling, in compressionModel);
			}
			else
			{
				snapshot.fishIsStruggling = baseline.fishIsStruggling;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.playerReeling = reader.ReadPackedUIntDelta(baseline.playerReeling, in compressionModel);
			}
			else
			{
				snapshot.playerReeling = baseline.playerReeling;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.prevPlayerReeling = reader.ReadPackedUIntDelta(baseline.prevPlayerReeling, in compressionModel);
			}
			else
			{
				snapshot.prevPlayerReeling = baseline.prevPlayerReeling;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.struggleBlend = reader.ReadPackedFloatDelta(baseline.struggleBlend, in compressionModel);
			}
			else
			{
				snapshot.struggleBlend = baseline.struggleBlend;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.reelVolume = reader.ReadPackedFloatDelta(baseline.reelVolume, in compressionModel);
			}
			else
			{
				snapshot.reelVolume = baseline.reelVolume;
			}
			if ((num & 0x20000) != 0)
			{
				snapshot.lineTension = reader.ReadPackedFloatDelta(baseline.lineTension, in compressionModel);
			}
			else
			{
				snapshot.lineTension = baseline.lineTension;
			}
			if ((num & 0x40000) != 0)
			{
				snapshot.struggleAudioFadeOutTime = reader.ReadPackedFloatDelta(baseline.struggleAudioFadeOutTime, in compressionModel);
			}
			else
			{
				snapshot.struggleAudioFadeOutTime = baseline.struggleAudioFadeOutTime;
			}
			if ((num & 0x80000) != 0)
			{
				snapshot.fishPosition = reader.ReadPackedFloatDelta(baseline.fishPosition, in compressionModel);
			}
			else
			{
				snapshot.fishPosition = baseline.fishPosition;
			}
			if ((num & 0x100000) != 0)
			{
				snapshot.fishLevel = reader.ReadPackedIntDelta(baseline.fishLevel, in compressionModel);
			}
			else
			{
				snapshot.fishLevel = baseline.fishLevel;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 7377599826395273518uL,
					ComponentType = ComponentType.ReadWrite<FishingMiniGameStateCD>(),
					ComponentSize = UnsafeUtility.SizeOf<FishingMiniGameStateCD>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 21,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.All,
					VariantHash = 14442990905461324762uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<FishingMiniGameStateCD, Snapshot, FishingMiniGameStateCDGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
