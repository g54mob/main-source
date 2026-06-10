using UnityEngine;

public class AnimationEventForwarder : MonoBehaviour
{
	public GameObject target;

	public void OnDoorAnimationEvent(string param)
	{
		if (!(target == null))
		{
			target.SendMessage("OnDoorAnimationEvent", param, SendMessageOptions.DontRequireReceiver);
		}
	}
}
