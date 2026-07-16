using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ProgressionStatComponent : MonoBehaviour
{
	[SerializeField]
	private UIContentAnimator animator;

	[SerializeField]
	private TMP_Text labelValue;

	[SerializeField]
	private AnimationCurve curveValue;

	[SerializeField]
	private string prefix;

	[SerializeField]
	private string suffix;

	private bool isCounting;

	private float alpha;

	private int targetValue;

	private Action action;

	[SerializeField]
	private UnityEvent<int> OnValueChange = new UnityEvent<int>();

	public AnimationCurve GetAnimationCurve()
	{
		return curveValue;
	}

	public void Show(int value, Action updateAction = null)
	{
		animator.OnPlay();
		action = updateAction;
		CountUpTo(value);
	}

	public void Hide()
	{
		animator.BeginWithNormalState();
		isCounting = false;
		alpha = 0f;
	}

	public void HideAndReset()
	{
		animator.BeginWithNormalState();
		isCounting = false;
		targetValue = 0;
		alpha = 0f;
	}

	private void CountUpTo(int value)
	{
		isCounting = true;
		alpha = 0f;
		targetValue = value;
		OnValueChange.Invoke(0);
		labelValue.text = "0";
	}

	private void FixedUpdate()
	{
		if (isCounting)
		{
			if (alpha >= 1f)
			{
				alpha = 1f;
			}
			else
			{
				alpha += Time.deltaTime;
			}
			int arg = Mathf.RoundToInt(Mathf.Lerp(0f, targetValue, curveValue.Evaluate(alpha)));
			if (action != null)
			{
				action();
			}
			OnValueChange.Invoke(arg);
			labelValue.text = prefix + arg + suffix;
		}
	}
}
