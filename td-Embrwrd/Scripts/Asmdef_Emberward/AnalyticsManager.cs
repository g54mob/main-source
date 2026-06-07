using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CInitialize_003Ed__4 : IAsyncStateMachine
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

	public static AnalyticsManager instance;

	private static bool isAnalyticsEnabled;

	private static bool isInitialized;

	private void Awake()
	{
	}

	[AsyncStateMachine(typeof(_003CInitialize_003Ed__4))]
	private void Initialize()
	{
	}

	public static void SendAnalytics(string eventName, Dictionary<string, object> eventData)
	{
	}

	public void RecordDifficulty(eGameDifficultyType diff)
	{
	}

	public void RecordLevelFinishedStatus(string levelName, eGameDifficultyType difficulty, bool isSuccess)
	{
	}
}
