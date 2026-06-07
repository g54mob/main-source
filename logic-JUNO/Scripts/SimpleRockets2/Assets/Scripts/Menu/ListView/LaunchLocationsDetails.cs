using ModApi.Math;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class LaunchLocationsDetails
	{
		private DetailsPropertyPairScript _career;

		private DetailsPropertyPairScript _coords;

		private DetailsTextScript _description;

		private DetailsImageScript _image;

		private DetailsPropertyPairScript _state;

		public LaunchLocationsDetails(ListViewDetailsScript listViewDetails)
		{
			_image = listViewDetails.Widgets.AddImage();
			_image.SetSize(200);
			_description = listViewDetails.Widgets.AddText("Description");
			listViewDetails.Widgets.AddSpacer();
			if (Game.IsCareer)
			{
				_career = listViewDetails.Widgets.AddPropertyPair("Mass", "Size");
			}
			_coords = listViewDetails.Widgets.AddPropertyPair("Planet", "Coords");
			_state = listViewDetails.Widgets.AddPropertyPair("Altitude", "Velocity");
		}

		public void UpdateDetails(LaunchLocation launchLocation)
		{
			if (!string.IsNullOrEmpty(launchLocation.ImagePath))
			{
				_image.Visible = true;
				_image.ImagePath = launchLocation.ImagePath;
			}
			else
			{
				_image.Visible = false;
			}
			_description.Text = launchLocation.Description;
			_coords.LeftValueText = launchLocation.PlanetName;
			_coords.RightValueText = Units.GetCoordinatesString(new Vector3((float)launchLocation.Latitude, (float)launchLocation.Longitude, 0f));
			if (launchLocation.LocationType == LaunchLocationType.SurfaceLockedGround)
			{
				_state.LeftValueText = "Ground";
				_state.RightValueText = "None";
			}
			else
			{
				_state.LeftValueText = Units.GetDistanceString((float)launchLocation.AltitudeAboveGroundLevel);
				_state.RightValueText = Units.GetVelocityString((float)launchLocation.Velocity.magnitude);
			}
			if (Game.IsCareer)
			{
				_career.LeftValueText = ((launchLocation.MaxCraftMass > 0.0) ? (Units.GetMassString((float)launchLocation.MaxCraftMass) + "  ") : ((launchLocation.LaunchCostPerKG > 0.0) ? string.Empty : "Unlimited")) + ((launchLocation.LaunchCostPerKG > 0.0) ? (Units.GetMoneyString((long)launchLocation.LaunchCostPerKG) + "/kg") : string.Empty);
				_career.RightValueText = ((launchLocation.MaxCraftHeight > 0.0) ? ("<size=150%>↕</size>" + Units.GetDistanceString((float)launchLocation.MaxCraftHeight) + "  ") : string.Empty) + ((launchLocation.MaxCraftDiameter > 0.0) ? ("<size=150%>↔</size>" + Units.GetDistanceString((float)launchLocation.MaxCraftDiameter)) : string.Empty);
			}
		}
	}
}
