using PajamaLlama.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PathingDevTools : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _navigatorField;

	[SerializeField]
	private TMP_InputField _targetField;

	[SerializeField]
	private TMP_InputField _obstacleField;

	[SerializeField]
	private Toggle _drawLineOfSight;

	[SerializeField]
	private ChildBehaviourCache<PathingDevToolsNode> _nodeCache;

	private CursorManager _cursorManager;

	private Navigator _navigator;

	private Target _target;

	private Obstacle _obstacle;

	private NavigatorPathBase _path;

	private void OnEnable()
	{
		if (_cursorManager == null)
		{
			_cursorManager = GameManager.CursorManager;
		}
	}

	private void Update()
	{
		if (_cursorManager == null || _cursorManager.SelectionLink == null)
		{
			return;
		}
		Target componentInParent2;
		if (_cursorManager.SelectionLink.TryGetComponentInParent<Navigator>(out var componentInParent))
		{
			if (FlotsamInputManager.GetButtonUp(102))
			{
				SetNavigator(componentInParent);
			}
		}
		else if (_cursorManager.SelectionLink.TryGetComponentInParent<Target>(out componentInParent2) && FlotsamInputManager.GetButtonUp(102))
		{
			SetTarget(componentInParent2);
			if (componentInParent2 is Obstacle obstacle)
			{
				SetObstacle(obstacle);
			}
		}
	}

	private void LateUpdate()
	{
		if (_navigator == null || _navigator.PathfinderNavigator == null || !_navigator.PathfinderNavigator.enabled)
		{
			return;
		}
		if (_navigator.Path is PathfinderPath { WasProcessed: not false } pathfinderPath)
		{
			_nodeCache.Reset();
			foreach (PathfindingNode node in pathfinderPath.Nodes)
			{
				_nodeCache.Get(active: true).Initialize(pathfinderPath, node);
			}
			_nodeCache.Trim();
		}
		if (_drawLineOfSight.isOn)
		{
			DrawLineOfSight();
		}
	}

	private void SetNavigator(Navigator navigator)
	{
		_navigator = navigator;
		_navigatorField.text = _navigator.name;
	}

	private void SetTarget(Target target)
	{
		_target = target;
		_targetField.text = _target.name;
	}

	private void SetObstacle(Obstacle obstacle)
	{
		_obstacle = obstacle;
		_obstacleField.text = _obstacle.name;
	}

	private void DrawLineOfSight()
	{
		if (!(_navigator == null) && !(_obstacle == null) && _navigator.Path is PathfinderPath { Length: not 0 } pathfinderPath)
		{
			Vector3 position = _navigator.transform.position;
			Vector3 direction = pathfinderPath.Nodes[0].RootPosition - position;
			if (_obstacle.Polygon.ReturnIsLineIntersecting(position, direction, _navigator.Width))
			{
				_obstacle.Polygon.DrawDebugPolygon(Color.red, Vector3.zero);
			}
			else
			{
				_obstacle.Polygon.DrawDebugPolygon(Color.green, Vector3.zero);
			}
			_obstacle.Polygon.DrawDebugRectangle(Color.yellow, Vector3.zero);
		}
	}

	public void StartNavigation()
	{
		if (_navigator == null || _target == null)
		{
			Debug.LogError("Unable to start navigation!");
		}
		else
		{
			_navigator.StartNavigation(_target);
		}
	}
}
