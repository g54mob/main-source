using System.Collections;
using UnityEngine;

public class SpinAnimation : OneShotAnimationBase
{
	public AnimationCurve curve;

	public Vector3 spinRotation;

	public Transform transformToAnimate;

	private Quaternion initialRotation;

	private Quaternion targetRotation;

	private void Start()
	{
		initialRotation = transformToAnimate.localRotation;
		targetRotation = Quaternion.Euler(spinRotation.x, spinRotation.y, spinRotation.z);
	}

	private IEnumerator Animate()
	{
		transformToAnimate.localRotation = initialRotation;
		float timer = 0f;
		while (timer < duration)
		{
			transformToAnimate.localRotation = Quaternion.Euler(initialRotation.eulerAngles + spinRotation * (timer / duration));
			timer += Time.deltaTime;
			yield return null;
		}
		transformToAnimate.localRotation = initialRotation;
	}

	public override void Trigger()
	{
		if (base.gameObject.activeInHierarchy)
		{
			StopAllCoroutines();
			StartCoroutine(Animate());
		}
	}
}
