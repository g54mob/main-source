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
	public struct _32077016b3d740f438be7293b01c02ac_1079945632233027578 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity TargetTransform;

			[FieldOffset(4)]
			public byte SyncedDeathStyle;

			[FieldOffset(5)]
			public Entity Eye1;

			[FieldOffset(9)]
			public Entity Eye2;

			[FieldOffset(13)]
			public Entity Eye3;

			[FieldOffset(17)]
			public Entity Eye4;

			[FieldOffset(21)]
			public Entity Eye5;

			[FieldOffset(25)]
			public Entity Eye6;

			[FieldOffset(29)]
			public Entity Eye7;

			[FieldOffset(33)]
			public int SyncedEnemyType;

			[FieldOffset(37)]
			public uint DeathSeed;

			[FieldOffset(41)]
			public byte IsTeleportOnCull;

			[FieldOffset(42)]
			public Entity Owner;

			[FieldOffset(46)]
			public byte IsBoss;
		}

		public AbsoluteSimulationFrame TargetTransformSimulationFrame;

		public Entity TargetTransform;

		public AbsoluteSimulationFrame SyncedDeathStyleSimulationFrame;

		public byte SyncedDeathStyle;

		public AbsoluteSimulationFrame Eye1SimulationFrame;

		public Entity Eye1;

		public AbsoluteSimulationFrame Eye2SimulationFrame;

		public Entity Eye2;

		public AbsoluteSimulationFrame Eye3SimulationFrame;

		public Entity Eye3;

		public AbsoluteSimulationFrame Eye4SimulationFrame;

		public Entity Eye4;

		public AbsoluteSimulationFrame Eye5SimulationFrame;

		public Entity Eye5;

		public AbsoluteSimulationFrame Eye6SimulationFrame;

		public Entity Eye6;

		public AbsoluteSimulationFrame Eye7SimulationFrame;

		public Entity Eye7;

		public AbsoluteSimulationFrame SyncedEnemyTypeSimulationFrame;

		public int SyncedEnemyType;

		public AbsoluteSimulationFrame DeathSeedSimulationFrame;

		public uint DeathSeed;

		public AbsoluteSimulationFrame IsTeleportOnCullSimulationFrame;

		public bool IsTeleportOnCull;

		public AbsoluteSimulationFrame OwnerSimulationFrame;

		public Entity Owner;

		public AbsoluteSimulationFrame IsBossSimulationFrame;

		public bool IsBoss;

		public const int order = 0;

		private static readonly int _SyncedEnemyType_Min;

		private static readonly int _SyncedEnemyType_Max;

		private static readonly uint _DeathSeed_Min;

		private static readonly uint _DeathSeed_Max;

		public static uint TargetTransformMask => 0u;

		public static uint SyncedDeathStyleMask => 0u;

		public static uint Eye1Mask => 0u;

		public static uint Eye2Mask => 0u;

		public static uint Eye3Mask => 0u;

		public static uint Eye4Mask => 0u;

		public static uint Eye5Mask => 0u;

		public static uint Eye6Mask => 0u;

		public static uint Eye7Mask => 0u;

		public static uint SyncedEnemyTypeMask => 0u;

		public static uint DeathSeedMask => 0u;

		public static uint IsTeleportOnCullMask => 0u;

		public static uint OwnerMask => 0u;

		public static uint IsBossMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _32077016b3d740f438be7293b01c02ac_1079945632233027578 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_32077016b3d740f438be7293b01c02ac_1079945632233027578);
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

		public static uint Serialize(_32077016b3d740f438be7293b01c02ac_1079945632233027578 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _32077016b3d740f438be7293b01c02ac_1079945632233027578 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_32077016b3d740f438be7293b01c02ac_1079945632233027578);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
