using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

public class GeometryCullingController : MonoBehaviour
{
	public class DebugCullingRayCommands
	{
		public Vector3 start;

		public Vector3 dir;

		public Color color;

		public float duration;

		public float delay;
	}

	public class CullingTreeData
	{
		public NewRoom room;

		public Vector3 initialAccessPoint;

		public Vector3 initialAccessFoward;

		public Vector3 pathPoint;

		public float pathDistance;

		public int accessCount;

		public Vector2 angleThresholds;
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CProcessCullingTreeForRoom_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public NewRoom room;

		public GeometryCullingController _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

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

	[Header("Settings")]
	public float maxDistance;

	[Tooltip("The max FoV angle calculated from the first entrance in the room loop")]
	[Range(0f, 100f)]
	public float maxAngleAtMinDistance;

	[Range(0f, 100f)]
	public float maxAngleAtMaxDistance;

	public int maximumLoopCount;

	[Tooltip("If true, with realtime culling doors will blocks sight but the culling will have to be updated when doors open")]
	public bool doorsBlockSight;

	[Header("State")]
	[ReadOnly]
	public bool backgroundCachingEnabled;

	public HashSet<NewRoom> currentRoomsCullingTree;

	private HashSet<NewRoom> currentRoomsCullingWithImmediateStuffLoad;

	private HashSet<AirDuctGroup> currentDuctsCullingTree;

	public bool transformSyncRequired;

	[Range(0f, 2f)]
	[Header("Debugging")]
	public int debugLevel;

	public bool animateDrawDebugRays;

	[EnableIf("animateDrawDebugRays")]
	public float rayDelay;

	public float rayTime;

	public List<NewRoom> debugCurrentRoomsVisible;

	private List<DebugCullingRayCommands> debugRayCommands;

	[Tooltip("List of rooms set to be calculated using async methods")]
	[Header("Realtime Culling")]
	[InfoBox("The above is mostly deprecated, but the below relates to calculating the room culling trees while running the game using asyncronous methods", EInfoBoxType.Normal)]
	public List<NewRoom> toCalculateList;

	[ReadOnly]
	public int roomsCalculated;

	public bool asyncCullingTreeActive;

	private static GeometryCullingController _instance;

	public static GeometryCullingController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateCullingForRoom(NewRoom currentRoom, bool updateSound, bool inAirVent, AirDuctGroup currentDuct, bool immediateLoad = false)
	{
	}

	public void ExecuteCurrentCullingTree(bool immediateLoad)
	{
	}

	public void GenerateDynamicCulling(NewRoom forRoom, int displayDebugLevel = 0)
	{
	}

	private bool IsRoomRenderableFromOrigin(NewRoom startingRoom, NewRoom destinationRoom, int displayDebugLevel)
	{
		return false;
	}

	private bool IsRoomRenderableFromThisRoom(NewRoom adjacentRoom, NewRoom originRoom, NewRoom destinationRoom, NewNode.NodeAccess access, int displayDebugLevel)
	{
		return false;
	}

	private bool IsAccessValid(NewRoom currentRoom, NewRoom destinationRoom, NewNode.NodeAccess access, int displayDebugLevel)
	{
		return false;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugDynamicCulling()
	{
	}

	private void QueueDrawRay(Vector3 origin, Vector3 direction, Color colour, float duration, float delay)
	{
	}

	private void Update()
	{
	}

	public void OnStartGame()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void StartCachingProcess()
	{
	}

	private bool IsBackgroundCachingAllowed()
	{
		return false;
	}

	public bool IsAtLoadTime()
	{
		return false;
	}

	[AsyncStateMachine(typeof(_003CProcessCullingTreeForRoom_003Ed__39))]
	public void ProcessCullingTreeForRoom(NewRoom room)
	{
	}

	public Task TaskedCullTreeGeneration(NewRoom room, bool debugMode)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetVisibleRooms()
	{
	}
}
