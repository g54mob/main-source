using UnityEngine;
using UnityEngine.Localization;

public class EmployeeInteractionText : NoktaSingleton<EmployeeInteractionText>
{
	[SerializeField]
	private InGameTextIndicator m_BoostIndicator;

	[SerializeField]
	private Transform m_IndicatorPosition;

	[SerializeField]
	private LocalizedString m_LocalizeKey;

	public void ShowIndicator()
	{
	}
}
