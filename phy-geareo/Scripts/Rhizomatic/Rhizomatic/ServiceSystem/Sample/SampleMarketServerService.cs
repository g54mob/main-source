using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Rhizomatic.ServiceSystem.Sample
{
	[CreateAssetMenu(fileName = "sample_market_server", menuName = "ServiceSystem/Services/SampleMarketServer")]
	public class SampleMarketServerService : MarketServerService
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CIsPurchaseConsumed_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SampleMarketServerService _003C_003E4__this;

			public Action<bool> onSuccess;

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
		private struct _003CValidatePurchase_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SampleMarketServerService _003C_003E4__this;

			public Action<bool> onSuccess;

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
		private struct _003CWait_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public SampleMarketServerService _003C_003E4__this;

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

		public float minDelay;

		public float maxDelay;

		public override string marketKey => null;

		[AsyncStateMachine(typeof(_003CWait_003Ed__4))]
		private Task Wait()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CValidatePurchase_003Ed__5))]
		public override void ValidatePurchase(string sku, string token, Action<bool> onSuccess, Action<MarketServerException> onFailed)
		{
		}

		[AsyncStateMachine(typeof(_003CIsPurchaseConsumed_003Ed__6))]
		public override void IsPurchaseConsumed(string sku, string token, Action<bool> onSuccess, Action<MarketServerException> onFailed)
		{
		}
	}
}
