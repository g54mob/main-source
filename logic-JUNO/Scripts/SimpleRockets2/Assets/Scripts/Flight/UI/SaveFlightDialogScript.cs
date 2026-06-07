using System;
using Assets.Scripts.Ui;
using ModApi.Craft;
using ModApi.Flight;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class SaveFlightDialogScript : StatsDialogScript
	{
		public Action OnRetryClicked { get; set; }

		public static SaveFlightDialogScript Create(Transform parent, bool temporaryFlightState)
		{
			SaveFlightDialogScript saveFlightDialogScript = Game.Instance.UserInterface.CreateDialog("Ui/Xml/StatsDialog", parent, delegate(SaveFlightDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
			saveFlightDialogScript.ConfigureButtons();
			return saveFlightDialogScript;
		}

		private static bool IsOnCollisionCourse()
		{
			ICraftNode craftNode = FlightSceneScript.Instance.CraftNode;
			if (!craftNode.InContactWithPlanet)
			{
				double height = craftNode.Parent.PlanetData.AtmosphereData.Height;
				if (!craftNode.IsDestroyed && craftNode.Orbit.Eccentricity <= 1.0 && craftNode.Orbit.PeriapsisDistance < craftNode.Parent.PlanetData.Radius + height + 1000.0)
				{
					return true;
				}
			}
			return false;
		}

		private void ConfigureButtons()
		{
			string text = "Save this flight so that you can resume it later from the Resume Flight button in the main menu.";
			text += "\n\nIf you're not happy with what you accomplished this flight, then it might be best to Retry / Undo instead.";
			if (IsOnCollisionCourse())
			{
				text += "\n\nYour craft is on a collision course with the planet and will crash if left unattended. Are you sure you want to save and exit?";
			}
			_headerText.text = "SAVE FLIGHT";
			_statsHeader.text = text;
			SetButtonText(base.ButtonLeft, "RETRY / UNDO");
			base.ButtonLeft.AddOnClickEvent(delegate
			{
				Close();
				OnRetryClicked?.Invoke();
			});
			base.ButtonLeft.Tooltip = "There's no penalty for trying again. If you didn't complete any contracts or milestones, this is the recommended option.";
			base.ButtonLeft.SetActive(Game.Instance.GameState.Validator.IsItemAvailable("Cheats.UndoRetry"));
			base.ButtonCenter.SetActive(active: false);
			SetButtonText(base.ButtonRight, "SAVE & EXIT");
			base.ButtonRight.AddOnClickEvent(delegate
			{
				OnExitClicked();
			});
		}

		private void OnExitClicked()
		{
			FlightSceneScript.Instance.ExitFlightScene(saveFlightState: true, FlightSceneExitReason.SaveAndExit, "Menu");
		}
	}
}
