using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class unused_EME_Magic2Weapon : unused_EME_Magic1Weapon
{
	private const int SPAWNED_ZONES = 5;

	public override void Fire(bool skipTriggers = false)
	{
		//IL_002a: Expected O, but got I
		//IL_0061: Expected I, but got O
		//IL_006f: Expected I, but got O
		//IL_007f: Expected O, but got I
		//IL_00ff: Expected O, but got I4
		//IL_00bb: Expected O, but got I
		//IL_00f1: Expected O, but got I4
		//IL_014c: Expected I, but got O
		bool flag = true;
		IntPtr intPtr = default(IntPtr);
		do
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile = base.FireOneProjectile((Vector2)(nint)intPtr, 0, _targetTransform);
			Projectile projectile2;
			if ((object)projectile == null)
			{
				projectile2 = null;
				goto IL_0198;
			}
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(EME_Magic2Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_Magic2Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_Magic2Projectile>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v26+FFFFFFF8+v148 @ rax_v22*8]");
				if (0 == (nint)typeof(EME_Magic2Projectile))
				{
					obj3 = 1;
					goto IL_0170;
				}
			}
			obj3 = 0;
			goto IL_0170;
			IL_0170:
			bool flag2 = obj3 == null;
			projectile2 = null;
			if (!flag2)
			{
				projectile2 = projectile;
			}
			goto IL_0198;
			IL_0198:
			if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
			{
				nint num4 = (nint)projectile2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v376 @ rax_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+448] (should have been resolved before IL gen)");
			}
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) <= 5);
	}
}
