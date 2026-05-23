using System.Collections;
using UnityEngine;

public class PositionAnimation : OneShotAnimationBase
{
	public AnimationCurve curve;

	public Vector3 targetPosition;

	public Transform transformToAnimate;

	private Vector3 initialPosition;

	private void Start()
	{
		initialPosition = transformToAnimate.localPosition;
	}

	private IEnumerator Animate()
	{
		transformToAnimate.localPosition = initialPosition;
		float timer = 0f;
		while (timer < duration)
		{
			transformToAnimate.localPosition = Vector3.Lerp(initialPosition, targetPosition, curve.Evaluate(timer / duration));
			timer += Time.deltaTime;
			yield return null;
		}
		transformToAnimate.localPosition = Vector3.Lerp(initialPosition, targetPosition, curve.Evaluate(1f));
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
