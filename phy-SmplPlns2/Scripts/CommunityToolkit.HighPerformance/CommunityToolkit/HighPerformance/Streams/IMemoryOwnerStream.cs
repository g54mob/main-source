using System;

namespace CommunityToolkit.HighPerformance.Streams
{
	internal sealed class IMemoryOwnerStream<TSource> : MemoryStream<TSource> where TSource : struct, ISpanOwner
	{
		private readonly IDisposable disposable;

		public IMemoryOwnerStream(TSource source, IDisposable disposable)
			: base(source, false)
		{
			this.disposable = disposable;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			disposable.Dispose();
		}
	}
}
