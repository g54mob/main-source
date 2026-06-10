using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.View;

namespace NSMedieval.Goap.Goals
{
	public class TrainingEventGoalSergeant : EventBaseGoalRole
	{
		public TrainingEventGoalSergeant(Agent selfAgent)
			: base("TrainingEventGoalSergeant", selfAgent)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToGatherPosition();
			yield return WaitForOthers();
			yield return GoToEventPosition();
			yield return SnapToWorkPosition();
			yield return EventRoleAction("SargeantIdle");
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is TrainingEventInstance result))
			{
				return null;
			}
			return result;
		}

		protected override void EquipProp(bool equipped)
		{
			if (!(base.AnimatedAgentView is HumanoidView))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\TrainingEventGoalSergeant.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Something went wrong, ");
					messageBuilder.AppendFormatted(base.AnimatedAgentView);
					messageBuilder.AppendLiteral(" is not HumanoidView.");
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
