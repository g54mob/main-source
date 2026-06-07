using System.Collections;
using UnityEngine;

public class HighlightAnimation : MonoBehaviour, IHoverReaction
{
	[SerializeField]
	private float animationDuration = 0.25f;

	[SerializeField]
	private float scaleAmount = 0.125f;

	private Transform animationTransform;

	public float elapsedAnimationTime;

	private Coroutine animationCoro;

	private void Start()
	{
		HighlightTag component = GetComponent<HighlightTag>();
		if (component != null)
		{
			Renderer renderer = ((component.renderers.Count != 0) ? component.renderers[0] : null);
			if (renderer != null)
			{
				animationTransform = renderer.transform;
			}
		}
		if (animationTransform == null)
		{
			animationTransform = GetComponentInChildren<Renderer>().transform;
		}
	}

	private void OnDisable()
	{
		if (animationCoro != null)
		{
			StopCoroutine(animationCoro);
			animationCoro = null;
		}
		if (animationTransform != null)
		{
			animationTransform.localScale = Vector3.one;
		}
		elapsedAnimationTime = 0f;
	}

	public void OnHovered()
	{
		if (animationCoro != null)
		{
			StopCoroutine(animationCoro);
		}
		animationCoro = StartCoroutine(AnimateScale(scaleUp: true));
	}

	public void OnUnhovered()
	{
		if (animationCoro != null)
		{
			StopCoroutine(animationCoro);
		}
		animationCoro = StartCoroutine(AnimateScale(scaleUp: false));
	}

	private IEnumerator AnimateScale(bool scaleUp)
	{
		while (true)
		{
			if (scaleUp)
			{
				elapsedAnimationTime += Time.deltaTime;
			}
			else
			{
				elapsedAnimationTime -= Time.deltaTime;
			}
			elapsedAnimationTime = Mathf.Clamp(elapsedAnimationTime, 0f, animationDuration);
			float num = elapsedAnimationTime / animationDuration;
			float num2 = 1f + scaleAmount * num;
			animationTransform.localScale = new Vector3(num2, num2, num2);
			if (!(num > 0f) || !(num < 1f))
			{
				break;
			}
			yield return null;
		}
		animationCoro = null;
	}
}
