using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Ui;
using ModApi.Flight;
using ModApi.Math;
using ModApi.State;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class EndFlightDialogScript : StatsDialogScript
	{
		public static EndFlightDialogScript Create(Transform parent)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/StatsDialog", parent, delegate(EndFlightDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
		}

		protected override void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			base.OnLayoutRebuilt(xmlLayout);
			base.ButtonCancel.SetActive(active: false);
			SetButtonText(base.ButtonLeft, "SAVE FLIGHT");
			base.ButtonLeft.Tooltip = "Exit the flight scene and keep this as an active craft in case you want to resume control of it later.";
			base.ButtonLeft.AddOnClickEvent(delegate
			{
				OnExitClicked();
			});
			SetButtonText(base.ButtonCenter, "RETRY / UNDO");
			base.ButtonCenter.Tooltip = "Undo this flight and try again.";
			base.ButtonCenter.AddOnClickEvent(delegate
			{
				OnRetryClicked();
			});
			base.ButtonCenter.SetActive(Game.Instance.GameState.Validator.IsItemAvailable("Cheats.UndoRetry"));
			SetButtonText(base.ButtonRight, "RECOVER CRAFT");
			base.ButtonRight.Tooltip = "View options for recovering this craft. If it's close enough to a recovery location, you can scrap its parts for money.";
			base.ButtonRight.AddOnClickEvent(delegate
			{
				OnRecoverCraftClicked();
			});
			UpdateEndFlightStats();
		}

		private void OnExitClicked()
		{
			_panel.SetActive(active: false);
			SaveFlightDialogScript saveFlightDialogScript = SaveFlightDialogScript.Create(base.transform, temporaryFlightState: false);
			saveFlightDialogScript.OnRetryClicked = delegate
			{
				OnRetryClicked();
				_panel.SetActive(active: false);
			};
			saveFlightDialogScript.Closed += delegate
			{
				_panel.SetActive(active: true);
			};
		}

		private void OnRecoverCraftClicked()
		{
			CraftNode craftNode = FlightSceneScript.Instance.CraftNode as CraftNode;
			CraftRecovery recovery = new CraftRecovery(Game.Instance.GameState, craftNode.CraftScript.Data, craftNode.CraftMass, new CraftNodeDataDynamic(craftNode), craftNode.Parent, craftNode.IsDestroyed);
			bool showRetryButton = Game.Instance.GameState.Validator.IsItemAvailable("Cheats.UndoRetry");
			RecoverCraftDialogScript recoverCraftDialogScript = RecoverCraftDialogScript.Create(recovery, showRetryButton);
			_panel.SetActive(active: false);
			recoverCraftDialogScript.OnRetryClicked = delegate
			{
				OnRetryClicked();
				_panel.SetActive(active: false);
			};
			recoverCraftDialogScript.CraftDestroyed = delegate
			{
				craftNode.DestroyOnExitFlightScene = true;
				FlightSceneScript.Instance.ExitFlightScene(saveFlightState: true, FlightSceneExitReason.SaveAndDestroy, "Menu");
			};
			recoverCraftDialogScript.CraftRecovered = delegate
			{
				craftNode.DestroyOnExitFlightScene = true;
				FlightSceneScript.Instance.ExitFlightScene(saveFlightState: true, FlightSceneExitReason.SaveAndRecover, "Menu");
			};
			recoverCraftDialogScript.Closed += delegate
			{
				_panel.SetActive(active: true);
			};
		}

		private void OnRetryClicked()
		{
			_panel.SetActive(active: false);
			RetryFlightDialogScript.Create(base.transform).Closed += delegate
			{
				_panel.SetActive(active: true);
			};
		}

		private void UpdateEndFlightStats()
		{
			ClearStats();
			_headerText.text = "EXIT FLIGHT";
			_statsHeader.text = "FLIGHT STATS";
			Assets.Scripts.Flight.FlightLog flightLog = FlightSceneScript.Instance.FlightLog;
			if (Game.IsCareer)
			{
				AddStat("Money Awarded", Units.GetMoneyString(flightLog.Money));
				AddStat("Tech Points Awarded", flightLog.TechPoints.ToString());
				long launchCost = flightLog.LaunchCost;
				if (launchCost > 0)
				{
					AddStat("Launch Cost", Units.GetMoneyString(launchCost));
				}
			}
			AddStat("Flight Time", TimeManagerScript.GetTimeString((long)flightLog.FlightTime));
			AddStat("Max Velocity", Units.GetVelocityString((int)flightLog.MaxVelocity));
			AddStat("Max Altitude", Units.GetDistanceString((float)flightLog.MaxAltitude));
			if (flightLog.IsNewLaunch)
			{
				AddStat("Max Q", Units.GetDistanceString((float)flightLog.MaxQ));
			}
			AddStat("Distance Traveled", Units.GetDistanceString((float)flightLog.DistanceTraveled));
		}
	}
}
