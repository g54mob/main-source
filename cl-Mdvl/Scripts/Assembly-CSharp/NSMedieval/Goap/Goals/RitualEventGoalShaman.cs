using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.View;

namespace NSMedieval.Goap.Goals
{
	public class RitualEventGoalShaman : EventBaseGoalRole
	{
		public RitualEventGoalShaman(Agent selfAgent)
			: base("RitualEventGoalShaman", selfAgent)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToGatherPosition();
			yield return WaitForOthers();
			yield return GoToEventPosition();
			yield return EventRoleAction("ShamanIdle");
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is RitualEventInstance result))
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
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RitualEventGoalShaman.cs");
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
				humanoidView.BodyPreview.SetDrumsEnabled(equipped);
			}
		}
	}
}
