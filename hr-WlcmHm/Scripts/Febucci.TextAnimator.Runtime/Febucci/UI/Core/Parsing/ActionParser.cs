using System;
using System.Text;
using Febucci.UI.Actions;

namespace Febucci.UI.Core.Parsing
{
	public sealed class ActionParser : TagParserBase
	{
		public ActionDatabase database;

		private ActionMarker[] _results;

		public ActionMarker[] results => _results;

		public ActionParser(char startSymbol, char closingSymbol, char endSymbol, ActionDatabase actionDatabase)
			: base(startSymbol, closingSymbol, endSymbol)
		{
			database = actionDatabase;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			_results = new ActionMarker[0];
			if ((bool)database)
			{
				database.BuildOnce();
			}
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (!database)
			{
				return false;
			}
			database.BuildOnce();
			int num = textInsideBrackets.IndexOf('=');
			string text = ((num == -1) ? textInsideBrackets : textInsideBrackets.Substring(0, num));
			text = text.ToLower();
			if (!database.ContainsKey(text))
			{
				return false;
			}
			ActionMarker actionMarker;
			if (num != -1)
			{
				string text2 = textInsideBrackets.Substring(num + 1);
				actionMarker = new ActionMarker(text, realTextIndex, internalOrder, text2.Replace(" ", "").Split(','));
			}
			else
			{
				actionMarker = new ActionMarker(text, realTextIndex, internalOrder, new string[0]);
			}
			Array.Resize(ref _results, _results.Length + 1);
			_results[_results.Length - 1] = actionMarker;
			return true;
		}
	}
}
