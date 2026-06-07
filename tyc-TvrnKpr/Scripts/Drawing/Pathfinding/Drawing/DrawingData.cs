using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Drawing.Text;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pathfinding.Drawing
{
	public class DrawingData
	{
		public struct Hasher : IEquatable<Hasher>
		{
			private ulong hash;

			public static Hasher NotSupplied => default(Hasher);

			public readonly ulong Hash => 0uL;

			[Obsolete("Use the constructor instead")]
			public static Hasher Create<T>(T init)
			{
				return default(Hasher);
			}

			public void Add<T>(T hash)
			{
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public bool Equals(Hasher other)
			{
				return false;
			}
		}

		internal struct ProcessedBuilderData
		{
			public enum Type
			{
				Invalid = 0,
				Static = 1,
				Dynamic = 2,
				Persistent = 3
			}

			public struct CapturedState
			{
				public Matrix4x4 matrix;

				public Color color;
			}

			public struct MeshBuffers
			{
				public UnsafeAppendBuffer splitterOutput;

				public UnsafeAppendBuffer vertices;

				public UnsafeAppendBuffer triangles;

				public UnsafeAppendBuffer solidVertices;

				public UnsafeAppendBuffer solidTriangles;

				public UnsafeAppendBuffer textVertices;

				public UnsafeAppendBuffer textTriangles;

				public UnsafeAppendBuffer capturedState;

				public Bounds bounds;

				public MeshBuffers(Allocator allocator)
				{
					splitterOutput = default(UnsafeAppendBuffer);
					vertices = default(UnsafeAppendBuffer);
					triangles = default(UnsafeAppendBuffer);
					solidVertices = default(UnsafeAppendBuffer);
					solidTriangles = default(UnsafeAppendBuffer);
					textVertices = default(UnsafeAppendBuffer);
					textTriangles = default(UnsafeAppendBuffer);
					capturedState = default(UnsafeAppendBuffer);
					bounds = default(Bounds);
				}

				public void Dispose()
				{
				}

				private static void DisposeIfLarge(ref UnsafeAppendBuffer ls)
				{
				}

				public void DisposeIfLarge()
				{
				}
			}

			public Type type;

			public BuilderData.Meta meta;

			private bool submitted;

			public NativeArray<MeshBuffers> temporaryMeshBuffers;

			private JobHandle buildJob;

			private JobHandle splitterJob;

			public List<MeshWithType> meshes;

			private static int SubmittedJobs;

			public bool isValid => false;

			public unsafe UnsafeAppendBuffer* splitterOutputPtr => null;

			public void Init(Type type, BuilderData.Meta meta)
			{
			}

			public void SetSplitterJob(DrawingData gizmos, JobHandle splitterJob)
			{
			}

			public void SchedulePersistFilter(int version, int lastTickVersion, float time, int sceneModeVersion)
			{
			}

			public bool IsValidForCamera(Camera camera, bool allowGizmos, bool allowCameraDefault)
			{
				return false;
			}

			public void Schedule(DrawingData gizmos, ref GeometryBuilder.CameraInfo cameraInfo)
			{
			}

			public void BuildMeshes(DrawingData gizmos)
			{
			}

			public void CollectMeshes(List<RenderedMeshWithType> meshes)
			{
			}

			private void PoolMeshes(DrawingData gizmos, bool includeCustom)
			{
			}

			public void PoolDynamicMeshes(DrawingData gizmos)
			{
			}

			public void Release(DrawingData gizmos)
			{
			}

			public void Dispose()
			{
			}
		}

		internal struct SubmittedMesh
		{
			public Mesh mesh;

			public bool temporary;
		}

		[BurstCompile]
		internal struct BuilderData : IDisposable
		{
			public enum State
			{
				Free = 0,
				Reserved = 1,
				Initialized = 2,
				WaitingForSplitter = 3,
				WaitingForUserDefinedJob = 4
			}

			public struct Meta
			{
				public Hasher hasher;

				public RedrawScope redrawScope1;

				public RedrawScope redrawScope2;

				public int version;

				public bool isGizmos;

				public int sceneModeVersion;

				public int drawOrderIndex;

				public Camera[] cameraTargets;
			}

			public struct BitPackedMeta
			{
				private uint flags;

				private const int UniqueIDBitshift = 17;

				private const int IsBuiltInFlagIndex = 16;

				private const int IndexMask = 65535;

				private const int MaxDataIndex = 65535;

				public const int UniqueIdMask = 32767;

				public int dataIndex => 0;

				public int uniqueID => 0;

				public bool isBuiltInCommandBuilder => false;

				public BitPackedMeta(int dataIndex, int uniqueID, bool isBuiltInCommandBuilder)
				{
					flags = 0u;
				}

				public static bool operator ==(BitPackedMeta lhs, BitPackedMeta rhs)
				{
					return false;
				}

				public static bool operator !=(BitPackedMeta lhs, BitPackedMeta rhs)
				{
					return false;
				}

				public override bool Equals(object obj)
				{
					return false;
				}

				public override int GetHashCode()
				{
					return 0;
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			private unsafe delegate bool AnyBuffersWrittenToDelegate(UnsafeAppendBuffer* buffers, int numBuffers);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			private unsafe delegate void ResetAllBuffersToDelegate(UnsafeAppendBuffer* buffers, int numBuffers);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate bool AnyBuffersWrittenTo_000001E2_0024PostfixBurstDelegate(UnsafeAppendBuffer* buffers, int numBuffers);

			internal static class AnyBuffersWrittenTo_000001E2_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
				}

				private static IntPtr GetFunctionPointer()
				{
					return (IntPtr)0;
				}

				public unsafe static bool Invoke(UnsafeAppendBuffer* buffers, int numBuffers)
				{
					return false;
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void ResetAllBuffers_000001E3_0024PostfixBurstDelegate(UnsafeAppendBuffer* buffers, int numBuffers);

			internal static class ResetAllBuffers_000001E3_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
				}

				private static IntPtr GetFunctionPointer()
				{
					return (IntPtr)0;
				}

				public unsafe static void Invoke(UnsafeAppendBuffer* buffers, int numBuffers)
				{
				}
			}

			public BitPackedMeta packedMeta;

			public List<SubmittedMesh> meshes;

			public NativeArray<UnsafeAppendBuffer> commandBuffers;

			public bool preventDispose;

			private JobHandle splitterJob;

			private JobHandle disposeDependency;

			private AllowedDelay disposeDependencyDelay;

			private GCHandle disposeGCHandle;

			public Meta meta;

			private static int UniqueIDCounter;

			private static readonly AnyBuffersWrittenToDelegate AnyBuffersWrittenToInvoke;

			private static readonly ResetAllBuffersToDelegate ResetAllBuffersToInvoke;

			public State state { get; private set; }

			public unsafe UnsafeAppendBuffer* bufferPtr => null;

			public void Reserve(int dataIndex, bool isBuiltInCommandBuilder)
			{
			}

			public void Init(Hasher hasher, RedrawScope frameRedrawScope, RedrawScope customRedrawScope, bool isGizmos, int drawOrderIndex, int sceneModeVersion)
			{
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(AnyBuffersWrittenToDelegate))]
			private unsafe static bool AnyBuffersWrittenTo(UnsafeAppendBuffer* buffers, int numBuffers)
			{
				return false;
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(AnyBuffersWrittenToDelegate))]
			private unsafe static void ResetAllBuffers(UnsafeAppendBuffer* buffers, int numBuffers)
			{
			}

			public void SubmitWithDependency(GCHandle gcHandle, JobHandle dependency, AllowedDelay allowedDelay)
			{
			}

			public void Submit(DrawingData gizmos)
			{
			}

			public void CheckJobDependency(DrawingData gizmos, bool allowBlocking)
			{
			}

			public void Release()
			{
			}

			private void ClearData()
			{
			}

			public void Dispose()
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[MonoPInvokeCallback(typeof(AnyBuffersWrittenToDelegate))]
			public unsafe static bool AnyBuffersWrittenTo_0024BurstManaged(UnsafeAppendBuffer* buffers, int numBuffers)
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[MonoPInvokeCallback(typeof(AnyBuffersWrittenToDelegate))]
			public unsafe static void ResetAllBuffers_0024BurstManaged(UnsafeAppendBuffer* buffers, int numBuffers)
			{
			}
		}

		internal struct BuilderDataContainer : IDisposable
		{
			private BuilderData[] data;

			public int memoryUsage => 0;

			public BuilderData.BitPackedMeta Reserve(bool isBuiltInCommandBuilder)
			{
				return default(BuilderData.BitPackedMeta);
			}

			public void Release(BuilderData.BitPackedMeta meta)
			{
			}

			public bool StillExists(BuilderData.BitPackedMeta meta)
			{
				return false;
			}

			public ref BuilderData Get(BuilderData.BitPackedMeta meta)
			{
				throw null;
			}

			public void DisposeCommandBuildersWithJobDependencies(DrawingData gizmos)
			{
			}

			public void ReleaseAllUnused()
			{
			}

			public void Dispose()
			{
			}
		}

		internal struct ProcessedBuilderDataContainer
		{
			private ProcessedBuilderData[] data;

			private Dictionary<ulong, List<int>> hash2index;

			private Stack<int> freeSlots;

			private Stack<List<int>> freeLists;

			public bool isEmpty => false;

			public int memoryUsage => 0;

			public int Reserve(ProcessedBuilderData.Type type, BuilderData.Meta meta)
			{
				return 0;
			}

			public ref ProcessedBuilderData Get(int index)
			{
				throw null;
			}

			private void Release(DrawingData gizmos, int i)
			{
			}

			public void SubmitMeshes(DrawingData gizmos, Camera camera, int versionThreshold, bool allowGizmos, bool allowCameraDefault)
			{
			}

			public void PoolDynamicMeshes(DrawingData gizmos)
			{
			}

			public void CollectMeshes(int versionThreshold, List<RenderedMeshWithType> meshes, Camera camera, bool allowGizmos, bool allowCameraDefault)
			{
			}

			public void FilterOldPersistentCommands(int version, int lastTickVersion, float time, int sceneModeVersion)
			{
			}

			public bool SetVersion(Hasher hasher, int version)
			{
				return false;
			}

			public bool SetVersion(RedrawScope scope, int version)
			{
				return false;
			}

			public bool SetCustomScope(Hasher hasher, RedrawScope scope)
			{
				return false;
			}

			public void ReleaseDataOlderThan(DrawingData gizmos, int version)
			{
			}

			public void ReleaseAllWithHash(DrawingData gizmos, Hasher hasher)
			{
			}

			public void Dispose(DrawingData gizmos)
			{
			}
		}

		[Flags]
		internal enum MeshType
		{
			Solid = 1,
			Lines = 2,
			Text = 4,
			Custom = 8,
			Pool = 0x10,
			BaseType = 7
		}

		internal struct MeshWithType
		{
			public Mesh mesh;

			public MeshType type;
		}

		internal struct RenderedMeshWithType
		{
			public Mesh mesh;

			public MeshType type;

			public int drawingOrderIndex;

			public Color color;

			public Matrix4x4 matrix;
		}

		private struct Range
		{
			public int start;

			public int end;
		}

		public struct CommandBufferWrapper
		{
			public CommandBuffer cmd;

			public void SetWireframe(bool enable)
			{
			}

			public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties)
			{
			}
		}

		internal BuilderDataContainer data;

		internal ProcessedBuilderDataContainer processedData;

		private List<RenderedMeshWithType> meshes;

		private List<Mesh> cachedMeshes;

		private List<Mesh> stagingCachedMeshes;

		private int lastTimeLargestCachedMeshWasUsed;

		internal SDFLookupData fontData;

		private int currentDrawOrderIndex;

		internal int sceneModeVersion;

		public Material surfaceMaterial;

		public Material lineMaterial;

		public Material textMaterial;

		public DrawingSettings.Settings settings;

		private int lastTickVersion;

		private int lastTickVersion2;

		private Dictionary<int, GameObject> persistentRedrawScopes;

		internal GCHandle gizmosHandle;

		public RedrawScope frameRedrawScope;

		private Dictionary<Camera, Range> cameraVersions;

		internal static readonly ProfilerMarker MarkerScheduleJobs;

		internal static readonly ProfilerMarker MarkerAwaitUserDependencies;

		internal static readonly ProfilerMarker MarkerSchedule;

		internal static readonly ProfilerMarker MarkerBuild;

		internal static readonly ProfilerMarker MarkerPool;

		internal static readonly ProfilerMarker MarkerRelease;

		internal static readonly ProfilerMarker MarkerBuildMeshes;

		internal static readonly ProfilerMarker MarkerCollectMeshes;

		internal static readonly ProfilerMarker MarkerSortMeshes;

		internal static readonly ProfilerMarker LeakTracking;

		private static readonly Comparison<RenderedMeshWithType> meshSorter;

		private Plane[] frustrumPlanes;

		private MaterialPropertyBlock customMaterialProperties;

		private int adjustedSceneModeVersion => 0;

		private static float CurrentTime => 0f;

		public DrawingSettings.Settings settingsRef => null;

		public int version { get; private set; }

		private int totalMemoryUsage => 0;

		internal int GetNextDrawOrderIndex()
		{
			return 0;
		}

		internal void PoolMesh(Mesh mesh)
		{
		}

		private void SortPooledMeshes()
		{
		}

		internal Mesh GetMesh(int desiredVertexCount)
		{
			return null;
		}

		internal void LoadFontDataIfNecessary()
		{
		}

		private static void UpdateTime()
		{
		}

		public CommandBuilder GetBuilder(bool renderInGame = false)
		{
			return default(CommandBuilder);
		}

		internal CommandBuilder GetBuiltInBuilder(bool renderInGame = false)
		{
			return default(CommandBuilder);
		}

		public CommandBuilder GetBuilder(RedrawScope redrawScope, bool renderInGame = false)
		{
			return default(CommandBuilder);
		}

		public CommandBuilder GetBuilder(Hasher hasher, RedrawScope redrawScope = default(RedrawScope), bool renderInGame = false)
		{
			return default(CommandBuilder);
		}

		public GameObject GetAssociatedGameObject(RedrawScope scope)
		{
			return null;
		}

		private void DiscardData(Hasher hasher)
		{
		}

		internal void OnChangingPlayMode()
		{
		}

		public bool Draw(Hasher hasher)
		{
			return false;
		}

		public bool Draw(Hasher hasher, RedrawScope scope)
		{
			return false;
		}

		internal void Draw(RedrawScope scope)
		{
		}

		internal void DrawUntilDisposed(RedrawScope scope, GameObject associatedGameObject)
		{
		}

		internal void DisposeRedrawScope(RedrawScope scope)
		{
		}

		private void RefreshRedrawScopes()
		{
		}

		private void CleanupOldCameras()
		{
		}

		public void DisposeCommandBuildersWithJobDependencies()
		{
		}

		public void TickFramePreRender()
		{
		}

		public void PostRenderCleanup()
		{
		}

		private static int MeshCompareByDrawingOrder(RenderedMeshWithType a, RenderedMeshWithType b)
		{
			return 0;
		}

		private void LoadMaterials()
		{
		}

		private static int CeilLog2(int x)
		{
			return 0;
		}

		public void Render(Camera cam, bool allowGizmos, CommandBufferWrapper commandBuffer, bool allowCameraDefault)
		{
		}

		private static Bounds TransformBoundingBox(Matrix4x4 matrix, Bounds bounds)
		{
			return default(Bounds);
		}

		public void ClearData()
		{
		}
	}
}
