using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO.Implementation.Platform;
using ModIO.Util;

namespace ModIO.Implementation
{
	internal static class DataStorage
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSaveUserDataAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

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
		private struct _003CLoadUserDataAsync_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			private TaskAwaiter<ResultAnd<byte[]>> _003C_003Eu__1;

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
		private struct _003CTryRetrieveImageBytes_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<byte[]>> _003C_003Et__builder;

			public string imageURL;

			private TaskAwaiter<ResultAnd<byte[]>> _003C_003Eu__1;

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
		private struct _003CSaveSystemRegistry_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModCollectionRegistry registry;

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
		private struct _003CLoadSystemRegistryAsync_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModCollectionRegistry>> _003C_003Et__builder;

			private TaskAwaiter<ResultAnd<byte[]>> _003C_003Eu__1;

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

		[CompilerGenerated]
		private sealed class _003CIterateFilesInDirectory_003Ed__36 : IEnumerable<ResultAnd<ModIOFileStream>>, IEnumerable, IEnumerator<ResultAnd<ModIOFileStream>>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ResultAnd<ModIOFileStream> _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private string directoryPath;

			public string _003C_003E3__directoryPath;

			private IDataService _003CdataService_003E5__2;

			private uint _003CresultCode_003E5__3;

			private List<string>.Enumerator _003C_003E7__wrap3;

			ResultAnd<ModIOFileStream> IEnumerator<ResultAnd<ModIOFileStream>>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CIterateFilesInDirectory_003Ed__36(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ResultAnd<ModIOFileStream>> IEnumerable<ResultAnd<ModIOFileStream>>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		internal static TaskQueueRunner taskRunner;

		private static Mutex FileWriteMutex;

		public static IPersistentDataService persistent;

		public static IUserDataService user;

		public static ITempDataService temp;

		private const string UserDataFilePath = "user.json";

		public static Mutex GetFileWriteMutex()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSaveUserDataAsync_003Ed__7))]
		public static Task<Result> SaveUserDataAsync()
		{
			return null;
		}

		public static Result SaveUserData()
		{
			return default(Result);
		}

		[AsyncStateMachine(typeof(_003CLoadUserDataAsync_003Ed__9))]
		public static Task<Result> LoadUserDataAsync()
		{
			return null;
		}

		public static Result LoadUserData()
		{
			return default(Result);
		}

		public static string GenerateImageCacheFilePath(string imageURL)
		{
			return null;
		}

		public static Result DeleteStoredImage(string imageURL)
		{
			return default(Result);
		}

		public static ResultAnd<ModIOFileStream> GetImageFileReadStream(string imageURL)
		{
			return null;
		}

		public static ResultAnd<ModIOFileStream> GetImageFileWriteStream(string imageURL)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CTryRetrieveImageBytes_003Ed__15))]
		public static Task<ResultAnd<byte[]>> TryRetrieveImageBytes(string imageURL)
		{
			return null;
		}

		public static string GenerateExtractionDirectoryPath()
		{
			return null;
		}

		public static string GenerateInstallationDirectoryPath(long modId, long modfileId)
		{
			return null;
		}

		public static string GenerateModfileDetailsDirectoryPath(string directory)
		{
			return null;
		}

		public static string GenerateModfileArchiveFilePath(long modId, long modfileId)
		{
			return null;
		}

		public static bool TryGetInstallationDirectory(long modId, long modfileId, out string directoryPath)
		{
			directoryPath = null;
			return false;
		}

		public static bool TryGetModfileDetailsDirectory(string directoryPath, out string properDirectory)
		{
			properDirectory = null;
			return false;
		}

		public static bool TryGetModfileArchive(long modId, long modfileId, out string filePath)
		{
			filePath = null;
			return false;
		}

		public static bool TryDeleteModfileArchive(long modId, long modfileId, out Result result)
		{
			result = default(Result);
			return false;
		}

		public static bool TryDeleteInstalledMod(long modId, long modfileId, out Result result)
		{
			result = default(Result);
			return false;
		}

		public static void DeleteExtractionDirectory()
		{
		}

		public static Result MakeInstallationFromExtractionDirectory(long modId, long modfileId)
		{
			return default(Result);
		}

		public static ResultAnd<string> GetModfileArchivePathIfValid(long modId, long modfileId, long expectedSize, string expectedHash)
		{
			return null;
		}

		public static string GenerateSystemRegistryFilePath()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSaveSystemRegistry_003Ed__29))]
		public static Task<Result> SaveSystemRegistry(ModCollectionRegistry registry)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadSystemRegistryAsync_003Ed__30))]
		public static Task<ResultAnd<ModCollectionRegistry>> LoadSystemRegistryAsync()
		{
			return null;
		}

		public static ResultAnd<ModCollectionRegistry> LoadSystemRegistry()
		{
			return null;
		}

		public static ModIOFileStream OpenArchiveReadStream(string filePath, out Result result)
		{
			result = default(Result);
			return null;
		}

		public static ModIOFileStream OpenArchiveReadStream(long modId, long modfileId, out Result result)
		{
			result = default(Result);
			return null;
		}

		public static ModIOFileStream OpenArchiveEntryOutputStream(string relativePath, out Result result)
		{
			result = default(Result);
			return null;
		}

		public static ModIOFileStream CreateArchiveDownloadStream(string absolutePath, out Result result)
		{
			result = default(Result);
			return null;
		}

		[IteratorStateMachine(typeof(_003CIterateFilesInDirectory_003Ed__36))]
		public static IEnumerable<ResultAnd<ModIOFileStream>> IterateFilesInDirectory(string directoryPath)
		{
			return null;
		}
	}
}
