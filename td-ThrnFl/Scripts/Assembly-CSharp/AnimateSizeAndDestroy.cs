using System.Collections;
using UnityEngine;

public class AnimateSizeAndDestroy : MonoBehaviour
{
	public AnimationCurve animationCurve;

	public float duration = 1f;

	private Vector3 initialScale;

	private void Start()
	{
		initialScale = base.transform.localScale;
		StartCoroutine(AnimateScale());
	}

	private IEnumerator AnimateScale()
	{
		float time = 0f;
		while (time <= duration)
		{
			float num = animationCurve.Evaluate(time / duration);
			base.transform.localScale = initialScale * num;
			time += Time.deltaTime;
			yield return null;
		}
		Object.Destroy(base.gameObject);
	}
}
