using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.Utilities
{
	[AddComponentMenu("JU TPS/UI/FPS Counter")]
	public class FPSCounter : MonoBehaviour
	{
		[SerializeField]
		private Text FPSText;

		public float RefreshRate;

		private void Start()
		{
			InvokeRepeating("UpdateFrameRateOnScreen", 0f, RefreshRate);
			if (FPSText == null && GetComponent<Text>() != null)
			{
				FPSText = GetComponent<Text>();
			}
		}

		public void UpdateFrameRateOnScreen()
		{
			if (FPSText != null)
			{
				FPSText.text = GetFrameRate() + "FPS";
				FPSText.color = Color.Lerp(Color.red, Color.green, (float)GetFrameRate() / 60f);
			}
		}

		public static int GetFrameRate()
		{
			return (int)(1f / Time.unscaledDeltaTime);
		}
	}
}
