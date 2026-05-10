using CTS.Core.Utilities;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Discuss")]
	public class AutonomousActionDiscuss : AgentAutonomousAction<AgentActionDiscuss>
	{
		[SerializeField]
		[CurveRange(0f, 0f, 1f, 1f, EColor.Clear)]
		private AnimationCurve _chanceBaseOnNeed = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		[SerializeField]
		private int _socializeScore;

		private DayCheck<Agent, AnimationCurve> _socializeDayCheck = new DayCheck<Agent, AnimationCurve>(SocializeCheck);

		private static bool SocializeCheck(Agent agent, AnimationCurve needCurve)
		{
			if (agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Social, out var statisticValue))
			{
				float value = Random.value;
				return needCurve.Evaluate(statisticValue) >= value;
			}
			return false;
		}

		private static Customer GetNearestWhenWaiting(Customer origin)
		{
			Vector3 position = origin.transform.position;
			Customer result = null;
			float num = float.MaxValue;
			Customer[] members = origin.GroupData.Members;
			foreach (Customer customer in members)
			{
				if (!(customer == origin) && !customer.Business.IsLocked && customer.Tags.HasTag(EAgentTag.IsInside) && customer.ContextualFSM.CurrentStateEquals<ContextualStateNormal>() && IsCustomerCorrect(customer, origin.RandomMovementMask))
				{
					float num2 = Vector3.SqrMagnitude((position - customer.transform.position).MulY(10f));
					if (num2 < num)
					{
						num = num2;
						result = customer;
					}
				}
			}
			return result;
		}

		private static Customer GetNearestWhenNotWaiting(Customer origin)
		{
			Vector3 position = origin.transform.position;
			Customer result = null;
			float num = float.MaxValue;
			foreach (Customer allAvailableCustomer in CustomerManager.GetAllAvailableCustomers())
			{
				if (allAvailableCustomer == origin || !allAvailableCustomer.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
				{
					continue;
				}
				if (allAvailableCustomer.GroupData != origin.GroupData)
				{
					CustomerOrder.EStatus? eStatus = allAvailableCustomer.CurrentOrder?.Status;
					if (eStatus.HasValue && eStatus.GetValueOrDefault() == CustomerOrder.EStatus.WaitingToOrder)
					{
						continue;
					}
				}
				if (IsCustomerCorrect(allAvailableCustomer, origin.RandomMovementMask))
				{
					float num2 = Vector3.SqrMagnitude((position - allAvailableCustomer.transform.position).MulY(10f));
					if (num2 < num)
					{
						num = num2;
						result = allAvailableCustomer;
					}
				}
			}
			return result;
		}

		private static bool IsCustomerCorrect(Customer customer, NavigationMask areaMask)
		{
			return IsCustomerCorrect(customer, (int)areaMask);
		}

		private static bool IsCustomerCorrect(Customer customer, int areaMask)
		{
			int count = customer.ActionPlayer.ActionQueue.Count;
			if (customer.AutonomousActions.Paused)
			{
				return false;
			}
			if (count > 0 && (count > 1 || !(customer.ActionPlayer.ActionQueue[0] is AgentActionMove)))
			{
				return false;
			}
			if ((bool)customer.ControllingVampire)
			{
				return false;
			}
			return (1 << customer.RoomObject.CurrentRoom.NavArea.Area).ExistsInMask(areaMask);
		}

		protected override AgentActionDiscuss CreateActionInstance(Agent agent)
		{
			return new AgentActionDiscuss(null, initiator: true);
		}

		protected override int CalculateScore(Agent agent, AgentActionDiscuss action)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			if (!_socializeDayCheck.Check(agent, _chanceBaseOnNeed))
			{
				return -1;
			}
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			Customer customer2 = (Customer)(action.OtherAgent = (((customer.CurrentOrder?.Status ?? CustomerOrder.EStatus.Ordered) != CustomerOrder.EStatus.WaitingToOrder) ? GetNearestWhenNotWaiting(customer) : GetNearestWhenWaiting(customer)));
			if ((object)customer2 == null)
			{
				return -1;
			}
			return _socializeScore;
		}
	}
}
