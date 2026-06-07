using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DailyStatisticsScreenAnimation : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup[] m_UIElements;

	[SerializeField]
	private float m_FadeInDurationPerElement;

	[SerializeField]
	private float m_IntervalBetweenElements;

	[SerializeField]
	private float m_FadeOutDurationOfTheScreen;

	[SerializeField]
	private Button m_StartNextDayButton;

	[SerializeField]
	private Image m_InstantOpener;

	[SerializeField]
	private DailyStatisticsScreen dailyStatisticsScreen;

	private bool m_IsAnimating;

	private Sequence sequence;

	public void Open()
	{
	}

	public void Close()
	{
	}

	public void InstantOpen()
	{
	}

	public void SwitchGamepadFunctionality(bool isOpen)
	{
	}
}
