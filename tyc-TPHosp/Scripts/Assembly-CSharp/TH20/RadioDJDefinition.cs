using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	public class RadioDJDefinition
	{
		public string Name;

		public List<SharedInstance<RadioSessionDefinition>> Sessions;

		public void VerifySessions()
		{
			foreach (SharedInstance<RadioSessionDefinition> session in Sessions)
			{
				RadioSessionDefinition instance = session.Instance;
				if (instance.IntroQuote != null && instance.IntroQuote.LocalisedClip != null)
				{
					VerifyQuoteFadeLength(instance.IntroQuote);
				}
				foreach (RadioDJQuote quote in instance.Quotes)
				{
					VerifyQuoteFadeLength(quote);
				}
			}
		}

		private void VerifyQuoteFadeLength(RadioDJQuote quote)
		{
			while (quote != null)
			{
				quote = quote.OverrideNextQuote;
			}
		}

		public RadioSessionDefinition GetSession(int index, out int nextBookmark, out bool wasReset)
		{
			wasReset = false;
			if (index >= Sessions.Count)
			{
				wasReset = true;
				nextBookmark = 1;
				return Sessions[0].Instance;
			}
			nextBookmark = index + 1;
			return Sessions[index].Instance;
		}
	}
}
