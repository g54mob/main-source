using UnityEngine;

namespace HeneGames.Airplane
{
	public class Runway : MonoBehaviour
	{
		private bool landingCompleted;

		private float landingSpeed;

		private SimpleAirPlaneController landingAirplaneController;

		private Vector3 landingAdjusterStartLocalPos;

		[Header("Input")]
		[SerializeField]
		private KeyCode launchKey = KeyCode.Space;

		[Header("Runway references")]
		public string runwayName = "Runway";

		[SerializeField]
		private LandingArea landingArea;

		public Transform landingAdjuster;

		[SerializeField]
		private Transform landingfinalPos;

		private void Start()
		{
			landingSpeed = 1f;
			landingAdjusterStartLocalPos = landingAdjuster.localPosition;
		}

		private void Update()
		{
			if (!(landingAirplaneController != null))
			{
				return;
			}
			landingAirplaneController.transform.SetParent(landingAdjuster.transform);
			if (!landingCompleted)
			{
				landingSpeed += Time.deltaTime;
				landingAdjuster.localPosition = Vector3.Lerp(landingAdjuster.localPosition, landingfinalPos.localPosition, landingSpeed * Time.deltaTime);
				if (Vector3.Distance(landingAdjuster.position, landingfinalPos.position) < 0.1f)
				{
					landingCompleted = true;
				}
				return;
			}
			landingAdjuster.localPosition = Vector3.Lerp(landingAdjuster.localPosition, landingfinalPos.localPosition, landingSpeed * Time.deltaTime);
			if (Input.GetKeyDown(launchKey))
			{
				landingAirplaneController.airplaneState = SimpleAirPlaneController.AirplaneState.Takeoff;
			}
			if (landingAirplaneController.airplaneState == SimpleAirPlaneController.AirplaneState.Flying)
			{
				landingAirplaneController.transform.SetParent(null);
				landingAirplaneController = null;
				landingCompleted = false;
				landingSpeed = 1f;
				landingAdjuster.localPosition = landingAdjusterStartLocalPos;
			}
		}

		public void AddAirplane(SimpleAirPlaneController _simpleAirPlane)
		{
			landingAirplaneController = _simpleAirPlane;
		}

		public bool AirplaneLandingCompleted()
		{
			if (landingAirplaneController != null && landingAirplaneController.airplaneState != SimpleAirPlaneController.AirplaneState.Takeoff)
			{
				return landingCompleted;
			}
			return false;
		}

		public bool AirplaneIsLanding()
		{
			if (landingAirplaneController != null && !landingCompleted)
			{
				return true;
			}
			return false;
		}

		public bool AriplaneIsTakingOff()
		{
			if (landingAirplaneController != null && landingAirplaneController.airplaneState == SimpleAirPlaneController.AirplaneState.Takeoff)
			{
				return true;
			}
			return false;
		}
	}
}
