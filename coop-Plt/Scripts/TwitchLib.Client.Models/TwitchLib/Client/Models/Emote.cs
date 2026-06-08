namespace TwitchLib.Client.Models
{
	public class Emote
	{
		public string Id { get; }

		public string Name { get; }

		public int StartIndex { get; }

		public int EndIndex { get; }

		public string ImageUrl { get; }

		public Emote(string emoteId, string name, int emoteStartIndex, int emoteEndIndex)
		{
			Id = emoteId;
			Name = name;
			StartIndex = emoteStartIndex;
			EndIndex = emoteEndIndex;
			ImageUrl = "https://static-cdn.jtvnw.net/emoticons/v1/" + emoteId + "/1.0";
		}
	}
}
