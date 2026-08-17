using Cpp2ILInjected;
using Unity.Mathematics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_BloodProjectile_BloodRage : EME_BloodProjectile
{
	public override void OnTargetHit()
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		Weapon weapon = _weapon;
		if ((object)_weapon == null)
		{
			return;
		}
		nint num = (nint)typeof(EME_Blood1Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v10+FFFFFFF8+v45 @ rax_v3*8]");
			if (0 == (nint)typeof(EME_Blood1Weapon))
			{
				obj3 = 1;
				goto IL_0116;
			}
		}
		obj3 = 0;
		goto IL_0116;
		IL_0116:
		bool flag = obj3 == null;
		EME_Blood1Weapon eME_Blood1Weapon = null;
		if (!flag)
		{
			eME_Blood1Weapon = (EME_Blood1Weapon)_weapon;
		}
		if ((object)eME_Blood1Weapon != null)
		{
			float2 float5 = base.position;
			float areaMul = default(float);
			eME_Blood1Weapon.SpawnSpecialProjectiles(float5, eME_Blood1Weapon._bloodRagePool, 2f, areaMul);
		}
	}
}
