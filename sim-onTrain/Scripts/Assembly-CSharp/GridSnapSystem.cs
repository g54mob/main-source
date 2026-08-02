using System;
using System.Collections.Generic;
using UnityEngine;

public class GridSnapSystem : MonoBehaviour
{
	public Transform gridStartPos;

	public int gridSizeX;

	public int gridSizeY;

	public float distance = 1f;

	[SerializeField]
	private bool showGizmos;

	public List<SnapPointPositionData> snapPoints = new List<SnapPointPositionData>();

	public bool isGround;

	public bool isWagon;

	public bool isVertical;

	public GridSnapSystem connectedSnapSystem;

	public List<Transform> selectMultiplePoints = new List<Transform>();

	private void OnDrawGizmos()
	{
		if (!showGizmos)
		{
			return;
		}
		Gizmos.color = Color.green;
		if (!isGround)
		{
			for (int i = 0; i <= gridSizeX; i++)
			{
				for (int j = 0; j <= gridSizeY; j++)
				{
					Gizmos.DrawWireSphere(gridStartPos.position + gridStartPos.transform.right * i * distance + gridStartPos.transform.forward * j * distance, 0.1f);
				}
			}
			return;
		}
		Gizmos.color = Color.red;
		Vector3 size = GetComponentInChildren<Renderer>().bounds.size;
		size.x *= base.transform.localScale.x;
		size.y *= base.transform.localScale.y;
		size.z *= base.transform.localScale.z;
		float num = 0f;
		Vector3 center = GetComponentInChildren<Renderer>().bounds.center;
		Gizmos.DrawWireSphere(center, 0.1f);
		for (int k = 0; k < 4; k++)
		{
			Vector3 vector = base.transform.forward;
			if (isVertical)
			{
				vector = base.transform.up;
			}
			Vector3 right = base.transform.right;
			num = ((!isVertical) ? ((k % 2 == 0) ? (size.z / 2f) : (size.x / 2f)) : ((k % 2 == 0) ? (size.y / 2f) : (size.x / 2f)));
			float f = MathF.PI / 180f * (float)(k * 90);
			Gizmos.DrawWireSphere(center + num * right * Mathf.Sin(f) + num * vector * Mathf.Cos(f), 0.1f);
		}
	}

	public void AddMultiplePoints()
	{
		foreach (Transform selectMultiplePoint in selectMultiplePoints)
		{
			snapPoints.Add(new SnapPointPositionData
			{
				transform = selectMultiplePoint,
				rotationType = SnapperRotationType.Center,
				bounds = Vector3.one,
				meshCenter = Vector3.zero
			});
		}
		selectMultiplePoints.Clear();
	}

	private void ClearGrids()
	{
		foreach (SnapPointPositionData snapPoint in snapPoints)
		{
			UnityEngine.Object.Destroy(snapPoint.transform.gameObject);
		}
		snapPoints.Clear();
	}

	public void SetSnapPointsType(SnapperRotationType rotationType)
	{
		foreach (SnapPointPositionData snapPoint in snapPoints)
		{
			snapPoint.rotationType = rotationType;
		}
	}

	private void SetGrids()
	{
		if (!isGround)
		{
			int num = 1;
			for (int i = 0; i <= gridSizeX; i++)
			{
				for (int j = 0; j <= gridSizeY; j++)
				{
					GameObject gameObject = new GameObject("SnapPoint" + num);
					SnapPointPositionData snapPointPositionData = new SnapPointPositionData();
					gameObject.transform.position = gridStartPos.position + gridStartPos.transform.right * i * distance + gridStartPos.transform.forward * j * distance;
					gameObject.transform.parent = base.transform;
					snapPointPositionData.transform = gameObject.transform;
					num++;
					snapPoints.Add(snapPointPositionData);
				}
			}
			return;
		}
		Vector3 size = GetComponentInChildren<Renderer>().bounds.size;
		Vector3 center = GetComponentInChildren<Renderer>().bounds.center;
		float num2 = 0f;
		int num3 = 1;
		SnapPointPositionData snapPointPositionData2 = new SnapPointPositionData();
		GameObject gameObject2 = new GameObject("SnapPoint" + num3);
		gameObject2.transform.position = center;
		gameObject2.transform.parent = base.transform;
		snapPointPositionData2.transform = gameObject2.transform;
		snapPointPositionData2.rotationType = SnapperRotationType.Cross;
		snapPointPositionData2.meshCenter = center;
		snapPointPositionData2.bounds = size;
		snapPoints.Add(snapPointPositionData2);
		for (int k = 0; k < 4; k++)
		{
			Vector3 vector = base.transform.forward;
			if (isVertical)
			{
				vector = base.transform.up;
			}
			Vector3 right = base.transform.right;
			num2 = ((!isVertical) ? ((k % 2 == 0) ? (size.z / 2f) : (size.x / 2f)) : ((k % 2 == 0) ? (size.y / 2f) : (size.x / 2f)));
			float f = MathF.PI / 180f * (float)(k * 90);
			Vector3 position = center + num2 * right * Mathf.Sin(f) + num2 * vector * Mathf.Cos(f);
			SnapPointPositionData snapPointPositionData3 = new SnapPointPositionData();
			snapPointPositionData3.meshCenter = center;
			snapPointPositionData3.bounds = size;
			GameObject gameObject3 = new GameObject("SnapPoint" + num3);
			snapPointPositionData3.transform = gameObject3.transform;
			gameObject3.transform.position = position;
			gameObject3.transform.parent = base.transform;
			snapPointPositionData3.transform.localEulerAngles = new Vector3(0f, k * 90, 0f);
			snapPointPositionData3.rotationType = (SnapperRotationType)k;
			snapPoints.Add(snapPointPositionData3);
			num3++;
		}
	}
}
