using System;
using UnityEngine;

[Serializable]
public struct TrainStressFrameData
{
	public Vector3 position;

	public Quaternion rotation;

	public Vector3 velocity;

	public Vector3 jointForce;

	public Vector3 jointTorque;

	public int trainIndex;

	public bool isValid;

	public float calculatedStress;

	public Vector3 calculatedTargetStress;

	public float calculatedBuildUp;

	public bool calculatedDerailed;

	public float calculatedAvgSpeed;
}
