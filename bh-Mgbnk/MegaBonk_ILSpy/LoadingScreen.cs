using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
	private sealed class _003CLoadSceneAsync_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		private string _003CsceneToLoad_003E5__2;

		private AsyncOperation _003CasyncLoad_003E5__3;

		private float _003Ctimer_003E5__4;

		private float _003Ctimeout_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CLoadSceneAsync_003Ed__8(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00c5: Expected I4, but got I8
			//IL_013c: Expected O, but got I4
			//IL_01d6: Expected O, but got I4
			//IL_0183: Expected O, but got Ref
			//IL_018c: Expected O, but got I4
			//IL_031a: Expected I4, but got O
			LoadingScreen loadingScreen = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003CsceneToLoad_003E5__2 = sceneName;
				if (MapController.isFinalBossStage)
				{
					_003CsceneToLoad_003E5__2 = finalMapName;
				}
				AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_003CsceneToLoad_003E5__2);
				_003CasyncLoad_003E5__3 = asyncOperation;
				isLoading = true;
				_003CasyncLoad_003E5__3.allowSceneActivation = false;
				_003Ctimer_003E5__4 = 0f;
				_003Ctimeout_003E5__5 = 30f;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0299;
				}
				_003C_003E1__state = -1;
			}
			if (!_003CasyncLoad_003E5__3.isDone)
			{
				float deltaTime = Time.deltaTime;
				float num = deltaTime + _003Ctimer_003E5__4;
				_003Ctimer_003E5__4 = num;
				bool flag = loadingScreen.loadingBar != null;
				bool flag2 = !flag;
				object obj = 0;
				if (!flag2)
				{
					Transform transform = loadingScreen.loadingBar.transform;
					float progress = _003CasyncLoad_003E5__3.progress;
					float num2 = default(float);
					transform.localScale = (Vector3)(&num2);
					obj = 0;
				}
				float progress2 = _003CasyncLoad_003E5__3.progress;
				if (!(progress2 < 0.9f))
				{
					_003CasyncLoad_003E5__3.allowSceneActivation = true;
					obj = 0;
				}
				if (!(_003Ctimer_003E5__4 > _003Ctimeout_003E5__5))
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				string message = $"[LoadingScreen] Scene load stuck for {arg} seconds! Scene='{_003CsceneToLoad_003E5__2}'";
				Debug.LogError(message);
				if (_003CasyncLoad_003E5__3 == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003CasyncLoad_003E5__3.allowSceneActivation = false;
				SceneManager.LoadScene(_003CsceneToLoad_003E5__2, LoadSceneMode.Single);
			}
			goto IL_0299;
			IL_0299:
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

	private static string sceneName = "GeneratedMap";

	private static string finalMapName = "FinalBossMap";

	public Transform loadingBar;

	public TextMeshProUGUI t_loading;

	public static bool isLoading;

	private void Start()
	{
		WindowManager.CloseAll();
		TextMeshProUGUI textMeshProUGUI = t_loading;
		string localizedString = LocalizationUtility.GetLocalizedString("MainMenuOther", "LOADING");
		textMeshProUGUI.text = localizedString;
		isLoading = true;
		_003CLoadSceneAsync_003Ed__8 obj = new _003CLoadSceneAsync_003Ed__8(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void OnDestroy()
	{
		isLoading = false;
	}

	private void OnDisable()
	{
		isLoading = false;
	}

	private IEnumerator LoadSceneAsync()
	{
		_003CLoadSceneAsync_003Ed__8 obj = new _003CLoadSceneAsync_003Ed__8(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public static void LoadInstant()
	{
		string text = sceneName;
		if (MapController.isFinalBossStage)
		{
			text = finalMapName;
		}
		SceneManager.LoadScene(text, LoadSceneMode.Single);
	}
}
