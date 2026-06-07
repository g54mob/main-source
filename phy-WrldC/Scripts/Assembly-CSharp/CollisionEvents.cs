using System;
using UnityEngine;

public class CollisionEvents : MonoBehaviour
{
	public event Action<Collision> OnCollisionEnterEvent;

	public event Action<Collision> OnCollisionStayEvent;

	public event Action<Collision> OnCollisionExitEvent;

	private void OnCollisionEnter(Collision other)
	{
		if (this.OnCollisionEnterEvent != null)
		{
			this.OnCollisionEnterEvent(other);
		}
	}

	private void OnCollisionStay(Collision other)
	{
		if (this.OnCollisionStayEvent != null)
		{
			this.OnCollisionStayEvent(other);
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (this.OnCollisionExitEvent != null)
		{
			this.OnCollisionExitEvent(other);
		}
	}
}
