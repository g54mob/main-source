using UnityEngine;
using UnityEngine.Events;

public class TriggerOnLook : MonoBehaviour
{
	[SerializeField]
	private UnityEvent action;

	private void OnBecameVisible()
	{
		action.Invoke();
		base.enabled = false;
	}
}
