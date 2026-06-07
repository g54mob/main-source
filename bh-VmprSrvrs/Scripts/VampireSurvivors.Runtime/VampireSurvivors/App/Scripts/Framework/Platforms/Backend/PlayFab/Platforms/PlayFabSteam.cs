using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Core;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms
{
	public class PlayFabSteam : IPlatform, IPlatformAuthentication
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLinkAccount_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ILinkResult> _003C_003Et__builder;

			public PlayFabSteam _003C_003E4__this;

			public bool force;

			private TaskAwaiter<ILinkResult> _003C_003Eu__1;

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
		private struct _003CLogin_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

			public PlayFabSteam _003C_003E4__this;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

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
		private struct _003CLoginOrRegister_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

			public PlayFabSteam _003C_003E4__this;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

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
		private struct _003CRetryAction_003Ed__9<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

			public Func<Task<T>> action;

			public int maxAttempts;

			private int _003Cattempt_003E5__2;

			private bool _003CtryAgain_003E5__3;

			private Exception _003Cerror_003E5__4;

			private TaskAwaiter<T> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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

		public PlatformType GetPlatformName()
		{
			return default(PlatformType);
		}

		[AsyncStateMachine(typeof(_003CLoginOrRegister_003Ed__1))]
		public Task<ILoginResult> LoginOrRegister()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLogin_003Ed__2))]
		public Task<ILoginResult> Login()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLinkAccount_003Ed__3))]
		public Task<ILinkResult> LinkAccount(bool force = false)
		{
			return null;
		}

		private Task<ILoginResult> TryLoginOrRegisterInternal()
		{
			return null;
		}

		private Task<ILoginResult> TryLoginInternal()
		{
			return null;
		}

		private Task<ILoginResult> LoginOrRegisterInternal(bool createAccount)
		{
			return null;
		}

		private Task<ILinkResult> LinkAccountInternal(bool force = false)
		{
			return null;
		}

		public Task<bool> UnlinkAccount()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRetryAction_003Ed__9<>))]
		private Task<T> RetryAction<T>(Func<Task<T>> action, int maxAttempts = 3)
		{
			return null;
		}
	}
}
