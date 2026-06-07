using System;
using System.Threading;
using System.Threading.Channels;

namespace R3
{
	internal sealed class ToAsyncEnumerable<T> : Observer<T>
	{
		public CancellationTokenRegistration registration;

		public ToAsyncEnumerable(ChannelWriter<T> writer)
		{
			_003Cwriter_003EP = writer;
			base._002Ector();
		}

		protected override void OnNextCore(T value)
		{
			_003Cwriter_003EP.TryWrite(value);
		}

		protected override void OnErrorResumeCore(Exception error)
		{
			_003Cwriter_003EP.TryComplete(error);
		}

		protected override void OnCompletedCore(Result result)
		{
			if (result.IsFailure)
			{
				_003Cwriter_003EP.TryComplete(result.Exception);
			}
			else
			{
				_003Cwriter_003EP.TryComplete();
			}
		}

		protected override void DisposeCore()
		{
			registration.Dispose();
		}
	}
}
