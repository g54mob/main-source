using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Sentry.Internal.Extensions
{
	internal static class MiscExtensions
	{
		private static readonly TimeSpan MaxTimeout = TimeSpan.FromMilliseconds(2147483647.0);

		public static TOut Pipe<TIn, TOut>(this TIn input, Func<TIn, TOut> pipe)
		{
			return pipe(input);
		}

		public static T? NullIfDefault<T>(this T value) where T : struct
		{
			if (EqualityComparer<T>.Default.Equals(value, default(T)))
			{
				return null;
			}
			return value;
		}

		public static string ToHexString(this long l, bool upperCase = false)
		{
			return "0x" + l.ToString("x", CultureInfo.InvariantCulture);
		}

		public static string ToHexString(this byte[] bytes, bool upperCase = false)
		{
			return new ReadOnlySpan<byte>(bytes).ToHexString(upperCase);
		}

		public static string ToHexString(this Span<byte> bytes, bool upperCase = false)
		{
			return ((ReadOnlySpan<byte>)bytes).ToHexString(upperCase);
		}

		public static string ToHexString(this ReadOnlySpan<byte> bytes, bool upperCase = false)
		{
			StringBuilder stringBuilder = new StringBuilder(bytes.Length * 2);
			string text = (upperCase ? "X2" : "x2");
			ReadOnlySpan<byte> readOnlySpan = bytes;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				byte b = readOnlySpan[i];
				stringBuilder.Append(b.ToString(text, CultureInfo.InvariantCulture));
			}
			return stringBuilder.ToString();
		}

		public static void CancelAfterSafe(this CancellationTokenSource cts, TimeSpan timeout)
		{
			if (timeout == TimeSpan.Zero)
			{
				cts.Cancel();
			}
			else if (timeout > MaxTimeout)
			{
				cts.CancelAfter(Timeout.InfiniteTimeSpan);
			}
			else
			{
				cts.CancelAfter(timeout);
			}
		}

		public static bool IsNull(this object? o)
		{
			return o == null;
		}

		public static void Add<TKey, TValue>(this ICollection<KeyValuePair<TKey, TValue>> collection, TKey key, TValue value)
		{
			collection.Add(new KeyValuePair<TKey, TValue>(key, value));
		}

		internal static string GetRawMessage(this AggregateException exception)
		{
			string message = exception.Message;
			Exception innerException = exception.InnerException;
			if (innerException != null)
			{
				int num = message.IndexOf(" (" + innerException.Message + ")", StringComparison.Ordinal);
				if (num > 0)
				{
					return message.Substring(0, num);
				}
			}
			return message;
		}
	}
}
