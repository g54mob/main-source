using UnityEngine;

public class StreetLights : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private int m_HourToTurningOnLights;

	[SerializeField]
	private bool m_AM;

	[SerializeField]
	private Vector2 m_RandomTimeBetweenLights;

	[Header("Lights")]
	[SerializeField]
	private GameObject m_StreetLights;

	private bool m_LightsOn;

	private Light[] m_Lights;

	private void Start()
	{
	}

	private void CheckTime()
	{
	}

	private void TurnOnLights()
	{
	}

	private void TurnOffLights()
	{
	}

	private void OnDayCycleDisabled()
	{
	}
}
