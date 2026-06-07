using System;
using UnityEngine;

public class NullifierTargetIndicator : MonoBehaviour
{
	private LineRenderer pathLine;

	private int LINE_SEGMENT_COUNT;

	private float PATH_MAX_HEIGHT;

	[NonSerialized]
	public Vector3 start;

	[NonSerialized]
	public Vector3 end;

	public void Awake()
	{
	}

	public void HidePath()
	{
	}

	public void ShowPath()
	{
	}
}
