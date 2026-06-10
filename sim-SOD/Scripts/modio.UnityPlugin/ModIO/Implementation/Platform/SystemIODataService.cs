using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ModIO.Implementation.Platform
{
	internal class SystemIODataService : IUserDataService, IDataService, IPersistentDataService, ITempDataService
	{
		[Serializable]
		internal struct GlobalSettingsFile
		{
			public string RootLocalStoragePath;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReadFileAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<byte[]>> _003C_003Et__builder;

			public string filePath;

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
		private struct _003CWriteFileAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public string filePath;

			public byte[] data;

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
		private struct _003CIsThereEnoughDiskSpaceFor_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public long bytes;

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

		public static readonly string PersistentDataRootDirectory;

		public static readonly string UserRootDirectory;

		public static readonly string TempRootDirectory;

		public static readonly string GlobalSettingsFilePath;

		private string rootDir;

		public string RootDirectory => null;

		Result IUserDataService.Initialize(string userProfileIdentifier, long gameId, BuildSettings settings)
		{
			return default(Result);
		}

		Result IPersistentDataService.Initialize(long gameId, BuildSettings settings)
		{
			return default(Result);
		}

		Result ITempDataService.Initialize(long gameId, BuildSettings settings)
		{
			return default(Result);
		}

		public ModIOFileStream OpenReadStream(string filePath, out Result result)
		{
			result = default(Result);
			return null;
		}

		public ModIOFileStream OpenWriteStream(string filePath, out Result result)
		{
			result = default(Result);
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadFileAsync_003Ed__13))]
		public Task<ResultAnd<byte[]>> ReadFileAsync(string filePath)
		{
			return null;
		}

		public ResultAnd<byte[]> ReadFile(string filePath)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWriteFileAsync_003Ed__15))]
		public Task<Result> WriteFileAsync(string filePath, byte[] data)
		{
			return null;
		}

		public Result WriteFile(string filePath, byte[] data)
		{
			return default(Result);
		}

		public Result DeleteFile(string filePath)
		{
			return default(Result);
		}

		public Result DeleteDirectory(string directoryPath)
		{
			return default(Result);
		}

		public Result MoveDirectory(string directoryPath, string newDirectoryPath)
		{
			return default(Result);
		}

		public bool TryCreateParentDirectory(string path)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CIsThereEnoughDiskSpaceFor_003Ed__21))]
		public Task<bool> IsThereEnoughDiskSpaceFor(long bytes)
		{
			return null;
		}

		public bool FileExists(string filePath)
		{
			return false;
		}

		public Result GetFileSizeAndHash(string filePath, out long fileSize, out string fileHash)
		{
			fileSize = default(long);
			fileHash = null;
			return default(Result);
		}

		public bool DirectoryExists(string directoryPath)
		{
			return false;
		}

		public ResultAnd<List<string>> ListAllFiles(string directoryPath)
		{
			return null;
		}
	}
}
