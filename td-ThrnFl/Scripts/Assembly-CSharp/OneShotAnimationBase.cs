using UnityEngine;

public abstract class OneShotAnimationBase : MonoBehaviour
{
	public float duration = 1f;

	public abstract void Trigger();
}
