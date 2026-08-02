using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Rhizomatic.ServiceSystem
{
	public abstract class PurchaseService : Service
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwaitable_003Ed__96<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public Task<T> task;

			public Action<T> onSucceed;

			public Action<PurchaseServiceException> onFailed;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDequeueRequest_003Ed__81 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public PurchaseService _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CEnqueueRequest_003Ed__82 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Func<PurchaseServiceRequest> createRequest;

			public PurchaseService _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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

		public Dictionary<string, ServiceProduct> loadedProducts;

		private Dictionary<PurchaseServiceRequestType, List<PurchaseServiceRequest>> currentRequests;

		private PurchaseServiceRequest currentRequest;

		private List<Action> requestsQueue;

		private const float maxRequestTime = 16f;

		public abstract string marketKey { get; }

		public bool isSupported { get; private set; }

		public event Action onSupported
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<PurchaseServiceException> onNotSupported
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<List<ServicePurchase>, List<ServiceProduct>> onQueryInventorySucceededEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<PurchaseServiceException> onQueryInventoryFailedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<List<ServiceProduct>> onQueryProductsSucceededEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<PurchaseServiceException> onQueryProductsFailedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<List<ServicePurchase>> onQueryPurchasesSucceededEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<PurchaseServiceException> onQueryPurchasesFailedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ServicePurchase> onPurchaseSucceededEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<PurchaseServiceException> onPurchaseFailedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ServicePurchase> onConsumePurchaseSucceededEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<PurchaseServiceException> onConsumePurchaseFailedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract string GetPriceText(ServiceProduct product);

		public abstract int GetPriceValue(ServiceProduct product);

		protected abstract void CallInitIAB();

		protected abstract void CallPurchaseProduct(string productId, string payload);

		protected abstract void CallConsumeProduct(string productId);

		protected abstract void CallQueryPurchases();

		protected abstract void CallQueryProducts(string[] productIds);

		protected abstract void CallQueryInventory(string[] productIds);

		protected void CallSupportedEvent()
		{
		}

		protected void CallNotSupportedEvent(PurchaseServiceException error)
		{
		}

		protected void CallQueryInventorySucceededEvent(List<ServicePurchase> purchases, List<ServiceProduct> products)
		{
		}

		protected void CallQueryInventoryFailedEvent(PurchaseServiceException error)
		{
		}

		protected void CallQueryProductsSucceededEvent(List<ServiceProduct> products)
		{
		}

		protected void CallQueryProductsFailedEvent(PurchaseServiceException error)
		{
		}

		protected void CallQueryPurchasesSucceededEvent(List<ServicePurchase> purchases)
		{
		}

		protected void CallQueryPurchasesFailedEvent(PurchaseServiceException error)
		{
		}

		protected void CallPurchaseSucceededEvent(ServicePurchase purchase)
		{
		}

		protected void CallPurchaseFailedEvent(PurchaseServiceException error)
		{
		}

		protected void CallConsumePurchaseSucceededEvent(ServicePurchase purchase)
		{
		}

		protected void CallConsumePurchaseFailedEvent(PurchaseServiceException error)
		{
		}

		private void OnSupported()
		{
		}

		private void OnNotSupported(PurchaseServiceException error)
		{
		}

		private void OnQueryInventorySucceededEvent(List<ServicePurchase> purchases, List<ServiceProduct> products)
		{
		}

		private void OnQueryInventoryFailedEvent(PurchaseServiceException error)
		{
		}

		private void OnQueryProductsSucceededEvent(List<ServiceProduct> products)
		{
		}

		private void OnQueryProductsFailedEvent(PurchaseServiceException error)
		{
		}

		private void OnQueryPurchasesSucceededEvent(List<ServicePurchase> purchases)
		{
		}

		private void OnQueryPurchasesFailedEvent(PurchaseServiceException error)
		{
		}

		private void OnPurchaseSucceededEvent(ServicePurchase purchase)
		{
		}

		private void OnPurchaseFailedEvent(PurchaseServiceException error)
		{
		}

		private void OnConsumePurchaseSucceededEvent(ServicePurchase purchase)
		{
		}

		private void OnConsumePurchaseFailedEvent(PurchaseServiceException error)
		{
		}

		private PurchaseServiceRequest SendRequest(PurchaseServiceRequestType type, Action<object[]> onSucceed, Action<object[]> onFailed)
		{
			return null;
		}

		private void FinishRequest(PurchaseServiceRequestType type, bool succeed, params object[] args)
		{
		}

		[AsyncStateMachine(typeof(_003CDequeueRequest_003Ed__81))]
		private void DequeueRequest()
		{
		}

		[AsyncStateMachine(typeof(_003CEnqueueRequest_003Ed__82))]
		private void EnqueueRequest(Func<PurchaseServiceRequest> createRequest)
		{
		}

		public void InitIAB(Action onSucceed, Action<PurchaseServiceException> onFailed)
		{
		}

		public void Purchase(string productId, string payload, Action<ServicePurchase> onSucceed, Action<PurchaseServiceException> onFailed)
		{
		}

		public void ConsumeProduct(string productId, Action<ServicePurchase> onSucceed, Action<PurchaseServiceException> onFailed)
		{
		}

		public void QueryPurchases(Action<List<ServicePurchase>> onSucceed, Action<PurchaseServiceException> onFailed)
		{
		}

		public void QueryProducts(string[] productIds, Action<List<ServiceProduct>> onSucceed, Action<PurchaseServiceException> onFailed)
		{
		}

		public void QueryInventory(string[] productIds, Action<InventoryResult> onSucceed, Action<PurchaseServiceException> onFailed)
		{
		}

		public Task<bool> InitIABAsync()
		{
			return null;
		}

		public Task<ServicePurchase> PurchaseAsync(string productId)
		{
			return null;
		}

		public Task<ServicePurchase> PurchaseAsync(string productId, string payload)
		{
			return null;
		}

		public Task<ServicePurchase> ConsumeProductAsync(string productId)
		{
			return null;
		}

		public Task<List<ServicePurchase>> QueryPurchasesAsync()
		{
			return null;
		}

		public Task<List<ServiceProduct>> QueryProductsAsync(string[] productIds)
		{
			return null;
		}

		public Task<InventoryResult> QueryInventoryAsync(string[] productIds)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitable_003Ed__96<>))]
		public Task<bool> Awaitable<T>(Task<T> task, Action<T> onSucceed, Action<PurchaseServiceException> onFailed)
		{
			return null;
		}

		public Task<bool> InitIABAsyncSafe(out PurchaseResultContainer<bool> result)
		{
			result = null;
			return null;
		}

		public Task<bool> PurchaseAsync(string productId, out PurchaseResultContainer<ServicePurchase> result)
		{
			result = null;
			return null;
		}

		public Task<bool> PurchaseAsync(string productId, string payload, out PurchaseResultContainer<ServicePurchase> result)
		{
			result = null;
			return null;
		}

		public Task<bool> ConsumeProductAsync(string productId, out PurchaseResultContainer<ServicePurchase> result)
		{
			result = null;
			return null;
		}

		public Task<bool> QueryPurchasesAsync(out PurchaseResultContainer<List<ServicePurchase>> result)
		{
			result = null;
			return null;
		}

		public Task<bool> QueryProductsAsync(string[] productIds, out PurchaseResultContainer<List<ServiceProduct>> result)
		{
			result = null;
			return null;
		}

		public Task<bool> QueryInventoryAsync(string[] productIds, out PurchaseResultContainer<InventoryResult> result)
		{
			result = null;
			return null;
		}
	}
}
