using System;
using System.Collections.Generic;
using System.Linq;

namespace NSubstitute.ReceivedExtensions
{
	public abstract class Quantity
	{
		private class ExactQuantity : Quantity
		{
			private readonly int _number;

			public ExactQuantity(int number)
			{
				_number = number;
			}

			public override bool Matches<T>(IEnumerable<T> items)
			{
				return _number == items.Count();
			}

			public override bool RequiresMoreThan<T>(IEnumerable<T> items)
			{
				return _number > items.Count();
			}

			public override string Describe(string singularNoun, string pluralNoun)
			{
				return $"exactly {_number} {((_number == 1) ? singularNoun : pluralNoun)}";
			}

			public bool Equals(ExactQuantity other)
			{
				if (other == null)
				{
					return false;
				}
				if (this == other)
				{
					return true;
				}
				return other._number == _number;
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (this == obj)
				{
					return true;
				}
				if (obj.GetType() != typeof(ExactQuantity))
				{
					return false;
				}
				return Equals((ExactQuantity)obj);
			}

			public override int GetHashCode()
			{
				return _number;
			}
		}

		private class AnyNonZeroQuantity : Quantity
		{
			public override bool Matches<T>(IEnumerable<T> items)
			{
				return items.Any();
			}

			public override bool RequiresMoreThan<T>(IEnumerable<T> items)
			{
				return !items.Any();
			}

			public override string Describe(string singularNoun, string pluralNoun)
			{
				return $"a {singularNoun}";
			}

			public bool Equals(AnyNonZeroQuantity other)
			{
				return other != null;
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (this == obj)
				{
					return true;
				}
				if (obj.GetType() != typeof(AnyNonZeroQuantity))
				{
					return false;
				}
				return Equals((AnyNonZeroQuantity)obj);
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		private class NoneQuantity : Quantity
		{
			public override bool Matches<T>(IEnumerable<T> items)
			{
				return !items.Any();
			}

			public override bool RequiresMoreThan<T>(IEnumerable<T> items)
			{
				return false;
			}

			public override string Describe(string singularNoun, string pluralNoun)
			{
				return "no " + pluralNoun;
			}

			public bool Equals(NoneQuantity other)
			{
				return other != null;
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (this == obj)
				{
					return true;
				}
				if (obj.GetType() != typeof(NoneQuantity))
				{
					return false;
				}
				return Equals((NoneQuantity)obj);
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		private class RangeQuantity : Quantity
		{
			private readonly int minInclusive;

			private readonly int maxInclusive;

			public RangeQuantity(int minInclusive, int maxInclusive)
			{
				if (minInclusive < 0)
				{
					throw new ArgumentOutOfRangeException("minInclusive", string.Format("{0} must be >= 0, but was {1}.", "minInclusive", minInclusive));
				}
				if (maxInclusive <= minInclusive)
				{
					throw new ArgumentOutOfRangeException("maxInclusive", string.Format("{0} must be greater than {1} (was {2}, required > {3}).", "maxInclusive", "minInclusive", maxInclusive, minInclusive));
				}
				this.minInclusive = minInclusive;
				this.maxInclusive = maxInclusive;
			}

			public override string Describe(string singularNoun, string pluralNoun)
			{
				return $"between {minInclusive} and {maxInclusive} (inclusive) {((maxInclusive == 1) ? singularNoun : pluralNoun)}";
			}

			public override bool Matches<T>(IEnumerable<T> items)
			{
				int num = items.Count();
				if (num >= minInclusive)
				{
					return num <= maxInclusive;
				}
				return false;
			}

			public override bool RequiresMoreThan<T>(IEnumerable<T> items)
			{
				return items.Count() < minInclusive;
			}
		}

		public static Quantity Exactly(int number)
		{
			if (number != 0)
			{
				return new ExactQuantity(number);
			}
			return None();
		}

		public static Quantity AtLeastOne()
		{
			return new AnyNonZeroQuantity();
		}

		public static Quantity None()
		{
			return new NoneQuantity();
		}

		public static Quantity Within(int minInclusive, int maxInclusive)
		{
			return new RangeQuantity(minInclusive, maxInclusive);
		}

		public abstract bool Matches<T>(IEnumerable<T> items);

		public abstract bool RequiresMoreThan<T>(IEnumerable<T> items);

		public abstract string Describe(string singularNoun, string pluralNoun);
	}
}
