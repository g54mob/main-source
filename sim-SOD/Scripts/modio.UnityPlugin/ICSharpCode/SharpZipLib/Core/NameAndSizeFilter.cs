using System;

namespace ICSharpCode.SharpZipLib.Core
{
	[Obsolete("Use ExtendedPathFilter instead")]
	public class NameAndSizeFilter : PathFilter
	{
		private long minSize_;

		private long maxSize_;

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

		public NameAndSizeFilter(string filter, long minSize, long maxSize)
			: base(null)
		{
		}

		public override bool IsMatch(string name)
		{
			return false;
		}
	}
}
