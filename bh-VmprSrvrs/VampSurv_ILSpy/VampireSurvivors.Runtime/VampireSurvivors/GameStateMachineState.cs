using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class GameStateMachineState : StateMachineState
{
	protected GameStateMachine _gameStateMachine;

	public override void Init(StateMachine stateMachine)
	{
		//IL_0164: Expected I, but got O
		//IL_001c: Expected I, but got O
		//IL_002c: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_00ad: Expected I, but got O
		//IL_00b5: Expected I, but got O
		//IL_00c5: Expected O, but got I
		//IL_0101: Expected O, but got I
		parentStateMachine = stateMachine;
		nint num = (nint)typeof(GameStateMachine);
		if ((object)stateMachine == null)
		{
			_gameStateMachine = (GameStateMachine)stateMachine;
			return;
		}
		nint num2 = (nint)stateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v2 (Il2CppClass<VampireSurvivors.GameStateMachine>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v2 (Il2CppClass<VampireSurvivors.StateMachine>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v2 (Il2CppClass<VampireSurvivors.GameStateMachine>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v2 (Il2CppClass<VampireSurvivors.StateMachine>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v16+FFFFFFF8+v114 @ rax_v11*8]");
			if (0 == (nint)typeof(GameStateMachine))
			{
				_gameStateMachine = (GameStateMachine)stateMachine;
				nint num4 = (nint)typeof(GameStateMachine);
				nint num5 = (nint)stateMachine;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v7 (Il2CppClass<VampireSurvivors.GameStateMachine>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r9_v4 (Il2CppClass<VampireSurvivors.StateMachine>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v7 (Il2CppClass<VampireSurvivors.GameStateMachine>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r9_v4 (Il2CppClass<VampireSurvivors.StateMachine>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v18+FFFFFFF8+v234 @ rax_v17*8]");
					if (0 == (nint)typeof(GameStateMachine))
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
	}

	public GameStateMachineState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
