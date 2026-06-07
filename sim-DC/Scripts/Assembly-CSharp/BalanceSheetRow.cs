using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BalanceSheetRow : MonoBehaviour
{
	[SerializeField]
	private Image imageCustomerLogo;

	[SerializeField]
	private TextMeshProUGUI txtCustomerName;

	[SerializeField]
	private TextMeshProUGUI txtRevenue;

	[SerializeField]
	private TextMeshProUGUI txtPenalties;

	[SerializeField]
	private TextMeshProUGUI txtTotal;

	[SerializeField]
	private Image imageBackground;

	[Header("Row Colors")]
	[SerializeField]
	private Color defaultColor;

	[SerializeField]
	private Color headerColor;

	[SerializeField]
	private Color salaryColor;

	[SerializeField]
	private Color totalColor;

	[SerializeField]
	private Color sectionTitleColor;

	public void SetData(string customerName, string revenue, string penalties, string total, Sprite customerLogo = null)
	{
	}

	public void SetAsHeader()
	{
	}

	public void SetAsSalaryRow(float salaryExpense)
	{
	}

	public void SetAsTotalRow(float revenue, float penalties, float total)
	{
	}

	public void SetAsSectionTitle(string title)
	{
	}

	private void SetBackgroundColor(Color color)
	{
	}
}
