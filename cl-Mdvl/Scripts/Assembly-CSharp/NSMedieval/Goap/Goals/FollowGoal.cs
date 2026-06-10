using System.Collections.Generic;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class FollowGoal : Goal
	{
		private CreatureBase lastFollowedCreature;

		private MapNode lastFollowedCreatureStandingNode;

		public FollowGoal(Agent selfAgent)
			: base("FollowGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(StartCheck));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is CreatureBase;
		}

		public override bool CanStart(bool isForced = false)
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (creatureBase.IsOnFire)
			{
				return false;
			}
			CreatureBase followCreature = creatureBase.FollowCreature;
			if (CombatUtils.IsNullOrDisposed(followCreature))
			{
				return false;
			}
			if (lastFollowedCreature == followCreature && lastFollowedCreatureStandingNode == followCreature.GetNode())
			{
				return false;
			}
			if (Vector3.Distance(followCreature.GetPosition(), creatureBase.GetPosition()) < 5f)
			{
				return false;
			}
			return true;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			((CreatureBase)base.AgentOwner)?.SetFollowCreature(null);
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToCreatureTarget(TargetIndex.A, 5f).FailIfTargetDisposedOrNull(TargetIndex.A);
		}

		private bool StartCheck()
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			CreatureBase followCreature = creatureBase.FollowCreature;
			if (followCreature == null || followCreature.HasDisposed)
			{
				return false;
			}
			lastFollowedCreature = creatureBase.FollowCreature;
			lastFollowedCreatureStandingNode = creatureBase.FollowCreature.GetNode();
			SetTarget(TargetIndex.A, new TargetObject(creatureBase.FollowCreature));
			return true;
		}
	}
}
