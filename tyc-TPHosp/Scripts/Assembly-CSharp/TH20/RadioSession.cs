using System.Collections.Generic;

namespace TH20
{
	public class RadioSession
	{
		private readonly RadioSessionDefinition _definition;

		private readonly RadioDJDefinition _dj;

		private int _currentQuoteIndex = -1;

		private bool _hasPlayedIntroQuote;

		private List<RadioDJQuote> _quoteList;

		public RadioSessionDefinition Defintion => _definition;

		public RadioDJDefinition DJ => _dj;

		public int CurrentQuoteIndex => _currentQuoteIndex;

		public int TotalQuotesInSession => _quoteList.Count;

		public RadioSession(RadioSessionDefinition definition, RadioDJDefinition djDefinition)
		{
			_dj = djDefinition;
			_definition = definition;
			_quoteList = new List<RadioDJQuote>(_definition.Quotes);
			if (_definition.Shuffle)
			{
				_quoteList.Shuffle(RandomUtils.GlobalRandomInstance);
			}
		}

		public void RestoreFromSave()
		{
			if (_quoteList != null)
			{
				_quoteList.RemoveAll((RadioDJQuote item) => item == null);
			}
		}

		public RadioDJQuote GetNextQuoteInSession()
		{
			if (!_hasPlayedIntroQuote)
			{
				_hasPlayedIntroQuote = true;
				if (_definition.IntroQuote != null && _definition.IntroQuote.LocalisedClip != null)
				{
					return _definition.IntroQuote;
				}
			}
			_currentQuoteIndex++;
			if (_quoteList.Count <= _currentQuoteIndex)
			{
				return null;
			}
			return _quoteList[_currentQuoteIndex];
		}
	}
}
