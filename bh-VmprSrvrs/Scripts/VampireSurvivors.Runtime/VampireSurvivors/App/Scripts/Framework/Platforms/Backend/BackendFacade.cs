using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.Json;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Core;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend
{
	public static class BackendFacade
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass36_0
		{
			public string id;

			internal Task<bool> _003CLinkCustomID_003Eb__0()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass37_0
		{
			public string id;

			internal Task<bool> _003CUnlinkCustomId_003Eb__0()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAddEmailAndPassword_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public string email;

			public string password;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAddOrUpdateContactEmail_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public string email;

			private bool _003Cres_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExecuteCloudScript_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<JsonObject> _003C_003Et__builder;

			public string fnName;

			public Dictionary<string, string> parameters;

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
		private struct _003CGetAccountDetails_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<AccountDetails> _003C_003Et__builder;

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
		private struct _003CGetAccountEmailAddress_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

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
		private struct _003CGetMergeConflictSlotData_003Ed__39 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

			private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

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
		private struct _003CGetPlayerData_003Ed__44 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public PlayFabPlayerData.AllowedPlayerDataKeys key;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct _003CGetPlayerProfile_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<IPlayerProfile> _003C_003Et__builder;

			private TaskAwaiter<IPlayerProfile> _003C_003Eu__1;

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
		private struct _003CGetSlotSaveData_003Ed__40 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

			public int slot;

			private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

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
		private struct _003CLinkAccount_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ILinkResult> _003C_003Et__builder;

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
		private struct _003CLinkCustomID_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public string id;

			private _003C_003Ec__DisplayClass36_0 _003C_003E8__1;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

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
		private struct _003CLogin_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

			private ILoginResult _003Cres_003E5__2;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoginWithCustomID_003Ed__38 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

			public string id;

			public bool forceCreate;

			public bool requiresProfileFetch;

			private ILoginResult _003Cres_003E5__2;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoginWithDeviceId_003Ed__35 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

			private ILoginResult _003Cres_003E5__2;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoginWithEmail_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

			public string email;

			public string password;

			private ILoginResult _003Cres_003E5__2;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRegisterWithEmail_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public string email;

			public string password;

			private bool _003Cres_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRemoveContactEmailAddress_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CResendAccountVerificationEmail_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			private TaskAwaiter<IPlayerProfile> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private TaskAwaiter<bool> _003C_003Eu__3;

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
		private struct _003CResetContactEmailAddress_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			private string _003CaccountEmailAddress_003E5__2;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct _003CSetPlayerData_003Ed__42 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public PlayFabPlayerData.AllowedPlayerDataKeys key;

			public string value;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSetSlotSaveData_003Ed__41 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public int slot;

			public PlayerOptionsData value;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTryOperationAndDoAuth_003Ed__7<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

			public Func<Task<T>> operation;

			private TaskAwaiter<T> _003C_003Eu__1;

			private TaskAwaiter<ILoginResult> _003C_003Eu__2;

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
		private struct _003CUnlinkAccount_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnlinkAccount_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public IPlatformAuthentication platformAuthentication;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnlinkCustomId_003Ed__37 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public string id;

			private _003C_003Ec__DisplayClass37_0 _003C_003E8__1;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

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

		private static IPlatformConfiguration _platformConfiguration;

		private static readonly IPlatform _platform;

		private static readonly ICoreAuthentication _coreAuthentication;

		private static readonly IPlatformAuthentication _platformAuthentication;

		private static readonly IPlayerDataStorage _storage;

		private static readonly IMultiSlotSaveStorage _multiSlotSaveStorage;

		static BackendFacade()
		{
		}

		[AsyncStateMachine(typeof(_003CTryOperationAndDoAuth_003Ed__7<>))]
		private static Task<T> TryOperationAndDoAuth<T>(Func<Task<T>> operation)
		{
			return null;
		}

		public static string GetPlatformAsString()
		{
			return null;
		}

		public static PlatformType GetPlatformType()
		{
			return default(PlatformType);
		}

		public static string GetEnvironment()
		{
			return null;
		}

		public static bool SupportsPlatformAuthentication()
		{
			return false;
		}

		public static string GetAccountId()
		{
			return null;
		}

		public static bool IsLoggedIn()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CAddOrUpdateContactEmail_003Ed__14))]
		public static Task<bool> AddOrUpdateContactEmail(string email)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAccountEmailAddress_003Ed__15))]
		public static Task<string> GetAccountEmailAddress()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetPlayerProfile_003Ed__16))]
		public static Task<IPlayerProfile> GetPlayerProfile()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CResetContactEmailAddress_003Ed__17))]
		public static Task<string> ResetContactEmailAddress()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CResendAccountVerificationEmail_003Ed__18))]
		public static Task<bool> ResendAccountVerificationEmail()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRemoveContactEmailAddress_003Ed__19))]
		public static Task<bool> RemoveContactEmailAddress()
		{
			return null;
		}

		public static void Logout()
		{
		}

		public static void SetDefaultAuthContext(PlayFabAuthenticationContext ctx)
		{
		}

		[AsyncStateMachine(typeof(_003CExecuteCloudScript_003Ed__22))]
		public static Task<JsonObject> ExecuteCloudScript(string fnName, Dictionary<string, string> parameters = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAccountDetails_003Ed__23))]
		public static Task<AccountDetails> GetAccountDetails()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLogin_003Ed__24))]
		public static Task<ILoginResult> Login()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLinkAccount_003Ed__25))]
		public static Task<ILinkResult> LinkAccount(bool force = false)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUnlinkAccount_003Ed__26))]
		public static Task<bool> UnlinkAccount()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUnlinkAccount_003Ed__27))]
		public static Task<bool> UnlinkAccount(IPlatformAuthentication platformAuthentication)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAddEmailAndPassword_003Ed__28))]
		public static Task<bool> AddEmailAndPassword(string email, string password)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithEmail_003Ed__29))]
		public static Task<ILoginResult> LoginWithEmail(string email, string password)
		{
			return null;
		}

		public static Task SendPasswordReset(string email)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRegisterWithEmail_003Ed__31))]
		public static Task<bool> RegisterWithEmail(string email, string password)
		{
			return null;
		}

		public static string GetCustomID()
		{
			return null;
		}

		public static Task<bool> LinkDeviceId()
		{
			return null;
		}

		public static Task<bool> UnlinkDeviceId()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithDeviceId_003Ed__35))]
		public static Task<ILoginResult> LoginWithDeviceId()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLinkCustomID_003Ed__36))]
		private static Task<bool> LinkCustomID(string id)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUnlinkCustomId_003Ed__37))]
		private static Task<bool> UnlinkCustomId(string id)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithCustomID_003Ed__38))]
		public static Task<ILoginResult> LoginWithCustomID(string id, bool forceCreate = false, bool requiresProfileFetch = true)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetMergeConflictSlotData_003Ed__39))]
		public static Task<PlayerOptionsData> GetMergeConflictSlotData()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetSlotSaveData_003Ed__40))]
		public static Task<PlayerOptionsData> GetSlotSaveData(int slot)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSetSlotSaveData_003Ed__41))]
		public static Task<bool> SetSlotSaveData(int slot, PlayerOptionsData value)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSetPlayerData_003Ed__42))]
		public static Task<bool> SetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys key, string value)
		{
			return null;
		}

		public static Task<bool> TryGetPlatformToken()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetPlayerData_003Ed__44))]
		private static Task<string> GetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys key)
		{
			return null;
		}
	}
}
