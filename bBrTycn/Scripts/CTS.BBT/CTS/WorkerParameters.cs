using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "WorkerParameters", menuName = "Worker/WorkerParameters")]
	public class WorkerParameters : ScriptableObject
	{
		[field: Header("Gender spawn chance")]
		[field: SerializeField]
		[field: Range(0f, 5f)]
		public int MaleWeight { get; set; } = 5;

		[field: SerializeField]
		[field: Range(0f, 5f)]
		public int FemaleWeight { get; set; } = 5;

		[field: Header("Customer Visuals")]
		[field: SerializeField]
		public CharacterData CharacterData { get; private set; }

		[field: Header("Salary")]
		[field: SerializeField]
		[field: MinMaxSlider(100f, 20000f)]
		public Vector2Int SalaryCost { get; private set; } = new Vector2Int(1200, 1400);

		[field: SerializeField]
		public float PerLevelSalaryMultiplier { get; private set; } = 0.05f;

		[field: SerializeField]
		public float EngageCostMultiplier { get; private set; } = 1.5f;

		[field: Header("Passive Features")]
		[field: SerializeField]
		public WorkerPassives.EPassiveHabilities[] disponibleStatsHability { get; private set; }

		[field: SerializeField]
		public WorkerPassives.EPassiveHabilities[] disponibleUtilitaryHability { get; private set; }

		[field: Header("Power Features")]
		[field: SerializeField]
		public WorkerPowerFeature.e_PowerFeatures[] PowerFeatures { get; private set; }
	}
}
