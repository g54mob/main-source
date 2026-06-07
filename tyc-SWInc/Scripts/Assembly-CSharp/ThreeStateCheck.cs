using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ThreeStateCheck : MonoBehaviour
{
	public enum State
	{
		Off = 0,
		Unknown = 1,
		On = 2
	}

	public Image Check;

	public Sprite On;

	public Sprite Unknown;

	[SerializeField]
	private State _currentState;

	public UnityEvent OnStateChange;

	public bool AllowUnknown = true;

	public State CurrentState
	{
		get
		{
			return _currentState;
		}
		set
		{
			_currentState = value;
			UpdateGraphic();
			OnStateChange.Invoke();
		}
	}

	public bool ForceState
	{
		get
		{
			return CurrentState == State.On;
		}
		set
		{
			CurrentState = (value ? State.On : State.Off);
		}
	}

	public bool interactable
	{
		get
		{
			return GetComponent<Button>().interactable;
		}
		set
		{
			GetComponent<Button>().interactable = value;
		}
	}

	private void Start()
	{
		UpdateGraphic();
	}

	public void UpdateGraphic()
	{
		switch (CurrentState)
		{
		case State.On:
			Check.gameObject.SetActive(true);
			Check.sprite = On;
			break;
		case State.Off:
			Check.gameObject.SetActive(false);
			break;
		case State.Unknown:
			Check.gameObject.SetActive(true);
			Check.sprite = Unknown;
			break;
		}
	}

	public void ChangeState()
	{
		if (AllowUnknown)
		{
			CurrentState = (State)((int)(CurrentState + 1) % 3);
		}
		else
		{
			switch (CurrentState)
			{
			case State.Off:
				CurrentState = State.On;
				break;
			case State.Unknown:
				CurrentState = State.On;
				break;
			case State.On:
				CurrentState = State.Off;
				break;
			}
		}
		UpdateGraphic();
	}

	public static State GetState<T>(IList<T> l, Func<T, bool> conv)
	{
		if (l == null || l.Count == 0)
		{
			return State.Unknown;
		}
		bool flag = false;
		bool flag2 = conv(l[0]);
		for (int i = 1; i < l.Count; i++)
		{
			if (conv(l[i]) != flag2)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			if (!flag2)
			{
				return State.Off;
			}
			return State.On;
		}
		return State.Unknown;
	}
}
