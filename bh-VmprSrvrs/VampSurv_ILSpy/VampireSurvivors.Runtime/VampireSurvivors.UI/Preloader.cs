using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Framework.System;
using VampireSurvivors.App.Scripts.Framework.Initialisation;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class Preloader : MonoBehaviour
{
	[StructLayout((LayoutKind)3)]
	private struct _003CInitAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public Preloader _003C_003E4__this;

		private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_004f: Expected O, but got I4
			//IL_00e5: Expected O, but got I4
			//IL_00f5: Expected O, but got Ref
			//IL_0143: Expected I4, but got I8
			//IL_014e: Expected O, but got Ref
			//IL_00bf: Expected O, but got I
			CancellationToken cancellationToken = default(CancellationToken);
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)0;
				_003C_003E1__state = -1;
			}
			else
			{
				SwitchToMainThreadAwaitable.Awaiter awaiter = default(SwitchToMainThreadAwaitable.Awaiter);
				bool isCompleted = awaiter.IsCompleted;
				bool flag = !isCompleted;
				cancellationToken = (CancellationToken)0;
				if (flag)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)8;
					AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
			Action action = _003C_003E4__this.InitPlatform;
			bool flag2 = action == null;
			object obj = _003C_003E4__this;
			if (!flag2)
			{
				obj = (nint)((Delegate)action).method;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v304.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			_003C_003E1__state = -2;
			object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844336B0");
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class _003CWait_003Ed__18(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AsyncOperation s;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0082: Expected I4, but got I8
			//IL_00f0->IL00cf: Incompatible stack heights: 1 vs 0
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = 1f;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				object obj = s;
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v3 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v3 (System.Object)+10]");
				AsyncOperation.set_allowSceneActivation_Injected((IntPtr)0, true);
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
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitAFrame_003Ed__15(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Action callback;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_0089: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				Action action = callback;
				_003C_003E1__state = -1;
				if (callback != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v75.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
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
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private List<GameObject> _Sprites;

	private TextMeshProUGUI _StatusInfoText;

	private TextMeshProUGUI _ExtraInfoText;

	private Canvas _Canvas;

	private UnityServicesManager _unityServicesManager;

	private PlayerOptions _playerOptions;

	private AchievementManager _achievementManager;

	public static bool HideGraphics;

	private void Construct(UnityServicesManager unityServicesManager)
	{
		//IL_0104: Expected O, but got I4
		//IL_0146: Expected I, but got O
		//IL_015c: Expected O, but got I
		_unityServicesManager = unityServicesManager;
		Action<string> b = UpdateText;
		Delegate obj = PreloaderEvents.UpdateText;
		Action<string> action = default(Action<string>);
		object obj8 = default(object);
		while (true)
		{
			Delegate obj2 = Delegate.Combine(obj, b);
			Action<string> updateText;
			if ((object)obj2 == null)
			{
				updateText = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag = action == null;
				updateText = action;
				if (flag)
				{
					break;
				}
			}
			bool flag2 = (object)obj == PreloaderEvents.UpdateText;
			Delegate obj3;
			if ((object)obj == PreloaderEvents.UpdateText)
			{
				PreloaderEvents.UpdateText = updateText;
				obj3 = obj;
			}
			else
			{
				obj3 = PreloaderEvents.UpdateText;
			}
			Delegate obj4 = obj;
			if (!flag2)
			{
				obj4 = obj3;
			}
			bool flag3 = (object)obj4 != obj;
			obj = obj4;
			if (flag3)
			{
				continue;
			}
			Action<string> b2 = UpdateExtraText;
			Delegate obj5 = PreloaderEvents.UpdateExtraText;
			while (true)
			{
				Delegate obj6 = Delegate.Combine(obj5, b2);
				object obj7;
				if ((object)obj6 == null)
				{
					obj7 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag4 = obj8 == null;
					obj7 = obj8;
					if (flag4)
					{
						break;
					}
				}
				nint num = (nint)typeof(PreloaderEvents);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rcx_v21 (Il2CppClass<VampireSurvivors.UI.PreloaderEvents>)+B8]");
				object obj9 = (nint)0 + (nint)8;
				bool flag5 = obj5 == obj9;
				Delegate obj10;
				if (obj5 == obj9)
				{
					obj9 = obj7;
					obj10 = obj5;
				}
				else
				{
					obj10 = (Delegate)obj9;
				}
				Delegate obj11 = obj5;
				if (!flag5)
				{
					obj11 = obj10;
				}
				bool flag6 = (object)obj11 != obj5;
				obj5 = obj11;
				if (!flag6)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private void Awake()
	{
		Timers.InitManagers();
	}

	private void Start()
	{
		//IL_010c: Expected O, but got I4
		//IL_011f: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		GameObject gameObject = default(GameObject);
		_003CInitAsync_003Ed__11 obj4 = default(_003CInitAsync_003Ed__11);
		while (true)
		{
			List<GameObject> sprites = _Sprites;
			object obj = UnityEngine.Random.RandomRangeInt(0, sprites._size);
			List<GameObject> sprites2 = _Sprites;
			object obj2 = 0;
			object obj3 = 0;
			while ((nint)obj2 < sprites2._size)
			{
				bool active;
				if (obj != obj3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					active = false;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					active = true;
				}
				gameObject.SetActive(active);
				sprites2 = _Sprites;
				obj3++;
				obj2 = obj3;
			}
			obj4.MoveNext();
			if (HideGraphics)
			{
				object canvas = _Canvas;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbx_v10 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					break;
				}
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(canvas);
				continue;
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbx_v10 (System.Object)+10]");
		Behaviour.set_enabled_Injected((IntPtr)0, false);
	}

	private UniTaskVoid InitAsync()
	{
		//IL_001a: Expected O, but got I4
		_003CInitAsync_003Ed__11 obj = default(_003CInitAsync_003Ed__11);
		obj.MoveNext();
		return (UniTaskVoid)0;
	}

	private void InitPlatform()
	{
		Action callback = delegate
		{
			Action onComplete = LoadNextScene;
			PlatformIntegration.Init(_playerOptions, _achievementManager, onComplete);
		};
		_003CWaitAFrame_003Ed__15 obj = null;
		obj._003C_003E1__state = 0;
		obj.callback = callback;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void UpdateText(string newText)
	{
		TextMeshProUGUI statusInfoText = _StatusInfoText;
		if ((object)_StatusInfoText != null && ((UnityEngine.Object)statusInfoText).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
			_StatusInfoText.ForceMeshUpdate();
		}
	}

	private unsafe void UpdateExtraText(string newText)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Ref, but got Unknown
		//IL_0181: Expected I8, but got I4
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected Ref, but got Unknown
		TextMeshProUGUI extraInfoText = _ExtraInfoText;
		if ((object)_ExtraInfoText == null || ((UnityEngine.Object)extraInfoText).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		_ExtraInfoText.ForceMeshUpdate();
		TextMeshProUGUI statusInfoText = _StatusInfoText;
		if ((object)_StatusInfoText == null || ((UnityEngine.Object)statusInfoText).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		RectTransform rectTransform = _StatusInfoText.rectTransform;
		Vector2 anchoredPosition = rectTransform.anchoredPosition;
		RectTransform rectTransform2 = _StatusInfoText.rectTransform;
		object obj = "";
		bool flag2;
		if ((object)newText != "")
		{
			if (newText != null && "" != null)
			{
				int stringLength = newText._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rdx_v8+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(newText + 20);
					ulong length = (ulong)(newText._stringLength + newText._stringLength);
					bool flag = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
					flag2 = flag;
					goto IL_0238;
				}
			}
			flag2 = false;
		}
		else
		{
			flag2 = true;
		}
		goto IL_0238;
		IL_0238:
		if (flag2)
		{
			Vector2 anchoredPosition2 = default(Vector2);
			rectTransform2.anchoredPosition = anchoredPosition2;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	private IEnumerator WaitAFrame(Action callback)
	{
		_003CWaitAFrame_003Ed__15 obj = null;
		obj._003C_003E1__state = 0;
		obj.callback = callback;
		return obj;
	}

	private void LoadNextScene()
	{
		//IL_00de: Expected O, but got I4
		Action<string> value = UpdateText;
		Delegate obj = PreloaderEvents.UpdateText;
		Action<string> action = default(Action<string>);
		while (true)
		{
			Delegate obj2 = Delegate.Remove(obj, value);
			Action<string> updateText;
			if ((object)obj2 == null)
			{
				updateText = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag = action == null;
				updateText = action;
				if (flag)
				{
					break;
				}
			}
			bool flag2 = (object)obj == PreloaderEvents.UpdateText;
			Delegate obj3;
			if ((object)obj == PreloaderEvents.UpdateText)
			{
				PreloaderEvents.UpdateText = updateText;
				obj3 = obj;
			}
			else
			{
				obj3 = PreloaderEvents.UpdateText;
			}
			Delegate obj4 = obj;
			if (!flag2)
			{
				obj4 = obj3;
			}
			bool flag3 = (object)obj4 != obj;
			obj = obj4;
			if (!flag3)
			{
				AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu", (LoadSceneParameters)1);
				bool flag4 = asyncOperation.m_Ptr == (IntPtr)0;
				AsyncOperation.set_allowSceneActivation_Injected(asyncOperation.m_Ptr, false);
				_003CWait_003Ed__18 obj5 = null;
				obj5._003C_003E1__state = 0;
				obj5.s = asyncOperation;
				Coroutine coroutine = StartCoroutine(obj5);
				UnityAction<Scene, LoadSceneMode> unityAction = null;
				OnSceneLoaded((Scene)unityAction, LoadSceneMode.Single);
				SceneManager.sceneLoaded += unityAction;
				return;
			}
		}
		throw new InvalidCastException();
	}

	private static void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		UnityAction<Scene, LoadSceneMode> value = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B140");
		SceneManager.sceneLoaded -= value;
		AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync("Preloader");
	}

	private static IEnumerator Wait(AsyncOperation s)
	{
		_003CWait_003Ed__18 obj = null;
		obj._003C_003E1__state = 0;
		obj.s = s;
		return obj;
	}

	public Preloader()
	{
		List<GameObject> sprites = new List<GameObject>();
		_Sprites = sprites;
	}

	private void _003CInitPlatform_003Eb__12_0()
	{
		Action onComplete = LoadNextScene;
		PlatformIntegration.Init(_playerOptions, _achievementManager, onComplete);
	}
}
