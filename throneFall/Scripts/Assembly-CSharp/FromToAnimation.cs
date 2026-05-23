using System.Collections;
using UnityEngine;

public class FromToAnimation : OneShotAnimationBase
{
	public AnimationCurve curve;

	public Vector3 eulerTargetRotation;

	public Transform transformToAnimate;

	private Quaternion initialRotation;

	private Quaternion targetRotation;

	private void Start()
	{
		initialRotation = transformToAnimate.localRotation;
		targetRotation = Quaternion.Euler(eulerTargetRotation.x, eulerTargetRotation.y, eulerTargetRotation.z);
	}

	private IEnumerator Animate()
	{
		transformToAnimate.localRotation = initialRotation;
		float timer = 0f;
		while (timer < duration)
		{
			transformToAnimate.localRotation = Quaternion.Lerp(initialRotation, targetRotation, curve.Evaluate(timer / duration));
			timer += Time.deltaTime;
			yield return null;
		}
		transformToAnimate.localRotation = Quaternion.Lerp(initialRotation, targetRotation, curve.Evaluate(1f));
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
