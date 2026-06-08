using System;
using UnityEngine;

public abstract class Transition : MonoBehaviour, IAsciiObject
{
	public enum State
	{
		Disabled = 0,
		Out = 1,
		Blank = 2,
		In = 3
	}

	public int ticDuration = 10;

	private State currentState;

	private int firePending;

	public State CurrentState => currentState;

	public int stateElapsedTics { get; private set; }

	public event Action<Transition> OnTransitionComplete;

	public virtual float GetPercent()
	{
		if (ticDuration <= 0)
		{
			return 1f;
		}
		return Mathf.Clamp01((float)stateElapsedTics / (float)ticDuration);
	}

	public virtual void SetState(State newState)
	{
		currentState = newState;
		stateElapsedTics = 0;
	}

	public virtual void FadeIn()
	{
		SetState(State.In);
	}

	public virtual void FadeOut()
	{
		SetState(State.Out);
	}

	public virtual void UpdateTic()
	{
		if (firePending > 0 && --firePending <= 0)
		{
			FireTransitionComplete();
		}
		stateElapsedTics++;
		if ((currentState == State.In || currentState == State.Out) && stateElapsedTics > ticDuration)
		{
			firePending = 2;
			if (currentState == State.Out)
			{
				SetState(State.Blank);
			}
			else
			{
				SetState(State.Disabled);
			}
		}
	}

	protected virtual void FireTransitionComplete()
	{
		if (this.OnTransitionComplete != null)
		{
			this.OnTransitionComplete(this);
		}
	}

	public abstract void Draw(AsciiRenderProcedural r, int offsetX, int offsetY);
}
