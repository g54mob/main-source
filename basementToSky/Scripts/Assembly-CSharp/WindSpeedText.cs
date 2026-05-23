using TMPro;
using UnityEngine;

public class WindSpeedText : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI windSpeed;

	private void Start()
	{
	}

	private void Update()
	{
		float magnitude = GameManager.S.windManager.wind.magnitude;
		windSpeed.text = magnitude.ToString("F1") + " m/s";
	}
}
