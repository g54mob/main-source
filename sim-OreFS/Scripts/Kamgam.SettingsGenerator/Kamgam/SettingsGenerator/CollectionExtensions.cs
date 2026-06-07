using System;
using System.Collections;

namespace Kamgam.SettingsGenerator
{
	public static class CollectionExtensions
	{
		public static bool IsNull(this string text)
		{
			return string.IsNullOrEmpty(text);
		}

		public static bool IsNull(this ICollection list)
		{
			return list == null;
		}

		public static bool IsNullOrEmpty(this ICollection list)
		{
			if (list != null)
			{
				return list.Count == 0;
			}
			return true;
		}

		public static bool IsNullOrEmpty(this IEnumerable source)
		{
			if (source != null)
			{
				{
					IEnumerator enumerator = source.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							_ = enumerator.Current;
							return false;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			return true;
		}

		public static bool IsIndexOutOfBounds(this ICollection list, int index)
		{
			if (index >= 0)
			{
				return index >= list.Count;
			}
			return true;
		}
	}
}
