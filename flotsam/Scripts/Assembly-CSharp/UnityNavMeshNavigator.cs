using System;
using PajamaLlama.Debugs;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnityNavMeshNavigator : MonoBehaviour
{
	private UnityNavMeshPath _path;

	private ITarget _target;

	private Vector3 _targetDestination;

	private NavMeshSurface _navMeshSurface;

	private Vector3 _lastValidNavMeshSurfacePosition;

	private bool _townheartMoved;

	public Navigator Navigator { get; set; }

	public NavMeshAgent UnityNavMeshAgent { get; private set; }

	private void Awake()
	{
		UnityNavMeshAgent = GetComponent<NavMeshAgent>();
		if ((bool)UnityNavMeshAgent)
		{
			if (UnityNavMeshAgent.stoppingDistance < UnityNavMeshAgent.radius)
			{
				Debug.LogWarning("NavMeshAgent stopping distance is smaller than its (collision avoidence) radius! This could cause problems when 2 NavMeshAgents reach the same destination around the same time!");
			}
		}
		else
		{
			Debugger.Warning("A NavMesh Agent component needs to be attached to this agent.", this);
		}
	}

	private void OnEnable()
	{
		UnityNavMeshAgent.enabled = true;
		_navMeshSurface = UnityNavMeshAgent.navMeshOwner as NavMeshSurface;
		if (!CacheNavMeshSurfacePosition())
		{
			Debug.LogErrorFormat("Navigator '{0}' was enabled while not being on a NavMesh!", base.name);
		}
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
	}

	private void Update()
	{
		if (_path == null)
		{
			return;
		}
		if (_path.State == NavigatorPathState.Navigating)
		{
			if (!_path.NoPathFound)
			{
				float num = Vector3.Distance(base.transform.position, _target.ReturnPosition());
				float num2 = UnityNavMeshAgent.stoppingDistance + _target.Range;
				if (num < num2)
				{
					Navigator.StopNavigation(ProjectFlags.Success);
				}
				else if (UnityNavMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid || UnityNavMeshAgent.remainingDistance < num2)
				{
					Navigator.StopNavigation(ProjectFlags.Exception);
				}
			}
		}
		else if (_path.State == NavigatorPathState.Processing && !UnityNavMeshAgent.pathPending)
		{
			_path.SetState(NavigatorPathState.Navigating);
			switch (UnityNavMeshAgent.path.status)
			{
			case NavMeshPathStatus.PathPartial:
				_path.IncompletePath = true;
				break;
			case NavMeshPathStatus.PathInvalid:
				_path.NoPathFound = true;
				Navigator.StopNavigation(ProjectFlags.InValid);
				return;
			}
			_path.Nodes.Clear();
			_path.Nodes.AddRange(UnityNavMeshAgent.path.corners);
			Navigator.LineRenderer.UpdateLineRenderer(_target, _path);
		}
	}

	private void LateUpdate()
	{
		if (_target == null)
		{
			return;
		}
		if (_townheartMoved)
		{
			if (UnityNavMeshAgent.isOnNavMesh)
			{
				UnityNavMeshAgent.ResetPath();
				SetDestination(_target);
				_townheartMoved = false;
			}
		}
		else if (!CacheNavMeshSurfacePosition())
		{
			Debug.LogException(new Exception($"UnityNavMeshNavigator '{Navigator}' is no longer on a NavMeshSurface!"));
		}
	}

	private void OnDisable()
	{
		if (UnityNavMeshAgent.isOnNavMesh)
		{
			UnityNavMeshAgent.isStopped = true;
		}
		UnityNavMeshAgent.enabled = false;
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
	}

	public NavigatorPathBase SetDestination(ITarget target)
	{
		UnityNavMeshAgent.isStopped = false;
		if (_path == null)
		{
			_path = new UnityNavMeshPath(this);
		}
		_path.SetTarget(target);
		_path.SetState(NavigatorPathState.Processing);
		_target = target;
		_targetDestination = _target.ReturnPosition();
		if (!UnityNavMeshAgent.SetDestination(_targetDestination))
		{
			_path.NoPathFound = true;
		}
		return _path;
	}

	private void OnTownheartMoved(GameEvent gameEvent)
	{
		UnityNavMeshAgent.Warp(_navMeshSurface.transform.TransformPoint(_lastValidNavMeshSurfacePosition));
		_townheartMoved = true;
	}

	private bool CacheNavMeshSurfacePosition()
	{
		if (UnityNavMeshAgent.isOnNavMesh && (bool)_navMeshSurface && UnityNavMeshAgent.navMeshOwner == _navMeshSurface)
		{
			_lastValidNavMeshSurfacePosition = _navMeshSurface.transform.InverseTransformPoint(base.transform.position);
			return true;
		}
		return false;
	}

	public bool ReturnIsOutOfBounds()
	{
		if (!(UnityNavMeshAgent == null) && UnityNavMeshAgent.enabled)
		{
			return !UnityNavMeshAgent.isOnNavMesh;
		}
		return true;
	}
}
