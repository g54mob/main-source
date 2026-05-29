using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Kill Vampire")]
	public class AutonomousActionKillVampire : AgentAutonomousAction<AgentActionShootAgent>
	{
		[SerializeField]
		private int _score;

		private static Func<Worker, bool> WorkerIsAvailable = (Worker obj) => IsVisibleAndNotTargeted(obj) && obj.IsAlive;

		public static Func<IVisibleBBTObject, bool> IsVisibleAndNotTargeted { get; } = (IVisibleBBTObject obj) => !obj.Transform.HasTag(BBTAgentTags.HunterTarget) && obj.IsVisible;

		protected override AgentActionShootAgent CreateActionInstance(Agent agent)
		{
			return new AgentActionShootAgent(null);
		}

		protected override int CalculateScore(Agent agent, AgentActionShootAgent shootAction)
		{
			if (agent.Cooldowns.IsOnCooldown(BBTAgentTags.ShotSomeone))
			{
				return -1;
			}
			if (!agent.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			Customer outBest;
			float outBestDistance;
			bool flag = Collections<Customer>.Filter(CustomerManager.GetAllAvailableVampires(), IsVisibleAndNotTargeted).TryGetNearest<ReadOnlyHashSet<Customer>, Customer>(agent.RoomObject, out outBest, out outBestDistance);
			bool flag2 = false;
			Worker outBest2 = null;
			float outBestDistance2 = 0f;
			if (CTSSingleton<HunterRaid>.Instance.CanKillWorkers)
			{
				flag2 = Collections<Worker>.Filter(WorkerList.All, WorkerIsAvailable).TryGetNearest<ReadOnlyHashSet<Worker>, Worker>(agent.RoomObject, out outBest2, out outBestDistance2);
			}
			if (!flag && !flag2)
			{
				return -1;
			}
			if (flag)
			{
				if (flag2)
				{
					shootAction.Target = ((outBestDistance2 < outBestDistance) ? ((Agent)outBest2) : ((Agent)outBest));
				}
				else
				{
					shootAction.Target = outBest;
				}
			}
			else
			{
				shootAction.Target = outBest2;
			}
			return _score;
		}
	}
}
