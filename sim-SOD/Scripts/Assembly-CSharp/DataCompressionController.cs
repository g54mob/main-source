using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class DataCompressionController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0<T> where T : class
	{
		public string jsonString;

		public int compressionQuality;

		public string filePath;

		public bool success;

		internal void _003CCompressAndSaveDataAsync_003Eb__0()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCompressAndSaveDataAsync_003Ed__5<T> : IAsyncStateMachine where T : class
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public int compressionQuality;

		public string filePath;

		public T input;

		private _003C_003Ec__DisplayClass5_0<T> _003C_003E8__1;

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

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0<T> where T : class
	{
		public byte[] loadedBytes;

		public string filePath;

		public Type typeParameterType;

		internal void _003CLoadCompressedDataAsync_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1<T> where T : class
	{
		public string jsonString;

		public _003C_003Ec__DisplayClass6_0<T> CS_0024_003C_003E8__locals1;

		internal void _003CLoadCompressedDataAsync_003Eb__1()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_2<T> where T : class
	{
		public string tempFile;

		public ulong[] progress;

		public string jsonString;

		internal void _003CLoadCompressedDataAsync_003Eb__2()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CLoadCompressedDataAsync_003Ed__6<T> : IAsyncStateMachine where T : class
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string filePath;

		private _003C_003Ec__DisplayClass6_0<T> _003C_003E8__1;

		private _003C_003Ec__DisplayClass6_1<T> _003C_003E8__2;

		private _003C_003Ec__DisplayClass6_2<T> _003C_003E8__3;

		public Action<T> onComplete;

		private T _003Coutput_003E5__2;

		private bool _003Csuccess_003E5__3;

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

	private static DataCompressionController _instance;

	public static DataCompressionController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	[AsyncStateMachine(typeof(_003CCompressAndSaveDataAsync_003Ed__5<>))]
	public Task<bool> CompressAndSaveDataAsync<T>(T input, string filePath, int compressionQuality = 9) where T : class
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CLoadCompressedDataAsync_003Ed__6<>))]
	public Task<bool> LoadCompressedDataAsync<T>(string filePath, Action<T> onComplete) where T : class
	{
		return null;
	}
}
