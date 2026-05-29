using UnityEngine;

[CreateAssetMenu(fileName = "New Expenses Settings", menuName = "Scriptable Objects/Expenses Settings")]
public class ExpensesSO : ScriptableObject
{
	public float IndoorLightExpensePerSecond;

	public float SmallFridgeExpensePerSecond;

	public float LargeFridgeExpensePerSecond;

	public float SmallFreezerExpensePerSecond;

	public float MediumFreezerExpensePerSecond;

	public float LargeFreezerExpensePerSecond;

	public float SpeakerExpensePerSecond;

	public float SecurityExpensePerSecond;

	public float CheckoutExpensePerSecond;

	public float SelfCheckoutExpensePerSecond;

	public float OvenExpensePerSecond;

	[Space]
	public float DefaultDailyRent;

	[Space]
	public int BillPaymentDueDate;
}
