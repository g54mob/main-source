using System;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerRoomTooSmall : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerRoomTooSmallDefinition _definition;

		[SerializeField]
		private bool _showMessage;

		[SerializeField]
		private int _numTimesShown;

		public AdvisorTriggerRoomTooSmall(AdvisorTriggerRoomTooSmallDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

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
			if (floorPlan.TileCount != 0 && !floorPlan.ValidRoomSize && _numTimesShown < _definition.MaxSmallRooms)
			{
				_showMessage = true;
			}
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
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
