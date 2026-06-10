using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Picks a random building for artillery to target")]
	public class EnqueueRandomArtilleryTargetBTAction : UnitsBTActionBase
	{
		public BBParameter<List<IDamageTakingAgent>> artilleryTargets;

		private List<BaseBuildingInstance> targets;

		protected override string info => $"Enqueue random artillery target into {artilleryTargets}";

		protected override void OnStart()
		{
			if (targets == null)
			{
				targets = new List<BaseBuildingInstance>();
			}
			targets.Clear();
			MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(FindTargetThread, delegate(bool result)
			{
				if (!result || targets.Count == 0)
				{
					Log.Debug("EnqueueRandomArtilleryTarget FAIL", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\EnqueueRandomArtilleryTargetBTAction.cs");
					EndAction(success: false);
				}
				else
				{
					bool isEnabled;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\EnqueueRandomArtilleryTargetBTAction.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("EnqueueRandomArtilleryTarget SUCCESS ");
						messageBuilder.AppendFormatted(targets.Count);
					}
					Log.Debug(messageBuilder);
					artilleryTargets.value.AddRange(targets, 100);
					EndAction();
				}
			});
		}

		private bool FindTargetThread()
		{
			base.Map.BuildingsManagerMain.GetBuildings(BuildingType.Wall, targets);
			Vector3 unitsPosition = base.UnitForPathfinding.Humanoid.GetPosition();
			targets.Sort(delegate(BaseBuildingInstance b1, BaseBuildingInstance b2)
			{
				float num = b1.GetPosition().DistanceSquared(in unitsPosition);
				float value = b2.GetPosition().DistanceSquared(in unitsPosition);
				return num.CompareTo(value);
			});
			return true;
		}
	}
}
