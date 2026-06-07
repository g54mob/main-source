using System;
using GameCreator.Runtime.Characters.Animim;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public struct ConfigState : IConfig
	{
		[SerializeField]
		private float m_DelayIn;

		[SerializeField]
		private float m_Duration;

		[SerializeField]
		private float m_Speed;

		[SerializeField]
		private float m_Weight;

		[SerializeField]
		private bool m_RootMotion;

		[SerializeField]
		private float m_TransitionIn;

		[SerializeField]
		private float m_TransitionOut;

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
				return m_Weight;
			}
			set
			{
				m_Weight = value;
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
				return m_TransitionIn;
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
				return m_TransitionOut;
			}
			set
			{
				m_TransitionOut = value;
			}
		}

		public ConfigState(float delayIn, float speed, float weight, float transitionIn, float transitionOut)
		{
			m_DelayIn = delayIn;
			m_Duration = 0f;
			m_Speed = speed;
			m_Weight = weight;
			m_RootMotion = false;
			m_TransitionIn = transitionIn;
			m_TransitionOut = transitionOut;
		}
	}
}
