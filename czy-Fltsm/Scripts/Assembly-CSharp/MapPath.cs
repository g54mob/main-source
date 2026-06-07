using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class MapPath
{
	public struct Point
	{
		public Vector2 Position;

		public float LerpValue;

		public float DistanceToNextPoint;

		public Point(Vector2 position)
		{
			Position = position;
			LerpValue = 0f;
			DistanceToNextPoint = 0f;
		}
	}

	public enum State
	{
		Ok = 0,
		DestinationOutOfRange = 1,
		DestinationBlocked = 2
	}

	public interface IStateEvaluator
	{
		State ReturnEvaluatedState(MapPath mapPath);
	}

	private float _progress;

	private MapPathCalculator _calculator;

	private List<IStateEvaluator> _stateEvaluators;

	public List<MapObstacle> Obstacles { get; private set; }

	public Transform Origin { get; private set; }

	public Vector3 Destination { get; private set; }

	public List<Point> Points { get; private set; }

	public float Length { get; protected set; }

	public float LengthDifference { get; protected set; }

	public float Progress { get; protected set; }

	public State EvaluatedState { get; private set; }

	public MapPath(MapPathCalculator calculator, List<MapObstacle> obstacles, Transform origin)
	{
		Obstacles = obstacles;
		Origin = origin;
		_calculator = calculator;
		Points = ListPool<Point>.Get();
		MapEvent.DispatchMapPathStateUpdated(EvaluatedState);
	}

	public MapPath(MapPath mapPath)
	{
		Points = new List<Point>(mapPath.Points);
		Length = mapPath.Length;
		MapEvent.DispatchMapPathStateUpdated(EvaluatedState);
	}

	public void CalculatePath(Vector3 destination)
	{
		float length = Length;
		Destination = destination;
		Points.Clear();
		Length = 0f;
		Progress = 0f;
		_calculator.CalculatePath(this, Origin.position, destination);
		CalculatePointLerpValues();
		LengthDifference = Length - length;
		if (_stateEvaluators != null)
		{
			State state = ReturnEvaluatedState();
			if (state != EvaluatedState)
			{
				EvaluatedState = state;
				MapEvent.DispatchMapPathStateUpdated(EvaluatedState);
			}
		}
	}

	private void CalculatePointLerpValues()
	{
		if (Points != null && Points.Count != 0)
		{
			float num = 0f;
			for (int i = 0; i < Points.Count; i++)
			{
				Point value = Points[i];
				value.LerpValue = num / Length;
				num += value.DistanceToNextPoint;
				Points[i] = value;
			}
		}
	}

	public void AddStateEvaluator(IStateEvaluator stateEvaluator)
	{
		if (_stateEvaluators == null)
		{
			_stateEvaluators = new List<IStateEvaluator>();
		}
		_stateEvaluators.Add(stateEvaluator);
	}

	public void AddPathPoint(Vector2 point)
	{
		Point item = new Point(point);
		int num = Points.Count - 1;
		if (0 <= num)
		{
			Point value = Points[num];
			float num2 = (value.DistanceToNextPoint = Vector2.Distance(value.Position, point));
			Length += num2;
			Points[num] = value;
		}
		Points.Add(item);
	}

	public void SetLineRendererPositions(LineRenderer lineRenderer, float currentProgress)
	{
		int num = 1;
		lineRenderer.positionCount = Points.Count;
		lineRenderer.SetPosition(0, ReturnLerpedPosition(currentProgress).Vector3TopDown(0.1f));
		for (int i = 0; i < Points.Count; i++)
		{
			Point point = Points[i];
			if (!(point.LerpValue <= currentProgress))
			{
				lineRenderer.SetPosition(num, point.Position.Vector3TopDown(0.1f));
				num++;
			}
		}
		lineRenderer.positionCount = num;
	}

	public Vector2 ReturnPosition(float distance)
	{
		if (distance > Length)
		{
			return ReturnLerpedPosition(1f);
		}
		return ReturnLerpedPosition(distance / Length);
	}

	public bool ReturnNextPosition(float distance, out Vector3 position)
	{
		Progress = Mathf.Clamp01(Progress + distance / Length);
		position = ReturnLerpedPosition(Progress).Vector3TopDown();
		return Progress < 1f;
	}

	public Vector2 ReturnLerpedPosition(float lerp)
	{
		if (Points == null || Points.Count <= 1)
		{
			return Vector2.zero;
		}
		lerp = Mathf.Clamp(lerp, 0f, 1f);
		for (int i = 0; i < Points.Count - 1; i++)
		{
			Point point = Points[i];
			Point point2 = Points[i + 1];
			if (lerp >= point.LerpValue && lerp <= point2.LerpValue)
			{
				float t = 1f / (point2.LerpValue - point.LerpValue) * (lerp - point.LerpValue);
				return Vector2.Lerp(point.Position, point2.Position, t);
			}
		}
		throw new NotImplementedException();
	}

	private State ReturnEvaluatedState()
	{
		if (_stateEvaluators == null)
		{
			return State.Ok;
		}
		State state = State.Ok;
		int num = 0;
		while (state == State.Ok && num < _stateEvaluators.Count)
		{
			state = _stateEvaluators[num++].ReturnEvaluatedState(this);
		}
		return state;
	}
}
