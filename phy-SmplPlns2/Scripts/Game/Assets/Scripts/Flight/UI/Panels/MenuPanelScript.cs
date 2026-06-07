using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Dialogs;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class MenuPanelScript : FlightPanelScript
	{
		private static bool _instrumentsVisible = true;

		private ButtonWidget _buildButton;

		private CraftInstructionsScript _craftInstructionsDialog;

		private int _lastInstructionsHash;

		private FlightScenePlayer _localPlayer;

		private NetworkStatsDialogScript _networkStats;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			widget.FindWidget("time-buttons").Visible = PauseManager.AllowTimeScaleChanges;
			_buildButton = widget.FindWidget<ButtonWidget>("build-button");
			SetButtonEnabledStatesOnCraftLoad(enabled: false);
			FlightSceneScript instance = FlightSceneScript.Instance;
			instance.FlightSceneUnloading += OnFlightSceneUnloading;
			instance.PlayerAircraftLoaded += OnPlayerAircraftLoaded;
			if (instance.LocalPlayer != null)
			{
				OnPrimaryLocalPlayerLoaded(this, new FlightScenePlayerEventArgs(instance.LocalPlayer));
			}
			else
			{
				instance.PrimaryLocalPlayerLoaded += OnPrimaryLocalPlayerLoaded;
			}
		}

		protected virtual void Start()
		{
			UpdateInstrumentsVisibility();
		}

		private void CloseCraftInstructionsDialog()
		{
			_craftInstructionsDialog.Close();
			_craftInstructionsDialog = null;
			UpdateCraftInstructionsButton();
		}

		private void OnActivitiesClicked(Widget widget)
		{
			base.FlightUI.ActivityManagerUI.CreateSelectActivityDialog();
			base.FlightUI.Flyouts.Selected = null;
		}

		private void OnAircraftLoadCompleted(object sender, FlightScenePlayerAircraftLoadCompletedEventArgs e)
		{
			SetButtonEnabledStatesOnCraftLoad(enabled: true);
		}

		private void OnAircraftLoadStarted(object sender, FlightScenePlayerEventArgs e)
		{
			SetButtonEnabledStatesOnCraftLoad(enabled: false);
		}

		private void OnChangeCraftClicked(Widget widget)
		{
			base.FlightUI.Flyouts.Selected = base.FlightUI.Flyouts.ChangeCraft;
		}

		private void OnCustomizeCharacterClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateCustomizeCharacterFlyout();
		}

		private void OnEnableVRClicked(Widget widget)
		{
			Game.Instance.XRDeviceManager.SetXrActive(active: true);
			base.FlightUI.Flyouts.Selected = null;
		}

		private void OnEnterDesignerClicked(Widget widget)
		{
			FlightSceneScript.Instance.Designer.Enter();
		}

		private void OnEnteredInFlightDesigner(object sender, FlightScenePlayerEventArgs e)
		{
			if (_craftInstructionsDialog != null)
			{
				CloseCraftInstructionsDialog();
			}
		}

		private void OnExitClicked(Widget widget)
		{
			string exitConfirmationMessage = base.FlightUI.GetExitConfirmationMessage();
			Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, exitConfirmationMessage, "Exit Flight", delegate(MessageDialogScript d)
			{
				d.Close();
				Game.Instance.SceneManager.EndLevelReturnScene = null;
				PauseManager.RequestPauseChange(paused: false, userInitiated: false);
				FlightSceneScript.Instance.LocalPlayer.DespawnAircraft();
				FlightSceneScript.Instance.ExitLevel();
			}).UseDangerButtonStyle = true;
		}

		private void OnExitedInFlightDesigner(object sender, FlightScenePlayerEventArgs e)
		{
			SetButtonEnabledStatesOnCraftLoad(enabled: false);
		}

		private void OnFastForwardClicked(Widget widget)
		{
			PauseManager.SetFastForward(enabled: true);
			UpdateTimeButtons();
			base.FlightUI.ShowMessage("Fast Forward Enabled");
		}

		private void OnFlightSceneUnloading(object sender, EventArgs e)
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if ((object)instance != null)
			{
				instance.FlightSceneUnloading -= OnFlightSceneUnloading;
				instance.PlayerAircraftLoaded -= OnPlayerAircraftLoaded;
				instance.PrimaryLocalPlayerLoaded -= OnPrimaryLocalPlayerLoaded;
			}
			if (_localPlayer != null)
			{
				_localPlayer.AircraftLoadStarted -= OnAircraftLoadStarted;
				_localPlayer.AircraftLoadCompleted -= OnAircraftLoadCompleted;
				_localPlayer.EnteredInFlightDesigner -= OnEnteredInFlightDesigner;
				_localPlayer.ExitedInFlightDesigner -= OnExitedInFlightDesigner;
			}
		}

		private void OnLocationClicked(Widget widget)
		{
			if (Game.Instance.CurrentLevel.IsSandbox)
			{
				base.FlightUI.Flyouts.Selected = base.FlightUI.Flyouts.SelectLocation;
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "The locations feature is only available in Sandbox mode. If we let people use it during challenges, they may be tempted to use it for evil.";
			}
		}

		private void OnNetworkStatsClicked(Widget widget)
		{
			if (_networkStats != null)
			{
				_networkStats.Close();
				_networkStats = null;
			}
			_networkStats = Game.Instance.UserInterface.CreateNetworkStatsDialog();
		}

		private void OnNormalTimeClicked(Widget widget)
		{
			PauseManager.SetFastForward(enabled: false);
			PauseManager.SetSlowMotion(enabled: false);
			UpdateTimeButtons();
			base.FlightUI.ShowMessage("Normal Time Enabled");
		}

		private void OnPlayerAircraftLoaded(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (!e.Player.IsPrimaryLocal)
			{
				return;
			}
			bool flag = false;
			if (_craftInstructionsDialog != null)
			{
				flag = true;
				CloseCraftInstructionsDialog();
			}
			if (!PlayerPrefs.HasKey("CraftInstructionsVisible"))
			{
				PlayerPrefs.SetInt("CraftInstructionsVisible", 1);
			}
			if (!string.IsNullOrWhiteSpace(e.Aircraft?.Aircraft?.Instructions))
			{
				int hashCode = e.Aircraft.Aircraft.Instructions.GetHashCode();
				if (flag || (PlayerPrefs.GetInt("CraftInstructionsVisible") > 0 && _lastInstructionsHash != hashCode))
				{
					ShowCraftInstructionsDialog(e.Aircraft.Aircraft);
				}
			}
		}

		private void OnPlayerListClicked(Widget widget)
		{
			base.FlightUI.Flyouts.Selected = base.FlightUI.Flyouts.PlayerList;
		}

		private void OnPrimaryLocalPlayerLoaded(object sender, FlightScenePlayerEventArgs e)
		{
			_localPlayer = e.Player;
			_localPlayer.AircraftLoadStarted += OnAircraftLoadStarted;
			_localPlayer.AircraftLoadCompleted += OnAircraftLoadCompleted;
			_localPlayer.EnteredInFlightDesigner += OnEnteredInFlightDesigner;
			_localPlayer.ExitedInFlightDesigner += OnExitedInFlightDesigner;
		}

		private void OnQuickStartClicked(Widget widget)
		{
			base.FlightUI.gameObject.GetComponentInChildren<DemoTutorialScript>().ShowQuickStartGuide();
		}

		private void OnServerSettingsClicked(Widget widget)
		{
			base.FlightUI.Flyouts.Selected = base.FlightUI.Flyouts.ServerSettings;
		}

		private void OnSettingsClicked(Widget widget)
		{
			base.FlightUI.Flyouts.Selected = base.FlightUI.Flyouts.Settings;
		}

		private void OnShowDamageClicked(Widget widget)
		{
			bool flag = base.FlightUI.OnToggleDamageVisualizer();
			widget.FindWidget("show-damage-button").EnableClass("btn-primary", flag);
			base.FlightUI.ShowMessage("Damage Visualizer " + (flag ? "Enabled" : "Disabled"));
			throw new NotImplementedException("Damage visualizer apparently does not support URP yet.");
		}

		private void OnShowInstructionsClicked(Widget widget)
		{
			if (_craftInstructionsDialog != null)
			{
				CloseCraftInstructionsDialog();
				return;
			}
			AircraftData craft = FlightSceneScript.Instance.LocalPlayer?.CurrentOrPreviousAircraft?.Aircraft;
			ShowCraftInstructionsDialog(craft);
		}

		private void OnShowInstrumentsClicked(Widget widget)
		{
			_instrumentsVisible = !_instrumentsVisible;
			UpdateInstrumentsVisibility();
		}

		private void OnSlowMoClicked(Widget widget)
		{
			PauseManager.SetSlowMotion(enabled: true);
			UpdateTimeButtons();
			base.FlightUI.ShowMessage("Slow Motion Enabled");
		}

		private void OnSpawnAIClicked(Widget widget)
		{
			if (base.FlightUI.MultiplayerState != FlightUIScript.MultiplayerStateType.Client)
			{
				base.FlightUI.Flyouts.Selected = base.FlightUI.Flyouts.SpawnCraft;
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog("Only the host can spawn an AI craft.");
			}
		}

		private void OnStartServerClicked(Widget widget)
		{
			widget.AddClass("disabled");
			Game.Instance.NetworkGameManager.StartSteamHost(null);
		}

		private void OnToggleFlightGizmosClicked(Widget widget)
		{
			FlightSceneScript.Instance.FlightGizmos.Visible = !FlightSceneScript.Instance.FlightGizmos.Visible;
			widget.EnableClass("btn-primary", FlightSceneScript.Instance.FlightGizmos.Visible);
		}

		private void SetButtonEnabledStatesOnCraftLoad(bool enabled)
		{
			_buildButton.EnableClass("disabled", !enabled);
		}

		private void ShowCraftInstructionsDialog(AircraftData craft)
		{
			string text = craft?.Instructions;
			_lastInstructionsHash = text?.GetHashCode() ?? 0;
			_craftInstructionsDialog = Game.Instance.UserInterface.CreateDialog<CraftInstructionsScript>("Xml/Flight/CraftInstructionsDialog");
			_craftInstructionsDialog.Closed += delegate
			{
				_craftInstructionsDialog = null;
				UpdateCraftInstructionsButton();
			};
			_craftInstructionsDialog.ShowXmlModNotice(craft?.Tags?.Contains("XML Modded") == true);
			_craftInstructionsDialog.Text = text;
			UpdateCraftInstructionsButton();
		}

		private void UpdateCraftInstructionsButton()
		{
			base.Widget.FindWidget("craft-instructions-button").EnableClass("btn-primary", _craftInstructionsDialog != null);
		}

		private void UpdateInstrumentsVisibility()
		{
			base.FlightUI.InstrumentPanel.Widget.Visible = _instrumentsVisible;
			base.FlightUI.ActivationPanel.Widget.Visible = false;
			base.Widget.FindWidget("show-instruments-button").EnableClass("btn-primary", _instrumentsVisible);
		}

		private void UpdateTimeButtons()
		{
			Widget widget = base.Widget.FindWidget("time-slow-button");
			Widget widget2 = base.Widget.FindWidget("time-fast-button");
			Widget widget3 = base.Widget.FindWidget("time-normal-button");
			if (PauseManager.FastForwardEnabled)
			{
				widget.RemoveClass("btn-primary");
				widget2.AddClass("btn-primary");
				widget3.RemoveClass("btn-primary");
			}
			else if (PauseManager.SlowMotionEnabled)
			{
				widget.AddClass("btn-primary");
				widget2.RemoveClass("btn-primary");
				widget3.RemoveClass("btn-primary");
			}
			else
			{
				widget.RemoveClass("btn-primary");
				widget2.RemoveClass("btn-primary");
				widget3.AddClass("btn-primary");
			}
		}
	}
}
