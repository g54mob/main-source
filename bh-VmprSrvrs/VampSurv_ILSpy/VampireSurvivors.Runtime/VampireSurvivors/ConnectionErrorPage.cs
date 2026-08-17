using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class ConnectionErrorPage : BaseUIPage
{
	[StructLayout((LayoutKind)3)]
	private struct _003CQuit_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public ConnectionErrorPage _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_003e: Expected O, but got I
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0078: Expected O, but got I
			//IL_00b1: Expected O, but got I
			//IL_0219: Expected I4, but got I8
			//IL_0224: Expected O, but got Ref
			//IL_0119: Expected O, but got I4
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Expected O, but got Unknown
			//IL_0275: Expected O, but got Ref
			object CS_0024_003C_003E8__locals0 = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
				goto IL_013c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rsi_v1 (System.Object)+F0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v36+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v36+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v37+178]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rsi_v1 (System.Object)+F0]");
					Task<bool> task2 = ((LobbiesManager)0).LeaveLobby();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
					TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
					int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag = num == 0;
					bool flag2 = num < 0;
					bool flag3 = !flag2;
					object obj3 = !flag3;
					object obj4 = obj3 | flag;
					task = (Task)taskAwaiter;
					if (obj4 == null)
					{
						goto IL_013c;
					}
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			goto IL_017f;
			IL_017f:
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CShowQuitDescription_003Ek__BackingField = false;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
			TweenCallback onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACA80");
			};
			Tween tween = UITimerHelper.RegisterMillis(420f, onComplete);
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
			return;
			IL_013c:
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			goto IL_017f;
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

	private TextMeshProUGUI _errorText;

	private SignalBus _signalBus;

	private LobbiesManager _lobbiesManager;

	private void Construct(SignalBus signalBus, LobbiesManager lobbiesManager)
	{
		_signalBus = signalBus;
		_lobbiesManager = lobbiesManager;
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		GameManager core = GM.Core;
		string message = core._003CConnectionException_003Ek__BackingField.Message;
		_errorText.text = message;
	}

	public void Quit()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CQuit_003Ed__5 stateMachine = default(_003CQuit_003Ed__5);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void _003CQuit_003Eb__5_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACA80");
	}
}
