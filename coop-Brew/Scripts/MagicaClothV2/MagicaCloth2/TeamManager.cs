using System;
using System.Collections.Generic;
using System.Text;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;

namespace MagicaCloth2
{
	public class TeamManager : IManager, IDisposable, IValid
	{
		public struct TeamData
		{
			public BitField64 flag;

			public ClothUpdateMode originalUpdateMode;

			public ClothUpdateMode updateMode;

			public float frameDeltaTime;

			public float time;

			public float oldTime;

			public float nowUpdateTime;

			public float oldUpdateTime;

			public float frameUpdateTime;

			public float frameOldTime;

			public float timeScale;

			public float nowTimeScale;

			public int updateCount;

			public int skipCount;

			public float frameInterpolation;

			public float gravityRatio;

			public float gravityDot;

			public int centerTransformIndex;

			public int distanceReferenceObjectId;

			public int componentTransformIndex;

			public float3 initScale;

			public float scaleRatio;

			public float negativeScaleSign;

			public float3 negativeScaleDirection;

			public float3 negativeScaleChange;

			public float2 negativeScaleTriangleSign;

			public float4 negativeScaleQuaternionValue;

			public MagicaObjectId componentId;

			public int syncTeamId;

			public FixedList32Bytes<int> syncParentTeamId;

			public int syncCenterTransformIndex;

			public MagicaObjectId interlockingAnimatorId;

			public float animationPoseRatio;

			public float velocityWeight;

			public float distanceWeight;

			public float blendWeight;

			public ClothForceMode forceMode;

			public float3 impactForce;

			public VirtualMesh.MeshType proxyMeshType;

			public DataChunk proxyTransformChunk;

			public DataChunk proxyCommonChunk;

			public DataChunk proxyVertexChildDataChunk;

			public DataChunk proxyTriangleChunk;

			public DataChunk proxyEdgeChunk;

			public DataChunk proxyMeshChunk;

			public DataChunk proxyBoneChunk;

			public DataChunk proxySkinBoneChunk;

			public DataChunk baseLineChunk;

			public DataChunk baseLineDataChunk;

			public DataChunk fixedDataChunk;

			public DataChunk particleChunk;

			public DataChunk colliderChunk;

			public DataChunk colliderTransformChunk;

			public int colliderCount;

			public DataChunk distanceStartChunk;

			public DataChunk distanceDataChunk;

			public DataChunk bendingPairChunk;

			public DataChunk selfPointChunk;

			public DataChunk selfEdgeChunk;

			public DataChunk selfTriangleChunk;

			public float selfGridSize;

			public int selfPointGridCount;

			public int selfEdgeGridCount;

			public int selfTriangleGridCount;

			public float selfMaxPrimitiveSize;

			public bool IsFixedUpdate => false;

			public bool IsUnscaled => false;

			public bool IsValid => false;

			public bool IsEnable => false;

			public bool IsProcess => false;

			public bool IsReset => false;

			public bool IsKeepReset => false;

			public bool IsInertiaShift => false;

			public bool IsRunning => false;

			public bool IsStepRunning => false;

			public bool IsCameraCullingInvisible => false;

			public bool IsCameraCullingKeep => false;

			public bool IsDistanceCullingInvisible => false;

			public bool IsCullingInvisible => false;

			public bool IsSpring => false;

			public bool IsNegativeScale => false;

			public bool IsNegativeScaleTeleport => false;

			public bool IsTangent => false;

			public bool IsScaleSuspend => false;

			public int ParticleCount => 0;

			public int UseColliderCount => 0;

			public int BaseLineCount => 0;

			public int TriangleCount => 0;

			public int EdgeCount => 0;

			public float InitScale => 0f;
		}

		public struct MappingData : IValid
		{
			public int teamId;

			public BitField32 flag;

			public int centerTransformIndex;

			public DataChunk mappingCommonChunk;

			public float4x4 toProxyMatrix;

			public quaternion toProxyRotation;

			public bool sameSpace;

			public float4x4 toMappingMatrix;

			public quaternion toMappingRotation;

			public float scaleRatio;

			public int renderDataWorkIndex;

			public int VertexCount => 0;

			public bool IsValid()
			{
				return false;
			}
		}

		[BurstCompile]
		private struct AlwaysTeamUpdatePreJob : IJob
		{
			public NativeArray<TeamData> teamDataArray;

			public NativeArray<ClothParameters> parameterArray;

			public NativeParallelHashMap<MagicaObjectId, int> comp2SuspendCounterMap;

			public NativeParallelHashMap<MagicaObjectId, int> comp2TeamIdMap;

			public NativeParallelHashMap<MagicaObjectId, MagicaObjectId> comp2SyncPartnerCompMap;

			public NativeParallelHashMap<MagicaObjectId, MagicaObjectId> comp2SyncTopCompMap;

			public NativeParallelHashSet<int> selfCollisionUpdateSet;

			public NativeReference<int> edgeColliderCollisionCountBuff;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct AlwaysTeamUpdatePostJob : IJob
		{
			public int teamCount;

			public float unityFrameDeltaTime;

			public float unityFrameFixedDeltaTime;

			public float unityFrameUnscaledDeltaTime;

			public float globalTimeScale;

			public float simulationDeltaTime;

			public int maxSimmulationCountPerFrame;

			public int splitProxyMeshVertexCount;

			public NativeReference<int4> teamStatus;

			public NativeArray<TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			public NativeArray<float3> componentPositionArray;

			public NativeArray<float> componentMinScaleArray;

			public bool hasMainCamera;

			public NativeParallelHashMap<MagicaObjectId, int> comp2TeamIdMap;

			public NativeParallelHashMap<MagicaObjectId, MagicaObjectId> comp2SyncTopCompMap;

			public NativeParallelHashMap<MagicaObjectId, int> animatorUpdateModeMap;

			public NativeArray<MagicaObjectId> teamAnchorTransformIndexArray;

			public NativeArray<MagicaObjectId> teamDistanceTransformIndexArray;

			public NativeParallelHashMap<MagicaObjectId, float3> transformPositionMap;

			public NativeParallelHashMap<MagicaObjectId, quaternion> transformRotationMap;

			public NativeList<int> cullingDirtyList;

			public NativeList<int> batchNormalClothTeamList;

			public NativeList<int> batchSplitClothTeamList;

			public void Execute()
			{
			}

			private void DistanceCullingUpdate(int teamId, ref TeamData tdata, ref ClothParameters param)
			{
			}
		}

		public const int Flag_Valid = 0;

		public const int Flag_Enable = 1;

		public const int Flag_Reset = 2;

		public const int Flag_TimeReset = 3;

		public const int Flag_SyncSuspend = 4;

		public const int Flag_Running = 5;

		public const int Flag_Synchronization = 6;

		public const int Flag_StepRunning = 7;

		public const int Flag_Exit = 8;

		public const int Flag_KeepTeleport = 9;

		public const int Flag_InertiaShift = 10;

		public const int Flag_CameraCullingInvisible = 11;

		public const int Flag_CameraCullingKeep = 12;

		public const int Flag_Spring = 13;

		public const int Flag_SkipWriting = 14;

		public const int Flag_Anchor = 15;

		public const int Flag_AnchorReset = 16;

		public const int Flag_NegativeScale = 17;

		public const int Flag_NegativeScaleTeleport = 18;

		public const int Flag_DistanceCullingInvisible = 19;

		public const int Flag_RestoreTransformOnlyOnec = 20;

		public const int Flag_Tangent = 21;

		public const int Flag_ScaleSuspent = 22;

		public const int Flag_ProxyMeshLine = 23;

		public const int Flag_Self_PointPrimitive = 32;

		public const int Flag_Self_EdgePrimitive = 33;

		public const int Flag_Self_TrianglePrimitive = 34;

		public const int Flag_Self_EdgeEdge = 35;

		public const int Flag_Sync_EdgeEdge = 36;

		public const int Flag_PSync_EdgeEdge = 37;

		public const int Flag_Self_PointTriangle = 38;

		public const int Flag_Sync_PointTriangle = 39;

		public const int Flag_PSync_PointTriangle = 40;

		public const int Flag_Self_TrianglePoint = 41;

		public const int Flag_Sync_TrianglePoint = 42;

		public const int Flag_PSync_TrianglePoint = 43;

		public const int Flag_Self_EdgeTriangleIntersect = 44;

		public const int Flag_Sync_EdgeTriangleIntersect = 45;

		public const int Flag_PSync_EdgeTriangleIntersect = 46;

		public const int Flag_Self_TriangleEdgeIntersect = 47;

		public const int Flag_Sync_TriangleEdgeIntersect = 48;

		public const int Flag_PSync_TriangleEdgeIntersect = 49;

		public ExNativeArray<TeamData> teamDataArray;

		public ExNativeArray<TeamWindData> teamWindArray;

		public const int MappingDataFlag_ChangePositionNormal = 0;

		public const int MappingDataFlag_ChangeTangent = 1;

		public const int MappingDataFlag_ChangeBoneWeight = 2;

		public const int MappingDataFlag_ModifyBoneWeight = 3;

		public ExNativeArray<MappingData> mappingDataArray;

		public ExNativeArray<FixedList64Bytes<short>> teamMappingIndexArray;

		public NativeReference<int4> teamStatus;

		public ExNativeArray<ClothParameters> parameterArray;

		public ExNativeArray<InertiaConstraint.CenterData> centerDataArray;

		private HashSet<int> enableTeamSet;

		private Dictionary<int, ClothProcess> clothProcessDict;

		private bool isValid;

		internal int edgeColliderCollisionCount;

		internal NativeReference<int> edgeColliderCollisionCountBuff;

		internal NativeParallelHashMap<MagicaObjectId, int> comp2SuspendCounterMap;

		internal NativeParallelHashMap<MagicaObjectId, int> comp2TeamIdMap;

		internal NativeParallelHashMap<MagicaObjectId, MagicaObjectId> comp2SyncPartnerCompMap;

		internal NativeParallelHashMap<MagicaObjectId, MagicaObjectId> comp2SyncTopCompMap;

		internal NativeList<int> batchNormalClothTeamList;

		internal NativeList<int> batchSplitClothTeamList;

		internal List<ClothProcess> parameterDirtyList;

		internal List<ClothProcess> skipWritingDirtyList;

		internal NativeList<int> cullingDirtyList;

		internal NativeParallelHashSet<int> selfCollisionUpdateSet;

		internal NativeParallelHashMap<MagicaObjectId, int> animatorUpdateModeMap;

		internal ExSimpleNativeArray<MagicaObjectId> teamAnchorTransformIndexArray;

		internal ExSimpleNativeArray<MagicaObjectId> teamDistanceTransformIndexArray;

		internal NativeParallelHashMap<MagicaObjectId, float3> transformPositionMap;

		internal NativeParallelHashMap<MagicaObjectId, quaternion> transformRotationMap;

		internal HashSet<MagicaCloth> cameraCullingClothSet;

		private static readonly ProfilerMarker teamCameraCullingPreProfiler;

		private static readonly ProfilerMarker teamCameraCullingProfiler;

		private static readonly ProfilerMarker startClothUpdateComponentProfiler;

		private HashSet<ClothProcess> monitoringProcessSet;

		private List<ClothProcess> disposeProcessList;

		public int MappingCount => 0;

		public int TeamCount => 0;

		public int TrueTeamCount => 0;

		public int ActiveTeamCount => 0;

		public int TeamMaxUpdateCount => 0;

		public void Dispose()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Initialize()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		internal int AddTeam(ClothProcess cprocess, ClothParameters clothParams)
		{
			return 0;
		}

		internal void RemoveTeam(int teamId)
		{
		}

		public void SetEnable(ClothProcess cprocess, int teamId, bool sw)
		{
		}

		public bool IsEnable(int teamId)
		{
			return false;
		}

		internal void SetSkipWriting(int teamId, bool sw)
		{
		}

		public bool ContainsTeamData(int teamId)
		{
			return false;
		}

		public ref TeamData GetTeamDataRef(int teamId)
		{
			throw null;
		}

		public ref FixedList64Bytes<short> GetTeamMappingRef(int teamId)
		{
			throw null;
		}

		public ref ClothParameters GetParametersRef(int teamId)
		{
			throw null;
		}

		internal ref InertiaConstraint.CenterData GetCenterDataRef(int teamId)
		{
			throw null;
		}

		internal ref MappingData GetMappingDataRef(int mindex)
		{
			throw null;
		}

		public ClothProcess GetClothProcess(int teamId)
		{
			return null;
		}

		internal void CameraCullingPreProcess()
		{
		}

		internal void CameraCullingPostProcess()
		{
		}

		internal void AlwaysTeamUpdate()
		{
		}

		internal void RemoveSyncParent(ref TeamData tdata, int parentTeamId)
		{
		}

		internal void AddMonitoringProcess(ClothProcess cprocess)
		{
		}

		internal void RemoveMonitoringProcess(ClothProcess cprocess)
		{
		}

		private void MonitoringProcess(bool force)
		{
		}

		private void MonitoringProcessUpdate()
		{
		}

		internal static void SimulationCalcCenterAndInertiaAndWind(float simulationDeltaTime, int teamId, ref TeamData tdata, ref InertiaConstraint.CenterData cdata, ref TeamWindData windData, ref ClothParameters param, in NativeArray<float3> positions, in NativeArray<quaternion> rotations, in NativeArray<quaternion> vertexBindPoseRotations, in NativeArray<ushort> fixedArray, in NativeArray<float3> transformPositionArray, in NativeArray<quaternion> transformRotationArray, in NativeArray<float3> transformScaleArray, int windZoneCount, in NativeArray<WindManager.WindData> windDataArray)
		{
		}

		internal static void SimulationStepTeamUpdate(int updateIndex, float simulationDeltaTime, int teamId, ref TeamData tdata, ref ClothParameters param, ref InertiaConstraint.CenterData cdata, ref TeamWindData wdata)
		{
		}

		private static void UpdateWind(float simulationDeltaTime, int teamId, in TeamData tdata, in WindParams windParams, in InertiaConstraint.CenterData cdata, ref TeamWindData teamWindData)
		{
		}

		private static void UpdateWindTime(ref TeamWindInfo windInfo, float frequency, float simulationDeltaTime)
		{
		}

		internal static void SimulationPostTeamUpdate(ref TeamData tdata, ref InertiaConstraint.CenterData cdata)
		{
		}

		public void InformationLog(StringBuilder allsb)
		{
		}
	}
}
