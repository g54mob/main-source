using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;

namespace Sentry
{
	public readonly struct SpanId : IEquatable<SpanId>, ISentryJsonSerializable
	{
		private static readonly char[] HexChars = new char[16]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'a', 'b', 'c', 'd', 'e', 'f'
		};

		private static readonly RandomValuesFactory Random = new SynchronizedRandomValuesFactory();

		private readonly long _value;

		public static readonly SpanId Empty = new SpanId(0L);

		private long GetValue()
		{
			return _value;
		}

		public SpanId(string value)
		{
			long.TryParse(value, NumberStyles.HexNumber, null, out _value);
		}

		public SpanId(long value)
		{
			_value = value;
		}

		public bool Equals(SpanId other)
		{
			return GetValue().Equals(other.GetValue());
		}

		public override bool Equals(object? obj)
		{
			if (obj is SpanId other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return StringComparer.Ordinal.GetHashCode(_value);
		}

		public override string ToString()
		{
			long value = _value;
			return value.ToString("x8");
		}

		public static SpanId Create()
		{
			byte[] array = new byte[8];
			Random.NextBytes(array);
			return new SpanId(BitConverter.ToInt64(array, 0));
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? _)
		{
			Span<byte> span = stackalloc byte[8];
			Unsafe.As<byte, long>(ref span[0]) = _value;
			Span<char> span2 = stackalloc char[16];
			for (int num = span.Length - 1; num >= 0; num--)
			{
				byte b = span[num];
				span2[(span.Length - 1 - num) * 2] = HexChars[b >> 4];
				span2[(span.Length - 1 - num) * 2 + 1] = HexChars[b & 0xF];
			}
			writer.WriteStringValue(span2);
		}

		public static SpanId Parse(string value)
		{
			return new SpanId(value);
		}

		public static SpanId FromJson(JsonElement json)
		{
			string value = json.GetString();
			if (string.IsNullOrWhiteSpace(value))
			{
				return Empty;
			}
			return Parse(value);
		}

		public static bool operator ==(SpanId left, SpanId right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(SpanId left, SpanId right)
		{
			return !(left == right);
		}

		public static implicit operator string(SpanId id)
		{
			return id.ToString();
		}
	}
}
