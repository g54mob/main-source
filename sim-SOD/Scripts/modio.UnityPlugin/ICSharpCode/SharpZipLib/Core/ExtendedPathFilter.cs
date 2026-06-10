using System;

namespace ICSharpCode.SharpZipLib.Core
{
	public class ExtendedPathFilter : PathFilter
	{
		private long minSize_;

		private long maxSize_;

		private DateTime minDate_;

		private DateTime maxDate_;

		public long MinSize
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long MaxSize
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public DateTime MinDate
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public DateTime MaxDate
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public ExtendedPathFilter(string filter, long minSize, long maxSize)
			: base(null)
		{
		}

		public ExtendedPathFilter(string filter, DateTime minDate, DateTime maxDate)
			: base(null)
		{
		}

		public ExtendedPathFilter(string filter, long minSize, long maxSize, DateTime minDate, DateTime maxDate)
			: base(null)
		{
		}

		public override bool IsMatch(string name)
		{
			return false;
		}
	}
}
