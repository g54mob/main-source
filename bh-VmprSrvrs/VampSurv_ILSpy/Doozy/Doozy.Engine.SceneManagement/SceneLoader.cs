using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using Doozy.Engine.Progress;
using Doozy.Engine.Settings;
using Doozy.Engine.Soundy;
using Doozy.Engine.UI.Base;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	private sealed class _003CAsynchronousLoad_003Ed__59(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SceneLoader _003C_003E4__this;

		public string sceneName;

		public LoadSceneMode mode;

		private bool _003CsceneLoadedAndReady_003E5__2;

		private bool _003CactivatingScene_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_007f: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_006b: Expected I4, but got I8
			//IL_0166: Expected O, but got I4
			//IL_0052: Expected I4, but got I8
			//IL_0bc8: Expected O, but got I4
			//IL_0199: Expected O, but got I4
			//IL_01be: Expected O, but got I4
			//IL_0a6b: Expected O, but got F4
			//IL_0a84: Invalid comparison between I4 and F4
			//IL_0323: Expected F4, but got I4
			//IL_0519: Expected O, but got I4
			//IL_044f: Expected O, but got I4
			//IL_07dc: Invalid comparison between I4 and F4
			//IL_0b94: Invalid comparison between F4 and I4
			//IL_0b10: Expected O, but got F4
			//IL_0b35: Expected O, but got I4
			//IL_06c7: Expected O, but got I4
			//IL_06fc: Expected O, but got I4
			//IL_0723: Expected O, but got I4
			//IL_0bf3->IL0bf3: Incompatible stack heights: 1 vs 0
			//IL_0a56->IL09e6: Incompatible stack heights: 1 vs 0
			//IL_07c9->IL0b67: Incompatible stack heights: 1 vs 0
			//IL_0bb3->IL0806: Incompatible stack heights: 1 vs 0
			//IL_0c1d->IL0b67: Incompatible stack heights: 2 vs 0
			//IL_0c22->IL07a1: Incompatible stack heights: 2 vs 1
			SceneLoader sceneLoader = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			object obj2;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					goto IL_0806;
				}
				if ((nint)obj != 1)
				{
					goto IL_09af;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
				_003C_003E4__this.Progress = 0f;
				SceneLoadBehavior loadBehavior = sceneLoader.LoadBehavior;
				UIAction onLoadScene = loadBehavior.OnLoadScene;
				GameObject gameObject = _003C_003E4__this.gameObject;
				if (loadBehavior.OnLoadScene.HasSound)
				{
					SoundyController soundyController = SoundyManager.Play(onLoadScene.SoundData);
				}
				Canvas canvas = loadBehavior.OnLoadScene.GetCanvas(gameObject);
				loadBehavior.OnLoadScene.ExecuteEffect(canvas);
				loadBehavior.OnLoadScene.InvokeAnimatorEvents();
				bool flag2 = onLoadScene.GameEvents == null;
				obj2 = 0;
				if (!flag2)
				{
					List<string> gameEvents = onLoadScene.GameEvents;
					bool flag3 = gameEvents._size <= 0;
					obj2 = 0;
					if (!flag3)
					{
						GameEventMessage.SendEvents(gameEvents, gameObject);
						obj2 = 0;
					}
				}
				if (onLoadScene.Event != null)
				{
					onLoadScene.Event.Invoke();
				}
				if (onLoadScene.Action != null)
				{
					Action<GameObject> action = onLoadScene.Action;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1427 @ rax_v140 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				AsyncOperation currentAsyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);
				_003C_003E4__this.CurrentAsyncOperation = currentAsyncOperation;
				if (sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField == null)
				{
					goto IL_09af;
				}
				object obj3 = sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1050 @ rcx_v120 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1050 @ rcx_v120 (System.Object)+10]");
				AsyncOperation.set_allowSceneActivation_Injected((IntPtr)0, false);
				sceneLoader.m_loadInProgress = true;
				_003CsceneLoadedAndReady_003E5__2 = false;
			}
			if (!sceneLoader.m_loadInProgress)
			{
				goto IL_09af;
			}
			object obj4 = sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v40 (System.Object)+10]");
			bool flag5 = (nint)0 == 0;
			bool num = flag5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v40 (System.Object)+10]");
			object obj5 = AsyncOperation.get_progress_Injected((IntPtr)0);
			float num3 = default(float);
			float num2 = num3 / 0.9f;
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			_003C_003E4__this.Progress = num2;
			float num4;
			if (!sceneLoader.DebugMode)
			{
				DoozySettings instance = DoozySettings.Instance;
				bool flag6 = !instance.DebugSceneLoader;
				num4 = num2;
				if (flag6)
				{
					goto IL_0acc;
				}
			}
			bool flag7 = _003CactivatingScene_003E5__3;
			num4 = num2;
			if (!flag7)
			{
				string[] array = new string[5];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string name = ((UnityEngine.Object)_003C_003E4__this).GetName();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				num4 = sceneLoader.m_progress * 100f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				string text = System.Number.FormatSingle(num4, null, currentInfo);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message = string.Concat(array);
				DDebug.Log(message, _003C_003E4__this);
				obj2 = 0;
			}
			goto IL_0acc;
			IL_0acc:
			string[] array2 = new string[5];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string name2 = ((UnityEngine.Object)_003C_003E4__this).GetName();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			num3 = sceneLoader.m_progress * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
			string text2 = System.Number.FormatSingle(num3, null, currentInfo2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message2 = string.Concat(array2);
			DDebug.Log(message2, _003C_003E4__this);
			bool flag8 = _003CsceneLoadedAndReady_003E5__2;
			object obj6 = 0;
			if (flag8)
			{
				goto IL_07a1;
			}
			object obj7 = sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rcx_v60 (System.Object)+10]");
			bool flag9 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rcx_v60 (System.Object)+10]");
			object obj8 = AsyncOperation.get_progress_Injected((IntPtr)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000182C2E981h\"");
			bool flag10 = num3 != 0.9f;
			obj6 = 0;
			if (!flag10)
			{
				if (!sceneLoader.DebugMode)
				{
					DoozySettings instance2 = DoozySettings.Instance;
					if (!instance2.DebugSceneLoader)
					{
						goto IL_05f5;
					}
				}
				string name3 = ((UnityEngine.Object)_003C_003E4__this).GetName();
				string message3 = "[" + name3 + "] Scene is ready to be activated.";
				DDebug.Log(message3, _003C_003E4__this);
				goto IL_05f5;
			}
			goto IL_0bf8;
			IL_0be5:
			return true;
			IL_09af:
			return false;
			IL_0942:
			bool flag11 = !sceneLoader.SelfDestructAfterSceneLoaded;
			sceneLoader.m_loadInProgress = false;
			if (!flag11)
			{
				IEnumerator enumerator = _003C_003E4__this.SelfDestruct();
				Coroutine coroutine = Coroutiner.Start(enumerator);
			}
			goto IL_0993;
			IL_05f5:
			SceneLoadBehavior loadBehavior2 = sceneLoader.LoadBehavior;
			UIAction onSceneLoaded = loadBehavior2.OnSceneLoaded;
			GameObject gameObject2 = _003C_003E4__this.gameObject;
			if (loadBehavior2.OnSceneLoaded.HasSound)
			{
				SoundyController soundyController2 = SoundyManager.Play(onSceneLoaded.SoundData);
			}
			Canvas canvas2 = loadBehavior2.OnSceneLoaded.GetCanvas(gameObject2);
			loadBehavior2.OnSceneLoaded.ExecuteEffect(canvas2);
			loadBehavior2.OnSceneLoaded.InvokeAnimatorEvents();
			bool flag12 = onSceneLoaded.GameEvents == null;
			obj6 = 0;
			if (!flag12)
			{
				List<string> gameEvents2 = onSceneLoaded.GameEvents;
				bool flag13 = gameEvents2._size <= 0;
				obj6 = 0;
				if (!flag13)
				{
					GameEventMessage.SendEvents(gameEvents2, gameObject2);
					obj6 = 0;
				}
			}
			if (onSceneLoaded.Event != null)
			{
				onSceneLoaded.Event.Invoke();
			}
			if (onSceneLoaded.Action != null)
			{
				Action<GameObject> action2 = onSceneLoaded.Action;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1837 @ rax_v81 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			_003CsceneLoadedAndReady_003E5__2 = true;
			goto IL_0bf8;
			IL_0b67:
			object obj9 = sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v10 (System.Object)+10]");
			bool flag14 = (nint)0 == 0;
			num = flag14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v10 (System.Object)+10]");
			object obj10 = AsyncOperation.get_isDone_Injected((IntPtr)0);
			if (obj10 != null)
			{
				if (!sceneLoader.DebugMode)
				{
					DoozySettings instance3 = DoozySettings.Instance;
					if (!instance3.DebugSceneLoader)
					{
						goto IL_0942;
					}
				}
				string name4 = ((UnityEngine.Object)_003C_003E4__this).GetName();
				string message4 = "[" + name4 + "] Scene has been activated.";
				DDebug.Log(message4, _003C_003E4__this);
				goto IL_0942;
			}
			goto IL_0993;
			IL_0806:
			if (sceneLoader.AllowSceneActivation)
			{
				_003C_003E4__this.ActivateLoadedScene();
				_003CactivatingScene_003E5__3 = true;
			}
			goto IL_0b67;
			IL_0bf8:
			bool flag15 = !_003CsceneLoadedAndReady_003E5__2;
			obj2 = obj6;
			if (!flag15)
			{
				goto IL_07a1;
			}
			goto IL_0b67;
			IL_07a1:
			bool flag16 = _003CactivatingScene_003E5__3;
			obj2 = obj6;
			if (flag16)
			{
				goto IL_0b67;
			}
			if (0f > sceneLoader.SceneActivationDelay)
			{
				sceneLoader.SceneActivationDelay = 0f;
			}
			num3 = sceneLoader.SceneActivationDelay;
			bool flag17 = sceneLoader.SceneActivationDelay > 0f;
			obj2 = obj6;
			if (flag17)
			{
				WaitForSecondsRealtime waitForSecondsRealtime = null;
				waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = sceneLoader.SceneActivationDelay;
				waitForSecondsRealtime.m_WaitUntilTime = -1f;
				_003C_003E2__current = waitForSecondsRealtime;
				_003C_003E1__state = 1;
				goto IL_0be5;
			}
			goto IL_0806;
			IL_0993:
			_003C_003E2__current = null;
			_003C_003E1__state = 2;
			goto IL_0be5;
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

	private sealed class _003CAsynchronousLoad_003Ed__60(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SceneLoader _003C_003E4__this;

		public int sceneBuildIndex;

		public LoadSceneMode mode;

		private bool _003CsceneLoadedAndReady_003E5__2;

		private bool _003CactivatingScene_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_007f: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_006b: Expected I4, but got I8
			//IL_0166: Expected O, but got I4
			//IL_0052: Expected I4, but got I8
			//IL_0bd1: Expected O, but got I4
			//IL_0199: Expected O, but got I4
			//IL_01be: Expected O, but got I4
			//IL_0a75: Expected O, but got F4
			//IL_0a8e: Invalid comparison between I4 and F4
			//IL_0323: Expected F4, but got I4
			//IL_0519: Expected O, but got I4
			//IL_044f: Expected O, but got I4
			//IL_0809: Invalid comparison between I4 and F4
			//IL_0b1a: Expected O, but got F4
			//IL_0b3f: Expected O, but got I4
			//IL_0b9e: Invalid comparison between F4 and I4
			//IL_06c7: Expected O, but got I4
			//IL_06fc: Expected O, but got I4
			//IL_0723: Expected O, but got I4
			//IL_0bfc->IL0bfc: Incompatible stack heights: 1 vs 0
			//IL_0a60->IL09f1: Incompatible stack heights: 1 vs 0
			//IL_07c9->IL0b71: Incompatible stack heights: 1 vs 0
			//IL_07f6->IL0b71: Incompatible stack heights: 1 vs 0
			//IL_0c26->IL0b71: Incompatible stack heights: 2 vs 0
			//IL_0bbc->IL0833: Incompatible stack heights: 1 vs 0
			//IL_0c2b->IL07a1: Incompatible stack heights: 2 vs 1
			SceneLoader sceneLoader = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			object obj2;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					goto IL_0833;
				}
				if ((nint)obj != 1)
				{
					goto IL_09ba;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
				_003C_003E4__this.Progress = 0f;
				SceneLoadBehavior loadBehavior = sceneLoader.LoadBehavior;
				UIAction onLoadScene = loadBehavior.OnLoadScene;
				GameObject gameObject = _003C_003E4__this.gameObject;
				if (loadBehavior.OnLoadScene.HasSound)
				{
					SoundyController soundyController = SoundyManager.Play(onLoadScene.SoundData);
				}
				Canvas canvas = loadBehavior.OnLoadScene.GetCanvas(gameObject);
				loadBehavior.OnLoadScene.ExecuteEffect(canvas);
				loadBehavior.OnLoadScene.InvokeAnimatorEvents();
				bool flag2 = onLoadScene.GameEvents == null;
				obj2 = 0;
				if (!flag2)
				{
					List<string> gameEvents = onLoadScene.GameEvents;
					bool flag3 = gameEvents._size <= 0;
					obj2 = 0;
					if (!flag3)
					{
						GameEventMessage.SendEvents(gameEvents, gameObject);
						obj2 = 0;
					}
				}
				if (onLoadScene.Event != null)
				{
					onLoadScene.Event.Invoke();
				}
				if (onLoadScene.Action != null)
				{
					Action<GameObject> action = onLoadScene.Action;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1424 @ rax_v140 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				AsyncOperation currentAsyncOperation = SceneManager.LoadSceneAsync(sceneBuildIndex, mode);
				_003C_003E4__this.CurrentAsyncOperation = currentAsyncOperation;
				if (sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField == null)
				{
					goto IL_09ba;
				}
				object obj3 = sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ rcx_v120 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ rcx_v120 (System.Object)+10]");
				AsyncOperation.set_allowSceneActivation_Injected((IntPtr)0, false);
				sceneLoader.m_loadInProgress = true;
				_003CsceneLoadedAndReady_003E5__2 = false;
			}
			if (!sceneLoader.m_loadInProgress)
			{
				goto IL_09ba;
			}
			object obj4 = sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v40 (System.Object)+10]");
			bool flag5 = (nint)0 == 0;
			bool num = flag5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v40 (System.Object)+10]");
			object obj5 = AsyncOperation.get_progress_Injected((IntPtr)0);
			float num3 = default(float);
			float num2 = num3 / 0.9f;
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			_003C_003E4__this.Progress = num2;
			float num4;
			if (!sceneLoader.DebugMode)
			{
				DoozySettings instance = DoozySettings.Instance;
				bool flag6 = !instance.DebugSceneLoader;
				num4 = num2;
				if (flag6)
				{
					goto IL_0ad6;
				}
			}
			bool flag7 = _003CactivatingScene_003E5__3;
			num4 = num2;
			if (!flag7)
			{
				string[] array = new string[5];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string name = ((UnityEngine.Object)_003C_003E4__this).GetName();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				num4 = sceneLoader.m_progress * 100f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				string text = System.Number.FormatSingle(num4, null, currentInfo);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message = string.Concat(array);
				DDebug.Log(message, _003C_003E4__this);
				obj2 = 0;
			}
			goto IL_0ad6;
			IL_0ad6:
			string[] array2 = new string[5];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string name2 = ((UnityEngine.Object)_003C_003E4__this).GetName();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			num3 = sceneLoader.m_progress * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
			string text2 = System.Number.FormatSingle(num3, null, currentInfo2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message2 = string.Concat(array2);
			DDebug.Log(message2, _003C_003E4__this);
			bool flag8 = _003CsceneLoadedAndReady_003E5__2;
			object obj6 = 0;
			if (flag8)
			{
				goto IL_07a1;
			}
			object obj7 = sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rcx_v60 (System.Object)+10]");
			bool flag9 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rcx_v60 (System.Object)+10]");
			object obj8 = AsyncOperation.get_progress_Injected((IntPtr)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000182C2F2CFh\"");
			bool flag10 = num3 != 0.9f;
			obj6 = 0;
			if (!flag10)
			{
				if (!sceneLoader.DebugMode)
				{
					DoozySettings instance2 = DoozySettings.Instance;
					if (!instance2.DebugSceneLoader)
					{
						goto IL_05f5;
					}
				}
				string name3 = ((UnityEngine.Object)_003C_003E4__this).GetName();
				string message3 = "[" + name3 + "] Scene is ready to be activated.";
				DDebug.Log(message3, _003C_003E4__this);
				goto IL_05f5;
			}
			goto IL_0c01;
			IL_0833:
			_003C_003E4__this.ActivateLoadedScene();
			_003CactivatingScene_003E5__3 = true;
			goto IL_0b71;
			IL_09ba:
			return false;
			IL_0b71:
			object obj9 = sceneLoader._003CCurrentAsyncOperation_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v10 (System.Object)+10]");
			bool flag11 = (nint)0 == 0;
			num = flag11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v10 (System.Object)+10]");
			object obj10 = AsyncOperation.get_isDone_Injected((IntPtr)0);
			if (obj10 != null)
			{
				if (!sceneLoader.DebugMode)
				{
					DoozySettings instance3 = DoozySettings.Instance;
					if (!instance3.DebugSceneLoader)
					{
						goto IL_094d;
					}
				}
				string name4 = ((UnityEngine.Object)_003C_003E4__this).GetName();
				string message4 = "[" + name4 + "] Scene has been activated.";
				DDebug.Log(message4, _003C_003E4__this);
				goto IL_094d;
			}
			goto IL_099e;
			IL_05f5:
			SceneLoadBehavior loadBehavior2 = sceneLoader.LoadBehavior;
			UIAction onSceneLoaded = loadBehavior2.OnSceneLoaded;
			GameObject gameObject2 = _003C_003E4__this.gameObject;
			if (loadBehavior2.OnSceneLoaded.HasSound)
			{
				SoundyController soundyController2 = SoundyManager.Play(onSceneLoaded.SoundData);
			}
			Canvas canvas2 = loadBehavior2.OnSceneLoaded.GetCanvas(gameObject2);
			loadBehavior2.OnSceneLoaded.ExecuteEffect(canvas2);
			loadBehavior2.OnSceneLoaded.InvokeAnimatorEvents();
			bool flag12 = onSceneLoaded.GameEvents == null;
			obj6 = 0;
			if (!flag12)
			{
				List<string> gameEvents2 = onSceneLoaded.GameEvents;
				bool flag13 = gameEvents2._size <= 0;
				obj6 = 0;
				if (!flag13)
				{
					GameEventMessage.SendEvents(gameEvents2, gameObject2);
					obj6 = 0;
				}
			}
			if (onSceneLoaded.Event != null)
			{
				onSceneLoaded.Event.Invoke();
			}
			if (onSceneLoaded.Action != null)
			{
				Action<GameObject> action2 = onSceneLoaded.Action;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1837 @ rax_v81 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			_003CsceneLoadedAndReady_003E5__2 = true;
			goto IL_0c01;
			IL_099e:
			_003C_003E2__current = null;
			_003C_003E1__state = 2;
			goto IL_0bee;
			IL_0bee:
			return true;
			IL_0c01:
			bool flag14 = !_003CsceneLoadedAndReady_003E5__2;
			obj2 = obj6;
			if (!flag14)
			{
				goto IL_07a1;
			}
			goto IL_0b71;
			IL_07a1:
			bool flag15 = _003CactivatingScene_003E5__3;
			obj2 = obj6;
			if (!flag15)
			{
				bool flag16 = !sceneLoader.AllowSceneActivation;
				obj2 = obj6;
				if (!flag16)
				{
					if (0f > sceneLoader.SceneActivationDelay)
					{
						sceneLoader.SceneActivationDelay = 0f;
					}
					num3 = sceneLoader.SceneActivationDelay;
					bool flag17 = sceneLoader.SceneActivationDelay > 0f;
					obj2 = obj6;
					if (flag17)
					{
						WaitForSecondsRealtime waitForSecondsRealtime = null;
						waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = sceneLoader.SceneActivationDelay;
						waitForSecondsRealtime.m_WaitUntilTime = -1f;
						_003C_003E2__current = waitForSecondsRealtime;
						_003C_003E1__state = 1;
						goto IL_0bee;
					}
					goto IL_0833;
				}
			}
			goto IL_0b71;
			IL_094d:
			bool flag18 = !sceneLoader.SelfDestructAfterSceneLoaded;
			sceneLoader.m_loadInProgress = false;
			if (!flag18)
			{
				IEnumerator enumerator = _003C_003E4__this.SelfDestruct();
				Coroutine coroutine = Coroutiner.Start(enumerator);
			}
			goto IL_099e;
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

	private sealed class _003CSelfDestruct_003Ed__61(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SceneLoader _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00c1: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				GameObject gameObject = _003C_003E4__this.gameObject;
				UnityEngine.Object.Destroy(gameObject, 0f);
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

	public const GetSceneBy DEFAULT_GET_SCENE_BY = GetSceneBy.Name;

	public const LoadSceneMode DEFAULT_LOAD_SCENE_MODE = LoadSceneMode.Single;

	public const bool DEFAULT_AUTO_SCENE_ACTIVATION = true;

	public const bool DEFAULT_SELF_DESTRUCT_AFTER_SCENE_LOADED = false;

	public const float DEFAULT_SCENE_ACTIVATION_DELAY = 0.2f;

	public const int DEFAULT_BUILD_INDEX = 0;

	public const string DEFAULT_SCENE_NAME = "";

	public static readonly List<SceneLoader> Database;

	private AsyncOperation _003CCurrentAsyncOperation_003Ek__BackingField;

	public bool AllowSceneActivation = true;

	public bool DebugMode;

	public SceneLoadBehavior LoadBehavior;

	public GetSceneBy GetSceneBy;

	public LoadSceneMode LoadSceneMode;

	public ProgressEvent OnProgressChanged;

	public ProgressEvent OnInverseProgressChanged;

	public Progressor Progressor;

	public float SceneActivationDelay;

	public int SceneBuildIndex;

	public string SceneName;

	public bool SelfDestructAfterSceneLoaded;

	private bool m_loadInProgress;

	private bool m_sceneLoadedAndReady;

	private bool m_activatingScene;

	private float m_sceneLoadedAndReadyTime;

	private float m_progress;

	public AsyncOperation CurrentAsyncOperation
	{
		get
		{
			return _003CCurrentAsyncOperation_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentAsyncOperation_003Ek__BackingField = value;
		}
	}

	public float InverseProgress => 1f - m_progress;

	public float Progress
	{
		get
		{
			return m_progress;
		}
		private set
		{
			//IL_004e: Invalid comparison between I4 and F4
			//IL_005d: Expected F4, but got I4
			Progressor progressor = Progressor;
			m_progress = value;
			if ((object)Progressor != null && ((UnityEngine.Object)progressor).m_CachedPtr != (IntPtr)0)
			{
				Progressor progressor2 = Progressor;
				bool flag = 0f > value;
				float num = 0f;
				if (!flag)
				{
					num = ((value > 1f) ? 1f : value);
				}
				float num2 = progressor2.m_maxValue - progressor2.m_minValue;
				float num3 = num2 * num;
				float value2 = num3 + progressor2.m_minValue;
				progressor2.SetValue(value2, instantUpdate: false);
			}
			OnProgressChanged.Invoke(value);
			float arg = 1f - value;
			OnInverseProgressChanged.Invoke(arg);
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0063: Expected I4, but got O
			if (DebugMode)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugSceneLoader;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private void Reset()
	{
		SceneName = "";
		SceneActivationDelay = 0.2f;
		GetSceneBy = GetSceneBy.Name;
		SceneLoadBehavior loadBehavior = new SceneLoadBehavior();
		LoadBehavior = loadBehavior;
		ProgressEvent onProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnProgressChanged = onProgressChanged;
		ProgressEvent onInverseProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnInverseProgressChanged = onInverseProgressChanged;
		Progress = 0f;
	}

	private void Awake()
	{
		List<object> database = (List<object>)(object)Database;
		int version = database._version + 1;
		database._version = version;
		object[] items = database._items;
		if (database._size >= items.Length)
		{
			database.AddWithResize((object)this);
			return;
		}
		int size = database._size + 1;
		database._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	private void OnEnable()
	{
		Progress = 0f;
	}

	private void OnDestroy()
	{
		bool flag = ((List<object>)(object)Database).Remove((object)this);
	}

	private void Update()
	{
		//IL_0611: Expected O, but got F4
		//IL_062a: Invalid comparison between I4 and F4
		//IL_0070: Expected F4, but got I4
		//IL_075e: Expected O, but got I4
		//IL_045a: Invalid comparison between I4 and F4
		//IL_06af: Expected O, but got F4
		//IL_0732: Invalid comparison between F4 and I4
		//IL_0191: Expected O, but got I4
		//IL_031e: Expected O, but got I4
		//IL_0353: Expected O, but got I4
		//IL_037a: Expected O, but got I4
		//IL_0776->IL077b: Incompatible stack heights: 1 vs 0
		//IL_07a1->IL070e: Incompatible stack heights: 1 vs 0
		//IL_07a6->IL03f8: Incompatible stack heights: 1 vs 0
		//IL_05b2->IL077b: Incompatible stack heights: 1 vs 0
		//IL_05d3->IL077b: Incompatible stack heights: 1 vs 0
		object obj3 = default(object);
		while (_003CCurrentAsyncOperation_003Ek__BackingField != null)
		{
			object obj = _003CCurrentAsyncOperation_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3 (System.Object)+10]");
			if ((nint)0 == 0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(obj);
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3 (System.Object)+10]");
			object obj2 = AsyncOperation.get_progress_Injected((IntPtr)0);
			float num = (float)obj3 / 0.9f;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			Progress = num;
			float num2;
			if (!DebugMode)
			{
				DoozySettings instance = DoozySettings.Instance;
				bool flag = !instance.DebugSceneLoader;
				num2 = num;
				if (flag)
				{
					goto IL_066a;
				}
			}
			bool flag2 = m_activatingScene;
			num2 = num;
			object obj4;
			if (!flag2)
			{
				string[] array = new string[5];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string text = GetName();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				num2 = m_progress * 100f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				string text2 = System.Number.FormatSingle(num2, null, currentInfo);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message = string.Concat(array);
				DDebug.Log(message, this);
				obj4 = 0;
			}
			goto IL_066a;
			IL_0254:
			SceneLoadBehavior loadBehavior = LoadBehavior;
			UIAction onSceneLoaded = loadBehavior.OnSceneLoaded;
			GameObject source = base.gameObject;
			if (loadBehavior.OnSceneLoaded.HasSound)
			{
				SoundyController soundyController = SoundyManager.Play(onSceneLoaded.SoundData);
			}
			Canvas canvas = loadBehavior.OnSceneLoaded.GetCanvas(source);
			loadBehavior.OnSceneLoaded.ExecuteEffect(canvas);
			loadBehavior.OnSceneLoaded.InvokeAnimatorEvents();
			bool flag3 = onSceneLoaded.GameEvents == null;
			obj4 = 0;
			if (!flag3)
			{
				List<string> gameEvents = onSceneLoaded.GameEvents;
				bool flag4 = gameEvents._size <= 0;
				obj4 = 0;
				if (!flag4)
				{
					GameEventMessage.SendEvents(gameEvents, source);
					obj4 = 0;
				}
			}
			if (onSceneLoaded.Event != null)
			{
				onSceneLoaded.Event.Invoke();
			}
			if (onSceneLoaded.Action != null)
			{
				Action<GameObject> action = onSceneLoaded.Action;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1193 @ rax_v55 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			m_sceneLoadedAndReady = true;
			num2 = (m_sceneLoadedAndReadyTime = Time.realtimeSinceStartup);
			goto IL_077c;
			IL_077c:
			bool flag5 = !m_sceneLoadedAndReady;
			float num3 = num2;
			if (!flag5)
			{
				goto IL_03f8;
			}
			goto IL_070e;
			IL_03f8:
			bool flag6 = m_activatingScene;
			num3 = num2;
			if (!flag6)
			{
				bool flag7 = !AllowSceneActivation;
				num3 = num2;
				if (!flag7)
				{
					if (0f > SceneActivationDelay)
					{
						SceneActivationDelay = 0f;
					}
					num3 = SceneActivationDelay;
					if (!(SceneActivationDelay < 0f))
					{
						float realtimeSinceStartup = Time.realtimeSinceStartup;
						num3 = realtimeSinceStartup - m_sceneLoadedAndReadyTime;
						if (num3 > SceneActivationDelay)
						{
							ActivateLoadedScene();
							m_activatingScene = true;
						}
					}
				}
			}
			goto IL_070e;
			IL_070e:
			object obj5 = _003CCurrentAsyncOperation_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rcx_v21 (System.Object)+10]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rcx_v21 (System.Object)+10]");
			object obj6 = AsyncOperation.get_isDone_Injected((IntPtr)0);
			if (obj6 == null)
			{
				break;
			}
			if (!DebugMode)
			{
				DoozySettings instance2 = DoozySettings.Instance;
				if (!instance2.DebugSceneLoader)
				{
					goto IL_0586;
				}
			}
			string text3 = GetName();
			string message2 = "[" + text3 + "] Scene has been activated.";
			DDebug.Log(message2, this);
			goto IL_0586;
			IL_0586:
			m_loadInProgress = false;
			CurrentAsyncOperation = null;
			if (SelfDestructAfterSceneLoaded)
			{
				IEnumerator enumerator = SelfDestruct();
				Coroutine coroutine = Coroutiner.Start(enumerator);
			}
			break;
			IL_066a:
			if (m_sceneLoadedAndReady)
			{
				goto IL_03f8;
			}
			object obj7 = _003CCurrentAsyncOperation_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rcx_v38 (System.Object)+10]");
			bool flag9 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rcx_v38 (System.Object)+10]");
			object obj8 = AsyncOperation.get_progress_Injected((IntPtr)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000182C2CE79h\"");
			if (num2 == 0.9f)
			{
				if (!DebugMode)
				{
					DoozySettings instance3 = DoozySettings.Instance;
					if (!instance3.DebugSceneLoader)
					{
						goto IL_0254;
					}
				}
				string text4 = GetName();
				string message3 = "[" + text4 + "] Scene is ready to be activated.";
				DDebug.Log(message3, this);
				goto IL_0254;
			}
			goto IL_077c;
		}
	}

	public void ActivateLoadedScene()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980ACC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_003CCurrentAsyncOperation_003Ek__BackingField == null)
		{
			return;
		}
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugSceneLoader)
			{
				goto IL_00ba;
			}
		}
		string text = GetName();
		string message = "[" + text + "] Activating Scene...";
		DDebug.Log(message, this);
		goto IL_00ba;
		IL_00ba:
		object obj = _003CCurrentAsyncOperation_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v8 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 105 ConditionalJump @-1, v200 @ ZF_v9 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	public void LoadSceneAsync()
	{
		if (GetSceneBy == GetSceneBy.Name)
		{
			Progressor progressor = LoadSceneAsync(SceneName, LoadSceneMode);
		}
		else if (GetSceneBy == GetSceneBy.BuildIndex)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 33 Invalid \"Jump target not found in method: 0x182C2D140\"");
		}
	}

	public Progressor LoadSceneAsync(int sceneBuildIndex, LoadSceneMode mode)
	{
		//IL_00dd: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		Progress = 0f;
		SceneLoadBehavior loadBehavior = LoadBehavior;
		if (LoadBehavior != null)
		{
			UIAction onLoadScene = loadBehavior.OnLoadScene;
			GameObject gameObject = base.gameObject;
			if (loadBehavior.OnLoadScene != null)
			{
				if (loadBehavior.OnLoadScene.HasSound)
				{
					SoundyController soundyController = SoundyManager.Play(onLoadScene.SoundData);
				}
				Canvas canvas = loadBehavior.OnLoadScene.GetCanvas(gameObject);
				loadBehavior.OnLoadScene.ExecuteEffect(canvas);
				loadBehavior.OnLoadScene.InvokeAnimatorEvents();
				bool flag = onLoadScene.GameEvents == null;
				object obj = 0;
				if (!flag)
				{
					List<string> gameEvents = onLoadScene.GameEvents;
					if (onLoadScene.GameEvents == null)
					{
						goto IL_01fc;
					}
					bool flag2 = gameEvents._size <= 0;
					obj = 0;
					if (!flag2)
					{
						if ((object)gameObject == null)
						{
							goto IL_01fc;
						}
						GameEventMessage.SendEvents(onLoadScene.GameEvents, gameObject);
						obj = 0;
					}
				}
				if (onLoadScene.Event != null)
				{
					onLoadScene.Event.Invoke();
				}
				if (onLoadScene.Action != null)
				{
					Action<GameObject> action = onLoadScene.Action;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v272 @ rax_v24 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneBuildIndex, mode);
				_003CCurrentAsyncOperation_003Ek__BackingField = asyncOperation;
				StartSceneLoad();
				return Progressor;
			}
		}
		goto IL_01fc;
		IL_01fc:
		return (Progressor)(object)new NullReferenceException();
	}

	public Progressor LoadSceneAsync(string sceneName, LoadSceneMode mode)
	{
		//IL_00dd: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		Progress = 0f;
		SceneLoadBehavior loadBehavior = LoadBehavior;
		if (LoadBehavior != null)
		{
			UIAction onLoadScene = loadBehavior.OnLoadScene;
			GameObject gameObject = base.gameObject;
			if (loadBehavior.OnLoadScene != null)
			{
				if (loadBehavior.OnLoadScene.HasSound)
				{
					SoundyController soundyController = SoundyManager.Play(onLoadScene.SoundData);
				}
				Canvas canvas = loadBehavior.OnLoadScene.GetCanvas(gameObject);
				loadBehavior.OnLoadScene.ExecuteEffect(canvas);
				loadBehavior.OnLoadScene.InvokeAnimatorEvents();
				bool flag = onLoadScene.GameEvents == null;
				object obj = 0;
				if (!flag)
				{
					List<string> gameEvents = onLoadScene.GameEvents;
					if (onLoadScene.GameEvents == null)
					{
						goto IL_01fc;
					}
					bool flag2 = gameEvents._size <= 0;
					obj = 0;
					if (!flag2)
					{
						if ((object)gameObject == null)
						{
							goto IL_01fc;
						}
						GameEventMessage.SendEvents(onLoadScene.GameEvents, gameObject);
						obj = 0;
					}
				}
				if (onLoadScene.Event != null)
				{
					onLoadScene.Event.Invoke();
				}
				if (onLoadScene.Action != null)
				{
					Action<GameObject> action = onLoadScene.Action;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v272 @ rax_v24 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);
				_003CCurrentAsyncOperation_003Ek__BackingField = asyncOperation;
				StartSceneLoad();
				return Progressor;
			}
		}
		goto IL_01fc;
		IL_01fc:
		return (Progressor)(object)new NullReferenceException();
	}

	public void LoadSceneAsyncAdditive(int sceneBuildIndex)
	{
		Progressor progressor = LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Additive);
	}

	public void LoadSceneAsyncAdditive(string sceneName)
	{
		Progressor progressor = LoadSceneAsync(sceneName, LoadSceneMode.Additive);
	}

	public void LoadSceneAsyncSingle(int sceneBuildIndex)
	{
		Progressor progressor = LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single);
	}

	public void LoadSceneAsyncSingle(string sceneName)
	{
		Progressor progressor = LoadSceneAsync(sceneName, LoadSceneMode.Single);
	}

	public SceneLoader SetAllowSceneActivation(bool allowSceneActivation)
	{
		AllowSceneActivation = allowSceneActivation;
		return this;
	}

	public SceneLoader SetLoadSceneBy(GetSceneBy getSceneBy)
	{
		GetSceneBy = getSceneBy;
		return this;
	}

	public SceneLoader SetLoadSceneMode(LoadSceneMode loadSceneMode)
	{
		LoadSceneMode = loadSceneMode;
		return this;
	}

	public SceneLoader SetProgressor(Progressor progressor)
	{
		Progressor = progressor;
		return this;
	}

	public SceneLoader SetSceneActivationDelay(float sceneActivationDelay)
	{
		SceneActivationDelay = sceneActivationDelay;
		return this;
	}

	public SceneLoader SetSceneBuildIndex(int sceneBuildIndex)
	{
		SceneBuildIndex = sceneBuildIndex;
		return this;
	}

	public SceneLoader SetSceneName(string sceneName)
	{
		SceneName = sceneName;
		return this;
	}

	public SceneLoader SetSelfDestructAfterSceneLoaded(bool selfDestruct)
	{
		SelfDestructAfterSceneLoaded = selfDestruct;
		return this;
	}

	private void ResetProgress()
	{
		Progress = 0f;
	}

	private void StartSceneLoad()
	{
		AsyncOperation asyncOperation = _003CCurrentAsyncOperation_003Ek__BackingField;
		bool flag = asyncOperation.m_Ptr == (IntPtr)0;
		AsyncOperation.set_allowSceneActivation_Injected(asyncOperation.m_Ptr, false);
		m_loadInProgress = true;
		m_activatingScene = false;
	}

	private IEnumerator AsynchronousLoad(string sceneName, LoadSceneMode mode)
	{
		_003CAsynchronousLoad_003Ed__59 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.sceneName = sceneName;
		obj.mode = mode;
		return obj;
	}

	private IEnumerator AsynchronousLoad(int sceneBuildIndex, LoadSceneMode mode)
	{
		_003CAsynchronousLoad_003Ed__60 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.sceneBuildIndex = sceneBuildIndex;
		obj.mode = mode;
		return obj;
	}

	private IEnumerator SelfDestruct()
	{
		_003CSelfDestruct_003Ed__61 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public static void ActivateLoadedScenes()
	{
		RemoveNullReferencesFromDatabase();
		if (Database != null)
		{
			List<SceneLoader>.Enumerator enumerator = default(List<SceneLoader>.Enumerator);
			if (enumerator.MoveNext())
			{
				SceneLoader sceneLoader = null;
				throw new NullReferenceException();
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				if (instance.DebugSceneLoader)
				{
					DDebug.Log("Activate Loaded Scenes");
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public static SceneLoader GetLoader(Transform parent = null)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		SceneLoader sceneLoader;
		if (obj3 != null)
		{
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v205 @ rdx_v3+1B8] (should have been resolved before IL gen)");
			GameObject gameObject = new GameObject();
			string text = default(string);
			GameObject.Internal_CreateGameObject(gameObject, text);
			if ((object)gameObject != null)
			{
				sceneLoader = gameObject.AddComponent<SceneLoader>();
				if ((object)parent == null || ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0139;
				}
				if ((object)sceneLoader != null)
				{
					Transform transform = sceneLoader.transform;
					if ((object)transform != null)
					{
						transform.SetParent(parent, worldPositionStays: true);
						goto IL_0139;
					}
				}
			}
		}
		return (SceneLoader)(object)new NullReferenceException();
		IL_0139:
		return sceneLoader;
	}

	private static SceneLoader AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<SceneLoader>("Scene Loader", isSingleton: false, selectGameObjectAfterCreation);
	}

	private static void RemoveNullReferencesFromDatabase()
	{
		//IL_012d: Expected O, but got I4
		List<SceneLoader> database = Database;
		bool flag = (nint)Database < 0;
		int num = database._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<SceneLoader> database2 = Database;
			if (num >= database2._size)
			{
				break;
			}
			SceneLoader[] items = database2._items;
			SceneLoader sceneLoader = items[num];
			bool flag2;
			if ((object)items[num] != null)
			{
				flag2 = (nint)((UnityEngine.Object)sceneLoader).m_CachedPtr < 0;
				if (((UnityEngine.Object)sceneLoader).m_CachedPtr != (IntPtr)0)
				{
					goto IL_0114;
				}
			}
			flag2 = (nint)Database < 0;
			Database.RemoveAt(num);
			goto IL_0114;
			IL_0114:
			num--;
			object obj = !flag2;
			if (obj == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public SceneLoader()
	{
		SceneLoadBehavior loadBehavior = new SceneLoadBehavior();
		LoadBehavior = loadBehavior;
		ProgressEvent onProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnProgressChanged = onProgressChanged;
		ProgressEvent onInverseProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnInverseProgressChanged = onInverseProgressChanged;
		SceneActivationDelay = 0.2f;
		SceneName = "";
	}

	static SceneLoader()
	{
		List<SceneLoader> database = new List<SceneLoader>();
		Database = database;
	}
}
