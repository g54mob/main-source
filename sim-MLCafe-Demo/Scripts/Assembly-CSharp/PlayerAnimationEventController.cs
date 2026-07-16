using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimationEventController : MonoBehaviour
{
	public UnityEvent OnTriggerBeginAnimation = new UnityEvent();

	public UnityEvent OnTriggerEndAnimation = new UnityEvent();

	public UnityEvent OnTriggerImpactPoint = new UnityEvent();

	public void TriggerBeginAnimation()
	{
		OnTriggerBeginAnimation.Invoke();
	}

	public void TriggerImpactPoint()
	{
		OnTriggerImpactPoint.Invoke();
	}

	public void TriggerEndAnimation()
	{
		OnTriggerEndAnimation.Invoke();
	}
}
