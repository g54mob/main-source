using UnityEngine;
using __Project__.Scripts.Janitor;

[CreateAssetMenu(fileName = "Janitor", menuName = "Scriptable Objects/Employees/Janitor")]
public class JanitorSO : ScriptableObject
{
	public int ID;

	public string JanitorName;

	public float DailyWage;

	public float HiringCost;

	public int RequiredStoreLevel;

	public Janitor JanitorPrefab;
}
