using System.Collections.Generic;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public class RadioStatus : MustCallDestroy
	{
		[DontSave]
		private RadioConfig _config;

		[DontSave]
		private DynamicPlaylistManager _dynamicPlaylistManager;

		private readonly List<RadioDJDefinition> _djCycle = new List<RadioDJDefinition>();

		private readonly Dictionary<RadioDJDefinition, int> _djSessionBookmarks = new Dictionary<RadioDJDefinition, int>();

		private RadioSession _session;

		private int _currentSongIndex;

		private int _jingleCountdown;

		private RadioDJQuote _lastQuote;

		private Dictionary<RadioDJDefinition, List<RadioSessionDefinition>> _djSessionHistory = new Dictionary<RadioDJDefinition, List<RadioSessionDefinition>>();

		public RadioDJDefinition CurrentDJ
		{
			get
			{
				if (_session == null)
				{
					return null;
				}
				return _session.DJ;
			}
		}

		public RadioStatus(RadioConfig config, DynamicPlaylistManager dynamicPlaylistManager)
		{
			_config = config;
			_dynamicPlaylistManager = dynamicPlaylistManager;
			VerifyData();
			ResetJingleCountdown();
		}

		public void RestoreFromSave(RadioConfig config, DynamicPlaylistManager dynamicPlaylistManager)
		{
			_config = config;
			_dynamicPlaylistManager = dynamicPlaylistManager;
			if (_djSessionHistory == null)
			{
				_djSessionHistory = new Dictionary<RadioDJDefinition, List<RadioSessionDefinition>>();
			}
			if (_session != null)
			{
				_session.RestoreFromSave();
			}
			VerifyData();
		}

		private void VerifyData()
		{
			foreach (SharedInstance<RadioDJDefinition> dJ in _config.DJs)
			{
				dJ.Instance.VerifySessions();
			}
		}

		public void NotifyAudioSourceSongStarted(AudioSource audioSource, RadioSong radioSong)
		{
			_dynamicPlaylistManager.NotifyRadioSongStarted(audioSource, radioSong);
		}

		public void NotifyAudioSourceSongFinishing(AudioSource audioSource, RadioSong radioSong)
		{
			_dynamicPlaylistManager.NotifyRadioSongFinishing(audioSource, radioSong);
		}

		public void NotifyAudioSourceSongFinished(AudioSource audioSource, RadioSong radioSong)
		{
			_dynamicPlaylistManager.NotifyRadioSongFinished(audioSource, radioSong);
		}

		public RadioSong GetNextSong()
		{
			return _dynamicPlaylistManager.GetNextRadioSong();
		}

		public RadioDJQuote GetNextQuote()
		{
			RadioDJQuote nextQuoteInternal = GetNextQuoteInternal();
			nextQuoteInternal.Session = _session;
			_lastQuote = nextQuoteInternal;
			return nextQuoteInternal;
		}

		private RadioDJQuote GetNextQuoteInternal()
		{
			if (_lastQuote != null && _lastQuote.OverrideNextQuote != null)
			{
				return _lastQuote.OverrideNextQuote;
			}
			_jingleCountdown--;
			if (_jingleCountdown <= 0)
			{
				return GetRandomJingle();
			}
			if (_session != null)
			{
				RadioDJQuote nextQuoteInSession = _session.GetNextQuoteInSession();
				if (nextQuoteInSession != null)
				{
					return nextQuoteInSession;
				}
			}
			GetNextRadioSession();
			if (_session != null)
			{
				RadioDJQuote nextQuoteInSession2 = _session.GetNextQuoteInSession();
				if (nextQuoteInSession2 != null)
				{
					return nextQuoteInSession2;
				}
			}
			return null;
		}

		private void GetNextRadioSession()
		{
			if (_djCycle.Count <= 0)
			{
				GenerateNextDJCycle();
			}
			RadioDJDefinition radioDJDefinition = _djCycle[0];
			_djCycle.RemoveAt(0);
			_djSessionBookmarks.TryGetValue(radioDJDefinition, out var value);
			List<RadioSessionDefinition> list = RecordSessionHistory();
			RadioSessionDefinition session;
			int nextBookmark;
			while (true)
			{
				session = radioDJDefinition.GetSession(value, out nextBookmark, out var wasReset);
				if (list == null)
				{
					break;
				}
				if (wasReset)
				{
					list.Clear();
				}
				if (!list.Contains(session))
				{
					break;
				}
				value = nextBookmark;
			}
			_session = new RadioSession(session, radioDJDefinition);
			_djSessionBookmarks[radioDJDefinition] = nextBookmark;
		}

		private void GenerateNextDJCycle()
		{
			foreach (SharedInstance<RadioDJDefinition> dJ in _config.DJs)
			{
				_djCycle.Add(dJ.Instance);
			}
			if (_djCycle.Count > 1)
			{
				_djCycle.Shuffle(RandomUtils.GlobalRandomInstance);
				if (_session == null || _djCycle[0] == _session.DJ)
				{
					int index = RandomUtils.GlobalRandomInstance.Next(1, _djCycle.Count);
					RadioDJDefinition item = _djCycle[0];
					_djCycle.RemoveAt(0);
					_djCycle.Insert(index, item);
				}
			}
		}

		private RadioDJQuote GetRandomJingle()
		{
			ResetJingleCountdown();
			int index = RandomUtils.GlobalRandomInstance.Next(0, _config.Jingles.Count);
			return _config.Jingles[index];
		}

		private void ResetJingleCountdown()
		{
			_jingleCountdown = RandomUtils.GlobalRandomInstance.Next((int)_config.JingleFrequencyMin, (int)_config.JingleFrequencyMax);
		}

		public bool IsLineInjectionAllowed()
		{
			if (_lastQuote == null)
			{
				return false;
			}
			if (_lastQuote.OverrideNextQuote != null)
			{
				return false;
			}
			if (_session == null)
			{
				return false;
			}
			if (_session.CurrentQuoteIndex >= _session.TotalQuotesInSession - 1)
			{
				return false;
			}
			if (_session.CurrentQuoteIndex == 0)
			{
				return false;
			}
			return true;
		}

		private List<RadioSessionDefinition> RecordSessionHistory()
		{
			if (_session == null)
			{
				return null;
			}
			_djSessionHistory.TryGetValue(_session.DJ, out var value);
			if (value == null)
			{
				value = new List<RadioSessionDefinition>();
			}
			value.Add(_session.Defintion);
			return value;
		}
	}
}
