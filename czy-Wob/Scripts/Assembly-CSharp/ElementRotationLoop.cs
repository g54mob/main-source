using System.Collections.Generic;
using UnityEngine;

public class ElementRotationLoop : MonoBehaviour
{
	public List<Vector3> rotVals = new List<Vector3>();

	public List<float> rotTimes = new List<float>();

	private float loopTime;

	private Vector3 targetRot;

	private Vector3 loopStartRot;

	private int index;

	private Vector3 startRot;

	private void Start()
	{
		startRot = base.transform.localRotation.eulerAngles;
		StartLoop();
	}

	private void Update()
	{
		UpdateLoop();
	}

	public void ForceCancel()
	{
		base.transform.localRotation = Quaternion.Euler(startRot);
	}

	private void StartLoop()
	{
		loopTime = 0f;
		loopStartRot = base.transform.localRotation.eulerAngles;
		targetRot = new Vector3(rotVals[index].x + startRot.x, rotVals[index].y + startRot.y, rotVals[index].z + startRot.z);
	}

	private void ContinueLoop()
	{
		loopTime = 0f;
		if (index > 0)
		{
			loopStartRot = rotVals[index - 1];
		}
		else
		{
			loopStartRot = rotVals[rotVals.Count - 1];
		}
		targetRot = new Vector3(rotVals[index].x + startRot.x, rotVals[index].y + startRot.y, rotVals[index].z + startRot.z);
	}

	private void UpdateLoop()
	{
		loopTime += Time.deltaTime;
		if (loopTime > rotTimes[index])
		{
			loopTime = rotTimes[index];
		}
		float num = loopTime / rotTimes[index];
		Vector3 euler = new Vector3(loopStartRot.x + (targetRot.x - loopStartRot.x) * num, loopStartRot.y + (targetRot.y - loopStartRot.y) * num, loopStartRot.z + (targetRot.z - loopStartRot.z) * num);
		base.transform.localRotation = Quaternion.Euler(euler);
		if (loopTime >= rotTimes[index])
		{
			LoopEnd();
		}
	}

	private void LoopEnd()
	{
		index++;
		if (index >= rotVals.Count)
		{
			index = 0;
		}
		ContinueLoop();
	}
}
