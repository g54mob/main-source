using System.Collections;
using UnityEngine;

public class LevelUpScreenAnimation : MonoBehaviour
{
	public float animationTime = 0.5f;

	public AnimationCurve scaleCurve;

	public Transform target;

	public void Trigger()
	{
		StopAllCoroutines();
		StartCoroutine(Animation());
	}

	private IEnumerator Animation()
	{
		float timer = 0f;
		while (timer < animationTime)
		{
			timer += Time.unscaledDeltaTime;
			target.localScale = Vector3.one * scaleCurve.Evaluate(Mathf.InverseLerp(0f, animationTime, timer));
			yield return null;
		}
		target.localScale = Vector3.one;
	}
}
