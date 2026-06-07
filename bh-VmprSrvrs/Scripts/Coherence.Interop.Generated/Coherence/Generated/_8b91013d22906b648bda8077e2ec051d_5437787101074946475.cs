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
	public struct _8b91013d22906b648bda8077e2ec051d_5437787101074946475 : ICoherenceComponentData
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int SelectedCharacter;

			[FieldOffset(4)]
			public byte IsReadyToPlay;

			[FieldOffset(5)]
			public byte GameplayLoaded;

			[FieldOffset(6)]
			public Entity CharacterEntity;

			[FieldOffset(10)]
			public int AverageLatencyMs;

			[FieldOffset(14)]
			public byte SceneLoaded;

			[FieldOffset(15)]
			public byte StageInitialized;

			[FieldOffset(16)]
			public int SuggestedLevelUp;

			[FieldOffset(20)]
			public byte IsInBanishMode;

			[FieldOffset(21)]
			public byte HasGameplayUiActive;

			[FieldOffset(22)]
			public ByteArray UserName;

			[FieldOffset(38)]
			public int UiPageId;

			[FieldOffset(42)]
			public int SelectedSkin;

			[FieldOffset(46)]
			public byte IsReadyToStartCharacterSelect;
		}

		public AbsoluteSimulationFrame SelectedCharacterSimulationFrame;

		public int SelectedCharacter;

		public AbsoluteSimulationFrame IsReadyToPlaySimulationFrame;

		public bool IsReadyToPlay;

		public AbsoluteSimulationFrame GameplayLoadedSimulationFrame;

		public bool GameplayLoaded;

		public AbsoluteSimulationFrame CharacterEntitySimulationFrame;

		public Entity CharacterEntity;

		public AbsoluteSimulationFrame AverageLatencyMsSimulationFrame;

		public int AverageLatencyMs;

		public AbsoluteSimulationFrame SceneLoadedSimulationFrame;

		public bool SceneLoaded;

		public AbsoluteSimulationFrame StageInitializedSimulationFrame;

		public bool StageInitialized;

		public AbsoluteSimulationFrame SuggestedLevelUpSimulationFrame;

		public int SuggestedLevelUp;

		public AbsoluteSimulationFrame IsInBanishModeSimulationFrame;

		public bool IsInBanishMode;

		public AbsoluteSimulationFrame HasGameplayUiActiveSimulationFrame;

		public bool HasGameplayUiActive;

		public AbsoluteSimulationFrame UserNameSimulationFrame;

		public string UserName;

		public AbsoluteSimulationFrame UiPageIdSimulationFrame;

		public int UiPageId;

		public AbsoluteSimulationFrame SelectedSkinSimulationFrame;

		public int SelectedSkin;

		public AbsoluteSimulationFrame IsReadyToStartCharacterSelectSimulationFrame;

		public bool IsReadyToStartCharacterSelect;

		public const int order = 0;

		private static readonly int _SelectedCharacter_Min;

		private static readonly int _SelectedCharacter_Max;

		private static readonly int _AverageLatencyMs_Min;

		private static readonly int _AverageLatencyMs_Max;

		private static readonly int _SuggestedLevelUp_Min;

		private static readonly int _SuggestedLevelUp_Max;

		private static readonly int _UiPageId_Min;

		private static readonly int _UiPageId_Max;

		private static readonly int _SelectedSkin_Min;

		private static readonly int _SelectedSkin_Max;

		public static uint SelectedCharacterMask => 0u;

		public static uint IsReadyToPlayMask => 0u;

		public static uint GameplayLoadedMask => 0u;

		public static uint CharacterEntityMask => 0u;

		public static uint AverageLatencyMsMask => 0u;

		public static uint SceneLoadedMask => 0u;

		public static uint StageInitializedMask => 0u;

		public static uint SuggestedLevelUpMask => 0u;

		public static uint IsInBanishModeMask => 0u;

		public static uint HasGameplayUiActiveMask => 0u;

		public static uint UserNameMask => 0u;

		public static uint UiPageIdMask => 0u;

		public static uint SelectedSkinMask => 0u;

		public static uint IsReadyToStartCharacterSelectMask => 0u;

		public uint FieldsMask { get; set; }

		public uint StoppedMask { get; set; }

		public void ResetFrame(AbsoluteSimulationFrame frame)
		{
		}

		public unsafe static _8b91013d22906b648bda8077e2ec051d_5437787101074946475 FromInterop(IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return default(_8b91013d22906b648bda8077e2ec051d_5437787101074946475);
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

		public static uint Serialize(_8b91013d22906b648bda8077e2ec051d_5437787101074946475 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
		{
			return 0u;
		}

		public static _8b91013d22906b648bda8077e2ec051d_5437787101074946475 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
		{
			return default(_8b91013d22906b648bda8077e2ec051d_5437787101074946475);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
