using UnityEngine;
using UnityEngine.Events;

public class RunEventOnEnable : MonoBehaviour
{
	public UnityEvent eventOnEnable;

	private void OnEnable()
	{
		eventOnEnable.Invoke();
	}
}
