using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.Serializer;
using Coherence.SimulationFrame;
using UnityEngine;

namespace Coherence.Generated
{
	public struct _20976c99945ba92458236101a7c5aafd_7605943528661137650 : ICoherenceComponentData
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
			public float ReloadSpeed;

			[FieldOffset(23)]
			public Entity CharacterToCopy;

			[FieldOffset(27)]
			public float WeaponUsageCooldown;

			[FieldOffset(31)]
			public Vector2 SpritePosition;

			[FieldOffset(39)]
			public Vector2 CurrentDirectionSynced;

			[FieldOffset(47)]
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

		public AbsoluteSimulationFrame ReloadSpeedSimulationFrame;

		public float ReloadSpeed;

		public AbsoluteSimulationFrame CharacterToCopySimulationFrame;

		public Entity CharacterToCopy;

		public AbsoluteSimulationFrame WeaponUsageCooldownSimulationFrame;

		public float WeaponUsageCooldown;

		public AbsoluteSimulationFrame SpritePositionSimulationFrame;

		public Vector2 SpritePosition;

		public AbsoluteSimulationFrame CurrentDirectionSyncedSimulationFrame;

		public Vector2 CurrentDirectionSynced;

		public AbsoluteSimulationFrame IsDeadSimulationFrame;

		public bool IsDead;

		public const int order = 0;

		private long[] simulationFrames;

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

		public static uint ReloadSpeedMask => 0u;

		public static uint CharacterToCopyMask => 0u;

		public static uint WeaponUsageCooldownMask => 0u;

		public static uint SpritePositionMask => 0u;

		public static uint CurrentDirectionSyncedMask => 0u;

		public static uint IsDeadMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _20976c99945ba92458236101a7c5aafd_7605943528661137650 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_20976c99945ba92458236101a7c5aafd_7605943528661137650);
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

		public static uint Serialize(_20976c99945ba92458236101a7c5aafd_7605943528661137650 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Coherence.Log.Logger logger)
		{
			return 0u;
		}

		public static _20976c99945ba92458236101a7c5aafd_7605943528661137650 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_20976c99945ba92458236101a7c5aafd_7605943528661137650);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
