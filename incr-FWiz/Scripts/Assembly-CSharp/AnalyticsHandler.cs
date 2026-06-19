using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class AnalyticsHandler : MonoBehaviour
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CStart_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AnalyticsHandler _003C_003E4__this;

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

	private bool _isInitialised;

	private string PlayerID;

	private const string PlayerIDSaveKey = "PlayerID";

	public bool AnalyticsOff;

	public static AnalyticsHandler Instance { get; private set; }

	[AsyncStateMachine(typeof(_003CStart_003Ed__8))]
	private void Start()
	{
	}

	private void OnGameStarted(bool newCampaign)
	{
	}

	private void OnGameExited()
	{
	}

	private void OnUpdateGameState(string state)
	{
	}

	private void OnCheckpoint(string checkpoint)
	{
	}

	public void OnPlayerAction(string playerAction)
	{
	}

	public string GetVersion()
	{
		return null;
	}
}
