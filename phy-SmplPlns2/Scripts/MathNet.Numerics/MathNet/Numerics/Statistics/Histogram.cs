using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MathNet.Numerics.Statistics
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics")]
	public class Histogram
	{
		[DataMember(Order = 1)]
		private readonly List<Bucket> _buckets;

		[DataMember(Order = 2)]
		private bool _areBucketsSorted;

		public double LowerBound
		{
			get
			{
				LazySort();
				return _buckets[0].LowerBound;
			}
		}

		public double UpperBound
		{
			get
			{
				LazySort();
				return _buckets[_buckets.Count - 1].UpperBound;
			}
		}

		public Bucket this[int n]
		{
			get
			{
				LazySort();
				return (Bucket)_buckets[n].Clone();
			}
		}

		public int BucketCount => _buckets.Count;

		public double DataCount
		{
			get
			{
				double num = 0.0;
				for (int i = 0; i < BucketCount; i++)
				{
					num += this[i].Count;
				}
				return num;
			}
		}

		public Histogram()
		{
			_buckets = new List<Bucket>();
			_areBucketsSorted = true;
		}

		public Histogram(IEnumerable<double> data, int nbuckets)
			: this()
		{
			if (nbuckets < 1)
			{
				throw new ArgumentOutOfRangeException("data", "The number of bins in a histogram should be at least 1.");
			}
			double num = data.Minimum();
			double num2 = (data.Maximum() - num) / (double)nbuckets;
			if (double.IsNaN(num2))
			{
				throw new ArgumentException("Data must contain at least one entry.", "data");
			}
			double num3 = num + num2;
			AddBucket(new Bucket(num.Decrement(), num3));
			for (int i = 1; i < nbuckets; i++)
			{
				AddBucket(new Bucket(num3, num3 = num + (double)(i + 1) * num2));
			}
			AddData(data);
		}

		public Histogram(IEnumerable<double> data, int nbuckets, double lower, double upper)
			: this()
		{
			if (lower > upper)
			{
				throw new ArgumentOutOfRangeException("upper", "The histogram lower bound must be smaller than the upper bound.");
			}
			if (nbuckets < 1)
			{
				throw new ArgumentOutOfRangeException("nbuckets", "The number of bins in a histogram should be at least 1.");
			}
			double num = (upper - lower) / (double)nbuckets;
			for (int i = 0; i < nbuckets; i++)
			{
				AddBucket(new Bucket(lower + (double)i * num, lower + (double)(i + 1) * num));
			}
			AddData(data);
		}

		public void AddData(double d)
		{
			LazySort();
			if (d <= LowerBound)
			{
				_buckets[0].LowerBound = d.Decrement();
				_buckets[0].Count++;
			}
			else if (d > UpperBound)
			{
				_buckets[BucketCount - 1].UpperBound = d;
				_buckets[BucketCount - 1].Count++;
			}
			else
			{
				_buckets[GetBucketIndexOf(d)].Count++;
			}
		}

		public void AddData(IEnumerable<double> data)
		{
			foreach (double datum in data)
			{
				AddData(datum);
			}
		}

		public void AddBucket(Bucket bucket)
		{
			_buckets.Add(bucket);
			_areBucketsSorted = false;
		}

		private void LazySort()
		{
			if (!_areBucketsSorted)
			{
				_buckets.Sort();
				_areBucketsSorted = true;
			}
		}

		public Bucket GetBucketOf(double v)
		{
			return (Bucket)_buckets[GetBucketIndexOf(v)].Clone();
		}

		public int GetBucketIndexOf(double v)
		{
			LazySort();
			int num = _buckets.BinarySearch(new Bucket(v), Bucket.DefaultPointComparer);
			if (num < 0)
			{
				throw new ArgumentException("The histogram does not contain the value.");
			}
			return num;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Bucket bucket in _buckets)
			{
				stringBuilder.Append(bucket);
			}
			return stringBuilder.ToString();
		}
	}
}
