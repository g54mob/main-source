using TMPro;
using UnityEngine;

public class DayCycleCanvas : MonoBehaviour
{
	[SerializeField]
	private TMP_Text m_EndDayText;

	[SerializeField]
	private GameObject m_FinishTheDayIndicator;

	[SerializeField]
	private GameObject m_FinishTheDayIndicatorClient;

	public bool FinishTheDay
	{
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDisable()
	{
	}

	private void OnConnectedGamepad(bool isConnected)
	{
	}
}
