using System;
using System.Text;

namespace Febucci.UI.Core.Parsing
{
	public class EventParser : TagParserBase
	{
		private const char eventSymbol = '?';

		private EventMarker[] _results;

		public EventMarker[] results => _results;

		public EventParser(char openingBracket, char closingBracket, char closingTagSymbol)
			: base(openingBracket, closingBracket, closingTagSymbol)
		{
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			_results = new EventMarker[0];
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (textInsideBrackets[0] != '?')
			{
				return false;
			}
			int num = textInsideBrackets.IndexOf('=');
			EventMarker eventMarker = ((num == -1) ? new EventMarker(textInsideBrackets.Substring(1), realTextIndex, internalOrder, new string[0]) : new EventMarker(textInsideBrackets.Substring(1, num - 1), parameters: textInsideBrackets.Substring(num + 1).Replace(" ", "").Split(','), index: realTextIndex, internalOrder: internalOrder));
			Array.Resize(ref _results, _results.Length + 1);
			_results[_results.Length - 1] = eventMarker;
			return true;
		}
	}
}
