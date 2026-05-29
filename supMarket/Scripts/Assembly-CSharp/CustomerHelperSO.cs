using UnityEngine;

[CreateAssetMenu(fileName = "CustomerHelper", menuName = "Scriptable Objects/Employees/CustomerHelper")]
public class CustomerHelperSO : ScriptableObject
{
	public int ID;

	public string CustomerHelperName;

	public float DailyWage;

	public float HiringCost;

	public int SelfCheckoutCountToUnlock;

	public int RequiredStoreLevel;

	public CustomerHelper CustomerHelperPrefab;
}
