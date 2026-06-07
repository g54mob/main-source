using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Multiplayer.Events;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class PlayerListRowScript : WidgetScript
	{
		private NetworkedActivityState? _activityState;

		private bool _inDesigner;

		private TextWidget _pingLabel;

		private PlayerListScript _playerList;

		public FlightScenePlayer Player { get; private set; }

		private bool IsHost
		{
			get
			{
				FlightScenePlayer player = Player;
				if (player == null)
				{
					return false;
				}
				return player.NetworkPlayer.OwnerId == 0;
			}
		}

		public void InitializeRow(PlayerListScript playerList, FlightScenePlayer player)
		{
			Player = player;
			_playerList = playerList;
			Player.NetworkPlayer.NameChanged += OnPlayerNameChanged;
			Player.AircraftEntered += OnPlayerAircraftEntered;
			Player.AircraftExited += OnPlayerAircraftExited;
			_pingLabel = base.Widget.FindWidget<TextWidget>("ping");
			UpdateLabels();
		}

		public void SetSelected(bool selected)
		{
			base.Widget.EnableClass("list-item-selected", selected);
		}

		protected virtual void OnDestroy()
		{
			Player.NetworkPlayer.NameChanged -= OnPlayerNameChanged;
			Player.AircraftEntered -= OnPlayerAircraftEntered;
			Player.AircraftExited -= OnPlayerAircraftExited;
		}

		protected virtual void Update()
		{
			if (!IsHost && !Player.NetworkPlayer.IsNPC)
			{
				double clientRoundTripTime = FlightSceneScript.Instance.FlightSceneNetwork.ClientPing.GetClientRoundTripTime(Player.NetworkPlayer.OwnerId);
				_pingLabel.Text = $"{clientRoundTripTime * 1000.0:n0}ms";
			}
			if (_inDesigner != Player.NetworkPlayer.InDesigner || _activityState != Player.NetworkedActivity?.State)
			{
				UpdateLabels();
			}
		}

		private void OnClicked(Widget widget)
		{
			if (_playerList.SelectedRow != this)
			{
				_playerList.SelectedRow = this;
			}
			else
			{
				_playerList.SelectedRow = null;
			}
		}

		private void OnPlayerAircraftEntered(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			UpdateLabels();
		}

		private void OnPlayerAircraftExited(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			UpdateLabels();
		}

		private void OnPlayerNameChanged(object sender, NetworkPlayerNameChangedEventArgs e)
		{
			UpdateLabels();
		}

		private void UpdateLabels()
		{
			_inDesigner = Player.NetworkPlayer.InDesigner;
			TextWidget textWidget = base.Widget.FindWidget<TextWidget>("name");
			if (Player.NetworkPlayer.IsNPC)
			{
				_pingLabel.Text = "AI";
			}
			else if (IsHost)
			{
				_pingLabel.Text = "HOST";
			}
			textWidget.Text = Player?.NetworkPlayer?.Name ?? "Unknown";
			TextWidget textWidget2 = base.Widget.FindWidget<TextWidget>("aircraft");
			if (Player.NetworkPlayer.InDesigner)
			{
				textWidget2.Text = "In Designer";
			}
			else
			{
				AircraftData aircraftData = Player?.CurrentOrPreviousAircraft?.Aircraft;
				if (aircraftData != null)
				{
					textWidget2.Text = $"{StringUtility.ClampString(aircraftData.Name, 20)} ({aircraftData.Assembly.Parts.Count:n0} parts)";
				}
				else
				{
					textWidget2.Text = "No Aircraft";
				}
			}
			TextWidget textWidget3 = base.Widget.FindWidget<TextWidget>("activity");
			string text = string.Empty;
			_activityState = Player.NetworkedActivity?.State;
			if (_activityState.HasValue && (int)_activityState.Value < 5)
			{
				text = Player.NetworkedActivity?.Data.DisplayName ?? string.Empty;
			}
			textWidget3.Text = text;
		}
	}
}
