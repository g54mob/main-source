using System.Linq;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Leave")]
	public class AutonomousActionLeave : AgentAutonomousAction
	{
		[SerializeField]
		private int _leaveNormal = 500;

		[SerializeField]
		private int _leaveAngry = 1000;

		[SerializeField]
		private int _leaveBarClosed = 600;

		[SerializeField]
		private int _lonelyScore = 10;

		[SerializeField]
		private int _wentInMachineScore = -1;

		private const int MaxProbability = 30;

		private DayCheck<Agent> _leaveDayCheck = new DayCheck<Agent>(GetAngryLeaveCondition);

		public static bool AutoLeaveWhenClosed { get; set; } = true;

		private static bool GetAngryLeaveCondition(Agent agent)
		{
			if (agent.Statistics.TryGetStatisticPercentage(EAgentStatistics.Satisfaction, out var statisticValue))
			{
				float num = Random.Range(0f, 100f);
				float num2 = Mathf.InverseLerp(0f, 30f, 30f - statisticValue) * 100f;
				return num <= num2;
			}
			return false;
		}

		public override int CalculateScore(Agent agent, AgentAction action1)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			if (agent.Tags.HasTag(EAgentTag.CannotLeave))
			{
				return -1;
			}
			if (customer.Business.IsLocked)
			{
				return -1;
			}
			if (customer.IsControlled)
			{
				return -1;
			}
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				if (customer.Tags.HasTag(EAgentTag.Hunter) && !customer.Cooldowns.IsOnCooldown(BBTAgentTags.StartedPanicking))
				{
					return _leaveAngry;
				}
				return -1;
			}
			if (customer.HasTag(BBTAgentTags.Investigating))
			{
				return -1;
			}
			if (customer.Cooldowns.IsOnCooldown(BBTAgentTags.Investigate))
			{
				return -1;
			}
			if (AutoLeaveWhenClosed && !CTSSingleton<LevelParameters>.Instance.IsOpen)
			{
				return _leaveBarClosed;
			}
			if (customer.Tags.HasTag(EAgentTag.Angry))
			{
				return _leaveAngry;
			}
			if (customer.CurrentDrinks >= customer.MaxDrinksBeforeLeaving)
			{
				return _leaveAngry;
			}
			if (!customer.CanGetDrink() && (customer.CurrentOrder == null || !customer.CurrentOrder.PreparedDrink.IsValid()))
			{
				return _leaveNormal;
			}
			if (!customer.AssignedSeat && customer.GroupData.Members.Any((Customer test) => test.AtTable))
			{
				return _lonelyScore;
			}
			if (_wentInMachineScore >= 0 && agent.Tags.HasTag(EAgentTag.WentInMachine))
			{
				return _wentInMachineScore;
			}
			if (!_leaveDayCheck.Check(agent))
			{
				return -1;
			}
			return _leaveAngry;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new AgentActionLeave();
		}
	}
}
