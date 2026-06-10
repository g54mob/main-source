using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace ModIO.Implementation
{
	internal static class IOUtil
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetFileHashFromFilePath_md5_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string filepath;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

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
		private struct _003CGetRawBytesFromFile_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<byte[]> _003C_003Et__builder;

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

		public static bool TryParseUTF8JSONData<T>(byte[] data, out T jsonObject, out Result result)
		{
			jsonObject = default(T);
			result = default(Result);
			return false;
		}

		public static byte[] GenerateUTF8JSONData<T>(T jsonObject)
		{
			return null;
		}

		public static bool TryParseImageData(byte[] data, out Texture2D texture, out Result result)
		{
			texture = null;
			result = default(Result);
			return false;
		}

		public static string GenerateMD5(Stream data)
		{
			return null;
		}

		public static string GenerateMD5(byte[] data)
		{
			return null;
		}

		public static string GenerateArchiveMD5(string filepath)
		{
			return null;
		}

		public static Result GenerateMD5(Stream stream, out string MD5)
		{
			MD5 = null;
			return default(Result);
		}

		public static string GenerateMD5(string text)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetFileHashFromFilePath_md5_003Ed__8))]
		internal static Task<string> GetFileHashFromFilePath_md5(string filepath)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetRawBytesFromFile_003Ed__9))]
		internal static Task<byte[]> GetRawBytesFromFile(string filepath)
		{
			return null;
		}

		internal static string CleanFileNameForInvalidCharacters(string filename)
		{
			return null;
		}
	}
}
