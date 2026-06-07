using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelScene
{
	public class PirateAnimation : MonoBehaviour
	{
		public GameObject PirateFromLeft;

		public GameObject PirateFromRight;

		public GameObject PirateFlyAway;

		public void SetPirateShipState(string state)
		{
			switch (state)
			{
			case "FromLeft":
				PirateFromLeft.SetActive(true);
				PirateFromRight.SetActive(false);
				PirateFlyAway.SetActive(false);
				break;
			case "FromRight":
				PirateFromLeft.SetActive(false);
				PirateFromRight.SetActive(true);
				PirateFlyAway.SetActive(false);
				break;
			case "FromRightFlying":
				PirateFromLeft.SetActive(false);
				PirateFromRight.SetActive(false);
				PirateFlyAway.SetActive(true);
				break;
			default:
				Debug.Log("Did not find PirateShip state. Check string.");
				break;
			}
		}
	}
}
