using System;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class SplineMaker : MonoBehaviour
{
	[Serializable]
	public class Vector3ArrayEvent : UnityEvent<Vector3[]>
	{
	}

	[SerializeField]
	private int _pointsPerSegment;

	[SerializeField]
	private bool _loop;

	[SerializeField]
	private Vector3[] _anchorPoints;

	[SerializeField]
	private Vector3ArrayEvent _onUpdated;

	private bool _isDirty;

	private Vector3[] _points;

	public int pointsPerSegment
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool loop
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Vector3[] anchorPoints
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Vector3[] points => null;

	public Vector3ArrayEvent onUpdated => null;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void UpdatePoints()
	{
	}

	private void OnValidate()
	{
	}

	private void OnDidApplyAnimationProperties()
	{
	}

	private static Vector3 CatmullRomInterpolation(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
	{
		return default(Vector3);
	}
}
