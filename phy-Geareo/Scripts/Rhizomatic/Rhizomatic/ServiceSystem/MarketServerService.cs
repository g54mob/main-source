using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Rhizomatic.ServiceSystem
{
	public abstract class MarketServerService : Service
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwaitable_003Ed__6<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public Task<T> task;

			public Action<T> onSucceed;

			public Action<MarketServerException> onFailed;

			private TaskAwaiter<T> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public abstract string marketKey { get; }

		public abstract void ValidatePurchase(string sku, string token, Action<bool> onSuccess, Action<MarketServerException> onFailed);

		public abstract void IsPurchaseConsumed(string sku, string token, Action<bool> onSuccess, Action<MarketServerException> onFailed);

		public Task<bool> ValidatePurchaseAsync(string sku, string token)
		{
			return null;
		}

		public Task<bool> IsPurchaseConsumedAsync(string sku, string token)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitable_003Ed__6<>))]
		public Task<bool> Awaitable<T>(Task<T> task, Action<T> onSucceed, Action<MarketServerException> onFailed)
		{
			return null;
		}

		public Task<bool> ValidatePurchaseAsync(string sku, string token, out MarketServerResultContainer<bool> result)
		{
			result = null;
			return null;
		}

		public Task<bool> IsPurchaseConsumedAsync(string sku, string token, out MarketServerResultContainer<bool> result)
		{
			result = null;
			return null;
		}
	}
}
