using UnityEngine;

[CreateAssetMenu(fileName = "Cashier", menuName = "Scriptable Objects/Employees/Cashier")]
public class CashierSO : ScriptableObject
{
	public int ID;

	public string CashierName;

	public float DailyWage;

	public float HiringCost;

	public int CheckoutGoalToUnlock;

	public int RequiredStoreLevel;

	public Cashier CashierPrefab;
}
