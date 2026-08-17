using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySnekRed : EnemySnek
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0211: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0157: Expected O, but got I
		//IL_026c: Expected O, but got I4
		//IL_017d: Expected O, but got I
		base.InitEnemy(enemyType, asRemote);
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v9+18]");
		if (num >= 0)
		{
			list.AddWithResize(16746564u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16746564;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v11+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(16746632u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 16746632;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		uint num3 = 0u;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v13 (System.UInt32)+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(16729156u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj5 = (nint)0 + (nint)1;
			_ = 16729156;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		object obj6 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		bool flag = (nint)obj6 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v22+20+v104 @ rax_v22*4]");
		_saveTint = 0u;
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v22+20+v104 @ rax_v22*4]");
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(enemyRenderer, 0u);
		BaseBody baseBody = body;
		float2 float5 = default(float2);
		baseBody._transform.setOrigin(float5);
	}
}
