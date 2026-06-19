using System;

namespace TH20
{
	public class RadioDJQuote : RadioPlaylistItem
	{
		public RadioDJQuote OverrideNextQuote;

		[NonSerialized]
		public RadioSession Session;
	}
}
