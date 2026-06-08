using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TwitchLib.Client.Models
{
	public class MessageEmoteCollection
	{
		public delegate bool EmoteFilterDelegate(MessageEmote emote);

		private readonly SortedList<string, MessageEmote> _emoteList;

		private const string BasePattern = "(\\b{0}\\b)";

		private string _currentPattern;

		private Regex _regex;

		private readonly EmoteFilterDelegate _preferredFilter;

		private string CurrentPattern
		{
			get
			{
				return _currentPattern;
			}
			set
			{
				if (_currentPattern == null || !_currentPattern.Equals(value))
				{
					_currentPattern = value;
					PatternChanged = true;
				}
			}
		}

		private Regex CurrentRegex
		{
			get
			{
				if (PatternChanged)
				{
					if (CurrentPattern != null)
					{
						_regex = new Regex(string.Format(CurrentPattern, ""));
						PatternChanged = false;
					}
					else
					{
						_regex = null;
					}
				}
				return _regex;
			}
		}

		private bool PatternChanged { get; set; }

		private EmoteFilterDelegate CurrentEmoteFilter { get; set; } = AllInclusiveEmoteFilter;

		public MessageEmoteCollection()
		{
			_emoteList = new SortedList<string, MessageEmote>();
			_preferredFilter = AllInclusiveEmoteFilter;
		}

		public MessageEmoteCollection(EmoteFilterDelegate preferredFilter)
			: this()
		{
			_preferredFilter = preferredFilter;
		}

		public void Add(MessageEmote emote)
		{
			if (!_emoteList.TryGetValue(emote.Text, out var _))
			{
				_emoteList.Add(emote.Text, emote);
			}
			if (CurrentPattern == null)
			{
				CurrentPattern = $"(\\b{emote.EscapedText}\\b)";
			}
			else
			{
				CurrentPattern = CurrentPattern + "|" + $"(\\b{emote.EscapedText}\\b)";
			}
		}

		public void Merge(IEnumerable<MessageEmote> emotes)
		{
			IEnumerator<MessageEmote> enumerator = emotes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Add(enumerator.Current);
			}
			enumerator.Dispose();
		}

		public void Remove(MessageEmote emote)
		{
			if (_emoteList.ContainsKey(emote.Text))
			{
				_emoteList.Remove(emote.Text);
				string text = "(^\\(\\\\b" + emote.EscapedText + "\\\\b\\)\\|?)";
				string text2 = "(\\|\\(\\\\b" + emote.EscapedText + "\\\\b\\))";
				string text3 = Regex.Replace(CurrentPattern, text + "|" + text2, "");
				CurrentPattern = (text3.Equals("") ? null : text3);
			}
		}

		public void RemoveAll()
		{
			_emoteList.Clear();
			CurrentPattern = null;
		}

		public string ReplaceEmotes(string originalMessage, EmoteFilterDelegate del = null)
		{
			if (CurrentRegex == null)
			{
				return originalMessage;
			}
			if (del != null && del != CurrentEmoteFilter)
			{
				CurrentEmoteFilter = del;
			}
			string result = CurrentRegex.Replace(originalMessage, GetReplacementString);
			CurrentEmoteFilter = _preferredFilter;
			return result;
		}

		public static bool AllInclusiveEmoteFilter(MessageEmote emote)
		{
			return true;
		}

		public static bool TwitchOnlyEmoteFilter(MessageEmote emote)
		{
			return emote.Source == MessageEmote.EmoteSource.Twitch;
		}

		private string GetReplacementString(Match m)
		{
			if (!_emoteList.ContainsKey(m.Value))
			{
				return m.Value;
			}
			MessageEmote messageEmote = _emoteList[m.Value];
			return CurrentEmoteFilter(messageEmote) ? messageEmote.ReplacementString : m.Value;
		}
	}
}
