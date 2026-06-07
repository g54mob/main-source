using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class RunwayLightsScript : MonoBehaviour
	{
		public GameObject HalosGameObject;

		public GameObject LightsGameObject;

		protected virtual void Start()
		{
			if (HalosGameObject != null)
			{
				HalosGameObject.SetActive(Game.Instance.Device.IsDesktopBuild);
			}
		}

		protected virtual void Update()
		{
			int num = (int)FlightSceneScript.Instance.Environment.TimeOfDay;
			bool flag = num < 6 || num > 18;
			if (LightsGameObject.activeInHierarchy != flag)
			{
				LightsGameObject.SetActive(flag);
			}
		}
	}
}
