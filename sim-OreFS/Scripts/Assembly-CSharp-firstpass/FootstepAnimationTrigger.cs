using UnityEngine;
using UnityEngine.Events;

public class FootstepAnimationTrigger : MonoBehaviour
{
	public UnityEvent onFootstep;

	public void SetSound()
	{
		onFootstep.Invoke();
	}
}
