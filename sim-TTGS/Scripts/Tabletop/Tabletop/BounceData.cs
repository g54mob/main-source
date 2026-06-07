using System;
using UnityEngine;

namespace Tabletop
{
	[Serializable]
	public struct BounceData
	{
		public float duration;

		private float m_time;

		public float power;

		public AnimationCurve customCurve;

		public bool Finished => m_time >= duration;

		public BounceData(float duration, float power, AnimationCurve customCurve)
		{
			this.duration = duration;
			this.power = power;
			m_time = 0f;
			this.customCurve = customCurve;
		}

		public BounceData(float duration, float power)
		{
			this.duration = duration;
			this.power = power;
			m_time = 0f;
			customCurve = null;
		}

		public void PlayBounceCall(Transform tr)
		{
			JuiceManager.AddBounce(tr, this);
		}

		public void GetManagerCurve()
		{
			customCurve = ShaderSettings.BounceAnimationCurve;
		}

		public float GetScale()
		{
			return customCurve.Evaluate(m_time / duration) * power;
		}

		public void AddTime(float t)
		{
			m_time += t;
		}
	}
}
