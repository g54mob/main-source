using System;
using UnityEngine;

public class TransitionManager : MonoBehaviour, IAsciiObject
{
	public enum Type
	{
		Fade = 0,
		WhiteToBlack = 1,
		SlowFadeToBlack = 2
	}

	public Transition fadeTransition;

	public Transition whiteToBlackTransition;

	public Transition slowFadeToBlackTransition;

	private Transition currentTransition;

	public Transition CurrentTransition => currentTransition;

	public event Action<Transition> OnTransitionComplete;

	private void Awake()
	{
		fadeTransition.OnTransitionComplete += HandleOnTransitionComplete;
	}

	private void OnDestroy()
	{
		fadeTransition.OnTransitionComplete -= HandleOnTransitionComplete;
	}

	public Transition GetTransition(Type transitionType)
	{
		return transitionType switch
		{
			Type.Fade => fadeTransition, 
			Type.WhiteToBlack => whiteToBlackTransition, 
			Type.SlowFadeToBlack => slowFadeToBlackTransition, 
			_ => null, 
		};
	}

	public Transition FadeIn(Type transitionType)
	{
		currentTransition = GetTransition(transitionType);
		currentTransition.FadeIn();
		return currentTransition;
	}

	public Transition FadeOut(Type transitionType)
	{
		currentTransition = GetTransition(transitionType);
		currentTransition.FadeOut();
		return currentTransition;
	}

	public Transition FadeIn()
	{
		if (currentTransition == null)
		{
			currentTransition = fadeTransition;
		}
		currentTransition.FadeIn();
		return currentTransition;
	}

	public Transition FadeOut()
	{
		if (currentTransition == null)
		{
			currentTransition = fadeTransition;
		}
		currentTransition.FadeOut();
		return currentTransition;
	}

	public void UpdateTic()
	{
		if (currentTransition != null && currentTransition.CurrentState != Transition.State.Disabled)
		{
			currentTransition.UpdateTic();
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentTransition != null && currentTransition.CurrentState != Transition.State.Disabled)
		{
			currentTransition.Draw(r, offsetX, offsetY);
		}
	}

	private void HandleOnTransitionComplete(Transition transition)
	{
		if (this.OnTransitionComplete != null)
		{
			this.OnTransitionComplete(transition);
		}
	}
}
