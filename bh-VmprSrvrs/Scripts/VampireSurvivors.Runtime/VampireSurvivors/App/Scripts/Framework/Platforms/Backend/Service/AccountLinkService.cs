using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.Json;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service
{
	public class AccountLinkService
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAcceptMergeConflict_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			private TaskAwaiter<JsonObject> _003C_003Eu__1;

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
		private struct _003CCanUnlink_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			private TaskAwaiter<AccountDetails> _003C_003Eu__1;

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
		private struct _003CCheckForceLinkOnServer_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ForceLinkResponse> _003C_003Et__builder;

			public string platformAccountPlayFabId;

			public AccountDetailsType platform;

			private string _003ClinkedPlayerId_003E5__2;

			private TaskAwaiter<JsonObject> _003C_003Eu__1;

			private Task<PlayerOptionsData> _003CgetDataTask_003E5__3;

			private Task<PlayerOptionsData> _003CgetMergeConflictDataTask_003E5__4;

			private TaskAwaiter<PlayerOptionsData[]> _003C_003Eu__2;

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
		private struct _003CPrepareForForceLink_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ForceLinkResponse> _003C_003Et__builder;

			public AccountLinkService _003C_003E4__this;

			public AccountDetailsType platform;

			private TaskAwaiter<string> _003C_003Eu__1;

			private TaskAwaiter<ForceLinkResponse> _003C_003Eu__2;

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
		private struct _003CSetAccountVerificationTokenOnPlatformAccount_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			private PlayFabAuthenticationContext _003CbasicCredsAuthContext_003E5__2;

			private PlayFabLoginSuccess _003CplatformLoginResult_003E5__3;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

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
		private struct _003CTryToUnlinkSpecificPlatform_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public AccountDetailsType platform;

			public bool isCurrentPlatform;

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

		[AsyncStateMachine(typeof(_003CPrepareForForceLink_003Ed__0))]
		public Task<ForceLinkResponse> PrepareForForceLink(AccountDetailsType platform)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCanUnlink_003Ed__1))]
		public Task<bool> CanUnlink()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CTryToUnlinkSpecificPlatform_003Ed__2))]
		public Task TryToUnlinkSpecificPlatform(AccountDetailsType platform, bool isCurrentPlatform)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSetAccountVerificationTokenOnPlatformAccount_003Ed__3))]
		private Task<string> SetAccountVerificationTokenOnPlatformAccount()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAcceptMergeConflict_003Ed__4))]
		public Task AcceptMergeConflict()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCheckForceLinkOnServer_003Ed__5))]
		private Task<ForceLinkResponse> CheckForceLinkOnServer(string platformAccountPlayFabId, AccountDetailsType platform)
		{
			return null;
		}
	}
}
