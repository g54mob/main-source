using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
	public CinemachineVirtualCamera cinemachineRef;

	public CinemachineVirtualCamera secondaryCinemachineRef;

	public float pathUnitsPerSecond = 1f;

	public float totalDistance = 35f;

	public float distanceUnitsPerSecond = 2.5f;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			StartCoroutine(CameraMoveRoutine());
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			secondaryCinemachineRef.enabled = true;
		}
	}

	private IEnumerator CameraMoveRoutine()
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		cinemachineRef.enabled = true;
		yield return new WaitForSeconds(3f);
		CinemachineTrackedDolly dollyRef = cinemachineRef.GetCinemachineComponent<CinemachineTrackedDolly>();
		float totalUnits = dollyRef.m_Path.MaxPos;
		for (float currentPos = 0f; currentPos < totalUnits; currentPos = (dollyRef.m_PathPosition = currentPos + pathUnitsPerSecond * Time.deltaTime))
		{
			yield return frameWait;
		}
	}
}
