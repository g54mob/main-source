using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/MessageIcon.png")]
	public class ShowMessage : ExpiringLevelAction
	{
		[Tooltip("Use a name here, if you only want it to show once")]
		[UsedImplicitly]
		public string _name;

		[Tooltip("DEPRECATED - Please use a notification reference")]
		[UsedImplicitly]
		public NotificationMessages.Definition _message;

		[UsedImplicitly]
		public SharedInstance_TH20TH20_NotificationMessagesDefinition _messageInstance;

		[UsedImplicitly]
		public bool _showImmediately;

		private bool _messageDismissed;

		public override void OnStart()
		{
			base.OnStart();
			if (HasTaskExpired())
			{
				return;
			}
			NotificationObjectiveComplete message = new NotificationObjectiveComplete((_messageInstance != null) ? _messageInstance.Instance : _message, null, null, ResponseDelegate, base.Owner.Level, null);
			if (_name.IsNullOrEmpty())
			{
				if (_showImmediately)
				{
					base.Owner.Level.Notifications.OpenPopup(message);
				}
				else
				{
					base.Owner.Level.Notifications.Send(message);
				}
			}
			else if (_showImmediately)
			{
				if (!base.Owner.Level.Notifications.OpenNamed(message, _name))
				{
					_messageDismissed = true;
				}
			}
			else if (!base.Owner.Level.Notifications.SendNamed(message, _name))
			{
				_messageDismissed = true;
			}
		}

		private void ResponseDelegate(int response)
		{
			_messageDismissed = true;
		}

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			if (_showImmediately && !_messageDismissed)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
