using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation
{
	internal static class ModManagement
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWakeUp_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

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
		private struct _003CPerformJobs_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

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
		private struct _003CPerformJob_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModManagementJob job;

			private long _003CmodId_003E5__2;

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
		private struct _003CPerformOperation_Download_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModManagementJob job;

			private long _003CmodId_003E5__2;

			private long _003CfileId_003E5__3;

			private string _003Cmd5_003E5__4;

			private string _003CdownloadFilepath_003E5__5;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter<ResultAnd<ModObject>> _003C_003Eu__2;

			private ModIOFileStream _003CdownloadStream_003E5__6;

			private TaskAwaiter<Result> _003C_003Eu__3;

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
		private struct _003CPerformOperation_Install_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModManagementJob job;

			private long _003CmodId_003E5__2;

			private long _003CfileId_003E5__3;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter<Result> _003C_003Eu__2;

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
		private struct _003CPerformOperation_Delete_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public long modId;

			public long fileId;

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
		private struct _003CShutdownOperations_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

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

		private static Task operation;

		private static bool isModManagementEnabled;

		private static bool isModManagementAwake;

		private static HashSet<ModId> taintedMods;

		private static HashSet<ModId> notEnoughStorageMods;

		private static List<ModId> uninstalledModsWithNoUserSubscriptions;

		private static HashSet<CreationToken> creationTokens;

		public static ModManagementJob currentJob;

		private static Dictionary<long, ModManagementOperationType> previousJobs;

		public static ModManagementEventDelegate modManagementEventDelegate;

		private static HashSet<long> abortingDownloadsModObjectIds;

		public static CreationToken GenerateNewCreationToken()
		{
			return null;
		}

		public static void InvalidateCreationToken(CreationToken token)
		{
		}

		public static bool IsCreationTokenValid(CreationToken token)
		{
			return false;
		}

		public static void EnableModManagement()
		{
		}

		public static void DisableModManagement()
		{
		}

		[AsyncStateMachine(typeof(_003CWakeUp_003Ed__16))]
		public static void WakeUp()
		{
		}

		public static void AbortCurrentInstallJob()
		{
		}

		public static void AbortCurrentDownloadJob()
		{
		}

		private static bool DownloadIsAborting(long id)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CPerformJobs_003Ed__20))]
		private static Task PerformJobs()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CPerformJob_003Ed__21))]
		public static Task<Result> PerformJob(ModManagementJob job)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CPerformOperation_Download_003Ed__22))]
		private static Task<Result> PerformOperation_Download(ModManagementJob job)
		{
			return null;
		}

		private static Result DownloadCleanup(Result result, long modId, long fileId)
		{
			return default(Result);
		}

		[AsyncStateMachine(typeof(_003CPerformOperation_Install_003Ed__24))]
		private static Task<Result> PerformOperation_Install(ModManagementJob job)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CPerformOperation_Delete_003Ed__25))]
		private static Task<Result> PerformOperation_Delete(long modId, long fileId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CShutdownOperations_003Ed__26))]
		public static Task ShutdownOperations()
		{
			return null;
		}

		public static ProgressHandle GetCurrentOperationProgress()
		{
			return null;
		}

		public static void InvokeModManagementDelegate(ModId modId, ModManagementEventType eventType, Result eventResult)
		{
		}

		public static SubscribedModStatus GetModCollectionEntrysSubscribedModStatus(ModCollectionEntry mod)
		{
			return default(SubscribedModStatus);
		}

		private static ModManagementJob GetNextModManagementJob()
		{
			return null;
		}

		private static ModManagementJob FilterJob(ModManagementJob job, ModCollectionEntry mod, ModManagementOperationType jobType)
		{
			return null;
		}

		private static ModManagementOperationType GetNextJobTypeForModCollectionEntry(ModCollectionEntry mod)
		{
			return default(ModManagementOperationType);
		}

		private static bool ShouldThisModBeUninstalled(ModId modId)
		{
			return false;
		}

		public static bool ValidateDownload_md5(string correctMD5, string zippedFilepath)
		{
			return false;
		}

		private static bool ShouldModManagementBeRunning()
		{
			return false;
		}

		public static void RemoveModFromTaintedJobs(ModId modid)
		{
		}
	}
}
