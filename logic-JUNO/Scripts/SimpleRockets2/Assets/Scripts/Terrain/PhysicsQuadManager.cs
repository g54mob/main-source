using System;
using System.Collections.Generic;
using Assets.Scripts.Terrain.Pooling;
using ModApi.Common.Jobs;
using ModApi.Planet;
using Unity.Collections;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Terrain
{
	[Serializable]
	public class PhysicsQuadManager : IPhysicsQuadManager
	{
		private readonly struct FindQuad2DResult
		{
			public readonly Vector2d Center;

			public readonly long Id;

			public readonly double Scale;

			public FindQuad2DResult(long id, Vector2d center, double scale)
			{
				Id = id;
				Center = center;
				Scale = scale;
			}
		}

		private class PhysicsQuadData
		{
			public Vector3d Center;

			public QuadSpherePoolItem<MeshCollider> Collider;

			public CreatePhysicsQuadData CreateQuadData;

			public long Id;

			public JobHandle? JobBakePhysicsHandle;

			public ManagedActionJob? JobBuildMeshData;

			public JobHandle? JobBuildMeshDataHandle;

			public QuadSpherePoolItem<Mesh> Mesh;

			public Vector3d MeshCenter;

			public int Priority;

			public int RemainingFrameLifetime;

			public Quaterniond Rotation;

			public double Scale;

			public TrackedPhysicsQuadData TrackedQuadData;

			public PhysicsQuadData(TrackedPhysicsQuadData trackedQuad)
			{
				TrackedQuadData = trackedQuad;
			}
		}

		private class RequiredPhysicsQuad
		{
			public Vector3d Center;

			public long Id;

			public int Priority;

			public Quaterniond Rotation;

			public double Scale;
		}

		private class TrackedPhysicsQuadData
		{
			public LinkedListNode<PhysicsQuadData> NodeLoaded;

			public LinkedListNode<PhysicsQuadData> NodePending;

			public LinkedListNode<PhysicsQuadData> NodeProcessing;

			public PhysicsQuadData QuadData;

			public TrackedPhysicsQuadData()
			{
				PhysicsQuadData value = (QuadData = new PhysicsQuadData(this));
				NodeLoaded = new LinkedListNode<PhysicsQuadData>(value);
				NodeProcessing = new LinkedListNode<PhysicsQuadData>(value);
				NodePending = new LinkedListNode<PhysicsQuadData>(value);
			}

			public void Detach()
			{
				NodeLoaded.List?.Remove(NodeLoaded);
				NodeProcessing.List?.Remove(NodeProcessing);
				NodePending.List?.Remove(NodePending);
			}

			public void Initialize(RequiredPhysicsQuad quad)
			{
				PhysicsQuadData quadData = QuadData;
				quadData.Id = quad.Id;
				quadData.Center = quad.Center;
				quadData.Scale = quad.Scale;
				quadData.Rotation = quad.Rotation;
				quadData.Priority = quad.Priority;
				quadData.RemainingFrameLifetime = 10;
			}
		}

		private const int MaxLifetimeFrames = 10;

		private const int SynchronousPriority = 10;

		private static bool _isApplicationQuitting;

		private static Matrix4x4d _quadPositioningMatrix;

		private static Quaterniond _quaternionBackFace;

		private static Quaterniond _quaternionDownFace;

		private static Quaterniond _quaternionForwardFace;

		private static Quaterniond _quaternionLeftFace;

		private static Quaterniond _quaternionRightFace;

		private static Quaterniond _quaternionUpFace;

		private static Stack<RequiredPhysicsQuad> _requiredPhysicsQuadPool;

		private Stack<CreatePhysicsQuadData> _createQuadDataPool;

		private Dictionary<long, PhysicsQuadData> _quadsAll;

		private LinkedList<PhysicsQuadData> _quadsLoaded;

		private LinkedList<PhysicsQuadData> _quadsPending;

		private QuadSphereScript _quadSphere;

		private LinkedList<PhysicsQuadData> _quadsProcessing;

		private List<PhysicsQuadData> _quadsToProcess;

		private List<PhysicsQuadData> _quadsToUnload;

		private Dictionary<long, RequiredPhysicsQuad> _requiredQuads;

		private Stack<TrackedPhysicsQuadData> _trackedQuadPool;

		public bool QuadsLoaded => _quadsAll.Count > 0;

		static PhysicsQuadManager()
		{
			_quadPositioningMatrix = new Matrix4x4d();
			_quaternionBackFace = Quaterniond.Euler(-90.0, 0.0, 0.0);
			_quaternionDownFace = Quaterniond.Euler(180.0, 0.0, 0.0);
			_quaternionForwardFace = Quaterniond.Euler(-90.0, 180.0, 0.0);
			_quaternionLeftFace = Quaterniond.Euler(-90.0, 90.0, 0.0);
			_quaternionRightFace = Quaterniond.Euler(-90.0, -90.0, 0.0);
			_quaternionUpFace = Quaterniond.identity;
			CreateRequiredPhysicsQuadPool();
			Application.quitting += OnApplicationQuitting;
		}

		public PhysicsQuadManager(QuadSphereScript quadSphere)
		{
			_quadSphere = quadSphere;
			_requiredQuads = new Dictionary<long, RequiredPhysicsQuad>();
			_quadsAll = new Dictionary<long, PhysicsQuadData>();
			_quadsLoaded = new LinkedList<PhysicsQuadData>();
			_quadsPending = new LinkedList<PhysicsQuadData>();
			_quadsProcessing = new LinkedList<PhysicsQuadData>();
			_quadsToProcess = new List<PhysicsQuadData>();
			_quadsToUnload = new List<PhysicsQuadData>();
			InitializeCreateQuadDataPool();
			InitializeTrackedQuadPool();
			_quadSphere.FrameStateRecalculated += RecalculateFrameState;
		}

		public void DrawGizmos(Transform worldTransform, ITerrainGenerator terrainGenerator)
		{
			foreach (PhysicsQuadData item in _quadsLoaded)
			{
				Vector3d normalized = item.Center.normalized;
				double height = terrainGenerator.GetHeight(normalized);
				double radius = terrainGenerator.TerrainData.PlanetData.Radius;
				int num = item.Priority - 10;
				if (num <= 0)
				{
					Gizmos.color = Color.red;
				}
				else
				{
					switch (num)
					{
					case 1:
						Gizmos.color = Color.yellow;
						break;
					case 2:
						Gizmos.color = Color.blue;
						break;
					case 3:
						Gizmos.color = Color.green;
						break;
					default:
						Gizmos.color = Color.white;
						break;
					}
				}
				Gizmos.matrix = worldTransform.localToWorldMatrix;
				Gizmos.DrawWireSphere((normalized * (radius + height)).ToVector3(), (float)(item.Scale * radius));
			}
		}

		public void OnDestroy()
		{
			if (_isApplicationQuitting)
			{
				return;
			}
			_quadSphere.FrameStateRecalculated -= RecalculateFrameState;
			foreach (PhysicsQuadData item in _quadsProcessing)
			{
				if (item.JobBuildMeshDataHandle.HasValue)
				{
					item.JobBuildMeshDataHandle.Value.Complete();
					CancelJobBuildMeshData(item);
				}
				else if (item.JobBakePhysicsHandle.HasValue)
				{
					item.JobBakePhysicsHandle.Value.Complete();
					CancelJobBakePhysics(item);
				}
			}
			LinkedListNode<PhysicsQuadData> linkedListNode = _quadsLoaded.First;
			while (linkedListNode != null)
			{
				LinkedListNode<PhysicsQuadData> next = linkedListNode.Next;
				UnloadQuad(linkedListNode.Value);
				linkedListNode = next;
			}
		}

		public void RegisterPhysicsPosition(Vector3d position, int subdivisionLevel, int quadRadiusSynchronous, int quadRadiusAsynchronous)
		{
			int priority = 11 - quadRadiusSynchronous;
			int maxPriority = 10 + quadRadiusAsynchronous;
			RegisterPhysicsPosition(position, subdivisionLevel, priority, maxPriority, -1, Vector2d.zero);
		}

		public void UpdateQuads()
		{
			foreach (RequiredPhysicsQuad value3 in _requiredQuads.Values)
			{
				if (_quadsAll.TryGetValue(value3.Id, out var value))
				{
					value.RemainingFrameLifetime = 10;
					value.Priority = value3.Priority;
				}
				else
				{
					TrackedPhysicsQuadData trackedQuadDataItem = GetTrackedQuadDataItem();
					trackedQuadDataItem.Initialize(value3);
					_quadsAll.Add(value3.Id, trackedQuadDataItem.QuadData);
					_quadsPending.AddLast(trackedQuadDataItem.NodePending);
				}
				ReturnRequiredPhysicsQuadItem(value3);
			}
			_requiredQuads.Clear();
			foreach (PhysicsQuadData value4 in _quadsAll.Values)
			{
				if (--value4.RemainingFrameLifetime < 0 && value4.TrackedQuadData.NodeProcessing.List == null)
				{
					_quadsToUnload.Add(value4);
				}
			}
			LinkedListNode<PhysicsQuadData> linkedListNode = _quadsProcessing.First;
			while (linkedListNode != null)
			{
				LinkedListNode<PhysicsQuadData> next = linkedListNode.Next;
				PhysicsQuadData value2 = linkedListNode.Value;
				ref JobHandle? jobBuildMeshDataHandle = ref value2.JobBuildMeshDataHandle;
				if (jobBuildMeshDataHandle.HasValue && jobBuildMeshDataHandle.GetValueOrDefault().IsCompleted)
				{
					value2.JobBuildMeshDataHandle.Value.Complete();
					if (value2.RemainingFrameLifetime < 0)
					{
						CancelJobBuildMeshData(value2);
						_quadsToUnload.Add(value2);
					}
					else
					{
						CompleteJobBuildMeshData(linkedListNode.Value);
						ManagedActionJob jobData = CreateJobBakePhysics(linkedListNode.Value);
						value2.JobBakePhysicsHandle = jobData.Schedule();
					}
				}
				else
				{
					ref JobHandle? jobBakePhysicsHandle = ref value2.JobBakePhysicsHandle;
					if (jobBakePhysicsHandle.HasValue && jobBakePhysicsHandle.GetValueOrDefault().IsCompleted)
					{
						value2.JobBakePhysicsHandle.Value.Complete();
						_quadsProcessing.Remove(linkedListNode);
						if (value2.RemainingFrameLifetime < 0)
						{
							CancelJobBakePhysics(value2);
							_quadsToUnload.Add(value2);
						}
						else
						{
							CompleteJobBakePhysics(linkedListNode.Value);
							_quadsLoaded.AddLast(value2.TrackedQuadData.NodeLoaded);
						}
					}
				}
				linkedListNode = next;
			}
			foreach (PhysicsQuadData item in _quadsToUnload)
			{
				UnloadQuad(item);
			}
			_quadsToUnload.Clear();
			linkedListNode = _quadsPending.First;
			while (linkedListNode != null)
			{
				LinkedListNode<PhysicsQuadData> next2 = linkedListNode.Next;
				if (linkedListNode.Value.Priority <= 10)
				{
					_quadsPending.Remove(linkedListNode);
					_quadsToProcess.Add(linkedListNode.Value);
				}
				linkedListNode = next2;
			}
			linkedListNode = _quadsProcessing.First;
			while (linkedListNode != null)
			{
				LinkedListNode<PhysicsQuadData> next3 = linkedListNode.Next;
				if (linkedListNode.Value.Priority <= 10)
				{
					_quadsProcessing.Remove(linkedListNode);
					_quadsToProcess.Add(linkedListNode.Value);
				}
				linkedListNode = next3;
			}
			if (_quadsToProcess.Count > 0)
			{
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < _quadsToProcess.Count; i++)
				{
					PhysicsQuadData physicsQuadData = _quadsToProcess[i];
					if (physicsQuadData.JobBakePhysicsHandle.HasValue)
					{
						num2++;
						continue;
					}
					if (physicsQuadData.JobBuildMeshDataHandle.HasValue)
					{
						num++;
						continue;
					}
					num++;
					physicsQuadData.JobBuildMeshData = CreateJobBuildMeshData(physicsQuadData);
					physicsQuadData.JobBuildMeshDataHandle = physicsQuadData.JobBuildMeshData.Value.Schedule();
				}
				if (num > 0)
				{
					NativeArray<JobHandle> jobs = new NativeArray<JobHandle>(num, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					num = 0;
					foreach (PhysicsQuadData item2 in _quadsToProcess)
					{
						if (item2.JobBuildMeshDataHandle.HasValue)
						{
							jobs[num++] = item2.JobBuildMeshDataHandle.Value;
						}
					}
					JobHandle.CompleteAll(jobs);
					jobs.Dispose();
					foreach (PhysicsQuadData item3 in _quadsToProcess)
					{
						if (item3.JobBuildMeshDataHandle.HasValue)
						{
							CompleteJobBuildMeshData(item3);
							ManagedActionJob jobData2 = CreateJobBakePhysics(item3);
							item3.JobBakePhysicsHandle = jobData2.Schedule();
							num2++;
						}
					}
				}
				if (num2 > 0)
				{
					NativeArray<JobHandle> jobs2 = new NativeArray<JobHandle>(num2, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					num2 = 0;
					foreach (PhysicsQuadData item4 in _quadsToProcess)
					{
						if (item4.JobBakePhysicsHandle.HasValue)
						{
							jobs2[num2++] = item4.JobBakePhysicsHandle.Value;
						}
					}
					JobHandle.CompleteAll(jobs2);
					jobs2.Dispose();
					foreach (PhysicsQuadData item5 in _quadsToProcess)
					{
						if (item5.JobBakePhysicsHandle.HasValue)
						{
							CompleteJobBakePhysics(item5);
							_quadsLoaded.AddLast(item5.TrackedQuadData.NodeLoaded);
						}
					}
				}
				_quadsToProcess.Clear();
			}
			if (_quadsPending.Count <= 0)
			{
				return;
			}
			int num3 = Math.Max(2, JobsUtility.JobWorkerCount - 2);
			if (_quadsPending.Count <= num3)
			{
				linkedListNode = _quadsPending.First;
				while (linkedListNode != null)
				{
					LinkedListNode<PhysicsQuadData> next4 = linkedListNode.Next;
					_quadsPending.Remove(linkedListNode);
					_quadsToProcess.Add(linkedListNode.Value);
					linkedListNode = next4;
				}
			}
			else
			{
				int num4 = 11;
				linkedListNode = _quadsPending.First;
				while (linkedListNode != null && _quadsToProcess.Count < num3)
				{
					LinkedListNode<PhysicsQuadData> next5 = linkedListNode.Next;
					if (linkedListNode.Value.Priority <= num4)
					{
						_quadsPending.Remove(linkedListNode);
						_quadsToProcess.Add(linkedListNode.Value);
					}
					linkedListNode = next5;
					if (linkedListNode == null)
					{
						linkedListNode = _quadsPending.First;
						num4++;
						if (num4 >= 15)
						{
							num4 = int.MaxValue;
						}
					}
				}
			}
			foreach (PhysicsQuadData item6 in _quadsToProcess)
			{
				item6.JobBuildMeshData = CreateJobBuildMeshData(item6);
				item6.JobBuildMeshDataHandle = item6.JobBuildMeshData.Value.Schedule();
				_quadsProcessing.AddLast(item6.TrackedQuadData.NodeProcessing);
			}
			_quadsToProcess.Clear();
			JobHandle.ScheduleBatchedJobs();
		}

		private static void CreateRequiredPhysicsQuadPool()
		{
			int num = 30;
			_requiredPhysicsQuadPool = new Stack<RequiredPhysicsQuad>(num);
			for (int i = 0; i < num; i++)
			{
				_requiredPhysicsQuadPool.Push(new RequiredPhysicsQuad());
			}
		}

		private static RequiredPhysicsQuad GetRequiredPhysicsQuadItem(long id, Vector3d center, double scale, Quaterniond rotation, int priority)
		{
			RequiredPhysicsQuad obj = ((_requiredPhysicsQuadPool.Count > 0) ? _requiredPhysicsQuadPool.Pop() : new RequiredPhysicsQuad());
			obj.Id = id;
			obj.Center = center;
			obj.Scale = scale;
			obj.Rotation = rotation;
			obj.Priority = priority;
			return obj;
		}

		private static void OnApplicationQuitting()
		{
			_isApplicationQuitting = true;
		}

		private static void ReturnRequiredPhysicsQuadItem(RequiredPhysicsQuad item)
		{
			_requiredPhysicsQuadPool.Push(item);
		}

		private bool AddRequiredPhysicsQuad(long id, Vector3d center, double scale, Quaterniond rotation, int priority)
		{
			if (_requiredQuads.TryGetValue(id, out var value))
			{
				if (priority < value.Priority)
				{
					value.Priority = priority;
					return true;
				}
				return false;
			}
			_requiredQuads.Add(id, GetRequiredPhysicsQuadItem(id, center, scale, rotation, priority));
			return true;
		}

		private void CancelJobBakePhysics(PhysicsQuadData quad)
		{
			quad.JobBakePhysicsHandle = null;
			QuadSpherePoolManager.Instance.PhysicsMeshPool.ReturnItem(quad.Mesh);
			quad.Mesh = null;
		}

		private void CancelJobBuildMeshData(PhysicsQuadData quad)
		{
			quad.JobBuildMeshData?.Dispose();
			quad.JobBuildMeshData = null;
			quad.JobBuildMeshDataHandle = null;
			ReturnCreateQuadDataItem(quad.CreateQuadData);
			quad.CreateQuadData = null;
		}

		private void CompleteJobBakePhysics(PhysicsQuadData quad)
		{
			quad.JobBakePhysicsHandle = null;
			quad.Collider = QuadSpherePoolManager.Instance.PhysicsQuadPool.GetItem();
			MeshCollider item = quad.Collider.Item;
			quad.Collider.Item.sharedMesh = quad.Mesh.Item;
			Transform transform = item.transform;
			transform.SetParent(null, worldPositionStays: false);
			PositionPhysicsQuad(quad, transform);
			item.gameObject.SetActive(value: true);
		}

		private void CompleteJobBuildMeshData(PhysicsQuadData quad)
		{
			quad.JobBuildMeshData?.Dispose();
			quad.JobBuildMeshData = null;
			quad.JobBuildMeshDataHandle = null;
			quad.Mesh = QuadSpherePoolManager.Instance.PhysicsMeshPool.GetItem();
			MeshDataPhysics.PhysicsVertex[] vertices = quad.CreateQuadData.MeshData.Vertices;
			quad.Mesh.Item.SetVertexBufferData(vertices, 0, 0, vertices.Length, 0, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			quad.MeshCenter = quad.CreateQuadData.Center;
			ReturnCreateQuadDataItem(quad.CreateQuadData);
			quad.CreateQuadData = null;
		}

		private ManagedActionJob CreateJobBakePhysics(PhysicsQuadData quad)
		{
			int id = quad.Mesh.Item.GetInstanceID();
			return new ManagedActionJob(delegate
			{
				Physics.BakeMesh(id, convex: false);
			});
		}

		private ManagedActionJob CreateJobBuildMeshData(PhysicsQuadData quad)
		{
			CreatePhysicsQuadData createQuadData = GetCreateQuadDataItem();
			quad.CreateQuadData = createQuadData;
			Vector3d position = quad.Center;
			Quaterniond rotation = quad.Rotation;
			double scale = quad.Scale;
			return new ManagedActionJob(delegate
			{
				_quadSphere.GeneratePhysicsQuadMeshData(createQuadData, position, rotation, scale);
			});
		}

		private FindQuad2DResult FindQuad2D(long id, Vector2d targetPosition, int targetLevel)
		{
			Vector2d zero = Vector2d.zero;
			double num = 1.0;
			for (int i = 0; i != targetLevel; i++)
			{
				num *= 0.5;
				if (targetPosition.x > zero.x)
				{
					if (targetPosition.y > zero.y)
					{
						id |= 1L << i << i;
						zero.x += num;
						zero.y += num;
					}
					else
					{
						id |= 3L << i << i;
						zero.x += num;
						zero.y -= num;
					}
				}
				else if (targetPosition.y > zero.y)
				{
					id |= 0L << i << i;
					zero.x -= num;
					zero.y += num;
				}
				else
				{
					id |= 2L << i << i;
					zero.x -= num;
					zero.y -= num;
				}
			}
			return new FindQuad2DResult(id, zero, num);
		}

		private CreatePhysicsQuadData GetCreateQuadDataItem()
		{
			if (_createQuadDataPool.Count <= 0)
			{
				return new CreatePhysicsQuadData(_quadSphere.NumVerticesInPaddedQuad);
			}
			return _createQuadDataPool.Pop();
		}

		private TrackedPhysicsQuadData GetTrackedQuadDataItem()
		{
			if (_trackedQuadPool.Count <= 0)
			{
				return new TrackedPhysicsQuadData();
			}
			return _trackedQuadPool.Pop();
		}

		private void InitializeCreateQuadDataPool()
		{
			int jobWorkerMaximumCount = JobsUtility.JobWorkerMaximumCount;
			_createQuadDataPool = new Stack<CreatePhysicsQuadData>(jobWorkerMaximumCount);
			for (int i = 0; i < jobWorkerMaximumCount; i++)
			{
				_createQuadDataPool.Push(new CreatePhysicsQuadData(_quadSphere.NumVerticesInPaddedQuad));
			}
		}

		private void InitializeTrackedQuadPool()
		{
			int num = 60;
			_trackedQuadPool = new Stack<TrackedPhysicsQuadData>(num);
			for (int i = 0; i < num; i++)
			{
				_trackedQuadPool.Push(new TrackedPhysicsQuadData());
			}
		}

		private void PositionPhysicsQuad(PhysicsQuadData quad, Transform physicsTransform)
		{
			Transform transform = (Game.InFlightScene ? _quadSphere.Transform.parent : _quadSphere.Transform);
			_quadPositioningMatrix.SetTRS(_quadSphere.FramePosition, new Quaterniond(transform.localRotation), Vector3.one);
			Matrix4x4d quadPositioningMatrix = _quadPositioningMatrix;
			Vector3d meshCenter = quad.MeshCenter;
			quadPositioningMatrix.m03 = quadPositioningMatrix.m00 * meshCenter.x + quadPositioningMatrix.m01 * meshCenter.y + quadPositioningMatrix.m02 * meshCenter.z + quadPositioningMatrix.m03;
			quadPositioningMatrix.m13 = quadPositioningMatrix.m10 * meshCenter.x + quadPositioningMatrix.m11 * meshCenter.y + quadPositioningMatrix.m12 * meshCenter.z + quadPositioningMatrix.m13;
			quadPositioningMatrix.m23 = quadPositioningMatrix.m20 * meshCenter.x + quadPositioningMatrix.m21 * meshCenter.y + quadPositioningMatrix.m22 * meshCenter.z + quadPositioningMatrix.m23;
			physicsTransform.SetPositionAndRotation(new Vector3((float)quadPositioningMatrix.m03, (float)quadPositioningMatrix.m13, (float)quadPositioningMatrix.m23), transform.localRotation);
		}

		private void RecalculateFrameState(object sender, EventArgs e)
		{
			foreach (PhysicsQuadData item in _quadsLoaded)
			{
				PositionPhysicsQuad(item, item.Collider.Item.transform);
			}
		}

		private void RegisterPhysicsPosition(Vector3d targetPosition, int targetLevel, int priority, int maxPriority, int previousFace, Vector2d direction)
		{
			double num = Mathd.Abs(targetPosition.x);
			double num2 = Mathd.Abs(targetPosition.y);
			double num3 = Mathd.Abs(targetPosition.z);
			ref Quaterniond quaternionUpFace = ref _quaternionUpFace;
			int num4;
			long id;
			Vector2d targetPosition2;
			Func<Vector2d, Vector3d> func;
			Func<Vector2d, Vector3d> func2;
			if (num > num2)
			{
				if (num > num3)
				{
					Vector3d vector3d = targetPosition / num;
					if (targetPosition.x >= 0.0)
					{
						num4 = 0;
						id = 0L;
						targetPosition2 = new Vector2d(vector3d.z, vector3d.y);
						quaternionUpFace = ref _quaternionRightFace;
						func = (Vector2d v) => new Vector3d(1.0, v.y, v.x);
						func2 = delegate(Vector2d v)
						{
							double num6 = 1.0 / Math.Sqrt(1.0 + v.x * v.x + v.y * v.y);
							return new Vector3d(num6, v.y * num6, v.x * num6);
						};
						if (num4 != previousFace)
						{
							switch (previousFace)
							{
							case 2:
								direction = new Vector2d(direction.y, 0.0 - direction.x);
								break;
							case 3:
								direction = new Vector2d(0.0 - direction.y, direction.x);
								break;
							}
						}
					}
					else
					{
						num4 = 1;
						id = 2305843009213693952L;
						targetPosition2 = new Vector2d(0.0 - vector3d.z, vector3d.y);
						quaternionUpFace = ref _quaternionLeftFace;
						func = (Vector2d v) => new Vector3d(-1.0, v.y, 0.0 - v.x);
						func2 = delegate(Vector2d v)
						{
							double num6 = 1.0 / Math.Sqrt(1.0 + v.x * v.x + v.y * v.y);
							return new Vector3d(0.0 - num6, v.y * num6, (0.0 - v.x) * num6);
						};
						if (num4 != previousFace)
						{
							switch (previousFace)
							{
							case 2:
								direction = new Vector2d(0.0 - direction.y, direction.x);
								break;
							case 3:
								direction = new Vector2d(direction.y, 0.0 - direction.x);
								break;
							}
						}
					}
				}
				else
				{
					Vector3d vector3d2 = targetPosition / num3;
					if (targetPosition.z >= 0.0)
					{
						num4 = 4;
						id = long.MinValue;
						targetPosition2 = new Vector2d(0.0 - vector3d2.x, vector3d2.y);
						quaternionUpFace = ref _quaternionForwardFace;
						func = (Vector2d v) => new Vector3d(0.0 - v.x, v.y, 1.0);
						func2 = delegate(Vector2d v)
						{
							double num6 = 1.0 / Math.Sqrt(1.0 + v.x * v.x + v.y * v.y);
							return new Vector3d((0.0 - v.x) * num6, v.y * num6, num6);
						};
						if (num4 != previousFace)
						{
							switch (previousFace)
							{
							case 2:
								direction = new Vector2d(0.0 - direction.x, 0.0 - direction.y);
								break;
							case 3:
								direction = new Vector2d(0.0 - direction.x, 0.0 - direction.y);
								break;
							}
						}
					}
					else
					{
						num4 = 5;
						id = -6917529027641081856L;
						targetPosition2 = new Vector2d(vector3d2.x, vector3d2.y);
						quaternionUpFace = ref _quaternionBackFace;
						func = (Vector2d v) => new Vector3d(v.x, v.y, -1.0);
						func2 = delegate(Vector2d v)
						{
							double num6 = 1.0 / Math.Sqrt(1.0 + v.x * v.x + v.y * v.y);
							return new Vector3d(v.x * num6, v.y * num6, 0.0 - num6);
						};
					}
				}
			}
			else if (num2 > num3)
			{
				Vector3d vector3d3 = targetPosition / num2;
				if (targetPosition.y >= 0.0)
				{
					num4 = 2;
					id = 4611686018427387904L;
					targetPosition2 = new Vector2d(vector3d3.x, vector3d3.z);
					quaternionUpFace = ref _quaternionUpFace;
					func = (Vector2d v) => new Vector3d(v.x, 1.0, v.y);
					func2 = delegate(Vector2d v)
					{
						double num6 = 1.0 / Math.Sqrt(1.0 + v.x * v.x + v.y * v.y);
						return new Vector3d(v.x * num6, num6, v.y * num6);
					};
					if (num4 != previousFace)
					{
						switch (previousFace)
						{
						case 4:
							direction = new Vector2d(0.0 - direction.x, 0.0 - direction.y);
							break;
						case 0:
							direction = new Vector2d(0.0 - direction.y, direction.x);
							break;
						case 1:
							direction = new Vector2d(direction.y, 0.0 - direction.x);
							break;
						}
					}
				}
				else
				{
					num4 = 3;
					id = 6917529027641081856L;
					targetPosition2 = new Vector2d(vector3d3.x, 0.0 - vector3d3.z);
					quaternionUpFace = ref _quaternionDownFace;
					func = (Vector2d v) => new Vector3d(v.x, -1.0, 0.0 - v.y);
					func2 = delegate(Vector2d v)
					{
						double num6 = 1.0 / Math.Sqrt(1.0 + v.x * v.x + v.y * v.y);
						return new Vector3d(v.x * num6, 0.0 - num6, (0.0 - v.y) * num6);
					};
					if (num4 != previousFace)
					{
						switch (previousFace)
						{
						case 4:
							direction = new Vector2d(0.0 - direction.x, 0.0 - direction.y);
							break;
						case 0:
							direction = new Vector2d(direction.y, 0.0 - direction.x);
							break;
						case 1:
							direction = new Vector2d(0.0 - direction.y, direction.x);
							break;
						}
					}
				}
			}
			else
			{
				Vector3d vector3d4 = targetPosition / num3;
				if (targetPosition.z >= 0.0)
				{
					num4 = 4;
					id = long.MinValue;
					targetPosition2 = new Vector2d(0.0 - vector3d4.x, vector3d4.y);
					quaternionUpFace = ref _quaternionForwardFace;
					func = (Vector2d v) => new Vector3d(0.0 - v.x, v.y, 1.0);
					func2 = delegate(Vector2d v)
					{
						double num6 = 1.0 / Math.Sqrt(1.0 + v.x * v.x + v.y * v.y);
						return new Vector3d((0.0 - v.x) * num6, v.y * num6, num6);
					};
					if (num4 != previousFace)
					{
						switch (previousFace)
						{
						case 2:
							direction = new Vector2d(0.0 - direction.x, 0.0 - direction.y);
							break;
						case 3:
							direction = new Vector2d(0.0 - direction.x, 0.0 - direction.y);
							break;
						}
					}
				}
				else
				{
					num4 = 5;
					id = -6917529027641081856L;
					targetPosition2 = new Vector2d(vector3d4.x, vector3d4.y);
					quaternionUpFace = ref _quaternionBackFace;
					func = (Vector2d v) => new Vector3d(v.x, v.y, -1.0);
					func2 = delegate(Vector2d v)
					{
						double num6 = 1.0 / Math.Sqrt(1.0 + v.x * v.x + v.y * v.y);
						return new Vector3d(v.x * num6, v.y * num6, 0.0 - num6);
					};
				}
			}
			FindQuad2DResult findQuad2DResult = FindQuad2D(id, targetPosition2, targetLevel);
			if (!AddRequiredPhysicsQuad(findQuad2DResult.Id, func(findQuad2DResult.Center), findQuad2DResult.Scale, quaternionUpFace, priority) || priority >= maxPriority)
			{
				return;
			}
			Vector2d center = findQuad2DResult.Center;
			Vector2d direction2 = direction;
			int priority2 = priority + 1;
			double num5 = findQuad2DResult.Scale + findQuad2DResult.Scale;
			if (direction.x == 0.0)
			{
				if (direction.y == 0.0)
				{
					RegisterPhysicsPosition(func2(new Vector2d(center.x, center.y + num5)), targetLevel, priority2, maxPriority, num4, new Vector2d(0.0, 1.0));
					RegisterPhysicsPosition(func2(new Vector2d(center.x, center.y - num5)), targetLevel, priority2, maxPriority, num4, new Vector2d(0.0, -1.0));
					RegisterPhysicsPosition(func2(new Vector2d(center.x - num5, center.y)), targetLevel, priority2, maxPriority, num4, new Vector2d(-1.0, 0.0));
					RegisterPhysicsPosition(func2(new Vector2d(center.x + num5, center.y)), targetLevel, priority2, maxPriority, num4, new Vector2d(1.0, 0.0));
					RegisterPhysicsPosition(func2(new Vector2d(center.x - num5, center.y - num5)), targetLevel, priority2, maxPriority, num4, new Vector2d(-1.0, -1.0));
					RegisterPhysicsPosition(func2(new Vector2d(center.x + num5, center.y - num5)), targetLevel, priority2, maxPriority, num4, new Vector2d(1.0, -1.0));
					RegisterPhysicsPosition(func2(new Vector2d(center.x - num5, center.y + num5)), targetLevel, priority2, maxPriority, num4, new Vector2d(-1.0, 1.0));
					RegisterPhysicsPosition(func2(new Vector2d(center.x + num5, center.y + num5)), targetLevel, priority2, maxPriority, num4, new Vector2d(1.0, 1.0));
				}
				else
				{
					RegisterPhysicsPosition(func2(new Vector2d(center.x, center.y + direction2.y * num5)), targetLevel, priority2, maxPriority, num4, direction2);
				}
			}
			else if (direction.y == 0.0)
			{
				RegisterPhysicsPosition(func2(new Vector2d(center.x + direction2.x * num5, center.y)), targetLevel, priority2, maxPriority, num4, direction2);
			}
			else
			{
				RegisterPhysicsPosition(func2(new Vector2d(center.x + direction2.x * num5, center.y)), targetLevel, priority2, maxPriority, num4, new Vector2d(direction2.x, 0.0));
				RegisterPhysicsPosition(func2(new Vector2d(center.x, center.y + direction2.y * num5)), targetLevel, priority2, maxPriority, num4, new Vector2d(0.0, direction2.y));
				RegisterPhysicsPosition(func2(new Vector2d(center.x + direction2.x * num5, center.y + direction2.y * num5)), targetLevel, priority2, maxPriority, num4, direction2);
			}
		}

		private void ReturnCreateQuadDataItem(CreatePhysicsQuadData item)
		{
			_createQuadDataPool.Push(item);
		}

		private void ReturnTrackedQuadDataItem(TrackedPhysicsQuadData item)
		{
			_trackedQuadPool.Push(item);
		}

		private void UnloadQuad(PhysicsQuadData quad)
		{
			try
			{
				_quadsAll.Remove(quad.Id);
				quad.TrackedQuadData.Detach();
				QuadSpherePoolManager instance = QuadSpherePoolManager.Instance;
				if (instance != null)
				{
					if (quad.Mesh != null)
					{
						instance.PhysicsMeshPool.ReturnItem(quad.Mesh);
						quad.Mesh = null;
					}
					if (quad.Collider != null)
					{
						instance.PhysicsQuadPool.ReturnItem(quad.Collider);
						quad.Collider = null;
					}
				}
				ReturnTrackedQuadDataItem(quad.TrackedQuadData);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
