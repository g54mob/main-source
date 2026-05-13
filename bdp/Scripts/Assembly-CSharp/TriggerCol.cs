using UnityEngine;
using UnityEngine.Events;

public class TriggerCol : MonoBehaviour
{
	[SerializeField]
	private bool destroy;

	[SerializeField]
	private UnityEvent action;

	private bool triggered;

	private void OnTriggerEnter(Collider other)
	{
		if (!triggered && other.tag == "Player")
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

	private void OnCollisionEnter(Collision other)
	{
		if (!triggered && other.gameObject.tag == "Player")
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
}
