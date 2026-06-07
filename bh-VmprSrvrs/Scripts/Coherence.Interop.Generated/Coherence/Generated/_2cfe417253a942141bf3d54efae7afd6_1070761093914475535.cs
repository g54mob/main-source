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
	public struct _2cfe417253a942141bf3d54efae7afd6_1070761093914475535 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint _firstSeat;

			[FieldOffset(4)]
			public uint _secondSeat;

			[FieldOffset(8)]
			public uint _thirdSeat;

			[FieldOffset(12)]
			public uint _fourthSeat;

			[FieldOffset(16)]
			public byte ControlTimeScale;

			[FieldOffset(17)]
			public int StageEventSpawned;

			[FieldOffset(21)]
			public uint RandomEventsSeed;

			[FieldOffset(25)]
			public uint UiPageSeed;

			[FieldOffset(29)]
			public uint MinorArcanasSeed;

			[FieldOffset(33)]
			public uint SurvarotsSeed;
		}

		public AbsoluteSimulationFrame _firstSeatSimulationFrame;

		public uint _firstSeat;

		public AbsoluteSimulationFrame _secondSeatSimulationFrame;

		public uint _secondSeat;

		public AbsoluteSimulationFrame _thirdSeatSimulationFrame;

		public uint _thirdSeat;

		public AbsoluteSimulationFrame _fourthSeatSimulationFrame;

		public uint _fourthSeat;

		public AbsoluteSimulationFrame ControlTimeScaleSimulationFrame;

		public bool ControlTimeScale;

		public AbsoluteSimulationFrame StageEventSpawnedSimulationFrame;

		public int StageEventSpawned;

		public AbsoluteSimulationFrame RandomEventsSeedSimulationFrame;

		public uint RandomEventsSeed;

		public AbsoluteSimulationFrame UiPageSeedSimulationFrame;

		public uint UiPageSeed;

		public AbsoluteSimulationFrame MinorArcanasSeedSimulationFrame;

		public uint MinorArcanasSeed;

		public AbsoluteSimulationFrame SurvarotsSeedSimulationFrame;

		public uint SurvarotsSeed;

		public const int order = 0;

		private static readonly uint __firstSeat_Min;

		private static readonly uint __firstSeat_Max;

		private static readonly uint __secondSeat_Min;

		private static readonly uint __secondSeat_Max;

		private static readonly uint __thirdSeat_Min;

		private static readonly uint __thirdSeat_Max;

		private static readonly uint __fourthSeat_Min;

		private static readonly uint __fourthSeat_Max;

		private static readonly int _StageEventSpawned_Min;

		private static readonly int _StageEventSpawned_Max;

		private static readonly uint _RandomEventsSeed_Min;

		private static readonly uint _RandomEventsSeed_Max;

		private static readonly uint _UiPageSeed_Min;

		private static readonly uint _UiPageSeed_Max;

		private static readonly uint _MinorArcanasSeed_Min;

		private static readonly uint _MinorArcanasSeed_Max;

		private static readonly uint _SurvarotsSeed_Min;

		private static readonly uint _SurvarotsSeed_Max;

		public static uint _firstSeatMask => 0u;

		public static uint _secondSeatMask => 0u;

		public static uint _thirdSeatMask => 0u;

		public static uint _fourthSeatMask => 0u;

		public static uint ControlTimeScaleMask => 0u;

		public static uint StageEventSpawnedMask => 0u;

		public static uint RandomEventsSeedMask => 0u;

		public static uint UiPageSeedMask => 0u;

		public static uint MinorArcanasSeedMask => 0u;

		public static uint SurvarotsSeedMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _2cfe417253a942141bf3d54efae7afd6_1070761093914475535 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_1070761093914475535);
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

		public static uint Serialize(_2cfe417253a942141bf3d54efae7afd6_1070761093914475535 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _2cfe417253a942141bf3d54efae7afd6_1070761093914475535 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_1070761093914475535);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
