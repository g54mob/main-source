using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Greatsword2Weapon : EME_Greatsword1Weapon
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword2Weapon>)+608]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword2Weapon>)+610]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		BulletPool glimmerBulletPool = base.GetGlimmerBulletPool(_fireCounter, out var _);
		if (glimmerBulletPool != _glimmer1Pool && glimmerBulletPool != _glimmer2Pool)
		{
			Projectile projectile = base.FireOneProjectile(pos, index, target);
		}
	}

	public EME_Greatsword2Weapon()
	{
		List<AbsetzenInstance> absetzenInstances = new List<AbsetzenInstance>();
		base._absetzenInstances = absetzenInstances;
		((EME_Weapon)this)._002Ector();
	}
}
