using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class SplineNode
{
	public Vector3 position;

	public Vector3 direction;

	[HideInInspector]
	public UnityEvent Changed = new UnityEvent();

	public SplineNode(Vector3 position, Vector3 direction)
	{
		SetPosition(position);
		SetDirection(direction);
	}

	public void SetPosition(Vector3 p)
	{
		if (!position.Equals(p))
		{
			position.x = p.x;
			position.y = p.y;
			position.z = p.z;
			if (Changed != null)
			{
				Changed.Invoke();
			}
		}
	}

	public void SetDirection(Vector3 d)
	{
		if (!direction.Equals(d))
		{
			direction.x = d.x;
			direction.y = d.y;
			direction.z = d.z;
			if (Changed != null)
			{
				Changed.Invoke();
			}
		}
	}
}
