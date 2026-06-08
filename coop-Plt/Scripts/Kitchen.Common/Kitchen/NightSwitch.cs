using UnityEngine;

namespace Kitchen
{
	public class NightSwitch : MonoBehaviour
	{
		public GameObject Day;

		public GameObject Night;

		private static readonly int Fade = Shader.PropertyToID("_NightFade");

		private bool IsNight;

		private bool IsUpdated;

		private void Update()
		{
			bool flag = Shader.GetGlobalFloat(Fade) > 0.8f;
			if (!IsUpdated || IsNight != flag)
			{
				IsUpdated = true;
				SetNight(flag);
				IsNight = flag;
			}
		}

		public void SetNight(bool is_night)
		{
			if (Day != null)
			{
				Day.SetActive(!is_night);
			}
			if (Night != null)
			{
				Night.SetActive(is_night);
			}
		}
	}
}
