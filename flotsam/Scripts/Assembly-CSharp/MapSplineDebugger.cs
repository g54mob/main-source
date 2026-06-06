using System.Collections.Generic;
using PajamaLlama.Math;
using TMPro;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class MapSplineDebugger : MonoBehaviour
{
	public enum CursorMode
	{
		Add = 1,
		Remove = 2,
		Move = 3
	}

	public struct Pathpoint
	{
		public float Curve;

		public Vector2 Waypoint;

		public Pathpoint(float curve, Vector2 waypoint)
		{
			Curve = curve;
			Waypoint = waypoint;
		}
	}

	[SerializeField]
	private MapPathCalculator _calculator;

	[Header("References")]
	[SerializeField]
	private RectTransform _pathFollower;

	[SerializeField]
	private RectTransform _town;

	[SerializeField]
	private RectTransform _viewport;

	[SerializeField]
	private DebugSplineObstacle _obstaclePrefab;

	[SerializeField]
	private UILineRenderer _mouseLine;

	[Header("Info")]
	[SerializeField]
	private TMP_InputField _obstacleAmountField;

	[SerializeField]
	private TMP_InputField _fpsField;

	private MapPath _path;

	private List<DebugSplineObstacle> _debugObstacles;

	private List<MapObstacle> _obstacles;

	private CursorMode _cursorMode = CursorMode.Add;

	private float _obstacleRadius = 75f;

	private List<Pathpoint> _pathpoints = new List<Pathpoint>();

	private float _turningRadius = 10f;

	private float _progress;

	private void Awake()
	{
		_debugObstacles = new List<DebugSplineObstacle>();
		_obstacles = new List<MapObstacle>();
		_path = new MapPath(_calculator, _obstacles, _town);
	}

	private void Update()
	{
		Vector3 vector = _viewport.InverseTransformPoint(FlotsamInputManager.MousePosition);
		switch (_cursorMode)
		{
		case CursorMode.Add:
			Update_Add(vector);
			break;
		case CursorMode.Remove:
			Update_Remove(vector);
			break;
		case CursorMode.Move:
			Update_Move(vector);
			break;
		}
		_fpsField.text = (1f / Time.deltaTime).ToString("F0");
	}

	private void Update_Add(Vector2 mousePosition)
	{
		if (Input.GetMouseButtonDown(1))
		{
			AddObstacle(mousePosition);
		}
	}

	private void Update_Remove(Vector2 mousePosition)
	{
		if (Input.GetMouseButtonDown(1))
		{
			RemoveObstaclesNearPosition(mousePosition);
		}
	}

	private void Update_Move(Vector2 mousePosition)
	{
		_path.CalculatePath(mousePosition.Vector3TopDown());
		Vector2[] array = new Vector2[_path.Points.Count];
		for (int i = 0; i < _path.Points.Count; i++)
		{
			array[i] = _path.Points[i].Position;
		}
		_mouseLine.Points = array;
		_pathFollower.anchoredPosition = _path.ReturnLerpedPosition(_progress);
		_progress += Time.deltaTime;
		_progress %= 1f;
	}

	public void AddObstacle(Vector2 position)
	{
		MapObstacle mapObstacle = new MapObstacle(position, _obstacleRadius);
		DebugSplineObstacle debugSplineObstacle = Object.Instantiate(_obstaclePrefab, _viewport);
		debugSplineObstacle.Initialize(mapObstacle);
		_debugObstacles.Add(debugSplineObstacle);
		_obstacles.Add(mapObstacle);
		_obstacleAmountField.text = _obstacles.Count.ToString();
	}

	public void RemoveObstaclesNearPosition(Vector2 position)
	{
		int count = _debugObstacles.Count;
		if (count == 0)
		{
			return;
		}
		for (int num = count - 1; num >= 0; num--)
		{
			DebugSplineObstacle debugSplineObstacle = _debugObstacles[num];
			if (debugSplineObstacle.Obstacle.HasPointInRadius(position))
			{
				_obstacles.Remove(debugSplineObstacle.Obstacle);
				Object.Destroy(debugSplineObstacle.gameObject);
				_debugObstacles.RemoveAt(num);
			}
		}
		_obstacleAmountField.text = _debugObstacles.Count.ToString();
	}

	public void Reset()
	{
		_town.localPosition = Vector2.zero;
		for (int i = 0; i < _debugObstacles.Count; i++)
		{
			Object.Destroy(_debugObstacles[i].gameObject);
		}
		_debugObstacles.Clear();
		_obstacles.Clear();
	}

	public void Recenter()
	{
		_viewport.anchoredPosition = Vector2.zero;
	}

	public void SetObstacleRadius(float radius)
	{
		_obstacleRadius = radius;
	}

	public void SetObstacleOpacity(float opacity)
	{
		Color red = Color.red;
		red.a = opacity;
		for (int i = 0; i < _debugObstacles.Count; i++)
		{
			_debugObstacles[i].SetColor(red);
		}
	}

	public void SetTurnRadius(float radius)
	{
		_turningRadius = radius;
	}

	public void SetAddCursorMode(bool enabled)
	{
		if (enabled)
		{
			_cursorMode = CursorMode.Add;
		}
	}

	public void SetRemoveCursorMode(bool enabled)
	{
		if (enabled)
		{
			_cursorMode = CursorMode.Remove;
		}
	}

	public void SetMoveCursorMode(bool enabled)
	{
		if (enabled)
		{
			_cursorMode = CursorMode.Move;
		}
	}
}
