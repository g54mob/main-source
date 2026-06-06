using System.Collections.Generic;
using PajamaLlama.Debugs;
using PajamaLlama.Math;
using UnityEngine;

public class AnimationTween
{
	public struct Cubic
	{
		public Vector3 Position;

		public Vector3 Derivative;
	}

	public static Vector3 SphericalPositionLerp(Vector3 startPosition, Vector3 endPosition, float progress, float height = 1f)
	{
		if (height == 0f)
		{
			Debugger.Warning("Height can not be 0!");
			return (startPosition + endPosition) * 0.5f;
		}
		if (height >= Vector3.Distance(startPosition, endPosition) * 0.5f)
		{
			height = Vector3.Distance(startPosition, endPosition) * 0.5f - 0.01f;
		}
		float f = Vector3.Distance(startPosition, endPosition);
		float num = height / 2f + Mathf.Pow(f, 2f) / (8f * height);
		Vector3 index = Math.ReturnPerpendicularVector(endPosition - startPosition);
		Vector3 normalized = Math.ReturnPerpendicularVector(endPosition - startPosition, index).normalized;
		Vector3 vector = (startPosition + endPosition) * 0.5f;
		vector -= -normalized * (num - height);
		startPosition -= vector;
		endPosition -= vector;
		AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
		return Vector3.Slerp(startPosition, endPosition, animationCurve.Evaluate(progress)) + vector;
	}

	public static Vector3 LinearPositionLerp(Vector3 startPosition, Vector3 endPosition, float progress)
	{
		AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
		return Vector3.Lerp(startPosition, endPosition, animationCurve.Evaluate(progress));
	}

	public static Cubic CubicLerp(Vector3 startPosition, Vector3 endPosition, float progress, Vector3 curvature, AnimationCurve curve)
	{
		Vector3 item = startPosition;
		Vector3 item2 = endPosition;
		Vector3 vector = endPosition - startPosition;
		item.x += vector.x * curvature.x;
		item.y += vector.y * curvature.y;
		item.z += vector.z * curvature.z;
		item2.x -= vector.x * curvature.x;
		item2.y -= vector.y * curvature.y;
		item2.z -= vector.z * curvature.z;
		progress = curve.Evaluate(progress);
		List<Vector3> list = new List<Vector3>();
		list.Add(startPosition);
		list.Add(item);
		list.Add(item2);
		list.Add(endPosition);
		Cubic result = default(Cubic);
		result.Position = Bezier.CalculatePointInTime(progress, list);
		result.Derivative = Bezier.CalculateDerivative(progress, list);
		return result;
	}
}
