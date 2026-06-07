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
	public struct _f04546503722c8f4cb717afd85d8934e_17711460836336830180 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int SelectedStage;

			[FieldOffset(4)]
			public byte SelectedHyper;

			[FieldOffset(5)]
			public byte SelectedHurry;

			[FieldOffset(6)]
			public byte SelectedInverse;

			[FieldOffset(7)]
			public byte SelectedReapers;

			[FieldOffset(8)]
			public byte SelectedMazzo;

			[FieldOffset(9)]
			public byte SelectedRandomEvents;

			[FieldOffset(10)]
			public byte HasKilledTheFinalBoss;

			[FieldOffset(11)]
			public byte HasSeenFinalFireworks;

			[FieldOffset(12)]
			public byte SelectedSharePassives;

			[FieldOffset(13)]
			public byte HasSeenDarkanaTransition;

			[FieldOffset(14)]
			public int SelectedArcana;

			[FieldOffset(18)]
			public byte SelectedOnlineFreeRoam;

			[FieldOffset(19)]
			public byte VisuallyInvert;

			[FieldOffset(20)]
			public int EME_NextBossBiome;

			[FieldOffset(24)]
			public int SelectedBGM;
		}

		public AbsoluteSimulationFrame SelectedStageSimulationFrame;

		public int SelectedStage;

		public AbsoluteSimulationFrame SelectedHyperSimulationFrame;

		public bool SelectedHyper;

		public AbsoluteSimulationFrame SelectedHurrySimulationFrame;

		public bool SelectedHurry;

		public AbsoluteSimulationFrame SelectedInverseSimulationFrame;

		public bool SelectedInverse;

		public AbsoluteSimulationFrame SelectedReapersSimulationFrame;

		public bool SelectedReapers;

		public AbsoluteSimulationFrame SelectedMazzoSimulationFrame;

		public bool SelectedMazzo;

		public AbsoluteSimulationFrame SelectedRandomEventsSimulationFrame;

		public bool SelectedRandomEvents;

		public AbsoluteSimulationFrame HasKilledTheFinalBossSimulationFrame;

		public bool HasKilledTheFinalBoss;

		public AbsoluteSimulationFrame HasSeenFinalFireworksSimulationFrame;

		public bool HasSeenFinalFireworks;

		public AbsoluteSimulationFrame SelectedSharePassivesSimulationFrame;

		public bool SelectedSharePassives;

		public AbsoluteSimulationFrame HasSeenDarkanaTransitionSimulationFrame;

		public bool HasSeenDarkanaTransition;

		public AbsoluteSimulationFrame SelectedArcanaSimulationFrame;

		public int SelectedArcana;

		public AbsoluteSimulationFrame SelectedOnlineFreeRoamSimulationFrame;

		public bool SelectedOnlineFreeRoam;

		public AbsoluteSimulationFrame VisuallyInvertSimulationFrame;

		public bool VisuallyInvert;

		public AbsoluteSimulationFrame EME_NextBossBiomeSimulationFrame;

		public int EME_NextBossBiome;

		public AbsoluteSimulationFrame SelectedBGMSimulationFrame;

		public int SelectedBGM;

		public const int order = 0;

		private static readonly int _SelectedStage_Min;

		private static readonly int _SelectedStage_Max;

		private static readonly int _SelectedArcana_Min;

		private static readonly int _SelectedArcana_Max;

		private static readonly int _EME_NextBossBiome_Min;

		private static readonly int _EME_NextBossBiome_Max;

		private static readonly int _SelectedBGM_Min;

		private static readonly int _SelectedBGM_Max;

		public static uint SelectedStageMask => 0u;

		public static uint SelectedHyperMask => 0u;

		public static uint SelectedHurryMask => 0u;

		public static uint SelectedInverseMask => 0u;

		public static uint SelectedReapersMask => 0u;

		public static uint SelectedMazzoMask => 0u;

		public static uint SelectedRandomEventsMask => 0u;

		public static uint HasKilledTheFinalBossMask => 0u;

		public static uint HasSeenFinalFireworksMask => 0u;

		public static uint SelectedSharePassivesMask => 0u;

		public static uint HasSeenDarkanaTransitionMask => 0u;

		public static uint SelectedArcanaMask => 0u;

		public static uint SelectedOnlineFreeRoamMask => 0u;

		public static uint VisuallyInvertMask => 0u;

		public static uint EME_NextBossBiomeMask => 0u;

		public static uint SelectedBGMMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _f04546503722c8f4cb717afd85d8934e_17711460836336830180 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_17711460836336830180);
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

		public static uint Serialize(_f04546503722c8f4cb717afd85d8934e_17711460836336830180 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _f04546503722c8f4cb717afd85d8934e_17711460836336830180 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_17711460836336830180);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
