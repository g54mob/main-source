using System.Collections.Generic;
using Febucci.UI.Effects;

namespace Febucci.UI.Core.Parsing
{
	public class AnimationParser<T> : TagParserBase where T : AnimationScriptableBase
	{
		public Database<T> database;

		private VisibilityMode visibilityMode;

		private char middleSymbol;

		private const char middleSymbolDefault = '\n';

		private Dictionary<string, AnimationRegion> _results;

		public AnimationRegion[] results => null;

		public AnimationParser(char startSymbol, char closingSymbol, char endSymbol, VisibilityMode visibilityMode, Database<T> database)
		{
		}

		public AnimationParser(char startSymbol, char closingSymbol, char middleSymbol, char endSymbol, VisibilityMode visibilityMode, Database<T> database)
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
