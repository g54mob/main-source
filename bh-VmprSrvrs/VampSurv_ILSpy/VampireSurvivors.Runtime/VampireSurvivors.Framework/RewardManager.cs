using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework;

public class RewardManager
{
	private DataManager _data;

	private PlayerOptions _playerOptions;

	private GameSessionData _session;

	private SignalBus _signalBus;

	private Dictionary<WeaponType, List<WeaponData>> _weapons;

	private readonly List<WeaponType> _ownedWeapons;

	private readonly List<WeaponType> _ownedAccessories;

	private readonly List<WeaponType> _availableWeapons;

	private readonly List<WeaponType> _availableAccessories;

	public List<Reward> GetLevelUpRewards(int amount)
	{
		//IL_05da: Expected O, but got I
		//IL_009a: Expected O, but got I
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_0320: Expected O, but got I
		//IL_0379: Expected O, but got I
		//IL_0398: Expected O, but got I
		//IL_052c: Expected O, but got I4
		//IL_0502: Expected O, but got I
		//IL_0502: Expected O, but got I
		//IL_0543->IL06ab: Incompatible stack heights: 3 vs 0
		//IL_054d->IL02b2: Incompatible stack heights: 3 vs 0
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		_weapons = convertedWeapons;
		PlayerOptionsData config = _playerOptions.Config;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-80_v17+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-80_v17+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-80_v17+10]");
						object obj5 = 0;
						obj4++;
						Dictionary<WeaponType, List<WeaponData>> weapons = _weapons;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdx_v57+20+v1189 @ rcx_v93*4]");
						object obj6 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v130 (System.Object)+18]");
						if ((nint)0 > (nint)0)
						{
							continue;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						throw new NullReferenceException();
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		PlayerOptions playerOptions = (PlayerOptions)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-80_v17+1C]");
			if (obj2 == null)
			{
				List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
				while (enumerator.MoveNext())
				{
				}
				GameSessionData session = _session;
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = session._activeCharacter;
				CharacterAccessoriesManager accessoriesManager = activeCharacter._accessoriesManager;
				List<Equipment>.Enumerator enumerator2 = default(List<Equipment>.Enumerator);
				while (enumerator2.MoveNext())
				{
				}
				List<WeaponType> list = new List<WeaponType>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)_availableWeapons);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)_ownedWeapons);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)_ownedAccessories);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)_availableAccessories);
				List<Reward> list2 = new List<Reward>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)0 <= (nint)0)
				{
					Reward reward = null;
					reward.Data = null;
					reward.Weapon = WeaponType.VOID;
					reward.IsFood = true;
					reward.Value = 30;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4B00");
					Reward reward2 = null;
					reward2.Data = null;
					reward2.Weapon = WeaponType.VOID;
					reward2.IsFood = false;
					reward2.Value = 25;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4B00");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					bool flag2 = (nint)0 > (nint)amount;
					int num = amount;
					int num2 = amount;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						num = 0;
					}
					if (num2 > 0)
					{
						int length = default(int);
						WeaponData weaponData;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							int num3 = UnityEngine.Random.RandomRangeInt(0, 0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							bool flag3 = (nint)num3 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
							object obj7 = 0;
							Dictionary<WeaponType, List<WeaponData>> weapons2 = _weapons;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v52+20+v172 @ rax_v80 (System.Int32)*4]");
							object obj8 = ((Dictionary<System.Int32Enum, object>)(object)weapons2).get_Item((System.Int32Enum)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v81 (System.Object)+18]");
							bool flag4 = (nint)0 <= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v81 (System.Object)+10]");
							object obj9 = 0;
							Reward reward3 = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v20+20]");
							reward3.Data = (WeaponData)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v52+20+v172 @ rax_v80 (System.Int32)*4]");
							reward3.Weapon = WeaponType.VOID;
							reward3.IsFood = false;
							reward3.Value = 0;
							int version = list2._version + 1;
							list2._version = version;
							Reward[] items = list2._items;
							if (list2._size >= items.Length)
							{
								((List<object>)(object)list2).AddWithResize((object)reward3);
							}
							else
							{
								int size = list2._size + 1;
								list2._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							bool flag5 = (nint)num3 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							_ = -1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							if ((nint)num3 < (nint)0)
							{
								int sourceIndex = num3 + 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								Array.Copy((Array)num4, sourceIndex, (Array)0, num3, length);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
							_ = (nint)0 + (nint)1;
							weaponData = (WeaponData)(0 + 1);
						}
						while ((nint)weaponData < num);
					}
				}
				return list2;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			playerOptions = null;
		}
		throw new NullReferenceException();
	}

	public RewardManager()
	{
		Dictionary<WeaponType, List<WeaponData>> weapons = new Dictionary<WeaponType, List<WeaponData>>();
		_weapons = weapons;
		List<WeaponType> ownedWeapons = new List<WeaponType>();
		_ownedWeapons = ownedWeapons;
		List<WeaponType> ownedAccessories = new List<WeaponType>();
		_ownedAccessories = ownedAccessories;
		List<WeaponType> availableWeapons = new List<WeaponType>();
		_availableWeapons = availableWeapons;
		List<WeaponType> availableAccessories = new List<WeaponType>();
		_availableAccessories = availableAccessories;
	}
}
