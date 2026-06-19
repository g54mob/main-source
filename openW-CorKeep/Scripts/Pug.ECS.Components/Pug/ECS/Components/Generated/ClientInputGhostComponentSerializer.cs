using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.NetCode.LowLevel.Unsafe;

namespace Pug.ECS.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct ClientInputGhostComponentSerializer : IGhostSerializer
	{
		public struct Snapshot
		{
			public uint Tick;

			public int cameraPosition_x;

			public int cameraPosition_y;

			public int playedNotes;

			public int movementDirection_x;

			public int movementDirection_y;

			public int aimDirection_x;

			public int aimDirection_y;

			public int targetingDirection_x;

			public int targetingDirection_y;

			public int mouseOrJoystickWorldPoint_x;

			public int mouseOrJoystickWorldPoint_y;

			public int joystickDirection_x;

			public int joystickDirection_y;

			public int buttonSetMask;

			public uint equippedSlotIndex;

			public uint equipmentPresetIndex;

			public uint facingDirection_id;

			public uint collectedAndEnabledSoulsMask;

			public uint deterministicInterpolationDelay;

			public uint prefersKeyboardAndMouse;

			public uint wasAiming;

			public uint useFishingMiniGame;
		}

		private const int ChangeMaskBits = 17;

		private static bool s_StateInitialized;

		private static GhostComponentSerializer.State s_State;

		public int ChangeMaskSizeInBits => 17;

		public bool HasGhostFields => true;

		public int SizeInSnapshot => UnsafeUtility.SizeOf<Snapshot>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyToSnapshot(in GhostSerializerState serializerState, [NoAlias] IntPtr snapshot, [NoAlias][ReadOnly] IntPtr component)
		{
			CopyToSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<Snapshot>(snapshot), in GhostComponentSerializer.TypeCast<ClientInput>(component));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyFromSnapshot(in GhostDeserializerState serializerState, [NoAlias] IntPtr component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, [NoAlias][ReadOnly] IntPtr snapshotBefore, [NoAlias][ReadOnly] IntPtr snapshotAfter)
		{
			CopyFromSnapshotGenerated(in serializerState, ref GhostComponentSerializer.TypeCast<ClientInput>(component), snapshotInterpolationFactor, snapshotInterpolationFactorRaw, in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotBefore), in GhostComponentSerializer.TypeCastReadonly<Snapshot>(snapshotAfter));
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
			RestoreFromBackupGenerated(ref GhostComponentSerializer.TypeCast<ClientInput>(component), in GhostComponentSerializer.TypeCastReadonly<ClientInput>(backup));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyToSnapshotGenerated(in GhostSerializerState serializerState, ref Snapshot snapshot, in ClientInput component)
		{
			snapshot.Tick = component.Tick.SerializedData;
			snapshot.cameraPosition_x = (int)math.round(component.cameraPosition.x * 1000f);
			snapshot.cameraPosition_y = (int)math.round(component.cameraPosition.y * 1000f);
			snapshot.playedNotes = component.playedNotes;
			snapshot.movementDirection_x = (int)math.round(component.movementDirection.x * 1000f);
			snapshot.movementDirection_y = (int)math.round(component.movementDirection.y * 1000f);
			snapshot.aimDirection_x = (int)math.round(component.aimDirection.x * 1000f);
			snapshot.aimDirection_y = (int)math.round(component.aimDirection.y * 1000f);
			snapshot.targetingDirection_x = (int)math.round(component.targetingDirection.x * 1000f);
			snapshot.targetingDirection_y = (int)math.round(component.targetingDirection.y * 1000f);
			snapshot.mouseOrJoystickWorldPoint_x = (int)math.round(component.mouseOrJoystickWorldPoint.x * 1000f);
			snapshot.mouseOrJoystickWorldPoint_y = (int)math.round(component.mouseOrJoystickWorldPoint.y * 1000f);
			snapshot.joystickDirection_x = (int)math.round(component.joystickDirection.x * 1000f);
			snapshot.joystickDirection_y = (int)math.round(component.joystickDirection.y * 1000f);
			snapshot.buttonSetMask = component.buttonSetMask;
			snapshot.equippedSlotIndex = component.equippedSlotIndex;
			snapshot.equipmentPresetIndex = component.equipmentPresetIndex;
			snapshot.facingDirection_id = (uint)component.facingDirection.id;
			snapshot.collectedAndEnabledSoulsMask = component.collectedAndEnabledSoulsMask;
			snapshot.deterministicInterpolationDelay = component.deterministicInterpolationDelay;
			snapshot.prefersKeyboardAndMouse = (component.prefersKeyboardAndMouse ? 1u : 0u);
			snapshot.wasAiming = (component.wasAiming ? 1u : 0u);
			snapshot.useFishingMiniGame = (component.useFishingMiniGame ? 1u : 0u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CopyFromSnapshotGenerated(in GhostDeserializerState deserializerState, ref ClientInput component, float snapshotInterpolationFactor, float snapshotInterpolationFactorRaw, in Snapshot snapshotBefore, in Snapshot snapshotAfter)
		{
			component.Tick = new NetworkTick
			{
				SerializedData = snapshotBefore.Tick
			};
			component.cameraPosition = new float2((float)snapshotBefore.cameraPosition_x * 0.001f, (float)snapshotBefore.cameraPosition_y * 0.001f);
			component.playedNotes = snapshotBefore.playedNotes;
			component.movementDirection = new float2((float)snapshotBefore.movementDirection_x * 0.001f, (float)snapshotBefore.movementDirection_y * 0.001f);
			component.aimDirection = new float2((float)snapshotBefore.aimDirection_x * 0.001f, (float)snapshotBefore.aimDirection_y * 0.001f);
			component.targetingDirection = new float2((float)snapshotBefore.targetingDirection_x * 0.001f, (float)snapshotBefore.targetingDirection_y * 0.001f);
			component.mouseOrJoystickWorldPoint = new float2((float)snapshotBefore.mouseOrJoystickWorldPoint_x * 0.001f, (float)snapshotBefore.mouseOrJoystickWorldPoint_y * 0.001f);
			component.joystickDirection = new float2((float)snapshotBefore.joystickDirection_x * 0.001f, (float)snapshotBefore.joystickDirection_y * 0.001f);
			component.buttonSetMask = (short)snapshotBefore.buttonSetMask;
			component.equippedSlotIndex = (byte)snapshotBefore.equippedSlotIndex;
			component.equipmentPresetIndex = (byte)snapshotBefore.equipmentPresetIndex;
			component.facingDirection.id = (Direction.Id)snapshotBefore.facingDirection_id;
			component.collectedAndEnabledSoulsMask = (byte)snapshotBefore.collectedAndEnabledSoulsMask;
			component.deterministicInterpolationDelay = (byte)snapshotBefore.deterministicInterpolationDelay;
			component.prefersKeyboardAndMouse = snapshotBefore.prefersKeyboardAndMouse != 0;
			component.wasAiming = snapshotBefore.wasAiming != 0;
			component.useFishingMiniGame = snapshotBefore.useFishingMiniGame != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RestoreFromBackupGenerated(ref ClientInput component, in ClientInput backup)
		{
			component.Tick = backup.Tick;
			component.cameraPosition.x = backup.cameraPosition.x;
			component.cameraPosition.y = backup.cameraPosition.y;
			component.playedNotes = backup.playedNotes;
			component.movementDirection.x = backup.movementDirection.x;
			component.movementDirection.y = backup.movementDirection.y;
			component.aimDirection.x = backup.aimDirection.x;
			component.aimDirection.y = backup.aimDirection.y;
			component.targetingDirection.x = backup.targetingDirection.x;
			component.targetingDirection.y = backup.targetingDirection.y;
			component.mouseOrJoystickWorldPoint.x = backup.mouseOrJoystickWorldPoint.x;
			component.mouseOrJoystickWorldPoint.y = backup.mouseOrJoystickWorldPoint.y;
			component.joystickDirection.x = backup.joystickDirection.x;
			component.joystickDirection.y = backup.joystickDirection.y;
			component.buttonSetMask = backup.buttonSetMask;
			component.equippedSlotIndex = backup.equippedSlotIndex;
			component.equipmentPresetIndex = backup.equipmentPresetIndex;
			component.facingDirection.id = backup.facingDirection.id;
			component.collectedAndEnabledSoulsMask = backup.collectedAndEnabledSoulsMask;
			component.deterministicInterpolationDelay = backup.deterministicInterpolationDelay;
			component.prefersKeyboardAndMouse = backup.prefersKeyboardAndMouse;
			component.wasAiming = backup.wasAiming;
			component.useFishingMiniGame = backup.useFishingMiniGame;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictDeltaGenerated(ref Snapshot snapshot, in Snapshot baseline1, in Snapshot baseline2, ref GhostDeltaPredictor predictor)
		{
			snapshot.Tick = (uint)predictor.PredictInt((int)snapshot.Tick, (int)baseline1.Tick, (int)baseline2.Tick);
			snapshot.cameraPosition_x = predictor.PredictInt(snapshot.cameraPosition_x, baseline1.cameraPosition_x, baseline2.cameraPosition_x);
			snapshot.cameraPosition_y = predictor.PredictInt(snapshot.cameraPosition_y, baseline1.cameraPosition_y, baseline2.cameraPosition_y);
			snapshot.playedNotes = predictor.PredictInt(snapshot.playedNotes, baseline1.playedNotes, baseline2.playedNotes);
			snapshot.movementDirection_x = predictor.PredictInt(snapshot.movementDirection_x, baseline1.movementDirection_x, baseline2.movementDirection_x);
			snapshot.movementDirection_y = predictor.PredictInt(snapshot.movementDirection_y, baseline1.movementDirection_y, baseline2.movementDirection_y);
			snapshot.aimDirection_x = predictor.PredictInt(snapshot.aimDirection_x, baseline1.aimDirection_x, baseline2.aimDirection_x);
			snapshot.aimDirection_y = predictor.PredictInt(snapshot.aimDirection_y, baseline1.aimDirection_y, baseline2.aimDirection_y);
			snapshot.targetingDirection_x = predictor.PredictInt(snapshot.targetingDirection_x, baseline1.targetingDirection_x, baseline2.targetingDirection_x);
			snapshot.targetingDirection_y = predictor.PredictInt(snapshot.targetingDirection_y, baseline1.targetingDirection_y, baseline2.targetingDirection_y);
			snapshot.mouseOrJoystickWorldPoint_x = predictor.PredictInt(snapshot.mouseOrJoystickWorldPoint_x, baseline1.mouseOrJoystickWorldPoint_x, baseline2.mouseOrJoystickWorldPoint_x);
			snapshot.mouseOrJoystickWorldPoint_y = predictor.PredictInt(snapshot.mouseOrJoystickWorldPoint_y, baseline1.mouseOrJoystickWorldPoint_y, baseline2.mouseOrJoystickWorldPoint_y);
			snapshot.joystickDirection_x = predictor.PredictInt(snapshot.joystickDirection_x, baseline1.joystickDirection_x, baseline2.joystickDirection_x);
			snapshot.joystickDirection_y = predictor.PredictInt(snapshot.joystickDirection_y, baseline1.joystickDirection_y, baseline2.joystickDirection_y);
			snapshot.buttonSetMask = predictor.PredictInt(snapshot.buttonSetMask, baseline1.buttonSetMask, baseline2.buttonSetMask);
			snapshot.equippedSlotIndex = (uint)predictor.PredictInt((int)snapshot.equippedSlotIndex, (int)baseline1.equippedSlotIndex, (int)baseline2.equippedSlotIndex);
			snapshot.equipmentPresetIndex = (uint)predictor.PredictInt((int)snapshot.equipmentPresetIndex, (int)baseline1.equipmentPresetIndex, (int)baseline2.equipmentPresetIndex);
			snapshot.facingDirection_id = (uint)predictor.PredictInt((int)snapshot.facingDirection_id, (int)baseline1.facingDirection_id, (int)baseline2.facingDirection_id);
			snapshot.collectedAndEnabledSoulsMask = (uint)predictor.PredictInt((int)snapshot.collectedAndEnabledSoulsMask, (int)baseline1.collectedAndEnabledSoulsMask, (int)baseline2.collectedAndEnabledSoulsMask);
			snapshot.deterministicInterpolationDelay = (uint)predictor.PredictInt((int)snapshot.deterministicInterpolationDelay, (int)baseline1.deterministicInterpolationDelay, (int)baseline2.deterministicInterpolationDelay);
			snapshot.prefersKeyboardAndMouse = (uint)predictor.PredictInt((int)snapshot.prefersKeyboardAndMouse, (int)baseline1.prefersKeyboardAndMouse, (int)baseline2.prefersKeyboardAndMouse);
			snapshot.wasAiming = (uint)predictor.PredictInt((int)snapshot.wasAiming, (int)baseline1.wasAiming, (int)baseline2.wasAiming);
			snapshot.useFishingMiniGame = (uint)predictor.PredictInt((int)snapshot.useFishingMiniGame, (int)baseline1.useFishingMiniGame, (int)baseline2.useFishingMiniGame);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateChangeMaskGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset)
		{
			uint num = ((snapshot.Tick != baseline.Tick) ? 1u : 0u);
			num |= (uint)((snapshot.cameraPosition_x != baseline.cameraPosition_x) ? 2 : 0);
			num |= (uint)((snapshot.cameraPosition_y != baseline.cameraPosition_y) ? 2 : 0);
			num |= (uint)((snapshot.playedNotes != baseline.playedNotes) ? 4 : 0);
			num |= (uint)((snapshot.movementDirection_x != baseline.movementDirection_x) ? 8 : 0);
			num |= (uint)((snapshot.movementDirection_y != baseline.movementDirection_y) ? 8 : 0);
			num |= (uint)((snapshot.aimDirection_x != baseline.aimDirection_x) ? 16 : 0);
			num |= (uint)((snapshot.aimDirection_y != baseline.aimDirection_y) ? 16 : 0);
			num |= (uint)((snapshot.targetingDirection_x != baseline.targetingDirection_x) ? 32 : 0);
			num |= (uint)((snapshot.targetingDirection_y != baseline.targetingDirection_y) ? 32 : 0);
			num |= (uint)((snapshot.mouseOrJoystickWorldPoint_x != baseline.mouseOrJoystickWorldPoint_x) ? 64 : 0);
			num |= (uint)((snapshot.mouseOrJoystickWorldPoint_y != baseline.mouseOrJoystickWorldPoint_y) ? 64 : 0);
			num |= (uint)((snapshot.joystickDirection_x != baseline.joystickDirection_x) ? 128 : 0);
			num |= (uint)((snapshot.joystickDirection_y != baseline.joystickDirection_y) ? 128 : 0);
			num |= (uint)((snapshot.buttonSetMask != baseline.buttonSetMask) ? 256 : 0);
			num |= (uint)((snapshot.equippedSlotIndex != baseline.equippedSlotIndex) ? 512 : 0);
			num |= (uint)((snapshot.equipmentPresetIndex != baseline.equipmentPresetIndex) ? 1024 : 0);
			num |= (uint)((snapshot.facingDirection_id != baseline.facingDirection_id) ? 2048 : 0);
			num |= (uint)((snapshot.collectedAndEnabledSoulsMask != baseline.collectedAndEnabledSoulsMask) ? 4096 : 0);
			num |= (uint)((snapshot.deterministicInterpolationDelay != baseline.deterministicInterpolationDelay) ? 8192 : 0);
			num |= (uint)((snapshot.prefersKeyboardAndMouse != baseline.prefersKeyboardAndMouse) ? 16384 : 0);
			num |= (uint)((snapshot.wasAiming != baseline.wasAiming) ? 32768 : 0);
			num |= (uint)((snapshot.useFishingMiniGame != baseline.useFishingMiniGame) ? 65536 : 0);
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 17);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 17);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Tick, baseline.Tick, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.cameraPosition_x, baseline.cameraPosition_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.cameraPosition_y, baseline.cameraPosition_y, in compressionModel);
			}
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.playedNotes, baseline.playedNotes, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.movementDirection_x, baseline.movementDirection_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.movementDirection_y, baseline.movementDirection_y, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.aimDirection_x, baseline.aimDirection_x, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.aimDirection_y, baseline.aimDirection_y, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.targetingDirection_x, baseline.targetingDirection_x, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.targetingDirection_y, baseline.targetingDirection_y, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.mouseOrJoystickWorldPoint_x, baseline.mouseOrJoystickWorldPoint_x, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.mouseOrJoystickWorldPoint_y, baseline.mouseOrJoystickWorldPoint_y, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.joystickDirection_x, baseline.joystickDirection_x, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.joystickDirection_y, baseline.joystickDirection_y, in compressionModel);
			}
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.buttonSetMask, baseline.buttonSetMask, in compressionModel);
			}
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.equippedSlotIndex, baseline.equippedSlotIndex, in compressionModel);
			}
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.equipmentPresetIndex, baseline.equipmentPresetIndex, in compressionModel);
			}
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.facingDirection_id, baseline.facingDirection_id, in compressionModel);
			}
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.collectedAndEnabledSoulsMask, baseline.collectedAndEnabledSoulsMask, in compressionModel);
			}
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.deterministicInterpolationDelay, baseline.deterministicInterpolationDelay, in compressionModel);
			}
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.prefersKeyboardAndMouse, baseline.prefersKeyboardAndMouse, in compressionModel);
			}
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.wasAiming, baseline.wasAiming, in compressionModel);
			}
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.useFishingMiniGame, baseline.useFishingMiniGame, in compressionModel);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SerializeCombinedGenerated(in Snapshot snapshot, in Snapshot baseline, [NoAlias] IntPtr changeMaskData, int startOffset, ref DataStreamWriter writer, in StreamCompressionModel compressionModel)
		{
			uint num = ((snapshot.Tick != baseline.Tick) ? 1u : 0u);
			if ((num & 1) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.Tick, baseline.Tick, in compressionModel);
			}
			num |= (uint)((snapshot.cameraPosition_x != baseline.cameraPosition_x) ? 2 : 0);
			num |= (uint)((snapshot.cameraPosition_y != baseline.cameraPosition_y) ? 2 : 0);
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.cameraPosition_x, baseline.cameraPosition_x, in compressionModel);
			}
			if ((num & 2) != 0)
			{
				writer.WritePackedIntDelta(snapshot.cameraPosition_y, baseline.cameraPosition_y, in compressionModel);
			}
			num |= (uint)((snapshot.playedNotes != baseline.playedNotes) ? 4 : 0);
			if ((num & 4) != 0)
			{
				writer.WritePackedIntDelta(snapshot.playedNotes, baseline.playedNotes, in compressionModel);
			}
			num |= (uint)((snapshot.movementDirection_x != baseline.movementDirection_x) ? 8 : 0);
			num |= (uint)((snapshot.movementDirection_y != baseline.movementDirection_y) ? 8 : 0);
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.movementDirection_x, baseline.movementDirection_x, in compressionModel);
			}
			if ((num & 8) != 0)
			{
				writer.WritePackedIntDelta(snapshot.movementDirection_y, baseline.movementDirection_y, in compressionModel);
			}
			num |= (uint)((snapshot.aimDirection_x != baseline.aimDirection_x) ? 16 : 0);
			num |= (uint)((snapshot.aimDirection_y != baseline.aimDirection_y) ? 16 : 0);
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.aimDirection_x, baseline.aimDirection_x, in compressionModel);
			}
			if ((num & 0x10) != 0)
			{
				writer.WritePackedIntDelta(snapshot.aimDirection_y, baseline.aimDirection_y, in compressionModel);
			}
			num |= (uint)((snapshot.targetingDirection_x != baseline.targetingDirection_x) ? 32 : 0);
			num |= (uint)((snapshot.targetingDirection_y != baseline.targetingDirection_y) ? 32 : 0);
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.targetingDirection_x, baseline.targetingDirection_x, in compressionModel);
			}
			if ((num & 0x20) != 0)
			{
				writer.WritePackedIntDelta(snapshot.targetingDirection_y, baseline.targetingDirection_y, in compressionModel);
			}
			num |= (uint)((snapshot.mouseOrJoystickWorldPoint_x != baseline.mouseOrJoystickWorldPoint_x) ? 64 : 0);
			num |= (uint)((snapshot.mouseOrJoystickWorldPoint_y != baseline.mouseOrJoystickWorldPoint_y) ? 64 : 0);
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.mouseOrJoystickWorldPoint_x, baseline.mouseOrJoystickWorldPoint_x, in compressionModel);
			}
			if ((num & 0x40) != 0)
			{
				writer.WritePackedIntDelta(snapshot.mouseOrJoystickWorldPoint_y, baseline.mouseOrJoystickWorldPoint_y, in compressionModel);
			}
			num |= (uint)((snapshot.joystickDirection_x != baseline.joystickDirection_x) ? 128 : 0);
			num |= (uint)((snapshot.joystickDirection_y != baseline.joystickDirection_y) ? 128 : 0);
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.joystickDirection_x, baseline.joystickDirection_x, in compressionModel);
			}
			if ((num & 0x80) != 0)
			{
				writer.WritePackedIntDelta(snapshot.joystickDirection_y, baseline.joystickDirection_y, in compressionModel);
			}
			num |= (uint)((snapshot.buttonSetMask != baseline.buttonSetMask) ? 256 : 0);
			if ((num & 0x100) != 0)
			{
				writer.WritePackedIntDelta(snapshot.buttonSetMask, baseline.buttonSetMask, in compressionModel);
			}
			num |= (uint)((snapshot.equippedSlotIndex != baseline.equippedSlotIndex) ? 512 : 0);
			if ((num & 0x200) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.equippedSlotIndex, baseline.equippedSlotIndex, in compressionModel);
			}
			num |= (uint)((snapshot.equipmentPresetIndex != baseline.equipmentPresetIndex) ? 1024 : 0);
			if ((num & 0x400) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.equipmentPresetIndex, baseline.equipmentPresetIndex, in compressionModel);
			}
			num |= (uint)((snapshot.facingDirection_id != baseline.facingDirection_id) ? 2048 : 0);
			if ((num & 0x800) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.facingDirection_id, baseline.facingDirection_id, in compressionModel);
			}
			num |= (uint)((snapshot.collectedAndEnabledSoulsMask != baseline.collectedAndEnabledSoulsMask) ? 4096 : 0);
			if ((num & 0x1000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.collectedAndEnabledSoulsMask, baseline.collectedAndEnabledSoulsMask, in compressionModel);
			}
			num |= (uint)((snapshot.deterministicInterpolationDelay != baseline.deterministicInterpolationDelay) ? 8192 : 0);
			if ((num & 0x2000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.deterministicInterpolationDelay, baseline.deterministicInterpolationDelay, in compressionModel);
			}
			num |= (uint)((snapshot.prefersKeyboardAndMouse != baseline.prefersKeyboardAndMouse) ? 16384 : 0);
			if ((num & 0x4000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.prefersKeyboardAndMouse, baseline.prefersKeyboardAndMouse, in compressionModel);
			}
			num |= (uint)((snapshot.wasAiming != baseline.wasAiming) ? 32768 : 0);
			if ((num & 0x8000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.wasAiming, baseline.wasAiming, in compressionModel);
			}
			num |= (uint)((snapshot.useFishingMiniGame != baseline.useFishingMiniGame) ? 65536 : 0);
			if ((num & 0x10000) != 0)
			{
				writer.WritePackedUIntDelta(snapshot.useFishingMiniGame, baseline.useFishingMiniGame, in compressionModel);
			}
			GhostComponentSerializer.CopyToChangeMask(changeMaskData, num, startOffset, 17);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializeGenerated(ref DataStreamReader reader, in StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset, ref Snapshot snapshot, in Snapshot baseline)
		{
			uint num = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, 17);
			if ((num & 1) != 0)
			{
				snapshot.Tick = reader.ReadPackedUIntDelta(baseline.Tick, in compressionModel);
			}
			else
			{
				snapshot.Tick = baseline.Tick;
			}
			if ((num & 2) != 0)
			{
				snapshot.cameraPosition_x = reader.ReadPackedIntDelta(baseline.cameraPosition_x, in compressionModel);
			}
			else
			{
				snapshot.cameraPosition_x = baseline.cameraPosition_x;
			}
			if ((num & 2) != 0)
			{
				snapshot.cameraPosition_y = reader.ReadPackedIntDelta(baseline.cameraPosition_y, in compressionModel);
			}
			else
			{
				snapshot.cameraPosition_y = baseline.cameraPosition_y;
			}
			if ((num & 4) != 0)
			{
				snapshot.playedNotes = reader.ReadPackedIntDelta(baseline.playedNotes, in compressionModel);
			}
			else
			{
				snapshot.playedNotes = baseline.playedNotes;
			}
			if ((num & 8) != 0)
			{
				snapshot.movementDirection_x = reader.ReadPackedIntDelta(baseline.movementDirection_x, in compressionModel);
			}
			else
			{
				snapshot.movementDirection_x = baseline.movementDirection_x;
			}
			if ((num & 8) != 0)
			{
				snapshot.movementDirection_y = reader.ReadPackedIntDelta(baseline.movementDirection_y, in compressionModel);
			}
			else
			{
				snapshot.movementDirection_y = baseline.movementDirection_y;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.aimDirection_x = reader.ReadPackedIntDelta(baseline.aimDirection_x, in compressionModel);
			}
			else
			{
				snapshot.aimDirection_x = baseline.aimDirection_x;
			}
			if ((num & 0x10) != 0)
			{
				snapshot.aimDirection_y = reader.ReadPackedIntDelta(baseline.aimDirection_y, in compressionModel);
			}
			else
			{
				snapshot.aimDirection_y = baseline.aimDirection_y;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.targetingDirection_x = reader.ReadPackedIntDelta(baseline.targetingDirection_x, in compressionModel);
			}
			else
			{
				snapshot.targetingDirection_x = baseline.targetingDirection_x;
			}
			if ((num & 0x20) != 0)
			{
				snapshot.targetingDirection_y = reader.ReadPackedIntDelta(baseline.targetingDirection_y, in compressionModel);
			}
			else
			{
				snapshot.targetingDirection_y = baseline.targetingDirection_y;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.mouseOrJoystickWorldPoint_x = reader.ReadPackedIntDelta(baseline.mouseOrJoystickWorldPoint_x, in compressionModel);
			}
			else
			{
				snapshot.mouseOrJoystickWorldPoint_x = baseline.mouseOrJoystickWorldPoint_x;
			}
			if ((num & 0x40) != 0)
			{
				snapshot.mouseOrJoystickWorldPoint_y = reader.ReadPackedIntDelta(baseline.mouseOrJoystickWorldPoint_y, in compressionModel);
			}
			else
			{
				snapshot.mouseOrJoystickWorldPoint_y = baseline.mouseOrJoystickWorldPoint_y;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.joystickDirection_x = reader.ReadPackedIntDelta(baseline.joystickDirection_x, in compressionModel);
			}
			else
			{
				snapshot.joystickDirection_x = baseline.joystickDirection_x;
			}
			if ((num & 0x80) != 0)
			{
				snapshot.joystickDirection_y = reader.ReadPackedIntDelta(baseline.joystickDirection_y, in compressionModel);
			}
			else
			{
				snapshot.joystickDirection_y = baseline.joystickDirection_y;
			}
			if ((num & 0x100) != 0)
			{
				snapshot.buttonSetMask = reader.ReadPackedIntDelta(baseline.buttonSetMask, in compressionModel);
			}
			else
			{
				snapshot.buttonSetMask = baseline.buttonSetMask;
			}
			if ((num & 0x200) != 0)
			{
				snapshot.equippedSlotIndex = reader.ReadPackedUIntDelta(baseline.equippedSlotIndex, in compressionModel);
			}
			else
			{
				snapshot.equippedSlotIndex = baseline.equippedSlotIndex;
			}
			if ((num & 0x400) != 0)
			{
				snapshot.equipmentPresetIndex = reader.ReadPackedUIntDelta(baseline.equipmentPresetIndex, in compressionModel);
			}
			else
			{
				snapshot.equipmentPresetIndex = baseline.equipmentPresetIndex;
			}
			if ((num & 0x800) != 0)
			{
				snapshot.facingDirection_id = reader.ReadPackedUIntDelta(baseline.facingDirection_id, in compressionModel);
			}
			else
			{
				snapshot.facingDirection_id = baseline.facingDirection_id;
			}
			if ((num & 0x1000) != 0)
			{
				snapshot.collectedAndEnabledSoulsMask = reader.ReadPackedUIntDelta(baseline.collectedAndEnabledSoulsMask, in compressionModel);
			}
			else
			{
				snapshot.collectedAndEnabledSoulsMask = baseline.collectedAndEnabledSoulsMask;
			}
			if ((num & 0x2000) != 0)
			{
				snapshot.deterministicInterpolationDelay = reader.ReadPackedUIntDelta(baseline.deterministicInterpolationDelay, in compressionModel);
			}
			else
			{
				snapshot.deterministicInterpolationDelay = baseline.deterministicInterpolationDelay;
			}
			if ((num & 0x4000) != 0)
			{
				snapshot.prefersKeyboardAndMouse = reader.ReadPackedUIntDelta(baseline.prefersKeyboardAndMouse, in compressionModel);
			}
			else
			{
				snapshot.prefersKeyboardAndMouse = baseline.prefersKeyboardAndMouse;
			}
			if ((num & 0x8000) != 0)
			{
				snapshot.wasAiming = reader.ReadPackedUIntDelta(baseline.wasAiming, in compressionModel);
			}
			else
			{
				snapshot.wasAiming = baseline.wasAiming;
			}
			if ((num & 0x10000) != 0)
			{
				snapshot.useFishingMiniGame = reader.ReadPackedUIntDelta(baseline.useFishingMiniGame, in compressionModel);
			}
			else
			{
				snapshot.useFishingMiniGame = baseline.useFishingMiniGame;
			}
		}

		internal static GhostComponentSerializer.State GetState(ref SystemState state)
		{
			if (!s_StateInitialized)
			{
				s_State = new GhostComponentSerializer.State
				{
					GhostFieldsHash = 1560578527056479122uL,
					ComponentType = ComponentType.ReadWrite<ClientInput>(),
					ComponentSize = UnsafeUtility.SizeOf<ClientInput>(),
					SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
					ChangeMaskBits = 17,
					PrefabType = GhostPrefabType.All,
					SendMask = GhostSendType.AllClients,
					SendToOwner = SendToOwnerType.SendToNonOwner,
					VariantHash = 6943602050847636562uL,
					SerializationStrategyIndex = -1,
					SerializesEnabledBit = 0
				};
				if (s_State.ComponentType.IsZeroSized)
				{
					s_State.ComponentSize = 0;
				}
				s_StateInitialized = ComponentSerializationHelper<ClientInput, Snapshot, ClientInputGhostComponentSerializer>.SetupFunctionPointers(ref s_State, ref state);
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
