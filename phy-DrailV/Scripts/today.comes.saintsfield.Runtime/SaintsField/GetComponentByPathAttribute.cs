using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using SaintsField.Utils;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class GetComponentByPathAttribute : GetByXPathAttribute
	{
		public enum Locate
		{
			Child = 0,
			Descendant = 1,
			Root = 2
		}

		public struct Token
		{
			public Locate Locate;

			public string Node;

			public string Index;
		}

		private static readonly Regex ContentSquareBracket = new Regex("([^[\\]]*)\\[([^\\[\\]]+)\\]");

		public readonly IReadOnlyList<IReadOnlyList<Token>> Paths;

		public readonly IReadOnlyList<string> RawPaths;

		public readonly bool ForceResign;

		public readonly bool ResignButton = true;

		public GetComponentByPathAttribute(string path, params string[] paths)
		{
			RawPaths = paths.Prepend(path).ToArray();
			Paths = ((IEnumerable<string>)RawPaths).Select((Func<string, IReadOnlyList<Token>>)((string each) => ParsePath(each).ToArray())).ToArray();
			ParseOptions(SaintsFieldConfigUtil.GetComponentByPathExp(EXP.NoAutoResign | EXP.NoPicker));
			ParseXPaths(paths.Prepend(path).Select(TranslatePath).ToArray());
		}

		public GetComponentByPathAttribute(EXP config, string path, params string[] paths)
		{
			ParseOptions(config);
			ParseXPaths(paths.Prepend(path).Select(TranslatePath).ToArray());
		}

		public GetComponentByPathAttribute(EGetComp config, string path, params string[] paths)
			: this(TranslateConfig(config), path, paths)
		{
			ForceResign = config.HasFlagFast(EGetComp.ForceResign);
			ResignButton = !config.HasFlagFast(EGetComp.NoResignButton);
			RawPaths = paths.Prepend(path).ToArray();
			Paths = ((IEnumerable<string>)RawPaths).Select((Func<string, IReadOnlyList<Token>>)((string each) => ParsePath(each).ToArray())).ToArray();
		}

		private static string TranslatePath(string path)
		{
			if (path.StartsWith("///"))
			{
				return "scene:://" + path.Substring(3);
			}
			if (path.StartsWith("//"))
			{
				return "scene::/" + path.Substring(2);
			}
			if (path.StartsWith("/"))
			{
				return "scene::/" + path.Substring(1);
			}
			return path;
		}

		private static EXP TranslateConfig(EGetComp config)
		{
			EXP eXP = EXP.NoPicker;
			if (!config.HasFlagFast(EGetComp.ForceResign))
			{
				eXP |= EXP.NoAutoResignToValue;
				eXP |= EXP.NoAutoResignToNull;
			}
			if (config.HasFlagFast(EGetComp.NoResignButton))
			{
				eXP |= EXP.NoResignButton;
			}
			return eXP;
		}

		private static IEnumerable<Token> ParsePath(string path)
		{
			string input;
			if (path.StartsWith("/"))
			{
				Match match = Regex.Match(path, "^/([^/]+)");
				string text = "*";
				string index = "";
				string sub = path.Substring(1);
				if (match.Success)
				{
					string value = match.Groups[1].Value;
					Match match2 = ContentSquareBracket.Match(value);
					if (match2.Success)
					{
						text = match2.Groups[1].Value;
						index = match2.Groups[2].Value.Trim();
					}
					else
					{
						text = value;
					}
					if (text == ".")
					{
						text = "*";
					}
					sub = path.Substring(match.Value.Length);
				}
				yield return new Token
				{
					Locate = Locate.Root,
					Node = text,
					Index = index
				};
				input = (sub.StartsWith("/") ? sub : ("/" + sub));
			}
			else
			{
				input = "/" + path;
			}
			MatchCollection matchCollection = Regex.Matches(input, "(//?)([^/]+)");
			foreach (Match item in matchCollection)
			{
				string value2 = item.Groups[1].Value;
				string value3 = item.Groups[2].Value;
				string index2 = string.Empty;
				Match match3 = ContentSquareBracket.Match(value3);
				if (match3.Success)
				{
					value3 = match3.Groups[1].Value;
					index2 = match3.Groups[2].Value.Trim();
				}
				Locate locate;
				if (!(value2 == "//"))
				{
					if (!(value2 == "/"))
					{
						throw new ArgumentOutOfRangeException("slash", value2, null);
					}
					locate = Locate.Child;
				}
				else
				{
					locate = Locate.Descendant;
				}
				yield return new Token
				{
					Locate = locate,
					Node = value3,
					Index = index2
				};
			}
		}
	}
}
