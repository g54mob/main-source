using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_AlucardShield_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, bool> _003C_003E9__4_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__4_0(Equipment x)
		{
			//IL_006d: Expected I4, but got O
			//IL_0034: Expected I4, but got O
			if ((object)x != null && x._currentJsonDataObject != null)
			{
				bool flag = (byte)(int)x._currentJsonDataObject.ToObject<object>() != 0;
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v4 (System.Boolean)+60]");
					return false;
				}
				return flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public int SlotNumber = 1;

	private readonly List<Equipment> _weaponsHiddenByShield;

	public unsafe bool TryGetWeaponHiddenByShield(WeaponType weaponType, out Equipment weapon)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		ref Equipment reference = ref *(Equipment*)null;
		return false;
	}

	public override float PPower()
	{
		return 25.5f;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0553: Expected I, but got O
		//IL_0569: Expected O, but got I
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_066c: Expected O, but got I4
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_0117: Expected O, but got Ref
		base.InitWeapon(characterController, weaponType);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
			if ((object)characterController2._weaponsManager != null)
			{
				Func<Equipment, bool> predicate = _003C_003Ec._003C_003E9__4_0;
				if (_003C_003Ec._003C_003E9__4_0 == null)
				{
					Func<Equipment, bool> func = (_003C_003Ec._003C_003E9__4_0 = delegate(Equipment x)
					{
						//IL_006d: Expected I4, but got O
						//IL_0034: Expected I4, but got O
						if ((object)x == null || x._currentJsonDataObject == null)
						{
							NullReferenceException ex2 = new NullReferenceException();
							return (byte)(int)ex2 != 0;
						}
						bool flag2 = (byte)(int)x._currentJsonDataObject.ToObject<object>() != 0;
						if (flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v4 (System.Boolean)+60]");
							return false;
						}
						return flag2;
					});
					nint num = (nint)typeof(_003C_003Ec);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v80 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardShield_Weapon+<>c>)+B8]");
					object obj = (nint)0 + (nint)8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag = (nint)0 == 0;
					predicate = func;
					if (!flag)
					{
						object obj2 = obj >> 12;
						object obj3 = obj2 & 0x1FFFFF;
						object obj4 = obj3 >> 6;
						object obj5 = obj4 * 8;
						object obj6 = 6603577472L + obj5;
						object obj7 = obj3 & 0x3F;
						nint num3;
						do
						{
							object obj8 = 1 << (int)obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v35+462E0]");
							object obj9 = 0 | obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v35+462E0]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v35+462E0]");
							if (num2 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v35+462E0]");
							num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v35+462E0]");
						}
						while (num3 != 0);
						predicate = func;
					}
				}
				IEnumerable<Equipment> enumerable = Enumerable.Where(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, predicate);
				if (enumerable == null)
				{
					Exception ex = System.Linq.Error.ArgumentNull("source");
					throw ex;
				}
				List<object> list = new List<object>(enumerable);
				if (list != null)
				{
					List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
					if (enumerator.MoveNext())
					{
						Equipment equipment = null;
						List<object> list2 = (List<object>)(&enumerator);
						throw new NullReferenceException();
					}
					VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && characterController3.HeldShieldSlots != null)
					{
						((List<Equipment>)(object)characterController3.HeldShieldSlots)._002Ector((IEnumerable<Equipment>)this);
						VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							List<Weapon> heldShieldSlots = characterController4.HeldShieldSlots;
							if (characterController4.HeldShieldSlots != null)
							{
								SlotNumber = heldShieldSlots._size;
								base._003CCanCrit_003Ek__BackingField = true;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		base.Cleanup();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = ((List<object>)(object)characterController.HeldShieldSlots).Remove((object)this);
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0067: Invalid comparison between O and F4
		//IL_0092: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	protected override float CalcCritMul()
	{
		//IL_0062: Expected O, but got I
		//IL_00c8: Invalid comparison between F4 and I
		if (base._003CCanCrit_003Ek__BackingField)
		{
			List<float> critChancesArray = _critChancesArray;
			int critIndex = _critIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num = (int)((nint)critIndex % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num >= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int critIndex2 = _critIndex + 1;
			_critIndex = critIndex2;
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			WeaponData currentWeaponData = _currentWeaponData;
			float num4 = default(float);
			float num3 = num4 * currentWeaponData._003CcritChance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v7+20+v108 @ rdx_v4 (System.Int32)*4]");
			if (num3 > 0f)
			{
				return num4 * ArcanaManager.CritMul;
			}
		}
		return 1f;
	}

	public TP_AlucardShield_Weapon()
	{
		List<Equipment> weaponsHiddenByShield = new List<Equipment>();
		_weaponsHiddenByShield = weaponsHiddenByShield;
		base._002Ector();
	}
}
