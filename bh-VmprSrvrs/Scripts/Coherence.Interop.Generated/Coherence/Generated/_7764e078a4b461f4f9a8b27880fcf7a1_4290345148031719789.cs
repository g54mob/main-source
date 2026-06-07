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
	public struct _7764e078a4b461f4f9a8b27880fcf7a1_4290345148031719789 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint _deathSeed;

			[FieldOffset(4)]
			public int PropType;
		}

		public AbsoluteSimulationFrame _deathSeedSimulationFrame;

		public uint _deathSeed;

		public AbsoluteSimulationFrame PropTypeSimulationFrame;

		public int PropType;

		public const int order = 0;

		private static readonly uint __deathSeed_Min;

		private static readonly uint __deathSeed_Max;

		private static readonly int _PropType_Min;

		private static readonly int _PropType_Max;

		public static uint _deathSeedMask => 0u;

		public static uint PropTypeMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _7764e078a4b461f4f9a8b27880fcf7a1_4290345148031719789 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_7764e078a4b461f4f9a8b27880fcf7a1_4290345148031719789);
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

		public static uint Serialize(_7764e078a4b461f4f9a8b27880fcf7a1_4290345148031719789 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _7764e078a4b461f4f9a8b27880fcf7a1_4290345148031719789 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_7764e078a4b461f4f9a8b27880fcf7a1_4290345148031719789);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
