using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Rhizomatic.ServiceSystem.Sample
{
	[CreateAssetMenu(fileName = "sample_ad", menuName = "ServiceSystem/Services/SampleAd")]
	public class SampleAdService : AdService
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDoLoadRewarded_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ServiceAd> onSucceed;

			public string key;

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

		public SampleAdManager managerPrefab;

		public SampleAdManager manager { get; private set; }

		protected override void Init()
		{
		}

		[AsyncStateMachine(typeof(_003CDoLoadRewarded_003Ed__6))]
		protected override void DoLoadRewarded(string key, Action<ServiceAd> onSucceed, Action<ServiceAdError> onFailed)
		{
		}

		protected override void DoShowRewarded(ServiceAd ad, Action<ServiceAdReward> onReward, Action onClosed, Action<ServiceAdError> onFailed)
		{
		}
	}
}
