using UnityEngine;

namespace CurvedUI
{
	public class CUI_ViveHapticPulse : MonoBehaviour
	{
		private float PulseStrength;

		private void Start()
		{
			PulseStrength = 1f;
		}

		public void SetPulseStrength(float newStr)
		{
			PulseStrength = Mathf.Clamp(newStr, 0f, 1f);
		}

		public void TriggerPulse()
		{
		}
	}
}
