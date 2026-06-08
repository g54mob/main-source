using System;
using System.Collections.Generic;
using System.Text;

namespace Zio
{
	public readonly struct UPath : IEquatable<UPath>, IComparable<UPath>
	{
		private class InternalHelper
		{
			public readonly StringBuilder Builder;

			public readonly List<TextSlice> Slices;

			public InternalHelper()
			{
				Builder = new StringBuilder();
				Slices = new List<TextSlice>();
			}
		}

		private struct TextSlice
		{
			public readonly int Start;

			public readonly int End;

			public int Length => End - Start + 1;

			public TextSlice(int start, int end)
			{
				Start = start;
				End = end;
			}
		}

		private class ComparerCaseSensitive : IComparer<UPath>
		{
			public int Compare(UPath x, UPath y)
			{
				return string.Compare(x.FullName, y.FullName, StringComparison.Ordinal);
			}
		}

		private class ComparerIgnoreCase : IComparer<UPath>
		{
			public int Compare(UPath x, UPath y)
			{
				return string.Compare(x.FullName, y.FullName, StringComparison.OrdinalIgnoreCase);
			}
		}

		[ThreadStatic]
		private static InternalHelper? _internalHelperTls;

		public static readonly UPath Empty = new UPath(string.Empty, safe: true);

		public static readonly UPath Root = new UPath("/", safe: true);

		internal static readonly UPath Null = new UPath(null);

		public const char DirectorySeparator = '/';

		public static readonly IComparer<UPath> DefaultComparer = new ComparerCaseSensitive();

		public static readonly IComparer<UPath> DefaultComparerIgnoreCase = new ComparerIgnoreCase();

		private static InternalHelper InternalHelperTls => _internalHelperTls ?? (_internalHelperTls = new InternalHelper());

		public string FullName { get; }

		public bool IsNull => FullName == null;

		public bool IsEmpty => FullName == string.Empty;

		public bool IsAbsolute => FullName?.StartsWith("/") ?? false;

		public bool IsRelative => !IsAbsolute;

		public UPath(string path)
			: this(path, safe: false)
		{
		}

		internal UPath(string path, bool safe)
		{
			if (safe)
			{
				FullName = path;
				return;
			}
			FullName = ValidateAndNormalize(path, out string errorMessage);
			if (errorMessage == null)
			{
				return;
			}
			throw new ArgumentException(errorMessage, "path");
		}

		public static implicit operator UPath(string path)
		{
			return new UPath(path);
		}

		public static explicit operator string(UPath path)
		{
			return path.FullName;
		}

		public static UPath Combine(UPath path1, UPath path2)
		{
			if (path1.FullName == null)
			{
				throw new ArgumentNullException("path1");
			}
			if (path2.FullName == null)
			{
				throw new ArgumentNullException("path2");
			}
			if (path1.IsEmpty && path2.IsEmpty)
			{
				return Empty;
			}
			if (path2.IsAbsolute)
			{
				return path2;
			}
			StringBuilder builder = InternalHelperTls.Builder;
			if (!path1.IsEmpty)
			{
				builder.Append(path1.FullName);
				builder.Append('/');
			}
			if (!path2.IsEmpty)
			{
				builder.Append(path2.FullName);
			}
			try
			{
				string path3 = builder.ToString();
				builder.Length = 0;
				return new UPath(path3);
			}
			catch (ArgumentException innerException)
			{
				throw new ArgumentException($"Unable to combine path `{path1}` with `{path2}`", innerException);
			}
		}

		public static UPath Combine(UPath path1, UPath path2, UPath path3)
		{
			return Combine(Combine(path1, path2), path3);
		}

		public static UPath Combine(UPath path1, UPath path2, UPath path3, UPath path4)
		{
			return Combine(Combine(path1, path2), Combine(path3, path4));
		}

		public static UPath Combine(params UPath[] paths)
		{
			UPath uPath = paths[0];
			for (int i = 1; i < paths.Length; i++)
			{
				uPath = Combine(uPath, paths[i]);
			}
			return uPath;
		}

		public static UPath operator /(UPath path1, UPath path2)
		{
			return Combine(path1, path2);
		}

		public bool Equals(UPath other)
		{
			return string.Equals(FullName, other.FullName);
		}

		public override bool Equals(object obj)
		{
			if (obj is UPath other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return FullName?.GetHashCode() ?? 0;
		}

		public static bool operator ==(UPath left, UPath right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(UPath left, UPath right)
		{
			return !left.Equals(right);
		}

		public override string ToString()
		{
			return FullName;
		}

		public static bool TryParse(string path, out UPath pathInfo)
		{
			path = ValidateAndNormalize(path, out string errorMessage);
			pathInfo = ((errorMessage == null) ? new UPath(path, safe: true) : default(UPath));
			return errorMessage == null;
		}

		internal static StringBuilder GetSharedStringBuilder()
		{
			StringBuilder builder = InternalHelperTls.Builder;
			builder.Length = 0;
			return builder;
		}

		private static string? ValidateAndNormalize(string path, out string? errorMessage)
		{
			errorMessage = null;
			switch (path)
			{
			case null:
				return null;
			case "/":
			case "..":
			case ".":
				return path;
			case "\\":
				return "/";
			default:
			{
				InternalHelper internalHelperTls = InternalHelperTls;
				List<TextSlice> slices = internalHelperTls.Slices;
				slices.Clear();
				StringBuilder builder = internalHelperTls.Builder;
				builder.Length = 0;
				int num = 0;
				try
				{
					int i = 0;
					bool flag = false;
					int num2 = 0;
					for (; i < path.Length; i++)
					{
						char c = path[i];
						if (c == '.')
						{
							num2++;
						}
						if (c != '/' && c != '\\')
						{
							continue;
						}
						if (!flag && i + 1 == path.Length)
						{
							return path.Substring(0, path.Length - 1);
						}
						if (c == '\\')
						{
							flag = true;
						}
						int num3 = i - 1;
						for (i++; i < path.Length; i++)
						{
							c = path[i];
							if (c != '/' && c != '\\')
							{
								break;
							}
							flag = true;
						}
						if (num3 >= num || num3 == -1)
						{
							TextSlice item = new TextSlice(num, num3);
							slices.Add(item);
							if (item.Length == num2)
							{
								flag = true;
							}
						}
						num2 = ((c == '.') ? 1 : 0);
						num = i;
					}
					if (num < path.Length)
					{
						TextSlice item2 = new TextSlice(num, path.Length - 1);
						slices.Add(item2);
						if (item2.Length == num2)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						return path;
					}
					for (i = 0; i < slices.Count; i++)
					{
						TextSlice textSlice = slices[i];
						int length = textSlice.Length;
						if (length < 1 || path[textSlice.Start] != '.')
						{
							continue;
						}
						if (length == 1)
						{
							if (slices.Count > 1)
							{
								slices.RemoveAt(i--);
							}
						}
						else
						{
							if (path[textSlice.Start + 1] != '.')
							{
								continue;
							}
							if (length > 2)
							{
								bool flag2 = false;
								for (int j = textSlice.Start + 2; j <= textSlice.End; j++)
								{
									if (path[j] != '.')
									{
										flag2 = true;
										break;
									}
								}
								if (!flag2)
								{
									errorMessage = "The path `" + path + "` contains invalid dots `" + path.Substring(textSlice.Start, textSlice.Length) + "` while only `.` or `..` are supported";
									return string.Empty;
								}
							}
							else
							{
								if (i - 1 < 0)
								{
									continue;
								}
								TextSlice slice = slices[i - 1];
								if (!IsDotDot(slice, path))
								{
									if (slice.Length == 0)
									{
										errorMessage = "The path `" + path + "` cannot go to the parent (..) of a root path /";
										return string.Empty;
									}
									slices.RemoveAt(i--);
									slices.RemoveAt(i--);
								}
							}
						}
					}
					if (slices.Count == 1 && slices[0].Start == 0 && slices[0].End < 0)
					{
						return "/";
					}
					for (i = 0; i < slices.Count; i++)
					{
						TextSlice textSlice2 = slices[i];
						if (textSlice2.Length > 0)
						{
							builder.Append(path, textSlice2.Start, textSlice2.Length);
						}
						if (i + 1 < slices.Count)
						{
							builder.Append('/');
						}
					}
					return builder.ToString();
				}
				finally
				{
					slices.Clear();
					builder.Length = 0;
				}
			}
			}
		}

		private static bool IsDotDot(TextSlice slice, string path)
		{
			if (slice.Length != 2)
			{
				return false;
			}
			if (path[slice.Start] == '.')
			{
				return path[slice.End] == '.';
			}
			return false;
		}

		public int CompareTo(UPath other)
		{
			return string.Compare(FullName, other.FullName, StringComparison.Ordinal);
		}
	}
}
