using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/CinematicIcon.png")]
	public class SubmitInGameAdvisorMessage : MetagameCutsceneAction
	{
		public string _message;

		public LocalisedString _messageLocalised;

		public Sprite _messageIcon;

		public float _displayTime = 10f;

		public bool _showIndefinitely;

		public bool _userCanDismiss = true;

		public AdvisorDisplayType _displayType;

		public override TaskStatus OnUpdate()
		{
			MetagameStatePlayer stateInStateMachine = base.Owner.MetagameMap.StateMachine.GetStateInStateMachine<MetagameStatePlayer>();
			if (stateInStateMachine == null)
			{
				return TaskStatus.Success;
			}
			AdvisorMessageDefinition messageDefinition = new AdvisorMessageDefinition
			{
				LocalisedMessage = _messageLocalised,
				Message = _message,
				Icon = _messageIcon,
				Duration = _displayTime,
				ShowIndefinitely = _showIndefinitely,
				DisplayType = _displayType,
				UserCanDismiss = _userCanDismiss
			};
			stateInStateMachine.SubmitAdvisorMessage(messageDefinition);
			return TaskStatus.Success;
		}
	}
}
