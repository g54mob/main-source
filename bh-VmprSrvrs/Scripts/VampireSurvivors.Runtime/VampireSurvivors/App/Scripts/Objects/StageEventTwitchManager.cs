using System.Collections.Generic;
using JetBrains.Annotations;
using Lexone.UnityTwitchChat;
using TMPro;
using VampireSurvivors.App.UI.Twitch;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.Scripts.Objects
{
	[UsedImplicitly]
	public class StageEventTwitchManager : StageEventManager
	{
		private bool _active;

		private float _panelWidth;

		private float _panelHeight;

		private float _panelHideX;

		private float _panelX;

		private float _panelY;

		private int _twitchLimitCount;

		private Timer _twitchTimer;

		private List<int> _twitchOptionCounter;

		private List<Event> _mediaEvents;

		private List<TextMeshProUGUI> _twitchOptions;

		private readonly List<Event> _goodEvents;

		private readonly List<Event> _neutralEvents;

		private readonly List<Event> _badEvents;

		private TwitchStageEventsPanel EventsPanel => null;

		public override void Init(Stage stage)
		{
		}

		public void ShowTwitchUI()
		{
		}

		public void HideTwitchUI()
		{
		}

		public void QuickShow()
		{
		}

		public void QuickHide()
		{
		}

		public bool TriggerEvents()
		{
			return false;
		}

		private void EnableTwitch()
		{
		}

		private void DisableTwitch()
		{
		}

		private void ProcessMessage(Chatter chatter)
		{
		}

		private void IncreaseTwitchOption(int num, string username)
		{
		}

		private int CalculateChoice()
		{
			return 0;
		}

		private string GetEventName(Event stageEvent)
		{
			return null;
		}
	}
}
