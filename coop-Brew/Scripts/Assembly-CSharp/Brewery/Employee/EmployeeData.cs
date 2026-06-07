using System;
using UnityEngine;

namespace Brewery.Employee
{
	[Serializable]
	public class EmployeeData
	{
		[Header("Employee Info")]
		public string employeeName;

		[Header("Costs")]
		public float hireCost;

		public float dailySalary;

		[Header("Scene References")]
		[Tooltip("Employee's home location (where they spawn and return when off-duty)")]
		public Transform homeLocation;

		[Header("NPC Prefab")]
		[Tooltip("Employee NPC prefab to spawn (must have EmployeeNPCController)")]
		public GameObject employeeNPCPrefab;
	}
}
