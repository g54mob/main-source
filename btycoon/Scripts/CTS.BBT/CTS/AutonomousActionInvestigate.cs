using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Investigate")]
	public class AutonomousActionInvestigate : AgentAutonomousAction<AgentActionInvestigate>
	{
		[SerializeField]
		private int _score = 2000;

		[SerializeField]
		private bool _canInvestigateVampires;

		private static readonly List<Crime> _crimeList = new List<Crime>();

		protected override AgentActionInvestigate CreateActionInstance(Agent agent)
		{
			return new AgentActionInvestigate();
		}

		protected override int CalculateScore(Agent agent, AgentActionInvestigate action)
		{
			if (agent.Cooldowns.IsOnCooldown(BBTAgentTags.Oblivious))
			{
				return -1;
			}
			if (!agent.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return -1;
			}
			if (!agent.HasTag(BBTAgentTags.Investigating) && CTSSingleton<LevelParameters>.Instance.IsOpen && agent.Cooldowns.IsOnCooldown(BBTAgentTags.Investigate))
			{
				return -1;
			}
			_crimeList.Clear();
			Crimes.Copy(_crimeList);
			_crimeList.Sort(MonoBehaviourDistanceComparer.Get(agent.transform.position, 3f));
			IVisible visible = null;
			foreach (Crime crime in _crimeList)
			{
				if (crime.CriminalAct == ECriminalActs.Machine)
				{
					visible = crime;
				}
			}
			if (!_canInvestigateVampires)
			{
				if (visible == null)
				{
					return -1;
				}
				action.Target = visible;
				return _score;
			}
			Customer outBest;
			float outBestDistance;
			IVisible visible2 = ((!BBTCollections<Customer>.TryGetNearest(agent.RoomObject, CustomerManager.GetAllAvailableVampires(), out outBest, out outBestDistance)) ? null : outBest);
			if (visible2 == null && visible == null)
			{
				return -1;
			}
			if (visible2 != null)
			{
				if (visible != null)
				{
					action.Target = ((Random.value > 0.6f) ? visible2 : visible);
				}
				else
				{
					action.Target = visible2;
				}
			}
			else
			{
				action.Target = visible;
			}
			return _score;
		}
	}
}
