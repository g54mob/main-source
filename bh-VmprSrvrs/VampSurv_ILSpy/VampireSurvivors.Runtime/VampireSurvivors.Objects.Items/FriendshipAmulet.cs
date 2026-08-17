using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class FriendshipAmulet : NetworkPickup
{
	private static List<Equipment> s_equipmentCache;

	private LevelUpFactory _levelUpFactory;

	private CoherenceSync _sync;

	private void GetLevelUpFactory(LevelUpFactory levelUpFactory)
	{
		_levelUpFactory = levelUpFactory;
	}

	protected override void Awake()
	{
		base.Awake();
		CoherenceSync component = GetComponent<CoherenceSync>();
		_sync = component;
	}

	public override void GetTaken()
	{
		//IL_0015: Expected O, but got I
		//IL_004b: Expected O, but got I
		//IL_00e7: Expected I4, but got O
		base.SetHasSeenItem();
		MultiplayerManager core = (MultiplayerManager)(object)GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v5 (VampireSurvivors.Framework.MultiplayerManager)+168]");
			core = (MultiplayerManager)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v5 (VampireSurvivors.Framework.MultiplayerManager)+168]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v5 (VampireSurvivors.Framework.MultiplayerManager)+168]");
				if (!((MultiplayerManager)0).IsOnlineMultiplayer)
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._characters != null)
					{
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						while (enumerator.MoveNext())
						{
							WeaponType? randomWeaponToLevelUp = GetRandomWeaponToLevelUp(null);
							if ((object)randomWeaponToLevelUp != null)
							{
								WeaponType weaponType = (WeaponType)((object?)randomWeaponToLevelUp >> 32);
								ApplyFriendshipAmuletLevelUp(weaponType, null);
							}
						}
						goto IL_0152;
					}
				}
				else if ((object)_sync != null)
				{
					if (_sync.HasStateAuthority)
					{
						SendOnlineLevelUps();
					}
					goto IL_0152;
				}
			}
		}
		throw new NullReferenceException();
		IL_0152:
		if (!_taken)
		{
			((Pickup)this).GetTaken();
			_taken = true;
		}
	}

	public unsafe static void ApplyFriendshipAmuletLevelUp(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_008d: Expected O, but got Ref
		GM.Core.LevelWeaponUp(weaponType, removeFromStore: true, player);
		GameManager core = GM.Core;
		core._gizmoManager.DisplayWeaponLevelup(player);
		GameManager core2 = GM.Core;
		Color coopColour = player.GetCoopColour();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj = default(object);
		VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		core2._gizmoManager.DisplayWeaponIconOverhead(weaponType, "1", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
	}

	public static WeaponType? GetRandomWeaponToLevelUp(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_009d: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_0330: Expected O, but got I4
		//IL_0339: Expected O, but got I4
		//IL_04b7: Expected O, but got I4
		//IL_04ca: Expected O, but got I4
		//IL_03bb: Expected I4, but got O
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected O, but got Unknown
		//IL_0293: Expected O, but got I
		//IL_02ce: Expected O, but got I4
		List<Equipment> list = s_equipmentCache;
		int num = list._size;
		int version = list._version + 1;
		list._version = version;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
		GameManager core = GM.Core;
		object obj = 0;
		object obj2 = 0;
		WeaponType key = default(WeaponType);
		while (true)
		{
			CharacterWeaponsManager weaponsManager = player._weaponsManager;
			List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
			if ((nint)obj2 >= list2._size)
			{
				break;
			}
			if (!player._isDead && !player.IsDisconnectedFromOnlinePlay)
			{
				CharacterWeaponsManager weaponsManager2 = player._weaponsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				LevelUpFactory levelUpFactory = core._levelUpFactory;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v48 (VampireSurvivors.Data.WeaponType)+48]");
				bool flag = levelUpFactory.IsBanished(WeaponType.VOID);
				num = 0;
				if (!flag)
				{
					Dictionary<WeaponType, List<WeaponData>> convertedWeapons = core._dataManager.GetConvertedWeapons();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v48 (VampireSurvivors.Data.WeaponType)+48]");
					object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v48 (VampireSurvivors.Data.WeaponType)+4C]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v51 (System.Object)+18]");
					bool flag2 = num2 >= 0;
					num = 0;
					if (!flag2)
					{
						List<WeaponData> list3 = ((Dictionary<WeaponType, List<WeaponData>>)(object)s_equipmentCache).get_Item(key);
						bool flag3 = obj != null;
						num = 0;
						if (!flag3)
						{
							Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
							object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)player._characterType);
							List<CharacterData> list4 = ((Dictionary<CharacterType, List<CharacterData>>)obj4).get_Item(player._characterType);
							int num3 = list4._version >> 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v48 (VampireSurvivors.Data.WeaponType)+48]");
							object obj5 = (nint)num3 - (nint)0;
							bool flag4 = obj5 == null;
							int num4 = list4._version & (flag4 ? 1 : 0);
							bool flag5 = num4 == 0;
							object obj6 = !flag5;
							num = 0;
							if (obj6 != null)
							{
								break;
							}
						}
					}
				}
			}
			obj++;
			obj2 = obj;
		}
		List<Equipment> list5 = s_equipmentCache;
		if (list5._size == 0)
		{
			object obj7 = 0;
			object obj8 = 0;
			WeaponType? result = default(WeaponType?);
			while (true)
			{
				CharacterAccessoriesManager accessoriesManager = player._accessoriesManager;
				List<Equipment> list6 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
				if ((nint)obj8 >= list6._size)
				{
					break;
				}
				if ((nint)obj7 < list6._size)
				{
					Equipment[] items = list6._items;
					WeaponType key2 = (WeaponType)items[obj7];
					LevelUpFactory levelUpFactory2 = core._levelUpFactory;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rsi_v10 (VampireSurvivors.Data.WeaponType)+48]");
					if (!levelUpFactory2.IsBanished(WeaponType.VOID))
					{
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = core._dataManager.GetConvertedWeapons();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rsi_v10 (VampireSurvivors.Data.WeaponType)+48]");
						object obj9 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rsi_v10 (VampireSurvivors.Data.WeaponType)+4C]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v36 (System.Object)+18]");
						if (num5 < 0)
						{
							List<WeaponData> list7 = ((Dictionary<WeaponType, List<WeaponData>>)(object)s_equipmentCache).get_Item(key2);
						}
					}
					obj7++;
					obj8 = obj7;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		List<Equipment> list8 = s_equipmentCache;
		if (list8._size <= 0)
		{
			return (WeaponType?)(object)0;
		}
		Equipment equipment = Extensions.PickRnd(s_equipmentCache);
		return (WeaponType?)(object)1;
	}

	private void SendOnlineLevelUps()
	{
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		OnlineStageManager onlineStageManager = default(OnlineStageManager);
		WeaponType weaponType = default(WeaponType);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			WeaponType? randomWeaponToLevelUp = GetRandomWeaponToLevelUp(null);
			if ((object)randomWeaponToLevelUp != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				if ((object)onlineStageManager == null)
				{
					break;
				}
				onlineStageManager.SendFriendshipAmuletLevelUpWeaponForCharacter(weaponType, null);
				characters = null;
			}
		}
		throw new NullReferenceException();
	}

	static FriendshipAmulet()
	{
		List<Equipment> list = new List<Equipment>();
		s_equipmentCache = list;
	}
}
