using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SumoLocation.Scripts
{
	public class DisplayDroneName : MonoBehaviour
	{
		public UILabel Label;

		public NimbatusDrone Drone;

		public void Update()
		{
			Label.text = Drone.DroneData.DroneName;
		}
	}
}
