using System;
using UnityEngine;

public class UndeadCryptIntroSkull : MonoBehaviour
{
	[Serializable]
	public class AnimationPerExpression
	{
		public ScottyTheSkull.Expression expression;

		public AsciiAnimation animation;
	}

	public enum State
	{
		Asleep = 0,
		WakingUp = 1,
		Idle = 2,
		Talking = 3
	}

	public AsciiAnimation asleepAnm;

	public AsciiAnimation wakingUpAnm;

	public AsciiAnimation idleAnm;

	public AnimationPerExpression[] talkingAnimations;

	private State _currentState;

	private AsciiAnimation currentAnm;

	public State currentState => _currentState;

	public int LastDrawX
	{
		get
		{
			if (currentAnm != null)
			{
				return currentAnm.Sprite.lastDrawX;
			}
			return 0;
		}
	}

	public int LastDrawY
	{
		get
		{
			if (currentAnm != null)
			{
				return currentAnm.Sprite.lastDrawY;
			}
			return 0;
		}
	}

	public void SetState(State newState, ScottyTheSkull.Expression talkingExpression = ScottyTheSkull.Expression.Serious)
	{
		if (currentAnm != null)
		{
			currentAnm.gameObject.SetActive(value: false);
		}
		switch (newState)
		{
		case State.Asleep:
			currentAnm = asleepAnm;
			break;
		case State.WakingUp:
			currentAnm = wakingUpAnm;
			break;
		case State.Idle:
			currentAnm = idleAnm;
			break;
		case State.Talking:
		{
			for (int i = 0; i < talkingAnimations.Length; i++)
			{
				if (talkingAnimations[i].expression == talkingExpression)
				{
					currentAnm = talkingAnimations[i].animation;
					break;
				}
			}
			break;
		}
		}
		if (currentAnm == null)
		{
			currentAnm = idleAnm;
		}
		currentAnm.gameObject.SetActive(value: true);
		currentAnm.Play();
		_currentState = newState;
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentAnm != null)
		{
			currentAnm.Sprite.Draw(r, offsetX, offsetY);
		}
	}

	private void Awake()
	{
		InitAnm(asleepAnm);
		InitAnm(wakingUpAnm);
		InitAnm(idleAnm);
		for (int i = 0; i < talkingAnimations.Length; i++)
		{
			InitAnm(talkingAnimations[i].animation);
		}
	}

	private void InitAnm(AsciiAnimation anm)
	{
		if (anm != null)
		{
			anm.GetComponent<AsciiSprite>().Load();
			anm.gameObject.SetActive(value: false);
		}
	}
}
