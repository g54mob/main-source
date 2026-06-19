using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/AdvisorIcon.png")]
	public class ShowAdvisorMessage : ExpiringLevelAction
	{
		public string _message;

		public LocalisedString _messageLocalised;

		public Sprite _messageIcon;

		public float _displayTime = 10f;

		public bool _showIndefinitely;

		public bool _userCanDismiss = true;

		public AdvisorDisplayType _displayType;

		public RuntimeAnimatorController _overrideAnimationGraph;

		public bool _interrupts = true;

		public Advisor.PriorityLevel _priorityLevel;

		public bool _alwaysShow;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			if (_alwaysShow)
			{
				base.Owner.Level.Advisor.PushMessageForce(new AdvisorMessageDefinition
				{
					LocalisedMessage = _messageLocalised,
					Message = _message,
					Icon = _messageIcon,
					Duration = _displayTime,
					ShowIndefinitely = _showIndefinitely,
					DisplayType = _displayType,
					UserCanDismiss = _userCanDismiss,
					OverrideAnimationGraph = _overrideAnimationGraph
				}, _interrupts);
			}
			else
			{
				base.Owner.Level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					LocalisedMessage = _messageLocalised,
					Message = _message,
					Icon = _messageIcon,
					Duration = _displayTime,
					ShowIndefinitely = _showIndefinitely,
					DisplayType = _displayType,
					UserCanDismiss = _userCanDismiss,
					OverrideAnimationGraph = _overrideAnimationGraph
				}, _interrupts, _priorityLevel);
			}
			return TaskStatus.Success;
		}
	}
}
