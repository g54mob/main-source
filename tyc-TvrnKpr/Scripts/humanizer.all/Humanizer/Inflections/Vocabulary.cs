using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Humanizer.Inflections
{
	public class Vocabulary
	{
		private class Rule
		{
			private readonly Regex _regex;

			private readonly string _replacement;

			public Rule(string pattern, string replacement)
			{
			}

			public string Apply(string word)
			{
				return null;
			}
		}

		private readonly List<Rule> _plurals;

		private readonly List<Rule> _singulars;

		private readonly List<string> _uncountables;

		internal Vocabulary()
		{
		}

		public void AddIrregular(string singular, string plural, bool matchEnding = true)
		{
		}

		public void AddUncountable(string word)
		{
		}

		public void AddPlural(string rule, string replacement)
		{
		}

		public void AddSingular(string rule, string replacement)
		{
		}

		public string Pluralize(string word, bool inputIsKnownToBeSingular = true)
		{
			return null;
		}

		public string Singularize(string word, bool inputIsKnownToBePlural = true, bool skipSimpleWords = false)
		{
			return null;
		}

		private string ApplyRules(IList<Rule> rules, string word, bool skipFirstRule)
		{
			return null;
		}

		private bool IsUncountable(string word)
		{
			return false;
		}

		private string MatchUpperCase(string word, string replacement)
		{
			return null;
		}
	}
}
