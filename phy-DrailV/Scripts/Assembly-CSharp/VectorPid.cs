using System;
using UnityEngine;

[Serializable]
public class VectorPid
{
	public float pFactor;

	public float iFactor;

	public float dFactor;

	private Vector3 integral;

	private Vector3 lastError;

	public VectorPid(float pFactor, float iFactor, float dFactor)
	{
		this.pFactor = pFactor;
		this.iFactor = iFactor;
		this.dFactor = dFactor;
	}

	public Vector3 Update(Vector3 target, Vector3 current, float timeFrame)
	{
		return Update(target - current, timeFrame);
	}

	public Vector3 Update(Vector3 currentError, float timeFrame)
	{
		integral += currentError * timeFrame;
		Vector3 vector = (currentError - lastError) / timeFrame;
		lastError = currentError;
		return currentError * pFactor + integral * iFactor + vector * dFactor;
	}
}
