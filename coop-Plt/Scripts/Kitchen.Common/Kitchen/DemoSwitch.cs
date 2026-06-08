using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class DemoSwitch : MonoBehaviour
	{
		public bool ShowOnDemo;

		public bool ShowOnNonDemo;

		public GameObject Target;

		private void Awake()
		{
			bool active = (PlatformSettings.IsDemoMode ? ShowOnDemo : ShowOnNonDemo);
			Target.SetActive(active);
		}
	}
}
