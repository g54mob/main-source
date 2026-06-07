using System;
using System.Collections.Generic;
using PajamaLlama.Extensions;
using UnityEngine;

public class Target : MonoBehaviour, ITarget, IPathfindingNodeProvider, IUpdateManagerUpdateTarget
{
	[Header("Target Properties")]
	[Tooltip("Graph types that this target can occupy.")]
	[EnumFlag(0)]
	public Graph.Type TargetGraphType;

	[Tooltip("Primary marker for this target.")]
	public HierarchicalNodeMarker PrimaryMarker;

	[Tooltip("This target is a vessel (like a boat).")]
	[SerializeField]
	protected bool _isVessel;

	[Tooltip("Radius of this target.")]
	public float Radius = 1f;

	[Tooltip("Mooring point for this target")]
	[SerializeField]
	private List<LandmarkMooringPoint> _mooringPoints;

	[Header("Debug")]
	[Tooltip("Whether we want to view the debug helpers.")]
	protected bool _debug;

	protected Boat _boat;

	private List<NavigatorPathBase> _trackedPaths = new List<NavigatorPathBase>();

	private PathfindingNode _occupiedNode;

	private Construction _construction;

	private string _toString;

	private Transform _transform;

	private Target _override;

	public Graph.Type GraphType => TargetGraphType;

	public Vector3 Position { get; private set; }

	public float Range => Radius;

	public List<LandmarkMooringPoint> MooringPoints
	{
		get
		{
			return _mooringPoints;
		}
		set
		{
			_mooringPoints = value;
		}
	}

	GameObject ITarget.gameObject => base.gameObject;

	string ITarget.name => base.name;

	string ITarget.tag => base.tag;

	Transform IPathfindingNodeProvider.transform => base.transform;

	protected virtual void Awake()
	{
		_transform = base.transform;
		Position = base.transform.position;
		if (TargetGraphType == (Graph.Type)0 && !LoadingScreen.IsLoading)
		{
			Debug.LogException(new Exception("No graph type set for target '" + this.HierarchyPathToString() + "'."));
		}
		LandmarkMooringPoint[] componentsInChildren = GetComponentsInChildren<LandmarkMooringPoint>();
		foreach (LandmarkMooringPoint item in componentsInChildren)
		{
			_mooringPoints.Add(item);
		}
	}

	private void Start()
	{
		_boat = GetComponent<Boat>();
	}

	public void UpdateManager_Update(float deltaTime, int frame)
	{
		UpdatePosition();
		if (_trackedPaths.Count == 0)
		{
			_occupiedNode = null;
			GameManager.UpdateManager.UnregisterUpdateTarget(this);
			return;
		}
		PathfindingNode pathfindingNode = GameManager.GraphManager.ReturnNode(this, _trackedPaths[0].Navigator, 5);
		if (_occupiedNode != pathfindingNode)
		{
			_occupiedNode = pathfindingNode;
			for (int i = 0; i < _trackedPaths.Count; i++)
			{
				_trackedPaths[i].Recalculate();
			}
		}
	}

	protected virtual void OnDestroy()
	{
		if (_trackedPaths != null)
		{
			_trackedPaths.Clear();
		}
		GameManager.UpdateManager.UnregisterUpdateTarget(this);
	}

	private void OnDrawGizmos()
	{
		if (_debug)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(base.transform.position, Radius);
		}
	}

	public void SetConstruction(Construction construction)
	{
		_construction = construction;
		if (PrimaryMarker == null)
		{
			return;
		}
		using ListPool<HierarchicalNodeMarker>.List list = ListPool<HierarchicalNodeMarker>.Get(PrimaryMarker);
		list.AddRange(PrimaryMarker.GetComponentsInChildren<HierarchicalNodeMarker>());
		int count = list.Count;
		while (0 < count--)
		{
			list[count].Construction = construction;
		}
	}

	public void AddQueuedPath(NavigatorPathBase queuedPath)
	{
		if (!_trackedPaths.Contains(queuedPath))
		{
			_trackedPaths.Add(queuedPath);
			if (_occupiedNode == null)
			{
				_occupiedNode = GameManager.GraphManager.ReturnNode(this, _trackedPaths[0].Navigator, 5);
				GameManager.UpdateManager.RegisterUpdateTarget(this);
			}
		}
	}

	public void RemoveQueuedPath(NavigatorPathBase queuedPath)
	{
		if (_trackedPaths.Remove(queuedPath) && _trackedPaths.Count == 0)
		{
			_occupiedNode = null;
			GameManager.UpdateManager.UnregisterUpdateTarget(this);
		}
	}

	public virtual void AttachNavigator(Navigator navigator)
	{
		navigator.AttachToNode(PrimaryMarker.Node.ReturnNode(navigator, navigator, onlyUnblocked: true, leaf: true, 16, hasLineOfSight: false, onlyInRange: false), default(Vector3), overrideCheck: true);
	}

	public void SetOverride(Target overrideToSet)
	{
		_override = overrideToSet;
	}

	public Vector3 ReturnPosition()
	{
		if ((bool)_override)
		{
			return _override.ReturnPosition();
		}
		if (PrimaryMarker == null || PrimaryMarker.Node == null)
		{
			return base.transform.position;
		}
		return PrimaryMarker.Node.RootPosition;
	}

	public ITarget ReturnTarget()
	{
		if ((bool)_override)
		{
			return _override.ReturnTarget();
		}
		if ((bool)_boat && (bool)_boat.CurrentMooringPoint)
		{
			return _boat.CurrentMooringPoint.EmbarkTarget;
		}
		return this;
	}

	public virtual PathfindingNode ReturnPathfindingNode(Navigator navigator)
	{
		if ((bool)_override)
		{
			return _override.ReturnPathfindingNode(navigator);
		}
		if ((bool)_construction && _construction.TryReturnBuildablePhaseTargetNode(out var node))
		{
			return node;
		}
		return GameManager.GraphManager.ReturnNode(this, navigator);
	}

	public PathfindingNode ReturnNode(Graph.Type graphType)
	{
		if ((bool)_override)
		{
			return _override.ReturnNode(graphType);
		}
		return GameManager.GraphManager.ReturnNode(base.transform.position, graphType);
	}

	public bool TryReturnAvailableMooringPoint(Boat boat, out MooringPointBase mooringPoint)
	{
		if ((bool)_override)
		{
			return _override.TryReturnAvailableMooringPoint(_boat, out mooringPoint);
		}
		mooringPoint = null;
		if (_mooringPoints.IsNullOrEmpty())
		{
			return false;
		}
		foreach (LandmarkMooringPoint mooringPoint2 in _mooringPoints)
		{
			if (mooringPoint2.ReturnIsAvailableForMooring(boat))
			{
				mooringPoint = mooringPoint2;
				return true;
			}
		}
		return false;
	}

	public MooringPointBase ReturnReservedMooringPoint(Agent agent)
	{
		if ((bool)_override)
		{
			return _override.ReturnReservedMooringPoint(agent);
		}
		if (_mooringPoints == null || _mooringPoints.Count == 0)
		{
			return null;
		}
		for (int i = 0; i < _mooringPoints.Count; i++)
		{
			MooringPointBase mooringPointBase = _mooringPoints[i];
			if (mooringPointBase.ReturnIsReservedByAgent(agent))
			{
				return mooringPointBase;
			}
		}
		return null;
	}

	public MooringPointBase ReturnClosestMooringPoint(Agent agent)
	{
		if ((bool)_override)
		{
			return _override.ReturnClosestMooringPoint(agent);
		}
		MooringPointBase result = null;
		if (_mooringPoints == null || _mooringPoints.Count == 0)
		{
			return result;
		}
		Vector3 position = agent.transform.position;
		float num = float.MaxValue;
		for (int i = 0; i < _mooringPoints.Count; i++)
		{
			MooringPointBase mooringPointBase = _mooringPoints[i];
			float num2 = Vector3.Distance(position, mooringPointBase.MooringTarget.Position);
			if (num2 < num)
			{
				num = num2;
				result = mooringPointBase;
			}
		}
		return result;
	}

	public bool TryReturnAvailableBoat(Agent agent, out Boat boat)
	{
		if ((bool)_override)
		{
			return _override.TryReturnAvailableBoat(agent, out boat);
		}
		boat = null;
		if (_mooringPoints == null)
		{
			return false;
		}
		foreach (LandmarkMooringPoint mooringPoint in _mooringPoints)
		{
			if (mooringPoint.IsEmpty)
			{
				continue;
			}
			if (mooringPoint.IsReserved)
			{
				if (mooringPoint.ReturnIsReservedByAgent(agent))
				{
					boat = mooringPoint.MooredBoat;
					return true;
				}
			}
			else
			{
				boat = mooringPoint.MooredBoat;
			}
		}
		return boat != null;
	}

	public bool IsNull()
	{
		return !this;
	}

	public override string ToString()
	{
		if ((bool)_override)
		{
			return "[OVERRIDE] _override.ToString()";
		}
		if (_toString == null)
		{
			Buildable componentInParent4;
			if (base.gameObject.TryGetComponentInParent<Landmark>(out var componentInParent))
			{
				MooringPointBase componentInParent3;
				if (base.gameObject.TryGetComponentInParent<LandmarkInteractable>(out var componentInParent2))
				{
					_toString = $"{componentInParent}->{componentInParent2}";
				}
				else if (base.gameObject.TryGetComponentInParent<MooringPointBase>(out componentInParent3))
				{
					_toString = $"{componentInParent}->{componentInParent3}->{base.gameObject}";
				}
				else if (componentInParent.gameObject != base.gameObject)
				{
					_toString = $"{componentInParent}->{base.gameObject}";
				}
				else
				{
					_toString = componentInParent.ToString();
				}
			}
			else if (base.gameObject.TryGetComponentInParent<Buildable>(out componentInParent4))
			{
				_toString = componentInParent4.Name;
			}
			else
			{
				_toString = base.ToString();
			}
		}
		return _toString;
	}

	protected void UpdatePosition()
	{
		if ((bool)_override)
		{
			_override.UpdatePosition();
		}
		Position = _transform.position;
	}

	T ITarget.GetComponent<T>()
	{
		return GetComponent<T>();
	}

	T ITarget.GetComponentInParent<T>()
	{
		return GetComponentInParent<T>();
	}
}
