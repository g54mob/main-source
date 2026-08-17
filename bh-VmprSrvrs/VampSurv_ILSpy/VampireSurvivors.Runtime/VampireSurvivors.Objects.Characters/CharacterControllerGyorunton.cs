using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerGyorunton : CharacterController
{
	public override void GetTreasureModifier()
	{
		//IL_016b: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		//IL_00a7: Expected O, but got I
		//IL_012c: Expected O, but got I
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		GameManager core = GM.Core;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			TreasureFactory treasureFactory = core._treasureFactory;
			List<PrizeType> currentTreasureTypes = treasureFactory.currentTreasureTypes;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
			if ((nint)obj3 >= 0)
			{
				return;
			}
			GameManager core2 = GM.Core;
			TreasureFactory treasureFactory2 = core2._treasureFactory;
			List<PrizeType> currentTreasureTypes2 = treasureFactory2.currentTreasureTypes;
			object obj4 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
			if ((nint)obj4 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v5+20+v48 @ r8_v2*4]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v5+20+v48 @ r8_v2*4]");
				if ((nint)0 != 2)
				{
					goto IL_0180;
				}
			}
			GameManager core3 = GM.Core;
			TreasureFactory treasureFactory3 = core3._treasureFactory;
			List<PrizeType> currentTreasureTypes3 = treasureFactory3.currentTreasureTypes;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
			object obj6 = 0;
			_ = 6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+1C]");
			_ = (nint)0 + (nint)1;
			goto IL_0180;
			IL_0180:
			obj++;
			core = GM.Core;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
