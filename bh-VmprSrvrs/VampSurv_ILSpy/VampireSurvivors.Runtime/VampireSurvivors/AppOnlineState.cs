using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class AppOnlineState : AppStateMachineState
{
	[StructLayout((LayoutKind)3)]
	private struct _003COnBack_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AppOnlineState _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0091: Expected O, but got Ref
			//IL_0096: Expected O, but got Ref
			//IL_0057: Expected O, but got I4
			//IL_0066: Expected I4, but got I8
			//IL_00b4: Expected O, but got I
			//IL_00d3: Expected O, but got Ref
			//IL_00d8: Expected O, but got Ref
			//IL_02dd: Expected O, but got Ref
			//IL_046d: Expected I4, but got I8
			//IL_0478: Expected O, but got Ref
			//IL_0520: Expected O, but got Ref
			//IL_0529: Expected O, but got I4
			//IL_0123: Expected O, but got I
			//IL_0329: Expected I, but got O
			//IL_0170: Expected O, but got Ref
			//IL_019d: Expected O, but got Ref
			//IL_01ad: Expected O, but got I
			//IL_01cc: Expected O, but got I
			//IL_01e7: Expected O, but got Ref
			//IL_03a7: Expected O, but got I
			//IL_022a: Expected O, but got Ref
			//IL_0232: Expected I, but got O
			//IL_0290: Expected O, but got I4
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Expected O, but got Unknown
			//IL_02a2: Expected I, but got O
			//IL_02b8: Expected I, but got O
			//IL_0353: Expected O, but got Ref
			//IL_037c: Expected O, but got Ref
			//IL_0381: Expected I, but got O
			AppOnlineState appOnlineState = _003C_003E4__this;
			if (_003C_003E1__state != 0 && appOnlineState._isLeavingLobby)
			{
				goto IL_045e;
			}
			object obj = default(object);
			Task task;
			if (obj == null)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
				nint num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				goto IL_02c6;
			}
			IntPtr intPtr = default(IntPtr);
			bool flag = intPtr == (IntPtr)0;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
			_003COnBack_003Ed__4 obj2 = (_003COnBack_003Ed__4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			nint num2 = default(nint);
			ref _003COnBack_003Ed__4 stateMachine = default(ref _003COnBack_003Ed__4);
			AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = default(AsyncVoidMethodBuilder);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_20_v13 (Il2CppMethodInfo)+38]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_20_v13 (Il2CppMethodInfo)+38]");
				bool flag2 = (nint)0 == 0;
				asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
				obj2 = (_003COnBack_003Ed__4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v43+10]");
					bool flag3 = (nint)0 == 0;
					num2 = intPtr;
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v43+10]");
						obj2 = (_003COnBack_003Ed__4)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rcx_v2 (VampireSurvivors.AppOnlineState+<OnBack>d__4)+178]");
						bool flag4 = (nint)0 != 0;
						num2 = intPtr;
						if (!flag4)
						{
							_ = 1;
							bool flag5 = intPtr == (IntPtr)0;
							asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_20_v13 (Il2CppMethodInfo)+38]");
								bool flag6 = (nint)0 == 0;
								asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_20_v13 (Il2CppMethodInfo)+38]");
								obj2 = (_003COnBack_003Ed__4)0;
								if (!flag6)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_20_v13 (Il2CppMethodInfo)+38]");
									Task<bool> task2 = ((LobbiesManager)0).LeaveLobby();
									bool flag7 = task2 == null;
									asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_20_v13 (Il2CppMethodInfo)+38]");
									nint num = 0;
									if (!flag7)
									{
										((AsyncVoidMethodBuilder*)task2)->AwaitUnsafeOnCompleted(ref *(TaskAwaiter<bool>*)null, ref stateMachine);
										TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
										bool flag8 = (object)taskAwaiter == null;
										asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
										num = (nint)task2;
										if (!flag8)
										{
											int num3 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
											bool flag9 = num3 == 0;
											bool flag10 = num3 < 0;
											bool flag11 = !flag10;
											object obj4 = !flag11;
											object obj5 = obj4 | flag9;
											num2 = unchecked((nint)null);
											task = (Task)taskAwaiter;
											num = (nint)typeof(Task);
											if (obj5 == null)
											{
												goto IL_02c6;
											}
											_003C_003E1__state = 0;
											_003C_003Eu__1 = taskAwaiter;
											AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
											TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
											((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
											asyncVoidMethodBuilder3.AwaitUnsafeOnCompleted(ref awaiter, ref this);
											asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
											num = unchecked((nint)null);
											return;
										}
										throw new NullReferenceException();
									}
									obj2 = (_003COnBack_003Ed__4)num;
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
					}
					goto IL_0507;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_02c6:
			bool flag12 = task == null;
			asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
			if (!flag12)
			{
				int num4 = task.m_stateFlags & 0x11000000;
				if (num4 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					num2 = unchecked((nint)null);
				}
				goto IL_0507;
			}
			throw new NullReferenceException();
			IL_0507:
			asyncVoidMethodBuilder3.AwaitUnsafeOnCompleted(ref *(TaskAwaiter<bool>*)num2, ref stateMachine);
			asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
			obj2 = (_003COnBack_003Ed__4)0;
			goto IL_045e;
			IL_045e:
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder4.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder4)->NotifySynchronizationContextOfCompletion();
			}
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

	private bool _isLeavingLobby;

	public override void Init(StateMachine stateMachine)
	{
		//IL_003e: Expected I, but got O
		base.Init(stateMachine);
		UsesBackButton = true;
		nint num = (nint)typeof(BackButtonController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v3 (Il2CppClass<VampireSurvivors.UI.BackButtonController>)+E4]");
		if ((nint)0 == 0)
		{
			BackButtonController.BackButtonClosesPage = true;
		}
		else
		{
			BackButtonController.BackButtonClosesPage = true;
		}
	}

	public override void OnEnter()
	{
		base.OnEnter();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = OnShowLobbyScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6ED0");
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action2 = OnShowErrorScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA84B0");
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action3 = ShowAchievements;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7410");
		AppStateMachine appStateMachine4 = base.appStateMachine;
		Action action4 = ShowCollections;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7590");
		AppStateMachine appStateMachine5 = base.appStateMachine;
		Action action5 = ShowCredits;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7710");
		AppStateMachine appStateMachine6 = base.appStateMachine;
		Action action6 = ShowOptions;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7890");
		AppStateMachine appStateMachine7 = base.appStateMachine;
		Action action7 = ShowPowerUps;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7A10");
		AppStateMachine appStateMachine8 = base.appStateMachine;
		Action action8 = ShowBestiary;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7B90");
		AppStateMachine appStateMachine9 = base.appStateMachine;
		Action action9 = ShowAdventuresSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7DF0");
		Action b = OnBack;
		BackButtonController.AddListener(b);
	}

	public override void OnExit()
	{
		base.OnExit();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = OnShowLobbyScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7290");
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action2 = OnShowErrorScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8630");
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action3 = ShowAchievements;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7F70");
		AppStateMachine appStateMachine4 = base.appStateMachine;
		Action action4 = ShowCollections;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8030");
		AppStateMachine appStateMachine5 = base.appStateMachine;
		Action action5 = ShowCredits;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA80F0");
		AppStateMachine appStateMachine6 = base.appStateMachine;
		Action action6 = ShowOptions;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA81B0");
		AppStateMachine appStateMachine7 = base.appStateMachine;
		Action action7 = ShowPowerUps;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8270");
		AppStateMachine appStateMachine8 = base.appStateMachine;
		Action action8 = ShowBestiary;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8330");
		AppStateMachine appStateMachine9 = base.appStateMachine;
		Action action9 = ShowAdventuresSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA83F0");
		Action b = OnBack;
		BackButtonController.TryRemoveListener(b);
		BackButtonController.BackButtonClosesPage = true;
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = true;
	}

	private void OnBack()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003COnBack_003Ed__4 stateMachine = default(_003COnBack_003Ed__4);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void GoBackOnline()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("GO_BACK_ONLINE");
		GameEventMessage.SendEvent("GO_BACK_ONLINE");
	}

	private void OnShowLobbyScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42C4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE_LOBBY");
		GameEventMessage.SendEvent("SHOW_ONLINE_LOBBY");
	}

	private void OnShowErrorScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42C5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("ONLINE_ERROR");
		GameEventMessage.SendEvent("ONLINE_ERROR");
	}

	private void ShowAchievements()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42C6]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ACHIEVEMENTS");
		GameEventMessage.SendEvent("SHOW_ACHIEVEMENTS");
	}

	private void ShowCollections()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42C7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_COLLECTIONS");
		GameEventMessage.SendEvent("SHOW_COLLECTIONS");
	}

	private void ShowOptions()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42C8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_OPTIONS");
		GameEventMessage.SendEvent("SHOW_OPTIONS");
	}

	private void ShowCredits()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42C9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_CREDITS");
		GameEventMessage.SendEvent("SHOW_CREDITS");
	}

	private void ShowPowerUps()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42CA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_POWER_UPS");
		GameEventMessage.SendEvent("SHOW_POWER_UPS");
	}

	private void ShowBestiary()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42CB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("OPEN_BESTIARY");
		GameEventMessage.SendEvent("OPEN_BESTIARY");
	}

	private void ShowAdventuresSelection()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42CC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SELECT_ADVENTURE");
		GameEventMessage.SendEvent("SELECT_ADVENTURE");
	}

	public AppOnlineState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
