using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace TwitchLib.Client.Models
{
	public class MessageEmote
	{
		public delegate string ReplaceEmoteDelegate(MessageEmote caller);

		public enum EmoteSource
		{
			Twitch = 0,
			FrankerFaceZ = 1,
			BetterTwitchTv = 2
		}

		public enum EmoteSize
		{
			Small = 0,
			Medium = 1,
			Large = 2
		}

		public static readonly ReadOnlyCollection<string> TwitchEmoteUrls = new ReadOnlyCollection<string>(new string[3] { "https://static-cdn.jtvnw.net/emoticons/v1/{0}/1.0", "https://static-cdn.jtvnw.net/emoticons/v1/{0}/2.0", "https://static-cdn.jtvnw.net/emoticons/v1/{0}/3.0" });

		public static readonly ReadOnlyCollection<string> FrankerFaceZEmoteUrls = new ReadOnlyCollection<string>(new string[3] { "//cdn.frankerfacez.com/emoticon/{0}/1", "//cdn.frankerfacez.com/emoticon/{0}/2", "//cdn.frankerfacez.com/emoticon/{0}/4" });

		public static readonly ReadOnlyCollection<string> BetterTwitchTvEmoteUrls = new ReadOnlyCollection<string>(new string[3] { "//cdn.betterttv.net/emote/{0}/1x", "//cdn.betterttv.net/emote/{0}/2x", "//cdn.betterttv.net/emote/{0}/3x" });

		private readonly string _id;

		private readonly string _text;

		private readonly string _escapedText;

		private readonly EmoteSource _source;

		private readonly EmoteSize _size;

		public string Id => _id;

		public string Text => _text;

		public EmoteSource Source => _source;

		public EmoteSize Size => _size;

		public string ReplacementString => ReplacementDelegate(this);

		public static ReplaceEmoteDelegate ReplacementDelegate { get; set; } = SourceMatchingReplacementText;

		public string EscapedText => _escapedText;

		public static string SourceMatchingReplacementText(MessageEmote caller)
		{
			int size = (int)caller.Size;
			return caller.Source switch
			{
				EmoteSource.BetterTwitchTv => string.Format(BetterTwitchTvEmoteUrls[size], caller.Id), 
				EmoteSource.FrankerFaceZ => string.Format(FrankerFaceZEmoteUrls[size], caller.Id), 
				EmoteSource.Twitch => string.Format(TwitchEmoteUrls[size], caller.Id), 
				_ => caller.Text, 
			};
		}

		public MessageEmote(string id, string text, EmoteSource source = EmoteSource.Twitch, EmoteSize size = EmoteSize.Small, ReplaceEmoteDelegate replacementDelegate = null)
		{
			_id = id;
			_text = text;
			_escapedText = Regex.Escape(text);
			_source = source;
			_size = size;
			if (replacementDelegate != null)
			{
				ReplacementDelegate = replacementDelegate;
			}
		}
	}
}
