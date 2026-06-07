using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.Serializer;
using Coherence.SimulationFrame;

namespace Coherence.Generated
{
	public struct _145b9c266d666ec47b26a3ed9363150a_11319918802731987170 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int GateIndex;

			[FieldOffset(4)]
			public float _triggerDelay;

			[FieldOffset(8)]
			public Entity Link;

			[FieldOffset(12)]
			public byte IsAstralSecretDoor;

			[FieldOffset(13)]
			public ByteArray TeleporterKey;

			[FieldOffset(29)]
			public byte IsAnyGuardAlive;

			[FieldOffset(30)]
			public byte HasSpawned;

			[FieldOffset(31)]
			public int SyncedPickupType;

			[FieldOffset(35)]
			public byte IsStagePickup;

			[FieldOffset(36)]
			public ByteArray SpriteName;

			[FieldOffset(52)]
			public float Value;

			[FieldOffset(56)]
			public byte IgnoreMadGroove;

			[FieldOffset(57)]
			public byte DisableGet;

			[FieldOffset(58)]
			public ByteArray DestinationName;

			[FieldOffset(74)]
			public byte CanTeleport;
		}

		public AbsoluteSimulationFrame GateIndexSimulationFrame;

		public int GateIndex;

		public AbsoluteSimulationFrame _triggerDelaySimulationFrame;

		public float _triggerDelay;

		public AbsoluteSimulationFrame LinkSimulationFrame;

		public Entity Link;

		public AbsoluteSimulationFrame IsAstralSecretDoorSimulationFrame;

		public bool IsAstralSecretDoor;

		public AbsoluteSimulationFrame TeleporterKeySimulationFrame;

		public string TeleporterKey;

		public AbsoluteSimulationFrame IsAnyGuardAliveSimulationFrame;

		public bool IsAnyGuardAlive;

		public AbsoluteSimulationFrame HasSpawnedSimulationFrame;

		public bool HasSpawned;

		public AbsoluteSimulationFrame SyncedPickupTypeSimulationFrame;

		public int SyncedPickupType;

		public AbsoluteSimulationFrame IsStagePickupSimulationFrame;

		public bool IsStagePickup;

		public AbsoluteSimulationFrame SpriteNameSimulationFrame;

		public string SpriteName;

		public AbsoluteSimulationFrame ValueSimulationFrame;

		public float Value;

		public AbsoluteSimulationFrame IgnoreMadGrooveSimulationFrame;

		public bool IgnoreMadGroove;

		public AbsoluteSimulationFrame DisableGetSimulationFrame;

		public bool DisableGet;

		public AbsoluteSimulationFrame DestinationNameSimulationFrame;

		public string DestinationName;

		public AbsoluteSimulationFrame CanTeleportSimulationFrame;

		public bool CanTeleport;

		public const int order = 0;

		private static readonly int _GateIndex_Min;

		private static readonly int _GateIndex_Max;

		private static readonly int _SyncedPickupType_Min;

		private static readonly int _SyncedPickupType_Max;

		public static uint GateIndexMask => 0u;

		public static uint _triggerDelayMask => 0u;

		public static uint LinkMask => 0u;

		public static uint IsAstralSecretDoorMask => 0u;

		public static uint TeleporterKeyMask => 0u;

		public static uint IsAnyGuardAliveMask => 0u;

		public static uint HasSpawnedMask => 0u;

		public static uint SyncedPickupTypeMask => 0u;

		public static uint IsStagePickupMask => 0u;

		public static uint SpriteNameMask => 0u;

		public static uint ValueMask => 0u;

		public static uint IgnoreMadGrooveMask => 0u;

		public static uint DisableGetMask => 0u;

		public static uint DestinationNameMask => 0u;

		public static uint CanTeleportMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _145b9c266d666ec47b26a3ed9363150a_11319918802731987170 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_145b9c266d666ec47b26a3ed9363150a_11319918802731987170);
		}

		public uint GetComponentType()
		{
			return 0u;
		}

		public int PriorityLevel()
		{
			return 0;
		}

		public uint InitialFieldsMask()
		{
			return 0u;
		}

		public bool HasFields()
		{
			return false;
		}

		public bool HasRefFields()
		{
			return false;
		}

		public long[] GetSimulationFrames()
		{
			return null;
		}

		public int GetFieldCount()
		{
			return 0;
		}

		public HashSet<Entity> GetEntityRefs()
		{
			return null;
		}

		public uint ReplaceReferences(Entity fromEntity, Entity toEntity)
		{
			return 0u;
		}

		public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper)
		{
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error MapToRelative(IEntityMapper mapper)
		{
			return default(IEntityMapper.Error);
		}

		public ICoherenceComponentData Clone()
		{
			return null;
		}

		public int GetComponentOrder()
		{
			return 0;
		}

		public bool IsSendOrdered()
		{
			return false;
		}

		public AbsoluteSimulationFrame? GetMinSimulationFrame()
		{
			return null;
		}

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data)
		{
			return null;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			return 0u;
		}

		public static uint Serialize(_145b9c266d666ec47b26a3ed9363150a_11319918802731987170 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _145b9c266d666ec47b26a3ed9363150a_11319918802731987170 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_145b9c266d666ec47b26a3ed9363150a_11319918802731987170);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
