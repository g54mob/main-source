using System;
using System.ComponentModel;
using System.Globalization;
using Moq.Properties;

namespace Moq
{
	public readonly struct Times : IEquatable<Times>
	{
		private enum Kind
		{
			AtLeastOnce = 0,
			AtLeast = 1,
			AtMost = 2,
			AtMostOnce = 3,
			BetweenExclusive = 4,
			BetweenInclusive = 5,
			Exactly = 6,
			Once = 7,
			Never = 8
		}

		private readonly int from;

		private readonly int to;

		private readonly Kind kind;

		private Times(Kind kind, int from, int to)
		{
			this.from = from;
			this.to = to;
			this.kind = kind;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void Deconstruct(out int from, out int to)
		{
			if (kind == Kind.AtLeastOnce)
			{
				from = 1;
				to = int.MaxValue;
			}
			else
			{
				from = this.from;
				to = this.to;
			}
		}

		public static Times AtLeast(int callCount)
		{
			if (callCount < 1)
			{
				throw new ArgumentOutOfRangeException("callCount");
			}
			return new Times(Kind.AtLeast, callCount, int.MaxValue);
		}

		public static Times AtLeastOnce()
		{
			return new Times(Kind.AtLeastOnce, 1, int.MaxValue);
		}

		public static Times AtMost(int callCount)
		{
			if (callCount < 0)
			{
				throw new ArgumentOutOfRangeException("callCount");
			}
			return new Times(Kind.AtMost, 0, callCount);
		}

		public static Times AtMostOnce()
		{
			return new Times(Kind.AtMostOnce, 0, 1);
		}

		public static Times Between(int callCountFrom, int callCountTo, Range rangeKind)
		{
			if (rangeKind == Range.Exclusive)
			{
				if (callCountFrom <= 0 || callCountTo <= callCountFrom)
				{
					throw new ArgumentOutOfRangeException("callCountFrom");
				}
				if (callCountTo - callCountFrom == 1)
				{
					throw new ArgumentOutOfRangeException("callCountTo");
				}
				return new Times(Kind.BetweenExclusive, callCountFrom + 1, callCountTo - 1);
			}
			if (callCountFrom < 0 || callCountTo < callCountFrom)
			{
				throw new ArgumentOutOfRangeException("callCountFrom");
			}
			return new Times(Kind.BetweenInclusive, callCountFrom, callCountTo);
		}

		public static Times Exactly(int callCount)
		{
			if (callCount < 0)
			{
				throw new ArgumentOutOfRangeException("callCount");
			}
			return new Times(Kind.Exactly, callCount, callCount);
		}

		public static Times Never()
		{
			return new Times(Kind.Never, 0, 0);
		}

		public static Times Once()
		{
			return new Times(Kind.Once, 1, 1);
		}

		public bool Equals(Times other)
		{
			Times times = this;
			times.Deconstruct(out var num, out var num2);
			int num3 = num;
			int num4 = num2;
			times = other;
			times.Deconstruct(out num2, out num);
			int num5 = num2;
			int num6 = num;
			if (num3 == num5)
			{
				return num4 == num6;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Times other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			Times times = this;
			var (num3, num4) = (Times)(ref times);
			return num3.GetHashCode() ^ num4.GetHashCode();
		}

		public static bool operator ==(Times left, Times right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Times left, Times right)
		{
			return !left.Equals(right);
		}

		public override string ToString()
		{
			return kind switch
			{
				Kind.AtLeastOnce => "AtLeastOnce", 
				Kind.AtLeast => $"AtLeast({from})", 
				Kind.AtMost => $"AtMost({to})", 
				Kind.AtMostOnce => "AtMostOnce", 
				Kind.BetweenExclusive => $"Between({from - 1}, {to + 1}, Exclusive)", 
				Kind.BetweenInclusive => $"Between({from}, {to}, Inclusive)", 
				Kind.Exactly => $"Exactly({from})", 
				Kind.Once => "Once", 
				Kind.Never => "Never", 
				_ => throw new InvalidOperationException(), 
			};
		}

		internal string GetExceptionMessage(int callCount)
		{
			Times times = this;
			var (num3, num4) = (Times)(ref times);
			if (kind == Kind.BetweenExclusive)
			{
				num3--;
				num4++;
			}
			string format = kind switch
			{
				Kind.AtLeastOnce => Resources.NoMatchingCallsAtLeastOnce, 
				Kind.AtLeast => Resources.NoMatchingCallsAtLeast, 
				Kind.AtMost => Resources.NoMatchingCallsAtMost, 
				Kind.AtMostOnce => Resources.NoMatchingCallsAtMostOnce, 
				Kind.BetweenExclusive => Resources.NoMatchingCallsBetweenExclusive, 
				Kind.BetweenInclusive => Resources.NoMatchingCallsBetweenInclusive, 
				Kind.Exactly => Resources.NoMatchingCallsExactly, 
				Kind.Once => Resources.NoMatchingCallsOnce, 
				Kind.Never => Resources.NoMatchingCallsNever, 
				_ => throw new InvalidOperationException(), 
			};
			return string.Format(CultureInfo.CurrentCulture, format, num3, num4, callCount);
		}

		public bool Validate(int count)
		{
			Times times = this;
			var (num3, num4) = (Times)(ref times);
			if (num3 <= count)
			{
				return count <= num4;
			}
			return false;
		}
	}
}
