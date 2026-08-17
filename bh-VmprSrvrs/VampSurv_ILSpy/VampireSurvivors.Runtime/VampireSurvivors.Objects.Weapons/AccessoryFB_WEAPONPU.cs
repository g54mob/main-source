using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class AccessoryFB_WEAPONPU : Accessory
{
	public override void OnAccessoryAddedToEquipment()
	{
		CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		int maxAccessoryBonus = characterController._maxAccessoryBonus + 1;
		characterController._maxAccessoryBonus = maxAccessoryBonus;
	}

	public override void OnAccessoryRemovedFromEquipment()
	{
		CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		int maxAccessoryBonus = characterController._maxAccessoryBonus - 1;
		characterController._maxAccessoryBonus = maxAccessoryBonus;
	}

	protected override void MakeLevelOne()
	{
		updateWeapon();
		base.MakeLevelOne();
	}

	public override bool LevelUp(bool skipFire = false)
	{
		updateWeapon();
		return base.LevelUp(false);
	}

	private void updateWeapon()
	{
		//IL_00bf: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_0081: Expected O, but got I
		//IL_017d: Expected I4, but got O
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected O, but got Unknown
		//IL_02b9: Expected O, but got I
		//IL_02f4: Expected O, but got I4
		CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CoherenceSync coherenceSync = characterController._coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v41 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v41 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v41 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		List<Equipment> list = new List<Equipment>();
		CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		object obj2 = 0;
		object obj3 = 0;
		int param = default(int);
		while (true)
		{
			CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
			List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
			if ((nint)obj2 < list2._size)
			{
				CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
				CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
				List<Equipment> list3 = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField;
				if ((nint)obj3 >= list3._size)
				{
					break;
				}
				Equipment[] items = list3._items;
				WeaponType key = (WeaponType)items[obj3];
				LevelUpFactory levelUpFactory = _levelUpFactory;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rsi_v10 (VampireSurvivors.Data.WeaponType)+48]");
				if (levelUpFactory.IsBanished(WeaponType.VOID))
				{
					goto IL_0302;
				}
				Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rsi_v10 (VampireSurvivors.Data.WeaponType)+48]");
				object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rsi_v10 (VampireSurvivors.Data.WeaponType)+4C]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v43 (System.Object)+18]");
				if (num >= 0)
				{
					goto IL_0302;
				}
				List<WeaponData> list4 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item(key);
				if (obj3 != null)
				{
					goto IL_0302;
				}
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
				CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController4._characterType);
				List<CharacterData> list5 = ((Dictionary<CharacterType, List<CharacterData>>)obj5).get_Item(characterController4._characterType);
				int num2 = list5._version >> 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rsi_v10 (VampireSurvivors.Data.WeaponType)+48]");
				object obj6 = (nint)num2 - (nint)0;
				bool flag3 = obj6 == null;
				int num3 = list5._version & (flag3 ? 1 : 0);
				bool flag4 = num3 == 0;
				object obj7 = !flag4;
				if (obj7 == null)
				{
					goto IL_0302;
				}
			}
			if (list._size > 0)
			{
				Equipment equipment = Extensions.PickRnd(list);
				CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
				GameManager core = GM.Core;
				if (!core._multiplayer.IsOnlineMultiplayer)
				{
					((Equipment)this)._003COwner_003Ek__BackingField.ApplyWeaponLevelUp(equipment._equipmentType);
					return;
				}
				Action<long, int> action = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
				long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
				bool flag5 = characterController5._coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
			}
			return;
			IL_0302:
			characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			obj3++;
			obj2 = obj3;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
