using UnityEngine;

namespace Rewired.Demos.CustomPlatform
{
	public class VibrationTest : MonoBehaviour
	{
		public int playerId;

		public float vibrationIncrement;

		private float[] motors;

		private static readonly string[] action_motors;

		private static readonly string action_stop;

		private Player player => null;

		private void Update()
		{
		}

		private void StopVibration()
		{
		}

		private void SetVibration(int motorIndex, float value)
		{
		}
	}
}
