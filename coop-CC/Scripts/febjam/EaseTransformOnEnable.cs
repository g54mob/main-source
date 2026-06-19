using System.Collections;
using Aggro.Core;
using UnityEngine;

public class EaseTransformOnEnable : EntityBehaviourBase
{
	public float timeSeconds = 1f;

	public EasingFunction.Ease ease = EasingFunction.Ease.Linear;

	protected override void OnEntityCreated()
	{
		StartCoroutine(Grow());
	}

	private IEnumerator Grow()
	{
		float time = 0f;
		while (time < timeSeconds)
		{
			time += Time.deltaTime;
			float value = time / timeSeconds;
			float num = EasingFunction.Evaluate(ease, value);
			base.transform.localScale = Vector3.one * num;
			yield return null;
		}
	}
}
