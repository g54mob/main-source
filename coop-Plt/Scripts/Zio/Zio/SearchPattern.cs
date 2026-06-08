using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Zio
{
	public struct SearchPattern
	{
		private static readonly char[] SpecialChars = new char[2] { '?', '*' };

		private readonly string? _exactMatch;

		private readonly Regex? _regexMatch;

		public bool Match(UPath path)
		{
			path.AssertNotNull();
			string name = path.GetName();
			if (_exactMatch == null)
			{
				if (_regexMatch != null)
				{
					return _regexMatch.IsMatch(name);
				}
				return true;
			}
			return _exactMatch == name;
		}

		public bool Match(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (_exactMatch == null)
			{
				if (_regexMatch != null)
				{
					return _regexMatch.IsMatch(name);
				}
				return true;
			}
			return _exactMatch == name;
		}

		public static SearchPattern Parse(ref UPath path, ref string searchPattern)
		{
			return new SearchPattern(ref path, ref searchPattern);
		}

		public static void Normalize(ref UPath path, ref string searchPattern)
		{
			Parse(ref path, ref searchPattern);
		}

		private SearchPattern(ref UPath path, ref string searchPattern)
		{
			path.AssertAbsolute();
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			_exactMatch = null;
			_regexMatch = null;
			if (searchPattern == "*")
			{
				return;
			}
			if (searchPattern.StartsWith("/"))
			{
				throw new ArgumentException("The search pattern `" + searchPattern + "` cannot start by an absolute path `/`");
			}
			searchPattern = searchPattern.Replace('\\', '/');
			if (searchPattern.IndexOf('/') > 0)
			{
				UPath path2 = new UPath(searchPattern);
				UPath directory = path2.GetDirectory();
				if (!directory.IsNull && !directory.IsEmpty)
				{
					path /= directory;
				}
				searchPattern = path2.GetName();
				if (searchPattern == "*")
				{
					return;
				}
			}
			int num = 0;
			StringBuilder stringBuilder = null;
			try
			{
				int num2;
				while ((num2 = searchPattern.IndexOfAny(SpecialChars, num)) >= 0)
				{
					if (stringBuilder == null)
					{
						stringBuilder = UPath.GetSharedStringBuilder();
						stringBuilder.Append("^");
					}
					int num3 = num2 - num;
					if (num3 > 0)
					{
						string value = Regex.Escape(searchPattern.Substring(num, num3));
						stringBuilder.Append(value);
					}
					string value2 = ((searchPattern[num2] == '*') ? "[^/]*" : "[^/]");
					stringBuilder.Append(value2);
					num = num2 + 1;
				}
				if (stringBuilder == null)
				{
					_exactMatch = searchPattern;
					return;
				}
				int num4 = searchPattern.Length - num;
				if (num4 > 0)
				{
					string value3 = Regex.Escape(searchPattern.Substring(num, num4));
					stringBuilder.Append(value3);
				}
				stringBuilder.Append("$");
				string pattern = stringBuilder.ToString();
				_regexMatch = new Regex(pattern);
			}
			finally
			{
				if (stringBuilder != null)
				{
					stringBuilder.Length = 0;
				}
			}
		}
	}
}
