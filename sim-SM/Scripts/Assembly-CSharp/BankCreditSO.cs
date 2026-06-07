using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
[CreateAssetMenu(fileName = "New Loan", menuName = "Scriptable Objects/Bank/Loan")]
public class BankCreditSO : ScriptableObject
{
	public int ID;

	public LocalizedString LocalizedName;

	public float Amount;

	public float DailyInterestPercent;

	public int RequiredPlayerLevel;

	public float DailyInterest => 0f;

	public string CreditName => null;

	public float ReturnPayment(int termLength)
	{
		return 0f;
	}

	public float DailyPayment(int termLength)
	{
		return 0f;
	}

	public float RemainingPayment(int termLength, int remainingPaymentNumber)
	{
		return 0f;
	}

	public float EarlyPayOffAmount(int termLength, int remainingPaymentNumber)
	{
		return 0f;
	}
}
