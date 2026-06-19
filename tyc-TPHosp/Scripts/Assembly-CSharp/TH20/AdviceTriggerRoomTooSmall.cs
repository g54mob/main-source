using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerRoomTooSmall : AdviceTrigger
	{
		private bool _showMessage;

		private int _numTimesShown;

		[InspectorMargin(8)]
		[InspectorHeader("Room Too Small")]
		[InspectorTooltip("The number of times this message will be shown")]
		[FullInspector.InspectorName("Max Times To Show")]
		[SerializeField]
		private int _maxSmallRooms = 4;

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnFloorPlanUpdated = (Action<BlueprintFloorPlan>)Delegate.Combine(buildEvents.OnFloorPlanUpdated, new Action<BlueprintFloorPlan>(OnFloorPlanUpdated));
		}

		public override void OnUnregister()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnFloorPlanUpdated = (Action<BlueprintFloorPlan>)Delegate.Remove(buildEvents.OnFloorPlanUpdated, new Action<BlueprintFloorPlan>(OnFloorPlanUpdated));
		}

		private void OnFloorPlanUpdated(BlueprintFloorPlan floorPlan)
		{
			if (floorPlan.TileCount != 0 && !floorPlan.ValidRoomSize && _numTimesShown < _maxSmallRooms)
			{
				_showMessage = true;
			}
		}

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (_showMessage)
			{
				_numTimesShown++;
				_showMessage = false;
				return Advisor.PriorityLevel.VeryHigh;
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
