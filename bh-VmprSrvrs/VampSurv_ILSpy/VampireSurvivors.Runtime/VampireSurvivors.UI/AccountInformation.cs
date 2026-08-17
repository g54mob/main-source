using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

namespace VampireSurvivors.UI;

public class AccountInformation
{
	[StructLayout((LayoutKind)3)]
	private struct _003CFetch_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AccountInformation _003C_003E4__this;

		private TaskAwaiter<string> _003C_003Eu__1;

		private TaskAwaiter<IPlayerProfile> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005b: Expected O, but got I4
			//IL_006a: Expected I4, but got I8
			//IL_0166: Expected O, but got I
			//IL_0258: Expected O, but got I
			//IL_00eb: Expected O, but got I4
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_026c: Expected I4, but got I8
			//IL_027c: Expected O, but got Ref
			//IL_035d: Expected O, but got Ref
			//IL_01dd: Expected O, but got I4
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Expected O, but got Unknown
			//IL_02ed: Expected O, but got Ref
			AccountInformation accountInformation = _003C_003E4__this;
			Task task;
			Task task2;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					_003C_003Eu__2 = (TaskAwaiter<IPlayerProfile>)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__2;
					goto IL_0200;
				}
				Task<string> accountEmailAddress = BackendFacade.GetAccountEmailAddress();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				Task task3 = default(Task);
				int num = task3.m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = task3;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<string>)task3;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ rbx_v14 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
					}
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
					((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v10 (System.Threading.Tasks.Task)+50]");
			accountInformation._003CAccountEmailAddress_003Ek__BackingField = (string)0;
			Task<IPlayerProfile> playerProfile = BackendFacade.GetPlayerProfile();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
			Task task4 = default(Task);
			int num4 = task4.m_stateFlags & 0x1600000;
			bool flag4 = num4 == 0;
			bool flag5 = num4 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			task2 = task4;
			if (obj4 == null)
			{
				goto IL_0200;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = (TaskAwaiter<IPlayerProfile>)task4;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ rbx_v12 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter<IPlayerProfile> awaiter2 = default(TaskAwaiter<IPlayerProfile>);
			((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
			return;
			IL_0200:
			int num6 = task2.m_stateFlags & 0x11000000;
			if (num6 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rbx_v9 (System.Threading.Tasks.Task)+50]");
			accountInformation._003CPlayerProfile_003Ek__BackingField = (IPlayerProfile)0;
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder3)->SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private static readonly AccountInformation _accountInformation;

	private IPlayerProfile _003CPlayerProfile_003Ek__BackingField;

	private string _003CAccountEmailAddress_003Ek__BackingField;

	private IPlayerProfile PlayerProfile
	{
		get
		{
			return _003CPlayerProfile_003Ek__BackingField;
		}
		set
		{
			_003CPlayerProfile_003Ek__BackingField = value;
		}
	}

	private string AccountEmailAddress
	{
		get
		{
			return _003CAccountEmailAddress_003Ek__BackingField;
		}
		set
		{
			_003CAccountEmailAddress_003Ek__BackingField = value;
		}
	}

	private AccountInformation()
	{
	}

	public static AccountInformation Instance()
	{
		return _accountInformation;
	}

	public IPlayerProfile GetPlayerProfile()
	{
		if (_003CPlayerProfile_003Ek__BackingField != null)
		{
			return _003CPlayerProfile_003Ek__BackingField;
		}
		Exception ex = new Exception("PlayerProfile is not set");
		throw ex;
	}

	public string GetAccountEmailAddress()
	{
		if (_003CAccountEmailAddress_003Ek__BackingField != null)
		{
			return _003CAccountEmailAddress_003Ek__BackingField;
		}
		Debug.LogError("AccountEmailAddress is not set");
		return null;
	}

	public unsafe Task Fetch()
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CFetch_003Ed__13 stateMachine = default(_003CFetch_003Ed__13);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	public void Clear()
	{
		_003CAccountEmailAddress_003Ek__BackingField = null;
		_003CPlayerProfile_003Ek__BackingField = null;
	}

	private bool HasAccountEmailAddress()
	{
		bool flag = _003CAccountEmailAddress_003Ek__BackingField == null;
		return !flag;
	}

	private bool HasPlayerProfile()
	{
		bool flag = _003CPlayerProfile_003Ek__BackingField == null;
		return !flag;
	}

	static AccountInformation()
	{
		AccountInformation accountInformation = new AccountInformation();
		_accountInformation = accountInformation;
	}
}
