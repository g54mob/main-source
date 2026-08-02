using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Rhizomatic.ServiceSystem
{
	public abstract class AuthService : Service
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwaitable_003Ed__6<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public Task<T> task;

			public Action<T> onSucceed;

			public Action<AuthServiceException> onFailed;

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

		protected abstract void CallRegister(AuthBox box, Action<AuthBox> onSucceeded, Action<AuthServiceException> onFailed);

		protected abstract void CallLogin(Action<AuthBox> onSucceeded, Action<AuthServiceException> onFailed);

		public void Register(AuthBox box, Action<AuthBox> onSucceeded, Action<AuthServiceException> onFailed)
		{
		}

		public void Login(Action<AuthBox> onSucceeded, Action<AuthServiceException> onFailed)
		{
		}

		public Task<AuthBox> RegisterAsync(AuthBox box)
		{
			return null;
		}

		public Task<AuthBox> LoginAsync()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitable_003Ed__6<>))]
		public Task<bool> Awaitable<T>(Task<T> task, Action<T> onSucceed, Action<AuthServiceException> onFailed)
		{
			return null;
		}

		public Task<bool> RegisterAsync(AuthBox box, out AuthResultContainer<AuthBox> result)
		{
			result = null;
			return null;
		}

		public Task<bool> LoginAsync(out AuthResultContainer<AuthBox> result)
		{
			result = null;
			return null;
		}
	}
}
