using UnityEngine;
using UnityEngine.UI;

public class HoldingInteractionIndicator : NoktaSingleton<HoldingInteractionIndicator>
{
	[SerializeField]
	private Image m_Indicator;

	[SerializeField]
	private CanvasGroup m_IndicatorCanvasGroup;

	[SerializeField]
	private float m_MinHoldingPercentageToShowIndicator;

	[SerializeField]
	private int m_PunchVibrato;

	[SerializeField]
	private float m_PunchElasticity;

	[SerializeField]
	private float m_PunchScale;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLocalPlayerUpdated(PlayerInstance _instance)
	{
	}

	public void OnStateChanged(bool started)
	{
	}

	public void OnHolding(float percentage)
	{
	}

	public void OnRepairHolding(float percentage)
	{
	}

	public void PunchIndicator(float interval)
	{
	}

	private void OnInteractionDisabled()
	{
	}
}
