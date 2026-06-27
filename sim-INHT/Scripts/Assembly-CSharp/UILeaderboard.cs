using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class UILeaderboard : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public LeaderboardEntryResponse self;

		internal bool _003CRefresh_003Eb__0(LeaderboardEntryResponse x)
		{
			return false;
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CRefresh_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public UILeaderboard _003C_003E4__this;

		private _003C_003Ec__DisplayClass12_0 _003C_003E8__1;

		private GetTopLeaderboardResponse _003CentriesResponse_003E5__2;

		private GetMyLeaderboardResponse _003CselfResponse_003E5__3;

		private BackgroundThreadAwaitable _003C_003Eu__1;

		private TaskAwaiter<GetTopLeaderboardResponse> _003C_003Eu__2;

		private TaskAwaiter<GetMyLeaderboardResponse> _003C_003Eu__3;

		private MainThreadAwaitable _003C_003Eu__4;

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

	private const int DefaultLeaderboardCount = 20;

	public bool HasRun;

	public Gamemodes LeaderboardGamemode;

	public UILeaderboardEntry Prefab_Entry;

	public Transform Transform_ListRoot;

	public UILeaderboardEntry Entry_Self;

	public int EntryCount;

	private List<UILeaderboardEntry> spawnedUIEntries;

	private bool refreshInProgress;

	private void Start()
	{
	}

	public static void RefreshAll(bool force)
	{
	}

	public void RefreshNow()
	{
	}

	[AsyncStateMachine(typeof(_003CRefresh_003Ed__12))]
	public Task Refresh()
	{
		return null;
	}

	public static void CleanupImageCache(TimeSpan? maxAge = null)
	{
	}
}
