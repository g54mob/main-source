using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Localization.Components;

public class LoadingScene : NoktaSingleton<LoadingScene>
{
	[CompilerGenerated]
	private sealed class _003CLoadSceneAsync_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string sceneName;

		public LoadingScene _003C_003E4__this;

		private AsyncOperation _003Coperation_003E5__2;

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
		public _003CLoadSceneAsync_003Ed__3(int _003C_003E1__state)
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

	public GameObject LoadingScreen;

	public LocalizeStringEvent LoadingTextLocalizeStringEvent;

	public void LoadScene(string sceneName)
	{
	}

	[IteratorStateMachine(typeof(_003CLoadSceneAsync_003Ed__3))]
	private IEnumerator LoadSceneAsync(string sceneName)
	{
		return null;
	}

	public void SwitchLoadingScreen(bool willOpen)
	{
	}

	public void SetLocalizeStringEvent(string localizationKey)
	{
	}
}
