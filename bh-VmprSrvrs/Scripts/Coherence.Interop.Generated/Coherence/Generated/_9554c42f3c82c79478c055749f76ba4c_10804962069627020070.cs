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
	public struct _9554c42f3c82c79478c055749f76ba4c_10804962069627020070 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint RewardSeed;

			[FieldOffset(4)]
			public int SyncedPickupType;

			[FieldOffset(8)]
			public byte IsStagePickup;

			[FieldOffset(9)]
			public ByteArray SpriteName;

			[FieldOffset(25)]
			public float Value;

			[FieldOffset(29)]
			public byte IgnoreMadGroove;

			[FieldOffset(30)]
			public byte DisableGet;

			[FieldOffset(31)]
			public uint CatTypeSeed;
		}

		public AbsoluteSimulationFrame RewardSeedSimulationFrame;

		public uint RewardSeed;

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

		public AbsoluteSimulationFrame CatTypeSeedSimulationFrame;

		public uint CatTypeSeed;

		public const int order = 0;

		private static readonly uint _RewardSeed_Min;

		private static readonly uint _RewardSeed_Max;

		private static readonly int _SyncedPickupType_Min;

		private static readonly int _SyncedPickupType_Max;

		private static readonly uint _CatTypeSeed_Min;

		private static readonly uint _CatTypeSeed_Max;

		public static uint RewardSeedMask => 0u;

		public static uint SyncedPickupTypeMask => 0u;

		public static uint IsStagePickupMask => 0u;

		public static uint SpriteNameMask => 0u;

		public static uint ValueMask => 0u;

		public static uint IgnoreMadGrooveMask => 0u;

		public static uint DisableGetMask => 0u;

		public static uint CatTypeSeedMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _9554c42f3c82c79478c055749f76ba4c_10804962069627020070 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_9554c42f3c82c79478c055749f76ba4c_10804962069627020070);
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

		public static uint Serialize(_9554c42f3c82c79478c055749f76ba4c_10804962069627020070 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _9554c42f3c82c79478c055749f76ba4c_10804962069627020070 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_9554c42f3c82c79478c055749f76ba4c_10804962069627020070);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
