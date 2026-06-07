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
	public struct _b06052a15cf60af46a9db04018c90cdb_7586542022594947976 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int SyncedPickupType;

			[FieldOffset(4)]
			public byte IsStagePickup;

			[FieldOffset(5)]
			public ByteArray SpriteName;

			[FieldOffset(21)]
			public byte IsAnyGuardAlive;

			[FieldOffset(22)]
			public float Value;

			[FieldOffset(26)]
			public Entity Link;

			[FieldOffset(30)]
			public byte IsAstralSecretDoor;

			[FieldOffset(31)]
			public byte HasSpawned;

			[FieldOffset(32)]
			public byte IgnoreMadGroove;

			[FieldOffset(33)]
			public int GateIndex;

			[FieldOffset(37)]
			public float _triggerDelay;

			[FieldOffset(41)]
			public byte DisableGet;

			[FieldOffset(42)]
			public ByteArray TeleporterKey;

			[FieldOffset(58)]
			public byte CanTeleport;
		}

		public AbsoluteSimulationFrame SyncedPickupTypeSimulationFrame;

		public int SyncedPickupType;

		public AbsoluteSimulationFrame IsStagePickupSimulationFrame;

		public bool IsStagePickup;

		public AbsoluteSimulationFrame SpriteNameSimulationFrame;

		public string SpriteName;

		public AbsoluteSimulationFrame IsAnyGuardAliveSimulationFrame;

		public bool IsAnyGuardAlive;

		public AbsoluteSimulationFrame ValueSimulationFrame;

		public float Value;

		public AbsoluteSimulationFrame LinkSimulationFrame;

		public Entity Link;

		public AbsoluteSimulationFrame IsAstralSecretDoorSimulationFrame;

		public bool IsAstralSecretDoor;

		public AbsoluteSimulationFrame HasSpawnedSimulationFrame;

		public bool HasSpawned;

		public AbsoluteSimulationFrame IgnoreMadGrooveSimulationFrame;

		public bool IgnoreMadGroove;

		public AbsoluteSimulationFrame GateIndexSimulationFrame;

		public int GateIndex;

		public AbsoluteSimulationFrame _triggerDelaySimulationFrame;

		public float _triggerDelay;

		public AbsoluteSimulationFrame DisableGetSimulationFrame;

		public bool DisableGet;

		public AbsoluteSimulationFrame TeleporterKeySimulationFrame;

		public string TeleporterKey;

		public AbsoluteSimulationFrame CanTeleportSimulationFrame;

		public bool CanTeleport;

		public const int order = 0;

		private static readonly int _SyncedPickupType_Min;

		private static readonly int _SyncedPickupType_Max;

		private static readonly int _GateIndex_Min;

		private static readonly int _GateIndex_Max;

		public static uint SyncedPickupTypeMask => 0u;

		public static uint IsStagePickupMask => 0u;

		public static uint SpriteNameMask => 0u;

		public static uint IsAnyGuardAliveMask => 0u;

		public static uint ValueMask => 0u;

		public static uint LinkMask => 0u;

		public static uint IsAstralSecretDoorMask => 0u;

		public static uint HasSpawnedMask => 0u;

		public static uint IgnoreMadGrooveMask => 0u;

		public static uint GateIndexMask => 0u;

		public static uint _triggerDelayMask => 0u;

		public static uint DisableGetMask => 0u;

		public static uint TeleporterKeyMask => 0u;

		public static uint CanTeleportMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _b06052a15cf60af46a9db04018c90cdb_7586542022594947976 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_b06052a15cf60af46a9db04018c90cdb_7586542022594947976);
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

		public static uint Serialize(_b06052a15cf60af46a9db04018c90cdb_7586542022594947976 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _b06052a15cf60af46a9db04018c90cdb_7586542022594947976 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_b06052a15cf60af46a9db04018c90cdb_7586542022594947976);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
