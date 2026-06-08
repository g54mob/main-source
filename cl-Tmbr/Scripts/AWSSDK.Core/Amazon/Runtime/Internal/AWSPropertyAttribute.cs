using System;

namespace Amazon.Runtime.Internal
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class AWSPropertyAttribute : Attribute
	{
		private long min;

		private long max;

		public bool Sensitive { get; set; }

		public bool Required { get; set; }

		public bool IsMinSet { get; private set; }

		public long Min
		{
			get
			{
				if (!IsMinSet)
				{
					return long.MinValue;
				}
				return min;
			}
			set
			{
				IsMinSet = true;
				min = value;
			}
		}

		public bool IsMaxSet { get; private set; }

		public long Max
		{
			get
			{
				if (!IsMaxSet)
				{
					return long.MaxValue;
				}
				return max;
			}
			set
			{
				IsMaxSet = true;
				max = value;
			}
		}
	}
}
