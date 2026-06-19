using System;
using System.Threading.Tasks;

namespace Loxodon.Framework.Interactivity
{
	public class AsyncInteractionRequest : IInteractionRequest
	{
		private object sender;

		public event EventHandler<InteractionEventArgs> Raised;

		public AsyncInteractionRequest()
			: this(null)
		{
		}

		public AsyncInteractionRequest(object sender)
		{
			this.sender = ((sender != null) ? sender : this);
		}

		public Task Raise()
		{
			TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
			this.Raised?.Invoke(sender, new AsyncInteractionEventArgs(taskCompletionSource, null));
			return taskCompletionSource.Task;
		}
	}
	public class AsyncInteractionRequest<T> : IInteractionRequest
	{
		private object sender;

		public event EventHandler<InteractionEventArgs> Raised;

		public AsyncInteractionRequest()
			: this((object)null)
		{
		}

		public AsyncInteractionRequest(object sender)
		{
			this.sender = ((sender != null) ? sender : this);
		}

		public async Task<T> Raise(T context)
		{
			TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
			this.Raised?.Invoke(sender, new AsyncInteractionEventArgs(taskCompletionSource, context));
			await taskCompletionSource.Task;
			return context;
		}
	}
}
