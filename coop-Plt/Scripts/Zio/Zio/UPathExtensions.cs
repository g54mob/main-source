using System;
using System.Collections.Generic;
using System.IO;

namespace Zio
{
	public static class UPathExtensions
	{
		public static UPath ToRelative(this UPath path)
		{
			path.AssertNotNull();
			if (path.IsRelative)
			{
				return path;
			}
			if (!(path.FullName == "/"))
			{
				return new UPath(path.FullName.Substring(1), safe: true);
			}
			return UPath.Empty;
		}

		public static UPath ToAbsolute(this UPath path)
		{
			path.AssertNotNull();
			if (path.IsAbsolute)
			{
				return path;
			}
			if (!path.IsEmpty)
			{
				return UPath.Root / path;
			}
			return UPath.Root;
		}

		public static UPath GetDirectory(this UPath path)
		{
			path.AssertNotNull();
			string fullName = path.FullName;
			if (fullName == "/")
			{
				return default(UPath);
			}
			int num = fullName.LastIndexOf('/');
			if (num > 0)
			{
				return fullName.Substring(0, num);
			}
			if (num != 0)
			{
				return UPath.Empty;
			}
			return UPath.Root;
		}

		public static string GetFirstDirectory(this UPath path, out UPath remainingPath)
		{
			path.AssertNotNull();
			remainingPath = UPath.Empty;
			string fullName = path.FullName;
			int num = fullName.IndexOf('/', 1);
			string result;
			if (num < 0)
			{
				result = fullName.Substring(1, fullName.Length - 1);
			}
			else
			{
				result = fullName.Substring(1, num - 1);
				if (num + 1 < fullName.Length)
				{
					remainingPath = fullName.Substring(num + 1);
				}
			}
			return result;
		}

		public static List<string> Split(this UPath path)
		{
			path.AssertNotNull();
			string fullName = path.FullName;
			if (fullName == string.Empty)
			{
				return new List<string>();
			}
			List<string> list = new List<string>();
			int num = (path.IsAbsolute ? 1 : 0);
			int num2;
			while ((num2 = fullName.IndexOf('/', num)) >= 0)
			{
				if (num2 != 0)
				{
					list.Add(fullName.Substring(num, num2 - num));
				}
				num = num2 + 1;
			}
			if (num < fullName.Length)
			{
				list.Add(fullName.Substring(num, fullName.Length - num));
			}
			return list;
		}

		public static string GetName(this UPath path)
		{
			if (!path.IsNull)
			{
				return Path.GetFileName(path.FullName);
			}
			return null;
		}

		public static string? GetNameWithoutExtension(this UPath path)
		{
			if (!path.IsNull)
			{
				return Path.GetFileNameWithoutExtension(path.FullName);
			}
			return null;
		}

		public static string? GetExtensionWithDot(this UPath path)
		{
			if (!path.IsNull)
			{
				return Path.GetExtension(path.FullName);
			}
			return null;
		}

		public static UPath ChangeExtension(this UPath path, string extension)
		{
			return new UPath(Path.ChangeExtension(path.FullName, extension));
		}

		public static bool IsInDirectory(this UPath path, UPath directory, bool recursive)
		{
			path.AssertNotNull();
			directory.AssertNotNull("directory");
			if (path.IsAbsolute != directory.IsAbsolute)
			{
				throw new ArgumentException("Cannot mix absolute and relative paths", "directory");
			}
			string fullName = path.FullName;
			string fullName2 = directory.FullName;
			if (fullName.Length < fullName2.Length || !fullName.StartsWith(fullName2))
			{
				return false;
			}
			if (fullName.Length == fullName2.Length)
			{
				return true;
			}
			bool flag = fullName2[fullName2.Length - 1] == '/';
			if (!recursive)
			{
				int num = fullName.LastIndexOf('/');
				int num2 = fullName2.Length - (flag ? 1 : 0);
				if (num != num2)
				{
					return false;
				}
			}
			if (!flag)
			{
				if (fullName.Length > fullName2.Length)
				{
					return fullName[fullName2.Length] == '/';
				}
				return false;
			}
			return true;
		}

		public static UPath AssertNotNull(this UPath path, string name = "path")
		{
			if (path.FullName == null)
			{
				throw new ArgumentNullException(name);
			}
			return path;
		}

		public static UPath AssertAbsolute(this UPath path, string name = "path")
		{
			path.AssertNotNull(name);
			if (!path.IsAbsolute)
			{
				throw new ArgumentException($"Path `{path}` must be absolute", name);
			}
			return path.FullName;
		}
	}
}
