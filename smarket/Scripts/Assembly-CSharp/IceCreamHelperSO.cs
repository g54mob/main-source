using UnityEngine;

[CreateAssetMenu(fileName = "IceCreamHelper", menuName = "Scriptable Objects/Employees/Ice Cream Helper")]
public class IceCreamHelperSO : ScriptableObject
{
	public int ID;

	public string Name;

	public float DailyWage;

	public float HiringCost;

	public int RequiredStoreLevel;

	public IceCreamHelper EmployeePrefab;
}
