using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(Worker))]
	public class WorkerSalary : CTSBehaviour
	{
		[field: SerializeField]
		public WorkerSalaryData Data { get; private set; }

		[field: Inject(false)]
		public Worker Worker { get; }

		public int CurrentSalary
		{
			get
			{
				return Worker.Statistics.GetStatisticIntValue(EAgentStatistics.Salary);
			}
			set
			{
				Worker.Statistics.SetStatisticValue(EAgentStatistics.Salary, value);
			}
		}

		protected override void OnDisabled()
		{
			Worker.Level.LeveledUp -= LevelUpPromotion;
		}

		protected override void OnEnabled()
		{
			Worker.Level.LeveledUp += LevelUpPromotion;
		}

		public void SetupBaseSalary()
		{
			CurrentSalary = Mathf.FloorToInt(Data.BaseSalary * Data.BaseSalaryMultiplicatorRange.RandomInRange() * (Worker.Characteristics.IsSpecialized ? Data.SpecializedWorkerMultiplicator : 1f));
		}

		public void LevelUpPromotion()
		{
			CurrentSalary = Mathf.FloorToInt((float)CurrentSalary * Data.LevelUpMultiplicator);
		}
	}
}
