using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SceneMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_LoadScene_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SceneMgr _003C_003E4__this;

		public GameScene sc;

		public float fadeOutLen;

		private AsyncOperation _003CasyncOp_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003C_LoadScene_003Ed__11(int _003C_003E1__state)
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

	public static SceneMgr I;

	public DelegateUtl.NoArgsEvent OnSceneAboutToChange;

	public DelegateUtl.NoArgsEvent OnSceneLoaded;

	public GameScene PendingScene;

	public GameScene CurScene;

	public GameScene PrevScene;

	public GameObject WrapperLoading;

	public CanvasGroup CvsGrpLoading;

	private bool _isLoading;

	private void Awake()
	{
	}

	public void LoadScene(GameScene sc, float fadeOutLen = 0.5f)
	{
	}

	[IteratorStateMachine(typeof(_003C_LoadScene_003Ed__11))]
	private IEnumerator _LoadScene(GameScene sc, float fadeOutLen = 0.5f)
	{
		return null;
	}

	public static GameScene GetCurScene()
	{
		return default(GameScene);
	}

	public bool IsLoading()
	{
		return false;
	}
}
