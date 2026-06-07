using System.Collections.Generic;

namespace GameCreator.Runtime.Cameras
{
	internal class CameraShakeSustain : TCameraShake
	{
		private readonly Dictionary<int, ShakeSystem> m_Shakes;

		public CameraShakeSustain()
		{
			m_Shakes = new Dictionary<int, ShakeSystem>();
		}

		protected override void OnComplete(ShakeSystem shakeSystem)
		{
			base.OnComplete(shakeSystem);
			m_Shakes.Remove(shakeSystem.Layer);
		}

		public void AddSustain(int layer, float delay, float transition, ShakeEffect shakeEffect)
		{
			if (m_Shakes.TryGetValue(layer, out var value))
			{
				m_Shakes.Remove(layer);
				m_ShakeSystems.Remove(value);
			}
			value = ShakeSystem.Sustain(layer, delay, transition, shakeEffect);
			m_Shakes.Add(layer, value);
			m_ShakeSystems.Add(value);
		}

		public void RemoveSustain(int layer, float delay, float transition)
		{
			if (m_Shakes.TryGetValue(layer, out var value))
			{
				value.Stop(delay, transition);
			}
		}
	}
}
