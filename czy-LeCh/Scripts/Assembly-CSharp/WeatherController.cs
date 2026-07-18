using UnityEngine;

public class WeatherController : MonoBehaviour
{
	[SerializeField]
	private RainfallController rainController;

	[SerializeField]
	private SnowController snowController;

	private void Start()
	{
		if (Random.Range(0, 100) < 10)
		{
			if (Random.Range(0, 10) < 2)
			{
				snowController.StartSnow();
			}
			else
			{
				rainController.StartRain();
			}
		}
	}
}
