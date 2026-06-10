using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO.Implementation.API;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.API.Requests;

namespace ModIO.Implementation
{
	internal static class ModCollectionManager
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadRegistryAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			private TaskAwaiter<ResultAnd<ModCollectionRegistry>> _003C_003Eu__1;

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
		private struct _003CSaveRegistry_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CFetchUpdates_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			private Result _003Cresult_003E5__2;

			private long _003Cuser_003E5__3;

			private TaskAwaiter<ResultAnd<UserObject>> _003C_003Eu__1;

			private TaskAwaiter<ResultAnd<GetGameTags.ResponseSchema>> _003C_003Eu__2;

			private List<ModId>.Enumerator _003C_003E7__wrap3;

			private TaskAwaiter<Result> _003C_003Eu__3;

			private TaskAwaiter<ResultAnd<RatingObject[]>> _003C_003Eu__4;

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
		private struct _003CSyncUsersSubscriptions_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public long user;

			private Result _003Cresult_003E5__2;

			private TaskAwaiter<ResultAnd<ModObject[]>> _003C_003Eu__1;

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
		private struct _003CTryRequestAllResults_003Ed__12<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<T[]>> _003C_003Et__builder;

			public Func<WebRequestConfig> webrequestFactory;

			public string url;

			private ResultAnd<T[]> _003Cresponse_003E5__2;

			private List<T> _003CcollatedData_003E5__3;

			private int _003CnumberOfRequestsMade_003E5__4;

			private TaskAwaiter<ResultAnd<PaginatedResponse<T>>> _003C_003Eu__1;

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

		public static ModCollectionRegistry Registry;

		private static bool hasSyncedBefore;

		private static long lastUserEventId;

		private static long lastModEventId;

		[AsyncStateMachine(typeof(_003CLoadRegistryAsync_003Ed__4))]
		public static Task<Result> LoadRegistryAsync()
		{
			return null;
		}

		public static Result LoadRegistry()
		{
			return default(Result);
		}

		[AsyncStateMachine(typeof(_003CSaveRegistry_003Ed__6))]
		public static void SaveRegistry()
		{
		}

		public static void ClearRegistry()
		{
		}

		public static void ClearUserData()
		{
		}

		public static void AddUserToRegistry(UserObject user)
		{
		}

		[AsyncStateMachine(typeof(_003CFetchUpdates_003Ed__10))]
		public static Task<Result> FetchUpdates()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSyncUsersSubscriptions_003Ed__11))]
		private static Task<Result> SyncUsersSubscriptions(long user)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CTryRequestAllResults_003Ed__12<>))]
		public static Task<ResultAnd<T[]>> TryRequestAllResults<T>(string url, Func<WebRequestConfig> webrequestFactory)
		{
			return null;
		}

		public static void AddModCollectionEntry(ModId modId)
		{
		}

		public static void UpdateModCollectionEntry(ModId modId, ModObject modObject)
		{
		}

		public static void AddModToUserSubscriptions(ModId modId, bool saveRegistry = true)
		{
		}

		public static void RemoveModFromUserSubscriptions(ModId modId, bool offline, bool saveRegistry = true)
		{
		}

		public static void UpdateModCollectionEntryFromModObject(ModObject modObject, bool saveRegistry = true)
		{
		}

		public static bool EnableModForCurrentUser(ModId modId)
		{
			return false;
		}

		public static bool DisableModForCurrentUser(ModId modId)
		{
			return false;
		}

		public static InstalledMod[] GetInstalledMods(out Result result, bool excludeSubscribedModsForCurrentUser)
		{
			result = default(Result);
			return null;
		}

		public static SubscribedMod[] GetSubscribedModsForUser(out Result result)
		{
			result = default(Result);
			return null;
		}

		public static SubscribedMod ConvertModCollectionEntryToSubscribedMod(ModCollectionEntry entry)
		{
			return default(SubscribedMod);
		}

		public static InstalledMod ConvertModCollectionEntryToInstalledMod(ModCollectionEntry entry, string directory)
		{
			return default(InstalledMod);
		}

		public static Result MarkModForUninstallIfNotSubscribedToCurrentSession(ModId modId)
		{
			return default(Result);
		}

		private static bool IsRegistryLoaded()
		{
			return false;
		}

		public static bool DoesUserExist(long user = 0L)
		{
			return false;
		}

		public static long GetUserKey()
		{
			return 0L;
		}
	}
}
