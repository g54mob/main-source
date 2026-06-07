using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using AOT;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Terrain.CustomData;
using Assets.Scripts.Terrain.Diagnostics;
using Assets.Scripts.Terrain.Events;
using Assets.Scripts.Terrain.Pooling;
using Assets.Scripts.Terrain.Rendering;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Flight.GameView;
using ModApi.Planet;
using ModApi.Planet.Events;
using ModApi.Planet.Modifiers.Profiling;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Terrain
{
	public class QuadSphereScript : MonoBehaviour, IQuadSphere
	{
		public enum QuadSphereRenderingTechnique
		{
			DrawMesh = 0,
			MeshRenderers = 1
		}

		internal class LodAndCullingData
		{
			public Vector3d CameraSurfacePosition;

			public double LodAltitude;

			public Vector3d TargetSurfacePosition;

			public Vector3d TargetSurfacePositionNormalized;

			public double VisibilityRadiusSquared;

			public void Update(QuadSphereScript quadSphere)
			{
				if (Game.InFlightScene)
				{
					IGameView gameView = Game.Instance.FlightScene.ViewManager.GameView;
					CameraSurfacePosition = gameView.PlanetNode.PlanetVectorToSurfaceVector(gameView.GameCamera.PlanetPosition);
					TargetSurfacePosition = gameView.PlanetNode.PlanetVectorToSurfaceVector(gameView.GameCamera.CameraTargetPlanetPosition);
				}
				else if (Game.InPlanetStudioScene)
				{
					CelestialBodyViewerScript celestialBodyViewerScript = PlanetStudioScript.Instance?.CelestialBodyDesignerScript?.CelestialBodyViewer;
					CameraSurfacePosition = celestialBodyViewerScript.CameraSurfacePosition;
					TargetSurfacePosition = CameraSurfacePosition;
				}
				TargetSurfacePositionNormalized = TargetSurfacePosition.normalized;
				ITerrainGenerator terrainGenerator = quadSphere.TerrainGenerator;
				LodAltitude = TargetSurfacePosition.magnitude - quadSphere._radius - (quadSphere._terrainMaxHeight - (double)terrainGenerator.SeaLevel);
				if (LodAltitude < 0.0)
				{
					LodAltitude = 0.0;
				}
				double radius = quadSphere.PlanetData.Radius;
				double num = radius + quadSphere._terrainMinHeight;
				double num2 = radius + quadSphere._terrainMaxHeight;
				double num3 = CameraSurfacePosition.sqrMagnitude;
				double num4 = (num + 10.0) * (num + 10.0);
				if (num3 < num4)
				{
					num3 = num4;
				}
				double num5 = num * num;
				double num6 = num2 * num2;
				double num7 = Mathd.Sqrt(num3 - num5) + Mathd.Sqrt(num6 - num5);
				VisibilityRadiusSquared = num7 * num7;
			}
		}

		[BurstCompile]
		private static class BurstFunctions
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void AssignColorSplatmapAndMaterialDataToVerticesDelegate(int count, float4* data, MeshDataTerrain.TerrainVertex* vertices);

			public unsafe delegate void AssignColorSplatmapAndMaterialDataToVertices_000006FE_0024PostfixBurstDelegate(int count, [NoAlias] float4* data, [NoAlias] MeshDataTerrain.TerrainVertex* vertices);

			internal static class AssignColorSplatmapAndMaterialDataToVertices_000006FE_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(AssignColorSplatmapAndMaterialDataToVertices_000006FE_0024PostfixBurstDelegate).TypeHandle);
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public static void Constructor()
				{
					DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
				}

				public static void Initialize()
				{
				}

				static AssignColorSplatmapAndMaterialDataToVertices_000006FE_0024BurstDirectCall()
				{
					Constructor();
				}

				public unsafe static void Invoke(int count, [NoAlias] float4* data, [NoAlias] MeshDataTerrain.TerrainVertex* vertices)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<int, float4*, MeshDataTerrain.TerrainVertex*, void>)functionPointer)(count, data, vertices);
							return;
						}
					}
					AssignColorSplatmapAndMaterialDataToVertices_0024BurstManaged(count, data, vertices);
				}
			}

			private static bool _initialized;

			public static AssignColorSplatmapAndMaterialDataToVerticesDelegate AssignColorSplatmapAndMaterialDataToVerticesInvoke { get; private set; }

			public unsafe static void Initialize()
			{
				if (!_initialized)
				{
					_initialized = true;
					AssignColorSplatmapAndMaterialDataToVerticesInvoke = BurstCompiler.CompileFunctionPointer<AssignColorSplatmapAndMaterialDataToVerticesDelegate>(AssignColorSplatmapAndMaterialDataToVertices).Invoke;
				}
			}

			[BurstCompile(CompileSynchronously = true)]
			[MonoPInvokeCallback(typeof(AssignColorSplatmapAndMaterialDataToVerticesDelegate))]
			private unsafe static void AssignColorSplatmapAndMaterialDataToVertices(int count, [NoAlias] float4* data, [NoAlias] MeshDataTerrain.TerrainVertex* vertices)
			{
				AssignColorSplatmapAndMaterialDataToVertices_000006FE_0024BurstDirectCall.Invoke(count, data, vertices);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile(CompileSynchronously = true)]
			[MonoPInvokeCallback(typeof(AssignColorSplatmapAndMaterialDataToVerticesDelegate))]
			public unsafe static void AssignColorSplatmapAndMaterialDataToVertices_0024BurstManaged(int count, [NoAlias] float4* data, [NoAlias] MeshDataTerrain.TerrainVertex* vertices)
			{
				int num = -1;
				for (int i = 0; i < count; i++)
				{
					MeshDataTerrain.TerrainVertex* num2 = vertices + i;
					num2->Color = new half4(data[++num]);
					int4 int5 = (int4)math.clamp(math.round(data[++num] * 255f), 0f, 255f);
					num2->Uv2.r = (byte)int5.x;
					num2->Uv2.g = (byte)int5.y;
					num2->Uv2.b = (byte)int5.z;
					num2->Uv2.a = (byte)int5.w;
					int4 int6 = (int4)math.clamp(math.round(data[++num] * 255f), 0f, 255f);
					num2->Uv3.r = (byte)int6.x;
					num2->Uv3.g = (byte)int6.y;
					num2->Uv3.b = (byte)int6.z;
					num2->Uv3.a = (byte)int6.w;
					int4 int7 = (int4)math.clamp(math.round(data[++num] * 255f), 0f, 255f);
					num2->Uv4.r = (byte)int7.x;
					num2->Uv4.g = (byte)int7.y;
					num2->Uv4.b = (byte)int7.z;
					num2->Uv4.a = 0;
				}
			}
		}

		private const float WaterCloseToCameraDistSqr = 10000f;

		private static readonly half _f16One = new half(1.0);

		private static readonly half _f16Zero = new half(0f);

		private static readonly object _quadGenerationStatsLock = new object();

		private static Matrix4x4d _drawQuadsMatrix = new Matrix4x4d();

		private static ushort[] _rgbToHalf4Cache = InitializeRGBToHalf4Cache();

		private AsynchronousJobProcessor _asyncJobProcessor;

		private int[] _boundingBoxSampleIndexes;

		[SerializeField]
		private bool _cubify;

		[SerializeField]
		private bool _disableCulling;

		private bool _fullLodUpdate;

		[SerializeField]
		private bool _generateUnderwaterTerrainQuads = true;

		private LodAndCullingData _lodAndCullingData;

		private double[] _lodCullingDistance;

		private double[] _lodDistance;

		private double[] _lodMergeDistance;

		private Vector3d _lodUpdateLastPosition;

		private bool _lodUpdateRequired;

		private double _lodUpdateRequiredDistanceSquared;

		private double _maxSubDivisionDist;

		[SerializeField]
		private int _maxSubdivisionLevel;

		[SerializeField]
		private int _minSubdivisionLevel;

		[SerializeField]
		private bool _peakSmoothing;

		[SerializeField]
		private QuadGenerationPerformanceMetrics _performanceMetrics = new QuadGenerationPerformanceMetrics();

		[SerializeField]
		private PhysicsQuadManager _physicsQuadManager;

		private bool _previousFrameCullingDisabled;

		private int[] _quadCounts;

		private List<QuadRenderingData> _quadDrawList = new List<QuadRenderingData>(2000);

		[SerializeField]
		private double _quadGenerationTimeAverage;

		[SerializeField]
		private double _quadGenerationTimeMax;

		[SerializeField]
		private double _quadGenerationTimeMin;

		[SerializeField]
		private long _quadGenerationTimeTotal;

		[SerializeField]
		private int _quadsGenerated;

		private Stack<QuadScript> _quadStack;

		private Vector3d[] _quadTemplateVertices;

		private double _radius;

		[SerializeField]
		private QuadSphereRenderingTechnique _renderingTechnique;

		private List<QuadScript> _roots;

		[SerializeField]
		private bool _showNormals;

		[SerializeField]
		private float _splitDistanceFactor = 5f;

		private QuadSplitJob _synchronousQuadSplitJob;

		private ITerrainGenerator _terrainGenerator;

		private double _terrainMaxHeight;

		private double _terrainMinHeight;

		private bool _terrainReceivesShadows;

		private bool _unloaded;

		private int _uvSizeExponent;

		private bool _waterSupportsTransparency;

		private WaterTransparencyCameraScript _waterTransparency;

		public AsynchronousJobProcessor AsyncJobProcessor => _asyncJobProcessor;

		public Transform Camera { get; private set; }

		public double ClosestWaterQuadToCameraSqr { get; private set; }

		public Transform DirectionalLight { get; private set; }

		public double EstimatedMinimumQuadSize { get; private set; }

		public Vector3d FramePosition { get; set; }

		public double MaxSubDivisionDist
		{
			get
			{
				return _maxSubDivisionDist;
			}
			private set
			{
				_maxSubDivisionDist = value;
				this.MaxSubDivisionDistChanged?.Invoke(this);
			}
		}

		public int MaxSubdivisionLevel
		{
			get
			{
				return _maxSubdivisionLevel;
			}
			private set
			{
				_maxSubdivisionLevel = value;
			}
		}

		public int MinSubdivisionLevel
		{
			get
			{
				return _minSubdivisionLevel;
			}
			private set
			{
				_minSubdivisionLevel = value;
			}
		}

		public PlanetModifierProfiler ModifierProfiler { get; set; }

		public int NumVerticesInPaddedQuad { get; private set; }

		public int NumVerticesInQuad { get; private set; }

		public int NumVerticesInWaterQuad { get; private set; }

		public int NumVerticesOnPaddedQuadEdge { get; private set; }

		public int NumVerticesOnQuadEdge { get; private set; }

		public int NumVerticesOnWaterQuadEdge { get; private set; }

		public IPhysicsQuadManager PhysicsManager => _physicsQuadManager;

		public IPlanetData PlanetData { get; private set; }

		public Vector3d PlanetPosition { get; private set; }

		public GameObject QuadTerrainPrefab { get; private set; }

		public GameObject QuadWaterPrefab { get; private set; }

		public QuadSphereRenderingTechnique RenderingTechnique { get; private set; }

		public QuadMeshDataFlags RequiredQuadMeshDataTerrain { get; private set; }

		public QuadMeshDataFlags RequiredQuadMeshDataWater { get; private set; }

		public bool ShowNormals => _showNormals;

		public ITerrainGenerator TerrainGenerator => _terrainGenerator;

		public double TerrainMaxHeight => _terrainMaxHeight;

		public double TerrainMinHeight => _terrainMinHeight;

		public Transform Transform => base.transform;

		public bool Unloaded => _unloaded;

		public int WaterQuadVertexCountFactor { get; private set; }

		public static event EventHandler<CreateQuadDataEventArgs> CreateQuadDataCompleted;

		public event EventHandler<QuadSphereFrameStateRecalculatedEventArgs> FrameStateRecalculated;

		public event MaxSubDivisionDistChangedHandler MaxSubDivisionDistChanged;

		public bool CoordinatesOnPaddedEdge(int x, int z)
		{
			if (x != 0 && z != 0 && x <= NumVerticesOnQuadEdge)
			{
				return z > NumVerticesOnQuadEdge;
			}
			return true;
		}

		public void DrawQuadsForTerrainRaycasting(Camera camera, Material material)
		{
			Transform parent = base.transform.parent;
			Matrix4x4d matrix4x4d = Matrix4x4d.TRS(FramePosition, new Quaterniond(parent.localRotation), Vector3.one);
			Matrix4x4 matrix = matrix4x4d.ToMatrix4x4();
			foreach (QuadRenderingData quadDraw in _quadDrawList)
			{
				Vector3d localPosition = quadDraw.LocalPosition;
				matrix.m03 = (float)(matrix4x4d.m00 * localPosition.x + matrix4x4d.m01 * localPosition.y + matrix4x4d.m02 * localPosition.z + matrix4x4d.m03);
				matrix.m13 = (float)(matrix4x4d.m10 * localPosition.x + matrix4x4d.m11 * localPosition.y + matrix4x4d.m12 * localPosition.z + matrix4x4d.m13);
				matrix.m23 = (float)(matrix4x4d.m20 * localPosition.x + matrix4x4d.m21 * localPosition.y + matrix4x4d.m22 * localPosition.z + matrix4x4d.m23);
				if (quadDraw.TerrainMesh != null)
				{
					Graphics.DrawMesh(quadDraw.TerrainMesh, matrix, material, 29, camera, 0, quadDraw.RaycastMaterialPropertyBlock, ShadowCastingMode.Off, receiveShadows: false, null, LightProbeUsage.Off, null);
				}
			}
		}

		public void ExecuteOnAllQuads(Action<QuadScript> action)
		{
			Stack<QuadScript> quadStack = _quadStack;
			quadStack.Clear();
			foreach (QuadScript root in _roots)
			{
				quadStack.Push(root);
			}
			while (quadStack.Count > 0)
			{
				QuadScript quadScript = quadStack.Pop();
				action(quadScript);
				QuadScript[] children = quadScript.Children;
				if (children != null)
				{
					quadStack.Push(children[0]);
					quadStack.Push(children[1]);
					quadStack.Push(children[2]);
					quadStack.Push(children[3]);
				}
			}
			quadStack.Clear();
		}

		public void FullLodUpdate()
		{
			StartFullLodUpdate();
			WaitForFullLodUpdate();
			CompleteFullLodUpdate();
		}

		public Coroutine FullLodUpdateAsync()
		{
			return StartCoroutine(FullLodUpdateCoroutine());
		}

		public CreateQuadData GenerateCreateQuadData()
		{
			return new CreateQuadData(NumVerticesInPaddedQuad);
		}

		public void GeneratePhysicsQuadMeshData(CreatePhysicsQuadData data, Vector3d position, Quaterniond rotation, double scale)
		{
			Vector3d[] terrainPoints = data.TerrainPoints;
			MeshDataPhysics.PhysicsVertex[] vertices = data.MeshData.Vertices;
			_ = Thread.CurrentThread.ManagedThreadId;
			Vector3d zero = Vector3d.zero;
			TerrainGeneratorCacheData cacheData = _terrainGenerator.GetCacheData();
			Matrix4x4d matrix = data.Matrix;
			matrix.SetTRS(position, rotation, new Vector3d(scale, scale, scale));
			int num = 0;
			for (int i = 0; i < NumVerticesOnPaddedQuadEdge; i++)
			{
				for (int j = 0; j < NumVerticesOnPaddedQuadEdge; j++)
				{
					Vector3d v = _quadTemplateVertices[num];
					_ = ref vertices[num];
					Vector3d vector3d = matrix.MultiplyPoint3x4(v);
					vector3d.Normalize();
					float num2 = (float)_terrainGenerator.GetVertexDataBiomeAndHeightPass(vector3d, num, cacheData).Height;
					vector3d *= _radius + (double)num2;
					terrainPoints[num] = vector3d;
					zero += vector3d;
					num++;
				}
			}
			cacheData.ReturnToPool();
			zero = new Vector3d((zero / _quadTemplateVertices.Length).ToVector3());
			num = 0;
			for (int k = 0; k < NumVerticesOnPaddedQuadEdge; k++)
			{
				for (int l = 0; l < NumVerticesOnPaddedQuadEdge; l++)
				{
					vertices[num].Position = (terrainPoints[num] - zero).ToFloat3();
					num++;
				}
			}
			data.Center = zero;
		}

		public void GetAllQuads(List<QuadScript> quads)
		{
			Stack<QuadScript> quadStack = _quadStack;
			quadStack.Clear();
			foreach (QuadScript root in _roots)
			{
				quadStack.Push(root);
			}
			while (quadStack.Count > 0)
			{
				QuadScript quadScript = quadStack.Pop();
				quads.Add(quadScript);
				QuadScript[] children = quadScript.Children;
				if (children != null)
				{
					quadStack.Push(children[0]);
					quadStack.Push(children[1]);
					quadStack.Push(children[2]);
					quadStack.Push(children[3]);
				}
			}
			quadStack.Clear();
		}

		public void Initialize(IPlanetData planetData, ITerrainGenerator terrainGenerator, Transform directionalLight, Camera camera, bool soiTransition, IReferenceFrame referenceFrame)
		{
			PlanetData = planetData;
			SphereCollider sphereCollider = base.gameObject.AddComponent<SphereCollider>();
			sphereCollider.isTrigger = true;
			sphereCollider.radius = (float)planetData.Radius;
			DirectionalLight = directionalLight;
			Camera = camera.transform;
			_radius = planetData.Radius;
			IPlanetTerrainQuality quality = planetData.TerrainData.Quality;
			TerrainQualitySettings terrain = Game.Instance.QualitySettings.Terrain;
			MinSubdivisionLevel = Mathf.Clamp(planetData.TerrainData.Quality.MinSubdivisionLevel + (int)terrain.MinSubdivisionLevelBias, 1, 6);
			MaxSubdivisionLevel = Mathf.Clamp(planetData.TerrainData.Quality.MaxSubdivisionLevel + (int)terrain.MaxSubdivisionLevelBias, MinSubdivisionLevel, 20);
			_uvSizeExponent = planetData.TerrainData.UVSizeExponent;
			NumVerticesInPaddedQuad = (quality.TerrainQuadEdgeVertexCount + 2) * (quality.TerrainQuadEdgeVertexCount + 2);
			NumVerticesOnPaddedQuadEdge = quality.TerrainQuadEdgeVertexCount + 2;
			NumVerticesInQuad = quality.TerrainQuadEdgeVertexCount * quality.TerrainQuadEdgeVertexCount;
			NumVerticesOnQuadEdge = quality.TerrainQuadEdgeVertexCount;
			NumVerticesInWaterQuad = quality.WaterQuadEdgeVertexCount * quality.WaterQuadEdgeVertexCount;
			NumVerticesOnWaterQuadEdge = quality.WaterQuadEdgeVertexCount;
			GenerateBoundingBoxSampleIndexes();
			float num = (float)(quality.TerrainQuadEdgeVertexCount - quality.WaterQuadEdgeVertexCount) / ((float)quality.WaterQuadEdgeVertexCount - 1f) + 1f;
			WaterQuadVertexCountFactor = (int)num;
			if (!Mathf.Approximately(num - (float)WaterQuadVertexCountFactor, 0f))
			{
				this.LogError("Water quad vertex count ({0}) is not valid for the specified terrain quad vertex count ({1}).", quality.WaterQuadEdgeVertexCount, quality.TerrainQuadEdgeVertexCount);
			}
			RenderingTechnique = _renderingTechnique;
			_synchronousQuadSplitJob = new QuadSplitJob(GenerateCreateQuadData);
			_asyncJobProcessor = new AsynchronousJobProcessor(GenerateCreateQuadData);
			_previousFrameCullingDisabled = _disableCulling;
			_lodUpdateRequired = true;
			_lodAndCullingData = new LodAndCullingData();
			_quadStack = new Stack<QuadScript>();
			ResetStats();
			_quadCounts = new int[MaxSubdivisionLevel + 1];
			for (int i = 0; i < _quadCounts.Length; i++)
			{
				_quadCounts[i] = 0;
			}
			terrainGenerator.InitializeQuadSphere(this);
			_terrainGenerator = terrainGenerator;
			_terrainMinHeight = double.MaxValue;
			_terrainMaxHeight = double.MinValue;
			RequiredQuadMeshDataWater = _terrainGenerator.GetRequiredWaterMeshData();
			RequiredQuadMeshDataTerrain = _terrainGenerator.GetRequiredTerrainMeshData();
			NumericSetting<float> lodDistance = Game.Instance.QualitySettings.Terrain.LodDistance;
			lodDistance.Changed += OnLodDistanceSettingChanged;
			_splitDistanceFactor = lodDistance;
			BuildLodTables();
			EstimatedMinimumQuadSize = GetQuadSize(MaxSubdivisionLevel);
			CreateQuadTemplate();
			QuadSpherePoolManager.Instance.Initialize(this, soiTransition);
			if (planetData.HasTerrainPhysics)
			{
				_physicsQuadManager = new PhysicsQuadManager(this);
			}
			double num2 = Math.Pow(2.0, _uvSizeExponent);
			Vector2d uvCenter = new Vector2d(num2 / 2.0, num2 / 2.0);
			CreateQuadData data = GenerateCreateQuadData();
			_roots = new List<QuadScript>();
			_roots.Add(QuadScript.CreateQuad(this, GenerateQuadData(InitializeQuadData(data), 0, Vector3d.up * _radius, Quaterniond.identity, _radius, uvCenter, num2), null, 0));
			_roots.Add(QuadScript.CreateQuad(this, GenerateQuadData(InitializeQuadData(data), 0, Vector3d.down * _radius, Quaterniond.Euler(180.0, 0.0, 0.0), _radius, uvCenter, num2), null, 1));
			_roots.Add(QuadScript.CreateQuad(this, GenerateQuadData(InitializeQuadData(data), 0, Vector3d.forward * _radius, Quaterniond.Euler(-90.0, 180.0, 0.0), _radius, uvCenter, num2), null, 2));
			_roots.Add(QuadScript.CreateQuad(this, GenerateQuadData(InitializeQuadData(data), 0, Vector3d.back * _radius, Quaterniond.Euler(-90.0, 0.0, 0.0), _radius, uvCenter, num2), null, 3));
			_roots.Add(QuadScript.CreateQuad(this, GenerateQuadData(InitializeQuadData(data), 0, Vector3d.right * _radius, Quaterniond.Euler(-90.0, -90.0, 0.0), _radius, uvCenter, num2), null, 4));
			_roots.Add(QuadScript.CreateQuad(this, GenerateQuadData(InitializeQuadData(data), 0, Vector3d.left * _radius, Quaterniond.Euler(-90.0, 90.0, 0.0), _radius, uvCenter, num2), null, 5));
			if (planetData.HasWater)
			{
				WaterReflectionPlaneScript.Create(Transform, camera, referenceFrame);
				_waterTransparency = camera.gameObject.AddComponent<WaterTransparencyCameraScript>();
				WaterQualitySettings water = Game.Instance.QualitySettings.Water;
				_waterSupportsTransparency = water.Transparency;
				water.Changed += OnWaterQualityChanged;
			}
			BoolSetting terrainReceivesShadows = Game.Instance.QualitySettings.Shadows.TerrainReceivesShadows;
			terrainReceivesShadows.Changed += OnTerrainShadowsChanged;
			_terrainReceivesShadows = terrainReceivesShadows;
			TerrainRendererManagerScript.Instance.AddRenderer(this);
			if (Device.IsUnityEditor)
			{
				UnityEngine.Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(UnityEngine.Camera.onPreCull, new Camera.CameraCallback(EditorCameraPreCull));
			}
		}

		public CreateQuadData InitializeQuadData(CreateQuadData data)
		{
			QuadSpherePoolManager instance = QuadSpherePoolManager.Instance;
			data.TerrainMeshData = instance.TerrainMeshDataPool.GetItem();
			data.WaterMeshData = instance.WaterMeshDataPool.GetItem();
			return data;
		}

		public void OnQuadAdded(QuadScript quad)
		{
			_quadCounts[quad.SubdivisionLevel]++;
			_lodUpdateRequired = true;
			if (_fullLodUpdate)
			{
				UpdateQuadLod(quad, allowSynchronous: false);
			}
		}

		public void OnQuadRemoved(QuadScript quad)
		{
			_quadCounts[quad.SubdivisionLevel]--;
			_lodUpdateRequired = true;
		}

		public void ProcessAsynchronousJobs(int maxJobs)
		{
			if (!_unloaded)
			{
				_asyncJobProcessor.ProcessUninitializedJobs();
				_asyncJobProcessor.ProcessCompletedJobs(maxJobs);
			}
		}

		public void ProcessQuadRefreshJob(QuadRefreshJob job)
		{
			QuadScript quad = job.Quad;
			GenerateQuadData(job.QuadData, quad.SubdivisionLevel, quad.QuadPosition, quad.QuadRotation, quad.QuadScale, quad.UvCenter, quad.UvSize);
		}

		public void ProcessQuadSplitJob(QuadSplitJob job)
		{
			QuadScript quad = job.Quad;
			Vector3d vector3d = quad.QuadRotation * Vector3d.right;
			Vector3d vector3d2 = quad.QuadRotation * Vector3d.forward;
			double num = quad.QuadScale / 2.0;
			double num2 = quad.UvSize / 2.0;
			double num3 = num2 / 2.0;
			int subdivisionLevel = quad.SubdivisionLevel + 1;
			GenerateQuadData(job.QuadData[0], subdivisionLevel, quad.QuadPosition - vector3d * num + vector3d2 * num, quad.QuadRotation, num, quad.UvCenter + new Vector2d(0.0 - num3, num3), num2);
			GenerateQuadData(job.QuadData[1], subdivisionLevel, quad.QuadPosition + vector3d * num + vector3d2 * num, quad.QuadRotation, num, quad.UvCenter + new Vector2d(num3, num3), num2);
			GenerateQuadData(job.QuadData[2], subdivisionLevel, quad.QuadPosition - vector3d * num - vector3d2 * num, quad.QuadRotation, num, quad.UvCenter + new Vector2d(0.0 - num3, 0.0 - num3), num2);
			GenerateQuadData(job.QuadData[3], subdivisionLevel, quad.QuadPosition + vector3d * num - vector3d2 * num, quad.QuadRotation, num, quad.UvCenter + new Vector2d(num3, 0.0 - num3), num2);
		}

		public void RecalculateFrameState(IReferenceFrame referenceFrame)
		{
			this.FrameStateRecalculated?.Invoke(this, new QuadSphereFrameStateRecalculatedEventArgs(this, referenceFrame));
		}

		public void RefreshAllQuads()
		{
			RefreshQuads(Vector3d.one, 1000000000.0);
		}

		public void RefreshQuads(Vector3d spherePosition, double size)
		{
			Vector3d cubePosition = Utility.SpherePositionToCubePosition(spherePosition);
			cubePosition *= _radius;
			int num = 0;
			foreach (QuadScript root in _roots)
			{
				num += RefreshQuadsInRange(cubePosition, size, root);
			}
		}

		public void ResetStats()
		{
			_quadsGenerated = 0;
			_quadGenerationTimeTotal = 0L;
			_quadGenerationTimeMin = double.MaxValue;
			_quadGenerationTimeMax = double.MinValue;
			_quadGenerationTimeAverage = 0.0;
		}

		public void Unload()
		{
			if (!_unloaded)
			{
				_unloaded = true;
				OnUnload();
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		public void UpdateLod(bool updateCulling)
		{
			if (_unloaded || _fullLodUpdate)
			{
				return;
			}
			_lodAndCullingData.Update(this);
			if (!_lodUpdateRequired)
			{
				double sqrMagnitude = (_lodAndCullingData.TargetSurfacePosition - _lodUpdateLastPosition).sqrMagnitude;
				_lodUpdateRequired = sqrMagnitude > _lodUpdateRequiredDistanceSquared;
			}
			if (_lodUpdateRequired)
			{
				_lodUpdateRequired = false;
				_lodUpdateLastPosition = _lodAndCullingData.TargetSurfacePosition;
				foreach (QuadScript root in _roots)
				{
					UpdateQuadLod(root, base.gameObject.activeSelf);
				}
			}
			if (updateCulling)
			{
				UpdateCulling();
			}
			else
			{
				ClosestWaterQuadToCameraSqr = double.MaxValue;
			}
		}

		public void UpdateStats(QuadSphereStats stats)
		{
			stats.QuadsCreated = _quadsGenerated;
			stats.QuadsLoaded = _quadCounts.Sum();
			stats.QuadsLoadedPerLevel = _quadCounts;
			stats.QuadsDrawn = _quadDrawList.Count;
			if (_quadsGenerated == 0)
			{
				stats.QuadGenerationTimeMin = 0.0;
				stats.QuadGenerationTimeMax = 0.0;
				stats.QuadGenerationTimeAverage = 0.0;
			}
			else
			{
				double num = (double)Stopwatch.Frequency / 1000.0;
				stats.QuadGenerationTimeMin = _quadGenerationTimeMin / num;
				stats.QuadGenerationTimeMax = _quadGenerationTimeMax / num;
				stats.QuadGenerationTimeAverage = (double)_quadGenerationTimeTotal / (double)_quadsGenerated / num;
			}
		}

		protected virtual void Awake()
		{
			BurstFunctions.Initialize();
		}

		protected virtual void LateUpdate()
		{
			ProcessAsynchronousJobs(int.MaxValue);
			DrawQuads();
			if (RenderingTechnique != _renderingTechnique)
			{
				QuadSphereRenderingTechnique renderingTechnique = RenderingTechnique;
				RenderingTechnique = _renderingTechnique;
				OnRenderTechniqueChanged(renderingTechnique, _renderingTechnique);
			}
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.QualitySettings.Water.Changed -= OnWaterQualityChanged;
			Game.Instance.QualitySettings.Shadows.TerrainReceivesShadows.Changed -= OnTerrainShadowsChanged;
			Game.Instance.QualitySettings.Terrain.LodDistance.Changed -= OnLodDistanceSettingChanged;
			if (_waterTransparency != null)
			{
				UnityEngine.Object.Destroy(_waterTransparency);
				_waterTransparency = null;
			}
			if (Device.IsUnityEditor)
			{
				UnityEngine.Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(UnityEngine.Camera.onPreCull, new Camera.CameraCallback(EditorCameraPreCull));
			}
			_physicsQuadManager?.OnDestroy();
			_terrainGenerator = new TerrainGeneratorDisposed(_terrainGenerator);
			if (_asyncJobProcessor != null)
			{
				_asyncJobProcessor.Dispose();
				_asyncJobProcessor = null;
			}
		}

		private static ushort[] InitializeRGBToHalf4Cache()
		{
			ushort[] array = new ushort[256];
			for (int i = 0; i < 256; i++)
			{
				array[i] = new half((float)i / 255f).value;
			}
			return array;
		}

		private static void RGBToHalf4(ref Color c, ref half4 h)
		{
			h.x.value = ((c.r <= 0f) ? _f16Zero.value : ((ushort)math.f32tof16(c.r)));
			h.y.value = ((c.g <= 0f) ? _f16Zero.value : ((ushort)math.f32tof16(c.g)));
			h.z.value = ((c.b <= 0f) ? _f16Zero.value : ((ushort)math.f32tof16(c.b)));
			h.w.value = _f16One.value;
		}

		private void BuildLodTables()
		{
			double quadRootSize = GetQuadRootSize();
			int maxSubdivisionLevel = MaxSubdivisionLevel;
			_lodDistance = new double[maxSubdivisionLevel + 1];
			_lodMergeDistance = new double[maxSubdivisionLevel + 1];
			_lodCullingDistance = new double[maxSubdivisionLevel + 1];
			for (int i = 0; i <= maxSubdivisionLevel; i++)
			{
				double num = quadRootSize / Math.Pow(2.0, i);
				_lodDistance[i] = num * (double)_splitDistanceFactor;
				_lodMergeDistance[i] = _lodDistance[i] * 0.75;
				_lodCullingDistance[i] = _lodMergeDistance[i] * _lodMergeDistance[i];
			}
			_lodUpdateRequiredDistanceSquared = Math.Pow(quadRootSize / Math.Pow(2.0, maxSubdivisionLevel) * 0.1, 2.0);
			MaxSubDivisionDist = _lodDistance[MaxSubdivisionLevel];
		}

		private void CompleteFullLodUpdate()
		{
			_fullLodUpdate = false;
		}

		private void CreateQuadAxisAlignedBoundingBox(CreateQuadData data, float minHeight, float maxHeight)
		{
			TerrainPointSample[] terrainPoints = data.TerrainPoints;
			Vector3d[] boundingBoxSamplePoints = data.BoundingBoxSamplePoints;
			Vector3d normalized = data.Position.normalized;
			double num = _radius + (double)minHeight;
			double num2 = _radius + (double)maxHeight;
			double degress = Math.Atan2(normalized.z, normalized.x) * 57.295780181884766;
			double degress2 = Vector3d.Angle(Vector3d.up, normalized);
			Quaterniond quaterniond = Quaterniond.AngleAxis(degress, Vector3d.up);
			Quaterniond quaterniond2 = Quaterniond.AngleAxis(degress2, Vector3d.forward) * quaterniond;
			int num3 = 0;
			for (int i = 0; i < 9; i++)
			{
				Vector3d vector3d = quaterniond2 * terrainPoints[_boundingBoxSampleIndexes[i]].SpherePosition;
				boundingBoxSamplePoints[num3++] = vector3d * num;
				boundingBoxSamplePoints[num3++] = vector3d * num2;
			}
			Vector3d min = boundingBoxSamplePoints[0];
			Vector3d max = boundingBoxSamplePoints[0];
			for (int j = 1; j < 18; j++)
			{
				Vector3d vector3d2 = boundingBoxSamplePoints[j];
				if (vector3d2.x < min.x)
				{
					min.x = vector3d2.x;
				}
				else if (vector3d2.x > max.x)
				{
					max.x = vector3d2.x;
				}
				if (vector3d2.y < min.y)
				{
					min.y = vector3d2.y;
				}
				else if (vector3d2.y > max.y)
				{
					max.y = vector3d2.y;
				}
				if (vector3d2.z < min.z)
				{
					min.z = vector3d2.z;
				}
				else if (vector3d2.z > max.z)
				{
					max.z = vector3d2.z;
				}
			}
			data.AxisAlignedBoundingBox = new QuadAxisAlignedBoundingBox(min, max);
			data.AxisAlignedBoundingBoxRotation = quaterniond2;
		}

		private void CreateQuadTemplate()
		{
			_quadTemplateVertices = new Vector3d[NumVerticesInPaddedQuad];
			int num = 0;
			double num2 = 2.0 / (double)(NumVerticesOnQuadEdge - 1);
			double num3 = -1.0 - num2;
			Vector3d vector3d = default(Vector3d);
			for (int i = -1; i <= NumVerticesOnQuadEdge; i++)
			{
				double num4 = -1.0 - num2;
				for (int j = -1; j <= NumVerticesOnQuadEdge; j++)
				{
					vector3d.x = num3;
					vector3d.z = num4;
					vector3d.y = 0.0;
					num4 += num2;
					_quadTemplateVertices[num++] = vector3d;
				}
				num3 += num2;
			}
		}

		private void DrawQuads(Camera camera = null)
		{
			if (RenderingTechnique != QuadSphereRenderingTechnique.DrawMesh)
			{
				return;
			}
			bool receiveShadows = _terrainReceivesShadows && !_waterSupportsTransparency;
			Transform parent = base.transform.parent;
			_drawQuadsMatrix.SetTRS(FramePosition, new Quaterniond(parent.localRotation), Vector3.one);
			Matrix4x4d drawQuadsMatrix = _drawQuadsMatrix;
			Matrix4x4 matrix = drawQuadsMatrix.ToMatrix4x4();
			foreach (QuadRenderingData quadDraw in _quadDrawList)
			{
				Vector3d localPosition = quadDraw.LocalPosition;
				matrix.m03 = (float)(drawQuadsMatrix.m00 * localPosition.x + drawQuadsMatrix.m01 * localPosition.y + drawQuadsMatrix.m02 * localPosition.z + drawQuadsMatrix.m03);
				matrix.m13 = (float)(drawQuadsMatrix.m10 * localPosition.x + drawQuadsMatrix.m11 * localPosition.y + drawQuadsMatrix.m12 * localPosition.z + drawQuadsMatrix.m13);
				matrix.m23 = (float)(drawQuadsMatrix.m20 * localPosition.x + drawQuadsMatrix.m21 * localPosition.y + drawQuadsMatrix.m22 * localPosition.z + drawQuadsMatrix.m23);
				if (quadDraw.TerrainMesh != null)
				{
					Graphics.DrawMesh(quadDraw.TerrainMesh, matrix, quadDraw.TerrainMaterial, 29, camera, 0, null, ShadowCastingMode.Off, _terrainReceivesShadows, null, LightProbeUsage.Off, null);
				}
				if (quadDraw.WaterMesh != null)
				{
					Graphics.DrawMesh(quadDraw.WaterMesh, matrix, quadDraw.WaterMaterial, 4, camera, 0, null, ShadowCastingMode.Off, receiveShadows, null, LightProbeUsage.Off, null);
				}
			}
		}

		private void EditorCameraPreCull(Camera camera)
		{
		}

		private IEnumerator FullLodUpdateCoroutine()
		{
			StartFullLodUpdate();
			int jobCount = 6;
			while (jobCount > 0)
			{
				ProcessAsynchronousJobs(int.MaxValue);
				jobCount = _asyncJobProcessor.GetJobCount();
				yield return null;
			}
			CompleteFullLodUpdate();
		}

		private void GenerateBoundingBoxSampleIndexes()
		{
			int num = NumVerticesOnPaddedQuadEdge / 2;
			_boundingBoxSampleIndexes = new int[9]
			{
				NumVerticesOnPaddedQuadEdge + 1,
				NumVerticesOnPaddedQuadEdge + num,
				NumVerticesOnPaddedQuadEdge + NumVerticesOnPaddedQuadEdge - 2,
				NumVerticesOnPaddedQuadEdge * num + 1,
				NumVerticesOnPaddedQuadEdge * num + num,
				NumVerticesOnPaddedQuadEdge * (num + 1) - 2,
				NumVerticesOnPaddedQuadEdge * NumVerticesOnQuadEdge + 1,
				NumVerticesOnPaddedQuadEdge * NumVerticesOnQuadEdge + num,
				NumVerticesInPaddedQuad - 2
			};
		}

		private unsafe CreateQuadData GenerateQuadData(CreateQuadData data, int subdivisionLevel, Vector3d position, Quaterniond rotation, double scale, Vector2d uvCenter, double uvSize)
		{
			_ = data.PerformanceTracker;
			Stopwatch stopwatch = (Game.InPlanetStudioScene ? Stopwatch.StartNew() : null);
			data.SubdivisionLevel = subdivisionLevel;
			data.Position = position;
			data.Rotation = rotation;
			data.Scale = scale;
			data.UVCenter = uvCenter;
			data.UVSize = uvSize;
			bool flag = RequiredQuadMeshDataWater.HasFlag(QuadMeshDataFlags.UV4);
			bool flag2 = RequiredQuadMeshDataTerrain.HasFlag(QuadMeshDataFlags.UV4);
			Matrix4x4d matrix = data.Matrix;
			matrix.SetTRS(position, rotation, new Vector3d(scale, scale, scale));
			MeshDataTerrain.TerrainVertex[] vertices = data.TerrainMeshData.Item.Vertices;
			TerrainPointSample[] terrainPoints = data.TerrainPoints;
			Vector3d zero = Vector3d.zero;
			int num = 0;
			data.BelowSeaLevel = false;
			data.AboveSeaLevel = false;
			float num2 = float.MinValue;
			float num3 = float.MaxValue;
			float seaLevel = PlanetData.SeaLevel;
			bool uniformHeight = PlanetData.UniformHeight;
			TerrainGeneratorCacheData cacheData = _terrainGenerator.GetCacheData();
			PlanetVertexDataInput[] vertexDataInputs = cacheData.VertexDataInputs;
			PlanetVertexData[] vertexDataResults = cacheData.VertexDataResults;
			double num4 = 1.0 / Math.Pow(2.0, _uvSizeExponent);
			Vector2d vector2d = uvCenter * num4;
			double num5 = uvSize * 0.5 * num4;
			double num6 = uvSize * 0.5;
			cacheData.ModifierProfiler = ModifierProfiler;
			for (int i = 0; i < NumVerticesOnPaddedQuadEdge; i++)
			{
				for (int j = 0; j < NumVerticesOnPaddedQuadEdge; j++)
				{
					Vector3d v = _quadTemplateVertices[num];
					ref MeshDataTerrain.TerrainVertex reference = ref vertices[num];
					Vector4d vector4d = new Vector4d(v.x * num5 + vector2d.x, v.z * num5 + vector2d.y, v.x * num6 + uvCenter.x, v.z * num6 + uvCenter.y);
					if (uvSize <= 1.0)
					{
						vector4d.z -= (int)uvCenter.x;
						vector4d.w -= (int)uvCenter.y;
					}
					reference.Uv1 = vector4d.ToFloat4();
					Vector3d vector3d = matrix.MultiplyPoint3x4(v);
					vector3d.Normalize();
					if (_cubify)
					{
						double num7 = Mathd.Max(Mathd.Abs(vector3d.x), Mathd.Abs(vector3d.y), Mathd.Abs(vector3d.z));
						vector3d = new Vector3d(vector3d.x / num7, vector3d.y / num7, vector3d.z / num7);
					}
					vertexDataInputs[num].Position = vector3d;
					terrainPoints[num].SpherePosition = vector3d;
					num++;
				}
			}
			_terrainGenerator.GetVertexDataBiomeAndHeightPass(vertexDataInputs, cacheData);
			for (int k = 0; k < NumVerticesInPaddedQuad; k++)
			{
				PlanetVertexData planetVertexData = vertexDataResults[k];
				ref TerrainPointSample reference2 = ref terrainPoints[k];
				float num8 = (reference2.Height = (float)planetVertexData.Height);
				if (num8 < num3)
				{
					num3 = num8;
				}
				if (num8 > num2)
				{
					num2 = num8;
				}
				float num9 = num8;
				if (PlanetData.HasWater)
				{
					if (num8 > seaLevel)
					{
						data.AboveSeaLevel = true;
					}
					else if (num8 < seaLevel)
					{
						data.BelowSeaLevel = true;
						if (Device.IsMobileBuild && subdivisionLevel < MaxSubdivisionLevel)
						{
							float num10 = MaxSubdivisionLevel - subdivisionLevel + 1;
							num10 = num10 * num10 * 2f;
							num9 -= num10;
						}
					}
				}
				else
				{
					data.AboveSeaLevel = true;
				}
				zero += (reference2.Position = reference2.SpherePosition * (_radius + (double)num9));
			}
			if (_peakSmoothing)
			{
				num = NumVerticesOnPaddedQuadEdge * 2 + 3;
				for (int l = 2; l < NumVerticesOnPaddedQuadEdge - 2; l++)
				{
					for (int m = 3; m < NumVerticesOnPaddedQuadEdge - 1; m++)
					{
						float num11 = terrainPoints[num].Height - 0.25f;
						if (num11 > terrainPoints[num - 1].Height && num11 > terrainPoints[num + 1].Height && num11 > terrainPoints[num - NumVerticesOnPaddedQuadEdge].Height && num11 > terrainPoints[num + NumVerticesOnPaddedQuadEdge].Height)
						{
							TerrainPointSample terrainPointSample = terrainPoints[num];
							int num12 = num - 1;
							TerrainPointSample terrainPointSample2 = terrainPoints[num12];
							TerrainPointSample terrainPointSample3 = terrainPoints[num12 - NumVerticesOnPaddedQuadEdge];
							terrainPointSample2.Height = (terrainPointSample.Height + terrainPointSample3.Height) * 0.5f;
							terrainPointSample2.SpherePosition = (terrainPointSample.SpherePosition + terrainPointSample3.SpherePosition) * 0.5;
							terrainPointSample2.Position = (terrainPointSample.Position + terrainPointSample3.Position) * 0.5;
							terrainPoints[num12] = terrainPointSample2;
							vertices[num12].Uv1 = (vertices[num].Uv1 + vertices[num12 - NumVerticesOnPaddedQuadEdge].Uv1) * 0.5f;
						}
						num++;
					}
					num += 4;
				}
			}
			CreateQuadAxisAlignedBoundingBox(data, num3, num2);
			_terrainMinHeight = Mathd.Min(_terrainMinHeight, num3);
			_terrainMaxHeight = Mathd.Max(_terrainMaxHeight, num2);
			zero = (data.Center = new Vector3d((zero / _quadTemplateVertices.Length).ToVector3()));
			if (subdivisionLevel >= MinSubdivisionLevel)
			{
				num = 0;
				for (int n = 0; n < NumVerticesOnPaddedQuadEdge; n++)
				{
					for (int num13 = 0; num13 < NumVerticesOnPaddedQuadEdge; num13++)
					{
						if (!CoordinatesOnPaddedEdge(n, num13))
						{
							Vector3d normal;
							if (uniformHeight)
							{
								normal = terrainPoints[num].SpherePosition;
							}
							else
							{
								Vector3d lhs = terrainPoints[num + 1].Position - terrainPoints[num - 1].Position;
								Vector3d rhs = terrainPoints[num + NumVerticesOnPaddedQuadEdge].Position - terrainPoints[num - NumVerticesOnPaddedQuadEdge].Position;
								normal = Vector3d.Cross(lhs, rhs).normalized;
							}
							vertices[num].Normal = normal.ToFloat3();
							vertexDataInputs[num].Normal = normal;
						}
						else
						{
							vertexDataResults[num].OnPaddedQuadEdge = true;
						}
						num++;
					}
				}
				_terrainGenerator.GetVertexDataFinalPass(vertexDataInputs, cacheData);
				float4[] tempVertexFloat4x4Array = cacheData.TempVertexFloat4x4Array;
				int num14 = 0;
				int numVerticesInPaddedQuad = NumVerticesInPaddedQuad;
				for (int num15 = 0; num15 < numVerticesInPaddedQuad; num15++)
				{
					PlanetVertexData planetVertexData2 = vertexDataResults[num15];
					Color color = planetVertexData2.Color;
					tempVertexFloat4x4Array[num14++] = *(float4*)(&color);
					float[] splatMapData = planetVertexData2.SplatMapData;
					fixed (float* ptr = &splatMapData[0])
					{
						tempVertexFloat4x4Array[num14++] = *(float4*)ptr;
					}
					fixed (float* ptr2 = &splatMapData[4])
					{
						tempVertexFloat4x4Array[num14++] = *(float4*)ptr2;
					}
					tempVertexFloat4x4Array[num14++] = new float4(planetVertexData2.Metallicness, planetVertexData2.Smoothness, planetVertexData2.Emissiveness, 0f);
				}
				ulong gcHandle;
				void* data2 = UnsafeUtility.PinGCArrayAndGetDataAddress(tempVertexFloat4x4Array, out gcHandle);
				ulong gcHandle2;
				void* vertices2 = UnsafeUtility.PinGCArrayAndGetDataAddress(vertices, out gcHandle2);
				BurstFunctions.AssignColorSplatmapAndMaterialDataToVerticesInvoke(numVerticesInPaddedQuad, (float4*)data2, (MeshDataTerrain.TerrainVertex*)vertices2);
				UnsafeUtility.ReleaseGCObject(gcHandle);
				UnsafeUtility.ReleaseGCObject(gcHandle2);
				Vector3d normalized = zero.normalized;
				double num16 = scale / (double)NumVerticesOnQuadEdge;
				for (int num17 = 0; num17 < NumVerticesOnPaddedQuadEdge; num17++)
				{
					for (int num18 = 0; num18 < NumVerticesOnPaddedQuadEdge; num18++)
					{
						if (CoordinatesOnPaddedEdge(num17, num18))
						{
							int num19 = num17;
							int num20 = num18;
							if (num17 == 0)
							{
								num19++;
							}
							else if (num17 == NumVerticesOnPaddedQuadEdge - 1)
							{
								num19--;
							}
							if (num18 == 0)
							{
								num20++;
							}
							else if (num18 == NumVerticesOnPaddedQuadEdge - 1)
							{
								num20--;
							}
							int num21 = num18 * NumVerticesOnPaddedQuadEdge + num17;
							int num22 = num20 * NumVerticesOnPaddedQuadEdge + num19;
							ref MeshDataTerrain.TerrainVertex reference3 = ref vertices[num21];
							ref MeshDataTerrain.TerrainVertex reference4 = ref vertices[num22];
							reference3.Normal = reference4.Normal;
							reference3.Color = reference4.Color;
							reference3.Uv1 = reference4.Uv1;
							reference3.Uv2 = reference4.Uv2;
							reference3.Uv3 = reference4.Uv3;
							terrainPoints[num21].Position = terrainPoints[num22].Position - normalized * num16;
						}
					}
				}
				data.HasTerrain = data.AboveSeaLevel || _generateUnderwaterTerrainQuads;
				if (data.HasTerrain)
				{
					float3 float5 = new float3(float.MaxValue, float.MaxValue, float.MaxValue);
					float3 float6 = new float3(float.MinValue, float.MinValue, float.MinValue);
					int num23 = 0;
					for (int num24 = 0; num24 < NumVerticesOnPaddedQuadEdge; num24++)
					{
						for (int num25 = 0; num25 < NumVerticesOnPaddedQuadEdge; num25++)
						{
							ref MeshDataTerrain.TerrainVertex reference5 = ref vertices[num23];
							reference5.Position = (terrainPoints[num23].Position - zero).ToFloat3();
							float5 = math.min(float5, reference5.Position);
							float6 = math.max(float6, reference5.Position);
							num23++;
						}
					}
					float3 float7 = float6 - float5;
					data.TerrainMeshData.Item.Bounds = new Bounds(float6 - float7 / 2f, float7);
				}
				data.HasWater = data.BelowSeaLevel;
				if (data.HasWater)
				{
					MeshDataWater.WaterVertex[] vertices3 = data.WaterMeshData.Item.Vertices;
					float3 float8 = new float3(float.MaxValue, float.MaxValue, float.MaxValue);
					float3 float9 = new float3(float.MinValue, float.MinValue, float.MinValue);
					int num26 = 0;
					num = 0;
					for (int num27 = 1; num27 < NumVerticesOnPaddedQuadEdge - 1; num27 += WaterQuadVertexCountFactor)
					{
						for (int num28 = 1; num28 < NumVerticesOnPaddedQuadEdge - 1; num28 += WaterQuadVertexCountFactor)
						{
							num = num27 * NumVerticesOnPaddedQuadEdge + num28;
							ref MeshDataTerrain.TerrainVertex reference6 = ref vertices[num];
							ref MeshDataWater.WaterVertex reference7 = ref vertices3[num26];
							Vector3d spherePosition = terrainPoints[num].SpherePosition;
							float3 float10 = (spherePosition * (_radius + (double)seaLevel) - zero).ToFloat3();
							PlanetVertexData vertexDataWaterPass = _terrainGenerator.GetVertexDataWaterPass(spherePosition, reference6.Normal, num, cacheData);
							vertexDataWaterPass.Color.a = seaLevel - terrainPoints[num].Height;
							reference7.Position = float10;
							reference7.Normal = spherePosition.ToFloat3();
							reference7.Uv1 = reference6.Uv1;
							reference7.Uv2 = new Color(vertexDataWaterPass.Smoothness, vertexDataWaterPass.Metallicness, vertexDataWaterPass.Emissiveness, (float)(int)vertexDataWaterPass.WaveAmplitudeScale * 0.003921569f);
							reference7.Uv3 = new Color32(vertexDataWaterPass.ReflectionStrength, vertexDataWaterPass.TransparencyDepthScale, vertexDataWaterPass.TransparencyStrength, (byte)(vertexDataWaterPass.FoamStrength / 10 + vertexDataWaterPass.TextureStrength / 10 * 11));
							reference7.Color.x = (half)vertexDataWaterPass.Color.r;
							reference7.Color.y = (half)vertexDataWaterPass.Color.g;
							reference7.Color.z = (half)vertexDataWaterPass.Color.b;
							reference7.Color.w = (half)vertexDataWaterPass.Color.a;
							float8 = math.min(float8, float10);
							float9 = math.max(float9, float10);
							num26++;
						}
					}
					float3 float11 = float9 - float8;
					data.WaterMeshData.Item.Bounds = new Bounds(float9 - float11 / 2f, float9 - float8);
				}
			}
			if (data.TerrainMeshData.Item.VertexType == typeof(MeshDataTerrain.TerrainVertexBasic))
			{
				MeshDataTerrain.TerrainVertex[] vertices4 = data.TerrainMeshData.Item.Vertices;
				MeshDataTerrain.TerrainVertexBasic[] verticesBasic = data.TerrainMeshData.Item.VerticesBasic;
				int num29 = vertices4.Length;
				for (int num30 = 0; num30 < num29; num30++)
				{
					ref MeshDataTerrain.TerrainVertex reference8 = ref vertices4[num30];
					ref MeshDataTerrain.TerrainVertexBasic reference9 = ref verticesBasic[num30];
					reference9.Position = reference8.Position;
					reference9.Normal = reference8.Normal;
					reference9.Color = reference8.Color;
				}
			}
			if (stopwatch != null)
			{
				long elapsedTicks = stopwatch.ElapsedTicks;
				lock (_quadGenerationStatsLock)
				{
					_quadsGenerated++;
					_quadGenerationTimeTotal += elapsedTicks;
					_quadGenerationTimeMin = Math.Min(_quadGenerationTimeMin, elapsedTicks);
					_quadGenerationTimeMax = Math.Max(_quadGenerationTimeMax, elapsedTicks);
					_quadGenerationTimeAverage = (double)_quadGenerationTimeTotal / (double)_quadsGenerated;
				}
			}
			CustomCreateQuadData[] customData = data.CustomData;
			for (int num31 = 0; num31 < customData.Length; num31++)
			{
				customData[num31].OnQuadDataGenerated(cacheData, data);
			}
			try
			{
				data.EventArgs.Initialize(this);
				QuadSphereScript.CreateQuadDataCompleted?.Invoke(this, data.EventArgs);
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
			finally
			{
				data.EventArgs.Reset();
			}
			cacheData.ReturnToPool();
			return data;
		}

		private double GetQuadRootSize()
		{
			return Math.PI * 2.0 * PlanetData.Radius / 4.0;
		}

		private double GetQuadSize(int lodLevel)
		{
			return GetQuadRootSize() * Mathd.Pow(0.5, lodLevel);
		}

		[ContextMenu("Log LOD Distances")]
		private void LogLodDistances()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < _lodDistance.Length; i++)
			{
				stringBuilder.AppendFormat("{0}LOD {1}: {2:F0}", Environment.NewLine, i, _lodDistance[i]);
			}
			UnityEngine.Debug.LogFormat("Visibility Radius: {0:F2}{1}", _lodAndCullingData.VisibilityRadiusSquared, stringBuilder.ToString());
		}

		[ContextMenu("Log LOD Resolutions")]
		private void LogLodResolutions()
		{
			double quadRootSize = GetQuadRootSize();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Meters Per Vertex");
			double num = quadRootSize;
			for (int i = 0; i < 20; i++)
			{
				stringBuilder.AppendFormat("LOD {0}: {1:F2}{2}", i, num / (double)NumVerticesOnQuadEdge, Environment.NewLine);
				num /= 2.0;
			}
			UnityEngine.Debug.Log(stringBuilder);
		}

		[ContextMenu("Log Quad Counts")]
		private void LogQuadCounts()
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < _quadCounts.Length; i++)
			{
				int num2 = _quadCounts[i];
				stringBuilder.AppendLine($"Level {i,2}: {num2,5}");
				num += num2;
			}
			UnityEngine.Debug.LogFormat("Total Quads: {0,5}{1}{2}", num, Environment.NewLine, stringBuilder.ToString());
		}

		private void MergeQuad(QuadScript quad, bool returnToPool)
		{
			if (quad.IsSubdivided)
			{
				QuadScript[] children = quad.Children;
				foreach (QuadScript quad2 in children)
				{
					MergeQuad(quad2, returnToPool: true);
				}
				quad.ClearChildren();
				if (returnToPool)
				{
					quad.ReturnToPool();
				}
				else if (quad.IsRefreshRequired)
				{
					QuadRefreshJob quadRefreshJob = new QuadRefreshJob(GenerateCreateQuadData);
					quadRefreshJob.Initialize(quad);
					quadRefreshJob.Process();
					quadRefreshJob.Complete();
				}
			}
			else if (quad.IsSplitJobQueued)
			{
				quad.IsSubdivisionPending = false;
				quad.IsPendingReturnToPool = true;
			}
			else if (returnToPool)
			{
				quad.ReturnToPool();
			}
		}

		private void OnLodDistanceSettingChanged(object sender, SettingChangedEventArgs<float> e)
		{
			_splitDistanceFactor = e.Setting.Value;
			BuildLodTables();
			RebuildQuads(asynchronous: false);
		}

		private void OnRenderTechniqueChanged(QuadSphereRenderingTechnique previous, QuadSphereRenderingTechnique current)
		{
			Action<QuadScript> action = null;
			action = ((current != QuadSphereRenderingTechnique.MeshRenderers) ? ((Action<QuadScript>)delegate(QuadScript quad)
			{
				QuadRendererScript.Destroy(quad.QuadRenderer);
				quad.QuadRenderer = null;
			}) : ((Action<QuadScript>)delegate(QuadScript quad)
			{
				quad.QuadRenderer = QuadRendererScript.Create(quad);
			}));
			ExecuteOnAllQuads(action);
			_quadDrawList.Clear();
		}

		private void OnTerrainShadowsChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			_terrainReceivesShadows = e.Setting;
		}

		private void OnUnload()
		{
			TerrainRendererManagerScript.Instance?.RemoveRenderer(this);
			_terrainGenerator = new TerrainGeneratorDisposed(_terrainGenerator);
			if (_asyncJobProcessor != null)
			{
				_asyncJobProcessor.Dispose();
				_asyncJobProcessor = null;
			}
			foreach (QuadScript root in _roots)
			{
				UnloadQuad(root);
			}
		}

		private void OnWaterQualityChanged(object sender, SettingsChangedEventArgs<WaterQualitySettings> e)
		{
			_waterSupportsTransparency = e.Category.Transparency;
		}

		[ContextMenu("Rebuild LOD Table")]
		private void RebuildLodTable()
		{
			BuildLodTables();
			if (Device.IsUnityEditor)
			{
				LogLodDistances();
				LogLodResolutions();
			}
			RebuildQuads(asynchronous: true);
		}

		private void RebuildQuads(bool asynchronous)
		{
			foreach (QuadScript root in _roots)
			{
				MergeQuad(root, returnToPool: false);
			}
			if (asynchronous)
			{
				FullLodUpdateAsync();
			}
			else
			{
				FullLodUpdate();
			}
		}

		private int RefreshQuadsInRange(Vector3d cubePosition, double size, QuadScript quad)
		{
			int num = 0;
			Vector3d vector3d = quad.QuadPosition - cubePosition;
			if (Mathd.Abs(vector3d.x) < size + quad.QuadScale && Mathd.Abs(vector3d.y) < size + quad.QuadScale && Mathd.Abs(vector3d.z) < size + quad.QuadScale)
			{
				if (quad.Children != null)
				{
					QuadScript[] children = quad.Children;
					foreach (QuadScript quad2 in children)
					{
						num += RefreshQuadsInRange(cubePosition, size, quad2);
					}
				}
				else if (!quad.IsRefreshPending)
				{
					_asyncJobProcessor.QueueQuadRefreshJob(quad);
					num++;
				}
			}
			return num;
		}

		private void ResetCulling()
		{
			QuadRendererScript[] componentsInChildren = GetComponentsInChildren<QuadRendererScript>(includeInactive: true);
			foreach (QuadRendererScript obj in componentsInChildren)
			{
				obj.SetVisibility(!obj.Quad.IsSubdivided);
			}
		}

		private void SplitQuad(QuadScript quad, bool synchronous)
		{
			if (!synchronous)
			{
				_asyncJobProcessor.QueueQuadSplitJob(quad);
				return;
			}
			_synchronousQuadSplitJob.Initialize(quad);
			_synchronousQuadSplitJob.Process();
			_synchronousQuadSplitJob.Complete();
		}

		private void StartFullLodUpdate()
		{
			_fullLodUpdate = true;
			_lodAndCullingData.Update(this);
			foreach (QuadScript root in _roots)
			{
				UpdateQuadLod(root, allowSynchronous: false);
			}
		}

		private void UnloadQuad(QuadScript quad)
		{
			if (quad.Children != null)
			{
				QuadScript[] children = quad.Children;
				foreach (QuadScript quad2 in children)
				{
					UnloadQuad(quad2);
				}
			}
			quad.ReturnToPool();
		}

		private void UpdateCulling()
		{
			if (_disableCulling != _previousFrameCullingDisabled)
			{
				ResetCulling();
			}
			_previousFrameCullingDisabled = _disableCulling;
			if (!_disableCulling)
			{
				ClosestWaterQuadToCameraSqr = double.MaxValue;
				if (RenderingTechnique == QuadSphereRenderingTechnique.MeshRenderers)
				{
					foreach (QuadScript root in _roots)
					{
						UpdateQuadCullingForRenderers(root);
					}
					return;
				}
				_quadDrawList.Clear();
				{
					foreach (QuadScript root2 in _roots)
					{
						UpdateQuadCulling(root2);
					}
					return;
				}
			}
			if (RenderingTechnique != QuadSphereRenderingTechnique.DrawMesh)
			{
				return;
			}
			_quadDrawList.Clear();
			ExecuteOnAllQuads(delegate(QuadScript quad)
			{
				if (!quad.IsSubdivided)
				{
					_quadDrawList.Add(quad.RenderingData);
				}
			});
		}

		private void UpdateQuadCulling(QuadScript quad)
		{
			QuadRenderingData renderingData = quad.RenderingData;
			Vector3d p = renderingData.BoundingBoxRotation * _lodAndCullingData.CameraSurfacePosition;
			double squaredDistanceToClosestPoint = renderingData.BoundingBox.GetSquaredDistanceToClosestPoint(p);
			QuadScript[] children = quad.Children;
			if (squaredDistanceToClosestPoint > _lodAndCullingData.VisibilityRadiusSquared)
			{
				return;
			}
			if (children == null)
			{
				if (quad.HasWater && squaredDistanceToClosestPoint < ClosestWaterQuadToCameraSqr)
				{
					ClosestWaterQuadToCameraSqr = squaredDistanceToClosestPoint;
				}
				_quadDrawList.Add(renderingData);
			}
			else if (squaredDistanceToClosestPoint > _lodCullingDistance[quad.SubdivisionLevel] && quad.SubdivisionLevel >= MinSubdivisionLevel)
			{
				if (quad.HasWater && squaredDistanceToClosestPoint < ClosestWaterQuadToCameraSqr)
				{
					ClosestWaterQuadToCameraSqr = squaredDistanceToClosestPoint;
				}
				_quadDrawList.Add(renderingData);
			}
			else
			{
				UpdateQuadCulling(children[0]);
				UpdateQuadCulling(children[1]);
				UpdateQuadCulling(children[2]);
				UpdateQuadCulling(children[3]);
			}
		}

		private void UpdateQuadCullingForRenderers(QuadScript quad)
		{
			QuadRenderingData renderingData = quad.RenderingData;
			Vector3d p = renderingData.BoundingBoxRotation * _lodAndCullingData.CameraSurfacePosition;
			double squaredDistanceToClosestPoint = renderingData.BoundingBox.GetSquaredDistanceToClosestPoint(p);
			QuadScript[] children = quad.Children;
			if (squaredDistanceToClosestPoint > _lodAndCullingData.VisibilityRadiusSquared)
			{
				quad.QuadRenderer.SetVisibilityAndHideChildren(visible: false);
			}
			else if (children == null)
			{
				quad.QuadRenderer.SetVisibility(visible: true);
				if (quad.HasWater && squaredDistanceToClosestPoint < ClosestWaterQuadToCameraSqr)
				{
					ClosestWaterQuadToCameraSqr = squaredDistanceToClosestPoint;
				}
			}
			else if (squaredDistanceToClosestPoint > _lodCullingDistance[quad.SubdivisionLevel] && quad.SubdivisionLevel >= MinSubdivisionLevel)
			{
				quad.QuadRenderer.SetVisibilityAndHideChildren(visible: true);
				if (quad.HasWater && squaredDistanceToClosestPoint < ClosestWaterQuadToCameraSqr)
				{
					ClosestWaterQuadToCameraSqr = squaredDistanceToClosestPoint;
				}
			}
			else
			{
				quad.QuadRenderer.SetVisibility(visible: false);
				UpdateQuadCullingForRenderers(children[0]);
				UpdateQuadCullingForRenderers(children[1]);
				UpdateQuadCullingForRenderers(children[2]);
				UpdateQuadCullingForRenderers(children[3]);
			}
		}

		private void UpdateQuadLod(QuadScript quad, bool allowSynchronous)
		{
			QuadScript[] children = quad.Children;
			if (quad.SubdivisionLevel < MinSubdivisionLevel)
			{
				if (children == null)
				{
					if (allowSynchronous)
					{
						SplitQuad(quad, synchronous: true);
						children = quad.Children;
					}
					else if (quad.IsSplitJobQueued)
					{
						quad.IsSubdivisionPending = true;
					}
					else
					{
						SplitQuad(quad, synchronous: false);
					}
				}
				if (children != null)
				{
					UpdateQuadLod(children[0], allowSynchronous);
					UpdateQuadLod(children[1], allowSynchronous);
					UpdateQuadLod(children[2], allowSynchronous);
					UpdateQuadLod(children[3], allowSynchronous);
				}
				return;
			}
			double num = Mathd.Acos(Vector3d.Dot(_lodAndCullingData.TargetSurfacePositionNormalized, quad.SphereNormal)) * _radius + _lodAndCullingData.LodAltitude;
			if (children == null)
			{
				if (quad.SubdivisionLevel >= MaxSubdivisionLevel || !(num < _lodDistance[quad.SubdivisionLevel + 1]))
				{
					return;
				}
				bool flag = allowSynchronous && num < 50.0;
				if (flag || !quad.IsSplitJobQueued)
				{
					SplitQuad(quad, flag);
					if (flag)
					{
						children = quad.Children;
						UpdateQuadLod(children[0], allowSynchronous);
						UpdateQuadLod(children[1], allowSynchronous);
						UpdateQuadLod(children[2], allowSynchronous);
						UpdateQuadLod(children[3], allowSynchronous);
					}
				}
				else
				{
					quad.IsSubdivisionPending = true;
				}
			}
			else if (num > _lodMergeDistance[quad.SubdivisionLevel])
			{
				MergeQuad(quad, returnToPool: false);
			}
			else
			{
				UpdateQuadLod(children[0], allowSynchronous);
				UpdateQuadLod(children[1], allowSynchronous);
				UpdateQuadLod(children[2], allowSynchronous);
				UpdateQuadLod(children[3], allowSynchronous);
			}
		}

		private void WaitForFullLodUpdate()
		{
			for (int num = 6; num > 0; num = _asyncJobProcessor.GetJobCount())
			{
				Thread.Sleep(5);
				ProcessAsynchronousJobs(int.MaxValue);
			}
		}

		public static void Initialize_0024BurstFunctions_AssignColorSplatmapAndMaterialDataToVertices_000006FE_0024BurstDirectCall()
		{
			BurstFunctions.AssignColorSplatmapAndMaterialDataToVertices_000006FE_0024BurstDirectCall.Initialize();
		}
	}
}
