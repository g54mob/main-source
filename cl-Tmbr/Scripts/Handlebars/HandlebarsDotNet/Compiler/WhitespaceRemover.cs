using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HandlebarsDotNet.Compiler.Lexer;

namespace HandlebarsDotNet.Compiler
{
	internal class WhitespaceRemover : TokenConverter
	{
		private static readonly Regex MatchLastStartsWithWhitespace = new Regex("^[ \\t]*(\\r?\\n|$)", RegexOptions.Compiled);

		private static readonly Regex MatchStartsWithWhitespace = new Regex("^[ \\t]*\\r?\\n", RegexOptions.Compiled);

		private static readonly Regex TrimStartRegex = new Regex("^[ \\t]*\\r?\\n?", RegexOptions.Compiled);

		private static readonly Regex MatchFirstEndsWithWhitespace = new Regex("(^|\\r?\\n)\\s*?$", RegexOptions.Compiled);

		private static readonly Regex MatchEndsWithWhitespace = new Regex("\\r?\\n\\s*?$");

		private static readonly Regex TrimEndRegex = new Regex("[ \\t]+\\z", RegexOptions.Compiled);

		private static readonly WhitespaceRemover Remover = new WhitespaceRemover();

		public static IEnumerable<object> Remove(IEnumerable<object> sequence)
		{
			return Remover.ConvertTokens(sequence);
		}

		private WhitespaceRemover()
		{
		}

		private static IList<object> ToList(IEnumerable<object> sequence)
		{
			return (sequence as IList<object>) ?? sequence.ToArray();
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IList<object> list = ToList(sequence);
			ProcessTokens(list);
			return list;
		}

		private static void ProcessTokens(IList<object> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (!(list[i] is StatementExpression statementExpression))
				{
					continue;
				}
				if (statementExpression.TrimBefore)
				{
					TrimBefore(list, i, multipleLines: true);
				}
				if (statementExpression.TrimAfter)
				{
					TrimAfter(list, i, multipleLines: true);
				}
				if (IsStandalone(statementExpression) && IsNextWhitespace(list, i) && IsPrevWhitespace(list, i))
				{
					if (!statementExpression.TrimBefore)
					{
						TrimBefore(list, i, multipleLines: false);
					}
					if (!statementExpression.TrimAfter)
					{
						TrimAfter(list, i, multipleLines: false);
					}
				}
			}
		}

		private static bool IsNextWhitespace(IList<object> list, int index)
		{
			if (index >= list.Count - 1)
			{
				return true;
			}
			if (!(list[index + 1] is StaticToken staticToken))
			{
				return false;
			}
			return ((index == list.Count - 2) ? MatchLastStartsWithWhitespace : MatchStartsWithWhitespace).IsMatch(staticToken.Original);
		}

		private static void TrimAfter(IList<object> list, int index, bool multipleLines)
		{
			if (index < list.Count - 1 && list[index + 1] is StaticToken token)
			{
				list[index + 1] = TrimStart(token, multipleLines);
			}
		}

		private static Token TrimStart(StaticToken token, bool multipleLines)
		{
			string value = (multipleLines ? token.Value.TrimStart() : TrimStartRegex.Replace(token.Value, string.Empty));
			return token.GetModifiedToken(value);
		}

		private static bool IsPrevWhitespace(IList<object> list, int index)
		{
			if (index < 1)
			{
				return true;
			}
			if (!(list[index - 1] is StaticToken staticToken))
			{
				return false;
			}
			return ((index == 1) ? MatchFirstEndsWithWhitespace : MatchEndsWithWhitespace).IsMatch(staticToken.Original);
		}

		private static void TrimBefore(IList<object> list, int index, bool multipleLines)
		{
			if (index >= 1 && list[index - 1] is StaticToken token)
			{
				list[index - 1] = TrimEnd(token, multipleLines);
			}
		}

		private static Token TrimEnd(StaticToken token, bool multipleLines)
		{
			string value = (multipleLines ? token.Value.TrimEnd() : TrimEndRegex.Replace(token.Value, string.Empty));
			return token.GetModifiedToken(value);
		}

		private static bool IsStandalone(StatementExpression statement)
		{
			if (!(statement.Body is CommentExpression) && !(statement.Body is PartialExpression))
			{
				return IsBlockStatement(statement);
			}
			return true;
		}

		private static bool IsBlockStatement(StatementExpression statement)
		{
			if (!IsBlockHelperOrInversion(statement.Body as HelperExpression))
			{
				return IsSectionOrClosingNode(statement.Body as PathExpression);
			}
			return true;
		}

		private static bool IsSectionOrClosingNode(PathExpression pathExpression)
		{
			if (pathExpression != null)
			{
				return pathExpression.Path.IndexOfAny(new char[3] { '#', '/', '^' }) == 0;
			}
			return false;
		}

		private static bool IsBlockHelperOrInversion(HelperExpression helperExpression)
		{
			if (helperExpression == null)
			{
				return false;
			}
			if (!helperExpression.HelperName.StartsWith("#") && !helperExpression.HelperName.StartsWith("^"))
			{
				return helperExpression.HelperName == "else";
			}
			return true;
		}
	}
}
