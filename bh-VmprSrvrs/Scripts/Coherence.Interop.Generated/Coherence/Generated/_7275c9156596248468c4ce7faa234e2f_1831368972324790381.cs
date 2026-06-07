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
	public struct _7275c9156596248468c4ce7faa234e2f_1831368972324790381 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int SyncedPickupType;

			[FieldOffset(4)]
			public ByteArray SerializedTreasure;

			[FieldOffset(20)]
			public byte IsStagePickup;

			[FieldOffset(21)]
			public ByteArray SpriteName;

			[FieldOffset(37)]
			public float Value;

			[FieldOffset(41)]
			public byte IgnoreMadGroove;

			[FieldOffset(42)]
			public byte DisableGet;
		}

		public AbsoluteSimulationFrame SyncedPickupTypeSimulationFrame;

		public int SyncedPickupType;

		public AbsoluteSimulationFrame SerializedTreasureSimulationFrame;

		public byte[] SerializedTreasure;

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

		public const int order = 0;

		private static readonly int _SyncedPickupType_Min;

		private static readonly int _SyncedPickupType_Max;

		public static uint SyncedPickupTypeMask => 0u;

		public static uint SerializedTreasureMask => 0u;

		public static uint IsStagePickupMask => 0u;

		public static uint SpriteNameMask => 0u;

		public static uint ValueMask => 0u;

		public static uint IgnoreMadGrooveMask => 0u;

		public static uint DisableGetMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _7275c9156596248468c4ce7faa234e2f_1831368972324790381 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_7275c9156596248468c4ce7faa234e2f_1831368972324790381);
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

		public static uint Serialize(_7275c9156596248468c4ce7faa234e2f_1831368972324790381 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _7275c9156596248468c4ce7faa234e2f_1831368972324790381 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_7275c9156596248468c4ce7faa234e2f_1831368972324790381);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
