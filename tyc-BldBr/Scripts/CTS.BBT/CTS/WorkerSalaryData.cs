using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "WorkerSalaryData", menuName = "Worker/WorkerSalaryData")]
	public class WorkerSalaryData : ScriptableObject
	{
		[field: SerializeField]
		[field: Min(0f)]
		public float BaseSalary { get; private set; } = 150f;

		[field: SerializeField]
		[field: MinMaxSlider(0.1f, 2f)]
		public Vector2 BaseSalaryMultiplicatorRange { get; private set; } = new Vector2(0.95f, 1.05f);

		[field: SerializeField]
		public float SpecializedWorkerMultiplicator { get; private set; } = 1.2f;

		[field: SerializeField]
		public float HireMultiplicator { get; private set; } = 1.5f;

		[field: SerializeField]
		public float LevelUpMultiplicator { get; private set; } = 1.1f;
	}
}
