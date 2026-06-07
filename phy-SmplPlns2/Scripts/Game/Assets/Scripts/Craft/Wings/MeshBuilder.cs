using System.IO;
using System.Runtime.CompilerServices;
using Assets.Scripts.Craft.MeshGen;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings
{
	public class MeshBuilder
	{
		[BurstCompile]
		private struct CalculateBoundsJob : IJob
		{
			public NativeReference<Bounds> boundsOut;

			[ReadOnly]
			public NativeArray<Vertex> vertices;

			void IJob.Execute()
			{
				if (vertices.Length != 0)
				{
					float3 float5 = vertices[0].position;
					float3 float6 = float5;
					for (int i = 0; i < vertices.Length; i++)
					{
						float3 position = vertices[i].position;
						float5 = math.min(float5, position);
						float6 = math.max(float6, position);
					}
					boundsOut.Value = new Bounds((float5 + float6) * 0.5f, float6 - float5);
				}
			}
		}

		[BurstCompile]
		private struct FlipTrianglesJob : IJobFor
		{
			public NativeArray<int3> triangles;

			public void Execute(int i)
			{
				int3 value = triangles[i];
				ref int x = ref value.x;
				ref int y = ref value.y;
				int y2 = value.y;
				int x2 = value.x;
				x = y2;
				y = x2;
				triangles[i] = value;
			}
		}

		[BurstCompile]
		private struct TransformJob : IJobFor
		{
			[ReadOnly]
			public float4x4 transform;

			public NativeArray<Vertex> vertices;

			public void Execute(int index)
			{
				Vertex value = vertices[index];
				value.position = math.transform(transform, value.position);
				value.normal = math.mul((float3x3)transform, value.normal);
				vertices[index] = value;
			}
		}

		private Allocator _allocator;

		private RigidTransform _inverseTransform = RigidTransform.identity;

		private ProceduralPartMeshRenderer _partRenderer;

		private RigidTransform _transform = RigidTransform.identity;

		private bool _transformRotate;

		private bool _transformValid;

		public RigidTransform InverseTransform
		{
			get
			{
				if (_transformValid)
				{
					return _inverseTransform;
				}
				UpdateTransform();
				return _inverseTransform;
			}
			set
			{
				_inverseTransform = value;
				_transform = math.inverse(value);
				_transformValid = true;
			}
		}

		public Mesh Mesh { get; set; }

		public GameObject Object { get; set; }

		public NativeList<NativeMesh.TriangleRun> Runs { get; set; }

		public RigidTransform Transform
		{
			get
			{
				if (_transformValid)
				{
					return _transform;
				}
				UpdateTransform();
				return _transform;
			}
			set
			{
				_transform = value;
				_inverseTransform = math.inverse(value);
				_transformValid = true;
			}
		}

		public NativeList<int3> Triangles { get; set; }

		public NativeList<Vertex> Vertices { get; set; }

		internal float3? PivotEnd { get; set; }

		internal float3? PivotStart { get; set; }

		public MeshBuilder(MeshFilter meshFilter, Allocator allocator = Allocator.TempJob)
		{
			Mesh = meshFilter.sharedMesh;
			Object = meshFilter.gameObject;
			_allocator = allocator;
			_partRenderer = null;
		}

		public MeshBuilder(ProceduralPartMeshRenderer partRenderer, Allocator allocator = Allocator.TempJob)
		{
			_partRenderer = partRenderer;
			Object = partRenderer.Transform.gameObject;
			Mesh = null;
			_allocator = allocator;
		}

		public static implicit operator NativeMesh(MeshBuilder from)
		{
			return new NativeMesh
			{
				Vertices = from.Vertices,
				Triangles = from.Triangles,
				Runs = from.Runs
			};
		}

		public static void ApplyMeshData(MeshBuilder[] builders, bool debugOut = false, bool flipY = false, bool calculateNormals = true, bool dispose = true, bool setTransform = true)
		{
			for (int i = 0; i < builders.Length; i++)
			{
				builders[i]?.ApplyToMesh(debugOut, flipY, calculateNormals, dispose, setTransform);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddVertex(float3 position, ushort submeshId = 0)
		{
			Vertices.Add(new Vertex(position));
		}

		public void ApplyToMesh(bool debugOut = false, bool flipY = false, bool calculateNormals = true, bool dispose = true, bool setTransform = true)
		{
			try
			{
				IJobForExtensions.Run(new TransformJob
				{
					transform = GetInverseTransformWithFlip(flipY),
					vertices = Vertices.AsArray()
				}, Vertices.Length);
				if (flipY)
				{
					IJobForExtensions.Run(new FlipTrianglesJob
					{
						triangles = Triangles.AsArray()
					}, Triangles.Length);
				}
				if (debugOut)
				{
					DebugMeshOutput();
				}
				NativeMesh nativeMesh = this;
				if (_partRenderer != null)
				{
					_partRenderer.UpdateMesh(this, calculateNormals);
					calculateNormals = false;
				}
				else
				{
					nativeMesh.WriteToSimpleMeshData(Mesh, out var _);
					if (calculateNormals)
					{
						Mesh.RecalculateNormals();
					}
				}
				if (setTransform)
				{
					RigidTransform transform = Transform;
					if (flipY)
					{
						transform = MathUtils.GetTransformInMirroredYSpace(transform);
					}
					Object.transform.SetLocalPositionAndRotation(transform.pos, transform.rot);
				}
			}
			finally
			{
				if (dispose)
				{
					DisposeArrays();
				}
			}
		}

		public void DebugMeshOutput()
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Path.Join(new DirectoryInfo(Application.dataPath).Parent.Parent.Parent.FullName, "Temp"));
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			string path = $"export-{directoryInfo.GetFiles().Length}.obj";
			using StreamWriter streamWriter = new StreamWriter(Path.Combine(directoryInfo.FullName, path));
			streamWriter.WriteLine("#debug exported wing mesh");
			foreach (Vertex vertex in Vertices)
			{
				float3 position = vertex.position;
				streamWriter.WriteLine($"v {position.x} {position.y} {position.z}");
			}
			foreach (int3 triangle in Triangles)
			{
				streamWriter.WriteLine($"f {triangle.x + 1} {triangle.y + 1} {triangle.z + 1}");
			}
			Debug.Log("Exported mesh '" + ((Mesh != null) ? Mesh.name : _partRenderer.Transform.gameObject.name) + "' to '" + Path.Combine(directoryInfo.FullName, path) + "'");
		}

		public void DisposeArrays()
		{
			NativeList<Vertex> list = Vertices;
			Extensions.DisposeIfCreated(ref list);
			Vertices = list;
			NativeList<int3> list2 = Triangles;
			Extensions.DisposeIfCreated(ref list2);
			Triangles = list2;
			NativeList<NativeMesh.TriangleRun> list3 = Runs;
			Extensions.DisposeIfCreated(ref list3);
			Runs = list3;
		}

		public float4x4 GetInverseTransformWithFlip(bool flipY)
		{
			float4x4 float4x5 = new float4x4(InverseTransform);
			if (flipY)
			{
				return math.mul(float4x4.Scale(1f, -1f, 1f), float4x5);
			}
			return float4x5;
		}

		public void Prepare()
		{
			if (Vertices.IsCreated)
			{
				Vertices.Clear();
			}
			else
			{
				Vertices = new NativeList<Vertex>(256, _allocator);
			}
			if (Runs.IsCreated)
			{
				Runs.Clear();
			}
			else
			{
				Runs = new NativeList<NativeMesh.TriangleRun>(8, _allocator);
			}
			if (Triangles.IsCreated)
			{
				Triangles.Clear();
			}
			else
			{
				Triangles = new NativeList<int3>(128, _allocator);
			}
			PivotStart = null;
			PivotEnd = null;
			_transformValid = false;
			_inverseTransform = (_transform = RigidTransform.identity);
		}

		public void SetPivot(float3 pivot, bool rotate = true)
		{
			if (!_transformValid)
			{
				if (!PivotStart.HasValue)
				{
					PivotStart = pivot;
				}
				else
				{
					PivotEnd = pivot;
				}
				_transformValid = false;
				_transformRotate = rotate;
			}
		}

		private void UpdateTransform()
		{
			if (!PivotStart.HasValue)
			{
				_transform = RigidTransform.identity;
				_inverseTransform = RigidTransform.identity;
			}
			else if (!PivotEnd.HasValue || !_transformRotate)
			{
				_transform = RigidTransform.Translate(PivotStart.Value);
				_inverseTransform = RigidTransform.Translate(-PivotStart.Value);
			}
			else
			{
				float3 float5 = PivotEnd.Value - PivotStart.Value;
				float3 float6 = math.cross(math.forward(), float5);
				if (math.lengthsq(float6) <= float.Epsilon)
				{
					float5 = math.right();
					float6 = math.up();
				}
				float3 forward = math.cross(float5, float6);
				_transform = new RigidTransform(quaternion.LookRotation(forward, float6), PivotStart.Value);
				_inverseTransform = math.inverse(_transform);
			}
			_transformValid = true;
		}
	}
}
