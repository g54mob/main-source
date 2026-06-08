using System;
using System.IO;
using NUnit.Framework.Internal;

namespace NUnit.Framework.Constraints
{
	public abstract class PathConstraint : StringConstraint
	{
		private const char WindowsDirectorySeparatorChar = '\\';

		private const char NonWindowsDirectorySeparatorChar = '/';

		private static readonly char[] DirectorySeparatorChars = new char[2] { '\\', '/' };

		public PathConstraint RespectCase
		{
			get
			{
				caseInsensitive = false;
				return this;
			}
		}

		protected PathConstraint(string expected)
			: base(expected)
		{
			base.expected = expected;
			caseInsensitive = Path.DirectorySeparatorChar == '\\';
		}

		protected override string GetStringRepresentation()
		{
			return string.Format("<{0} \"{1}\" {2}>", DisplayName.ToLower(), expected, caseInsensitive ? "ignorecase" : "respectcase");
		}

		protected string Canonicalize(string path)
		{
			if (Path.DirectorySeparatorChar != Path.AltDirectorySeparatorChar)
			{
				path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			}
			string text = "";
			string text2 = path;
			char directorySeparatorChar;
			foreach (char c in text2)
			{
				if (c != '\\' && c != '/')
				{
					break;
				}
				string text3 = text;
				directorySeparatorChar = Path.DirectorySeparatorChar;
				text = text3 + directorySeparatorChar;
			}
			string[] array = path.Split(DirectorySeparatorChars, StringSplitOptions.RemoveEmptyEntries);
			int num = 0;
			bool flag = false;
			string[] array2 = array;
			foreach (string text4 in array2)
			{
				if (!(text4 == ".") && (text4 == null || text4.Length != 0))
				{
					if (text4 == "..")
					{
						flag = true;
						if (num > 0)
						{
							num--;
						}
					}
					else
					{
						if (flag)
						{
							array[num] = text4;
						}
						num++;
					}
				}
				else
				{
					flag = true;
				}
			}
			string text5 = text;
			directorySeparatorChar = Path.DirectorySeparatorChar;
			return text5 + string.Join(directorySeparatorChar.ToString(), array, 0, num);
		}

		protected bool IsSubPath(string path1, string path2)
		{
			int length = path1.Length;
			int length2 = path2.Length;
			if (length >= length2)
			{
				return false;
			}
			if (!StringUtil.StringsEqual(path1, path2.Substring(0, length), caseInsensitive))
			{
				return false;
			}
			if (path2[length - 1] != Path.DirectorySeparatorChar)
			{
				return path2[length] == Path.DirectorySeparatorChar;
			}
			return true;
		}
	}
}
