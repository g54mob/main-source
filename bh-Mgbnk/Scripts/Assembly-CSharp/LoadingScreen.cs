using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLoadSceneAsync_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		private string _003CsceneToLoad_003E5__2;

		private AsyncOperation _003CasyncLoad_003E5__3;

		private float _003Ctimer_003E5__4;

		private float _003Ctimeout_003E5__5;

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
		public _003CLoadSceneAsync_003Ed__8(int _003C_003E1__state)
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

	private static string sceneName;

	private static string finalMapName;

	public Transform loadingBar;

	public TextMeshProUGUI t_loading;

	public static bool isLoading;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
	}

	[IteratorStateMachine(typeof(_003CLoadSceneAsync_003Ed__8))]
	private IEnumerator LoadSceneAsync()
	{
		return null;
	}

	public static void LoadInstant()
	{
	}
}
