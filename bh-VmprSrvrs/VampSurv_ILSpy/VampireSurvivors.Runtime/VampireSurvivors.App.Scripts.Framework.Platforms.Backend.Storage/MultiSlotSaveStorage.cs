using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Cpp2ILInjected;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Saves;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage;

public class MultiSlotSaveStorage : IMultiSlotSaveStorage
{
	[StructLayout((LayoutKind)3)]
	private struct _003CGetMergeConflictSlotData_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

		public MultiSlotSaveStorage _003C_003E4__this;

		private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_00a6: Expected O, but got I4
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_011b: Expected I4, but got I8
			//IL_012b: Expected O, but got Ref
			//IL_0140: Expected O, but got I
			//IL_0170: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<PlayerOptionsData>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<PlayerOptionsData> task2 = _003C_003E4__this.TryGet(PlayFabPlayerData.AllowedPlayerDataKeys.MERGE_CONFLICT_DATA);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<PlayerOptionsData> taskAwaiter = default(TaskAwaiter<PlayerOptionsData>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<PlayerOptionsData> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<PlayerOptionsData>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<PlayerOptionsData> awaiter = default(TaskAwaiter<PlayerOptionsData>);
					((AsyncTaskMethodBuilder<PlayerOptionsData>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->SetResult(0);
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

	[StructLayout((LayoutKind)3)]
	private struct _003CGetSlotData_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

		public MultiSlotSaveStorage _003C_003E4__this;

		public int slot;

		private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0145: Expected I4, but got I8
			//IL_00d0: Expected O, but got I4
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_0155: Expected O, but got Ref
			//IL_016a: Expected O, but got I
			//IL_019a: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<PlayerOptionsData>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003E4__this.AssertArgs(slot);
				PlayFabPlayerData.AllowedPlayerDataKeys key = _003C_003E4__this.GetKey(slot);
				Task<PlayerOptionsData> task2 = _003C_003E4__this.TryGet(key);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<PlayerOptionsData> taskAwaiter = default(TaskAwaiter<PlayerOptionsData>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<PlayerOptionsData> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<PlayerOptionsData>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<PlayerOptionsData> awaiter = default(TaskAwaiter<PlayerOptionsData>);
					((AsyncTaskMethodBuilder<PlayerOptionsData>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->SetResult(0);
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

	[StructLayout((LayoutKind)3)]
	private struct _003CTryGet_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

		public MultiSlotSaveStorage _003C_003E4__this;

		public PlayFabPlayerData.AllowedPlayerDataKeys key;

		private TaskAwaiter<string> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_009c: Expected O, but got I4
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			//IL_0131: Expected I4, but got I8
			//IL_017e: Expected O, but got Ref
			//IL_0141: Expected O, but got Ref
			MultiSlotSaveStorage multiSlotSaveStorage = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9CFE0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<string> taskAwaiter = default(TaskAwaiter<string>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<PlayerOptionsData> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<PlayerOptionsData>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
					((AsyncTaskMethodBuilder<PlayerOptionsData>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BDF0");
			SaveParser saveParser = new SaveParser();
			string data = default(string);
			PlayerOptionsData result = saveParser.ParsePod(data);
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->SetResult(result);
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

	[StructLayout((LayoutKind)3)]
	private struct _003CTrySet_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public PlayerOptionsData value;

		public MultiSlotSaveStorage _003C_003E4__this;

		public PlayFabPlayerData.AllowedPlayerDataKeys key;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_015d: Expected I4, but got I8
			//IL_016d: Expected O, but got Ref
			//IL_00e8: Expected O, but got I4
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Expected O, but got Unknown
			//IL_01b2: Expected O, but got Ref
			MultiSlotSaveStorage multiSlotSaveStorage = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				byte[] serializedPlayerData = SaveUtils.GetSerializedPlayerData(value);
				Encoding uTF = Encoding.UTF8;
				string text = uTF.GetString(serializedPlayerData);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BDF0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D070");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v10 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->SetResult(result: false);
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

	private const string SAVE_SLOT_KEY_PREFIX = "SAVE_DATA_SLOT_";

	private ISaveDataCompressor compressor;

	private IPlayerDataStorage storage;

	private int maxSlots;

	public MultiSlotSaveStorage(IPlayerDataStorage storage, int maxSlots)
	{
		if (storage != null)
		{
			this.storage = storage;
			this.maxSlots = maxSlots;
			GZipSaveDataCompressor gZipSaveDataCompressor = new GZipSaveDataCompressor();
			compressor = gZipSaveDataCompressor;
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("storage");
		throw ex;
	}

	public Task<bool> SetSlotData(int slot, PlayerOptionsData value)
	{
		AssertArgs(slot);
		PlayFabPlayerData.AllowedPlayerDataKeys key = GetKey(slot);
		return TrySet(key, value);
	}

	public Task<PlayerOptionsData> GetSlotData(int slot)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetSlotData_003Ed__6 stateMachine = default(_003CGetSlotData_003Ed__6);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<PlayerOptionsData>)(object)asyncTaskMethodBuilder.Task;
	}

	public Task<PlayerOptionsData> GetMergeConflictSlotData()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetMergeConflictSlotData_003Ed__7 stateMachine = default(_003CGetMergeConflictSlotData_003Ed__7);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<PlayerOptionsData>)(object)asyncTaskMethodBuilder.Task;
	}

	private void AssertArgs(int slot)
	{
		if (slot >= 1 && slot <= maxSlots)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
		string message = default(string);
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("slot", message);
		throw ex;
	}

	private unsafe PlayFabPlayerData.AllowedPlayerDataKeys GetKey(int slot)
	{
		//IL_00b1: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray("SAVE_DATA_SLOT_", arg);
		object obj = default(object);
		string text = string.FormatHelper((IFormatProvider)null, "{0}{1}", (System.ParamsArray)(&obj));
		if (Enum.TryParse<PlayFabPlayerData.AllowedPlayerDataKeys>(text, ignoreCase: false, out var result))
		{
			return result;
		}
		string message = "The key `" + text + "` is not allowed to be written to player data.";
		Exception ex = new Exception(message);
		throw ex;
	}

	private Task<PlayerOptionsData> TryGet(PlayFabPlayerData.AllowedPlayerDataKeys key)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CTryGet_003Ed__10 stateMachine = default(_003CTryGet_003Ed__10);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<PlayerOptionsData>)(object)asyncTaskMethodBuilder.Task;
	}

	private Task<bool> TrySet(PlayFabPlayerData.AllowedPlayerDataKeys key, PlayerOptionsData value)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CTrySet_003Ed__11 stateMachine = default(_003CTrySet_003Ed__11);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}
}
