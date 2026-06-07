using System.Linq;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.UI;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.Discoverables
{
	public class DiscoverableActivityScript : DiscoverableAreaScript
	{
		[SerializeField]
		private string _activityId = string.Empty;

		public string ActivityId => _activityId;

		protected override void Awake()
		{
			base.Awake();
			base.Discovered = Game.Instance.Settings.Cloud.Activities.Unlocked.Contains(ActivityId);
			base.gameObject.SetActive(!base.Discovered);
		}

		protected override void OnDiscovered()
		{
			NetworkedActivityData registeredActivity = Game.Instance.NetworkedActivityManager.GetRegisteredActivity(ActivityId);
			if (registeredActivity == null)
			{
				this.LogError("Discoverable activity with id '{0}' could not be found in the activity database.", ActivityId);
				return;
			}
			Game.Instance.Settings.Cloud.Activities.SetActivityUnlocked(registeredActivity.Id);
			Game.Instance.Settings.Cloud.SaveIfNecessary();
			Game.Instance.UserInterface.Sound.PlaySound(UISound.DiscoverLocation);
			FlightSceneScript.Instance.FlightUI.ShowLogMessage($"Activity Unlocked: {registeredActivity.DisplayName}");
		}
	}
}
