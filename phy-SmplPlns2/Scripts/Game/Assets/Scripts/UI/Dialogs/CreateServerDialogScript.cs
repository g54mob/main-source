using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.Lobbies;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Dialogs
{
	public class CreateServerDialogScript : PanelDialogScript
	{
		public const int MaxPrivateServerPlayers = 16;

		public const int MaxPublicServerPlayers = 10;

		public const int MaxServerNameLength = 50;

		private ILobbyManager _lobbyManager;

		private NumericSpinnerControl _maxPlayersSpinner;

		private ToggleControl _peacefulModeToggle;

		private InputWidget _serverNameInput;

		private TextInputControl _serverPasswordInput;

		private EnumSpinnerControl<LobbyType> _serverTypeSpinner;

		private ILobbyManager LobbyManager
		{
			get
			{
				return _lobbyManager;
			}
			set
			{
				_ = _lobbyManager;
				_lobbyManager = value;
				_ = _lobbyManager;
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			LobbyManager = Game.Instance.NetworkGameManager.SteamLobbyManager;
			_serverNameInput = base.Widget.FindWidget<InputWidget>("server-name-input");
			_serverNameInput.Input.characterLimit = 50;
			_serverPasswordInput = new TextInputControl(base.Widget.FindWidget<Widget>("server-password-text"));
			_serverPasswordInput.InputField.Input.inputType = TMP_InputField.InputType.Password;
			_serverPasswordInput.InputField.Placeholder.text = null;
			_maxPlayersSpinner = new NumericSpinnerControl(base.Widget.FindWidget("max-players-spinner"));
			_maxPlayersSpinner.MinValue = 2f;
			_maxPlayersSpinner.MaxValue = 10f;
			_maxPlayersSpinner.StepSize = 1f;
			_maxPlayersSpinner.Value = 8f;
			_serverTypeSpinner = new EnumSpinnerControl<LobbyType>(base.Widget.FindWidget("server-type-spinner"));
			_serverTypeSpinner.Values.Clear();
			_serverTypeSpinner.Values.Add(LobbyType.Public);
			_serverTypeSpinner.Values.Add(LobbyType.FriendsOnly);
			_serverTypeSpinner.Values.Add(LobbyType.Private);
			EnumSpinnerControl<LobbyType> serverTypeSpinner = _serverTypeSpinner;
			serverTypeSpinner.OnValueChanged = (OnValueChanged<LobbyType>)Delegate.Combine(serverTypeSpinner.OnValueChanged, (OnValueChanged<LobbyType>)delegate(LobbyType oldValue, LobbyType newValue)
			{
				_maxPlayersSpinner.Visible = newValue == LobbyType.Public;
				_serverPasswordInput.Visible = newValue == LobbyType.Public;
			});
			_peacefulModeToggle = new ToggleControl(base.Widget.FindWidget("peaceful-mode-toggle"));
			_peacefulModeToggle.Toggle.IsOn = FlightSceneScript.IsPeacefulMode;
			_peacefulModeToggle.Toggle.ValueChanged += delegate(bool x)
			{
				FlightSceneScript.IsPeacefulMode = x;
			};
			_serverTypeSpinner.Value = LobbyType.Public;
		}

		protected virtual void OnDestroy()
		{
			LobbyManager = null;
		}

		private void OnCancelClicked(Widget widget)
		{
			Close();
		}

		private void OnCreateClicked(Widget widget)
		{
			if (ValidateInput())
			{
				int maxMembers = ((_serverTypeSpinner.Value == LobbyType.Public) ? ((int)_maxPlayersSpinner.Value) : 16);
				LobbyManager.CreateLobby(_serverTypeSpinner.Value, maxMembers, _serverNameInput.Text, _serverPasswordInput.InputField.Text);
				Debug.Log("Creating server");
			}
		}

		private void ShowMessage(string message)
		{
			TextWidget textWidget = base.Widget.FindWidget<TextWidget>("status-message");
			if (!string.IsNullOrWhiteSpace(message))
			{
				textWidget.Visible = true;
				textWidget.Text = message;
			}
			else
			{
				textWidget.Visible = false;
			}
		}

		private bool ValidateInput()
		{
			string text = ValidateServerName(_serverNameInput.Text);
			if (text != null)
			{
				ShowMessage(text);
				return false;
			}
			if (_maxPlayersSpinner.Value < 2f || _maxPlayersSpinner.Value > 10f)
			{
				ShowMessage($"Ensure max players is between 2 and {10}");
				return false;
			}
			ShowMessage(null);
			return true;
		}

		private string ValidateServerName(string serverName)
		{
			if (string.IsNullOrWhiteSpace(serverName) || serverName.Length < 3)
			{
				return $"Server name must be at least {3} characters long";
			}
			if (serverName.Length > 100)
			{
				return $"Server name must be less than {100} characters long";
			}
			if (!BadWordDetector.IsTextClean(serverName))
			{
				return "The server name is sketch. Please try a different one.";
			}
			return null;
		}
	}
}
