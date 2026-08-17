using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects;

public class CharacterWeaponsManager : EquipmentManager
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Weapon effectedWeapon;

		internal bool _003CSetWeaponActive_003Eb__0(Equipment w)
		{
			//IL_003d: Expected I, but got O
			//IL_0045: Expected I, but got O
			//IL_0055: Expected O, but got I
			//IL_00d5: Expected O, but got I4
			//IL_0091: Expected O, but got I
			//IL_00c7: Expected O, but got I4
			//IL_021b: Expected O, but got I4
			//IL_0235: Expected O, but got I4
			//IL_01b8: Expected I4, but got O
			Weapon weapon = effectedWeapon;
			Equipment equipment;
			if ((object)w == null)
			{
				equipment = null;
				goto IL_01ee;
			}
			nint num = (nint)typeof(Weapon);
			nint num2 = (nint)w;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v25+FFFFFFF8+v67 @ rax_v21*8]");
				if (0 == (nint)typeof(Weapon))
				{
					obj3 = 1;
					goto IL_01cc;
				}
			}
			obj3 = 0;
			goto IL_01cc;
			IL_01cc:
			bool flag = obj3 == null;
			equipment = null;
			if (!flag)
			{
				equipment = w;
			}
			goto IL_01ee;
			IL_01ee:
			bool flag2 = (object)equipment == null;
			bool flag3 = (object)effectedWeapon == null;
			object obj4 = flag3 & flag2;
			bool flag4 = obj4 == null;
			object obj5 = !flag4;
			if (obj5 == null)
			{
				if ((object)effectedWeapon != null)
				{
					if ((object)equipment != null)
					{
						object obj6 = (object)equipment - (object)effectedWeapon;
						return obj6 == null;
					}
					return ((UnityEngine.Object)weapon).m_CachedPtr == (IntPtr)0;
				}
				if ((object)equipment != null)
				{
					return ((UnityEngine.Object)equipment).m_CachedPtr == (IntPtr)0;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return true;
		}
	}

	private int _maxActiveCount = -1;

	private int _maxHiddenCount;

	public bool ShouldSkipWeaponUpdates => _maxActiveCount == 0;

	public void SetWeaponsActive(bool active)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected I4, but got Unknown
		//IL_0034: Expected O, but got I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected I4, but got Unknown
		object obj = (active ? 1 : 0) ^ 1;
		int maxActiveCount = obj - 1;
		_maxActiveCount = maxActiveCount;
		object obj2 = (active ? 1 : 0) ^ 1;
		SetMaxWeaponCount(maxHidden: _maxHiddenCount = obj2 - 1, maxActives: _maxActiveCount);
	}

	public Weapon SetWeaponActive(bool active, Weapon effectedWeapon = null)
	{
		//IL_0390: Expected O, but got I4
		//IL_039e: Expected I4, but got O
		//IL_03a2: Expected O, but got I4
		//IL_020f: Expected I, but got O
		//IL_0217: Expected I, but got O
		//IL_0227: Expected O, but got I
		//IL_00c2: Expected I, but got O
		//IL_00d0: Expected I, but got O
		//IL_00e0: Expected O, but got I
		//IL_02a7: Expected O, but got I4
		//IL_0160: Expected O, but got I4
		//IL_0263: Expected O, but got I
		//IL_011c: Expected O, but got I
		//IL_0299: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_0403->IL0172: Incompatible stack heights: 1 vs 0
		//IL_02ee->IL0172: Incompatible stack heights: 1 vs 0
		//IL_0313->IL0172: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass5_0();
		Weapon effectedWeapon2 = default(Weapon);
		CS_0024_003C_003E8__locals7.effectedWeapon = effectedWeapon2;
		Weapon effectedWeapon3 = CS_0024_003C_003E8__locals7.effectedWeapon;
		List<Equipment> list;
		object obj;
		Weapon weapon;
		object obj4;
		if ((object)CS_0024_003C_003E8__locals7.effectedWeapon != null)
		{
			bool flag = ((UnityEngine.Object)effectedWeapon3).m_CachedPtr == (IntPtr)0;
			list = base._003CActiveEquipment_003Ek__BackingField;
			if (!flag)
			{
				Func<Equipment, bool> predicate = delegate(Equipment w)
				{
					//IL_003d: Expected I, but got O
					//IL_0045: Expected I, but got O
					//IL_0055: Expected O, but got I
					//IL_00d5: Expected O, but got I4
					//IL_0091: Expected O, but got I
					//IL_00c7: Expected O, but got I4
					//IL_021b: Expected O, but got I4
					//IL_0235: Expected O, but got I4
					//IL_01b8: Expected I4, but got O
					Weapon effectedWeapon4 = CS_0024_003C_003E8__locals7.effectedWeapon;
					object obj12;
					if ((object)w != null)
					{
						nint num7 = (nint)typeof(Weapon);
						nint num8 = (nint)w;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						if (num9 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v25+FFFFFFF8+v67 @ rax_v21*8]");
							if (0 == (nint)typeof(Weapon))
							{
								obj12 = 1;
								goto IL_01cc;
							}
						}
						obj12 = 0;
						goto IL_01cc;
					}
					Equipment equipment = null;
					goto IL_01ee;
					IL_01cc:
					bool flag6 = obj12 == null;
					equipment = null;
					if (!flag6)
					{
						equipment = w;
					}
					goto IL_01ee;
					IL_01ee:
					bool flag7 = (object)equipment == null;
					bool flag8 = (object)CS_0024_003C_003E8__locals7.effectedWeapon == null;
					object obj13 = flag8 & flag7;
					bool flag9 = obj13 == null;
					object obj14 = !flag9;
					if (obj14 == null)
					{
						if ((object)CS_0024_003C_003E8__locals7.effectedWeapon != null)
						{
							if ((object)equipment != null)
							{
								object obj15 = (object)equipment - (object)CS_0024_003C_003E8__locals7.effectedWeapon;
								return obj15 == null;
							}
							return ((UnityEngine.Object)effectedWeapon4).m_CachedPtr == (IntPtr)0;
						}
						if ((object)equipment == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						return ((UnityEngine.Object)equipment).m_CachedPtr == (IntPtr)0;
					}
					return true;
				};
				obj = Enumerable.FirstOrDefault(base._003CActiveEquipment_003Ek__BackingField, (Func<object, bool>)predicate);
				if (obj == null)
				{
					weapon = null;
					goto IL_0348;
				}
				nint num = (nint)obj;
				nint num2 = (nint)typeof(Weapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ r8_v13 (Il2CppClass<System.Object>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ r8_v13 (Il2CppClass<System.Object>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v53+FFFFFFF8+v499 @ rax_v49*8]");
					if (0 == (nint)typeof(Weapon))
					{
						obj4 = 1;
						goto IL_035b;
					}
				}
				obj4 = 0;
				goto IL_035b;
			}
		}
		else
		{
			list = base._003CActiveEquipment_003Ek__BackingField;
		}
		object obj5 = list._size - 1;
		object obj6 = UnityEngine.Random.RandomRangeInt(0, (int)obj5);
		List<Equipment> list2 = base._003CActiveEquipment_003Ek__BackingField;
		bool flag2 = (nint)obj6 >= list2._size;
		Equipment[] items = list2._items;
		Weapon weapon2 = (Weapon)items[obj6];
		if ((object)items[obj6] == null)
		{
			weapon = null;
			goto IL_03b1;
		}
		nint num4 = (nint)typeof(Weapon);
		nint num5 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj9;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v683 @ rax_v38+FFFFFFF8+v638 @ rax_v34*8]");
			if (0 == (nint)typeof(Weapon))
			{
				obj9 = 1;
				goto IL_03c4;
			}
		}
		obj9 = 0;
		goto IL_03c4;
		IL_03c4:
		bool flag3 = obj9 == null;
		weapon = null;
		if (!flag3)
		{
			weapon = (Weapon)items[obj6];
		}
		goto IL_03b1;
		IL_03b1:
		SetWeaponVisible(weapon, active);
		if ((object)weapon != null && ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0)
		{
			bool flag4 = (byte)((active ? 1u : 0u) ^ 1u) != 0;
			weapon._003CShowAsDisabledOnEquipmentPanel_003Ek__BackingField = flag4;
		}
		goto IL_0172;
		IL_0172:
		return weapon;
		IL_0348:
		SetWeaponVisible(weapon, active);
		goto IL_0172;
		IL_035b:
		bool flag5 = obj4 == null;
		weapon = null;
		if (!flag5)
		{
			weapon = (Weapon)obj;
		}
		goto IL_0348;
	}

	public void SetMaxWeaponCount(int maxActives, int maxHidden)
	{
		//IL_0018: Expected O, but got I4
		//IL_0202: Expected O, but got I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected I4, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected I4, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected I4, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected I4, but got Unknown
		//IL_011f: Expected I, but got O
		//IL_012d: Expected I, but got O
		//IL_013d: Expected O, but got I
		//IL_01bd: Expected O, but got I4
		//IL_02f1: Expected I, but got O
		//IL_02ff: Expected I, but got O
		//IL_030f: Expected O, but got I
		//IL_0179: Expected O, but got I
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Expected O, but got Unknown
		//IL_03fd: Expected O, but got I4
		//IL_0412: Expected I, but got O
		//IL_038f: Expected O, but got I4
		//IL_034b: Expected O, but got I
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Expected O, but got Unknown
		//IL_0478: Expected O, but got I4
		//IL_0485: Expected I, but got O
		//IL_01af: Expected O, but got I4
		//IL_0381: Expected O, but got I4
		List<Equipment> list = base._003CActiveEquipment_003Ek__BackingField;
		_maxActiveCount = maxActives;
		_maxHiddenCount = maxHidden;
		bool flag = (nint)base._003CActiveEquipment_003Ek__BackingField < 0;
		object obj = list._size - 1;
		int num = maxHidden;
		bool flag2 = (byte)maxHidden != 0;
		IntPtr intPtr = default(IntPtr);
		nint num2 = intPtr;
		if (!flag)
		{
			Weapon weapon = default(Weapon);
			object obj7;
			do
			{
				bool flag3;
				if (maxActives == -1)
				{
					flag3 = true;
				}
				else
				{
					object obj2 = obj - maxActives;
					int num3 = obj ^ maxActives;
					object obj3 = obj ^ obj2;
					int num4 = num3 & obj3;
					bool flag4 = num4 < 0;
					bool flag5 = (nint)obj2 < 0;
					flag3 = flag5 != flag4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag6 = (nint)weapon < 0;
				Weapon weapon2;
				if ((object)weapon == null)
				{
					weapon2 = null;
					goto IL_03d6;
				}
				nint num5 = (nint)weapon;
				nint num6 = (nint)typeof(Weapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj6;
				if (num7 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rax_v24+FFFFFFF8+v330 @ rax_v20*8]");
					if (0 == (nint)typeof(Weapon))
					{
						obj6 = 1;
						goto IL_0420;
					}
				}
				obj6 = 0;
				goto IL_0420;
				IL_0420:
				flag6 = (nint)obj6 < 0;
				bool flag7 = obj6 == null;
				weapon2 = null;
				if (!flag7)
				{
					weapon2 = weapon;
				}
				goto IL_03d6;
				IL_03d6:
				SetWeaponVisible(weapon2, flag3);
				obj--;
				obj7 = !flag6;
				num = (flag3 ? 1 : 0);
				flag2 = flag3;
				num2 = unchecked((nint)null);
			}
			while (obj7 != null);
		}
		List<Equipment> list2 = base._003CHiddenEquipment_003Ek__BackingField;
		bool flag8 = (nint)base._003CHiddenEquipment_003Ek__BackingField < 0;
		object obj8 = list2._size - 1;
		if (flag8)
		{
			return;
		}
		Weapon weapon3 = default(Weapon);
		object obj14;
		do
		{
			bool flag9;
			if (maxHidden == -1)
			{
				flag9 = true;
			}
			else
			{
				object obj9 = obj8 - maxHidden;
				int num8 = obj8 ^ maxHidden;
				object obj10 = obj8 ^ obj9;
				int num9 = num8 & obj10;
				bool flag10 = num9 < 0;
				bool flag11 = (nint)obj9 < 0;
				flag9 = flag11 != flag10;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			bool flag12 = (nint)weapon3 < 0;
			Weapon weapon4;
			if ((object)weapon3 == null)
			{
				weapon4 = null;
				goto IL_0451;
			}
			nint num10 = (nint)weapon3;
			nint num11 = (nint)typeof(Weapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj13;
			if (num12 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v14+FFFFFFF8+v417 @ rax_v10*8]");
				if (0 == (nint)typeof(Weapon))
				{
					obj13 = 1;
					goto IL_0493;
				}
			}
			obj13 = 0;
			goto IL_0493;
			IL_0493:
			flag12 = (nint)obj13 < 0;
			bool flag13 = obj13 == null;
			weapon4 = null;
			if (!flag13)
			{
				weapon4 = weapon3;
			}
			goto IL_0451;
			IL_0451:
			SetWeaponVisible(weapon4, flag9);
			obj8--;
			obj14 = !flag12;
			flag2 = flag9;
			num2 = unchecked((nint)null);
		}
		while (obj14 != null);
	}

	private void SetWeaponVisible(Weapon weapon, bool visible)
	{
		if ((object)weapon == null || ((UnityEngine.Object)weapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (!visible)
		{
			if (~(weapon._isVisible ? 1u : 0u) == 0)
			{
				if (weapon._firingTimer != null)
				{
					weapon._firingTimer.Cancel();
				}
				if (weapon._firingAnimEvent != null)
				{
					weapon._firingAnimEvent.Cancel();
				}
				weapon.SetVisible(visible: false);
			}
		}
		else if (!weapon._isVisible)
		{
			weapon.ResetFiringTimer();
			weapon.SetVisible(visible: true);
		}
	}

	protected override void OnUpdate()
	{
		//IL_0038: Expected O, but got I4
		//IL_00fa: Expected O, but got I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_019c: Expected O, but got I4
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01cb: Expected O, but got I4
		if (PauseSystem._paused)
		{
			return;
		}
		List<Equipment> list = base._003CActiveEquipment_003Ek__BackingField;
		bool flag = (nint)base._003CActiveEquipment_003Ek__BackingField < 0;
		object obj = list._size - 1;
		bool flag3 = default(bool);
		bool flag2 = flag3;
		if (!flag)
		{
			IntPtr intPtr = default(IntPtr);
			object obj3;
			do
			{
				bool flag4;
				if (_maxActiveCount != -1)
				{
					object obj2 = _maxActiveCount - obj;
					flag4 = (nint)obj2 < 0;
					if (_maxActiveCount <= (nint)obj)
					{
						goto IL_0183;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				flag4 = (nint)intPtr < 0;
				flag2 = PauseSystem._paused;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v220 @ r8_v4 (System.Boolean)+228] (should have been resolved before IL gen)");
				goto IL_0183;
				IL_0183:
				obj--;
				obj3 = !flag4;
				flag3 = flag2;
			}
			while (obj3 != null);
		}
		List<Equipment> list2 = base._003CHiddenEquipment_003Ek__BackingField;
		bool flag5 = (nint)base._003CHiddenEquipment_003Ek__BackingField < 0;
		object obj4 = list2._size - 1;
		if (flag5)
		{
			return;
		}
		IntPtr intPtr2 = default(IntPtr);
		object obj6;
		do
		{
			bool flag6;
			if (_maxHiddenCount != -1)
			{
				object obj5 = _maxHiddenCount - obj4;
				flag6 = (nint)obj5 < 0;
				if (_maxHiddenCount <= (nint)obj4)
				{
					goto IL_01b2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			flag6 = (nint)intPtr2 < 0;
			flag3 = PauseSystem._paused;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v294 @ r8_v8 (System.Boolean)+228] (should have been resolved before IL gen)");
			goto IL_01b2;
			IL_01b2:
			obj4--;
			obj6 = !flag6;
		}
		while (obj6 != null);
	}

	public Weapon GetWeaponByType(WeaponType weaponType, bool searchHidden = false)
	{
		//IL_0012: Expected I, but got O
		//IL_0020: Expected I, but got O
		//IL_0030: Expected O, but got I
		//IL_00b0: Expected O, but got I4
		//IL_006c: Expected O, but got I
		//IL_00a2: Expected O, but got I4
		Weapon equipmentByType = (Weapon)GetEquipmentByType(weaponType, searchHidden);
		if ((object)equipmentByType == null)
		{
			return equipmentByType;
		}
		nint num = (nint)equipmentByType;
		nint num2 = (nint)typeof(Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v9+FFFFFFF8+v58 @ rax_v3*8]");
			if (0 == (nint)typeof(Weapon))
			{
				obj3 = 1;
				goto IL_00f4;
			}
		}
		obj3 = 0;
		goto IL_00f4;
		IL_00f4:
		bool flag = obj3 == null;
		Weapon result = null;
		if (!flag)
		{
			result = equipmentByType;
		}
		return result;
	}

	public Weapon GetWeaponByTypeFromAnyCollection(WeaponType weaponType)
	{
		//IL_00a0: Expected I, but got O
		//IL_00a8: Expected I, but got O
		//IL_00b8: Expected O, but got I
		//IL_00f4: Expected O, but got I
		//IL_01d9: Expected I, but got O
		//IL_01e7: Expected I, but got O
		//IL_01f7: Expected O, but got I
		//IL_0277: Expected O, but got I4
		//IL_0233: Expected O, but got I
		//IL_0269: Expected O, but got I4
		Equipment equipmentByType = GetEquipmentByType(weaponType);
		Equipment equipment;
		if ((object)equipmentByType != null)
		{
			bool flag = ((UnityEngine.Object)equipmentByType).m_CachedPtr != (IntPtr)0;
			equipment = equipmentByType;
			if (flag)
			{
				goto IL_0092;
			}
		}
		Equipment equipmentByType2 = GetEquipmentByType(weaponType, searchHidden: true);
		if ((object)equipmentByType2 != null)
		{
			bool flag2 = ((UnityEngine.Object)equipmentByType2).m_CachedPtr == (IntPtr)0;
			equipment = equipmentByType2;
			if (!flag2)
			{
				goto IL_0092;
			}
		}
		Equipment removedEquipment = GetRemovedEquipment(weaponType);
		if ((object)removedEquipment != null)
		{
			bool flag3 = ((UnityEngine.Object)removedEquipment).m_CachedPtr != (IntPtr)0;
			equipment = removedEquipment;
			if (flag3)
			{
				goto IL_0092;
			}
		}
		Weapon removedHiddenEquipment = (Weapon)GetRemovedHiddenEquipment(weaponType);
		if ((object)removedHiddenEquipment == null)
		{
			return removedHiddenEquipment;
		}
		nint num = (nint)removedHiddenEquipment;
		nint num2 = (nint)typeof(Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v37+FFFFFFF8+v534 @ rax_v31*8]");
			if (0 == (nint)typeof(Weapon))
			{
				obj3 = 1;
				goto IL_0311;
			}
		}
		obj3 = 0;
		goto IL_0311;
		IL_0092:
		nint num4 = (nint)typeof(Weapon);
		nint num5 = (nint)equipment;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v13+FFFFFFF8+v223 @ rax_v8*8]");
			if (0 == (nint)typeof(Weapon))
			{
				Weapon weapon = null;
				return (Weapon)equipment;
			}
		}
		return null;
		IL_0311:
		bool flag4 = obj3 == null;
		Weapon result = null;
		if (!flag4)
		{
			result = removedHiddenEquipment;
		}
		return result;
	}
}
