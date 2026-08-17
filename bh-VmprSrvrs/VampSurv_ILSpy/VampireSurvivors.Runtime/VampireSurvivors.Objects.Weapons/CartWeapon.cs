using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Objects.Weapons;

public class CartWeapon : Weapon
{
	private Vector2? _003CLocation_003Ek__BackingField;

	public Vector2? Location
	{
		get
		{
			//IL_0010: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+158]");
			CartWeapon cartWeapon = (CartWeapon)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+160]");
			_ = 0;
			return (Vector2?)this;
		}
		set
		{
			_003CLocation_003Ek__BackingField = value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Nullable`1<UnityEngine.Vector2>)+8]");
			_ = 0;
		}
	}

	public override float PAmount()
	{
		return 1f;
	}

	public override float PPower()
	{
		//IL_002c: Expected O, but got F4
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPower();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = Random.value;
		float num3 = default(float);
		float num2 = currentWeaponData._003Cpower_003Ek__BackingField * num3;
		float num4 = num3 + num3;
		float num5 = num4 + 1f;
		return num5 * num2;
	}

	public override float PInterval()
	{
		//IL_0069: Invalid comparison between F4 and I
		//IL_0090: Expected F4, but got I
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
		float num2 = default(float);
		bool flag = !(0.1f < num2);
		float num3 = 0.1f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = num3 * currentWeaponData._003Cinterval_003Ek__BackingField;
		float num5 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11140]");
		if (num5 < 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11140]");
			num4 = 0f;
		}
		return num4;
	}
}
