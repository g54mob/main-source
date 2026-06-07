using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors
{
	public class ConnectionErrorPage : BaseUIPage
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CQuit_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ConnectionErrorPage _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		[SerializeField]
		private TextMeshProUGUI _errorText;

		private SignalBus _signalBus;

		private LobbiesManager _lobbiesManager;

		[Inject]
		private void Construct(SignalBus signalBus, LobbiesManager lobbiesManager)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		[AsyncStateMachine(typeof(_003CQuit_003Ed__5))]
		public void Quit()
		{
		}
	}
}
