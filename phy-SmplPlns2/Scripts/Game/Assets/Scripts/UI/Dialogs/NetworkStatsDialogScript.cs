using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Multiplayer.Utils;
using FishNet.Managing;
using FishNet.Managing.Statistic;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Dialogs
{
	public class NetworkStatsDialogScript : PanelDialogScript
	{
		private class StatsRow
		{
			private readonly Queue<float> _inboundHistory;

			private readonly TextWidget _inboundText;

			private readonly Queue<float> _outboundHistory;

			private readonly TextWidget _outboundText;

			private readonly int _smoothingWindow;

			private readonly bool _useSmoothing;

			public Widget Row { get; }

			public StatsRow(Widget rowWidget, bool useSmoothing = false, int smoothingWindow = 30)
			{
				Row = rowWidget;
				_inboundText = rowWidget.FindWidget<TextWidget>("inbound");
				_outboundText = rowWidget.FindWidget<TextWidget>("outbound");
				_useSmoothing = useSmoothing;
				if (_useSmoothing)
				{
					_smoothingWindow = Mathf.Max(1, smoothingWindow);
					_inboundHistory = new Queue<float>(smoothingWindow);
					_outboundHistory = new Queue<float>(smoothingWindow);
				}
			}

			public void Update(float inboundBytes, float outboundBytes, float tickRate)
			{
				float num = inboundBytes;
				float num2 = outboundBytes;
				if (_useSmoothing)
				{
					_inboundHistory.Enqueue(inboundBytes);
					_outboundHistory.Enqueue(outboundBytes);
					while (_inboundHistory.Count > _smoothingWindow)
					{
						_inboundHistory.Dequeue();
					}
					while (_outboundHistory.Count > _smoothingWindow)
					{
						_outboundHistory.Dequeue();
					}
					num = _inboundHistory.Average();
					num2 = _outboundHistory.Average();
				}
				float bytes = num * tickRate;
				float bytes2 = num2 * tickRate;
				string text = NetworkTrafficStatistics.FormatBytesToLargest(bytes);
				string text2 = NetworkTrafficStatistics.FormatBytesToLargest(bytes2);
				_inboundText.Text = text + "/s";
				_outboundText.Text = text2 + "/s";
			}
		}

		private StatsRow _clientRow;

		private Widget _modeToggleButton;

		private NetworkEventHistory _networkEventHistory;

		private NetworkManager _networkManager;

		private Widget _pauseProfilerButton;

		private float _peakInbound;

		private float _peakOutbound;

		private StatsRow _peakRow;

		private NetworkProfilerWindow _profiler;

		private InputWidget _searchInput;

		private StatsRow _serverRow;

		[SerializeField]
		private int _smoothingWindow = 30;

		public override bool IsModal => false;

		public bool ProfilerVisible
		{
			get
			{
				return base.Widget.HasClass("profiler");
			}
			private set
			{
				base.Widget.EnableClass("profiler", value);
			}
		}

		public override void Close()
		{
			base.Close();
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_networkManager = Game.Instance.NetworkGameManager.NetworkManager;
			_clientRow = new StatsRow(widget.FindWidget("client-row"), useSmoothing: true, _smoothingWindow);
			_serverRow = new StatsRow(widget.FindWidget("server-row"), useSmoothing: true, _smoothingWindow);
			_peakRow = new StatsRow(widget.FindWidget("peak-row"));
			_networkEventHistory = base.gameObject.AddComponent<NetworkEventHistory>();
			_networkEventHistory.OnCorrectedTrafficUpdate += OnCorrectedTrafficUpdate;
			_profiler = widget.GetComponentInChildren<NetworkProfilerWindow>(includeInactive: true);
			_profiler.InitializeProfiler(_networkEventHistory);
			_pauseProfilerButton = widget.FindWidget("pause-profiler-button");
			_modeToggleButton = widget.FindWidget("toggle-mode-button");
			_searchInput = widget.FindWidget<InputWidget>("search-input");
			_searchInput.Input.onValueChanged.AddListener(delegate(string s)
			{
				_profiler.SearchText = s;
			});
			if (!_networkManager.IsServerStarted)
			{
				_serverRow.Row.Hide();
				_modeToggleButton.Hide();
			}
		}

		protected void OnDestroy()
		{
			_networkEventHistory.OnCorrectedTrafficUpdate -= OnCorrectedTrafficUpdate;
		}

		private void OnClearButtonClicked(Widget widget)
		{
			_profiler.ClearHistory();
		}

		private void OnCloseButtonClicked(Widget widget)
		{
			Close();
		}

		private void OnCorrectedTrafficUpdate(uint tick, ulong clientIn, ulong clientOut, ulong serverIn, ulong serverOut)
		{
			if (!_networkManager.IsClientStarted)
			{
				return;
			}
			float tickRate = (int)_networkManager.TimeManager.TickRate;
			_clientRow.Update(clientIn, clientOut, tickRate);
			_serverRow.Update(serverIn, serverOut, tickRate);
			_peakInbound = Mathf.Max(clientIn, serverIn, _peakInbound);
			_peakOutbound = Mathf.Max(clientOut, serverOut, _peakOutbound);
			_peakRow.Update(_peakInbound, _peakOutbound, tickRate);
			if (ProfilerVisible)
			{
				_pauseProfilerButton.EnableClass("btn-primary", !_profiler.IsPaused);
				bool flag = _networkEventHistory.CurrentMode == NetworkEventHistory.ProfilerMode.Server;
				_modeToggleButton.EnableClass("toggle-mode-button-server", flag);
				if (!string.IsNullOrEmpty(_profiler.SearchText))
				{
					base.Widget.FindWidget<TextWidget>("search-frames").Text = $"{_profiler.SearchResultsFrames}f";
					base.Widget.FindWidget<TextWidget>("search-messages").Text = $"{_profiler.SearchResultsMessages}m";
					base.Widget.FindWidget<TextWidget>("search-bytes").Text = NetworkTrafficStatistics.FormatBytesToLargest(_profiler.SearchResultsBytes) ?? "";
				}
				else
				{
					base.Widget.FindWidget<TextWidget>("search-frames").Text = string.Empty;
					base.Widget.FindWidget<TextWidget>("search-messages").Text = string.Empty;
					base.Widget.FindWidget<TextWidget>("search-bytes").Text = string.Empty;
				}
			}
		}

		private void OnNextTickButtonClicked(Widget widget)
		{
			_profiler.AdvanceFrame(1);
		}

		private void OnPeakClicked(Widget widget)
		{
			_peakOutbound = 0f;
			_peakInbound = 0f;
		}

		private void OnPrevTickButtonClicked(Widget widget)
		{
			_profiler.AdvanceFrame(-1);
		}

		private void OnToggleModeButtonClicked(Widget widget)
		{
			if (!(_networkEventHistory == null))
			{
				NetworkEventHistory.ProfilerMode mode = ((_networkEventHistory.CurrentMode == NetworkEventHistory.ProfilerMode.Client) ? NetworkEventHistory.ProfilerMode.Server : NetworkEventHistory.ProfilerMode.Client);
				_networkEventHistory.SetMode(mode);
				_profiler.ClearHistory();
			}
		}

		private void OnTogglePauseButtonClicked(Widget widget)
		{
			_profiler.IsPaused = !_profiler.IsPaused;
		}

		private void OnToggleProfilerButtonClicked(Widget widget)
		{
			ProfilerVisible = !ProfilerVisible;
			widget.EnableClass("btn-primary", ProfilerVisible);
		}
	}
}
