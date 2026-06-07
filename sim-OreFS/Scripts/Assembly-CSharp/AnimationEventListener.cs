using UnityEngine;
using UnityEngine.Events;

public class AnimationEventListener : MonoBehaviour
{
	[Header("Use Animation Events")]
	public UnityEvent onUseAnimationEvent;

	[Header("Second Use Animation Events")]
	public UnityEvent onSecondUseAnimationEvent;

	public void TriggerUseEvent()
	{
		onUseAnimationEvent?.Invoke();
	}

	public void TriggerSecondUseEvent()
	{
		onSecondUseAnimationEvent?.Invoke();
	}
}
