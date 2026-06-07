using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Wings
{
	public class ColliderGenerator
	{
		[BurstCompile]
		private struct AddPointsJob : IJob
		{
			[NativeDisableUnsafePtrRestriction]
			public unsafe ConvexBuilder* builder;

			public NativeArray<float3> points;

			public float xPos;

			public float margin;

			public float3 slicePos;

			public float3x3 sliceTransform;

			public NativeList<float3> builderPoints;

			public NativeList<EmittedCollider> colliders;

			public unsafe void Execute()
			{
				builder->AddCrossSection(points, xPos, colliders, builderPoints, margin, slicePos, sliceTransform);
			}
		}

		private struct ConvexBuilder
		{
			private struct BakeMeshesJob : IJobFor
			{
				public NativeArray<int> colliderIds;

				public void Execute(int i)
				{
					UnityEngine.Physics.BakeMesh(colliderIds[i], convex: true);
				}
			}

			[BurstCompile]
			private struct TransformJob : IJob
			{
				[ReadOnly]
				public RigidTransform Transform;

				[ReadOnly]
				public float yScale;

				public NativeArray<float3> points;

				public void Execute()
				{
					for (int i = 0; i < points.Length; i++)
					{
						float3 value = math.transform(Transform, points[i]);
						value.y *= yScale;
						points[i] = value;
					}
				}
			}

			[BurstCompile]
			private struct VerticesToMeshesJob : IJobFor
			{
				public NativeArray<EmittedCollider> colliders;

				[ReadOnly]
				[NativeDisableParallelForRestriction]
				public NativeArray<VertexAttributeDescriptor> descriptors;

				public Mesh.MeshDataArray meshes;

				[ReadOnly]
				[NativeDisableParallelForRestriction]
				public NativeArray<float3> points;

				public void Execute(int i)
				{
					EmittedCollider emittedCollider = colliders[i];
					Mesh.MeshData meshData = meshes[i];
					int num = emittedCollider.vertexEndIndex - emittedCollider.vertexStartIndex;
					meshData.SetVertexBufferParams(num, descriptors);
					meshData.GetVertexData<float3>().CopyFrom(points.GetSubArray(emittedCollider.vertexStartIndex, num));
				}
			}

			private EmittedCollider _current;

			private int _lastCrossSectionStartIndex;

			private Slice _prevBounds1;

			private Slice _prevBounds2;

			private float3 _prevSpanVec;

			private bool _inBentSection;

			private int _sectionCount;

			public void AddCrossSection(NativeArray<float3> newSection, float xPos, NativeList<EmittedCollider> colliders, NativeList<float3> points, float meshSplitMargin, float3 slicePosition, float3x3 sliceTransform)
			{
				Slice slice = new Slice(xPos);
				float3 tipSlicePos = _current.tipSlicePos;
				float y = _current.spanPositionRange.y;
				for (int i = 0; i < newSection.Length; i++)
				{
					slice.Encapsulate(math.float2(math.dot(newSection[i], sliceTransform.c0), math.dot(newSection[i], sliceTransform.c1)));
				}
				bool flag = points.Length != 0 && math.any(_prevSpanVec != sliceTransform.c2);
				_prevSpanVec = sliceTransform.c2;
				if (flag || _inBentSection)
				{
					if (flag != _inBentSection && _sectionCount > 1)
					{
						EndEmittedCollider(points.Length, y, tipSlicePos, colliders);
						StartEmittedCollider(_lastCrossSectionStartIndex, y, tipSlicePos);
						_sectionCount = 1;
						_prevBounds2 = _prevBounds1;
						_prevBounds1 = slice;
					}
					_inBentSection = flag;
				}
				else if (_sectionCount == 0)
				{
					_prevBounds1 = slice;
				}
				else if (_sectionCount == 1)
				{
					if (xPos == _prevBounds1.xPos)
					{
						_sectionCount = 0;
						_prevBounds1 = slice;
						StartEmittedCollider(points.Length, xPos, slicePosition);
					}
					else
					{
						_prevBounds2 = _prevBounds1;
						_prevBounds1 = slice;
					}
				}
				else if (xPos == _prevBounds1.xPos)
				{
					EndEmittedCollider(points.Length, xPos, slicePosition, colliders);
					StartEmittedCollider(points.Length, xPos, slicePosition);
					_prevBounds1 = slice;
					_sectionCount = 0;
				}
				else
				{
					if (!flag && !Slice.Lerp(_prevBounds2, _prevBounds1, math.unlerp(_prevBounds2.xPos, _prevBounds1.xPos, xPos)).Contains(slice, meshSplitMargin))
					{
						EndEmittedCollider(points.Length, y, tipSlicePos, colliders);
						StartEmittedCollider(_lastCrossSectionStartIndex, y, tipSlicePos);
						_sectionCount = 1;
					}
					_prevBounds2 = _prevBounds1;
					_prevBounds1 = slice;
				}
				_lastCrossSectionStartIndex = points.Length;
				points.AddRange(newSection);
				_sectionCount++;
				_current.tipSlicePos = slicePosition;
				_current.spanPositionRange.y = xPos;
			}

			[BurstDiscard]
			public JobHandle BuildColliders(List<ColliderInfo> outColliders, GameObject rootObj, NativeList<EmittedCollider> colliderList, NativeList<float3> points, out NativeArray<int> bakeIds, RigidTransform transform, bool flipY, NativeArray<VertexAttributeDescriptor> descriptors)
			{
				if (_sectionCount > 1)
				{
					_current.vertexEndIndex = points.Length;
					colliderList.Add(in _current);
				}
				new TransformJob
				{
					points = points.AsArray(),
					Transform = transform,
					yScale = (flipY ? (-1f) : 1f)
				}.Run();
				NativeArray<EmittedCollider> colliders = colliderList.AsArray();
				Mesh[] array = new Mesh[colliders.Length];
				for (int i = 0; i < colliders.Length; i++)
				{
					string name = $"WingMesh Collider {i}";
					EmittedCollider emittedCollider = colliders[i];
					ColliderInfo colliderInfo = new ColliderInfo
					{
						RootSlicePos = emittedCollider.rootSlicePos,
						TipSlicePos = emittedCollider.tipSlicePos,
						SpanPositionRange = emittedCollider.spanPositionRange
					};
					if (flipY)
					{
						colliderInfo.RootSlicePos.y = 0f - colliderInfo.RootSlicePos.y;
						colliderInfo.TipSlicePos.y = 0f - colliderInfo.TipSlicePos.y;
					}
					Mesh mesh;
					if (i < outColliders.Count)
					{
						colliderInfo.Collider = outColliders[i].Collider;
						colliderInfo.Collider.gameObject.name = name;
						mesh = colliderInfo.Collider.sharedMesh;
						outColliders[i] = colliderInfo;
					}
					else
					{
						GameObject gameObject = new GameObject(name);
						gameObject.transform.parent = rootObj.transform;
						colliderInfo.Collider = gameObject.AddComponent<MeshCollider>();
						mesh = new Mesh();
						colliderInfo.Collider.sharedMesh = mesh;
						outColliders.Add(colliderInfo);
					}
					mesh.name = name;
					Transform transform2 = colliderInfo.Collider.transform;
					transform2.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
					transform2.localScale = Vector3.one;
					array[i] = mesh;
				}
				while (outColliders.Count > colliders.Length)
				{
					Object.Destroy(outColliders[outColliders.Count - 1].Collider.gameObject);
					outColliders.RemoveAt(outColliders.Count - 1);
				}
				Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(array.Length);
				IJobForExtensions.Run(new VerticesToMeshesJob
				{
					points = points.AsArray(),
					colliders = colliders,
					meshes = meshDataArray,
					descriptors = descriptors
				}, array.Length);
				Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, array);
				bakeIds = new NativeArray<int>(array.Length, Allocator.TempJob);
				for (int j = 0; j < bakeIds.Length; j++)
				{
					bakeIds[j] = array[j].GetInstanceID();
				}
				return IJobForExtensions.ScheduleParallel(new BakeMeshesJob
				{
					colliderIds = bakeIds
				}, bakeIds.Length, 1, default(JobHandle));
			}

			private void StartEmittedCollider(int pointLen, float xPos, float3 slicePosition)
			{
				_current = new EmittedCollider
				{
					vertexStartIndex = pointLen,
					rootSlicePos = slicePosition,
					spanPositionRange = 
					{
						x = xPos
					}
				};
			}

			private void EndEmittedCollider(int pointLen, float xPos, float3 slicePosition, NativeList<EmittedCollider> colliders)
			{
				_current.vertexEndIndex = pointLen;
				_current.tipSlicePos = slicePosition;
				_current.spanPositionRange.y = xPos;
				colliders.Add(in _current);
			}
		}

		private struct EmittedCollider
		{
			public int vertexStartIndex;

			public int vertexEndIndex;

			public float3 rootSlicePos;

			public float3 tipSlicePos;

			public float2 spanPositionRange;
		}

		private struct Slice
		{
			public float2 max;

			public float2 min;

			public float xPos;

			public Slice(float xPos)
			{
				this.xPos = xPos;
				min = float.PositiveInfinity;
				max = float.NegativeInfinity;
			}

			public static Slice Lerp(Slice a, Slice b, float t)
			{
				return new Slice
				{
					min = math.lerp(a.min, b.min, t),
					max = math.lerp(a.max, b.max, t),
					xPos = math.lerp(a.xPos, b.xPos, t)
				};
			}

			public readonly bool Contains(Slice other)
			{
				if (math.all(min <= other.min))
				{
					return math.all(max >= other.max);
				}
				return false;
			}

			public readonly bool Contains(Slice other, float margin)
			{
				float2 float5 = (max - min) * margin;
				if (math.all(min - float5 <= other.min))
				{
					return math.all(max + float5 >= other.max);
				}
				return false;
			}

			public void Encapsulate(float2 point)
			{
				min = math.min(min, point);
				max = math.max(max, point);
			}

			public void Encapsulate(Slice bounds)
			{
				min = math.min(min, bounds.min);
				max = math.max(max, bounds.max);
			}
		}

		private ConvexBuilder _builder;

		private List<ColliderInfo> _colliderInfo;

		private GameObject _rootObj;

		private NativeList<float3> _builderPoints;

		private NativeList<EmittedCollider> _colliders;

		private NativeArray<VertexAttributeDescriptor> _descriptors;

		private NativeArray<int> _bakingIds;

		private JobHandle _bakingJob;

		private float _meshSplitMargin;

		public List<ColliderInfo> Colliders => _colliderInfo;

		public float MeshSplitMargin
		{
			get
			{
				return _meshSplitMargin;
			}
			set
			{
				_meshSplitMargin = value;
			}
		}

		public ColliderGenerator(GameObject gameObject, float meshSplitMargin = 0.05f)
		{
			_rootObj = gameObject;
			_colliderInfo = new List<ColliderInfo>();
			for (int i = 0; i < gameObject.transform.childCount; i++)
			{
				if (gameObject.transform.GetChild(i).TryGetComponent<MeshCollider>(out var component))
				{
					_colliderInfo.Add(new ColliderInfo
					{
						Collider = component
					});
					component.enabled = false;
				}
			}
			_builder = default(ConvexBuilder);
			_builderPoints = new NativeList<float3>(Allocator.TempJob);
			_colliders = new NativeList<EmittedCollider>(Allocator.TempJob);
			_descriptors = new NativeArray<VertexAttributeDescriptor>(1, Allocator.TempJob) { [0] = new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0) };
			_meshSplitMargin = meshSplitMargin;
		}

		public unsafe void AddPoints(NativeArray<float3> points, WingSlice slice)
		{
			fixed (ConvexBuilder* builder = &_builder)
			{
				new AddPointsJob
				{
					points = points,
					xPos = slice.SpanPosition,
					builder = builder,
					builderPoints = _builderPoints,
					colliders = _colliders,
					margin = _meshSplitMargin,
					slicePos = slice.Position,
					sliceTransform = math.float3x3(math.forward(), slice.Up, slice.SpanVec)
				}.Run();
			}
		}

		public void Build(RigidTransform transform, bool flipY)
		{
			StartBuild(transform, flipY);
			CompleteBuild();
		}

		public void StartBuild(RigidTransform transform, bool flipY)
		{
			_bakingJob = _builder.BuildColliders(_colliderInfo, _rootObj, _colliders, _builderPoints, out _bakingIds, transform, flipY, _descriptors);
			JobHandle.ScheduleBatchedJobs();
		}

		public void CompleteBuild()
		{
			_bakingJob.Complete();
			int length = _colliders.Length;
			_bakingIds.Dispose();
			_builderPoints.Dispose();
			_colliders.Dispose();
			_descriptors.Dispose();
			for (int i = 0; i < length; i++)
			{
				_colliderInfo[i].Collider.convex = true;
				_colliderInfo[i].Collider.enabled = true;
			}
		}
	}
}
