using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class CubicBezierCurve
{
	private class CurveSample
	{
		public Vector3 location;

		public Vector3 tangent;

		public float distance;
	}

	private const int STEP_COUNT = 30;

	private const float T_STEP = 1f / 30f;

	public SplineNode n1;

	public SplineNode n2;

	private readonly List<CurveSample> samples = new List<CurveSample>(30);

	public UnityEvent Changed = new UnityEvent();

	public float Length { get; private set; }

	public CubicBezierCurve(SplineNode n1, SplineNode n2)
	{
		this.n1 = n1;
		this.n2 = n2;
		n1.Changed.AddListener(delegate
		{
			ComputePoints();
		});
		n2.Changed.AddListener(delegate
		{
			ComputePoints();
		});
		ComputePoints();
	}

	public void ConnectStart(SplineNode n1)
	{
		this.n1.Changed.RemoveListener(delegate
		{
			ComputePoints();
		});
		this.n1 = n1;
		n1.Changed.AddListener(delegate
		{
			ComputePoints();
		});
		ComputePoints();
	}

	public void ConnectEnd(SplineNode n2)
	{
		this.n2.Changed.RemoveListener(delegate
		{
			ComputePoints();
		});
		this.n2 = n2;
		n2.Changed.AddListener(delegate
		{
			ComputePoints();
		});
		ComputePoints();
	}

	public Vector3 GetInverseDirection()
	{
		return 2f * n2.position - n2.direction;
	}

	public Vector3 GetLocation(float t)
	{
		if (t < 0f || t > 1f)
		{
			throw new ArgumentException("Time must be between 0 and 1. Given time was " + t);
		}
		float num = 1f - t;
		float num2 = num * num;
		float num3 = t * t;
		return n1.position * (num2 * num) + n1.direction * (3f * num2 * t) + GetInverseDirection() * (3f * num * num3) + n2.position * (num3 * t);
	}

	public Vector3 GetTangent(float t)
	{
		if (t < 0f || t > 1f)
		{
			throw new ArgumentException("Time must be between 0 and 1. Given time was " + t);
		}
		float num = 1f - t;
		float num2 = num * num;
		float num3 = t * t;
		return (n1.position * (0f - num2) + n1.direction * (3f * num2 - 2f * num) + GetInverseDirection() * (-3f * num3 + 2f * t) + n2.position * num3).normalized;
	}

	private void ComputePoints()
	{
		samples.Clear();
		Length = 0f;
		Vector3 location = GetLocation(0f);
		for (float num = 0f; num < 1f; num += 1f / 30f)
		{
			CurveSample curveSample = new CurveSample();
			curveSample.location = GetLocation(num);
			curveSample.tangent = GetTangent(num);
			Length += Vector3.Distance(location, curveSample.location);
			curveSample.distance = Length;
			location = curveSample.location;
			samples.Add(curveSample);
		}
		CurveSample curveSample2 = new CurveSample();
		curveSample2.location = GetLocation(1f);
		curveSample2.tangent = GetTangent(1f);
		Length += Vector3.Distance(location, curveSample2.location);
		curveSample2.distance = Length;
		samples.Add(curveSample2);
		if (Changed != null)
		{
			Changed.Invoke();
		}
	}

	private Vector3 getCurvePointAtDistance(float d, bool tangent)
	{
		if (d < 0f || d > Length)
		{
			throw new ArgumentException("Distance must be positive and less than curve length. Length = " + Length + ", given distance was " + d);
		}
		CurveSample curveSample = samples[0];
		CurveSample curveSample2 = null;
		for (int i = 0; i < samples.Count; i++)
		{
			CurveSample curveSample3 = samples[i];
			if (curveSample3.distance >= d)
			{
				curveSample2 = curveSample3;
				break;
			}
			curveSample = curveSample3;
		}
		if (curveSample2 == null)
		{
			throw new Exception("Can't find curve samples.");
		}
		float t = ((curveSample2 == curveSample) ? 0f : ((d - curveSample.distance) / (curveSample2.distance - curveSample.distance)));
		if (tangent)
		{
			return Vector3.Lerp(curveSample.tangent, curveSample2.tangent, t).normalized;
		}
		return Vector3.Lerp(curveSample.location, curveSample2.location, t);
	}

	public Vector3 GetLocationAtDistance(float d)
	{
		return getCurvePointAtDistance(d, false);
	}

	public Vector3 GetTangentAtDistance(float d)
	{
		return getCurvePointAtDistance(d, true);
	}

	public static Quaternion GetRotationFromTangent(Vector3 Tangent)
	{
		if (Tangent == Vector3.zero)
		{
			return Quaternion.identity;
		}
		return Quaternion.LookRotation(Tangent, Vector3.Cross(Tangent, Vector3.Cross(Vector3.forward, Tangent).normalized));
	}
}
