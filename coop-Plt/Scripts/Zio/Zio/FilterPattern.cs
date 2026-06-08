using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Zio
{
	public readonly struct FilterPattern
	{
		private static readonly char[] SpecialChars = new char[3] { '.', '*', '?' };

		private readonly string? _exactMatch;

		private readonly Regex? _regexMatch;

		public static FilterPattern Parse(string filter)
		{
			return new FilterPattern(filter);
		}

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

		public bool Match(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (_exactMatch == null)
			{
				if (_regexMatch != null)
				{
					return _regexMatch.IsMatch(fileName);
				}
				return true;
			}
			return _exactMatch == fileName;
		}

		public FilterPattern(string filter)
		{
			if (filter == null)
			{
				throw new ArgumentNullException("filter");
			}
			if (filter.IndexOf('/') >= 0)
			{
				throw new ArgumentException("Filter cannot contain directory parts.", "filter");
			}
			_exactMatch = null;
			_regexMatch = null;
			switch (filter)
			{
			case "*":
				return;
			case "*.*":
				return;
			}
			bool flag = false;
			int num = 0;
			StringBuilder stringBuilder = null;
			try
			{
				int num2;
				while ((num2 = filter.IndexOfAny(SpecialChars, num)) >= 0)
				{
					if (stringBuilder == null)
					{
						stringBuilder = UPath.GetSharedStringBuilder();
						stringBuilder.Append("^");
					}
					int num3 = num2 - num;
					if (num3 > 0)
					{
						string value = Regex.Escape(filter.Substring(num, num3));
						stringBuilder.Append(value);
					}
					char c = filter[num2];
					if (c == '.' && num2 == filter.Length - 2 && filter[num2 + 1] == '*')
					{
						flag = true;
						break;
					}
					stringBuilder.Append(c switch
					{
						'*' => ".*?", 
						'.' => "\\.", 
						_ => ".", 
					});
					num = num2 + 1;
				}
				if (stringBuilder == null)
				{
					_exactMatch = filter;
					return;
				}
				if (flag)
				{
					stringBuilder.Append("(\\.[^.]*)?");
				}
				else
				{
					int num4 = filter.Length - num;
					if (num4 > 0)
					{
						string value2 = Regex.Escape(filter.Substring(num, num4));
						stringBuilder.Append(value2);
					}
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
