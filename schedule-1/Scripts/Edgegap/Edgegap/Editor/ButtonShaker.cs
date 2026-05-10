using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Edgegap.Editor
{
	public class ButtonShaker
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CApplyShakeAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ButtonShaker _003C_003E4__this;

			public int msDelayBetweenShakes;

			public int iterations;

			private int _003Ci_003E5__2;

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
		private struct _003CshakeOnce_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ButtonShaker _003C_003E4__this;

			public int msDelayBetweenShakes;

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

		private const string SHAKE_START_CLASS = "shakeStart";

		private const string SHAKE_STOP_CLASS = "shakeEnd";

		private Button targetButton;

		public ButtonShaker(Button buttonToShake)
		{
		}

		[AsyncStateMachine(typeof(_003CApplyShakeAsync_003Ed__4))]
		public Task ApplyShakeAsync(int msDelayBetweenShakes = 40, int iterations = 2)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CshakeOnce_003Ed__5))]
		private Task shakeOnce(int msDelayBetweenShakes)
		{
			return null;
		}
	}
}
