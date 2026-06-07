using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(LineRenderer))]
public class RuntimePathVisualizer : MonoBehaviour
{
	public float lineWidth = 0.06f;

	private Seeker seeker;

	private LineRenderer lr;

	private void Awake()
	{
		seeker = GetComponent<Seeker>();
		lr = GetComponent<LineRenderer>();
		lr.positionCount = 0;
		lr.widthMultiplier = lineWidth;
		lr.useWorldSpace = true;
	}

	private void OnEnable()
	{
		Seeker obj = seeker;
		obj.pathCallback = (OnPathDelegate)Delegate.Combine(obj.pathCallback, new OnPathDelegate(OnPathComplete));
	}

	private void OnDisable()
	{
		Seeker obj = seeker;
		obj.pathCallback = (OnPathDelegate)Delegate.Remove(obj.pathCallback, new OnPathDelegate(OnPathComplete));
	}

	private void OnPathComplete(Path p)
	{
		if (p == null || p.vectorPath == null)
		{
			lr.positionCount = 0;
			return;
		}
		List<Vector3> vectorPath = p.vectorPath;
		lr.positionCount = vectorPath.Count;
		for (int i = 0; i < vectorPath.Count; i++)
		{
			lr.SetPosition(i, vectorPath[i]);
		}
	}
}
