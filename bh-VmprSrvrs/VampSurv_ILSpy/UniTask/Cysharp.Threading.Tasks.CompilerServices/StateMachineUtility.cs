using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.CompilerServices;

internal static class StateMachineUtility
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<FieldInfo, bool> _003C_003E9__0_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CGetState_003Eb__0_0(FieldInfo x)
		{
			//IL_0082: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189993281]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)x != null)
			{
				string name = x.Name;
				if (name != null)
				{
					return name.EndsWith("__state");
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static int GetState(IAsyncStateMachine stateMachine)
	{
		//IL_0195: Expected I4, but got O
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_00a5: Expected O, but got I
		//IL_00ca: Expected I, but got O
		if (stateMachine != null)
		{
			object obj = stateMachine + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj2 = default(object);
			if (obj2 != null)
			{
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v128 @ r8_v3+6D8] (should have been resolved before IL gen)");
				Func<FieldInfo, bool> predicate = _003C_003Ec._003C_003E9__0_0;
				if (_003C_003Ec._003C_003E9__0_0 == null)
				{
					predicate = (_003C_003Ec._003C_003E9__0_0 = delegate(FieldInfo x)
					{
						//IL_0082: Expected I4, but got O
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189993281]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if ((object)x != null)
						{
							string name = x.Name;
							if (name != null)
							{
								return name.EndsWith("__state");
							}
						}
						NullReferenceException ex3 = new NullReferenceException();
						return (byte)(int)ex3 != 0;
					});
				}
				IEnumerable<FieldInfo> source = default(IEnumerable<FieldInfo>);
				FieldInfo fieldInfo = Enumerable.First(source, predicate);
				if ((object)fieldInfo != null)
				{
					object value = fieldInfo.GetValue(stateMachine);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
					object obj4 = 0;
					if (value != null)
					{
						nint num = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v8 (Il2CppClass<System.Object>)+40]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r8_v9+40]");
						if (num2 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v12 (System.Object)+10]");
							return 0;
						}
						goto IL_0187;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_0187;
		IL_0187:
		InvalidCastException ex2 = new InvalidCastException();
		return (int)ex2;
	}
}
