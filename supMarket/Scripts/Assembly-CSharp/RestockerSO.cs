using UnityEngine;

[CreateAssetMenu(fileName = "Restocker", menuName = "Scriptable Objects/Employees/Restocker")]
public class RestockerSO : ScriptableObject
{
	public int ID;

	public string RestockerName;

	public float DailyWage;

	public float HiringCost;

	public int RackGoalToUnlock;

	public int RequiredStoreLevel;

	public Restocker RestockerPrefab;
}
