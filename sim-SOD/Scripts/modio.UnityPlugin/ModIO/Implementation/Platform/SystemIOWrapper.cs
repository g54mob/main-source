using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ModIO.Implementation.Platform
{
	internal static class SystemIOWrapper
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReadFileAsync_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<byte[]>> _003C_003Et__builder;

			public string filePath;

			private byte[] _003Cdata_003E5__2;

			private FileStream _003CsourceStream_003E5__3;

			private TaskAwaiter<int> _003C_003Eu__1;

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
		private struct _003CWriteFileAsync_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public byte[] data;

			public string filePath;

			private FileStream _003CfileStream_003E5__2;

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

		private static HashSet<string> currentlyOpenFiles;

		public static ModIOFileStream OpenReadStream(string filePath, out Result result)
		{
			result = default(Result);
			return null;
		}

		public static ModIOFileStream OpenWriteStream(string filePath, out Result result)
		{
			result = default(Result);
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadFileAsync_003Ed__3))]
		public static Task<ResultAnd<byte[]>> ReadFileAsync(string filePath)
		{
			return null;
		}

		public static ResultAnd<byte[]> ReadFile(string filePath)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWriteFileAsync_003Ed__5))]
		public static Task<Result> WriteFileAsync(string filePath, byte[] data)
		{
			return null;
		}

		public static Result WriteFile(string filePath, byte[] data)
		{
			return default(Result);
		}

		public static Result CreateDirectory(string directoryPath)
		{
			return default(Result);
		}

		public static Result DeleteDirectory(string path)
		{
			return default(Result);
		}

		public static Result MoveDirectory(string directoryPath, string newDirectoryPath)
		{
			return default(Result);
		}

		public static bool IsPathValid(string filePath, out Result result)
		{
			result = default(Result);
			return false;
		}

		public static bool FileExists(string path, out Result result)
		{
			result = default(Result);
			return false;
		}

		public static Result GetFileSizeAndHash(string filePath, out long fileSize, out string fileHash)
		{
			fileSize = default(long);
			fileHash = null;
			return default(Result);
		}

		public static bool DirectoryExists(string path)
		{
			return false;
		}

		public static bool DoesFileExist(string filePath, out Result result)
		{
			result = default(Result);
			return false;
		}

		public static bool TryCreateParentDirectory(string filePath, out Result result)
		{
			result = default(Result);
			return false;
		}

		public static ResultAnd<List<string>> ListAllFiles(string directoryPath)
		{
			return null;
		}

		public static Result DeleteFileGetResult(string path)
		{
			return default(Result);
		}

		public static bool DeleteFile(string path)
		{
			return false;
		}

		public static bool MoveFile(string source, string destination)
		{
			return false;
		}

		public static long GetFileSize(string path)
		{
			return 0L;
		}

		public static IList<string> GetFiles(string path, string nameFilter, bool recurseSubdirectories)
		{
			return null;
		}

		public static IList<string> GetDirectories(string path)
		{
			return null;
		}
	}
}
