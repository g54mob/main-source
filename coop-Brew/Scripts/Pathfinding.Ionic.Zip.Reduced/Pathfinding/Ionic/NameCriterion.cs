using System.Text.RegularExpressions;
using Pathfinding.Ionic.Zip;

namespace Pathfinding.Ionic
{
	internal class NameCriterion : SelectionCriterion
	{
		private Regex _re;

		private string _regexString;

		internal ComparisonOperator Operator;

		private string _MatchingFileSpec;

		internal virtual string MatchingFileSpec
		{
			set
			{
			}
		}

		public override string ToString()
		{
			return null;
		}

		internal override bool Evaluate(string filename)
		{
			return false;
		}

		private bool _Evaluate(string fullpath)
		{
			return false;
		}

		internal override bool Evaluate(ZipEntry entry)
		{
			return false;
		}
	}
}
