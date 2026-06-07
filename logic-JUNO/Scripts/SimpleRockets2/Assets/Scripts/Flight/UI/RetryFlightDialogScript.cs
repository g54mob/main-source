using System;
using Assets.Scripts.State;
using Assets.Scripts.Ui;
using ModApi.Flight;
using ModApi.State;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class RetryFlightDialogScript : StatsDialogScript
	{
		public static RetryFlightDialogScript Create(Transform parent)
		{
			RetryFlightDialogScript retryFlightDialogScript = Game.Instance.UserInterface.CreateDialog("Ui/Xml/StatsDialog", parent, delegate(RetryFlightDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
			retryFlightDialogScript.ConfigureButtons();
			return retryFlightDialogScript;
		}

		private static void RestorePreFlightGameState()
		{
			_ = Game.Instance.GameStateManager;
			GameState gameState = Game.Instance.GameState;
			string id = gameState.Id;
			string tagPreFlight = gameState.GetTagPreFlight();
			string tagActive = gameState.GetTagActive();
			if (string.IsNullOrWhiteSpace(tagPreFlight))
			{
				throw new Exception($"Unable to restore pre-flight state for game state '{id}' of type '{gameState.Type}'. Game state path: {gameState.RootPath}");
			}
			Game.Instance.GameStateManager.RestoreGameStateTag(id, tagPreFlight, tagActive);
		}

		private void ConfigureButtons()
		{
			_headerText.text = "EXIT FLIGHT";
			SetButtonText(base.ButtonLeft, "RETRY");
			base.ButtonLeft.AddOnClickEvent(delegate
			{
				OnRetryClicked();
			});
			base.ButtonCenter.SetActive(active: false);
			if (Game.Instance.GameState.Type == GameStateType.Level)
			{
				_headerText.text = "END FLIGHT";
				_statsHeader.text = "Would you like to retry this level or exit?";
				SetButtonText(base.ButtonRight, "EXIT");
			}
			else
			{
				_headerText.text = "RETRY / UNDO";
				_statsHeader.text = "Okay, let's pretend this never happened. We can roll everything back to the way it was before this flight.\n\nWould you like to retry this flight or just undo and exit?";
				SetButtonText(base.ButtonRight, "UNDO & EXIT");
			}
			base.ButtonRight.AddOnClickEvent(delegate
			{
				OnExitClicked();
			});
		}

		private void OnExitClicked()
		{
			bool flag = Game.Instance.GameState.Type == GameStateType.Level;
			RestorePreFlightGameState();
			FlightSceneScript.Instance.ExitFlightScene(saveFlightState: false, flag ? FlightSceneExitReason.ExitLevel : FlightSceneExitReason.UndoAndExit);
		}

		private void OnRetryClicked()
		{
			RestorePreFlightGameState();
			FlightSceneScript.Instance.ReloadFlightScene(saveFlightState: false, Game.Instance.GameState.PreflightLoadParameters, FlightSceneExitReason.Retry);
		}
	}
}
