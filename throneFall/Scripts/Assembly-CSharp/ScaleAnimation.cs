using System.Collections;
using UnityEngine;

public class ScaleAnimation : OneShotAnimationBase
{
	public AnimationCurve curve;

	public float targetScale;

	public Transform transformToAnimate;

	public bool playOnStart;

	private float initialScale = 1f;

	private void Start()
	{
		initialScale = transformToAnimate.localScale.x;
		if (playOnStart)
		{
			initialScale = 0f;
			Trigger();
		}
	}

	private IEnumerator Animate()
	{
		transformToAnimate.localScale = Vector3.one * initialScale;
		float timer = 0f;
		while (timer < duration)
		{
			transformToAnimate.localScale = Vector3.one * Mathf.Lerp(initialScale, targetScale, curve.Evaluate(timer / duration));
			timer += Time.deltaTime;
			yield return null;
		}
		transformToAnimate.localScale = Vector3.one * Mathf.Lerp(initialScale, targetScale, curve.Evaluate(timer / duration));
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
