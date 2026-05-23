using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
	public float animationTime;

	public float initialDelay = 0.25f;

	public Transform animationTarget;

	public AnimationCurve animationCurve;

	public Cloth clothRenderer;

	private void OnEnable()
	{
		StopAllCoroutines();
		StartCoroutine(Play());
	}

	private IEnumerator Play()
	{
		animationTarget.localScale = Vector3.zero;
		clothRenderer.enabled = false;
		float clock = 0f;
		yield return new WaitForSeconds(initialDelay);
		while (clock <= animationTime)
		{
			clock += Time.deltaTime;
			animationTarget.localScale = Vector3.one * animationCurve.Evaluate(Mathf.InverseLerp(0f, animationTime, clock));
			yield return null;
		}
		animationTarget.localScale = Vector3.one;
		yield return new WaitForSeconds(0.1f);
		clothRenderer.enabled = true;
	}
}
