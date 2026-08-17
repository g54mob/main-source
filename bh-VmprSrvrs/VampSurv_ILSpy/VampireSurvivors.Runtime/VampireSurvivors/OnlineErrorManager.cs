using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Cloud;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class OnlineErrorManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CShowError_003Eb__9_0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_0010: Expected O, but got I4
				//IL_001f: Expected I4, but got I8
				//IL_0390: Expected I4, but got I8
				//IL_039b: Expected O, but got Ref
				//IL_0171: Expected O, but got I4
				//IL_0179: Unknown result type (might be due to invalid IL or missing references)
				//IL_017e: Expected O, but got Unknown
				//IL_0299: Expected O, but got Ref
				Task task;
				if (_003C_003E1__state == 0)
				{
					_003C_003Eu__1 = (TaskAwaiter<bool>)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
					goto IL_0194;
				}
				GameManager core = GM.Core;
				if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
				{
					Debug.Log("<color=yellow>[OnlineErrorManager] - CreateOnlineErrorPopup game is running </color>");
					OnlineErrorManager instance = Instance;
					if ((object)Instance != null)
					{
						LobbiesManager lobbiesManager = instance._lobbiesManager;
						if (lobbiesManager._activeLobby != null)
						{
							LobbySession activeLobby = lobbiesManager._activeLobby;
							if (!activeLobby._003CIsDisposed_003Ek__BackingField)
							{
								Debug.Log("<color=yellow>[OnlineErrorManager] - CreateOnlineErrorPopup leaving lobby </color>");
								OnlineErrorManager instance2 = Instance;
								Task<bool> task2 = instance2._lobbiesManager.LeaveLobby();
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
								TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
								int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
								bool flag = num == 0;
								bool flag2 = num < 0;
								bool flag3 = !flag2;
								object obj = !flag3;
								object obj2 = obj | flag;
								task = (Task)taskAwaiter;
								if (obj2 == null)
								{
									goto IL_0194;
								}
								_003C_003E1__state = 0;
								_003C_003Eu__1 = taskAwaiter;
								AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
								TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
								((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
						}
						goto IL_01eb;
					}
					throw new NullReferenceException();
				}
				BackButtonController.FireBack();
				goto IL_0381;
				IL_0381:
				_003C_003E1__state = -2;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
				{
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
				}
				return;
				IL_0194:
				int num2 = task.m_stateFlags & 0x11000000;
				if (num2 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				Debug.Log("<color=yellow>[OnlineErrorManager] - CreateOnlineErrorPopup left lobby </color>");
				goto IL_01eb;
				IL_01eb:
				GameManager core2 = GM.Core;
				if (core2._isGameRunning)
				{
					core2.ResumeGame();
					Debug.Log("<color=yellow>[OnlineErrorManager] - CreateOnlineErrorPopup Resumed Game </color>");
					Debug.Log("<color=yellow>[OnlineErrorManager] - CreateOnlineErrorPopup Fire GamePaused Signal </color>");
					OnlineErrorManager instance3 = Instance;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99300");
				}
				Debug.Log("<color=yellow>[OnlineErrorManager] - CreateOnlineErrorPopup Fire QuitGame Signal </color>");
				OnlineErrorManager instance4 = Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACA80");
				goto IL_0381;
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//IL_000b: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__9_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CShowError_003Eb__9_0()
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CShowError_003Eb__9_0_003Ed stateMachine = default(_003C_003CShowError_003Eb__9_0_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}
	}

	private static OnlineErrorManager Instance;

	private SignalBus _signalBus;

	private LobbiesManager _lobbiesManager;

	public static string OnlineErrorPopupID = "onlineError";

	private void Construct(LobbiesManager lobbiesManager)
	{
		_lobbiesManager = lobbiesManager;
	}

	private void Awake()
	{
		Instance = this;
	}

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}

	public static void CloseErrorPopupIfExists()
	{
		PopupManager instance = PopupManager.Instance;
		int num = instance._popups.FindEntry(OnlineErrorPopupID);
		if (num >= 0)
		{
			PopupManager.ClosePopup(OnlineErrorPopupID);
		}
	}

	public unsafe static void ShowError(OnlineErrorType type, string msg)
	{
		//IL_00bc: Expected I, but got O
		//IL_00c4: Expected I, but got O
		//IL_00d4: Expected O, but got I
		//IL_0154: Expected O, but got I4
		//IL_0110: Expected O, but got I
		//IL_0146: Expected O, but got I4
		//IL_0223: Expected I4, but got O
		//IL_024c: Expected O, but got Ref
		//IL_02b7: Expected I4, but got O
		PopupManager.ClosePopup("HostStartingGame");
		OnlineErrorManager instance = Instance;
		LobbiesManager lobbiesManager = instance._lobbiesManager;
		if (lobbiesManager._activeLobby != null)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			if (!activeLobby._003CIsDisposed_003Ek__BackingField)
			{
				goto IL_019c;
			}
		}
		AppStateMachine appStateMachine = AppStateMachine._003CInstance_003Ek__BackingField;
		StateMachineState currentState = ((StateMachine)appStateMachine).currentState;
		StateMachineState stateMachineState;
		if ((object)((StateMachine)appStateMachine).currentState == null)
		{
			stateMachineState = null;
			goto IL_030e;
		}
		nint num = (nint)typeof(AppOnlineState);
		nint num2 = (nint)currentState;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rdx_v22 (Il2CppClass<VampireSurvivors.AppOnlineState>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ r8_v16 (Il2CppMethodInfo)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rdx_v22 (Il2CppClass<VampireSurvivors.AppOnlineState>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ r8_v16 (Il2CppMethodInfo)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rax_v86+FFFFFFF8+v395 @ rax_v82*8]");
			if (0 == (nint)typeof(AppOnlineState))
			{
				obj3 = 1;
				goto IL_02ec;
			}
		}
		obj3 = 0;
		goto IL_02ec;
		IL_019c:
		Debug.Log(GM.Core);
		Debug.Log(Instance);
		GameManager core = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			if (core2._isGameRunning)
			{
				core2.PauseGame();
			}
		}
		object obj4 = default(object);
		object arg = (OnlineErrorType)obj4;
		System.ParamsArray paramsArray = new System.ParamsArray(arg, msg);
		object obj5 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Creating Online Error Popup of type {0} with message {1}", (System.ParamsArray)(&obj5));
		Debug.LogWarning(message);
		string text = TypeToString(type);
		string term = "onlineLang/" + text;
		bool flag = default(bool);
		GameObject gameObject = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, flag, gameObject, overrideLanguage, allowLocalizedParameters);
		Action callback = _003C_003Ec._003C_003E9__9_0;
		if (_003C_003Ec._003C_003E9__9_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__9_0 = delegate
			{
				SynchronizationContext.CurrentNoFlow?.OperationStarted();
				AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
				_003C_003Ec._003C_003CShowError_003Eb__9_0_003Ed stateMachine = default(_003C_003Ec._003C_003CShowError_003Eb__9_0_003Ed);
				asyncVoidMethodBuilder.Start(ref stateMachine);
			});
		}
		PopupManager.CreateOnlineErrorPopup(OnlineErrorPopupID, translation, msg, callback, flag, (byte)(int)gameObject != 0);
		return;
		IL_030e:
		if ((object)stateMachineState != null && ((UnityEngine.Object)stateMachineState).m_CachedPtr != (IntPtr)0)
		{
			goto IL_019c;
		}
		return;
		IL_02ec:
		bool flag2 = obj3 == null;
		stateMachineState = null;
		if (!flag2)
		{
			stateMachineState = ((StateMachine)appStateMachine).currentState;
		}
		goto IL_030e;
	}

	public unsafe static string TypeToString(OnlineErrorType type)
	{
		//IL_0013: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_007f: Expected O, but got Ref
		bool flag = type == OnlineErrorType.StartGame;
		if (!flag)
		{
			object obj = type - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 != 1)
						{
							object obj4 = default(object);
							string text = ((Enum)(&obj4)).ToString();
							return "Unknown type" + text;
						}
						return "ErrorInGameTitle";
					}
					return "ErrorLoginTitle";
				}
				return "ErrorCreateGameTitle";
			}
			return "ErrorJoinGameTitle";
		}
		return "ErrorStartGameTitle";
	}

	public OnlineErrorManager()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
