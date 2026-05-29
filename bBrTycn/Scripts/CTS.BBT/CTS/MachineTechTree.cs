using CTS.BBT.AI;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.TechTree;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class MachineTechTree : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		private MachineBase _machineBase;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[Range(0f, 200f)]
		private int _minimumWorkerIQ;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[Range(0f, 100f)]
		private int _baseProbality;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[Range(0f, 100f)]
		private int _maxProbality;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[MinMaxSlider(0f, 100f)]
		private Vector2 _failureRate;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[MinMaxSlider(0f, 250f)]
		private Vector2 _pointsToGenerate;

		[SerializeField]
		[BoxGroup("Upgrade Settings")]
		public TechTreeTechnologySO TechTreeTechnologyRequiered;

		[SerializeField]
		[BoxGroup("Debug View")]
		private bool _debugMode;

		private MachineUpgrade _machineUpgrade => _machineBase.MachineUpgrade;

		public void Start()
		{
			if ((bool)_machineBase.MachineUpgrade)
			{
				TechTreeManager.GetTechnologyMaxResearchLevel(TechTreeTechnologyRequiered);
				_ = _machineUpgrade.machinePriceToUpgrade.Count;
			}
		}

		public void TryToGenerateResearchPoints(Agent user, float workerIntelligence)
		{
			if (user is Worker worker && workerIntelligence > (float)_minimumWorkerIQ)
			{
				float num = 0f;
				float num2 = _failureRate.RandomInRange();
				int num3 = Mathf.RoundToInt(_pointsToGenerate.RandomInRange());
				num += workerIntelligence - (float)_minimumWorkerIQ;
				num += (float)_baseProbality;
				if (num > (float)_maxProbality)
				{
					num = _maxProbality;
				}
				if (num > num2 && CTSSingleton<TechTreePoints>.Instance.TryToAddPoints(num3))
				{
					worker.WorkerTechTreeBubble.DisplayBubble(Mathf.RoundToInt(num3));
				}
			}
		}
	}
}
