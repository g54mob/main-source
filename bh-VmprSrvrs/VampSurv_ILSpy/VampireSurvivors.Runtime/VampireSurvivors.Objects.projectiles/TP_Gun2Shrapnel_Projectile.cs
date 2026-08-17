using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Gun2Shrapnel_Projectile : TP_Gun1Shrapnel_Projectile
{
	private List<Color> colors;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		object trail = _trail;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BD30");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdi_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdi_v2 (System.Object)+10]");
		Color value = default(Color);
		TrailRenderer.set_startColor_Injected((IntPtr)0, ref value);
	}

	public unsafe TP_Gun2Shrapnel_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00b1: Expected O, but got I
		//IL_0066: Expected O, but got Ref
		//IL_0076: Expected O, but got I
		//IL_038a: Expected O, but got I
		//IL_0134: Expected O, but got I
		//IL_0154: Expected O, but got I
		//IL_0109: Expected O, but got Ref
		//IL_0119: Expected O, but got I
		//IL_03b2: Expected O, but got I
		//IL_01d7: Expected O, but got I
		//IL_01f7: Expected O, but got I
		//IL_01ac: Expected O, but got Ref
		//IL_01bc: Expected O, but got I
		//IL_03da: Expected O, but got I
		//IL_027a: Expected O, but got I
		//IL_029a: Expected O, but got I
		//IL_024f: Expected O, but got Ref
		//IL_025f: Expected O, but got I
		//IL_0402: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_032d: Expected O, but got I
		//IL_02f2: Expected O, but got Ref
		List<Color> list = new List<Color>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v4+18]");
		object obj2 = default(object);
		if (num >= 0)
		{
			list.AddWithResize((Color)(&obj2));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A122C0]");
			obj2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj3 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj4 = (nint)0 + (nint)2;
			object obj5 = obj4 + obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A122C0]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize((Color)(&obj2));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A123E0]");
			obj2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj7 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj8 = (nint)0 + (nint)2;
			object obj9 = obj8 + obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A123E0]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize((Color)(&obj2));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12120]");
			obj2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj11 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj12 = (nint)0 + (nint)2;
			object obj13 = obj12 + obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12120]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize((Color)(&obj2));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FA0]");
			obj2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj15 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj16 = (nint)0 + (nint)2;
			object obj17 = obj16 + obj16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FA0]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize((Color)(&obj2));
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj19 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj20 = (nint)0 + (nint)2;
			object obj21 = obj20 + obj20;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12110]");
			_ = 0;
		}
		colors = list;
		((Projectile)this)._002Ector();
	}
}
