using UnityEngine;

namespace Brewery.Employee
{
	[CreateAssetMenu(fileName = "Employee", menuName = "Brewery/Employee Profile", order = 0)]
	public class EmployeeScriptableObject : ScriptableObject
	{
		[Header("Employee Info")]
		[Tooltip("Display name for this employee")]
		public string employeeName;

		[Header("Costs")]
		[Tooltip("One-time fee to hire this employee")]
		public float hireCost;

		[Header("Schedule-Based Salary Rates")]
		[Tooltip("Daily salary for morning shift (08:00-16:00)")]
		public float morningSalary;

		[Tooltip("Daily salary for evening shift (16:00-00:00)")]
		public float eveningSalary;

		[Tooltip("Daily salary for night shift (00:00-08:00) - typically higher as premium")]
		public float nightSalary;

		[Header("Employee Performance Stats")]
		[Tooltip("Movement speed for A* motor (1 = 1 star, 5 = 5 stars)")]
		[Range(1f, 5f)]
		public float movementSpeed;

		[Tooltip("Time to serve one customer in seconds (5s = 1 star, 1s = 5 stars)")]
		[Range(1f, 5f)]
		public float servingTime;

		[Header("Scene References")]
		[Tooltip("Home spawn point ID (must match an EmployeeHomePoint component in the scene)")]
		public string homeId;

		[Header("NPC Prefab")]
		[Tooltip("Employee NPC prefab to spawn (must have EmployeeNPCController component)")]
		public GameObject employeeNPCPrefab;

		public float GetSalaryForSchedule(int shiftStartHour)
		{
			return 0f;
		}

		public int GetSpeedStars()
		{
			return 0;
		}

		public int GetServingStars()
		{
			return 0;
		}

		private void OnValidate()
		{
		}
	}
}
