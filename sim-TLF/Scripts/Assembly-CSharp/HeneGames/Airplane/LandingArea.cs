using UnityEngine;

namespace HeneGames.Airplane
{
	public class LandingArea : MonoBehaviour
	{
		[SerializeField]
		private Runway runway;

		private void OnTriggerEnter(Collider other)
		{
			if (other.transform.TryGetComponent<SimpleAirPlaneCollider>(out var component))
			{
				Vector3 normalized = (base.transform.position - component.transform.position).normalized;
				if (Vector3.Dot(base.transform.forward, normalized) > 0.5f)
				{
					SimpleAirPlaneController controller = component.controller;
					runway.landingAdjuster.position = controller.transform.position;
					runway.AddAirplane(controller);
					controller.airplaneState = SimpleAirPlaneController.AirplaneState.Landing;
					controller.AddLandingRunway(runway);
				}
			}
		}
	}
}
