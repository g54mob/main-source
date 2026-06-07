using System;
using UnityEngine;

public class MiniMapMLDisk : MonoBehaviour
{
	public Color ACTIVE_COLOR;

	public Color NORMAL_COLOR;

	[NonSerialized]
	public float scale;

	private bool _activeDisk;

	public bool activeDisk
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void SetPosition(int cellX, int cellZ)
	{
	}

	public void SetRange(int r)
	{
	}

	public void Awake()
	{
	}
}
