using UnityEngine;
using UnityEngine.Events;

public class AnimationEventTrigger : MonoBehaviour
{
	public UnityEvent animEvent;

	public UnityEvent animEvent2;

	public UnityEvent animEvent3;

	public void ExecuteEvent()
	{
		animEvent.Invoke();
	}

	public void ExecuteEvent2()
	{
		animEvent2.Invoke();
	}

	public void ExecuteEvent3()
	{
		animEvent3.Invoke();
	}
}
