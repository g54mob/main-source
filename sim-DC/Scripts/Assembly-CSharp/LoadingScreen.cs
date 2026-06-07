using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
	public delegate void GameIsLoaded();

	[CompilerGenerated]
	private sealed class _003CAsynchronousLoad_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		public int sceneIndex;

		private AsyncOperation _003Cao_003E5__2;

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
		public _003CAsynchronousLoad_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003CAsynchronousUnLoad_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		public int sceneIndex;

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
		public _003CAsynchronousUnLoad_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003CLoadGameLoadScene_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int[] loadedScenes;

		public LoadingScreen _003C_003E4__this;

		private int[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

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
		public _003CLoadGameLoadScene_003Ed__13(int _003C_003E1__state)
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
	private sealed class _003CLoadPlayerAndNPCDataWithDelay_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerData playerData;

		public int[] hiredTechnicians;

		public List<RepairJobSaveData> repairJobQueue;

		public List<TechnicianSaveData> technicianData;

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
		public _003CLoadPlayerAndNPCDataWithDelay_003Ed__12(int _003C_003E1__state)
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
	private sealed class _003CStart_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

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
		public _003CStart_003Ed__10(int _003C_003E1__state)
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

	public static LoadingScreen instance;

	public int sceneToLoad;

	private int numberOfScenesInBuild;

	public float distanceToLoadScene;

	public float howOftenToCheckDisance;

	public float progressOfLoading;

	public bool isNewGame;

	public static GameIsLoaded onGameIsLoadedCallback;

	private void Awake()
	{
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__10))]
	private IEnumerator Start()
	{
		return null;
	}

	public void LoadGameScenesVoid(PlayerData playerData, List<TechnicianSaveData> technicianData, int[] loadedScenes = null, int[] hiredTechnicians = null, List<RepairJobSaveData> repairJobQueue = null)
	{
	}

	[IteratorStateMachine(typeof(_003CLoadPlayerAndNPCDataWithDelay_003Ed__12))]
	private IEnumerator LoadPlayerAndNPCDataWithDelay(PlayerData playerData, List<TechnicianSaveData> technicianData, int[] hiredTechnicians, List<RepairJobSaveData> repairJobQueue)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CLoadGameLoadScene_003Ed__13))]
	private IEnumerator LoadGameLoadScene(int[] loadedScenes = null)
	{
		return null;
	}

	public void SetDifficualty(int i)
	{
	}

	public void LoadLevel(int sceneIndex)
	{
	}

	public void UnLoadLevel(int sceneIndex)
	{
	}

	[IteratorStateMachine(typeof(_003CAsynchronousLoad_003Ed__17))]
	private IEnumerator AsynchronousLoad(int sceneIndex)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAsynchronousUnLoad_003Ed__18))]
	private IEnumerator AsynchronousUnLoad(int sceneIndex)
	{
		return null;
	}

	public bool IsSceneLoaded(string name)
	{
		return false;
	}
}
