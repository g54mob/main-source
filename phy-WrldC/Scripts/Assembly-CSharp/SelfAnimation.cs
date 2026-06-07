using UnityEngine;
using UnityEngine.Events;

public class SelfAnimation : MonoBehaviour
{
	public enum SelfAnimType
	{
		None = 0,
		Move = 1,
		Rotate = 2,
		Scale = 3,
		Move_RelativePosition = 4
	}

	public SDemoControl m_Control;

	public SelfAnimType m_SelfAnimType;

	public SDemoAnimation.LoopType loop;

	public Vector3 fromValue;

	public Vector3 toValue;

	public float time = 0.5f;

	public float delay;

	public float delay_Revert;

	public bool executeAtStart = true;

	public bool enableInitValue;

	public bool destroyOnComplete;

	public UnityEvent onComplete;

	private Vector3 _originPosition;

	private bool _isOdd;

	private void Awake()
	{
		_originPosition = base.transform.localPosition;
		if (executeAtStart)
		{
			StartAnimation();
		}
	}

	private void OnEnable()
	{
		if (m_Control != null)
		{
			m_Control.m_State = SDemoControl.State.Playing;
		}
	}

	private void OnDisable()
	{
		if (m_Control != null)
		{
			m_Control.m_State = SDemoControl.State.Paused;
		}
	}

	private void OnComplete()
	{
		if (onComplete != null)
		{
			onComplete.Invoke();
		}
		if (destroyOnComplete)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void OnDestroy()
	{
		if (m_Control != null)
		{
			m_Control.m_State = SDemoControl.State.Kill;
		}
	}

	public void SwitchAnimation()
	{
		_isOdd = !_isOdd;
		if (_isOdd)
		{
			StartAnimation(delay);
		}
		else
		{
			StartAnimationRevert(delay_Revert);
		}
	}

	public void SwitchAnimationRevert()
	{
		_isOdd = !_isOdd;
		if (!_isOdd)
		{
			StartAnimation(delay);
		}
		else
		{
			StartAnimationRevert(delay_Revert);
		}
	}

	public void StartAnimation(float inDelay = 0f)
	{
		if (m_Control != null)
		{
			m_Control.m_State = SDemoControl.State.Kill;
		}
		switch (m_SelfAnimType)
		{
		case SelfAnimType.Move:
			if (enableInitValue)
			{
				base.gameObject.transform.localPosition = fromValue;
			}
			m_Control = SDemoAnimation.Instance.Move(base.gameObject, fromValue, toValue, time, delay, loop, OnComplete);
			break;
		case SelfAnimType.Rotate:
			if (enableInitValue)
			{
				base.gameObject.transform.localEulerAngles = fromValue;
			}
			m_Control = SDemoAnimation.Instance.Rotate(base.gameObject, fromValue, toValue, time, delay, loop, OnComplete);
			break;
		case SelfAnimType.Scale:
			if (enableInitValue)
			{
				base.gameObject.transform.localScale = fromValue;
			}
			m_Control = SDemoAnimation.Instance.Scale(base.gameObject, fromValue, toValue, time, delay, loop, OnComplete);
			break;
		case SelfAnimType.Move_RelativePosition:
			if (enableInitValue)
			{
				base.gameObject.transform.localPosition = _originPosition + fromValue;
			}
			m_Control = SDemoAnimation.Instance.Move(base.gameObject, _originPosition + fromValue, _originPosition + toValue, time, delay, loop, OnComplete);
			break;
		}
	}

	public void StartAnimationRevert(float inDelay = 0f)
	{
		if (m_Control != null)
		{
			m_Control.m_State = SDemoControl.State.Kill;
		}
		switch (m_SelfAnimType)
		{
		case SelfAnimType.Move:
			if (enableInitValue)
			{
				base.gameObject.transform.localPosition = toValue;
			}
			m_Control = SDemoAnimation.Instance.Move(base.gameObject, toValue, fromValue, time, inDelay, loop, OnComplete);
			break;
		case SelfAnimType.Rotate:
			if (enableInitValue)
			{
				base.gameObject.transform.localEulerAngles = toValue;
			}
			m_Control = SDemoAnimation.Instance.Rotate(base.gameObject, toValue, fromValue, time, inDelay, loop, OnComplete);
			break;
		case SelfAnimType.Scale:
			if (enableInitValue)
			{
				base.gameObject.transform.localScale = toValue;
			}
			m_Control = SDemoAnimation.Instance.Scale(base.gameObject, toValue, fromValue, time, inDelay, loop, OnComplete);
			break;
		case SelfAnimType.Move_RelativePosition:
			if (enableInitValue)
			{
				base.gameObject.transform.localPosition = _originPosition + toValue;
			}
			m_Control = SDemoAnimation.Instance.Move(base.gameObject, _originPosition + toValue, _originPosition + fromValue, time, inDelay, loop, OnComplete);
			break;
		}
	}
}
