using System.Collections;
using UnityEngine;

public class UnitCommandRadiusAnimation : MonoBehaviour
{
	public AnimationCurve animationCurve;

	public AnimationCurve hideCurve;

	public float animationTime;

	public float hideTime = 0.25f;

	private bool active;

	public bool Active => active;

	private void Start()
	{
		if (!active)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void Activate()
	{
		active = true;
		StopAllCoroutines();
		base.gameObject.SetActive(value: true);
		StartCoroutine(AnimateShow());
	}

	public void Deactivate()
	{
		active = false;
		if (base.gameObject.activeSelf)
		{
			StopAllCoroutines();
			StartCoroutine(AnimateHide());
		}
	}

	private IEnumerator AnimateShow()
	{
		float timer = 0f;
		while (timer <= animationTime)
		{
			timer += Time.deltaTime;
			base.transform.localScale = Vector3.one * animationCurve.Evaluate(Mathf.InverseLerp(0f, animationTime, timer));
			yield return null;
		}
		base.transform.localScale = Vector3.one;
	}

	private IEnumerator AnimateHide()
	{
		float timer = 0f;
		while (timer <= hideTime)
		{
			timer += Time.deltaTime;
			base.transform.localScale = Vector3.one * hideCurve.Evaluate(Mathf.InverseLerp(0f, hideTime, timer));
			yield return null;
		}
		base.transform.localScale = Vector3.zero;
		base.gameObject.SetActive(value: false);
	}
}
