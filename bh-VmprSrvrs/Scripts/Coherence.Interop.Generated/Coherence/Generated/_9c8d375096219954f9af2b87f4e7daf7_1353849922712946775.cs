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
	public struct _9c8d375096219954f9af2b87f4e7daf7_1353849922712946775 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int SyncedEnemyType;

			[FieldOffset(4)]
			public byte SyncedDeathStyle;

			[FieldOffset(5)]
			public Entity TargetTransform;

			[FieldOffset(9)]
			public Entity Owner;

			[FieldOffset(13)]
			public uint DeathSeed;

			[FieldOffset(17)]
			public byte IsTeleportOnCull;

			[FieldOffset(18)]
			public byte IsBoss;
		}

		public AbsoluteSimulationFrame SyncedEnemyTypeSimulationFrame;

		public int SyncedEnemyType;

		public AbsoluteSimulationFrame SyncedDeathStyleSimulationFrame;

		public byte SyncedDeathStyle;

		public AbsoluteSimulationFrame TargetTransformSimulationFrame;

		public Entity TargetTransform;

		public AbsoluteSimulationFrame OwnerSimulationFrame;

		public Entity Owner;

		public AbsoluteSimulationFrame DeathSeedSimulationFrame;

		public uint DeathSeed;

		public AbsoluteSimulationFrame IsTeleportOnCullSimulationFrame;

		public bool IsTeleportOnCull;

		public AbsoluteSimulationFrame IsBossSimulationFrame;

		public bool IsBoss;

		public const int order = 0;

		private static readonly int _SyncedEnemyType_Min;

		private static readonly int _SyncedEnemyType_Max;

		private static readonly uint _DeathSeed_Min;

		private static readonly uint _DeathSeed_Max;

		public static uint SyncedEnemyTypeMask => 0u;

		public static uint SyncedDeathStyleMask => 0u;

		public static uint TargetTransformMask => 0u;

		public static uint OwnerMask => 0u;

		public static uint DeathSeedMask => 0u;

		public static uint IsTeleportOnCullMask => 0u;

		public static uint IsBossMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _9c8d375096219954f9af2b87f4e7daf7_1353849922712946775 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_9c8d375096219954f9af2b87f4e7daf7_1353849922712946775);
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

		public static uint Serialize(_9c8d375096219954f9af2b87f4e7daf7_1353849922712946775 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _9c8d375096219954f9af2b87f4e7daf7_1353849922712946775 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_9c8d375096219954f9af2b87f4e7daf7_1353849922712946775);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
