using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines.Examples
{
	public class TrainEngine : MonoBehaviour
	{
		private SplineTracer _tracer;

		private double _lastPercent;

		private Wagon _wagon;

		private void Awake()
		{
			_wagon = GetComponent<Wagon>();
		}

		private void Start()
		{
			_tracer = GetComponent<SplineTracer>();
			_tracer.onNode += OnJunction;
			_tracer.onMotionApplied += OnMotionApplied;
			if (_tracer is SplineFollower)
			{
				SplineFollower obj = (SplineFollower)_tracer;
				Debug.Log("Subscribing to follower");
				obj.onBeginningReached += FollowerOnBeginningReached;
				obj.onEndReached += FollowerOnEndReached;
			}
		}

		private void OnMotionApplied()
		{
			_lastPercent = _tracer.result.percent;
			_wagon.UpdateOffset();
		}

		private void FollowerOnBeginningReached(double lastPercent)
		{
			_lastPercent = lastPercent;
		}

		private void FollowerOnEndReached(double lastPercent)
		{
			_lastPercent = lastPercent;
		}

		private void OnJunction(List<SplineTracer.NodeConnection> passed)
		{
			Node node = passed[0].node;
			JunctionSwitch component = node.GetComponent<JunctionSwitch>();
			if (component == null || component.bridges.Length == 0)
			{
				return;
			}
			JunctionSwitch.Bridge[] bridges = component.bridges;
			foreach (JunctionSwitch.Bridge bridge in bridges)
			{
				if (!bridge.active || bridge.a == bridge.b)
				{
					continue;
				}
				int num = 0;
				Node.Connection[] connections = node.GetConnections();
				for (int j = 0; j < connections.Length; j++)
				{
					if (connections[j].spline == _tracer.spline)
					{
						num = j;
						break;
					}
				}
				if (num != bridge.a && num != bridge.b)
				{
					continue;
				}
				if (num == bridge.a)
				{
					if (_tracer.direction == (Spline.Direction)bridge.bDirection)
					{
						SwitchSpline(connections[bridge.a], connections[bridge.b]);
						break;
					}
				}
				else if (_tracer.direction == (Spline.Direction)bridge.aDirection)
				{
					SwitchSpline(connections[bridge.b], connections[bridge.a]);
					break;
				}
			}
		}

		private void SwitchSpline(Node.Connection from, Node.Connection to)
		{
			float distance = from.spline.CalculateLength(from.spline.GetPointPercent(from.pointIndex), _tracer.UnclipPercent(_lastPercent));
			_tracer.spline = to.spline;
			_tracer.RebuildImmediate();
			double start = _tracer.ClipPercent(to.spline.GetPointPercent(to.pointIndex));
			if (Vector3.Dot(from.spline.Evaluate(from.pointIndex).forward, to.spline.Evaluate(to.pointIndex).forward) < 0f)
			{
				if (_tracer.direction == Spline.Direction.Forward)
				{
					_tracer.direction = Spline.Direction.Backward;
				}
				else
				{
					_tracer.direction = Spline.Direction.Forward;
				}
			}
			_tracer.SetPercent(_tracer.Travel(start, distance, _tracer.direction));
			_wagon.EnterSplineSegment(from.pointIndex, _tracer.spline, to.pointIndex, _tracer.direction);
			_wagon.UpdateOffset();
		}
	}
}
