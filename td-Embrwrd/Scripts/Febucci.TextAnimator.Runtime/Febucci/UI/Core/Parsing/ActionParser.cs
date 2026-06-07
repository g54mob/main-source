using Febucci.UI.Actions;

namespace Febucci.UI.Core.Parsing
{
	public sealed class ActionParser : TagParserBase
	{
		public ActionDatabase database;

		private ActionMarker[] _results;

		public ActionMarker[] results => null;

		public ActionParser(char startSymbol, char closingSymbol, char endSymbol, ActionDatabase actionDatabase)
		{
		}

		protected override void OnInitialize()
		{
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, int realTextIndex, int internalOrder)
		{
			return false;
		}
	}
}
