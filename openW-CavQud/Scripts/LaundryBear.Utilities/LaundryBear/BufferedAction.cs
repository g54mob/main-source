using System;
using System.Collections;
using UnityEngine;

namespace LaundryBear
{
	public class BufferedAction
	{
		private float m_bufferTime;

		private float m_bufferTimer;

		private Coroutine m_coroutine;

		public bool Buffered { get; private set; }

		public event Action ActionBufferedEvent;

		public event Action ActionUnbufferedEvent;

		public Coroutine Buffer(MonoBehaviour behaviour, float time)
		{
			if (m_coroutine == null)
			{
				m_bufferTime = time;
				m_coroutine = behaviour.StartCoroutine(JumpBufferCoroutine());
			}
			else
			{
				m_bufferTime = time;
				m_bufferTimer = 0f;
			}
			return m_coroutine;
		}

		public void Unbuffer(MonoBehaviour behaviour)
		{
			if (m_coroutine != null)
			{
				behaviour.StopCoroutine(m_coroutine);
				m_coroutine = null;
				if (this.ActionUnbufferedEvent != null)
				{
					this.ActionUnbufferedEvent();
				}
			}
			Buffered = false;
		}

		private IEnumerator JumpBufferCoroutine()
		{
			Buffered = true;
			if (this.ActionBufferedEvent != null)
			{
				this.ActionBufferedEvent();
			}
			while (m_bufferTimer < m_bufferTime)
			{
				m_bufferTimer = Mathf.Clamp(m_bufferTimer + Time.deltaTime, 0f, m_bufferTime);
				yield return null;
			}
			m_bufferTimer = 0f;
			Buffered = false;
			if (this.ActionUnbufferedEvent != null)
			{
				this.ActionUnbufferedEvent();
			}
			m_coroutine = null;
		}

		public static implicit operator bool(BufferedAction action)
		{
			return action.Buffered;
		}
	}
}
