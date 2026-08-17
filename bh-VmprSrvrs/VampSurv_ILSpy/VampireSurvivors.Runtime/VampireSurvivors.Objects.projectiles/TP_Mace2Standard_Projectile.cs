using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Mace2Standard_Projectile : Projectile
{
	protected TP_Mace2_Weapon _trueWeapon;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I4, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00e4: Expected I, but got O
		//IL_00ec: Expected I, but got O
		//IL_00fc: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_0138: Expected O, but got I
		//IL_0175: Expected O, but got I
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_028c: Expected O, but got I4
		//IL_028c: Expected F4, but got O
		//IL_01ce: Expected O, but got I4
		//IL_01ce: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		TP_Mace2_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0235;
		}
		nint num = (nint)typeof(TP_Mace2_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v9 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v9 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v32+FFFFFFF8+v62 @ rax_v27*8]");
			if (0 == (nint)typeof(TP_Mace2_Weapon))
			{
				obj3 = 1;
				goto IL_0244;
			}
		}
		obj3 = 0;
		goto IL_0244;
		IL_0244:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (TP_Mace2_Weapon)_weapon;
		}
		goto IL_0235;
		IL_0235:
		_trueWeapon = trueWeapon;
		float num4 = weapon.PArea();
		nint num5 = (nint)typeof(TP_Mace2_Weapon);
		nint num6 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+130]");
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v10+FFFFFFF8+v227 @ rax_v9*8]");
			if (0 == (nint)typeof(TP_Mace2_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+130]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v10+FFFFFFF8+v338 @ rcx_v8*8]");
				object obj7 = 0 - typeof(TP_Mace2_Weapon);
				if (obj7 != null)
				{
					float2 float5 = default(float2);
					base.position = float5;
					float num8 = weapon.PArea();
					ArcadeSprite arcadeSprite = setScale((float)float5, (float?)(object)0);
					ArcadeSprite arcadeSprite2 = setAlpha(0f);
				}
				BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
				BaseBody baseBody2 = body;
				baseBody2._enable = true;
				return;
			}
		}
		throw new NullReferenceException();
	}
}
