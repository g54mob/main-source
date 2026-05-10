using UnityEngine;

[CreateAssetMenu(fileName = "SecurityGuard", menuName = "Scriptable Objects/Employees/Security Guard")]
public class SecurityGuardSO : ScriptableObject
{
	public int ID;

	public float DailyWage;

	public float HiringCost;

	public int RequiredStoreLevel;

	public SecurityGuard SecurityGuardPrefab;
}
