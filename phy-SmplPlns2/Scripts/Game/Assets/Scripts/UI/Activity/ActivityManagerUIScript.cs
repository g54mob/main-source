using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Threading.Tasks;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Activity
{
	public class ActivityManagerUIScript : WidgetScript
	{
		private List<ActivityInviteScript> _activityInvites = new List<ActivityInviteScript>();

		private Widget _activityInvitesParent;

		private ActivityUIScript _activityUI;

		private NetworkedActivityManager _manager;

		public ActivityUIScript ActivityUI
		{
			get
			{
				return _activityUI;
			}
			private set
			{
				CloseCurrentActivityUI();
				_activityUI = value;
				if (_activityUI != null)
				{
					_activityInvitesParent.Visible = false;
				}
			}
		}

		public bool AutoAcceptInvites { get; set; }

		public void CloseCurrentActivityUI()
		{
			_activityUI?.Widget.Destroy();
			_activityUI = null;
			_activityInvitesParent.Visible = true;
		}

		public void CreateSelectActivityDialog()
		{
			Game.Instance.UserInterface.CreateSelectActivityDialog().ActivitySelected += OnActivitySelected;
		}

		public async void InviteAccepted(ActivityInviteScript activityInvite)
		{
			RemoveInvite(activityInvite);
			FlightScenePlayer player = await UniTaskEx.WaitUntilNotNull(() => FlightSceneScript.Instance.LocalPlayer);
			await AcceptInvite(activityInvite.Activity, player, isHost: false);
		}

		public void InviteDeclined(ActivityInviteScript activityInvite)
		{
			RemoveInvite(activityInvite);
		}

		public void LateJoinActivity(NetworkedActivityScript activity)
		{
			CloseCurrentActivityUI();
			CreateActivityUI(activity);
		}

		public void OnCurrentActivityEnded()
		{
			_activityInvitesParent.Visible = true;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_manager = Game.Instance.NetworkedActivityManager;
			_manager.ActivityStateChanged += OnActivityStateChanged;
			_activityInvitesParent = base.Widget.FindWidget("activity-invites");
		}

		protected virtual void OnDestroy()
		{
			if (_manager != null)
			{
				_manager.ActivityStateChanged -= OnActivityStateChanged;
			}
		}

		private async Task AcceptInvite(NetworkedActivityScript activity, FlightScenePlayer player, bool isHost)
		{
			NetworkedActivityScript.AsyncResult asyncResult;
			if (isHost)
			{
				asyncResult = await activity.JoinTeam(player, null);
			}
			else
			{
				await UniTaskEx.WaitUntilWithTimeout(() => activity == null || activity.ActivityHost != null, 15000);
				if (activity == null || player.NetworkedActivity != null)
				{
					return;
				}
				asyncResult = await activity.JoinTeam(player, null);
			}
			if (!asyncResult.IsSuccess)
			{
				Debug.LogError("Failed to auto-join networked activity team. Error: " + asyncResult.Message);
			}
			CreateActivityUI(activity);
		}

		private void CreateActivityInvite(NetworkedActivityScript activity)
		{
			ActivityInviteScript componentInChildren = base.Widget.Context.CreateWidgetFromTemplate("activity-invite", _activityInvitesParent).GetComponentInChildren<ActivityInviteScript>();
			componentInChildren.InitializeInvite(this, activity);
			componentInChildren.Widget.Show();
			_activityInvites.Add(componentInChildren);
		}

		private void CreateActivityUI(NetworkedActivityScript activity)
		{
			ActivityUI = base.Widget.Context.LoadWidgetFromXml("Xml/Activity/ActivityUI", base.Widget).GetComponent<ActivityUIScript>();
			ActivityUI.Initialize(this, activity);
		}

		private void OnActivitySelected(object sender, ActivitySelectedEventArgs e)
		{
			_manager.CreateActivity(e.ActivityId).Forget();
		}

		private async void OnActivityStateChanged(object sender, NetworkedActivityStateChangedEventArgs e)
		{
			_ = 1;
			try
			{
				if (e.State == NetworkedActivityState.Initialized)
				{
					FlightScenePlayer flightScenePlayer = await UniTaskEx.WaitUntilNotNull(() => FlightSceneScript.Instance.LocalPlayer);
					bool isActivityHost = e.Activity.IsActivityHost;
					if ((AutoAcceptInvites || isActivityHost) && flightScenePlayer != null && flightScenePlayer.NetworkedActivity == null)
					{
						await AcceptInvite(e.Activity, flightScenePlayer, isActivityHost);
					}
					else if (flightScenePlayer != null && !isActivityHost)
					{
						CreateActivityInvite(e.Activity);
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void RemoveInvite(ActivityInviteScript activityInvite)
		{
			_activityInvites.Remove(activityInvite);
			activityInvite.Widget.Hide(delegate
			{
				activityInvite.Widget.Destroy();
			});
		}
	}
}
