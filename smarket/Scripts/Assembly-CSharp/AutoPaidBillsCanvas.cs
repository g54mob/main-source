using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class AutoPaidBillsCanvas : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup m_CanvasGroup;

	[SerializeField]
	private LocalizeStringEvent m_BillInfoLocalizedText;

	[SerializeField]
	private TMP_Text m_BillInfoText;

	[SerializeField]
	private ContentSizeFitter m_BillsContent;

	[SerializeField]
	private ContentSizeFitter m_Window;

	[Space]
	[SerializeField]
	private float m_FadeInDuration;

	[SerializeField]
	private float m_FadeOutDuration;

	[SerializeField]
	private float m_LifetimeDuration;

	[Space]
	[SerializeField]
	private Color m_NegativeTextColor;

	private List<LocalizeStringEvent> m_BillTexts;

	public void ShowAutoPaidBills(List<PlayerPaymentData> bills)
	{
	}

	private void RemoveExtraTexts()
	{
	}
}
