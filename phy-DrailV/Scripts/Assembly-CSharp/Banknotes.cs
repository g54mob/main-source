using DV.Localization;
using DV.UIFramework;
using TMPro;
using UnityEngine;

public class Banknotes : Money
{
	[SerializeField]
	[NullCheck]
	private TextMeshPro moneyAmountText1;

	[NullCheck]
	[SerializeField]
	private TextMeshPro moneyAmountText2;

	protected override double DefaultAmount => 10.0;

	public override double Amount
	{
		get
		{
			return amount;
		}
		set
		{
			amount = value;
			moneyAmountText1.enabled = false;
			moneyAmountText2.enabled = false;
			moneyAmountText1.text = "$" + value.ToString("N2", LocalizationAPI.CC);
			moneyAmountText2.text = moneyAmountText1.text;
			moneyAmountText1.enabled = true;
			moneyAmountText2.enabled = true;
		}
	}
}
