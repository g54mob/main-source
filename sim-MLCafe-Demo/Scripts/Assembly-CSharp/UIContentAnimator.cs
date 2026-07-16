using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIContentAnimator : MonoBehaviour
{
	public enum AnimatorState
	{
		BeginState = 0,
		TargetState = 1
	}

	[SerializeField]
	private RectTransform anchor;

	[SerializeField]
	private Image visualArea;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private UIFieldProperties normal;

	[SerializeField]
	private UIFieldProperties target;

	[SerializeField]
	[Range(0.01f, 6f)]
	private float fadeTime = 1f;

	[SerializeField]
	private AnimationCurve fadeCurve = new AnimationCurve();

	[SerializeField]
	public UnityEvent OnFinishedPlay = new UnityEvent();

	[SerializeField]
	public UnityEvent OnFinishedReverse = new UnityEvent();

	[SerializeField]
	private UIContentAnimator[] triggerOtherAnimators;

	private List<Coroutine> queue = new List<Coroutine>();

	private bool isPlaying;

	private bool isPlayingFullRound;

	public AnimatorState animatorState;

	private bool flipFlop;

	public float GetFadeTime()
	{
		return fadeTime;
	}

	public void SetFadeTime(float value)
	{
		fadeTime = value;
	}

	public Vector3 GetNormalPosition()
	{
		return normal.position;
	}

	public void SetNormalPosition(Vector3 position)
	{
		normal.usePosition = true;
		normal.position = position;
	}

	public Vector3 GetTargetPosition()
	{
		return target.position;
	}

	public void SetTargetPosition(Vector3 position)
	{
		target.usePosition = true;
		target.position = position;
	}

	public CanvasGroup GetCanvasGroup()
	{
		return canvasGroup;
	}

	private void Awake()
	{
	}

	private void Start()
	{
		BeginWithNormalState();
	}

	private void FinishPlay()
	{
		isPlaying = false;
		animatorState = AnimatorState.TargetState;
	}

	private void FinishReverse()
	{
		isPlaying = false;
		isPlayingFullRound = false;
		animatorState = AnimatorState.BeginState;
	}

	public bool ValidFromPlay()
	{
		if (isPlaying || animatorState == AnimatorState.TargetState)
		{
			return false;
		}
		return true;
	}

	public bool ValidFromReverse()
	{
		if (isPlaying || animatorState == AnimatorState.BeginState)
		{
			return false;
		}
		return true;
	}

	public bool IsPlaying()
	{
		return isPlaying;
	}

	public bool IsPlayingFullyTracked()
	{
		return isPlayingFullRound;
	}

	public void BeginWithNormalState()
	{
		UIAnimator.ApplyState(normal, anchor, fadeCurve, fadeTime, canvasGroup, visualArea);
		UIContentAnimator[] array = triggerOtherAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].BeginWithNormalState();
		}
		isPlayingFullRound = false;
		isPlaying = false;
		animatorState = AnimatorState.BeginState;
	}

	public void BeginWithTargetState()
	{
		UIAnimator.ApplyState(target, anchor, fadeCurve, fadeTime, canvasGroup, visualArea);
		UIContentAnimator[] array = triggerOtherAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].BeginWithTargetState();
		}
		isPlayingFullRound = false;
		isPlaying = false;
		animatorState = AnimatorState.TargetState;
	}

	public void OnPlayRuntime()
	{
		if (!isPlaying && animatorState != AnimatorState.TargetState)
		{
			OnPlay();
		}
	}

	public void OnReverseRuntime()
	{
		if (!isPlaying && animatorState != AnimatorState.BeginState)
		{
			OnReverse();
		}
	}

	public void OnPlay()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			UIAnimator.ApplyState(target, anchor, fadeCurve, fadeTime, canvasGroup, visualArea);
			animatorState = AnimatorState.TargetState;
			return;
		}
		UIAnimator.StopAllQuedRoutines(queue, this);
		Coroutine item = StartCoroutine(UIAnimator.AnimateContent(target, anchor, fadeCurve, fadeTime, canvasGroup, visualArea, null, OnFinishedPlay));
		queue.Add(item);
		UIContentAnimator[] array = triggerOtherAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnPlay();
		}
		TweenerManager.TweenTimeAction(base.name + "_ResetIsPlaying", fadeTime, FinishPlay);
		isPlaying = true;
		isPlayingFullRound = true;
		flipFlop = true;
		animatorState = AnimatorState.TargetState;
	}

	public void OnPlayWithoutNotify()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			UIAnimator.ApplyState(target, anchor, fadeCurve, fadeTime, canvasGroup, visualArea);
			animatorState = AnimatorState.TargetState;
			return;
		}
		UIAnimator.StopAllQuedRoutines(queue, this);
		Coroutine item = StartCoroutine(UIAnimator.AnimateContent(target, anchor, fadeCurve, fadeTime, canvasGroup, visualArea));
		queue.Add(item);
		UIContentAnimator[] array = triggerOtherAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnPlayWithoutNotify();
		}
		TweenerManager.TweenTimeAction(base.name + "_ResetIsPlaying", fadeTime, FinishPlay);
		isPlaying = true;
		isPlayingFullRound = true;
		flipFlop = true;
		animatorState = AnimatorState.TargetState;
	}

	public void OnReverse()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			UIAnimator.ApplyState(normal, anchor, fadeCurve, fadeTime, canvasGroup, visualArea);
			animatorState = AnimatorState.BeginState;
			return;
		}
		UIAnimator.StopAllQuedRoutines(queue, this);
		Coroutine item = StartCoroutine(UIAnimator.AnimateContent(normal, anchor, fadeCurve, fadeTime, canvasGroup, visualArea, null, OnFinishedReverse));
		queue.Add(item);
		UIContentAnimator[] array = triggerOtherAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnReverse();
		}
		TweenerManager.TweenTimeAction(base.name + "_ResetIsPlaying", fadeTime, FinishReverse);
		isPlaying = true;
		flipFlop = false;
		animatorState = AnimatorState.BeginState;
	}

	public void OnReverseWithoutNotify()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			UIAnimator.ApplyState(normal, anchor, fadeCurve, fadeTime, canvasGroup, visualArea);
			animatorState = AnimatorState.BeginState;
			return;
		}
		UIAnimator.StopAllQuedRoutines(queue, this);
		Coroutine item = StartCoroutine(UIAnimator.AnimateContent(normal, anchor, fadeCurve, fadeTime, canvasGroup, visualArea));
		queue.Add(item);
		UIContentAnimator[] array = triggerOtherAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnReverseWithoutNotify();
		}
		TweenerManager.TweenTimeAction(base.name + "_ResetIsPlaying", fadeTime, FinishReverse);
		isPlaying = true;
		flipFlop = false;
		animatorState = AnimatorState.BeginState;
	}

	public void OnPlay(UnityEvent customOnFinished)
	{
		UIAnimator.StopAllQuedRoutines(queue, this);
		Coroutine item = StartCoroutine(UIAnimator.AnimateContent(target, anchor, fadeCurve, fadeTime, canvasGroup, visualArea, null, customOnFinished));
		queue.Add(item);
		UIContentAnimator[] array = triggerOtherAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnPlay(customOnFinished);
		}
		TweenerManager.TweenTimeAction(base.name + "_ResetIsPlaying", fadeTime, FinishPlay);
		isPlaying = true;
		isPlayingFullRound = true;
		flipFlop = true;
		animatorState = AnimatorState.TargetState;
	}

	public void OnReverse(UnityEvent customOnFinished)
	{
		UIAnimator.StopAllQuedRoutines(queue, this);
		customOnFinished.AddListener(delegate
		{
			isPlayingFullRound = false;
		});
		Coroutine item = StartCoroutine(UIAnimator.AnimateContent(normal, anchor, fadeCurve, fadeTime, canvasGroup, visualArea, null, customOnFinished));
		queue.Add(item);
		UIContentAnimator[] array = triggerOtherAnimators;
		for (int num = 0; num < array.Length; num++)
		{
			array[num].OnReverse(customOnFinished);
		}
		TweenerManager.TweenTimeAction(base.name + "_ResetIsPlaying", fadeTime, FinishReverse);
		isPlaying = true;
		flipFlop = false;
		animatorState = AnimatorState.BeginState;
	}

	public void PlayFlipFlop()
	{
		flipFlop = !flipFlop;
		if (flipFlop)
		{
			OnPlay();
		}
		else
		{
			OnReverse();
		}
	}
}
