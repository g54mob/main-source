using System;
using System.Globalization;
using System.IO;
using HandlebarsDotNet.Pools;

namespace HandlebarsDotNet
{
	public class ReusableStringWriter : StringWriter
	{
		private readonly struct Policy : IInternalObjectPoolPolicy<ReusableStringWriter>
		{
			private readonly StringBuilderPool.StringBuilderPooledObjectPolicy _policy;

			public Policy(int initialCapacity, int maximumRetainedCapacity = 4096)
			{
				_policy = new StringBuilderPool.StringBuilderPooledObjectPolicy(initialCapacity, maximumRetainedCapacity);
			}

			public ReusableStringWriter Create()
			{
				return new ReusableStringWriter();
			}

			public bool Return(ReusableStringWriter item)
			{
				return _policy.Return(item.GetStringBuilder());
			}
		}

		private static readonly InternalObjectPool<ReusableStringWriter, Policy> Pool = new InternalObjectPool<ReusableStringWriter, Policy>(new Policy(16));

		private IFormatProvider _formatProvider;

		public override IFormatProvider FormatProvider => _formatProvider;

		public static ReusableStringWriter Get(IFormatProvider formatProvider = null)
		{
			ReusableStringWriter reusableStringWriter = Pool.Get();
			reusableStringWriter._formatProvider = formatProvider ?? CultureInfo.CurrentCulture;
			return reusableStringWriter;
		}

		private ReusableStringWriter()
		{
		}

		protected override void Dispose(bool disposing)
		{
			_formatProvider = null;
			Pool.Return(this);
		}
	}
}
