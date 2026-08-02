using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Rhizomatic.ServiceSystem.Sample
{
	[CreateAssetMenu(fileName = "sample_purchase", menuName = "ServiceSystem/Services/SamplePurchase")]
	public class SamplePurchaseService : PurchaseService
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCallConsumeProduct_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SamplePurchaseService _003C_003E4__this;

			public string productId;

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
		private struct _003CCallInitIAB_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SamplePurchaseService _003C_003E4__this;

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
		private struct _003CCallQueryInventory_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SamplePurchaseService _003C_003E4__this;

			public string[] productIds;

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
		private struct _003CCallQueryProducts_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SamplePurchaseService _003C_003E4__this;

			public string[] productIds;

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
		private struct _003CCallQueryPurchases_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SamplePurchaseService _003C_003E4__this;

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
		private struct _003CWait_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public SamplePurchaseService _003C_003E4__this;

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

		public SamplePurchaseManager managerPrefab;

		public float minDelay;

		public float maxDelay;

		public List<SampleProduct> products;

		public Dictionary<string, ServicePurchase> purchases;

		public SamplePurchaseManager manager { get; private set; }

		public override string marketKey => null;

		[AsyncStateMachine(typeof(_003CWait_003Ed__11))]
		private Task Wait()
		{
			return null;
		}

		protected override void Init()
		{
		}

		[AsyncStateMachine(typeof(_003CCallInitIAB_003Ed__13))]
		protected override void CallInitIAB()
		{
		}

		protected override void CallPurchaseProduct(string productId, string payload)
		{
		}

		[AsyncStateMachine(typeof(_003CCallConsumeProduct_003Ed__15))]
		protected override void CallConsumeProduct(string productId)
		{
		}

		[AsyncStateMachine(typeof(_003CCallQueryPurchases_003Ed__16))]
		protected override void CallQueryPurchases()
		{
		}

		[AsyncStateMachine(typeof(_003CCallQueryProducts_003Ed__17))]
		protected override void CallQueryProducts(string[] productIds)
		{
		}

		[AsyncStateMachine(typeof(_003CCallQueryInventory_003Ed__18))]
		protected override void CallQueryInventory(string[] productIds)
		{
		}

		private ServiceProduct GetProduct(string productId)
		{
			return null;
		}

		public override string GetPriceText(ServiceProduct product)
		{
			return null;
		}

		public override int GetPriceValue(ServiceProduct product)
		{
			return 0;
		}
	}
}
