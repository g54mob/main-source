using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using __Project__.Scripts.Multiplayer;

public class SceneDataTraveler : NoktaSingletonPunCallbacks<SceneDataTraveler>
{
	[CompilerGenerated]
	private sealed class _003CJoinRoomRoutine_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SceneDataTraveler _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CJoinRoomRoutine_003Ed__19(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CNewGameEnumerator_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SceneDataTraveler _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CNewGameEnumerator_003Ed__4(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWaitWithTimeout_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float timeout;

		public Func<bool> done;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CWaitWithTimeout_003Ed__20(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public bool IsDefaultSave;

	public string RegionedRoomCodeCache;

	public string RegionedRoomCodeExternal;

	private static readonly RegionInfo[] Regions;

	private string m_RegionCode;

	private string m_RoomCode;

	private bool m_ConnectedOk;

	private bool m_ConnectedFail;

	private bool m_JoinOk;

	private bool m_JoinFail;

	private DisconnectCause m_DiscCause;

	private short m_JoinErrorCode;

	private string m_JoinErrorMsg;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void IsNewGameTraveler(Scene scene, LoadSceneMode loadSceneMode)
	{
	}

	[IteratorStateMachine(typeof(_003CNewGameEnumerator_003Ed__4))]
	private IEnumerator NewGameEnumerator()
	{
		return null;
	}

	private void NewGameCheck()
	{
	}

	public void JoinDirectlyToRoom(string regionedRoomCode = "-1")
	{
	}

	[IteratorStateMachine(typeof(_003CJoinRoomRoutine_003Ed__19))]
	private IEnumerator JoinRoomRoutine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CWaitWithTimeout_003Ed__20))]
	private IEnumerator WaitWithTimeout(float timeout, Func<bool> done)
	{
		return null;
	}

	private bool IsOnRegion(string regionCode)
	{
		return false;
	}

	private string ParseRegionString(string regionedRoomCodeExternal, out string regionCode)
	{
		regionCode = null;
		return null;
	}

	public override void OnConnectedToMaster()
	{
	}

	public override void OnDisconnected(DisconnectCause cause)
	{
	}

	public override void OnJoinedRoom()
	{
	}

	public override void OnJoinRoomFailed(short returnCode, string message)
	{
	}
}
