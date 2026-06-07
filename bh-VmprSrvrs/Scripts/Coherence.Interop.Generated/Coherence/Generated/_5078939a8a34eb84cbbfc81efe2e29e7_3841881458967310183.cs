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
	public struct _5078939a8a34eb84cbbfc81efe2e29e7_3841881458967310183 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int SyncedWeaponType;

			[FieldOffset(4)]
			public int SyncedPickupType;

			[FieldOffset(8)]
			public byte IsStagePickup;

			[FieldOffset(9)]
			public ByteArray SpriteName;

			[FieldOffset(25)]
			public byte IsAnyGuardAlive;

			[FieldOffset(26)]
			public float Value;

			[FieldOffset(30)]
			public byte DespawnOnUnavailable;

			[FieldOffset(31)]
			public byte HasSpawned;

			[FieldOffset(32)]
			public Entity MarkedForSpecificCharacter;

			[FieldOffset(36)]
			public byte IgnoreMadGroove;

			[FieldOffset(37)]
			public byte DisableGet;
		}

		public AbsoluteSimulationFrame SyncedWeaponTypeSimulationFrame;

		public int SyncedWeaponType;

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

		public AbsoluteSimulationFrame DespawnOnUnavailableSimulationFrame;

		public bool DespawnOnUnavailable;

		public AbsoluteSimulationFrame HasSpawnedSimulationFrame;

		public bool HasSpawned;

		public AbsoluteSimulationFrame MarkedForSpecificCharacterSimulationFrame;

		public Entity MarkedForSpecificCharacter;

		public AbsoluteSimulationFrame IgnoreMadGrooveSimulationFrame;

		public bool IgnoreMadGroove;

		public AbsoluteSimulationFrame DisableGetSimulationFrame;

		public bool DisableGet;

		public const int order = 0;

		private static readonly int _SyncedWeaponType_Min;

		private static readonly int _SyncedWeaponType_Max;

		private static readonly int _SyncedPickupType_Min;

		private static readonly int _SyncedPickupType_Max;

		public static uint SyncedWeaponTypeMask => 0u;

		public static uint SyncedPickupTypeMask => 0u;

		public static uint IsStagePickupMask => 0u;

		public static uint SpriteNameMask => 0u;

		public static uint IsAnyGuardAliveMask => 0u;

		public static uint ValueMask => 0u;

		public static uint DespawnOnUnavailableMask => 0u;

		public static uint HasSpawnedMask => 0u;

		public static uint MarkedForSpecificCharacterMask => 0u;

		public static uint IgnoreMadGrooveMask => 0u;

		public static uint DisableGetMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _5078939a8a34eb84cbbfc81efe2e29e7_3841881458967310183 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_5078939a8a34eb84cbbfc81efe2e29e7_3841881458967310183);
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

		public static uint Serialize(_5078939a8a34eb84cbbfc81efe2e29e7_3841881458967310183 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _5078939a8a34eb84cbbfc81efe2e29e7_3841881458967310183 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_5078939a8a34eb84cbbfc81efe2e29e7_3841881458967310183);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
