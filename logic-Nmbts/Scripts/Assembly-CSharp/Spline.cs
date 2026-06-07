using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class Spline : MonoBehaviour
{
	public List<SplineNode> nodes = new List<SplineNode>();

	[HideInInspector]
	public List<CubicBezierCurve> curves = new List<CubicBezierCurve>();

	public float Length;

	[HideInInspector]
	public UnityEvent NodeCountChanged = new UnityEvent();

	[HideInInspector]
	public UnityEvent CurveChanged = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnSplineValidate = new UnityEvent();

	[HideInInspector]
	public int LastNodeAdded;

	[HideInInspector]
	public int LastNodeRemoved;

	public bool Loop;

	private bool _loopPrevious;

	private Vector3 _loopPreviousPos;

	private Vector3 _loopPreviousDir;

	public void Reset()
	{
		nodes.Clear();
		curves.Clear();
		AddNode(new SplineNode(new Vector3(0f, 0f, 0f), new Vector3(10f, 0f, 0f)));
		AddNode(new SplineNode(new Vector3(20f, 0f, 0f), new Vector3(30f, 0f, 0f)));
		RaiseNodeCountChanged();
		UpdateAfterCurveChanged();
	}

	public void ResetFully()
	{
		nodes.Clear();
		curves.Clear();
		RaiseNodeCountChanged();
		UpdateAfterCurveChanged();
	}

	protected virtual void OnEnable()
	{
		curves.Clear();
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			SplineNode n = nodes[i];
			SplineNode n2 = nodes[i + 1];
			CubicBezierCurve cubicBezierCurve = new CubicBezierCurve(n, n2);
			cubicBezierCurve.Changed.AddListener(delegate
			{
				UpdateAfterCurveChanged();
			});
			curves.Add(cubicBezierCurve);
		}
		RaiseNodeCountChanged();
		UpdateAfterCurveChanged();
	}

	public ReadOnlyCollection<CubicBezierCurve> GetCurves()
	{
		return curves.AsReadOnly();
	}

	public void RaiseOnSplineValidate()
	{
		if (OnSplineValidate != null)
		{
			OnSplineValidate.Invoke();
		}
	}

	private void RaiseNodeCountChanged()
	{
		if (NodeCountChanged != null)
		{
			NodeCountChanged.Invoke();
		}
	}

	private void UpdateAfterCurveChanged()
	{
		Length = 0f;
		foreach (CubicBezierCurve curf in curves)
		{
			Length += curf.Length;
		}
		if (nodes.Count > 0 && Loop)
		{
			nodes[nodes.Count - 1].SetPosition(nodes[0].position);
			nodes[nodes.Count - 1].SetDirection(nodes[0].direction);
		}
		if (CurveChanged != null)
		{
			CurveChanged.Invoke();
		}
	}

	public void DoLoop()
	{
		SplineNode splineNode = nodes[nodes.Count - 1];
		if (Loop && !_loopPrevious)
		{
			_loopPreviousPos = splineNode.position;
			_loopPreviousDir = splineNode.direction;
			splineNode.SetPosition(nodes[0].position);
			splineNode.SetDirection(nodes[0].direction);
			_loopPrevious = true;
		}
		if (!Loop && _loopPrevious)
		{
			splineNode.SetPosition(_loopPreviousPos);
			splineNode.SetDirection(_loopPreviousDir);
			_loopPrevious = false;
		}
	}

	public Vector3 GetLocationAlongSpline(float t)
	{
		int nodeIndexForTime = GetNodeIndexForTime(t);
		return curves[nodeIndexForTime].GetLocation(t - (float)nodeIndexForTime);
	}

	public Vector3 GetTangentAlongSpline(float t)
	{
		int nodeIndexForTime = GetNodeIndexForTime(t);
		return curves[nodeIndexForTime].GetTangent(t - (float)nodeIndexForTime);
	}

	private int GetNodeIndexForTime(float t)
	{
		if (t < 0f || t > (float)(nodes.Count - 1))
		{
			throw new ArgumentException(string.Format("Time must be between 0 and last node index ({0}). Given time was {1}.", nodes.Count - 1, t));
		}
		int num = Mathf.FloorToInt(t);
		if (num == nodes.Count - 1)
		{
			num--;
		}
		return num;
	}

	public Vector3 GetLocationAlongSplineAtDistance(float d)
	{
		if (!Loop && (d < 0f || d > Length))
		{
			throw new ArgumentException(string.Format("Distance must be between 0 and spline length ({0}). Given distance was {1}.", Length, d));
		}
		if (Loop)
		{
			if (d < 0f)
			{
				d += Length;
			}
			else if (d > Length)
			{
				d -= Length;
			}
		}
		if (Mathf.Abs(d - Length) < float.Epsilon)
		{
			return GetLocationAlongSpline(nodes.Count - 1);
		}
		foreach (CubicBezierCurve curf in curves)
		{
			if (d > curf.Length)
			{
				d -= curf.Length;
				continue;
			}
			return curf.GetLocationAtDistance(d);
		}
		throw new Exception("Something went wrong with GetLocationAlongSplineAtDistance");
	}

	public Vector3 GetTangentAlongSplineAtDistance(float d)
	{
		if (!Loop && (d < 0f || d > Length))
		{
			throw new ArgumentException(string.Format("Distance must be between 0 and spline length ({0}). Given distance was {1}.", Length, d));
		}
		if (Loop)
		{
			if (d < 0f)
			{
				d += Length;
			}
			else if (d > Length)
			{
				d -= Length;
			}
		}
		if (Mathf.Abs(d - Length) < float.Epsilon)
		{
			return GetTangentAlongSpline(nodes.Count - 1);
		}
		foreach (CubicBezierCurve curf in curves)
		{
			if (d > curf.Length)
			{
				d -= curf.Length;
				continue;
			}
			return curf.GetTangentAtDistance(d);
		}
		throw new Exception("Something went wrong with GetTangentAlongSplineAtDistance");
	}

	public Vector3 GetWorldPositionOfNode(SplineNode node)
	{
		if (!nodes.Contains(node))
		{
			throw new Exception("Specified node is not a part of this spline");
		}
		int index = nodes.IndexOf(node);
		return base.transform.TransformPoint(nodes[index].position);
	}

	public Vector3 GetWorldDirectionOfNode(SplineNode node)
	{
		if (!nodes.Contains(node))
		{
			throw new Exception("Specified node is not a part of this spline");
		}
		int index = nodes.IndexOf(node);
		return base.transform.TransformPoint(nodes[index].direction);
	}

	public int GetLastNodeIndexAtDistance(float distance)
	{
		float num = distance;
		for (int i = 0; i < nodes.Count; i++)
		{
			if (curves[i].Length > num)
			{
				return i;
			}
			num -= curves[i].Length;
		}
		throw new Exception("Something went wrong with GetLastNodeAtDistance");
	}

	public void AddNode(SplineNode node)
	{
		nodes.Add(node);
		LastNodeAdded = nodes.IndexOf(node);
		if (nodes.Count != 1)
		{
			CubicBezierCurve cubicBezierCurve = new CubicBezierCurve(nodes[nodes.IndexOf(node) - 1], node);
			cubicBezierCurve.Changed.AddListener(delegate
			{
				UpdateAfterCurveChanged();
			});
			curves.Add(cubicBezierCurve);
		}
		RaiseNodeCountChanged();
		UpdateAfterCurveChanged();
	}

	public void InsertNode(int index, SplineNode node)
	{
		if (index == 0)
		{
			throw new Exception("Can't insert a node at index 0");
		}
		SplineNode splineNode = nodes[index - 1];
		SplineNode n = nodes[index];
		nodes.Insert(index, node);
		LastNodeAdded = index;
		curves[index - 1].ConnectEnd(node);
		CubicBezierCurve cubicBezierCurve = new CubicBezierCurve(node, n);
		cubicBezierCurve.Changed.AddListener(delegate
		{
			UpdateAfterCurveChanged();
		});
		curves.Insert(index, cubicBezierCurve);
		RaiseNodeCountChanged();
		UpdateAfterCurveChanged();
	}

	public void RemoveNode(SplineNode node)
	{
		int num = nodes.IndexOf(node);
		if (nodes.Count <= 2)
		{
			throw new Exception("Can't remove the node because a spline needs at least 2 nodes.");
		}
		CubicBezierCurve cubicBezierCurve = ((num == nodes.Count - 1) ? curves[num - 1] : curves[num]);
		if (num != 0 && num != nodes.Count - 1)
		{
			SplineNode n = nodes[num + 1];
			curves[num - 1].ConnectEnd(n);
		}
		nodes.RemoveAt(num);
		LastNodeRemoved = num;
		cubicBezierCurve.Changed.RemoveListener(delegate
		{
			UpdateAfterCurveChanged();
		});
		curves.Remove(cubicBezierCurve);
		RaiseNodeCountChanged();
		UpdateAfterCurveChanged();
	}
}
