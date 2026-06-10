using TMPro;
using UnityEngine;

public class SalesLedgerEntryController : MonoBehaviour
{
	public RectTransform rect;

	public SalesLedgerContentController salesLedger;

	public Company.SalesRecord salesRecord;

	public TextMeshProUGUI descriptionText;

	public TextMeshProUGUI timeText;

	public TextMeshProUGUI nameText;

	public TextMeshProUGUI priceText;

	public void Setup(Company.SalesRecord newRecord, SalesLedgerContentController newSalesLedger)
	{
	}
}
