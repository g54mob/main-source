using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using NaughtyAttributes;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class MeshPoolingController : MonoBehaviour
{
	[Serializable]
	public class RoomMeshCache
	{
		public Mesh floorMesh;

		public Mesh wallMesh;

		public Dictionary<NewBuilding, Mesh> additionalWallMesh;

		public Mesh ceilingMesh;

		public float lastAccessed;
	}

	public class LoaderThread
	{
		public Coroutine thread;

		public NewRoom location;

		public bool isDone;
	}

	[BurstCompile]
	private struct ProcessMeshDataJob : IJobParallelFor
	{
		[Unity.Collections.ReadOnly]
		public Mesh.MeshDataArray meshData;

		public Mesh.MeshData outputMesh;

		[DeallocateOnJobCompletion]
		[Unity.Collections.ReadOnly]
		public NativeArray<int> vertexStart;

		[DeallocateOnJobCompletion]
		[Unity.Collections.ReadOnly]
		public NativeArray<int> indexStart;

		[Unity.Collections.ReadOnly]
		[DeallocateOnJobCompletion]
		public NativeArray<float4x4> xform;

		public NativeArray<float3x2> bounds;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<float3> tempVertices;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<float3> tempNormals;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<float4> tempTangents;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<float2> tempUVs;

		public void CreateInputArrays(int meshCount)
		{
		}

		public void Execute(int index)
		{
		}
	}

	[BurstCompile]
	public struct BakeJob : IJobParallelFor
	{
		private int meshId;

		public BakeJob(int mId)
		{
			meshId = 0;
		}

		public void Execute(int index)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public MeshPoolingController _003C_003E4__this;

		public LoaderThread loaderReference;

		internal void _003CThreadedMeshGeneration_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CThreadedMeshGeneration_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MeshPoolingController _003C_003E4__this;

		public LoaderThread loaderReference;

		private _003C_003Ec__DisplayClass34_0 _003C_003E8__1;

		private Thread _003Cthread_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CThreadedMeshGeneration_003Ed__34(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[NaughtyAttributes.ReadOnly]
	[Header("State")]
	public int generatedRoomMeshes;

	[Header("Settings")]
	public MeshColliderCookingOptions colliderCookingOptions;

	public bool bakeMeshesWithJobSystem;

	[Header("Background Caching")]
	[NaughtyAttributes.ReadOnly]
	public bool backgroundCachingEnabled;

	public int cacheRoomPerXFrames;

	private int frameCounter;

	[InfoBox("How many room meshes this will cache; possibly make this a game settings option?", EInfoBoxType.Normal)]
	public int maxCache;

	[NaughtyAttributes.ReadOnly]
	public int uncachedRooms;

	private List<NewRoom> toCache;

	[NonSerialized]
	public List<LoaderThread> threads;

	public Dictionary<NewRoom, RoomMeshCache> roomMeshes;

	private static MeshPoolingController _instance;

	public static MeshPoolingController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SpawnMeshesForRoom(NewRoom room)
	{
	}

	public void SpawnModularRoomElements(NewRoom room, bool prepForCombineMeshes, out List<MeshFilter> wallChildMeshes, out Dictionary<NewBuilding, List<MeshFilter>> separateWallChildMeshes, out List<MeshFilter> floorChildMeshes, out List<MeshFilter> ceilingChildMeshes)
	{
		wallChildMeshes = null;
		separateWallChildMeshes = null;
		floorChildMeshes = null;
		ceilingChildMeshes = null;
	}

	public void SpawnExtraRoomElements(NewRoom room)
	{
	}

	public void GetCombinedRoomMeshes(NewRoom room, out GameObject floor, out GameObject walls, out Dictionary<NewBuilding, GameObject> additionalWalls, out GameObject ceiling, out MeshRenderer floorRend, out MeshRenderer wallsRend, out MeshRenderer ceilingRend)
	{
		floor = null;
		walls = null;
		additionalWalls = null;
		ceiling = null;
		floorRend = null;
		wallsRend = null;
		ceilingRend = null;
	}

	public void BuildCombinedMeshesForRoom(NewRoom room, out Mesh floorMesh, out Mesh wallMesh, out Dictionary<NewBuilding, Mesh> additionalWallMeshes, out Mesh ceilingMesh, bool returnGameObjects, out GameObject floor, out GameObject walls, out Dictionary<NewBuilding, GameObject> additionalWalls, out GameObject ceiling, out MeshRenderer floorRend, out MeshRenderer wallsRend, out MeshRenderer ceilingRend)
	{
		floorMesh = null;
		wallMesh = null;
		additionalWallMeshes = null;
		ceilingMesh = null;
		floor = null;
		walls = null;
		additionalWalls = null;
		ceiling = null;
		floorRend = null;
		wallsRend = null;
		ceilingRend = null;
	}

	public Mesh CombineMeshes(ref List<MeshFilter> childMeshes, bool markNoLongerReadable = true, bool bakePhysics = true, string meshName = "CombinedMesh")
	{
		return null;
	}

	public Mesh CombineMeshesWithMeshAPI(ref List<MeshFilter> meshFilters, bool markNoLongerReadable = true, bool bakePhysics = true, string meshName = "CombinedMesh")
	{
		return null;
	}

	public static Mesh WeldVertices(Mesh aMesh)
	{
		return null;
	}

	public GameObject CreateGameObjectFromMesh(Mesh mesh, NewRoom room, string newName, ShadowCastingMode shadowMode, out MeshRenderer meshRenderer)
	{
		meshRenderer = null;
		return null;
	}

	public void ProcessWall(GameObject wallObject, NewRoom room, NewBuilding building = null)
	{
	}

	public void ProcessFloor(GameObject floorObject, NewRoom room)
	{
	}

	public void ProcessCeiling(GameObject ceilingObject, NewRoom room)
	{
	}

	private void Update()
	{
	}

	private bool IsBackgroundCachingAllowed()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CThreadedMeshGeneration_003Ed__34))]
	private IEnumerator ThreadedMeshGeneration(LoaderThread loaderReference)
	{
		return null;
	}

	public bool IsAtLoadTime()
	{
		return false;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void StartCachingProcess()
	{
	}
}
