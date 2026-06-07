using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Statistics
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics")]
	public class Bucket : IComparable<Bucket>, ICloneable
	{
		private sealed class PointComparer : IComparer<Bucket>
		{
			public int Compare(Bucket bkt1, Bucket bkt2)
			{
				if (!bkt2.IsSinglePoint)
				{
					return -bkt2.Contains(bkt1.UpperBound);
				}
				return -bkt1.Contains(bkt2.UpperBound);
			}
		}

		private static readonly PointComparer Comparer = new PointComparer();

		[DataMember(Order = 1)]
		public double LowerBound { get; set; }

		[DataMember(Order = 2)]
		public double UpperBound { get; set; }

		[DataMember(Order = 3)]
		public double Count { get; set; }

		public double Width => UpperBound - LowerBound;

		private bool IsSinglePoint => double.IsNaN(Count);

		public static IComparer<Bucket> DefaultPointComparer => Comparer;

		public Bucket(double lowerBound, double upperBound, double count = 0.0)
		{
			if (lowerBound > upperBound)
			{
				throw new ArgumentException("The upper bound must be at least as large as the lower bound.");
			}
			if (count < 0.0)
			{
				throw new ArgumentOutOfRangeException("count", "Value must be positive.");
			}
			LowerBound = lowerBound;
			UpperBound = upperBound;
			Count = count;
		}

		public Bucket(double targetValue)
		{
			LowerBound = targetValue;
			UpperBound = targetValue;
			Count = double.NaN;
		}

		public object Clone()
		{
			return new Bucket(LowerBound, UpperBound, Count);
		}

		public int Contains(double x)
		{
			if (LowerBound < x)
			{
				if (UpperBound >= x)
				{
					return 0;
				}
				return 1;
			}
			return -1;
		}

		public int CompareTo(Bucket bucket)
		{
			if (UpperBound > bucket.LowerBound && LowerBound < bucket.LowerBound)
			{
				throw new ArgumentException("The two arguments can't be compared (maybe they are part of a partial ordering?)");
			}
			if (UpperBound.Equals(bucket.UpperBound) && LowerBound.Equals(bucket.LowerBound))
			{
				return 0;
			}
			if (bucket.UpperBound <= LowerBound)
			{
				return 1;
			}
			return -1;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Bucket))
			{
				return false;
			}
			Bucket bucket = (Bucket)obj;
			if (LowerBound.Equals(bucket.LowerBound) && UpperBound.Equals(bucket.UpperBound))
			{
				return Count.AlmostEqual(bucket.Count);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return LowerBound.GetHashCode() ^ UpperBound.GetHashCode() ^ Count.GetHashCode();
		}

		public override string ToString()
		{
			return "(" + LowerBound + ";" + UpperBound + "] = " + Count;
		}
	}
}
