using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GattiCounterProjectile : GattiProjectile
{
	protected override void CreateCatAnim()
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_00cf: Expected O, but got I
		Weapon weapon = _weapon;
		bool flag = (object)_weapon == null;
		List<string> catFrames = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)typeof(GattiCounterWeapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r10_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r10_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v17+FFFFFFF8+v44 @ rax_v11*8]");
				if (0 == (nint)typeof(GattiCounterWeapon))
				{
					obj3 = 1;
					goto IL_0109;
				}
			}
			obj3 = 0;
			goto IL_0109;
		}
		goto IL_012b;
		IL_012b:
		_catFrames = catFrames;
		base.CreateCatAnim();
		return;
		IL_0109:
		bool flag2 = obj3 == null;
		Weapon weapon2 = null;
		if (!flag2)
		{
			weapon2 = _weapon;
		}
		bool flag3 = (object)weapon2 == null;
		catFrames = null;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v14 (VampireSurvivors.Objects.Weapons.Weapon)+170]");
			catFrames = (List<string>)0;
		}
		goto IL_012b;
	}
}
