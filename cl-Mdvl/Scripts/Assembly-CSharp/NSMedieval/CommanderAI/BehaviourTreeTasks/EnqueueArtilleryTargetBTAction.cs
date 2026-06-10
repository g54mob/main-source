using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSMedieval.Goap;
using NodeCanvas.Framework;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	public class EnqueueArtilleryTargetBTAction : UnitsBTActionBase
	{
		public BBParameter<IDamageTakingAgent> targetToEnqueue;

		public BBParameter<List<IDamageTakingAgent>> artilleryTargets;

		protected override string info => $"Enqueue artillery target into {artilleryTargets}";

		protected override void OnStart()
		{
			artilleryTargets.value.Add(targetToEnqueue.value);
			Log.Debug("EnqueueArtilleryTargetBTAction SUCCESS", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\EnqueueArtilleryTargetBTAction.cs");
			EndAction(success: true);
		}
	}
}
