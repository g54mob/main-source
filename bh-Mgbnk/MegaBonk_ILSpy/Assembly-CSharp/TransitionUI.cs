using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionUI : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public string mapName;

		internal void _003CStartLoadingMap_003Eb__0()
		{
			SceneManager.LoadScene(mapName);
		}
	}

	private sealed class _003CDoTransition_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TransitionUI _003C_003E4__this;

		public float newTransitionTime;

		public float delay;

		public Action action;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoTransition_003Ed__13(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_01d4: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0296: Expected I4, but got O
			//IL_0195: Expected I4, but got I8
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_010d: Expected I4, but got I8
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_00a8: Expected I4, but got I8
			//IL_0093: Expected I4, but got I8
			TransitionUI transitionUI = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 2;
					return true;
				}
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					bool result;
					if (!flag)
					{
						bool flag2 = (nint)obj3 != 1;
						result = false;
						if (!flag2)
						{
							_003C_003E1__state = -1;
							return false;
						}
					}
					else
					{
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this == null)
						{
							goto IL_0288;
						}
						IEnumerator enumerator = _003C_003E4__this.EndTransition();
						_003C_003E2__current = enumerator;
						_003C_003E1__state = 4;
						result = true;
					}
					return result;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if (transitionUI.isTransitioning)
					{
						Action action = this.action;
						if (this.action != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v189.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
					}
					transitionUI.isTransitioning = false;
					_003C_003E2__current = null;
					_003C_003E1__state = 3;
					return true;
				}
			}
			else
			{
				_003C_003E1__state = -1;
				Action a_transitionStart = A_transitionStart;
				if (A_transitionStart != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v48.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				if ((object)_003C_003E4__this != null)
				{
					transitionUI.isTransitioning = true;
					if ((object)transitionUI.overlay != null)
					{
						transitionUI.overlay.CrossFadeAlpha(1f, newTransitionTime, ignoreTimeScale: false);
						WaitForSeconds waitForSeconds2 = new WaitForSeconds(newTransitionTime);
						_003C_003E2__current = waitForSeconds2;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			goto IL_0288;
			IL_0288:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private sealed class _003CEndTransition_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TransitionUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CEndTransition_003Ed__15(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_001e: Expected I4, but got I8
			//IL_00e4: Expected I4, but got I8
			//IL_0128: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				TransitionUI transitionUI = _003C_003E4__this;
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)transitionUI.overlay != null)
				{
					transitionUI.overlay.CrossFadeAlpha(0f, transitionUI.fadeInTime, ignoreTimeScale: false);
					WaitForSeconds waitForSeconds = new WaitForSeconds(transitionUI.fadeInTime);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 1;
					return true;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				Action a_transitionEnd = A_transitionEnd;
				if (A_transitionEnd != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v90.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public RawImage overlay;

	private float transitionTime;

	public static TransitionUI Instance;

	public bool isTransitioning;

	public static Action A_transitionEnd;

	public static Action A_transitionStart;

	public static Action A_MapTransitionStart;

	private string sceneMainMenuName;

	private float fadeInTime;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			overlay.enabled = true;
			overlay.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
			UnityAction<Scene, LoadSceneMode> value = (UnityAction<Scene, LoadSceneMode>)(object)new UnityAction<Scene, System.Int32Enum>(OnNewSceneLoaded);
			SceneManager.sceneLoaded += value;
		}
		else
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
	}

	private void Start()
	{
		if (!Testing.isTesting && Instance == this)
		{
			overlay.CrossFadeAlpha(1f, 0f, ignoreTimeScale: true);
			IEnumerator routine = EndTransition();
			Coroutine coroutine = StartCoroutine(routine);
		}
	}

	public void LoadMenu()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x180392D90\"");
	}

	public void StartLoadingMap(string mapName)
	{
		//IL_00d9: Expected O, but got I
		//IL_00ee: Expected O, but got I
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals3.mapName = mapName;
		if (CS_0024_003C_003E8__locals3.mapName != sceneMainMenuName && GameManager.Instance != null && MapController.index == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
			UnityEngine.Object obj = default(UnityEngine.Object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v28+20]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v29+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v30+8C]");
				if ((nint)0 == 1)
				{
					LoadingScreen.LoadInstant();
					return;
				}
			}
		}
		Action action = delegate
		{
			SceneManager.LoadScene(CS_0024_003C_003E8__locals3.mapName);
		};
		IEnumerator routine = DoTransition(action, transitionTime);
		Coroutine coroutine = StartCoroutine(routine);
		Action a_MapTransitionStart = A_MapTransitionStart;
		if (A_MapTransitionStart != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v316.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void StartTransition(Action action, float transitionTime = 0.5f, float delay = 0.5f)
	{
		IEnumerator routine = DoTransition(action, transitionTime, delay);
		Coroutine coroutine = StartCoroutine(routine);
	}

	private IEnumerator DoTransition(Action action, float newTransitionTime, float delay = 0.5f)
	{
		_003CDoTransition_003Ed__13 obj = new _003CDoTransition_003Ed__13(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.action = action;
		obj.newTransitionTime = newTransitionTime;
		obj.delay = delay;
		return obj;
	}

	private IEnumerator EndTransition()
	{
		_003CEndTransition_003Ed__15 obj = new _003CEndTransition_003Ed__15(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void StopTransition()
	{
		isTransitioning = false;
	}

	public bool IsTransitioning()
	{
		return isTransitioning;
	}

	private void OnNewSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
	}

	public float GetTransitionTime()
	{
		return transitionTime;
	}

	public TransitionUI()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317212F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		transitionTime = 0.5f;
		sceneMainMenuName = "MainMenu";
		fadeInTime = 1f;
		base._002Ector();
	}
}
