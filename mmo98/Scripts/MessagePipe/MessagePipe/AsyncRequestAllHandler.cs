using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class AsyncRequestAllHandler<TRequest, TResponse> : IAsyncRequestAllHandler<TRequest, TResponse>
	{
		private readonly IAsyncRequestHandlerCore<TRequest, TResponse>[] handlers;

		private readonly AsyncPublishStrategy defaultAsyncPublishStrategy;

		[Preserve]
		public AsyncRequestAllHandler(IEnumerable<IAsyncRequestHandlerCore<TRequest, TResponse>> handlers, FilterAttachedAsyncRequestHandlerFactory handlerFactory, MessagePipeOptions options)
		{
			ICollection<IAsyncRequestHandlerCore<TRequest, TResponse>> obj = (handlers as ICollection<IAsyncRequestHandlerCore<TRequest, TResponse>>) ?? handlers.ToArray();
			IAsyncRequestHandlerCore<TRequest, TResponse>[] array = new IAsyncRequestHandlerCore<TRequest, TResponse>[obj.Count];
			int num = 0;
			foreach (IAsyncRequestHandlerCore<TRequest, TResponse> item in obj)
			{
				array[num++] = handlerFactory.CreateAsyncRequestHandler(item);
			}
			this.handlers = array;
			defaultAsyncPublishStrategy = options.DefaultAsyncPublishStrategy;
		}

		public UniTask<TResponse[]> InvokeAllAsync(TRequest request, CancellationToken cancellationToken)
		{
			return InvokeAllAsync(request, defaultAsyncPublishStrategy, cancellationToken);
		}

		public async UniTask<TResponse[]> InvokeAllAsync(TRequest request, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken)
		{
			if (publishStrategy == AsyncPublishStrategy.Sequential)
			{
				TResponse[] responses = new TResponse[handlers.Length];
				for (int i = 0; i < handlers.Length; i++)
				{
					TResponse[] array = responses;
					int num = i;
					array[num] = await handlers[i].InvokeAsync(request, cancellationToken);
				}
				return responses;
			}
			return await new AsyncRequestHandlerWhenAll<TRequest, TResponse>(handlers, request, cancellationToken);
		}

		public IUniTaskAsyncEnumerable<TResponse> InvokeAllLazyAsync(TRequest request, CancellationToken cancellationToken)
		{
			return UniTaskAsyncEnumerable.Create(async delegate(IAsyncWriter<TResponse> writer, CancellationToken token)
			{
				for (int i = 0; i < handlers.Length; i++)
				{
					await writer.YieldAsync(await handlers[i].InvokeAsync(request, cancellationToken));
				}
			});
		}
	}
}
