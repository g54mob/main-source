using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Mech2Weapon : EME_Mech1Weapon
{
	protected override int GlimmerTier => 2;

	protected override int ComboIndexFinal
	{
		get
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech2Weapon>)+608]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech2Weapon>)+610]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0017: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		Projectile projectile = base.FireOneProjectile(pos, index, target);
		int index2 = index + 1;
		Projectile projectile2 = base.FireOneProjectile(pos, index2, target);
		Projectile projectile3;
		if ((object)projectile2 == null)
		{
			projectile3 = null;
			goto IL_01bf;
		}
		nint num = (nint)projectile2;
		nint num2 = (nint)typeof(EME_MechProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_MechProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_MechProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v23+FFFFFFF8+v80 @ rax_v19*8]");
			if (0 == (nint)typeof(EME_MechProjectile))
			{
				obj3 = 1;
				goto IL_0198;
			}
		}
		obj3 = 0;
		goto IL_0198;
		IL_0198:
		bool flag = obj3 == null;
		projectile3 = null;
		if (!flag)
		{
			projectile3 = projectile2;
		}
		goto IL_01bf;
		IL_01bf:
		if ((object)projectile3 != null && ((UnityEngine.Object)projectile3).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rbx_v2 (VampireSurvivors.Objects.Projectiles.Projectile)+E0]");
			float num4 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rbx_v2 (VampireSurvivors.Objects.Projectiles.Projectile)+E4]");
			float num5 = 0f * -1f;
		}
	}
}
