using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using PajamaLlama.Math;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(LineRenderer), typeof(PathfinderNavigator))]
public class Navigator : Target, INavigator, IPathfindingNodeDisposedListener, IPathfindingNodeProvider
{
	public enum TerrainType
	{
		WaterSurface = 0,
		Construction = 1,
		Vessel = 2,
		Underwater = 3,
		Sky = 4,
		OutOfBounds = 5,
		UnityNavMesh = 6
	}

	[Serializable]
	public struct TerrainMovementValues
	{
		public TerrainType Type;

		public float Speed;

		public float Penalty;
	}

	[Header("Pathfinding Properties")]
	[Tooltip(" Multiplier for the width to decide on what the optimal width is.")]
	public float PreferredWidthMultiplier = 1f;

	[Header("Navigator Properties")]
	[Tooltip(" Width of this navigator object.")]
	public float Width = 5f;

	[Range(0f, 1f)]
	[Tooltip("The speed at which the navigator should accelerate.")]
	public float AccelerationSpeed = 1f;

	[Tooltip("The distance at which the navigator should start to decelerate.")]
	public float DecelerateDistance = 1f;

	[Range(0f, 1f)]
	[Tooltip("The minimum value for the speed multiplier.")]
	public float MinimumSpeedMultiplier = 1f;

	[Tooltip("The speed at which the navigator will rotate towards the target.")]
	public float RotationSpeed = 30f;

	[Space]
	[Tooltip("Enter one element per terrain type you want to have particular values for, default values if a terrain is not listed here will be a speed of 0 and a penalty of 9999.")]
	public List<TerrainMovementValues> _terrainMovementValues = new List<TerrainMovementValues>();

	[Tooltip("The transition cost for going from the construction graph to a grid")]
	[SerializeField]
	[FormerlySerializedAs("TransitionCost")]
	private int _transitionCost;

	[Space]
	[Tooltip("Possible transitions for this navigator.")]
	[SerializeField]
	private List<NavigationTransition> _transitions = new List<NavigationTransition>();

	private Agent _agent;

	private NavigationTransition _activeTransition;

	private Vector3 _lastTargetPosition = Vector3.zero;

	private GraphBase _currentGraph;

	private PathfindingNode _currentNode;

	private PathfinderNavigator _pathfinderNavigator;

	private UnityNavMeshNavigator _unityNavMeshNavigator;

	[HideInInspector]
	public bool MovingToFreeNode;

	private bool _parentNodeDisposed;

	public static List<Navigator> Navigators = new List<Navigator>();

	public NavigatorState State { get; private set; }

	public TerrainType Terrain { get; private set; }

	public NavigatorPathBase Path { get; private set; }

	public HierarchicalNode IdleNode { get; private set; }

	public NavigatorLineRenderer LineRenderer { get; private set; }

	public byte PreferredClearance { get; private set; }

	public byte RequiredClearance { get; private set; }

	public int TransitionCost => _transitionCost;

	public ITarget Target { get; private set; }

	public PathfinderNavigator PathfinderNavigator => _pathfinderNavigator;

	public bool AllowIncompletePath { get; private set; }

	Transform IPathfindingNodeProvider.transform => base.transform;

	protected override void Awake()
	{
		base.Awake();
		if (_isVessel)
		{
			_boat = GetComponent<Boat>();
		}
		else
		{
			_agent = GetComponent<Agent>();
		}
		Navigators.AddUnique(this);
		SetupNavigationModes();
	}

	private void OnEnable()
	{
		bool flag = Terrain == TerrainType.UnityNavMesh;
		_pathfinderNavigator.enabled = !flag;
		if (_unityNavMeshNavigator != null)
		{
			_unityNavMeshNavigator.enabled = flag;
		}
	}

	private void Start()
	{
		RequiredClearance = ComputeRequiredClearance();
		PreferredClearance = (byte)Mathf.CeilToInt(Width * PreferredWidthMultiplier);
		if (_pathfinderNavigator.enabled)
		{
			UpdateGraph(GameManager.GraphManager.ReturnNode(this, this, 16, onlyUnblocked: false));
		}
		LineRenderer = new NavigatorLineRenderer(this);
	}

	private void Update()
	{
		UpdateState();
		switch (State)
		{
		case NavigatorState.Navigating:
			if (_pathfinderNavigator.enabled)
			{
				_pathfinderNavigator.FollowPath(_currentGraph, Time.deltaTime);
			}
			break;
		case NavigatorState.Transitioning:
			_activeTransition?.Progress(base.transform, RotationSpeed, Time.deltaTime);
			break;
		}
		LineRenderer.UpdateLineRenderer(Target, Path);
	}

	private void LateUpdate()
	{
		if (_parentNodeDisposed)
		{
			UpdateTerrain(TerrainType.OutOfBounds);
			_parentNodeDisposed = false;
		}
	}

	private void OnDisable()
	{
		_pathfinderNavigator.enabled = false;
		if (_unityNavMeshNavigator != null)
		{
			_unityNavMeshNavigator.enabled = false;
		}
	}

	private void OnDrawGizmos()
	{
		if (_debug && Path != null && !Target.IsNull())
		{
			if (Path.Length == 0)
			{
				DrawPathSegment(base.transform.position, Target.Position, Color.cyan);
			}
			else
			{
				Path.OnDrawGizmos(this);
			}
		}
	}

	public bool StartNavigation(ITarget target, bool allowIncompletePath = false)
	{
		Target = target.ReturnTarget();
		AllowIncompletePath = allowIncompletePath;
		if (_pathfinderNavigator.enabled)
		{
			_pathfinderNavigator.StopAllCoroutines();
			if (_activeTransition != null)
			{
				_activeTransition.FastForward(base.transform);
				UpdateState();
				_activeTransition = null;
			}
			if (ReturnPathfindingNode(null) == null)
			{
				Debug.LogException(new Exception($"StartNavigation was called for '{this}' which was out of bounds (ReturnPathfindingNode() == null)! It is being reset to the town."));
				return false;
			}
		}
		StopIdling();
		ClearPath();
		Path = (_pathfinderNavigator.enabled ? _pathfinderNavigator.GetNewPathfinderPath(Target) : _unityNavMeshNavigator.SetDestination(Target));
		UpdateState();
		return true;
	}

	public void RestartNavigation()
	{
		NavigatorState state = State;
		if ((uint)state > 1u)
		{
			if (Target.IsNull())
			{
				Debug.LogException(new Exception("Navigator cannot be restarted when it has no MoveTarget!"));
			}
			else
			{
				StartNavigation(Target, AllowIncompletePath);
			}
		}
	}

	public void StopNavigation(ProjectFlags flags)
	{
		Path?.FinishPath(flags);
		ClearPath();
		UpdateState();
		base.transform.localRotation = Quaternion.Euler(0f, base.transform.localRotation.eulerAngles.y, 0f);
		if (_unityNavMeshNavigator != null && _unityNavMeshNavigator.UnityNavMeshAgent.isOnNavMesh)
		{
			_unityNavMeshNavigator.UnityNavMeshAgent.velocity = Vector3.zero;
			_unityNavMeshNavigator.UnityNavMeshAgent.isStopped = true;
		}
	}

	public void BeginIdling(PathfindingNode node)
	{
		IdleNode = node as HierarchicalNode;
		if (IdleNode != null)
		{
			if (IdleNode.Marker == null)
			{
				IdleNode = null;
			}
			else
			{
				IdleNode.Marker.SetIdlingAgent(_agent);
			}
		}
	}

	public void StopIdling()
	{
		if (IdleNode != null)
		{
			IdleNode.Marker?.RemoveIdlingAgent(_agent);
			IdleNode = null;
		}
	}

	private void UpdateState()
	{
		if (Path == null)
		{
			SetState(NavigatorState.Idling);
		}
		else if (!Path.Processed)
		{
			SetState(NavigatorState.Calculating);
		}
		else if (Path.NoPathFound)
		{
			StopNavigation(ProjectFlags.InValid);
		}
		else if (State == NavigatorState.Transitioning)
		{
			if (Path.Length == 0)
			{
				SetState(NavigatorState.Navigating);
				_activeTransition = null;
			}
			else if (_activeTransition.IsCompleted)
			{
				UpdateGraph(_activeTransition.TargetNode);
				SetState(NavigatorState.Navigating);
				if (_pathfinderNavigator.isActiveAndEnabled)
				{
					_pathfinderNavigator.RemoveNodeFromPath(_activeTransition.TargetNode);
				}
				_activeTransition = null;
			}
		}
		else if (_activeTransition == null && TransitionNeeded(out _activeTransition))
		{
			SetState(NavigatorState.Transitioning);
		}
		else
		{
			SetState(NavigatorState.Navigating);
		}
	}

	private void SetState(NavigatorState stateToSet)
	{
		if (State != stateToSet)
		{
			State = stateToSet;
			switch (stateToSet)
			{
			case NavigatorState.Navigating:
				UpdateAgentActivity(Activity.Moving);
				break;
			case NavigatorState.Transitioning:
				UpdateAgentActivity(Activity.Transitioning);
				break;
			}
		}
	}

	public void OnParentNodeDisposed()
	{
		base.transform.SetParent(null, worldPositionStays: true);
		_parentNodeDisposed = true;
	}

	public void Reset()
	{
		PlaceAt(base.transform.position, overrideCheck: true);
	}

	private void ClearPath()
	{
		Path?.ClearNodes();
		Path = null;
	}

	public void UpdateTerrain(TerrainType terrain, bool overrideUpdate = false)
	{
		if (Terrain == terrain && !overrideUpdate)
		{
			return;
		}
		if (terrain == TerrainType.UnityNavMesh)
		{
			if (_unityNavMeshNavigator == null)
			{
				throw new NotSupportedException("Cannot set Navigator.Terrain = UnityNavMesh on Navigator that cannot use the Unity navmesh.");
			}
			ClearPath();
			_pathfinderNavigator.enabled = false;
			_unityNavMeshNavigator.enabled = true;
			_unityNavMeshNavigator.UnityNavMeshAgent.speed = ReturnSpeed(TerrainType.UnityNavMesh);
			if (_unityNavMeshNavigator.UnityNavMeshAgent.speed == 0f)
			{
				Debugger.Warning($"There is no TerrainMovementValues associated to UnityNavMesh for this agent, its speed on Unity NavMesh has been set to zero.");
			}
		}
		else
		{
			if (Terrain == TerrainType.UnityNavMesh)
			{
				ClearPath();
			}
			_pathfinderNavigator.enabled = true;
			if (_unityNavMeshNavigator != null)
			{
				_unityNavMeshNavigator.enabled = false;
			}
		}
		Terrain = terrain;
		if (_agent != null)
		{
			_agent.UpdateAgentTerrain(Terrain);
		}
	}

	private void UpdateAgentActivity(Activity activity)
	{
		Agent agent = (_isVessel ? _boat.Captain : _agent);
		if (!(agent == null) && agent.IsAlive && agent.CurrentActivity != Activity.Drowning)
		{
			agent.UpdateActivity(activity);
		}
	}

	public void UpdateGraph(PathfindingNode node, bool updateParent = true)
	{
		if (node != null)
		{
			_currentNode = node;
			_currentGraph = node.Graph;
			switch (_currentGraph.GraphType)
			{
			case Graph.Type.WaterSurface:
				UpdateTerrain(TerrainType.WaterSurface);
				break;
			case Graph.Type.Constructions:
				UpdateTerrain(TerrainType.Construction);
				break;
			default:
				Debug.LogException(new NotImplementedException());
				break;
			}
			if (updateParent)
			{
				UpdateParent();
			}
		}
	}

	public void UpdateParent()
	{
		Transform agentParent = _currentNode.GetAgentParent();
		if (base.transform.parent != agentParent)
		{
			base.transform.SetParent(agentParent);
		}
	}

	public void DrawPathSegment(Vector3 startPoint, Vector3 endPoint, Color color)
	{
		Vector3 vector = endPoint - startPoint;
		Gizmos.color = color;
		Gizmos.DrawLine(startPoint, endPoint);
		Vector3 normalized = Vector3.Cross(vector, Vector3.up).normalized;
		Gizmos.color = color * 0.75f;
		Gizmos.DrawLine(startPoint + normalized * Width * 0.5f, startPoint + normalized * Width * 0.5f + vector);
		Gizmos.DrawLine(startPoint - normalized * Width * 0.5f, startPoint - normalized * Width * 0.5f + vector);
	}

	public void SetupNavigationModes()
	{
		_pathfinderNavigator = GetComponent<PathfinderNavigator>();
		_pathfinderNavigator.Navigator = this;
		_pathfinderNavigator.Radius = Radius;
		_pathfinderNavigator.Agent = _agent;
		if (Graph.TypesMatch(TargetGraphType, Graph.Type.UnityNavMesh))
		{
			_unityNavMeshNavigator = GetComponent<UnityNavMeshNavigator>();
			_unityNavMeshNavigator.Navigator = this;
		}
	}

	public void PlaceAt(Vector3 position, bool overrideCheck = false, bool placeOnObstacle = true)
	{
		if (!placeOnObstacle || !TryGetObstacle(out var obstacle, position))
		{
			AttachToNode(GameManager.GraphManager.ReturnNode(this, this), position, overrideCheck);
			return;
		}
		if (!Graph.TypesMatch(TargetGraphType, Graph.Type.Constructions) || !Graph.TypesMatch(obstacle.TargetGraphType, Graph.Type.Constructions))
		{
			Debug.LogException(new NotImplementedException($"Needs additional code to place navigator the position of {position} that's blocked by {obstacle}"));
		}
		AttachToTarget(obstacle, overrideCheck);
	}

	public void AttachToNode(PathfindingNode node, Vector3 position = default(Vector3), bool overrideCheck = false)
	{
		if (node == null)
		{
			Debugger.Warning("No node given to attach to. Moved to out of bounds terrain.", this);
			UpdateTerrain(TerrainType.OutOfBounds);
			return;
		}
		node.UpdateRootPosition();
		if (node.Graph is Grid)
		{
			if (position == default(Vector3))
			{
				base.transform.position = node.RootPosition;
			}
			else
			{
				base.transform.position = position.SetY(node.Graph.Height);
			}
		}
		else
		{
			base.transform.position = node.RootPosition;
			BeginIdling(node);
		}
		UpdateGraph(node);
	}

	public bool AttachToTarget(Target target, bool overrideCheck = false)
	{
		if (target.PrimaryMarker == null || target.PrimaryMarker.Node == null)
		{
			Debugger.Warning("No node given to attach to.", this);
			return false;
		}
		HierarchicalNode node = (HierarchicalNode)target.PrimaryMarker.Node.ReturnNode(this, this, onlyUnblocked: true, leaf: true, 16, hasLineOfSight: false, onlyInRange: false);
		bool overrideCheck2 = overrideCheck;
		AttachToNode(node, default(Vector3), overrideCheck2);
		return true;
	}

	private bool TransitionNeeded(out NavigationTransition navigationTransition)
	{
		navigationTransition = null;
		if (Path.TryGetNextNode<PathfindingNode>(out var nextNode))
		{
			foreach (NavigationTransition transition in _transitions)
			{
				if (transition.TryGetInstance(out navigationTransition, this, nextNode))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void OnPathfindingNodeDisposed(PathfindingNode node)
	{
		if (IdleNode == node)
		{
			IdleNode = null;
		}
		Path?.Recalculate();
	}

	public bool Validate()
	{
		if (Terrain == TerrainType.UnityNavMesh)
		{
			return _unityNavMeshNavigator.UnityNavMeshAgent.isOnNavMesh;
		}
		return true;
	}

	public bool IsOnGraph(GraphBase graph)
	{
		return graph == _currentGraph;
	}

	public bool IsOnGraph(Graph.Type graphType)
	{
		if (_currentGraph != null)
		{
			return _currentGraph.TypesMatch(graphType);
		}
		return false;
	}

	public override PathfindingNode ReturnPathfindingNode(Navigator navigator = null)
	{
		if (_currentGraph == null)
		{
			return null;
		}
		UpdatePosition();
		PathfindingNode pathfindingNode = _currentGraph.ReturnNode(this, this, 16);
		if (pathfindingNode == null || pathfindingNode.IsOutOfBounds)
		{
			UpdateTerrain(TerrainType.OutOfBounds);
			UpdatePosition();
			pathfindingNode = _currentGraph.ReturnNode(this, this, 16);
		}
		return pathfindingNode;
	}

	public float ReturnSpeed()
	{
		return ReturnSpeed(Terrain);
	}

	public float ReturnSpeed(TerrainType terrain)
	{
		float num = 1f;
		float result = 0f;
		if (_agent != null && _agent.Attributes != null)
		{
			num = _agent.Attributes.ReturnAttributeModifier(DrifterAttributes.AttributeType.Athletics);
		}
		for (int i = 0; i < _terrainMovementValues.Count; i++)
		{
			if (_terrainMovementValues[i].Type == terrain)
			{
				result = _terrainMovementValues[i].Speed;
				return result * num;
			}
		}
		return result;
	}

	public float ReturnTerrainPenalty(TerrainType terrain)
	{
		foreach (TerrainMovementValues terrainMovementValue in _terrainMovementValues)
		{
			if (terrainMovementValue.Type == terrain)
			{
				return terrainMovementValue.Penalty;
			}
		}
		return 9999f;
	}

	public bool ReturnIsOutOfBounds()
	{
		if (WorldManager.IsInInteractionRadius(base.transform.position))
		{
			return false;
		}
		NavigatorState state = State;
		if (state == NavigatorState.Calculating || state == NavigatorState.Transitioning)
		{
			return false;
		}
		return Terrain switch
		{
			TerrainType.UnityNavMesh => _unityNavMeshNavigator.ReturnIsOutOfBounds(), 
			TerrainType.OutOfBounds => true, 
			_ => GameManager.GraphManager.WaterSurfaceGraph.ReturnNode(this, this, 16, onlyUnblocked: false) == null, 
		};
	}

	public bool TryReturnNavMeshOwnerComponent<T>(out T component) where T : Component
	{
		component = null;
		if (Terrain == TerrainType.UnityNavMesh && _unityNavMeshNavigator.UnityNavMeshAgent.navMeshOwner is NavMeshSurface navMeshSurface)
		{
			return navMeshSurface.TryGetComponent<T>(out component);
		}
		return false;
	}

	public byte ComputeRequiredClearance()
	{
		return (byte)Mathf.CeilToInt(Width);
	}

	public override string ToString()
	{
		if ((bool)_agent)
		{
			return _agent.Name;
		}
		if ((bool)_boat)
		{
			return _boat.Buildable.Name;
		}
		return base.ToString();
	}

	public bool IsInRange(ITarget target)
	{
		if (target != null && !(base.transform == null))
		{
			return Vector3.Distance(base.transform.position, target.Position) < Radius + target.Range;
		}
		return true;
	}

	private bool TryGetObstacle(out Obstacle obstacle, Vector3 point)
	{
		for (int i = 0; i < Obstacle.AllObstacles.Count; i++)
		{
			obstacle = Obstacle.AllObstacles[i];
			if ((bool)obstacle && Graph.TypesMatch(TargetGraphType, obstacle.ObstacleGraphType) && Vector3.Distance(point, obstacle.transform.position) < Radius + obstacle.Radius)
			{
				return true;
			}
		}
		obstacle = null;
		return false;
	}

	public static TerrainType ReturnTerrainTypeFromGraphType(Graph.Type graphType)
	{
		switch (graphType)
		{
		case Graph.Type.WaterSurface:
			return TerrainType.WaterSurface;
		case Graph.Type.Constructions:
			return TerrainType.Construction;
		case Graph.Type.UnityNavMesh:
			return TerrainType.UnityNavMesh;
		default:
			Debug.LogException(new NotImplementedException());
			return TerrainType.WaterSurface;
		}
	}
}
