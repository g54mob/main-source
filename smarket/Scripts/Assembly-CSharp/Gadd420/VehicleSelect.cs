using UnityEngine;

namespace Gadd420
{
	public class VehicleSelect : MonoBehaviour
	{
		public GameObject motocross;

		public GameObject moped;

		public GameObject chopper;

		public GameObject bicycle;

		[Header("Chest or Hip is Ideal")]
		public Transform motocrossRiderCamFollowPos;

		public Transform mopedRiderCamFollowPos;

		public Transform chopperRiderCamFollowPos;

		public Transform bicycleRiderCamFollowPos;

		[Space]
		public ThirdPersonCamera cameraScript;

		public KeyBoardShortCuts shortCutScript;

		public GameObject canvas;

		public Speedometer speedo;

		public NitrousUI nitrousUI;

		public void SelectMotocross()
		{
		}

		public void SelectMoped()
		{
		}

		public void SelectChopper()
		{
		}

		public void SelectBicycle()
		{
		}
	}
}
