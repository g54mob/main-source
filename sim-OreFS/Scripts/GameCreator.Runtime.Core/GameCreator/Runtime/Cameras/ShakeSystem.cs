using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	internal class ShakeSystem
	{
		private float m_TransitionIn;

		private float m_TransitionOut;

		private ShakeEffect m_ShakeEffect;

		private float m_CurrentWeight;

		private float m_TargetWeight;

		private float m_HoldTransitionInUntil;

		private float m_HoldTransitionOutUntil;

		public int Layer { get; }

		public bool IsComplete { get; private set; }

		public Vector3 ValuePosition => m_ShakeEffect.Value * WeightPosition;

		public Vector3 ValueRotation => m_ShakeEffect.Value * WeightRotation;

		private float WeightPosition => m_CurrentWeight * m_ShakeEffect.PositionWeight;

		private float WeightRotation => m_CurrentWeight * m_ShakeEffect.RotationWeight;

		private ShakeSystem(int layer, float delay, float transition, float duration, ShakeEffect shakeEffect)
		{
			Layer = layer;
			IsComplete = false;
			m_TransitionIn = transition;
			m_TransitionOut = duration;
			m_ShakeEffect = shakeEffect;
			m_HoldTransitionInUntil = Time.time + delay;
			m_CurrentWeight = ((transition == 0f) ? 1f : 0f);
			m_TargetWeight = ((duration <= 0f) ? 1f : 0f);
		}

		public static ShakeSystem Sustain(int layer, float delay, float transition, ShakeEffect shakeEffect)
		{
			return new ShakeSystem(layer, delay, transition, -1f, shakeEffect);
		}

		public static ShakeSystem Burst(float delay, float duration, ShakeEffect shakeEffect)
		{
			return new ShakeSystem(0, delay, 0f, duration, shakeEffect);
		}

		public void Stop(float delay, float transition)
		{
			m_HoldTransitionOutUntil = Time.time + delay;
			m_TransitionOut = transition;
			m_TargetWeight = 0f;
		}

		public void Update(TCamera camera)
		{
			m_ShakeEffect.Update(camera);
			float num = m_TargetWeight;
			if (Time.time < m_HoldTransitionInUntil)
			{
				num = m_CurrentWeight;
			}
			if (Time.time < m_HoldTransitionOutUntil)
			{
				num = m_CurrentWeight;
			}
			float num2 = num - m_CurrentWeight;
			float num3 = (Mathf.Approximately(num2, 0f) ? 0f : Mathf.Sign(num2));
			float num4 = ((num3 > 0f) ? m_TransitionIn : m_TransitionOut);
			float num5 = Time.deltaTime * num3 / num4;
			m_CurrentWeight = Mathf.Clamp01(m_CurrentWeight + num5);
			if (m_TargetWeight == 0f && m_CurrentWeight == 0f)
			{
				IsComplete = true;
			}
		}
	}
}
