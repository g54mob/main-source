namespace GameCreator.Runtime.Cameras
{
	internal class CameraShakeBurst : TCameraShake
	{
		public void AddBurst(float delay, float duration, ShakeEffect shakeEffect)
		{
			ShakeSystem item = ShakeSystem.Burst(delay, duration, shakeEffect);
			m_ShakeSystems.Add(item);
		}

		public void RemoveBursts(float delay, float transition)
		{
			foreach (ShakeSystem shakeSystem in m_ShakeSystems)
			{
				shakeSystem.Stop(delay, transition);
			}
		}
	}
}
