using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Devolver.ExtensionsAPI;
using Devolver.ExtensionsAuth;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class TwitchMgr : MonoBehaviour
{
	public delegate void NoArgsEvent();

	public delegate void PollResultEvent(List<PollResult> results, int totalVotes);

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public Action<List<PollResult>, int> onCompleted;

		public List<PollResult> outResults;

		public int totalVotes;

		internal void _003CCreatePoll_003Eb__0()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CAuthenticate_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public TwitchMgr _003C_003E4__this;

		private TaskAwaiter<JObject> _003C_003Eu__1;

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
	private struct _003CCreatePoll_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public Action<List<PollResult>, int> onCompleted;

		public object[] inOptions;

		public TwitchMgr _003C_003E4__this;

		public float pollLen;

		public TwitchVoteType t;

		public int numChoices;

		private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

		private string _003CpollID_003E5__2;

		private TaskAwaiter<JObject> _003C_003Eu__1;

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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CGetActiveViewerSettings_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public TwitchMgr _003C_003E4__this;

		public int userRequests;

		private TaskAwaiter<JObject> _003C_003Eu__1;

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

	public static TwitchMgr I;

	private ExtensionAPI api;

	public static readonly string[] sRandomEventSlugs;

	public static readonly string[] sVoteTypeSlugs;

	[NonSerialized]
	public bool IsAuthed;

	public NoArgsEvent OnAuthChanged;

	private ExtensionAuth _auth;

	private bool _isPollInProgress;

	private void Awake()
	{
	}

	private void CreateAuth()
	{
	}

	[AsyncStateMachine(typeof(_003CAuthenticate_003Ed__12))]
	public void Authenticate()
	{
	}

	public void Disconnect()
	{
	}

	public object[] CreatePollOptions(TwitchRandomEventType e1, TwitchRandomEventType e2 = TwitchRandomEventType.kNum, TwitchRandomEventType e3 = TwitchRandomEventType.kNum)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CCreatePoll_003Ed__15))]
	public void CreatePoll(TwitchVoteType t, object[] inOptions, float pollLen, int numChoices, Action<List<PollResult>, int> onCompleted)
	{
	}

	[AsyncStateMachine(typeof(_003CGetActiveViewerSettings_003Ed__16))]
	public void GetActiveViewerSettings(int userRequests)
	{
	}

	public bool IsPollInProgress()
	{
		return false;
	}

	public void processAuth(Response response)
	{
	}

	public TwitchRandomEventType GetEventForSlug(string slug)
	{
		return default(TwitchRandomEventType);
	}

	public string GetDescSlug(TwitchRandomEventType t)
	{
		return null;
	}

	public bool IsPositive(TwitchRandomEventType t)
	{
		return false;
	}
}
