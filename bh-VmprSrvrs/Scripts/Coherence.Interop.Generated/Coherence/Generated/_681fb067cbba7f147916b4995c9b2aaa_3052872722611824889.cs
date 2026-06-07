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
	public struct _681fb067cbba7f147916b4995c9b2aaa_3052872722611824889 : ICoherenceComponentData
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

			[FieldOffset(19)]
			public Entity Head;

			[FieldOffset(23)]
			public Entity LeftArm;

			[FieldOffset(27)]
			public Entity LeftHand;

			[FieldOffset(31)]
			public Entity RightArm;

			[FieldOffset(35)]
			public Entity RightHand;

			[FieldOffset(39)]
			public Entity LeftThigh;

			[FieldOffset(43)]
			public Entity LeftLeg;

			[FieldOffset(47)]
			public Entity RightThigh;

			[FieldOffset(51)]
			public Entity RightLeg;

			[FieldOffset(55)]
			public Entity Belly;

			[FieldOffset(59)]
			public byte IsDead;
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

		public AbsoluteSimulationFrame HeadSimulationFrame;

		public Entity Head;

		public AbsoluteSimulationFrame LeftArmSimulationFrame;

		public Entity LeftArm;

		public AbsoluteSimulationFrame LeftHandSimulationFrame;

		public Entity LeftHand;

		public AbsoluteSimulationFrame RightArmSimulationFrame;

		public Entity RightArm;

		public AbsoluteSimulationFrame RightHandSimulationFrame;

		public Entity RightHand;

		public AbsoluteSimulationFrame LeftThighSimulationFrame;

		public Entity LeftThigh;

		public AbsoluteSimulationFrame LeftLegSimulationFrame;

		public Entity LeftLeg;

		public AbsoluteSimulationFrame RightThighSimulationFrame;

		public Entity RightThigh;

		public AbsoluteSimulationFrame RightLegSimulationFrame;

		public Entity RightLeg;

		public AbsoluteSimulationFrame BellySimulationFrame;

		public Entity Belly;

		public AbsoluteSimulationFrame IsDeadSimulationFrame;

		public bool IsDead;

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

		public static uint HeadMask => 0u;

		public static uint LeftArmMask => 0u;

		public static uint LeftHandMask => 0u;

		public static uint RightArmMask => 0u;

		public static uint RightHandMask => 0u;

		public static uint LeftThighMask => 0u;

		public static uint LeftLegMask => 0u;

		public static uint RightThighMask => 0u;

		public static uint RightLegMask => 0u;

		public static uint BellyMask => 0u;

		public static uint IsDeadMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _681fb067cbba7f147916b4995c9b2aaa_3052872722611824889 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_681fb067cbba7f147916b4995c9b2aaa_3052872722611824889);
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

		public static uint Serialize(_681fb067cbba7f147916b4995c9b2aaa_3052872722611824889 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _681fb067cbba7f147916b4995c9b2aaa_3052872722611824889 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_681fb067cbba7f147916b4995c9b2aaa_3052872722611824889);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
