using UnityEngine;

namespace RootMotion.Demos
{
	public class SlowMo : MonoBehaviour
	{
		public KeyCode[] keyCodes;

		public bool mouse0;

		public bool mouse1;

		public float slowMoTimeScale;

		private void Update()
		{
		}

		private bool IsSlowMotion()
		{
			return false;
		}
	}
}
