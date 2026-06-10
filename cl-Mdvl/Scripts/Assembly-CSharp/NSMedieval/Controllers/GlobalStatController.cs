using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.GlobalStats;
using NSMedieval.Objectives;

namespace NSMedieval.Controllers
{
	public class GlobalStatController : MonoSingleton<GlobalStatController>
	{
		public event Action<GlobalStatInstance, float, bool> GlobalStatValueSetEvent;

		public event Action<GlobalStatInstance, GlobalStatTrigger> GlobalStatTriggerActivatedEvent;

		public event Action<ObjectiveInstance> ObjectiveActivatedEvent;

		public void GlobalStatValueSet(GlobalStatInstance globalStatInstance, float oldValue, bool allowShowBbt = false)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(20, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Set ");
				messageBuilder.AppendFormatted(globalStatInstance.BlueprintId);
				messageBuilder.AppendLiteral(".Value from ");
				messageBuilder.AppendFormatted(oldValue);
				messageBuilder.AppendLiteral(" to ");
				messageBuilder.AppendFormatted(globalStatInstance.Value);
			}
			Log.Debug(messageBuilder);
			this.GlobalStatValueSetEvent?.Invoke(globalStatInstance, oldValue, allowShowBbt);
		}

		public void StatTriggerActivated(GlobalStatInstance globalStatInstance, GlobalStatTrigger globalStatTrigger)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(34, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Activated trigger ");
				messageBuilder.AppendFormatted(globalStatTrigger.ID);
				messageBuilder.AppendLiteral(" of global stat ");
				messageBuilder.AppendFormatted(globalStatInstance.BlueprintId);
			}
			Log.Debug(messageBuilder);
			this.GlobalStatTriggerActivatedEvent?.Invoke(globalStatInstance, globalStatTrigger);
		}

		protected override void OnDestroy()
		{
			this.GlobalStatValueSetEvent = null;
			this.GlobalStatTriggerActivatedEvent = null;
			this.ObjectiveActivatedEvent = null;
			base.OnDestroy();
		}

		public void ObjectiveActivated(ObjectiveInstance objectiveActivated)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Activated Objective ");
				messageBuilder.AppendFormatted(objectiveActivated);
			}
			Log.Debug(messageBuilder);
			this.ObjectiveActivatedEvent?.Invoke(objectiveActivated);
		}
	}
}
