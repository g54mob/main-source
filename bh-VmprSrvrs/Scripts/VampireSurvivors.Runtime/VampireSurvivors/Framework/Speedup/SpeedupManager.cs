using Rewired;

namespace VampireSurvivors.Framework.Speedup
{
	public class SpeedupManager
	{
		private static SpeedupManager m_Instance;

		private float m_CurrentSpeedMultiplier;

		private float m_DefaultSpeedMultiplier;

		private float m_MaxSpeed;

		private float m_MinimumSpeed;

		private bool m_isSpeedupBlocked;

		private const float c_SpeedMultiplierSpeedupStep = 0.5f;

		private Player m_Player;

		public static SpeedupManager Instance => null;

		public float CurrentSpeedMultiplier => 0f;

		public bool IsSpeedupBlocked => false;

		public void Setup()
		{
		}

		private void SetupInputDelegates()
		{
		}

		private void RemoveInputDelegates()
		{
		}

		public float GetCurrentSpeedUpMultiplier()
		{
			return 0f;
		}

		public void ToggleSpeedup(InputActionEventData _)
		{
		}

		public void IncreaseSpeedup()
		{
		}

		public void IncreaseSpeedup(float increaseBy = 0.5f)
		{
		}

		public void ReduceSpeedup()
		{
		}

		public void ReduceSpeedup(float reduceBy = 0.5f)
		{
		}

		public void SetSpeedup(float speed)
		{
		}

		public void SetSpeedupDebug(float speed)
		{
		}

		public void SetSpeedupBlocked(bool isBlocked)
		{
		}

		public static void ClearSpeedupManager()
		{
		}
	}
}
