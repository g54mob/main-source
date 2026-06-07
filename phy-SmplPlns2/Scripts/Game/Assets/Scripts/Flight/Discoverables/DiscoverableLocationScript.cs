using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Settings;
using Assets.Scripts.UI;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.Discoverables
{
	public class DiscoverableLocationScript : DiscoverableAreaScript
	{
		[SerializeField]
		private string _locationId = string.Empty;

		public string LocationId
		{
			get
			{
				return _locationId;
			}
			set
			{
				if (_locationId != value)
				{
					_locationId = value;
					OnLocationIdChanged();
				}
			}
		}

		protected virtual bool Locked { get; set; }

		protected override void Awake()
		{
			base.Awake();
			OnLocationIdChanged();
			GameState.Instance.MapLocationChanged += OnMapLocationChanged;
		}

		protected virtual void OnDestroy()
		{
			GameState.Instance.MapLocationChanged -= OnMapLocationChanged;
		}

		protected override void OnDiscovered()
		{
			CloudSettings cloud = Game.Instance.Settings.Cloud;
			LocationSettings locations = Game.Instance.Settings.Cloud.Locations;
			string mapId = Game.Instance.CurrentMap.MapId;
			if (!locations.HasDiscoveredLocation(mapId, LocationId))
			{
				StartLocationData discoverableLocation = locations.GetDiscoverableLocation(mapId, LocationId);
				if (discoverableLocation == null)
				{
					this.LogError("Discoverable starting location '{0}' was not found.", LocationId);
					return;
				}
				locations.UnlockDiscoverableLocation(mapId, LocationId);
				cloud.SaveIfNecessary();
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DiscoverLocation);
				FlightSceneScript.Instance.FlightUI.ShowLogMessage("Location Discovered: " + discoverableLocation.DisplayName);
			}
		}

		protected override void PlayerInBounds(FlightScenePlayer player)
		{
			if (!Locked)
			{
				base.PlayerInBounds(player);
			}
		}

		private void OnLocationIdChanged()
		{
			if (string.IsNullOrEmpty(LocationId))
			{
				base.Discovered = false;
				base.gameObject.SetActive(value: false);
			}
			else
			{
				base.Discovered = Game.Instance.Settings.Cloud.Locations.HasDiscoveredLocation(Game.Instance.CurrentMap.MapId, LocationId);
				base.gameObject.SetActive(!base.Discovered && Game.Instance.CurrentLevel.IsSandbox);
			}
		}

		private void OnMapLocationChanged(object sender, MapLocationChangedEventArgs e)
		{
			base.gameObject.SetActive(!base.Discovered && Game.Instance.CurrentLevel.IsSandbox && !IsPlayerInBounds(FlightSceneScript.Instance.LocalPlayer));
		}
	}
}
