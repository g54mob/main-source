using Assets.Scripts.Multiplayer.ActivityFramework;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Activity
{
	public class ActivityInviteScript : WidgetScript
	{
		private ActivityManagerUIScript _activityManager;

		public NetworkedActivityScript Activity { get; private set; }

		public void InitializeInvite(ActivityManagerUIScript activityManager, NetworkedActivityScript activity)
		{
			_activityManager = activityManager;
			Activity = activity;
			base.Widget.FindWidget<TextWidget>("activity-name").Text = activity.Data.DisplayName;
		}

		protected void Update()
		{
			if ((int)Activity.State >= 5)
			{
				_activityManager.InviteDeclined(this);
				base.Widget.Visible = false;
			}
		}

		private void OnAcceptButtonClicked(Widget widget)
		{
			_activityManager.InviteAccepted(this);
		}

		private void OnIgnoreButtonClicked(Widget widget)
		{
			_activityManager.InviteDeclined(this);
		}
	}
}
