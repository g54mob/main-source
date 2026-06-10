using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class SaveStateController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public string path;

		public string jsonString;

		internal void _003CCaptureSaveStateAsync_003Eb__1()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCaptureSaveStateAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string path;

		public bool isOverwrite;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		private StateSaveData _003Csave_003E5__2;

		private Stopwatch _003CstopWatch_003E5__3;

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

	private static SaveStateController _instance;

	public static SaveStateController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	[AsyncStateMachine(typeof(_003CCaptureSaveStateAsync_003Ed__5))]
	public Task CaptureSaveStateAsync(string path, bool isOverwrite = false)
	{
		return null;
	}

	public void PreLoadCases(ref StateSaveData load)
	{
	}

	public void LoadSaveState(StateSaveData load)
	{
	}

	private void LoadJob(SideJob job)
	{
	}
}
