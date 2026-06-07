using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FadeInAndOut : MonoBehaviour
{
	private Animator animator;

	public event Action OnFadeInHalfCompletedEvent;

	public event Action OnFadeInCompletedEvent;

	public event Action OnFadeOutHalfCompletedEvent;

	public event Action OnFadeOutCompletedEvent;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void FadeInToBlack()
	{
		animator.Play("FadeIn");
	}

	public void FadeOutFromBlack()
	{
		animator.Play("FadeOut");
	}

	public void OnFadeInHalfCompletedHandler()
	{
		if (this.OnFadeInHalfCompletedEvent != null)
		{
			this.OnFadeInHalfCompletedEvent();
		}
	}

	public void OnFadeInCompletedHandler()
	{
		if (this.OnFadeInCompletedEvent != null)
		{
			this.OnFadeInCompletedEvent();
		}
	}

	public void OnFadeOutHalfCompletedHandler()
	{
		if (this.OnFadeOutHalfCompletedEvent != null)
		{
			this.OnFadeOutHalfCompletedEvent();
		}
	}

	public void OnFadeOutCompletedHandler()
	{
		if (this.OnFadeOutCompletedEvent != null)
		{
			this.OnFadeOutCompletedEvent();
		}
	}
}
