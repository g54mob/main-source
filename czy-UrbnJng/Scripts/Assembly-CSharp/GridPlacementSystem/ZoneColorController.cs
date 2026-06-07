using UnityEngine;

namespace GridPlacementSystem
{
	public class ZoneColorController : MonoBehaviour
	{
		public GameObject BlueZone;

		public GameObject GreenZone;

		public GameObject YellowZone;

		public EnvironmentSunlight.Sunlight Sunlight;

		public EnvironmentHumidity.Humidity Humidity;

		public void TurnOnGreenLight()
		{
			GreenZone.gameObject.SetActive(value: true);
		}

		public void TurnOnBlueLight()
		{
			BlueZone.gameObject.SetActive(value: true);
		}

		public void TurnOnYellowLight()
		{
			YellowZone.gameObject.SetActive(value: true);
		}

		public void TurnOffLights()
		{
			BlueZone.gameObject.SetActive(value: false);
			GreenZone.gameObject.SetActive(value: false);
			YellowZone.gameObject.SetActive(value: false);
		}

		public void SetZoneTransform(Transform sourceTransform)
		{
			BlueZone.transform.position = sourceTransform.position;
			BlueZone.transform.rotation = sourceTransform.rotation;
			BlueZone.transform.localScale = sourceTransform.localScale;
			GreenZone.transform.position = sourceTransform.position;
			GreenZone.transform.rotation = sourceTransform.rotation;
			GreenZone.transform.localScale = sourceTransform.localScale;
			YellowZone.transform.position = sourceTransform.position;
			YellowZone.transform.rotation = sourceTransform.rotation;
			YellowZone.transform.localScale = sourceTransform.localScale;
		}
	}
}
