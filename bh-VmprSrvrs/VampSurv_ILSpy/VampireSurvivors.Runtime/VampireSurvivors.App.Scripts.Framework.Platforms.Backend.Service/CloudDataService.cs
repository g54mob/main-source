using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Saves;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public class CloudDataService
{
	[StructLayout((LayoutKind)3)]
	private struct _003CGetSlotSummary_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public int slot;

		public CloudDataService _003C_003E4__this;

		private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0056: Expected I, but got O
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0082: Expected I, but got O
			//IL_0184: Expected O, but got I
			//IL_0163: Expected I, but got O
			//IL_00e0: Expected O, but got I4
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_00f2: Expected I, but got O
			//IL_025a: Expected I4, but got I8
			//IL_01d5: Expected O, but got Ref
			//IL_01b7: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<PlayerOptionsData>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<PlayerOptionsData> slotSaveData = BackendFacade.GetSlotSaveData(slot);
				bool flag = slotSaveData == null;
				nint num = unchecked((nint)null);
				if (flag)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<PlayerOptionsData> taskAwaiter = default(TaskAwaiter<PlayerOptionsData>);
				bool flag2 = (object)taskAwaiter == null;
				num = unchecked((nint)null);
				if (flag2)
				{
					throw new NullReferenceException();
				}
				int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag3 = num2 == 0;
				bool flag4 = num2 < 0;
				bool flag5 = !flag4;
				object obj = !flag5;
				object obj2 = obj | flag3;
				num = unchecked((nint)null);
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<string>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<PlayerOptionsData> awaiter = default(TaskAwaiter<PlayerOptionsData>);
					((AsyncTaskMethodBuilder<string>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			if (task != null)
			{
				int num3 = task.m_stateFlags & 0x11000000;
				if (num3 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					nint num = unchecked((nint)null);
				}
				CloudDataService cloudDataService = _003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v5 (System.Threading.Tasks.Task)+50]");
				string result = cloudDataService.PlayerOptionsDataToSummaryString((PlayerOptionsData)0);
				_003C_003E1__state = -2;
				AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->SetResult(result);
				return;
			}
			throw new NullReferenceException();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private string NO_DATA_LABEL;

	public Task<string> GetSlotSummary(int slot)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetSlotSummary_003Ed__1 stateMachine = default(_003CGetSlotSummary_003Ed__1);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<string>)(object)asyncTaskMethodBuilder.Task;
	}

	public unsafe string PlayerOptionsDataToSummaryString(PlayerOptionsData playerOptionsData)
	{
		//IL_0086: Expected O, but got Ref
		//IL_00b6: Expected O, but got Ref
		SaveSummary saveSummary = SaveUtils.GetSaveSummary(playerOptionsData);
		string[] array = new string[3];
		if (saveSummary != null && array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj = default(object);
			string text = System.Number.FormatInt32(saveSummary._003C_totalGold_003Ek__BackingField, (ReadOnlySpan<char>)(&obj), null);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string text2 = System.Number.FormatInt32(saveSummary._003C_achievements_003Ek__BackingField, (ReadOnlySpan<char>)(&obj), null);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return AccountPage.GetAccountTranslation("common_data_summary", array);
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe bool IsEmpty(string slotSummary)
	{
		//IL_00f6: Expected I4, but got O
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Ref, but got Unknown
		//IL_00b2: Expected I8, but got I4
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Ref, but got Unknown
		if (slotSummary != null)
		{
			string nO_DATA_LABEL = NO_DATA_LABEL;
			if ((object)slotSummary != NO_DATA_LABEL)
			{
				if (NO_DATA_LABEL != null && slotSummary._stringLength == nO_DATA_LABEL._stringLength)
				{
					ref byte first = ref *(byte*)(slotSummary + 20);
					ulong length = (ulong)(slotSummary._stringLength + slotSummary._stringLength);
					return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)(NO_DATA_LABEL + 20), length);
				}
				return false;
			}
			return true;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public CloudDataService()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A302D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string accountTranslation = AccountPage.GetAccountTranslation("save_data_no_data");
		NO_DATA_LABEL = accountTranslation;
	}
}
