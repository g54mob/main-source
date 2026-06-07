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
	public struct _dc972107923b01d4b9d7a95b4d513916_5003902597528061878 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int SyncedCharacterType;

			[FieldOffset(4)]
			public byte IsFlipped;

			[FieldOffset(5)]
			public float CurrentHp;

			[FieldOffset(9)]
			public uint RandomEnemyPickerSeed;

			[FieldOffset(13)]
			public int SyncedPickupMode;

			[FieldOffset(17)]
			public uint FollowerLevelUpShuffleSeed;

			[FieldOffset(21)]
			public Vector2 CurrentDirectionRaw;

			[FieldOffset(29)]
			public float Xp;

			[FieldOffset(33)]
			public byte IsFollower;

			[FieldOffset(34)]
			public Entity FollowedCharacter;

			[FieldOffset(38)]
			public int FollowerLevelUpType;

			[FieldOffset(42)]
			public byte ShowHealthBar;

			[FieldOffset(43)]
			public float HealthBarScale;

			[FieldOffset(47)]
			public byte TrackedByCamera;

			[FieldOffset(48)]
			public byte CountsAsMainCharacterForRevivals;

			[FieldOffset(49)]
			public byte PermanentInvulnerability;

			[FieldOffset(50)]
			public byte IsFollowerSharingPassives;

			[FieldOffset(51)]
			public byte IsFollowerReactingToArcanas;

			[FieldOffset(52)]
			public int SyncedSkinType;

			[FieldOffset(56)]
			public Vector2 CurrentDefaultMapPosition;
		}

		public AbsoluteSimulationFrame SyncedCharacterTypeSimulationFrame;

		public int SyncedCharacterType;

		public AbsoluteSimulationFrame IsFlippedSimulationFrame;

		public bool IsFlipped;

		public AbsoluteSimulationFrame CurrentHpSimulationFrame;

		public float CurrentHp;

		public AbsoluteSimulationFrame RandomEnemyPickerSeedSimulationFrame;

		public uint RandomEnemyPickerSeed;

		public AbsoluteSimulationFrame SyncedPickupModeSimulationFrame;

		public int SyncedPickupMode;

		public AbsoluteSimulationFrame FollowerLevelUpShuffleSeedSimulationFrame;

		public uint FollowerLevelUpShuffleSeed;

		public AbsoluteSimulationFrame CurrentDirectionRawSimulationFrame;

		public Vector2 CurrentDirectionRaw;

		public AbsoluteSimulationFrame XpSimulationFrame;

		public float Xp;

		public AbsoluteSimulationFrame IsFollowerSimulationFrame;

		public bool IsFollower;

		public AbsoluteSimulationFrame FollowedCharacterSimulationFrame;

		public Entity FollowedCharacter;

		public AbsoluteSimulationFrame FollowerLevelUpTypeSimulationFrame;

		public int FollowerLevelUpType;

		public AbsoluteSimulationFrame ShowHealthBarSimulationFrame;

		public bool ShowHealthBar;

		public AbsoluteSimulationFrame HealthBarScaleSimulationFrame;

		public float HealthBarScale;

		public AbsoluteSimulationFrame TrackedByCameraSimulationFrame;

		public bool TrackedByCamera;

		public AbsoluteSimulationFrame CountsAsMainCharacterForRevivalsSimulationFrame;

		public bool CountsAsMainCharacterForRevivals;

		public AbsoluteSimulationFrame PermanentInvulnerabilitySimulationFrame;

		public bool PermanentInvulnerability;

		public AbsoluteSimulationFrame IsFollowerSharingPassivesSimulationFrame;

		public bool IsFollowerSharingPassives;

		public AbsoluteSimulationFrame IsFollowerReactingToArcanasSimulationFrame;

		public bool IsFollowerReactingToArcanas;

		public AbsoluteSimulationFrame SyncedSkinTypeSimulationFrame;

		public int SyncedSkinType;

		public AbsoluteSimulationFrame CurrentDefaultMapPositionSimulationFrame;

		public Vector2 CurrentDefaultMapPosition;

		public const int order = 0;

		private static readonly int _SyncedCharacterType_Min;

		private static readonly int _SyncedCharacterType_Max;

		private static readonly uint _RandomEnemyPickerSeed_Min;

		private static readonly uint _RandomEnemyPickerSeed_Max;

		private static readonly int _SyncedPickupMode_Min;

		private static readonly int _SyncedPickupMode_Max;

		private static readonly uint _FollowerLevelUpShuffleSeed_Min;

		private static readonly uint _FollowerLevelUpShuffleSeed_Max;

		private static readonly int _FollowerLevelUpType_Min;

		private static readonly int _FollowerLevelUpType_Max;

		private static readonly int _SyncedSkinType_Min;

		private static readonly int _SyncedSkinType_Max;

		public static uint SyncedCharacterTypeMask => 0u;

		public static uint IsFlippedMask => 0u;

		public static uint CurrentHpMask => 0u;

		public static uint RandomEnemyPickerSeedMask => 0u;

		public static uint SyncedPickupModeMask => 0u;

		public static uint FollowerLevelUpShuffleSeedMask => 0u;

		public static uint CurrentDirectionRawMask => 0u;

		public static uint XpMask => 0u;

		public static uint IsFollowerMask => 0u;

		public static uint FollowedCharacterMask => 0u;

		public static uint FollowerLevelUpTypeMask => 0u;

		public static uint ShowHealthBarMask => 0u;

		public static uint HealthBarScaleMask => 0u;

		public static uint TrackedByCameraMask => 0u;

		public static uint CountsAsMainCharacterForRevivalsMask => 0u;

		public static uint PermanentInvulnerabilityMask => 0u;

		public static uint IsFollowerSharingPassivesMask => 0u;

		public static uint IsFollowerReactingToArcanasMask => 0u;

		public static uint SyncedSkinTypeMask => 0u;

		public static uint CurrentDefaultMapPositionMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _dc972107923b01d4b9d7a95b4d513916_5003902597528061878 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_dc972107923b01d4b9d7a95b4d513916_5003902597528061878);
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

		public static uint Serialize(_dc972107923b01d4b9d7a95b4d513916_5003902597528061878 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Coherence.Log.Logger logger)
		{
			return 0u;
		}

		public static _dc972107923b01d4b9d7a95b4d513916_5003902597528061878 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_dc972107923b01d4b9d7a95b4d513916_5003902597528061878);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
