using System;
using UnityEngine;

public class TriggerEvents : MonoBehaviour
{
	public event Action<Collider> OnTriggerEnterEvent;

	public event Action<Collider> OnTriggerStayEvent;

	public event Action<Collider> OnTriggerExitEvent;

	private void OnTriggerEnter(Collider other)
	{
		if (this.OnTriggerEnterEvent != null)
		{
			this.OnTriggerEnterEvent(other);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (this.OnTriggerStayEvent != null)
		{
			this.OnTriggerStayEvent(other);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (this.OnTriggerExitEvent != null)
		{
			this.OnTriggerExitEvent(other);
		}
	}
}
