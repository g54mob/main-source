using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace MagicaCloth2
{
	public class ClothProcess : IDisposable, IValid, ITransform
	{
		[BurstCompile]
		private struct GenerateSelectionJob : IJobParallelFor
		{
			public int offset;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> positionList;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<VertexAttribute> attributeList;

			public int attributeMapWidth;

			public float4x4 toM;

			public int2 xySize;

			public ExBitFlag8 attributeReadFlag;

			[ReadOnly]
			public NativeArray<Color32> attributeMapData;

			[ReadOnly]
			public NativeArray<float2> uvs;

			[ReadOnly]
			public NativeArray<float3> vertexs;

			public void Execute(int vindex)
			{
			}
		}

		public class RenderMeshInfo
		{
			public MagicaObjectId renderHandle;

			public VirtualMeshContainer renderMeshContainer;

			public DataChunk mappingChunk;

			public int renderDataWorkIndex;
		}

		public class PaintMapData
		{
			public const byte ReadFlag_Fixed = 1;

			public const byte ReadFlag_Move = 2;

			public const byte ReadFlag_Limit = 4;

			public Color32[] paintData;

			public int paintMapWidth;

			public int paintMapHeight;

			public ExBitFlag8 paintReadFlag;
		}

		public enum ClothType
		{
			MeshCloth = 0,
			BoneCloth = 1,
			BoneSpring = 10
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass10_0
		{
			public CancellationToken ct;

			public VirtualMesh proxyMesh;

			public ClothProcess _003C_003E4__this;

			public List<RenderMeshInfo> renderMeshInfos;

			internal void _003CRuntimeBuildAsync_003Eb__1()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass10_1
		{
			public SelectionData selectionData;

			public ClothSerializeData sdata;

			public bool useManualVertexAttribute;

			public ClothSerializeData2 sdata2;

			public bool usePaintMap;

			public List<PaintMapData> paintMapDataList;

			public Dictionary<MagicaObjectId, VertexAttribute> boneAttributeDict;

			public _003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals1;

			internal void _003CRuntimeBuildAsync_003Eb__0()
			{
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CRuntimeBuildAsync_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken ct;

			public ClothProcess _003C_003E4__this;

			private _003C_003Ec__DisplayClass10_1 _003C_003E8__1;

			private _003C_003Ec__DisplayClass10_0 _003C_003E8__2;

			private MagicaCloth _003CsyncCloth_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private int _003CtimeOutCount_003E5__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private static readonly ProfilerMarker initClothProfiler;

		private static readonly ProfilerMarker preBuildProfiler;

		private static readonly ProfilerMarker preBuildDeserializationProfiler;

		private static readonly ProfilerMarker preBuildRegistrationProfiler;

		public const int State_Valid = 0;

		public const int State_Enable = 1;

		public const int State_InitSuccess = 3;

		public const int State_InitComplete = 4;

		public const int State_Build = 5;

		public const int State_Running = 6;

		public const int State_DisableAutoBuild = 7;

		public const int State_CameraCullingInvisible = 8;

		public const int State_CameraCullingKeep = 9;

		public const int State_SkipWriting = 10;

		public const int State_UsePreBuild = 12;

		public const int State_DistanceCullingInvisible = 13;

		public const int State_UpdateTangent = 14;

		public const int State_Component = 15;

		public const int State_Verification = 16;

		internal BitField32 stateFlag;

		internal List<MagicaObjectId> renderHandleList;

		internal RenderSetupData boneClothSetupData;

		internal List<RenderMeshInfo> renderMeshInfoList;

		internal List<TransformRecord> customSkinningBoneRecords;

		internal ResultCode result;

		private ReductionSettings reductionSettings;

		internal Dictionary<ColliderComponent, int2> colliderDict;

		internal InertiaConstraint.ConstraintData inertiaConstraintData;

		internal DistanceConstraint.ConstraintData distanceConstraintData;

		internal TriangleBendingConstraint.ConstraintData bendingConstraintData;

		internal Animator interlockingAnimator;

		internal List<Renderer> interlockingAnimatorRenderers;

		internal MagicaObjectId anchorTransformId;

		internal MagicaObjectId distanceReferenceObjectId;

		internal Animator cameraCullingAnimator;

		internal List<Renderer> cameraCullingRenderers;

		internal CullingSettings.CameraCullingMode cameraCullingMode;

		internal bool cameraCullingOldInvisible;

		private CancellationTokenSource cts;

		private object lockObject;

		private bool isDestory;

		private bool isDestoryInternal;

		private bool isBuild;

		public MagicaCloth cloth { get; internal set; }

		public MagicaCloth SyncTopCloth { get; internal set; }

		internal TransformRecord clothTransformRecord { get; private set; }

		internal TransformRecord normalAdjustmentTransformRecord { get; private set; }

		public ResultCode Result => default(ResultCode);

		public ResultCode InitDataResult { get; internal set; }

		internal ClothType clothType { get; private set; }

		public ClothParameters parameters { get; private set; }

		public VirtualMeshContainer ProxyMeshContainer { get; private set; }

		public int TeamId { get; private set; }

		public bool IsEnable => false;

		public bool HasProxyMesh => false;

		public string Name => null;

		internal void Init()
		{
		}

		private MagicaObjectId AddRenderer(Renderer ren, RenderSetupData referenceSetupData, RenderSetupData.UniqueSerializationData referenceUniqueSetupData, RenderSetupSerializeData referenceInitSetupData)
		{
			return default(MagicaObjectId);
		}

		private void CreateBoneRenderSetupData(ClothInitSerializeData initData, ClothType ctype, List<Transform> rootTransforms, List<Transform> collisionBones, RenderSetupData.BoneConnectionMode connectionMode)
		{
		}

		internal void StartUse()
		{
		}

		internal void EndUse()
		{
		}

		internal void UpdateUse()
		{
		}

		internal void DataUpdate()
		{
		}

		internal bool StartRuntimeBuild()
		{
			return false;
		}

		internal bool AutoBuild()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CRuntimeBuildAsync_003Ed__10))]
		private Task RuntimeBuildAsync(CancellationToken ct)
		{
			return null;
		}

		public ResultCode GenerateSelectionDataFromPaintMap(TransformRecord clothTransformRecord, VirtualMesh renderMesh, PaintMapData paintMapData, out SelectionData selectionData)
		{
			selectionData = null;
			return default(ResultCode);
		}

		public ResultCode GeneratePaintMapDataList(List<PaintMapData> dataList)
		{
			return default(ResultCode);
		}

		public ResultCode GenerateSelectionDataFromVertexAttributeData(TransformRecord clothTransformRecord, VirtualMesh renderMesh, VertexAttribute[] vertexAttributeArray, out SelectionData selectionData)
		{
			selectionData = null;
			return default(ResultCode);
		}

		internal bool PreBuildDataConstruction()
		{
			return false;
		}

		internal void UpdateCullingAnimatorAndRenderers()
		{
		}

		internal void UpdateRendererUse()
		{
		}

		public BitField32 GetStateFlag()
		{
			return default(BitField32);
		}

		public bool IsState(int state)
		{
			return false;
		}

		public void SetState(int state, bool sw)
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public bool IsRunning()
		{
			return false;
		}

		public bool IsCameraCullingInvisible()
		{
			return false;
		}

		public bool IsCameraCullingKeep()
		{
			return false;
		}

		public bool IsDistanceCullingInvisible()
		{
			return false;
		}

		public bool IsSkipWriting()
		{
			return false;
		}

		public bool IsUpdateTangent()
		{
			return false;
		}

		public void Dispose()
		{
		}

		private void DisposeInternal()
		{
		}

		internal void IncrementSuspendCounter()
		{
		}

		internal void DecrementSuspendCounter()
		{
		}

		internal int GetSuspendCounter()
		{
			return 0;
		}

		public RenderMeshInfo GetRenderMeshInfo(int index)
		{
			return null;
		}

		internal void SyncParameters()
		{
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}

		internal void SetSkipWriting(bool sw)
		{
		}

		internal ClothUpdateMode GetClothUpdateMode()
		{
			return default(ClothUpdateMode);
		}

		public ResultCode GenerateStatusCheck()
		{
			return default(ResultCode);
		}

		internal bool GenerateInitialization()
		{
			return false;
		}

		internal bool GenerateBoneClothSelection()
		{
			return false;
		}
	}
}
