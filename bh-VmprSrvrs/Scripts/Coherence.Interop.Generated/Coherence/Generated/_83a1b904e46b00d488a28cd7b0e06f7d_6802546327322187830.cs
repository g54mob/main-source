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
	public struct _83a1b904e46b00d488a28cd7b0e06f7d_6802546327322187830 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int RnjNameIndex;

			[FieldOffset(4)]
			public ByteArray RnjSpriteName;

			[FieldOffset(20)]
			public int RnjStartingWeapon;

			[FieldOffset(24)]
			public uint MissingNoSeed;
		}

		public AbsoluteSimulationFrame RnjNameIndexSimulationFrame;

		public int RnjNameIndex;

		public AbsoluteSimulationFrame RnjSpriteNameSimulationFrame;

		public string RnjSpriteName;

		public AbsoluteSimulationFrame RnjStartingWeaponSimulationFrame;

		public int RnjStartingWeapon;

		public AbsoluteSimulationFrame MissingNoSeedSimulationFrame;

		public uint MissingNoSeed;

		public const int order = 0;

		private static readonly int _RnjNameIndex_Min;

		private static readonly int _RnjNameIndex_Max;

		private static readonly int _RnjStartingWeapon_Min;

		private static readonly int _RnjStartingWeapon_Max;

		private static readonly uint _MissingNoSeed_Min;

		private static readonly uint _MissingNoSeed_Max;

		public static uint RnjNameIndexMask => 0u;

		public static uint RnjSpriteNameMask => 0u;

		public static uint RnjStartingWeaponMask => 0u;

		public static uint MissingNoSeedMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _83a1b904e46b00d488a28cd7b0e06f7d_6802546327322187830 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_83a1b904e46b00d488a28cd7b0e06f7d_6802546327322187830);
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

		public static uint Serialize(_83a1b904e46b00d488a28cd7b0e06f7d_6802546327322187830 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _83a1b904e46b00d488a28cd7b0e06f7d_6802546327322187830 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_83a1b904e46b00d488a28cd7b0e06f7d_6802546327322187830);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
