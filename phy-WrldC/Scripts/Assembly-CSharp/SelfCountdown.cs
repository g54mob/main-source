using UnityEngine;
using UnityEngine.Events;

public class SelfCountdown : MonoBehaviour
{
	public SDemoControl m_Control;

	public float time = 0.5f;

	public SDemoAnimation.LoopType loop = SDemoAnimation.LoopType.Loop;

	public bool destroyOnComplete;

	public bool executeAtStart = true;

	public UnityEvent onComplete;

	private void Start()
	{
		if (executeAtStart)
		{
			StartAnimation();
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

	private void OnDestroy()
	{
		if (m_Control != null)
		{
			m_Control.m_State = SDemoControl.State.Kill;
		}
	}

	public void StartAnimation()
	{
		m_Control = SDemoAnimation.Instance.Wait(time, OnComplete, loop);
	}
}
