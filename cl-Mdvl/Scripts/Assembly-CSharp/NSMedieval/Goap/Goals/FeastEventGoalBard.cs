using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.View;

namespace NSMedieval.Goap.Goals
{
	public class FeastEventGoalBard : EventBaseGoalRole
	{
		public FeastEventGoalBard(Agent selfAgent)
			: base("FeastEventGoalBard", selfAgent)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToGatherPosition();
			yield return WaitForOthers();
			yield return GoToEventPosition();
			yield return EventRoleAction("BardIdle");
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				return null;
			}
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is FeastEventInstance result))
			{
				return null;
			}
			return result;
		}

		protected override void EquipProp(bool equipped)
		{
			if (!(base.AnimatedAgentView is HumanoidView humanoidView))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FeastEventGoalBard.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Something went wrong, ");
					messageBuilder.AppendFormatted(base.AnimatedAgentView);
					messageBuilder.AppendLiteral(" is not HumanoidView.");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				humanoidView.BodyPreview.SetLuteEnabled(equipped);
			}
		}
	}
}
