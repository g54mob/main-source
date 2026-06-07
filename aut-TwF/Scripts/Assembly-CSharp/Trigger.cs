using UnityEngine;
using UnityEngine.Events;

public abstract class Trigger : MonoBehaviour
{
	[SerializeField]
	private UnityEvent onTriggered;

	[SerializeField]
	private bool destroyAfterActivate;

	protected void ActivateTrigger()
	{
		onTriggered.Invoke();
		if (destroyAfterActivate)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
