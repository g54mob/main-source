using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyMushMan : EnemyController
{
	private PhaserSprite maskSprite;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_028a: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_02b2: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02da: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0234: Expected O, but got I
		base.InitEnemy(enemyType, asRemote);
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v5+18]");
		if (num >= 0)
		{
			list.AddWithResize(16755336u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16755336;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(16764040u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 16764040;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v9+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(16764142u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 16764142;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v11+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(16777215u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 16777215;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		uint item = 0u;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rdx_v14 (System.UInt32)+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(13421670u);
			item = 13421670u;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj9 = (nint)0 + (nint)1;
			_ = 13421670;
		}
		list.Add(item);
		uint num6 = default(uint);
		_saveTint = num6;
		ArcadeSprite arcadeSprite = setTint(num6);
	}
}
