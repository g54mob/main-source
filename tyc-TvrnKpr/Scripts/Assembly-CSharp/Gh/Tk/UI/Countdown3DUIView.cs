using UnityEngine;
using UnityEngine.UI;

namespace Gh.Tk.UI
{
	public class Countdown3DUIView : MonoBehaviour
	{
		public Image meterFront;

		public Image meterBack;

		public Gradient gradientFront;

		public Gradient gradientBack;

		public Transform needle;

		public IconAnimation iconAnimation;

		private float _currentPercentage;

		public static float ConvertToCoyoteTimePercentage(float time)
		{
			return 0f;
		}

		public float GetCurrentPercentage()
		{
			return 0f;
		}

		public void SetPercentage(float percentage, bool useCoyoteTime = false)
		{
		}
	}
}
