using UnityEngine;

namespace Brewery.Employee
{
	[CreateAssetMenu(fileName = "BreweryEmployee", menuName = "Brewery/Brewery Employee Profile")]
	public class BreweryEmployeeProfileSO : ScriptableObject
	{
		[Header("Identity")]
		public string displayName;

		public Sprite portrait;

		[Header("Costs")]
		public float hireCost;

		public float dailySalary;

		[Header("Performance")]
		[Range(1f, 5f)]
		[Tooltip("A* movement speed")]
		public float movementSpeed;

		[Range(0.5f, 2f)]
		[Tooltip("Multiplier on station processing wait time. Lower = faster. 1.0 = normal")]
		public float workEfficiency;

		[Header("Spawning")]
		[Tooltip("Home point ID matching a BreweryEmployeeHomePoint in the scene")]
		public string homeId;

		[Tooltip("NPC prefab with BreweryEmployeeNPCController")]
		public GameObject npcPrefab;

		public int GetSpeedStars()
		{
			return 0;
		}

		public int GetEfficiencyStars()
		{
			return 0;
		}
	}
}
