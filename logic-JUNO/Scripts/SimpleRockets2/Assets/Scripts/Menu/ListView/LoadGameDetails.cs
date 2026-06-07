using System;
using System.Xml.Linq;
using Assets.Scripts.State;
using ModApi;
using ModApi.CelestialData;
using ModApi.Math;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class LoadGameDetails
	{
		private DetailsPropertyScript _craftsInFlight;

		private DetailsPropertyScript _createdDate;

		private DetailsPropertyScript _gameTime;

		private DetailsPropertyScript _gameType;

		private DetailsPropertyScript _lastPlayedDate;

		private DetailsPropertyScript _money;

		private DetailsPropertyScript _planetarySystem;

		private DetailsPropertyScript _planetarySystemVersion;

		public LoadGameDetails(ListViewDetailsScript listViewDetails)
		{
			_planetarySystem = listViewDetails.Widgets.AddProperty("Planetary System");
			_planetarySystemVersion = listViewDetails.Widgets.AddProperty("Version");
			listViewDetails.Widgets.AddSpacer();
			_gameType = listViewDetails.Widgets.AddProperty("Game Type");
			_money = listViewDetails.Widgets.AddProperty("Company Funds");
			listViewDetails.Widgets.AddSpacer();
			_craftsInFlight = listViewDetails.Widgets.AddProperty("Crafts in Flight");
			_gameTime = listViewDetails.Widgets.AddProperty("Elapsed Time");
			listViewDetails.Widgets.AddSpacer();
			_lastPlayedDate = listViewDetails.Widgets.AddProperty("Last Played");
			_createdDate = listViewDetails.Widgets.AddProperty("Created");
		}

		public void UpdateDetails(GameStateInfo gameState)
		{
			_money.ValueText = ((gameState.GameStateMode == GameStateMode.Career) ? Units.GetMoneyString(gameState.Money.GetValueOrDefault()) : "N/A");
			_gameType.ValueText = gameState.GameStateMode.ToString();
			_createdDate.ValueText = (gameState.CreatedDateTime.HasValue ? RelativeDate(gameState.CreatedDateTime.Value) : "Unknown");
			_lastPlayedDate.ValueText = (gameState.LastModifiedDateTime.HasValue ? RelativeDate(gameState.LastModifiedDateTime.Value) : "Unknown");
			_craftsInFlight.ValueText = gameState.CraftsInFlight.GetValueOrDefault().ToString();
			PlanetarySystemFileData planetarySystemFileData = null;
			if (!string.IsNullOrEmpty(gameState.PlanetarySystemXml))
			{
				try
				{
					CelestialFileReference planetarySystemFileReference = CelestialFileReference.LoadFromXml(XElement.Parse(gameState.PlanetarySystemXml));
					planetarySystemFileData = Game.Instance.CelestialDatabase.GetPlanetarySystem(planetarySystemFileReference);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			if (planetarySystemFileData != null)
			{
				_planetarySystem.ValueText = planetarySystemFileData.Name;
				_planetarySystemVersion.ValueText = planetarySystemFileData.Version.ToString();
			}
			else
			{
				_planetarySystem.ValueText = "<color=red>NOT FOUND</color>";
				_planetarySystemVersion.ValueText = string.Empty;
			}
			TimeSpan timeSpan = TimeSpan.FromSeconds(gameState.FlightStateTime.GetValueOrDefault());
			if (timeSpan.TotalHours > 48.0)
			{
				_gameTime.ValueText = timeSpan.TotalDays.ToString("n1") + " days";
			}
			else
			{
				_gameTime.ValueText = timeSpan.TotalHours.ToString("n1") + " hours";
			}
		}

		private static string RelativeDate(DateTime d)
		{
			return Utilities.RelativeDate(DateTime.Now, d);
		}
	}
}
