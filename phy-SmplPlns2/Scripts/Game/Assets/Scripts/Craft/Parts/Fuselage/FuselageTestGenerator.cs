using System;
using System.Diagnostics;
using Assets.Scripts.Craft.Wings;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Fuselage
{
	public class FuselageTestGenerator : MonoBehaviour
	{
		[BurstCompile]
		private struct MakeFlatShadedMesh : IJob
		{
			public NativeArray<float3> PositionIn;

			public NativeArray<int3> TrianglesIn;

			public NativeArray<float3> PositionOut;

			public NativeArray<int3> TrianglesOut;

			public void Execute()
			{
				for (int i = 0; i < TrianglesIn.Length; i++)
				{
					int3 int5 = TrianglesIn[i];
					float3 value = PositionIn[int5.x];
					float3 value2 = PositionIn[int5.y];
					float3 value3 = PositionIn[int5.z];
					PositionOut[i * 3] = value;
					PositionOut[i * 3 + 1] = value2;
					PositionOut[i * 3 + 2] = value3;
					TrianglesOut[i] = new int3(i * 3, i * 3 + 1, i * 3 + 2);
				}
			}
		}

		private MeshBuilder _builder;

		[SerializeField]
		private FuselageStyle _style;

		[SerializeField]
		private FuselageColliderType _colliderType;

		[SerializeField]
		private int _numColliders = 6;

		[SerializeField]
		[Range(3f, 10f)]
		private int _colliderCornerSamples = 3;

		[SerializeField]
		private float3 _offset;

		[SerializeField]
		private SectionParams _rear;

		[SerializeField]
		private SectionParams _front;

		[SerializeField]
		private bool _logTime = true;

		[SerializeField]
		private bool _update;

		[SerializeField]
		private bool _debugCollider;

		[SerializeField]
		private Material _debugColliderMaterial;

		public void Generate()
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			Stopwatch stopwatch2 = new Stopwatch();
			MeshFilter component = GetComponent<MeshFilter>();
			if (component.sharedMesh == null)
			{
				component.sharedMesh = new Mesh
				{
					name = "Fuselage"
				};
			}
			if (_builder == null)
			{
				_builder = new MeshBuilder(component);
			}
			using NativeList<ColliderOut> colliderOutput = new NativeList<ColliderOut>(Allocator.TempJob);
			using NativeList<float3> colliderVertices = new NativeList<float3>(Allocator.TempJob);
			using NativeList<int3> colliderTriangles = new NativeList<int3>(Allocator.TempJob);
			using (new NativeList<int2>(16, Allocator.TempJob))
			{
				using NativeArray<float3> attachPointPositions = new NativeArray<float3>(6, Allocator.TempJob);
				using NativeArray<float4> minSlicing = new NativeArray<float4>(2, Allocator.TempJob);
				using NativeArray<float4> cuttingPlanesForMass = new NativeArray<float4>(0, Allocator.TempJob);
				using NativeArray<float4> areaVolumeOut = new NativeArray<float4>(2, Allocator.TempJob);
				using NativeArray<SectionParams> nativeArray = new NativeArray<SectionParams>(2, Allocator.TempJob);
				using NativeArray<float3> nativeArray2 = new NativeArray<float3>(2, Allocator.TempJob);
				NativeArray<SectionParams> sections = nativeArray;
				NativeArray<float3> sectionPositions = nativeArray2;
				sections[0] = _rear;
				sections[1] = _front;
				sectionPositions[0] = _offset * -0.5f;
				sectionPositions[1] = _offset * 0.5f;
				try
				{
					_builder.Prepare();
					_rear.CornerRadii = math.max(0, _rear.CornerRadii);
					_front.CornerRadii = math.max(0, _front.CornerRadii);
					stopwatch2.Start();
					new FuselageJob
					{
						Mesh = _builder,
						Sections = sections,
						SectionPositions = sectionPositions,
						MaxEdgeRotationPerSlice = math.radians(10f),
						MinInterpSlices = 0,
						Style = _style,
						NumColliders = _numColliders,
						ColliderCornerSamples = _colliderCornerSamples,
						ColliderOutput = colliderOutput,
						ColliderTriangles = colliderTriangles,
						ColliderVertices = colliderVertices,
						ColliderType = _colliderType,
						AttachPointPositions = attachPointPositions,
						MinSlicing = minSlicing,
						CuttingPlanesForMass = cuttingPlanesForMass,
						AreaVolumeOut = areaVolumeOut
					}.Run();
					stopwatch2.Stop();
					_builder.ApplyToMesh(debugOut: false, flipY: false, calculateNormals: false);
				}
				catch
				{
					throw;
				}
				stopwatch.Stop();
				int num = ((_colliderType == FuselageColliderType.TriangleMesh) ? 1 : colliderOutput.Length);
				for (int i = 0; i < base.transform.childCount; i++)
				{
					GameObject gameObject = base.transform.GetChild(i).gameObject;
					if (gameObject.name.StartsWith("Collider ") && int.TryParse(gameObject.name.AsSpan("Collider ".Length), out var result) && result >= num)
					{
						if (Application.isPlaying)
						{
							UnityEngine.Object.Destroy(gameObject);
							continue;
						}
						UnityEngine.Object.DestroyImmediate(gameObject);
						i--;
					}
				}
				if (_colliderType == FuselageColliderType.SingleConvex || _colliderType == FuselageColliderType.ConvexSegments)
				{
					for (int j = 0; j < colliderOutput.Length; j++)
					{
						string n = "Collider " + j;
						Transform transform = base.transform.Find(n);
						GameObject gameObject2;
						if (transform != null)
						{
							gameObject2 = transform.gameObject;
						}
						else
						{
							gameObject2 = new GameObject(n);
							gameObject2.transform.SetParent(base.transform);
						}
						gameObject2.transform.SetLocalPositionAndRotation(default(Vector3), Quaternion.identity);
						if (!gameObject2.TryGetComponent<MeshCollider>(out var component2))
						{
							component2 = gameObject2.AddComponent<MeshCollider>();
						}
						ColliderOut colliderOut = colliderOutput[j];
						Mesh mesh = component2.sharedMesh;
						if (mesh == null)
						{
							mesh = new Mesh
							{
								name = n
							};
						}
						mesh.Clear();
						mesh.SetVertices(colliderVertices.AsArray().GetSubArray(colliderOut.BaseVertex, colliderOut.VertexCount));
						mesh.SetIndices(colliderTriangles.AsArray().GetSubArray(colliderOut.BaseTriangle, colliderOut.TriangleCount).Reinterpret<int>(12), MeshTopology.Triangles, 0);
						mesh.RecalculateBounds();
						mesh.MarkModified();
						component2.sharedMesh = mesh;
						component2.convex = _colliderType != FuselageColliderType.TriangleMesh;
						if (_debugCollider)
						{
							if (!gameObject2.TryGetComponent<MeshFilter>(out var component3))
							{
								component3 = gameObject2.AddComponent<MeshFilter>();
							}
							if (!gameObject2.TryGetComponent<MeshRenderer>(out var component4))
							{
								component4 = gameObject2.AddComponent<MeshRenderer>();
							}
							Mesh mesh2 = component3.sharedMesh;
							if (mesh2 == null || mesh2 == mesh)
							{
								mesh2 = new Mesh
								{
									name = $"collider {j} debug mesh"
								};
							}
							using (NativeArray<float3> nativeArray3 = new NativeArray<float3>(colliderOut.TriangleCount * 3, Allocator.TempJob))
							{
								using NativeArray<int3> trianglesOut = new NativeArray<int3>(colliderOut.TriangleCount, Allocator.TempJob);
								new MakeFlatShadedMesh
								{
									PositionIn = colliderVertices.AsArray().GetSubArray(colliderOut.BaseVertex, colliderOut.VertexCount),
									TrianglesIn = colliderTriangles.AsArray().GetSubArray(colliderOut.BaseTriangle, colliderOut.TriangleCount),
									PositionOut = nativeArray3,
									TrianglesOut = trianglesOut
								}.Run();
								mesh2.Clear();
								mesh2.SetVertices(nativeArray3);
								mesh2.SetIndices(trianglesOut.Reinterpret<int>(12), MeshTopology.Triangles, 0);
								mesh2.RecalculateBounds();
								mesh2.RecalculateNormals();
								mesh2.MarkModified();
								component3.sharedMesh = mesh2;
								component4.sharedMaterial = _debugColliderMaterial;
							}
							continue;
						}
						if (gameObject2.TryGetComponent<MeshRenderer>(out var component5))
						{
							if (Application.isPlaying)
							{
								UnityEngine.Object.Destroy(component5);
							}
							else
							{
								UnityEngine.Object.DestroyImmediate(component5);
							}
						}
						if (gameObject2.TryGetComponent<MeshFilter>(out var component6))
						{
							if (Application.isPlaying)
							{
								UnityEngine.Object.Destroy(component6);
							}
							else
							{
								UnityEngine.Object.DestroyImmediate(component6);
							}
						}
					}
				}
				else if (_colliderType == FuselageColliderType.TriangleMesh)
				{
					string n2 = "Collider 0";
					Transform transform2 = base.transform.Find(n2);
					GameObject gameObject3;
					if (transform2 != null)
					{
						gameObject3 = transform2.gameObject;
					}
					else
					{
						gameObject3 = new GameObject(n2);
						gameObject3.transform.SetParent(base.transform);
					}
					gameObject3.transform.SetLocalPositionAndRotation(default(Vector3), Quaternion.identity);
					if (!gameObject3.TryGetComponent<MeshCollider>(out var component7))
					{
						component7 = gameObject3.AddComponent<MeshCollider>();
					}
					component7.convex = false;
					component7.sharedMesh = UnityEngine.Object.Instantiate(_builder.Mesh);
				}
				if (_logTime)
				{
					UnityEngine.Debug.Log($"Total time: {stopwatch.Elapsed.TotalMilliseconds:0.00}ms. Inner time: {stopwatch.Elapsed.TotalMilliseconds:0.00}ms");
				}
			}
		}

		protected void Update()
		{
			if (_update)
			{
				Generate();
			}
		}
	}
}
