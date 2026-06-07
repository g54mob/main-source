using UnityEngine;
using UnityEngine.Events;

public class TriggerColLook : MonoBehaviour
{
	[SerializeField]
	private bool destroy;

	[SerializeField]
	private UnityEvent action;

	private bool triggered;

	private bool triggering;

	private bool looking;

	private void OnTriggerEnter(Collider other)
	{
		triggering = true;
	}

	private void OnTriggerExit(Collider other)
	{
		triggering = false;
	}

	private void OnTriggerStay(Collider other)
	{
		if (!triggered && other.tag == "Player" && triggering && looking)
		{
			triggered = true;
			action.Invoke();
			if (destroy)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				base.enabled = false;
			}
		}
	}

	private void OnBecameVisible()
	{
		looking = true;
	}

	private void OnBecameInvisible()
	{
		looking = false;
	}
}
