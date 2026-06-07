using System;

namespace MiscUtil.Extensions
{
	public static class ObjectExt
	{
		public static void ThrowIfNull<T>(this T data, string name) where T : class
		{
			if (data == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		public static void ThrowIfNull<T>(this T data) where T : class
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
		}
	}
}
