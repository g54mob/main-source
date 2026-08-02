using UnityEngine;

public class EASTUP_WeaponAnimationHandler : MonoBehaviour
{
	public Animator fpsAnimator;

	private Animator tpsAnimator;

	[SerializeField]
	private Transform tpsParent;

	private void Start()
	{
		tpsAnimator = tpsParent.GetComponentInChildren<Animator>();
	}

	public void SetTriggerAnimation(int key)
	{
		fpsAnimator.SetTrigger(key);
		tpsAnimator.SetTrigger(key);
	}

	public void SetBoolAnimation(int key, bool value)
	{
		fpsAnimator.SetBool(key, value);
		tpsAnimator.SetBool(key, value);
	}

	public void SetFloatAnimation(int key, float value)
	{
		fpsAnimator.SetFloat(key, value);
		tpsAnimator.SetFloat(key, value);
	}

	public void SetIntegerAnimation(int key, int value)
	{
		fpsAnimator.SetInteger(key, value);
		tpsAnimator.SetInteger(key, value);
	}
}
