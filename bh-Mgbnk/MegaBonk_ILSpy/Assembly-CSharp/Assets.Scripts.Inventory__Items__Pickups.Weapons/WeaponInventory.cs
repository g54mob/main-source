using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public class WeaponInventory
{
	private bool isMaxed;

	private bool hasAimableWeapon;

	public Dictionary<EWeapon, WeaponBase> weapons;

	public static Action<WeaponBase> A_WeaponAdded;

	public static Action<WeaponBase> A_WeaponRemoved;

	public static Action<WeaponBase> A_WeaponToggled;

	public void AddWeapon(WeaponData weaponData, List<StatModifier> upgradeOffer)
	{
		if (!ChallengesTracker.HasChallengeModifier("no_weapons") && weaponData != null)
		{
			if (((Dictionary<System.Int32Enum, object>)(object)weapons).ContainsKey((System.Int32Enum)weaponData.eWeapon))
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)weaponData.eWeapon);
				((WeaponBase)obj).Upgrade(upgradeOffer);
				IntPtr intPtr = default(IntPtr);
				nint num = intPtr;
			}
			else
			{
				WeaponData weapon = DataManager.Instance.GetWeapon(weaponData.eWeapon);
				WeaponBase value = new WeaponBase(weapon);
				((Dictionary<System.Int32Enum, object>)(object)weapons).Add((System.Int32Enum)weaponData.eWeapon, (object)value);
				nint num = 0;
			}
			CheckMaxed();
			if (weaponData.hasCrosshair)
			{
				hasAimableWeapon = true;
			}
			Action<WeaponBase> a_WeaponAdded = A_WeaponAdded;
			if (A_WeaponAdded != null)
			{
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)weaponData.eWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v116 @ rbx_v6 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponBase>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public void ToggleWeapon(EWeapon eWeapon, bool enable)
	{
		if (((Dictionary<System.Int32Enum, object>)(object)weapons).ContainsKey((System.Int32Enum)eWeapon))
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)eWeapon);
			if (enable)
			{
				_ = 1;
			}
			Action<WeaponBase> a_WeaponToggled = A_WeaponToggled;
			if (A_WeaponToggled != null)
			{
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)eWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ rdi_v5 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponBase>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void RemoveWeapon()
	{
	}

	public void Tick()
	{
		Dictionary<EWeapon, WeaponBase>.ValueCollection values = weapons.Values;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
		Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator enumerator = default(Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator);
		WeaponBase weaponBase = default(WeaponBase);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (weaponBase == null)
				{
					break;
				}
				if (weaponBase._003Cenabled_003Ek__BackingField)
				{
					float weaponCooldown = WeaponUtility.GetWeaponCooldown(weaponBase);
					float num = weaponBase.usedWeaponAtTime + weaponCooldown;
					if (num < MyTime.time)
					{
						WeaponUtility.WeaponAttack(weaponBase);
						weaponBase.usedWeaponAtTime = MyTime.time;
					}
				}
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return;
		}
		throw new NullReferenceException();
	}

	public int GetNumWeapons()
	{
		//IL_0027: Expected I4, but got O
		if (weapons != null)
		{
			return weapons.Count;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetWeaponLevel(EWeapon eWeapon)
	{
		//IL_0096: Expected I4, but got O
		if (weapons != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)weapons).ContainsKey((System.Int32Enum)eWeapon))
			{
				return 0;
			}
			if (weapons != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)eWeapon);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v5 (System.Object)+20]");
					return 0;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private void CheckMaxed()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
		Dictionary<EWeapon, WeaponBase>.Enumerator enumerator = default(Dictionary<EWeapon, WeaponBase>.Enumerator);
		EWeapon eWeapon = default(EWeapon);
		bool flag;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (!IsMaxLevel(eWeapon))
				{
					enumerator.Dispose();
					flag = false;
					break;
				}
				continue;
			}
			enumerator.Dispose();
			flag = true;
			break;
		}
		isMaxed = flag;
	}

	private bool IsMaxLevel(EWeapon eWeapon)
	{
		//IL_019a: Expected I4, but got O
		//IL_0105: Expected O, but got I
		//IL_011e: Expected O, but got I
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected I4, but got Unknown
		if (weapons != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)weapons).ContainsKey((System.Int32Enum)eWeapon))
			{
				return false;
			}
			if (weapons != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)eWeapon);
				if (obj != null && weapons != null)
				{
					object obj2 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)eWeapon);
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v7 (System.Object)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v7 (System.Object)+18]");
							int maxLevel = ((WeaponData)0).GetMaxLevel();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v6 (System.Object)+20]");
							object obj3 = -maxLevel;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v6 (System.Object)+20]");
							int num = (int)((nint)0 ^ (nint)maxLevel);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v6 (System.Object)+20]");
							object obj4 = 0 ^ obj3;
							int num2 = num & obj4;
							bool flag = num2 < 0;
							bool flag2 = (nint)obj3 < 0;
							return flag2 == flag;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsMaxed()
	{
		if (weapons != null)
		{
			int count = weapons.Count;
			int numAvailableWeaponSlots = InventoryUtility.GetNumAvailableWeaponSlots();
			if (count < numAvailableWeaponSlots)
			{
				return false;
			}
			bool flag = weapons == null;
			Dictionary<EWeapon, WeaponBase> dictionary = null;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
				Dictionary<EWeapon, WeaponBase>.Enumerator enumerator = default(Dictionary<EWeapon, WeaponBase>.Enumerator);
				EWeapon eWeapon = default(EWeapon);
				bool result;
				while (true)
				{
					if (enumerator.MoveNext())
					{
						if (!IsMaxLevel(eWeapon))
						{
							enumerator.Dispose();
							result = false;
							break;
						}
						continue;
					}
					enumerator.Dispose();
					result = true;
					break;
				}
				return result;
			}
		}
		throw new NullReferenceException();
	}

	public bool HasAimableWeapon()
	{
		return hasAimableWeapon;
	}

	public void Cleanup()
	{
		//IL_007a: Expected O, but got I
		Dictionary<EWeapon, WeaponBase>.ValueCollection values = weapons.Values;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
		Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator enumerator = default(Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ stack_-30+38]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ stack_-30+38]");
					object obj2 = 0;
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ rax_v11+188] (should have been resolved before IL gen)");
				}
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return;
		}
		throw new NullReferenceException();
	}

	public WeaponInventory()
	{
		Dictionary<EWeapon, WeaponBase> dictionary = new Dictionary<EWeapon, WeaponBase>();
		weapons = dictionary;
		RemoveWeapon();
	}
}
