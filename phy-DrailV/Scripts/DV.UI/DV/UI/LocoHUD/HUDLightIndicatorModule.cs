using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.LocoHUD
{
	public class HUDLightIndicatorModule : MonoBehaviour
	{
		public Image indicatorLight;

		public AudioClip alarmClip;

		public void SetIndicatorColor(Color color)
		{
			if ((bool)alarmClip && indicatorLight.color.a == 0f && color.a != 0f)
			{
				alarmClip.Play2D();
			}
			indicatorLight.color = color;
		}
	}
}
