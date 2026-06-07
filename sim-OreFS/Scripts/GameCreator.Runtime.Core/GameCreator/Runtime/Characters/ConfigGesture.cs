using System;
using GameCreator.Runtime.Characters.Animim;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public struct ConfigGesture : IConfig
	{
		[SerializeField]
		private float m_DelayIn;

		[SerializeField]
		private float m_Duration;

		[SerializeField]
		private float m_TransitionIn;

		[SerializeField]
		private float m_TransitionOut;

		[SerializeField]
		private float m_Speed;

		[SerializeField]
		private bool m_RootMotion;

		public float DelayIn
		{
			get
			{
				return m_DelayIn;
			}
			set
			{
				m_DelayIn = value;
			}
		}

		public float Duration
		{
			get
			{
				return m_Duration;
			}
			set
			{
				m_Duration = value;
			}
		}

		public float Speed
		{
			get
			{
				return m_Speed;
			}
			set
			{
				m_Speed = value;
			}
		}

		public float Weight
		{
			get
			{
				return 1f;
			}
			set
			{
			}
		}

		public bool RootMotion
		{
			get
			{
				return m_RootMotion;
			}
			set
			{
				m_RootMotion = value;
			}
		}

		public float TransitionIn
		{
			get
			{
				return Math.Min(m_Duration, m_TransitionIn);
			}
			set
			{
				m_TransitionIn = value;
			}
		}

		public float TransitionOut
		{
			get
			{
				return Math.Min(m_Duration, m_TransitionOut);
			}
			set
			{
				m_TransitionOut = value;
			}
		}

		public ConfigGesture(float delayIn, float duration, float speed, bool rootMotion, float transitionIn, float transitionOut)
		{
			m_DelayIn = delayIn;
			m_Duration = duration;
			m_Speed = speed;
			m_RootMotion = rootMotion;
			m_TransitionIn = transitionIn;
			m_TransitionOut = transitionOut;
		}
	}
}
