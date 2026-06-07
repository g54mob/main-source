using System;
using UnityEngine;

public class IkSolver
{
	public struct Target
	{
		public Matrix4x4 matrix;

		public Vector3 elbow;

		public float minDeflectionAngle;

		public Vector3 position
		{
			get
			{
				return matrix.GetColumn(3);
			}
		}

		public static Target Lerp(Target a, Target b, float t)
		{
			return new Target
			{
				matrix = Util.LerpMatrix(a.matrix, b.matrix, t),
				elbow = Util.LerpNoClamp(a.elbow, b.elbow, t),
				minDeflectionAngle = Util.LerpNoClamp(a.minDeflectionAngle, b.minDeflectionAngle, t)
			};
		}
	}

	private Transform upperArm;

	private Transform lowerArm;

	private Transform hand;

	public readonly float upperArmLen;

	public float lowerArmLen;

	public float armLen;

	public Target solvedTarget { get; private set; }

	public IkSolver(Transform upperArm_, Transform lowerArm_, Transform hand_)
	{
		upperArm = upperArm_;
		lowerArm = lowerArm_;
		hand = hand_;
		upperArmLen = Vector3.Distance(upperArm.position, lowerArm.position);
		lowerArmLen = Vector3.Distance(lowerArm.position, hand.position);
		armLen = upperArmLen + lowerArmLen;
	}

	public void Solve(Target target, float weight)
	{
		lowerArmLen = Vector3.Distance(lowerArm.position, hand.position);
		armLen = upperArmLen + lowerArmLen;
		weight = Mathf.Min(1f, weight);
		Quaternion rotation = upperArm.rotation;
		Quaternion rotation2 = lowerArm.rotation;
		Vector3 vector = target.position - upperArm.position;
		float magnitude = (vector.normalized * Mathf.Min(vector.magnitude, upperArmLen + lowerArmLen - 0.0001f)).magnitude;
		float a = Mathf.Acos((upperArmLen * upperArmLen + magnitude * magnitude - lowerArmLen * lowerArmLen) / (2f * upperArmLen * magnitude));
		a = Mathf.Max(a, target.minDeflectionAngle * ((float)Math.PI / 180f));
		Matrix4x4 matrix4x = Util.MakeLookAtMatrix(upperArm.position, target.position, target.elbow - upperArm.position);
		Vector3 worldPosition = matrix4x.MultiplyPoint(upperArmLen * new Vector3(0f, Mathf.Sin(a), Mathf.Cos(a)));
		Vector3 worldUp = -matrix4x.GetColumn(0);
		upperArm.LookAt(worldPosition, worldUp);
		lowerArm.LookAt(target.position, worldUp);
		upperArm.rotation = Quaternion.Slerp(rotation, upperArm.rotation, weight);
		lowerArm.rotation = Quaternion.Slerp(rotation2, lowerArm.rotation, weight);
		solvedTarget = target;
	}

	public float GetDistFromHandToTarget(Target target)
	{
		return Vector3.Distance(hand.position, target.position);
	}

	public void SolveWithApproach(Target target, float weight, AnimationCurve approachCurve)
	{
		Quaternion rotation = upperArm.rotation;
		Quaternion rotation2 = lowerArm.rotation;
		Solve(target, weight);
		float num = approachCurve.Evaluate(GetDistFromHandToTarget(target));
		Vector3 normalized = (hand.position - target.position).normalized;
		Target target2 = target;
		target2.matrix.SetColumn(3, target.position + normalized.normalized * num);
		upperArm.rotation = rotation;
		lowerArm.rotation = rotation2;
		Solve(target2, weight);
	}
}
