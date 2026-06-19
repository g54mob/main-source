using UnityEngine;
using UnityEngine.Events;

public class ClickablePenButton : ClickableObject
{
	public InchwormBounce bounceRef;

	public GameObject clickParticles;

	public Transform particlesTransform;

	public UnityEvent onClickEvents;

	protected override void OnClickInternal()
	{
		if (CanHighlight())
		{
			base.OnClickInternal();
			onClickEvents.Invoke();
			if (bounceRef != null)
			{
				bounceRef.RequestBounce();
			}
			Object.Instantiate(clickParticles, particlesTransform.position, particlesTransform.rotation);
		}
	}
}
