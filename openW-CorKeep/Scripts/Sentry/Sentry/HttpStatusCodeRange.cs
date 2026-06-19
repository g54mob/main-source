using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sentry
{
	public readonly struct HttpStatusCodeRange
	{
		public int Start { get; init; }

		public int End { get; init; }

		public HttpStatusCodeRange(int statusCode)
		{
			Start = statusCode;
			End = statusCode;
		}

		public HttpStatusCodeRange(int start, int end)
		{
			if (start > end)
			{
				throw new ArgumentOutOfRangeException("start", "Range start must be after range end");
			}
			Start = start;
			End = end;
		}

		public static implicit operator HttpStatusCodeRange((int Start, int End) range)
		{
			return new HttpStatusCodeRange(range.Start, range.End);
		}

		public static implicit operator HttpStatusCodeRange(int statusCode)
		{
			return new HttpStatusCodeRange(statusCode);
		}

		public static implicit operator HttpStatusCodeRange(HttpStatusCode statusCode)
		{
			return new HttpStatusCodeRange((int)statusCode);
		}

		public static implicit operator HttpStatusCodeRange((HttpStatusCode start, HttpStatusCode end) range)
		{
			return new HttpStatusCodeRange((int)range.start, (int)range.end);
		}

		public bool Contains(int statusCode)
		{
			if (statusCode >= Start)
			{
				return statusCode <= End;
			}
			return false;
		}

		public bool Contains(HttpStatusCode statusCode)
		{
			return Contains((int)statusCode);
		}

		[CompilerGenerated]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("HttpStatusCodeRange");
			stringBuilder.Append(" { ");
			if (PrintMembers(stringBuilder))
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			builder.Append("Start = ");
			builder.Append(Start.ToString());
			builder.Append(", End = ");
			builder.Append(End.ToString());
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(HttpStatusCodeRange left, HttpStatusCodeRange right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(HttpStatusCodeRange left, HttpStatusCodeRange right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return EqualityComparer<int>.Default.GetHashCode(Start) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(End);
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			if (obj is HttpStatusCodeRange)
			{
				return Equals((HttpStatusCodeRange)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public bool Equals(HttpStatusCodeRange other)
		{
			if (EqualityComparer<int>.Default.Equals(Start, other.Start))
			{
				return EqualityComparer<int>.Default.Equals(End, other.End);
			}
			return false;
		}
	}
}
