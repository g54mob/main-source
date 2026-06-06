using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class VitalCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private VitalType _vital;

		[SerializeField]
		[Tooltip("The condition is met when the value of the vital is higher than the threshold.")]
		private float _threshold;

		[SerializeField]
		[Min(1f)]
		[Tooltip("The number of drifters that must be over the threshold.")]
		private int _drifterCount = 1;

		public bool IsMet()
		{
			int num = 0;
			foreach (Agent agent in Community.PlayerCommunity.Agents)
			{
				if (_threshold < GetVital(agent))
				{
					num++;
				}
			}
			return _drifterCount <= num;
		}

		private float GetVital(Agent agent)
		{
			switch (_vital)
			{
			case VitalType.Hunger:
				return agent.Vitals.Hunger.Amount;
			case VitalType.Thirst:
				return agent.Vitals.Thirst.Amount;
			case VitalType.Pollution:
				return agent.Vitals.Pollution.Level;
			default:
				Debug.LogException(new NotImplementedException($"No implementation for VitalType.{_vital}"));
				return 0f;
			}
		}
	}
}
