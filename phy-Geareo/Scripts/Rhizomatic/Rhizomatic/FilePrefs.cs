using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Rhizomatic
{
	public class FilePrefs
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReadAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<byte[]> _003C_003Et__builder;

			public FilePrefs _003C_003E4__this;

			public string path;

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
		private struct _003CReadTextAsync_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public FilePrefs _003C_003E4__this;

			public string path;

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
		private struct _003CReadTexture2DAsync_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Texture2D> _003C_003Et__builder;

			public FilePrefs _003C_003E4__this;

			public string path;

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
		private struct _003CWriteAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public FilePrefs _003C_003E4__this;

			public string path;

			public byte[] bytes;

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
		private struct _003CWriteTexture2DAsync_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public FilePrefs _003C_003E4__this;

			public string path;

			public Texture2D texture;

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

		public string rootPath;

		public string currentFolder;

		public Dictionary<string, string> folders { get; }

		public FilePrefs(string rootPath)
		{
		}

		public static FilePrefs Build(string rootPath)
		{
			return null;
		}

		public string FullPath()
		{
			return null;
		}

		public string FullPath(string path)
		{
			return null;
		}

		public FilePrefs Folder(string path)
		{
			return null;
		}

		public FilePrefs Folder(string key, string path)
		{
			return null;
		}

		public FilePrefs CreateDirectory(string path)
		{
			return null;
		}

		public FilePrefs In(string folderKey)
		{
			return null;
		}

		public FilePrefs Root()
		{
			return null;
		}

		public void Write(string path, byte[] bytes)
		{
		}

		[AsyncStateMachine(typeof(_003CWriteAsync_003Ed__15))]
		public Task WriteAsync(string path, byte[] bytes)
		{
			return null;
		}

		public void WriteText(string path, string data)
		{
		}

		public void WriteTextAsync(string path, string data)
		{
		}

		public byte[] Read(string path)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadAsync_003Ed__19))]
		public Task<byte[]> ReadAsync(string path)
		{
			return null;
		}

		public string ReadText(string path)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadTextAsync_003Ed__21))]
		public Task<string> ReadTextAsync(string path)
		{
			return null;
		}

		public bool Exist(string path)
		{
			return false;
		}

		public void Delete(string path)
		{
		}

		public string[] GetDirectories()
		{
			return null;
		}

		public string[] GetFiles()
		{
			return null;
		}

		public void WriteTexture2D(string path, Texture2D texture)
		{
		}

		public Texture2D ReadTexture2D(string path)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWriteTexture2DAsync_003Ed__28))]
		public Task WriteTexture2DAsync(string path, Texture2D texture)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadTexture2DAsync_003Ed__29))]
		public Task<Texture2D> ReadTexture2DAsync(string path)
		{
			return null;
		}

		private byte[] WriteTexture2D(Texture2D texture)
		{
			return null;
		}

		private Texture2D ReadTexture2D(byte[] bytes)
		{
			return null;
		}
	}
}
