using System;
using System.Collections.Generic;
using Assets.Scripts.Bindings.Manifold;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Parts.Events;
using Assets.Scripts.Craft.Parts.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers.CarverParts;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Design;
using BuoyancyToolkit;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using Unity.Collections;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class JFuselageScript : PartModifierScript
	{
		private struct Neighbour : IEquatable<Neighbour>
		{
			public JFuselageScript Fuselage;

			public int SliceIndex;

			public static bool operator !=(Neighbour a, Neighbour b)
			{
				if (!(a.Fuselage != b.Fuselage))
				{
					return a.SliceIndex != b.SliceIndex;
				}
				return true;
			}

			public static bool operator ==(Neighbour a, Neighbour b)
			{
				if (a.Fuselage == b.Fuselage)
				{
					return a.SliceIndex == b.SliceIndex;
				}
				return false;
			}

			public override readonly bool Equals(object obj)
			{
				if (obj is Neighbour neighbour)
				{
					return this == neighbour;
				}
				return false;
			}

			public readonly bool Equals(Neighbour other)
			{
				return this == other;
			}

			public override readonly int GetHashCode()
			{
				return HashCode.Combine(Fuselage, SliceIndex);
			}
		}

		private struct BakeMeshJob : IJob
		{
			public const MeshColliderCookingOptions DefaultOptions = MeshColliderCookingOptions.CookForFasterSimulation | MeshColliderCookingOptions.EnableMeshCleaning | MeshColliderCookingOptions.WeldColocatedVertices | MeshColliderCookingOptions.UseFastMidphase;

			public bool Convex;

			public MeshColliderCookingOptions CookingOptions;

			public int InstanceID;

			public void Execute()
			{
				Physics.BakeMesh(InstanceID, Convex, CookingOptions);
			}
		}

		private struct ColliderBuildData
		{
			public MeshCollider[] Colliders;

			public Mesh[] TargetMeshes;
		}

		private struct ColliderBuilder
		{
			public NativeList<ColliderOut> Output;

			public NativeList<int3> Triangles;

			public NativeList<float3> Verts;

			public ColliderBuilder(Allocator allocator)
			{
				Output = new NativeList<ColliderOut>(16, allocator);
				Triangles = new NativeList<int3>(256, allocator);
				Verts = new NativeList<float3>(256, allocator);
			}

			public void AddFromManifold(Manifold<Vertex> manifold)
			{
				if (manifold.IsEmpty || manifold.Status != Error.NO_ERROR || manifold.Volume < 1.1920928955078125E-07)
				{
					return;
				}
				ColliderOut value = new ColliderOut
				{
					BaseTriangle = Triangles.Length,
					BaseVertex = Verts.Length
				};
				using MeshGL<Vertex> meshGL = MeshGL<Vertex>.Create(Allocator.Temp, manifold);
				int num = (int)meshGL.NumVert;
				NativeArray<Vertex> nativeArray = new NativeArray<Vertex>(num, Allocator.Temp);
				meshGL.GetVertices(nativeArray);
				Verts.Length += num;
				nativeArray.Slice().SliceWithStride<float3>().CopyTo(Verts.AsArray().GetSubArray(value.BaseVertex, num));
				value.VertexCount = num;
				int num2 = (int)(meshGL.IndexCount / 3);
				Triangles.Length += num2;
				meshGL.GetIndices(Triangles.AsArray().GetSubArray(value.BaseTriangle, num2).Reinterpret<uint>(12));
				value.TriangleCount = num2;
				Output.Add(in value);
			}

			public void Clear()
			{
				Output.Clear();
				Triangles.Clear();
				Verts.Clear();
			}

			public void CopyFrom(ColliderBuilder other)
			{
				Output.Length = other.Output.Length;
				Output.AsArray().CopyFrom(other.Output.AsArray());
				Triangles.Length = other.Triangles.Length;
				Triangles.AsArray().CopyFrom(other.Triangles.AsArray());
				Verts.Length = other.Verts.Length;
				Verts.AsArray().CopyFrom(other.Verts.AsArray());
			}

			public Manifold<Vertex> CreateManifold(int i, Allocator allocator, out Error error)
			{
				ColliderOut colliderOut = Output[i];
				NativeArray<float3> subArray = Verts.AsArray().GetSubArray(colliderOut.BaseVertex, colliderOut.VertexCount);
				NativeArray<int3> subArray2 = Triangles.AsArray().GetSubArray(colliderOut.BaseTriangle, colliderOut.TriangleCount);
				NativeArray<Vertex> nativeArray = new NativeArray<Vertex>(subArray.Length, Allocator.Temp);
				nativeArray.Slice().SliceWithStride<float3>().CopyFrom(subArray);
				Span<MeshGLBase.Run> runs = stackalloc MeshGLBase.Run[1];
				runs[0] = new MeshGLBase.Run
				{
					StartIndex = 0u,
					EndIndex = (uint)(subArray2.Length * 3),
					OriginalID = 0u
				};
				MeshGL<Vertex> meshGL = MeshGL<Vertex>.Create(allocator, nativeArray, subArray2.Reinterpret<uint3>(), runs);
				MeshGL<Vertex> meshGL2 = meshGL.Merge(Allocator.Temp);
				if (meshGL2 != meshGL)
				{
					meshGL.Dispose();
				}
				Manifold<Vertex> manifold;
				try
				{
					manifold = Manifold.Create(allocator, meshGL2);
				}
				finally
				{
					meshGL2.Dispose();
				}
				error = manifold.Status;
				if (error != Error.NO_ERROR)
				{
					Debug.LogError($"Failed to create manifold for collider mesh {i}: {manifold.Status}");
					manifold.Dispose();
					return null;
				}
				return manifold;
			}

			public void DisposeIfCreated()
			{
				Extensions.DisposeIfCreated(ref Output);
				Extensions.DisposeIfCreated(ref Verts);
				Extensions.DisposeIfCreated(ref Triangles);
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker ApplyCutting = new ProfilerMarker("JFuselageScript.ApplyCutting");

			public static readonly ProfilerMarker ApplyManifoldModifiers = new ProfilerMarker("JFuselageScript.ApplyMeshModifiers");

			public static readonly ProfilerMarker ApplySmoothing = new ProfilerMarker("JFuselageScript.ApplySmoothing");

			public static readonly ProfilerMarker ColliderBake = new ProfilerMarker("JFuselageScript.ColliderBake");

			public static readonly ProfilerMarker FinaliseMesh = new ProfilerMarker("JFuselageScript.FinaliseMesh");

			public static readonly ProfilerMarker FindNeighbours = new ProfilerMarker("JFuselageScript.FindNeighbours");

			public static readonly ProfilerMarker GenerateBaseMesh = new ProfilerMarker("JFuselageScript.GenerateBaseMesh");

			public static readonly ProfilerMarker GetLatestMeshAsManifold = new ProfilerMarker("JFuselageScript.GetLatestMeshAsManifold");

			public static readonly ProfilerMarker RequireThinManifold = new ProfilerMarker("JFuselageScript.RequireThinManifold");

			public static readonly ProfilerMarker Setup = new ProfilerMarker("JFuselageScript.Setup");
		}

		private NativeMesh _baseMesh;

		private ColliderBuilder _baseColliderData;

		private FuselageColliderType _colliderType;

		private float3[] _baseAttachPointPositions;

		private Manifold<Vertex> _baseManifold;

		private Manifold<Vertex> _thinManifold;

		private float4[] _minSlicing = new float4[2] { 0f, 0f };

		private ColliderBuildData? _bakingColliders;

		private JobHandle? _colliderBake;

		private Manifold<Vertex> _postCuttingManifold;

		private List<Manifold<Vertex>> _postCuttingManifoldColliders = new List<Manifold<Vertex>>();

		private float3[] _postCuttingAttachPoints;

		private Neighbour?[] _neighbours;

		private Manifold<Vertex> _postModifiersManifold;

		private Manifold<Vertex> _postModifiersColliderManifold;

		private NativeMesh _postSmoothingMesh;

		private bool _postSmoothingMeshValid;

		private Manifold<Vertex> _postSmoothingManifold;

		public const int FuselageInitOrderBase = 510;

		public const int InitOrderAfterFuselageGenerated = 519;

		public const int MeshModifierCheckLayer = 25;

		private static bool _changesSuspended;

		private static Dictionary<JFuselageScript, FuselageGenerationStage> _suspendedChangeQueue = new Dictionary<JFuselageScript, FuselageGenerationStage>();

		private List<Mesh> _colliderMeshes = new List<Mesh>();

		private bool _destroyed;

		private PreStartInitializationDelegate[] _generationDelegates;

		private bool _initComplete;

		private FuselageGenerationStage _lastCompletedStage;

		private List<MeshCollider> _meshColliders = new List<MeshCollider>();

		private Pose? _prevPose;

		private ProceduralPartMeshRenderer _renderer;

		private Mesh _meshModifierCheckMesh;

		private MeshCollider _meshModifierCheckCollider;

		public MinMaxAABB BaseMeshBounds { get; private set; }

		public JFuselageData Data { get; private set; }

		public bool IsBackwards => base.transform.forward.z < -0.0001f;

		public HashSet<MeshModifierBaseScript> MeshModifiers { get; } = new HashSet<MeshModifierBaseScript>();

		public float4[] MinCutting => _minSlicing;

		private void CleanupBaseMeshStage()
		{
			_baseMesh.DisposeIfCreated();
			_baseColliderData.DisposeIfCreated();
			_baseManifold?.Dispose();
			_baseManifold = null;
			_thinManifold?.Dispose();
			_thinManifold = null;
		}

		private async UniTask GenerateBaseMesh(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			CheckStage(FuselageGenerationStage.BaseMesh);
			_baseManifold?.Dispose();
			_baseManifold = null;
			_thinManifold?.Dispose();
			_thinManifold = null;
			PrepareMeshBuilder(ref _baseMesh, Allocator.Persistent);
			PrepareColliderBuilder(ref _baseColliderData, Allocator.Persistent);
			using NativeArray<float3> attachPoints = new NativeArray<float3>(6, Allocator.TempJob);
			using NativeArray<float4> minSlicing = new NativeArray<float4>(2, Allocator.TempJob);
			FuselageStyle style = Data.Style;
			bool isCone = Data.IsCone;
			FuselageColliderType colliderType = (_colliderType = (Data.OverrideColliderType.HasValue ? Data.OverrideColliderType.Value : ((loadContext == CraftLoadContext.Designer) ? FuselageColliderType.TriangleMesh : ((style == FuselageStyle.Hollow) ? FuselageColliderType.ConvexSegments : FuselageColliderType.SingleConvex))));
			int length = (isCone ? 3 : 2);
			using NativeList<float4> cutPlanes = new NativeList<float4>(4, Allocator.TempJob);
			using NativeArray<float4> areaVolumeOut = new NativeArray<float4>(2, Allocator.TempJob);
			using NativeArray<SectionParams> slices_ = new NativeArray<SectionParams>(length, Allocator.TempJob);
			using NativeArray<float3> slicePos_ = new NativeArray<float3>(length, Allocator.TempJob);
			using NativeReference<MinMaxAABB> boundsOut = new NativeReference<MinMaxAABB>(Allocator.TempJob);
			NativeArray<SectionParams> sections = slices_;
			NativeArray<float3> sectionPositions = slicePos_;
			GetCuttingPlanes(cutPlanes);
			int minInterpSlices = 0;
			bool noseconeSharp = false;
			if (isCone)
			{
				sectionPositions[0] = Data.Offset * -0.5f;
				sections[0] = Data.SectionA;
				sectionPositions[2] = Data.Offset * 0.5f;
				sections[2] = new SectionParams
				{
					CornerRadii = 1f,
					CornersStretch = 1f,
					CornerSamples = Data.SectionB.CornerSamples,
					EdgeCurvature = 0f,
					EdgeSamples = Data.SectionB.EdgeSamples,
					Size = 0f,
					Thickness = 0f,
					Trapezium = 0f,
					AbsoluteThickness = Data.SectionB.AbsoluteThickness
				};
				float num = math.saturate(Data.NoseconeRoundness);
				sections[1] = SectionParams.Lerp(SectionParams.Lerp(sections[0], sections[2], 0.5f), Data.SectionB, num);
				sectionPositions[1] = 0.5f * num * Data.Offset;
				minInterpSlices = 5;
				noseconeSharp = num < 0.75f;
			}
			else
			{
				sections[0] = Data.SectionA;
				sections[1] = Data.SectionB;
				sectionPositions[0] = Data.Offset * -0.5f;
				sectionPositions[1] = Data.Offset * 0.5f;
			}
			FuselageJob jobData = new FuselageJob
			{
				Mesh = _baseMesh,
				Style = style,
				ColliderType = colliderType,
				NumColliders = Data.NumColliders,
				ColliderCornerSamples = Data.ColliderCornerSamples,
				ColliderOutput = _baseColliderData.Output,
				ColliderTriangles = _baseColliderData.Triangles,
				ColliderVertices = _baseColliderData.Verts,
				CuttingPlanesForMass = cutPlanes.AsArray(),
				AreaVolumeOut = areaVolumeOut,
				BoundsOut = boundsOut,
				Sections = sections,
				SectionPositions = sectionPositions,
				MaxEdgeRotationPerSlice = math.radians(10f),
				MinInterpSlices = minInterpSlices,
				NoseconeSharp = noseconeSharp,
				AttachPointPositions = attachPoints,
				MinSlicing = minSlicing
			};
			if (async)
			{
				JobHandle handle = jobData.Schedule();
				await handle.ToUniTask(PlayerLoopTiming.Update);
				handle.Complete();
			}
			else
			{
				jobData.Run();
			}
			BaseMeshBounds = boundsOut.Value;
			Data.OnMeshGenerated(areaVolumeOut[1], areaVolumeOut[0], !_initComplete, GetFuelVolume(areaVolumeOut[1]));
			_initComplete = true;
			if (_baseAttachPointPositions == null || _baseAttachPointPositions.Length != attachPoints.Length)
			{
				_baseAttachPointPositions = attachPoints.ToArray();
			}
			else
			{
				attachPoints.CopyTo(_baseAttachPointPositions);
			}
			minSlicing.CopyTo(_minSlicing);
			Data.InvokeOnUpdateMinCutting(_minSlicing);
			UpdateFuel();
			_lastCompletedStage = FuselageGenerationStage.BaseMesh;
		}

		private unsafe void StartColliderBake()
		{
			if (_bakingColliders.HasValue)
			{
				return;
			}
			bool flag = false;
			ColliderBuilder colliderBuilder;
			if (_colliderType == FuselageColliderType.TriangleMesh)
			{
				flag = true;
				colliderBuilder = default(ColliderBuilder);
			}
			else if (_postCuttingManifoldColliders.Count > 0)
			{
				colliderBuilder = new ColliderBuilder(Allocator.Temp);
				for (int i = 0; i < _postCuttingManifoldColliders.Count; i++)
				{
					colliderBuilder.AddFromManifold(_postCuttingManifoldColliders[i]);
				}
			}
			else
			{
				colliderBuilder = _baseColliderData;
			}
			int num = (flag ? 1 : colliderBuilder.Output.Length);
			AttachPointScript component = GetComponent<AttachPointScript>();
			ColliderBuildData value = new ColliderBuildData
			{
				Colliders = new MeshCollider[num],
				TargetMeshes = new Mesh[num]
			};
			bool convex = _colliderType != FuselageColliderType.TriangleMesh;
			_bakingColliders = value;
			List<EditorCollider> list = null;
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				list = base.PartScript.EditorColliders;
				list.Clear();
			}
			for (int j = 0; j < num; j++)
			{
				string text = $"Part-{base.PartScript.Part.Id}-Collider-{j}";
				MeshCollider meshCollider;
				if (j < _meshColliders.Count)
				{
					meshCollider = _meshColliders[j];
				}
				else
				{
					GameObject obj = new GameObject(text);
					obj.transform.SetParent(base.transform);
					meshCollider = obj.AddComponent<MeshCollider>();
					_meshColliders.Add(meshCollider);
				}
				meshCollider.transform.SetLocalPositionAndRotation(default(Vector3), Quaternion.identity);
				Mesh mesh = meshCollider.sharedMesh;
				if (mesh == null)
				{
					mesh = new Mesh
					{
						name = text
					};
					_colliderMeshes.Add(mesh);
				}
				if (!flag)
				{
					ColliderOut colliderOut = colliderBuilder.Output[j];
					mesh.Clear();
					mesh.SetVertices(colliderBuilder.Verts.AsArray().GetSubArray(colliderOut.BaseVertex, colliderOut.VertexCount));
					mesh.SetIndices(colliderBuilder.Triangles.AsArray().GetSubArray(colliderOut.BaseTriangle, colliderOut.TriangleCount).Reinterpret<int>(12), MeshTopology.Triangles, 0);
					mesh.RecalculateBounds();
					mesh.MarkModified();
					if (meshCollider.sharedMesh != mesh)
					{
						meshCollider.sharedMesh = null;
					}
				}
				value.TargetMeshes[j] = mesh;
				value.Colliders[j] = meshCollider;
				meshCollider.convex = convex;
				if (component != null && base.LoadContext == CraftLoadContext.Designer)
				{
					if (!meshCollider.TryGetComponent<AttachPointProxyScript>(out var component2))
					{
						component2 = meshCollider.gameObject.AddComponent<AttachPointProxyScript>();
					}
					component2.AttachPointScript = component;
					meshCollider.gameObject.layer = ((base.gameObject.layer == 2) ? 2 : 15);
				}
				if (base.LoadContext == CraftLoadContext.Designer && !meshCollider.TryGetComponent<DecalTargetColliderScript>(out var _))
				{
					meshCollider.gameObject.AddComponent<DecalTargetColliderScript>().DecalTargets.Add(_renderer.DecalTargetScript);
				}
				bool flag2 = j == 0;
				PartColliderScript component4;
				bool flag3 = meshCollider.TryGetComponent<PartColliderScript>(out component4);
				if (flag3 && component4.IsPrimary != flag2)
				{
					UnityEngine.Object.Destroy(component4);
					flag3 = false;
				}
				if (!flag3)
				{
					component4 = (flag2 ? PartColliderScript.AddAsPrimary(meshCollider.gameObject) : meshCollider.gameObject.AddComponent<PartColliderScript>());
				}
				if (flag2)
				{
					base.PartScript.PrimaryPartCollider = meshCollider;
				}
				list?.Add(new EditorCollider(meshCollider, base.PartScript, component4));
			}
			for (int num2 = _meshColliders.Count - 1; num2 >= num; num2--)
			{
				MeshCollider meshCollider2 = _meshColliders[num2];
				Mesh sharedMesh = meshCollider2.sharedMesh;
				int num3 = _colliderMeshes.IndexOf(sharedMesh);
				if (num3 != -1)
				{
					UnityEngine.Object.Destroy(sharedMesh);
					_colliderMeshes.RemoveAtSwapBack(num3);
				}
				UnityEngine.Object.Destroy(meshCollider2.gameObject);
				_meshColliders.RemoveAt(num2);
			}
			if (!flag)
			{
				Span<JobHandle> span = stackalloc JobHandle[num];
				for (int k = 0; k < num; k++)
				{
					span[k] = new BakeMeshJob
					{
						Convex = convex,
						CookingOptions = (MeshColliderCookingOptions.CookForFasterSimulation | MeshColliderCookingOptions.EnableMeshCleaning | MeshColliderCookingOptions.WeldColocatedVertices | MeshColliderCookingOptions.UseFastMidphase),
						InstanceID = value.TargetMeshes[k].GetInstanceID()
					}.Schedule();
				}
				fixed (JobHandle* jobs = span)
				{
					_colliderBake = JobHandleUnsafeUtility.CombineDependencies(jobs, span.Length);
				}
			}
		}

		private void CleanupCuttingStage()
		{
			_postCuttingManifold?.Dispose();
			_postCuttingManifold = null;
			foreach (Manifold<Vertex> postCuttingManifoldCollider in _postCuttingManifoldColliders)
			{
				postCuttingManifoldCollider.Dispose();
			}
			_postCuttingManifoldColliders.Clear();
		}

		private UniTask ApplyCutting(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			using (Profile.ApplyCutting.Auto())
			{
				ApplyCuttingImpl();
				_lastCompletedStage = FuselageGenerationStage.Cutting;
				return UniTask.CompletedTask;
			}
		}

		private void ApplyCuttingImpl()
		{
			CheckStage(FuselageGenerationStage.Cutting);
			CleanupCuttingStage();
			float4 float5 = (float4)Data.GetCutting(0);
			float4 float6 = (float4)Data.GetCutting(1);
			bool4 bool5 = (float5 > _minSlicing[0]) | (float6 > _minSlicing[1]);
			if (!math.any(bool5))
			{
				return;
			}
			float4 falseValue = _minSlicing[0] - 1f;
			float4 falseValue2 = _minSlicing[1] - 1f;
			float5 = math.select(falseValue, float5, bool5);
			float6 = math.select(falseValue2, float6, bool5);
			float5 = math.select(_minSlicing[0], float5, math.isfinite(float5));
			float6 = math.select(_minSlicing[1], float6, math.isfinite(float6));
			SectionParams sliceRefUntracked = Data.GetSliceRefUntracked(0);
			SectionParams sliceRefUntracked2 = Data.GetSliceRefUntracked(1);
			float3 float7 = Data.Offset * 0.5f;
			Manifold<Vertex> latestMeshAsManifold = GetLatestMeshAsManifold(FuselageGenerationStage.Cutting);
			if (latestMeshAsManifold == null)
			{
				_lastCompletedStage = FuselageGenerationStage.Cutting;
				return;
			}
			new float2(0f, 1f);
			float4 float8 = (0.5f - float5.wzyx) * math.float4(-sliceRefUntracked.Size, sliceRefUntracked.Size) - float7.xyxy;
			float4 float9 = (0.5f - float6.wzyx) * math.float4(-sliceRefUntracked2.Size, sliceRefUntracked2.Size) + float7.xyxy;
			using Manifold<Vertex> manifold = JFuselageCutter.MakeCutVolume(4, float7.z, float8.xy, float8.zw, float9.xy, float9.zw);
			if (manifold == null)
			{
				_lastCompletedStage = FuselageGenerationStage.Cutting;
				return;
			}
			Manifold<Vertex> manifold2 = latestMeshAsManifold.Intersect(manifold);
			if (manifold2.Status != Error.NO_ERROR)
			{
				Debug.Log($"Cutting failed to apply to visual mesh: {manifold2.Status}");
				_lastCompletedStage = FuselageGenerationStage.Cutting;
				return;
			}
			_postCuttingManifold = manifold2;
			ColliderBuilder baseColliderData = _baseColliderData;
			bool flag = true;
			for (int i = 0; i < baseColliderData.Output.Length; i++)
			{
				Error error;
				Manifold<Vertex> manifold3 = baseColliderData.CreateManifold(i, Allocator.Persistent, out error);
				if (manifold3 == null)
				{
					flag = false;
					break;
				}
				Manifold<Vertex> manifold4 = manifold3.Intersect(manifold);
				if (manifold4 != manifold3)
				{
					manifold3.Dispose();
				}
				if (manifold4.Status != Error.NO_ERROR)
				{
					flag = false;
					manifold4.Dispose();
					break;
				}
				if (manifold4.IsEmpty)
				{
					manifold4.Dispose();
				}
				else
				{
					_postCuttingManifoldColliders.Add(manifold4);
				}
			}
			if (!flag)
			{
				_postCuttingManifoldColliders.Clear();
				return;
			}
			float4 float10 = (float9 + float8) * 0.5f;
			float2 xy = float10.xy;
			float2 zw = float10.zw;
			float3[] array = _postCuttingAttachPoints;
			if (array?.Length != _baseAttachPointPositions.Length)
			{
				array = (_postCuttingAttachPoints = new float3[_baseAttachPointPositions.Length]);
			}
			_baseAttachPointPositions.AsSpan().CopyTo(array);
			for (int j = 2; j < array.Length; j++)
			{
				array[j].xy = math.clamp(array[j].xy, xy, zw);
			}
		}

		private UniTask FindNeighbours(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			CheckStage(FuselageGenerationStage.FindNeighbours);
			using (Profile.FindNeighbours.Auto())
			{
				int numSections = Data.NumSections;
				if (_neighbours == null || _neighbours.Length != numSections)
				{
					_neighbours = new Neighbour?[numSections];
				}
				for (int i = 0; i < numSections; i++)
				{
					_neighbours[i] = null;
					if (Data.TryGetNeighbour(i, out var neighbourFuselage, out var neighbourSliceIndex))
					{
						JFuselageScript modifier = neighbourFuselage.Part.PartScript.GetModifier<JFuselageScript>();
						if (neighbourFuselage != null)
						{
							_neighbours[i] = new Neighbour
							{
								Fuselage = modifier,
								SliceIndex = neighbourSliceIndex
							};
						}
					}
				}
				_lastCompletedStage = FuselageGenerationStage.FindNeighbours;
				return UniTask.CompletedTask;
			}
		}

		private UniTask ApplyMeshModifiers(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			using (Profile.ApplyManifoldModifiers.Auto())
			{
				CheckStage(FuselageGenerationStage.MeshModifiers);
				ApplyMeshModifiersImpl();
				_lastCompletedStage = FuselageGenerationStage.MeshModifiers;
				return UniTask.CompletedTask;
			}
		}

		private void CleanupMeshModifierStage()
		{
			_postModifiersManifold?.Dispose();
			_postModifiersManifold = null;
			_postModifiersColliderManifold?.Dispose();
			_postModifiersColliderManifold = null;
		}

		private void ApplyMeshModifiersImpl()
		{
			CleanupMeshModifierStage();
			Manifold<Vertex> latestMeshAsManifold;
			if (MeshModifiers.Count == 0 || (latestMeshAsManifold = GetLatestMeshAsManifold(FuselageGenerationStage.MeshModifiers)) == null)
			{
				return;
			}
			MeshModifierBaseScript[] array = new MeshModifierBaseScript[MeshModifiers.Count];
			MeshModifiers.CopyTo(array);
			Array.Sort(array, (MeshModifierBaseScript a, MeshModifierBaseScript b) => a.PartScript.Part.Id.CompareTo(b.PartScript.Part.Id));
			Manifold<Vertex> storage = latestMeshAsManifold.Copy(Allocator.Persistent);
			Manifold<Vertex> storage2 = null;
			MeshModifierBaseScript[] array2 = array;
			foreach (MeshModifierBaseScript meshModifierBaseScript in array2)
			{
				if (meshModifierBaseScript == null)
				{
					MeshModifiers.Remove(meshModifierBaseScript);
					continue;
				}
				Manifold<Vertex> colliderManifold = storage;
				try
				{
					if (SetManifold(meshModifierBaseScript.ApplyToPart(this, storage2 ?? latestMeshAsManifold, ref colliderManifold, Allocator.Persistent), ref storage2) && colliderManifold != null && colliderManifold != storage)
					{
						SetManifold(colliderManifold, ref storage);
					}
				}
				catch (Exception arg)
				{
					Debug.LogError($"Exception while applying mesh modifier {meshModifierBaseScript.PartScript.Part.Id} to part {base.PartScript.Part.Id}: {arg}");
				}
			}
			_postModifiersManifold = storage2;
			_postModifiersColliderManifold = storage;
		}

		private void CleanupSmoothingStage()
		{
			_postSmoothingMeshValid = false;
			_postSmoothingMesh.DisposeIfCreated();
			_postSmoothingManifold?.Dispose();
			_postSmoothingManifold = null;
		}

		private async UniTask ApplySmoothing(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			CheckStage(FuselageGenerationStage.Smoothing);
			_postSmoothingMeshValid = false;
			_postSmoothingManifold?.Dispose();
			_postSmoothingManifold = null;
			bool meshReady = false;
			for (int i = 0; i < _neighbours.Length; i++)
			{
				if (HasSmoothingAtFace(i, out var thisSmooth, out var otherSmooth) && thisSmooth)
				{
					if (!meshReady)
					{
						PrepareMeshBuilder(ref _postSmoothingMesh, Allocator.Persistent);
						_postSmoothingMesh.CopyFrom(GetLatestMesh(FuselageGenerationStage.Smoothing));
						meshReady = true;
					}
					JFuselageScript fuselage = _neighbours[i].Value.Fuselage;
					ulong num = 9uL;
					RigidTransform rt = GetPartAircraftLocalTransform(base.PartScript);
					RigidTransform bTransform = math.mul(b: GetPartAircraftLocalTransform(fuselage.PartScript), a: rt.Inverse());
					FuselageSmoothJob jobData = new FuselageSmoothJob
					{
						MeshA = _postSmoothingMesh,
						MeshB = fuselage._baseMesh,
						BTransform = bTransform,
						MeshASubmeshMask = num,
						MeshBSubmeshMask = num,
						MergeRadius = 0.01f,
						SetMean = otherSmooth
					};
					if (async)
					{
						await jobData.Schedule().ToUniTask(PlayerLoopTiming.Update);
					}
					else
					{
						jobData.Run();
					}
					_postSmoothingMeshValid = true;
				}
			}
			_lastCompletedStage = FuselageGenerationStage.Smoothing;
			RigidTransform GetPartAircraftLocalTransform(PartScript part)
			{
				if (base.LoadContext == CraftLoadContext.Designer)
				{
					return new RigidTransform(part.transform.rotation, part.transform.position);
				}
				return new RigidTransform(Quaternion.Euler(part.Part.Rotation), part.Part.Position);
			}
		}

		public static bool ApplyBufferedChanges()
		{
			if (!_changesSuspended)
			{
				return false;
			}
			bool result = false;
			try
			{
				if (_suspendedChangeQueue.Count == 0)
				{
					return false;
				}
				List<JFuselageScript> list = new List<JFuselageScript>(_suspendedChangeQueue.Count);
				List<JFuselageScript> list2 = new List<JFuselageScript>();
				for (int i = 0; i < 9; i++)
				{
					FuselageGenerationStage fuselageGenerationStage = (FuselageGenerationStage)i;
					foreach (KeyValuePair<JFuselageScript, FuselageGenerationStage> item in _suspendedChangeQueue)
					{
						if (item.Value == fuselageGenerationStage && item.Key != null && !item.Key._destroyed)
						{
							list.Add(item.Key);
						}
					}
					if (fuselageGenerationStage == FuselageGenerationStage.BaseMesh && list.Count != 0)
					{
						result = true;
					}
					foreach (JFuselageScript item2 in list)
					{
						try
						{
							item2.ExecuteSync(item2._generationDelegates[i]);
						}
						catch (Exception arg)
						{
							Debug.LogError($"Exception while regenerating fuselage: {arg}");
							list2.Add(item2);
						}
					}
					foreach (JFuselageScript item3 in list2)
					{
						list.Remove(item3);
					}
					list2.Clear();
					if (fuselageGenerationStage != FuselageGenerationStage.FindNeighbours)
					{
						continue;
					}
					int count = list.Count;
					for (int j = 0; j < count; j++)
					{
						JFuselageScript jFuselageScript = list[j];
						if (_suspendedChangeQueue[jFuselageScript] > FuselageGenerationStage.BaseMesh)
						{
							continue;
						}
						for (int k = 0; k < jFuselageScript._neighbours.Length; k++)
						{
							if (!(jFuselageScript.HasSmoothingAtFace(k, out var _, out var otherSmooth) && otherSmooth))
							{
								continue;
							}
							JFuselageScript fuselage = jFuselageScript._neighbours[k].Value.Fuselage;
							if (_suspendedChangeQueue.TryGetValue(fuselage, out var value))
							{
								if (value > fuselageGenerationStage)
								{
									_suspendedChangeQueue[fuselage] = fuselageGenerationStage;
									list.Add(fuselage);
								}
							}
							else
							{
								_suspendedChangeQueue.Add(fuselage, fuselageGenerationStage);
								list.Add(fuselage);
							}
						}
					}
				}
				return result;
			}
			finally
			{
				_changesSuspended = false;
				_suspendedChangeQueue.Clear();
			}
		}

		public static void FlushChanges()
		{
			if (_changesSuspended)
			{
				try
				{
					ApplyBufferedChanges();
				}
				finally
				{
					StartChangeBuffer();
				}
			}
		}

		public static int GetInitOrder(FuselageGenerationStage stage)
		{
			return (int)(510 + stage);
		}

		public static bool StartChangeBuffer()
		{
			bool changesSuspended = _changesSuspended;
			_changesSuspended = true;
			return !changesSuspended;
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			_generationDelegates = new PreStartInitializationDelegate[9] { null, Setup, GenerateBaseMesh, FindNeighbours, ApplySmoothing, ApplyCutting, ApplyMeshModifiers, ColliderBake, FinaliseMesh };
			for (int i = 1; i < _generationDelegates.Length; i++)
			{
				plan.Register(this, _generationDelegates[i], PreStartInitializationFlags.Default, 510 + i);
			}
		}

		public bool GetAdjacentPiece(bool currentIsSlice, int currentIndex, bool forwards, out JFuselageScript nextFuselage, out bool nextIsSlice, out int nextIndex)
		{
			forwards ^= IsBackwards;
			if (currentIsSlice)
			{
				if ((currentIndex == 0 && forwards) || (currentIndex == 1 && !forwards))
				{
					nextFuselage = this;
					nextIsSlice = false;
					nextIndex = 0;
					return true;
				}
				Neighbour? neighbour = _neighbours[forwards ? 1 : 0];
				if (neighbour.HasValue)
				{
					nextFuselage = neighbour.Value.Fuselage;
					if (!Data.SyncSlice(currentIndex) || !neighbour.Value.Fuselage.Data.SyncSlice(neighbour.Value.SliceIndex))
					{
						nextIndex = neighbour.Value.SliceIndex;
						nextIsSlice = true;
						return true;
					}
					nextIndex = 0;
					nextIsSlice = false;
					return true;
				}
			}
			else if (currentIndex == 0)
			{
				nextFuselage = this;
				nextIsSlice = true;
				nextIndex = (forwards ? 1 : 0);
				return true;
			}
			nextFuselage = null;
			nextIsSlice = false;
			nextIndex = 0;
			return false;
		}

		public void GetSectionOutline(Span<float3> front, Span<float3> back, int sectionIndex, float outsetFraction = 0.05f)
		{
			if (sectionIndex != 0)
			{
				throw new IndexOutOfRangeException();
			}
			GetSliceOutline(back, 0, outsetFraction);
			GetSliceOutline(front, 1, outsetFraction);
		}

		public void GetSliceOutline(Span<float3> positions, int sliceIndex, float outsetFraction = 0.05f)
		{
			Pose sliceTransform = GetSliceTransform(sliceIndex);
			Span<float2> span = stackalloc float2[4];
			ref SectionParams sliceRefUntracked = ref Data.GetSliceRefUntracked(sliceIndex);
			bool flag = sliceRefUntracked.Size.x <= float.Epsilon;
			bool flag2 = sliceRefUntracked.Size.y <= float.Epsilon;
			if (flag || flag2)
			{
				float2 x = math.max(sliceRefUntracked.HalfSize, outsetFraction * 0.5f * Data.Offset.z);
				x = math.max(x, 0.01f);
				span[0] = x;
				span[1] = x * math.float2(1f, -1f);
				span[2] = x * math.float2(-1f, -1f);
				span[3] = x * math.float2(-1f, 1f);
			}
			else
			{
				sliceRefUntracked.GetOutline(span);
				float trapezium = sliceRefUntracked.Trapezium;
				bool flag3 = trapezium <= -1f;
				bool flag4 = trapezium >= 1f;
				if (outsetFraction > 0f)
				{
					int length = 4;
					if (flag3)
					{
						length = 3;
					}
					else if (flag4)
					{
						length = 3;
						span[2] = span[3];
					}
					float amount = math.csum(sliceRefUntracked.Size) * 0.5f * outsetFraction;
					Span<float2> span2 = span;
					SkeletalInsetter.OutsetPoints(span2.Slice(0, length), amount);
					if (flag3)
					{
						span[3] = span[0];
					}
					else if (flag4)
					{
						span[3] = span[2];
						span[2] = span[1];
					}
				}
			}
			for (int i = 0; i < 4; i++)
			{
				float2 float5 = span[i];
				positions[i] = sliceTransform.TransformPoint(new Vector3(float5.x, float5.y, 0f));
			}
		}

		public Pose GetSliceTransform(int slice)
		{
			return base.transform.GetWorldPose().TransformPose(new Pose(((slice == 0) ? (-0.5f) : 0.5f) * Data.Offset, Quaternion.identity));
		}

		public void Init(JFuselageData data, PartData.PartCreationInfo partCreationInfo)
		{
			Data = data;
			data.OnShapeDataChanged += OnShapeDataChanged;
			data.OnSmoothingDataChanged += OnSmoothingChanged;
			data.OnCuttingDataChanged += OnCuttingDataChanged;
			base.PartScript.PartConnectionChanged += OnPartConnectionChanged;
		}

		public override void OnConnectedToPart(AttachPointData thisAttachPoint, PartData targetPart, AttachPointData targetAttachPoint, bool isSymmetryOperation)
		{
			if (!Data.AutoResizeOnConnected)
			{
				return;
			}
			int? sliceIndex = Data.GetSliceIndex(thisAttachPoint);
			if (!sliceIndex.HasValue)
			{
				return;
			}
			int valueOrDefault = sliceIndex.GetValueOrDefault();
			if (!targetPart.TryGetModifier<JFuselageData>(out var result))
			{
				return;
			}
			sliceIndex = result.GetSliceIndex(targetAttachPoint);
			if (!sliceIndex.HasValue)
			{
				return;
			}
			int valueOrDefault2 = sliceIndex.GetValueOrDefault();
			bool flag = Data.SliceIsFront(valueOrDefault);
			bool flag2 = result.SliceIsFront(valueOrDefault2);
			SectionParams sliceRefUntracked = result.GetSliceRefUntracked(valueOrDefault2);
			ref SectionParams sliceRefUntracked2 = ref result.GetSliceRefUntracked(result.GetEndSlice(!flag2));
			ref SectionParams sliceRefUntracked3 = ref Data.GetSliceRefUntracked(valueOrDefault);
			ref SectionParams sliceRefUntracked4 = ref Data.GetSliceRefUntracked(Data.GetEndSlice(!flag));
			float3 float5 = result.Offset;
			if (flag == flag2)
			{
				float5.y = 0f - float5.y;
				sliceRefUntracked.Mirror();
			}
			if (math.any(sliceRefUntracked.Size <= 0f))
			{
				return;
			}
			float2 float6 = sliceRefUntracked.Size - sliceRefUntracked2.Size;
			float2 float7 = sliceRefUntracked.Size + float6;
			if (math.cmin(float7) < 0f)
			{
				float2 float8 = sliceRefUntracked.Size / float6;
				float8 = math.select(float.PositiveInfinity, float8, float8 > 0f);
				float num = math.cmin(float8);
				float7 = sliceRefUntracked.Size;
				if (num > 0.05f && num < 1f)
				{
					float7 = sliceRefUntracked.Size + float6 * num;
					float5 *= num;
					if (num == float8.x)
					{
						float7.x = 0f;
					}
					if (num == float8.y)
					{
						float7.y = 0f;
					}
				}
			}
			sliceRefUntracked3 = (sliceRefUntracked4 = sliceRefUntracked);
			sliceRefUntracked4.Size = float7;
			JFuselageData.CuttingParams cutting = result.GetCutting(valueOrDefault2);
			Data.SetCutting(0, cutting);
			Data.SetCutting(1, cutting);
			Data.Offset = float5;
			Data.AlignToSlice(valueOrDefault, result, valueOrDefault2);
			Data.AutoResizeOnConnected = false;
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			Vector3 offset = Data.Offset;
			offset.x = 0f - offset.x;
			Data.Offset = offset;
			for (int i = 0; i < Data.NumSections; i++)
			{
				SectionParams value = Data[i];
				value.Mirror();
				Data[i] = value;
				JFuselageData.CuttingParams cutting = Data.GetCutting(i);
				ref decimal? y = ref cutting.y;
				ref decimal? w = ref cutting.w;
				decimal? w2 = cutting.w;
				decimal? y2 = cutting.y;
				y = w2;
				w = y2;
				Data.SetCutting(i, cutting);
			}
		}

		public void RaiseMeshModifierChanged()
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				Regenerate(FuselageGenerationStage.MeshModifiers);
			}
		}

		public Manifold<Vertex> RequireThinManifold()
		{
			float thickness = 0.05f;
			using (Profile.RequireThinManifold.Auto())
			{
				if (_thinManifold != null)
				{
					return _thinManifold;
				}
				NativeMesh mesh = default(NativeMesh);
				PrepareMeshBuilder(ref mesh, Allocator.TempJob);
				using (NativeArray<float3> attachPointPositions = new NativeArray<float3>(6, Allocator.TempJob))
				{
					using NativeArray<float4> minSlicing = new NativeArray<float4>(2, Allocator.TempJob);
					bool isCone = Data.IsCone;
					int length = (isCone ? 3 : 2);
					using NativeArray<float4> cuttingPlanesForMass = new NativeArray<float4>(0, Allocator.TempJob);
					using NativeArray<float4> areaVolumeOut = new NativeArray<float4>(2, Allocator.TempJob);
					using NativeArray<SectionParams> nativeArray = new NativeArray<SectionParams>(length, Allocator.TempJob);
					using NativeArray<float3> nativeArray2 = new NativeArray<float3>(length, Allocator.TempJob);
					using NativeReference<MinMaxAABB> boundsOut = new NativeReference<MinMaxAABB>(Allocator.TempJob);
					NativeArray<SectionParams> sections = nativeArray;
					NativeArray<float3> sectionPositions = nativeArray2;
					int minInterpSlices = 0;
					bool noseconeSharp = false;
					sections[0] = SetThickness(Data.SectionA);
					sections[1] = SetThickness(Data.SectionB);
					sectionPositions[0] = Data.Offset * -0.5f;
					sectionPositions[1] = Data.Offset * 0.5f;
					new FuselageJob
					{
						Mesh = mesh,
						Style = ((!isCone) ? FuselageStyle.Hollow : FuselageStyle.HollowCone),
						ColliderType = FuselageColliderType.TriangleMesh,
						NumColliders = 0,
						ColliderCornerSamples = Data.ColliderCornerSamples,
						ColliderOutput = _baseColliderData.Output,
						ColliderTriangles = _baseColliderData.Triangles,
						ColliderVertices = _baseColliderData.Verts,
						CuttingPlanesForMass = cuttingPlanesForMass,
						AreaVolumeOut = areaVolumeOut,
						BoundsOut = boundsOut,
						Sections = sections,
						SectionPositions = sectionPositions,
						MaxEdgeRotationPerSlice = math.radians(10f),
						MinInterpSlices = minInterpSlices,
						NoseconeSharp = noseconeSharp,
						AttachPointPositions = attachPointPositions,
						MinSlicing = minSlicing
					}.Run();
				}
				using (mesh)
				{
					Error status;
					Manifold<Vertex> manifold = mesh.ToManifold(Allocator.Persistent, out status);
					if (manifold != null)
					{
						_thinManifold = manifold;
						return manifold;
					}
					_thinManifold = null;
					Debug.LogError($"Thin manifold mesh build failed on part {base.PartScript.Part.Id}: {status}");
					return null;
				}
			}
			SectionParams SetThickness(SectionParams section)
			{
				section.Thickness = thickness;
				return section;
			}
		}

		public void UpdateFuel()
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				FuelTankScript modifier = base.PartScript.GetModifier<FuelTankScript>();
				if (modifier != null)
				{
					float num = Data.FuelCapacity * Data.FuelProportion;
					modifier.FuelTank.Capacity = num;
					modifier.FuelTank.Fuel = num;
					Designer.Instance.SetAircraftStructureChanged();
				}
			}
		}

		protected void OnDestroy()
		{
			_destroyed = true;
			_renderer?.Dispose();
			CleanupMeshModifierStage();
			CleanupCuttingStage();
			CleanupSmoothingStage();
			CleanupBaseMeshStage();
			if (_meshModifierCheckMesh != null)
			{
				UnityEngine.Object.Destroy(_meshModifierCheckMesh);
				_meshModifierCheckMesh = null;
			}
			foreach (Mesh colliderMesh in _colliderMeshes)
			{
				if (colliderMesh != null)
				{
					UnityEngine.Object.Destroy(colliderMesh);
				}
			}
			_colliderMeshes.Clear();
			_suspendedChangeQueue.Remove(this);
			base.PartScript.PartConnectionChanged -= OnPartConnectionChanged;
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				Data.OnGlassStateChanged -= OnGlassStateChangedDesigner;
				Data.OnFuelProportionChanged -= OnFuelProportionChangedDesigner;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			base.RegisterUpdateMethods(in registrar);
			registrar.RegisterLateUpdate(OnLateUpdateDesigner, CraftUpdateFlags.DesignerDefault);
		}

		private static void AllocateOrClear<T>(ref NativeList<T> list, int defaultCapacity, Allocator allocator) where T : unmanaged
		{
			if (list.IsCreated)
			{
				list.Clear();
			}
			else
			{
				list = new NativeList<T>(defaultCapacity, allocator);
			}
		}

		private static void PrepareColliderBuilder(ref ColliderBuilder data, Allocator allocator)
		{
			AllocateOrClear(ref data.Output, 16, allocator);
			AllocateOrClear(ref data.Verts, 128, allocator);
			AllocateOrClear(ref data.Triangles, 64, allocator);
		}

		private static void PrepareMeshBuilder(ref NativeMesh mesh, Allocator allocator)
		{
			AllocateOrClear(ref mesh.Vertices, 128, allocator);
			AllocateOrClear(ref mesh.Triangles, 64, allocator);
			AllocateOrClear(ref mesh.Runs, 128, allocator);
		}

		private static FuselageGenerationStage Previous(FuselageGenerationStage stage)
		{
			return stage - 1;
		}

		private static bool SetManifold(Manifold<Vertex> newManifold, ref Manifold<Vertex> storage)
		{
			if (newManifold == null || newManifold == storage)
			{
				return false;
			}
			Error status = newManifold.Status;
			if (status != Error.NO_ERROR)
			{
				Debug.LogError($"Failed to apply manifold change: status {status}");
				newManifold.Dispose();
				return false;
			}
			storage?.Dispose();
			storage = newManifold;
			return true;
		}

		private void CheckStage(FuselageGenerationStage stage)
		{
			if (_lastCompletedStage < stage - 1)
			{
				throw new Exception($"Tried to generate stage {stage} when the previous stage was not completed (current stage = {_lastCompletedStage})");
			}
		}

		private UniTask ColliderBake(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			using (Profile.ColliderBake.Auto())
			{
				CheckStage(FuselageGenerationStage.ColliderBake);
				StartColliderBake();
				_lastCompletedStage = FuselageGenerationStage.ColliderBake;
				return UniTask.CompletedTask;
			}
		}

		private void ExecuteSync(PreStartInitializationDelegate del)
		{
			if (!_destroyed && del(base.PartScript.Aircraft, base.LoadContext, async: false).Status == UniTaskStatus.Pending)
			{
				Debug.LogWarning($"Synchronous generation delegate {del.Method.Name} on fuselage {base.PartScript.Part.Id} did not complete immediately", this);
			}
		}

		private async UniTask FinaliseMesh(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			CheckStage(FuselageGenerationStage.Finalise);
			StartColliderBake();
			Manifold<Vertex> latestMeshAsManifold = GetLatestMeshAsManifold(FuselageGenerationStage.Finalise, create: false);
			if (latestMeshAsManifold != null)
			{
				_renderer.UpdateMesh(latestMeshAsManifold);
			}
			else
			{
				_renderer.UpdateMesh(GetLatestMesh(FuselageGenerationStage.Finalise));
			}
			int[] submeshToLevel;
			if (_colliderType == FuselageColliderType.TriangleMesh && _bakingColliders.HasValue)
			{
				Mesh mesh = _bakingColliders.Value.TargetMeshes[0];
				Manifold<Vertex> manifold = _postModifiersColliderManifold;
				if (manifold != null || (manifold = GetLatestMeshAsManifold(FuselageGenerationStage.Finalise, create: false)) != null)
				{
					using NativeMesh mesh2 = new NativeMesh((int)manifold.NumVert, (int)manifold.NumTri, Allocator.TempJob);
					ManifoldUtils.ConvertManifoldToNativeMesh(manifold, mesh2, ulong.MaxValue);
					mesh2.WriteToSimpleMeshData(mesh, out submeshToLevel, makeSubmeshes: false);
				}
				else
				{
					GetLatestMesh(FuselageGenerationStage.Finalise).WriteToSimpleMeshData(mesh, out submeshToLevel, makeSubmeshes: false);
				}
			}
			MeshCollider mainCollider = null;
			if (_colliderBake.HasValue)
			{
				if (!_colliderBake.Value.IsCompleted && async)
				{
					await _colliderBake.Value.ToUniTask(PlayerLoopTiming.Update);
				}
				else
				{
					_colliderBake.Value.Complete();
				}
				_colliderBake = null;
			}
			if (_bakingColliders.HasValue)
			{
				ColliderBuildData value = _bakingColliders.Value;
				mainCollider = ((value.Colliders.Length == 0) ? null : value.Colliders[0]);
				for (int i = 0; i < value.Colliders.Length; i++)
				{
					value.Colliders[i].sharedMesh = value.TargetMeshes[i];
				}
			}
			_bakingColliders = null;
			if (loadContext == CraftLoadContext.Designer)
			{
				if (_meshModifierCheckMesh == null)
				{
					GameObject obj = new GameObject("MeshModifierArea", typeof(MeshCollider));
					obj.transform.parent = base.transform;
					obj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
					obj.layer = 25;
					MeshCollider component = obj.GetComponent<MeshCollider>();
					component.convex = false;
					_meshModifierCheckCollider = component;
					_meshModifierCheckMesh = new Mesh
					{
						name = $"MMA-{base.PartScript.Part.Id}"
					};
				}
				Manifold<Vertex> latestMeshAsManifold2 = GetLatestMeshAsManifold(FuselageGenerationStage.MeshModifiers, create: false);
				if (latestMeshAsManifold2 != null)
				{
					using NativeMesh mesh3 = new NativeMesh((int)latestMeshAsManifold2.NumVert, (int)latestMeshAsManifold2.NumTri, Allocator.TempJob);
					ManifoldUtils.ConvertManifoldToNativeMesh(latestMeshAsManifold2, mesh3, ulong.MaxValue);
					mesh3.WriteToSimpleMeshData(_meshModifierCheckMesh, out submeshToLevel, makeSubmeshes: false);
				}
				else
				{
					GetLatestMesh(FuselageGenerationStage.MeshModifiers).WriteToSimpleMeshData(_meshModifierCheckMesh, out submeshToLevel, makeSubmeshes: false);
				}
				Physics.BakeMesh(_meshModifierCheckMesh.GetInstanceID(), convex: false);
				_meshModifierCheckCollider.sharedMesh = _meshModifierCheckMesh;
			}
			UpdateAttachPoints();
			if (loadContext == CraftLoadContext.Flight && mainCollider != null)
			{
				SetupBuoyancy(mainCollider);
			}
		}

		private void GetCuttingPlanes(NativeList<float4> planes)
		{
			JFuselageData.CuttingParams cutting = Data.GetCutting(0);
			JFuselageData.CuttingParams cutting2 = Data.GetCutting(1);
			ref SectionParams sliceRefUntracked = ref Data.GetSliceRefUntracked(0);
			ref SectionParams sliceRefUntracked2 = ref Data.GetSliceRefUntracked(1);
			float3 float5 = Data.Offset * 0.5f;
			float2 float6 = new float2(0f, 1f);
			for (int i = 0; i < 4; i++)
			{
				float3 x = math.float3(float6.y, 0f - float6.x, 0f);
				if (cutting[i].HasValue || cutting2[i].HasValue)
				{
					decimal? num = cutting[i];
					decimal? num2 = cutting2[i];
					float num3 = 0.5f - (num.HasValue ? ((float)num.Value) : _minSlicing[0][i]);
					float num4 = 0.5f - (num2.HasValue ? ((float)num2.Value) : _minSlicing[1][i]);
					float3 float7 = math.float3(float6 * sliceRefUntracked.Size * num3, 0f) - float5;
					float3 float8 = math.float3(float6 * sliceRefUntracked2.Size * num4, 0f) + float5;
					float3 float9 = math.cross(x, float8 - float7);
					float w = math.dot(float9, float7);
					planes.Add(math.float4(float9, w));
				}
				float6 = x.xy;
			}
		}

		private float GetFuelVolume(float4 volumeMoment)
		{
			if (!base.PartScript.HasModifier<FuelTankScript>())
			{
				return 0f;
			}
			return volumeMoment.w * 0.8f * 1000f;
		}

		private float3[] GetLatestAttachPoints(FuselageGenerationStage stage)
		{
			FuselageGenerationStage fuselageGenerationStage = Previous(stage);
			switch (fuselageGenerationStage)
			{
			case FuselageGenerationStage.None:
			case FuselageGenerationStage.Setup:
				return null;
			case FuselageGenerationStage.BaseMesh:
				return _baseAttachPointPositions;
			case FuselageGenerationStage.Cutting:
				if (_postCuttingAttachPoints != null && _postCuttingManifoldColliders.Count > 0)
				{
					return _postCuttingAttachPoints;
				}
				goto case FuselageGenerationStage.BaseMesh;
			default:
				if (fuselageGenerationStage <= FuselageGenerationStage.Cutting)
				{
					if (fuselageGenerationStage < FuselageGenerationStage.BaseMesh)
					{
						return null;
					}
					return GetLatestAttachPoints(fuselageGenerationStage);
				}
				goto case FuselageGenerationStage.Cutting;
			}
		}

		private NativeMesh GetLatestMesh(FuselageGenerationStage stage)
		{
			FuselageGenerationStage fuselageGenerationStage = stage - 1;
			switch (fuselageGenerationStage)
			{
			case FuselageGenerationStage.BaseMesh:
				return _baseMesh;
			case FuselageGenerationStage.Smoothing:
				if (_postSmoothingMeshValid)
				{
					return _postSmoothingMesh;
				}
				goto case FuselageGenerationStage.BaseMesh;
			case FuselageGenerationStage.Cutting:
				if (_postCuttingManifold != null)
				{
					throw new InvalidOperationException("Cannot get latest mesh as NativeMesh as it is a manifold");
				}
				goto case FuselageGenerationStage.Smoothing;
			case FuselageGenerationStage.MeshModifiers:
				if (_postModifiersManifold != null)
				{
					throw new InvalidOperationException("Cannot get latest mesh as NativeMesh as it is a manifold");
				}
				goto case FuselageGenerationStage.Cutting;
			default:
				if (fuselageGenerationStage < FuselageGenerationStage.BaseMesh)
				{
					return default(NativeMesh);
				}
				return GetLatestMesh(fuselageGenerationStage);
			}
		}

		private Manifold<Vertex> GetLatestMeshAsManifold(FuselageGenerationStage stage, bool create = true)
		{
			using (Profile.GetLatestMeshAsManifold.Auto())
			{
				FuselageGenerationStage fuselageGenerationStage = stage - 1;
				switch (fuselageGenerationStage)
				{
				case FuselageGenerationStage.Setup:
					return null;
				case FuselageGenerationStage.BaseMesh:
					return _baseManifold ?? (_baseManifold = MakeManifold(in _baseMesh));
				case FuselageGenerationStage.Smoothing:
					if (_postSmoothingMeshValid)
					{
						return _postSmoothingManifold ?? (_postSmoothingManifold = MakeManifold(in _postSmoothingMesh));
					}
					goto case FuselageGenerationStage.BaseMesh;
				case FuselageGenerationStage.Cutting:
					if (_postCuttingManifold != null)
					{
						return _postCuttingManifold;
					}
					goto case FuselageGenerationStage.Smoothing;
				case FuselageGenerationStage.MeshModifiers:
					if (_postModifiersManifold != null)
					{
						return _postModifiersManifold;
					}
					goto case FuselageGenerationStage.Cutting;
				default:
					if (fuselageGenerationStage < FuselageGenerationStage.Setup)
					{
						return null;
					}
					return GetLatestMeshAsManifold(fuselageGenerationStage, create);
				}
			}
			Manifold<Vertex> MakeManifold(in NativeMesh from)
			{
				if (!create)
				{
					return null;
				}
				Error status;
				Manifold<Vertex> manifold = from.ToManifold(Allocator.Persistent, out status);
				if (manifold != null)
				{
					return manifold;
				}
				Debug.LogError($"Manifold mesh build failed on part {base.PartScript.Part.Id}: {status}");
				return null;
			}
		}

		private float4 GetMaterialIds()
		{
			List<int> materialIds = base.PartScript.Part.MaterialIds;
			float4 result = default(float4);
			for (int i = 0; i < materialIds.Count && i < 4; i++)
			{
				result[i] = materialIds[i];
			}
			return result;
		}

		private bool HasSmoothingAtFace(int i, out bool thisSmooth, out bool otherSmooth)
		{
			Neighbour? neighbour = _neighbours[i];
			if (!neighbour.HasValue)
			{
				thisSmooth = false;
				otherSmooth = false;
				return false;
			}
			JFuselageScript fuselage = neighbour.Value.Fuselage;
			int sliceIndex = neighbour.Value.SliceIndex;
			thisSmooth = Data.GetSmoothing(i);
			otherSmooth = fuselage.Data.GetSmoothing(sliceIndex);
			if ((thisSmooth | otherSmooth) && fuselage._neighbours != null && sliceIndex < fuselage._neighbours.Length)
			{
				Neighbour? neighbour2 = fuselage._neighbours[sliceIndex];
				Neighbour neighbour3 = new Neighbour
				{
					Fuselage = this,
					SliceIndex = i
				};
				if (!neighbour2.HasValue)
				{
					return false;
				}
				if (!neighbour2.HasValue)
				{
					return true;
				}
				return neighbour2.GetValueOrDefault() == neighbour3;
			}
			return false;
		}

		private void OnCuttingDataChanged(int obj)
		{
			Regenerate(FuselageGenerationStage.BaseMesh);
		}

		private void OnFuelProportionChangedDesigner(float obj)
		{
			UpdateFuel();
		}

		private void OnGlassStateChangedDesigner(bool isGlass)
		{
			if (_renderer != null)
			{
				_renderer.EnableTransparency = isGlass;
			}
			Designer.Instance.SetAircraftStructureChanged();
		}

		private void OnLateUpdateDesigner(in CraftUpdateFrameData frameData)
		{
			if (MeshModifiers.Count > 0)
			{
				Pose worldPose = base.transform.GetWorldPose();
				if (_prevPose.HasValue && _prevPose.Value != worldPose)
				{
					RaiseMeshModifierChanged();
				}
				_prevPose = worldPose;
			}
			else
			{
				_prevPose = null;
			}
		}

		private void OnPartConnectionChanged(object sender, PartConnectionChangedEventArgs e)
		{
			Regenerate(FuselageGenerationStage.FindNeighbours);
		}

		private void OnShapeDataChanged()
		{
			Regenerate(FuselageGenerationStage.BaseMesh);
			TransparencyScript modifier = base.PartScript.GetModifier<TransparencyScript>();
			if (modifier != null)
			{
				modifier.IsHollow = Data.IsHollow;
			}
		}

		private void OnSmoothingChanged(int slice)
		{
			Regenerate(FuselageGenerationStage.Smoothing);
			JFuselageScript jFuselageScript = _neighbours[slice]?.Fuselage;
			if (jFuselageScript != null)
			{
				jFuselageScript.Regenerate(FuselageGenerationStage.Smoothing);
			}
		}

		private void Regenerate(FuselageGenerationStage level)
		{
			if (_changesSuspended)
			{
				if (!_suspendedChangeQueue.TryGetValue(this, out var value) || level < value)
				{
					_suspendedChangeQueue[this] = level;
				}
			}
			else
			{
				if (_generationDelegates == null || _destroyed)
				{
					return;
				}
				_lastCompletedStage = level;
				AircraftScript aircraft = base.PartScript.Aircraft;
				CraftLoadContext loadContext = base.LoadContext;
				for (int i = (int)level; i < _generationDelegates.Length; i++)
				{
					if (_generationDelegates[i](aircraft, loadContext, async: false).Status == UniTaskStatus.Pending)
					{
						Debug.LogWarning($"Synchronous generation delegate {_generationDelegates[i].Method.Name} on fuselage {base.PartScript.Part.Id} did not complete immediately", this);
					}
				}
			}
		}

		private UniTask Setup(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			using (Profile.Setup.Auto())
			{
				if (_renderer == null)
				{
					_renderer = new ProceduralPartMeshRenderer(base.PartScript, $"Fuselage-{base.PartScript.Part.Id}", loadContext, loadContext == CraftLoadContext.Designer || Data.IsTransparent);
				}
				_renderer.EnableTransparency = Data.IsTransparent;
				if (loadContext == CraftLoadContext.Designer)
				{
					Data.OnGlassStateChanged += OnGlassStateChangedDesigner;
					Data.OnFuelProportionChanged += OnFuelProportionChangedDesigner;
				}
				_lastCompletedStage = FuselageGenerationStage.Setup;
				return UniTask.CompletedTask;
			}
		}

		private void SetupBuoyancy(MeshCollider collider)
		{
			if (Data.Buoyancy > 0f && Data.BuoyancyPermitted)
			{
				BuoyancyForce buoyancyForce = collider.gameObject.AddComponent<BuoyancyForce>();
				buoyancyForce.Quality = BuoyancyQuality.Low;
				buoyancyForce.WeightFactor = 20f * Data.Buoyancy;
				buoyancyForce.UseWeighting = true;
				buoyancyForce.ReduceBuoyancyIfBySelf = false;
				buoyancyForce.ImpactVelocityAdjustment = FloatingPartData.GetImpactVelocityAdjustmentCurve("Standard");
			}
		}

		private void UpdateAttachPoints()
		{
			int a = Data.Style switch
			{
				FuselageStyle.Cone => 1, 
				FuselageStyle.HollowCone => 1, 
				_ => 6, 
			};
			float3[] latestAttachPoints = GetLatestAttachPoints(FuselageGenerationStage.Finalise);
			if (latestAttachPoints == null)
			{
				return;
			}
			a = Mathf.Min(a, latestAttachPoints.Length);
			for (int i = 0; i < a; i++)
			{
				AttachPointData attachPoint = base.PartScript.Part.GetAttachPoint(i);
				attachPoint.Position = latestAttachPoints[i];
				if (base.LoadContext == CraftLoadContext.Designer)
				{
					attachPoint.AttachPointScript.transform.localPosition = latestAttachPoints[i];
				}
			}
		}
	}
}
