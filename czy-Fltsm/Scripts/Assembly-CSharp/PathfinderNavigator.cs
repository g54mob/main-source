using System;
using System.Collections;
using PajamaLlama.Debugs;
using PajamaLlama.Math;
using UnityEngine;

public class PathfinderNavigator : MonoBehaviour
{
	[SerializeField]
	private float _fixedDeltaTime = 1f / 30f;

	[SerializeField]
	[Tooltip("The amount of times per frame line of sight is tested against the path. Every time there is line of sight the first node in the path is removed.")]
	[Range(1f, 10f)]
	private int _lineOfSightItterations = 3;

	private Navigator.TerrainType _terrain;

	private PathfinderPath _path;

	private float _accelerationMultiplier;

	private bool _canNavigateLineOffSight;

	private Construction _startingConstruction;

	private ITarget _target;

	private Transform _transform;

	private Rect _lineOfSightBounds;

	private Vector3 _lineOfSightPadding;

	[HideInInspector]
	public Navigator Navigator { get; set; }

	[HideInInspector]
	public float Radius { get; set; }

	[HideInInspector]
	public Agent Agent { get; set; }

	private void Awake()
	{
		_transform = base.transform;
	}

	private void LateUpdate()
	{
		_lineOfSightPadding = new Vector3(Navigator.Width * 2f, 0f, Navigator.Width * 2f);
		ClearLineOfSight(_lineOfSightItterations);
	}

	private IEnumerator GetPathCoroutine()
	{
		Pathfinder.QueuePath(_path);
		while (_path != null && !_path.Processed)
		{
			yield return null;
		}
		Navigator.LineRenderer.UpdateLineRenderer(_target, _path);
	}

	public NavigatorPathBase GetNewPathfinderPath(ITarget target)
	{
		_path = new PathfinderPath(Navigator, target);
		_target = target;
		if (_path == null)
		{
			Debugger.Warning($"Queued path is null.");
		}
		StartCoroutine(GetPathCoroutine());
		return _path;
	}

	private bool HasLineOfSight(Vector3 startPosition, Vector3 endPosition)
	{
		_lineOfSightBounds.min = (Vector3.Min(startPosition, endPosition) - _lineOfSightPadding).Vector2TopDown();
		_lineOfSightBounds.max = (Vector3.Max(startPosition, endPosition) + _lineOfSightPadding).Vector2TopDown();
		Vector3 direction = endPosition - startPosition;
		for (int i = 0; i < Obstacle.LineOfSightObstables.Count; i++)
		{
			Obstacle obstacle = Obstacle.LineOfSightObstables[i];
			if (_lineOfSightBounds.Overlaps(obstacle.Polygon.Bounds) && obstacle.ReturnIsLineIntersecting(startPosition, direction, Navigator.Width))
			{
				return false;
			}
		}
		return true;
	}

	public void FollowPath(GraphBase currentGraph, float deltaTime)
	{
		if (_target.IsNull() || _path == null || currentGraph == null)
		{
			Navigator.StopNavigation(ProjectFlags.Exception);
			return;
		}
		if (_path.State == NavigatorPathState.Processed)
		{
			if (_path.NoPathFound)
			{
				Navigator.StopNavigation(ProjectFlags.Exception);
				return;
			}
			_path.SetState(NavigatorPathState.Navigating);
		}
		if (RecalculateIfNeeded() || _path.State != NavigatorPathState.Navigating)
		{
			return;
		}
		for (float num = deltaTime; num > 0f; num -= _fixedDeltaTime)
		{
			if (num <= _fixedDeltaTime)
			{
				FollowPathFixedDeltaTime(currentGraph, num);
			}
			else
			{
				FollowPathFixedDeltaTime(currentGraph, _fixedDeltaTime);
			}
		}
		Navigator.UpdateParent();
		UpdateOutline();
	}

	public void FollowPathFixedDeltaTime(GraphBase currentGraph, float deltaTime)
	{
		if (!_path.TryGetNextNode<PathfindingNode>(out var nextNode) && Navigator.IsInRange(_target))
		{
			if (!Graph.TypesMatch(_target.GraphType, currentGraph.GraphType))
			{
				Debug.LogException(new Exception($"Navigator should have reached it's destination (on graph {_target.GraphType}) but is on the wrong graph({currentGraph.GraphType})!"));
			}
			Navigator.StopNavigation(ProjectFlags.Success);
			return;
		}
		Vector3 position = _transform.position;
		_accelerationMultiplier += Navigator.AccelerationSpeed * deltaTime;
		float num = Vector3.Distance(position, _target.Position) - (Radius + _target.Range);
		if (nextNode == null && num <= Navigator.DecelerateDistance)
		{
			_accelerationMultiplier = num / Navigator.DecelerateDistance;
		}
		_accelerationMultiplier = Mathf.Clamp(_accelerationMultiplier, Navigator.MinimumSpeedMultiplier, 1f);
		Vector3 vector = ((nextNode == null) ? _target.ReturnPosition() : ReturnRootPosition(nextNode, position));
		Vector3 vector2 = (vector - position).normalized * Navigator.ReturnSpeed() * _accelerationMultiplier;
		float num2 = 1f;
		if (_terrain != Navigator.TerrainType.Vessel)
		{
			if (Vector3.Distance(position, vector2) >= 1f)
			{
				Vector3 vector3 = vector - position;
				Quaternion quaternion = ((vector3 == Vector3.zero) ? Quaternion.identity : Quaternion.LookRotation(vector3));
				_transform.rotation = Quaternion.RotateTowards(_transform.rotation, quaternion, Navigator.RotationSpeed * deltaTime);
				float num3 = Quaternion.Angle(quaternion, _transform.rotation);
				if (num3 > 10f)
				{
					num2 = (180f - num3) / 180f;
					_accelerationMultiplier *= num2;
				}
			}
		}
		else if (Vector3.Distance(position, vector) >= 1f)
		{
			_transform.LookAt(vector);
		}
		if (_terrain != Navigator.TerrainType.Construction && _terrain != Navigator.TerrainType.Vessel)
		{
			Vector3 zero = Vector3.zero;
			zero = GameManager.PhysicsManager.MovingWorldDirection * GameManager.PhysicsManager.MovingWorldForce;
			if (zero == Vector3.zero)
			{
				zero = -GameManager.PhysicsManager.MovingFlotsamDirection * GameManager.PhysicsManager.MovingFlotsamForce;
			}
			Vector3 vector4 = vector2 + zero * GameManager.Settings.GameplaySettings.WorldPhysics.NavigatorWorldSpeedMultiplier * Radius;
			_transform.Translate(vector4 * deltaTime * num2, Space.World);
		}
		else
		{
			_transform.Translate(vector2 * deltaTime, Space.World);
		}
		if (nextNode != null && ReturnDistanceToNode(position, nextNode) < Radius)
		{
			Navigator.UpdateGraph(nextNode, updateParent: false);
			RemoveNodeFromPath(nextNode);
		}
	}

	private void ClearLineOfSight(int itterations = 1)
	{
		if (Navigator.State != NavigatorState.Navigating || Navigator.IsOnGraph(Graph.Type.Constructions))
		{
			return;
		}
		for (int i = 0; i < itterations; i++)
		{
			if (1 >= _path.Length)
			{
				break;
			}
			PathfindingNode pathfindingNode = _path.Nodes[0];
			PathfindingNode pathfindingNode2 = _path.Nodes[1];
			if (pathfindingNode.IsGridNode && pathfindingNode.Graph == pathfindingNode2.Graph && HasLineOfSight(base.transform.position, pathfindingNode2.RootPosition))
			{
				RemoveNodeFromPath(pathfindingNode);
				continue;
			}
			break;
		}
	}

	private bool RecalculateIfNeeded()
	{
		if (_path.State == NavigatorPathState.Recalculate)
		{
			Debug.Log("Recalculating path. (target changed)");
			StartCoroutine(GetPathCoroutine());
			return true;
		}
		return false;
	}

	public void RemoveNodeFromPath(PathfindingNode node)
	{
		node.UnsubscribeDisposedListener(Navigator);
		_path.Nodes.Remove(node);
	}

	private void UpdateOutline()
	{
		Construction construction = null;
		if (_path.TryGetNextNode<HierarchicalNode>(out var nextNode))
		{
			if ((bool)nextNode.Marker)
			{
				if (_startingConstruction == null)
				{
					_startingConstruction = nextNode.Marker.Construction;
				}
				construction = nextNode.Marker.Construction;
			}
			else
			{
				Debug.LogException(new Exception("[LOG] Unable to update PathfinderNavigator outline, HierarchicalNode.Marker == NULL."), this);
			}
		}
		if (_startingConstruction == construction && construction != null && Navigator.IsOnGraph(Graph.Type.Constructions))
		{
			_startingConstruction.Buildable.OutlineRenderer.UpdateAgent(Agent, AddToConstructionOutline: true);
		}
		if (_startingConstruction != construction && _startingConstruction != null)
		{
			_startingConstruction.Buildable.OutlineRenderer.UpdateAgent(Agent);
			_startingConstruction = null;
		}
	}

	private float ReturnDistanceToNode(Vector3 position, PathfindingNode node)
	{
		if (node.IsGridNode)
		{
			return Vector2.Distance(position.Vector2TopDown(), node.RootPosition2D);
		}
		return Vector3.Distance(position, node.RootPosition);
	}

	private Vector3 ReturnRootPosition(PathfindingNode node, Vector3 position)
	{
		if (node.IsGridNode)
		{
			Vector3 rootPosition = node.RootPosition;
			rootPosition.y = position.y;
			return rootPosition;
		}
		return node.RootPosition;
	}
}
