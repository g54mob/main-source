using System.Collections.Generic;

namespace Google.Protobuf.Collections
{
	public static class ProtobufEqualityComparers
	{
		private class BitwiseDoubleEqualityComparerImpl : EqualityComparer<double>
		{
			public override bool Equals(double x, double y)
			{
				return false;
			}

			public override int GetHashCode(double obj)
			{
				return 0;
			}
		}

		private class BitwiseSingleEqualityComparerImpl : EqualityComparer<float>
		{
			public override bool Equals(float x, float y)
			{
				return false;
			}

			public override int GetHashCode(float obj)
			{
				return 0;
			}
		}

		private class BitwiseNullableDoubleEqualityComparerImpl : EqualityComparer<double?>
		{
			public override bool Equals(double? x, double? y)
			{
				return false;
			}

			public override int GetHashCode(double? obj)
			{
				return 0;
			}
		}

		private class BitwiseNullableSingleEqualityComparerImpl : EqualityComparer<float?>
		{
			public override bool Equals(float? x, float? y)
			{
				return false;
			}

			public override int GetHashCode(float? obj)
			{
				return 0;
			}
		}

		public static EqualityComparer<double> BitwiseDoubleEqualityComparer { get; }

		public static EqualityComparer<float> BitwiseSingleEqualityComparer { get; }

		public static EqualityComparer<double?> BitwiseNullableDoubleEqualityComparer { get; }

		public static EqualityComparer<float?> BitwiseNullableSingleEqualityComparer { get; }

		public static EqualityComparer<T> GetEqualityComparer<T>()
		{
			return null;
		}
	}
}
