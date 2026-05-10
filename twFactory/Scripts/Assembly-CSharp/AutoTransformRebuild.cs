using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoTransformRebuild : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Only applys the delay the first time")]
	private bool applyDelayOnce;

	[SerializeField]
	private int framesToDelay;

	[SerializeField]
	private bool updateAtEndOfFrame;

	[SerializeField]
	private bool onEnable = true;

	[SerializeField]
	private bool forceImmediateRebuild;

	[SerializeField]
	private RectTransform[] rectTransformsToRebuild;

	private bool delayApplied;

	private Coroutine rebuildCoroutine;

	private void Start()
	{
		if (!onEnable)
		{
			RebuildTransform();
		}
	}

	private void OnEnable()
	{
		if (onEnable)
		{
			RebuildTransform();
		}
	}

	public void RebuildTransform()
	{
		this.StartCoroutineCheckingVar(AutoRebuild(), ref rebuildCoroutine);
	}

	private IEnumerator AutoRebuild()
	{
		int delayedFrames = 0;
		if (!applyDelayOnce || !delayApplied)
		{
			delayApplied = true;
			while (delayedFrames < framesToDelay)
			{
				delayedFrames++;
				yield return null;
			}
		}
		if (updateAtEndOfFrame)
		{
			yield return new WaitForEndOfFrame();
		}
		RectTransform[] array = rectTransformsToRebuild;
		foreach (RectTransform rectTransform in array)
		{
			if (forceImmediateRebuild)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
			}
			else
			{
				LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
			}
		}
		rebuildCoroutine = null;
	}
}
