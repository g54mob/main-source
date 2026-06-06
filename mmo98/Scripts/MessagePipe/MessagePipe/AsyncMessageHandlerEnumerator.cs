using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal class AsyncMessageHandlerEnumerator<TMessage> : IUniTaskAsyncEnumerator<TMessage>, IUniTaskAsyncDisposable, IAsyncMessageHandler<TMessage>
	{
		private Channel<TMessage> channel;

		private CancellationToken cancellationToken;

		private SingleAssignmentDisposable singleAssignmentDisposable;

		TMessage IUniTaskAsyncEnumerator<TMessage>.Current
		{
			get
			{
				if (channel.Reader.TryRead(out var item))
				{
					return item;
				}
				throw new InvalidOperationException("Message is not buffered in Channel.");
			}
		}

		public AsyncMessageHandlerEnumerator(SingleAssignmentDisposable singleAssignmentDisposable, CancellationToken cancellationToken)
		{
			this.singleAssignmentDisposable = singleAssignmentDisposable;
			this.cancellationToken = cancellationToken;
			channel = Channel.CreateSingleConsumerUnbounded<TMessage>();
		}

		UniTask<bool> IUniTaskAsyncEnumerator<TMessage>.MoveNextAsync()
		{
			return channel.Reader.WaitToReadAsync(cancellationToken);
		}

		UniTask IAsyncMessageHandler<TMessage>.HandleAsync(TMessage message, CancellationToken cancellationToken)
		{
			channel.Writer.TryWrite(message);
			return default(UniTask);
		}

		UniTask IUniTaskAsyncDisposable.DisposeAsync()
		{
			singleAssignmentDisposable.Dispose();
			return default(UniTask);
		}
	}
}
