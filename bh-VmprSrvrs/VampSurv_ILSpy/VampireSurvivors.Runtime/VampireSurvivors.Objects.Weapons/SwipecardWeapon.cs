using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class SwipecardWeapon : Weapon
{
	private bool muteProjectile;

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0076: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_01bf: Invalid comparison between O and F4
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected I4, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0148: Invalid comparison between O and F4
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_0173: Expected F4, but got O
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		if (spawnedProjectiles._size > 0)
		{
			bool flag = !muteProjectile;
			muteProjectile = flag;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003CcritChance_003Ek__BackingField;
		object obj2 = 1;
		object obj3 = 0;
		object obj4;
		bool flag3;
		do
		{
			float chanceFromArray = base.GetChanceFromArray();
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2);
			obj4 = obj2;
			if (flag2)
			{
				break;
			}
			obj4 = obj2 + 1;
			obj3++;
			flag3 = (nint)obj3 < 3;
			obj2 = obj4;
		}
		while (flag3);
		float num3 = base.PAmount();
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm6\"");
		IntPtr intPtr = default(IntPtr);
		int index = (int)((nint)intPtr * obj4);
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, index);
		float num4 = base.PInterval();
		float num5 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj5 = num5 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num6 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}
}
