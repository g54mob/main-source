using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Activity
{
	public class ActivityUIScript : WidgetScript
	{
		private JoinActivityScript _joinActivity;

		private LeaderboardsScript _leaderboards;

		public NetworkedActivityScript Activity { get; private set; }

		public void CloseCurrentActivityUI()
		{
			_joinActivity?.Widget.Destroy();
			_joinActivity = null;
		}

		public void Initialize(ActivityManagerUIScript activityManagerUIScript, NetworkedActivityScript activity)
		{
			Activity = activity;
			_joinActivity.Initialize(this);
			_leaderboards.Initialize(this);
			_joinActivity.Widget.Visible = true;
			_leaderboards.Widget.Visible = false;
			Activity.PlayerStateChanged += OnActivityPlayerStateChanged;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_joinActivity = widget.FindWidgetComponent<JoinActivityScript>("join-activity");
			_leaderboards = widget.FindWidgetComponent<LeaderboardsScript>("leaderboards");
		}

		public void StartActivity()
		{
			Activity.StartActivity();
		}

		protected virtual void OnDestroy()
		{
			Activity.PlayerStateChanged -= OnActivityPlayerStateChanged;
		}

		private void OnActivityPlayerStateChanged(object sender, NetworkedActivityPlayerStateChangedEventArgs e)
		{
			if (Activity.LocalPlayer == e.Player && e.Player.State == NetworkedActivityPlayerState.Playing)
			{
				_joinActivity.OnActivityStarted();
				_leaderboards.OnActivityStarted();
			}
		}
	}
}
