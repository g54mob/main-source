using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class C1_Crewmate : CharacterController
{
	private List<WeaponType> _addedBonuses;

	private Dictionary<WeaponType, float> _powerUpBonusList;

	private Dictionary<WeaponType, float> _weaponBonusList;

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		List<WeaponType> addedBonuses = new List<WeaponType>();
		_addedBonuses = addedBonuses;
		Dictionary<WeaponType, float> dictionary = new Dictionary<WeaponType, float>();
		bool flag = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)65, 0.1f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)57, 0.2f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)56, 20f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)58, 0.08f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag5 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)53, -0.03f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag6 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)55, 0.2f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag7 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)63, 0.2f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag8 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)59, 0.5f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag9 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)61, 0.05f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag10 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)60, 0.05f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_powerUpBonusList = dictionary;
		Dictionary<WeaponType, float> dictionary2 = new Dictionary<WeaponType, float>();
		bool flag11 = ((Dictionary<System.Int32Enum, float>)(object)dictionary2).TryInsert((System.Int32Enum)50, 0.04f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag12 = ((Dictionary<System.Int32Enum, float>)(object)dictionary2).TryInsert((System.Int32Enum)52, 0.04f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag13 = ((Dictionary<System.Int32Enum, float>)(object)dictionary2).TryInsert((System.Int32Enum)54, 0.04f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag14 = ((Dictionary<System.Int32Enum, float>)(object)dictionary2).TryInsert((System.Int32Enum)51, 0.04f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_weaponBonusList = dictionary2;
	}

	public unsafe override void OnLevelUpCompleted()
	{
		//IL_00a6: Expected O, but got I
		//IL_00dc: Expected O, but got I4
		//IL_00e4: Expected O, but got Ref
		if (_PlayerIndex >> 31 != 0 && _deficiencyControl != null)
		{
			_deficiencyControl.HandleOnLevelUpCompleted();
		}
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v28 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v28 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v28 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj2 = 0;
			List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void HandleEquipment(Equipment equipment)
	{
		//IL_012e: Expected F4, but got I4
		//IL_0137: Expected O, but got I4
		//IL_03be: Expected I4, but got O
		//IL_0171: Expected O, but got I
		//IL_018c: Expected F4, but got I4
		//IL_0195: Expected O, but got I4
		//IL_0265: Expected O, but got I
		//IL_027f: Expected I4, but got O
		//IL_01f7: Expected I4, but got O
		//IL_02e1: Expected I4, but got O
		//IL_031e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		GameManager core = GM.Core;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = core._dataManager.GetConvertedWeapons();
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)equipment._equipmentType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v9 (System.Object)+18]");
		if ((nint)0 == 1)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = core2._dataManager.GetConvertedWeapons();
		object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)equipment._equipmentType);
		int num = equipment._003CLevel_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v13 (System.Object)+18]");
		if ((nint)num != 0)
		{
			return;
		}
		List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)(object)_addedBonuses).get_Item(equipment._equipmentType);
		bool flag = equipment.IsPowerup();
		float bonusValue = 0f;
		KeyValuePair<System.Int32Enum, float> keyValuePair = (KeyValuePair<System.Int32Enum, float>)0;
		object obj5 = default(object);
		if (!flag)
		{
			Dictionary<WeaponType, float> weaponBonusList = _weaponBonusList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Single>)+20]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Single>)+28]");
			object obj4 = num2 - 0;
			bool flag2 = (nint)obj4 <= 0;
			bonusValue = 0f;
			keyValuePair = (KeyValuePair<System.Int32Enum, float>)0;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Single>)+20]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Single>)+28]");
				int maxExclusive = (int)(num3 - 0);
				int index = UnityEngine.Random.Range(0, maxExclusive);
				KeyValuePair<System.Int32Enum, float> keyValuePair2 = Enumerable.ElementAt((IEnumerable<KeyValuePair<System.Int32Enum, float>>)weaponBonusList, index);
				int num4 = _weaponBonusList.FindEntry((WeaponType)keyValuePair2);
				if (num4 < 0)
				{
					return;
				}
				bonusValue = (float)equipment._003CLevel_003Ek__BackingField * (float)obj5;
				keyValuePair = keyValuePair2;
			}
		}
		bool flag3 = equipment.IsPowerup();
		bool flag4 = !flag3;
		int num5 = (int)keyValuePair;
		if (!flag4)
		{
			Dictionary<WeaponType, float> powerUpBonusList = _powerUpBonusList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Single>)+20]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Single>)+28]");
			object obj6 = num6 - 0;
			bool flag5 = (nint)obj6 <= 0;
			num5 = (int)keyValuePair;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Single>)+20]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Single>)+28]");
				int maxExclusive2 = (int)(num7 - 0);
				int index2 = UnityEngine.Random.Range(0, maxExclusive2);
				KeyValuePair<System.Int32Enum, float> keyValuePair3 = Enumerable.ElementAt((IEnumerable<KeyValuePair<System.Int32Enum, float>>)powerUpBonusList, index2);
				int num8 = _powerUpBonusList.FindEntry((WeaponType)keyValuePair3);
				if (num8 < 0)
				{
					return;
				}
				bonusValue = (float)equipment._003CLevel_003Ek__BackingField * (float)obj5;
				num5 = (int)keyValuePair3;
			}
		}
		if (num5 != 0)
		{
			GameManager core3 = GM.Core;
			if (!core3._multiplayer.IsOnlineMultiplayer)
			{
				AddValue(num5, bonusValue);
				return;
			}
			Action<int, float> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809BFB60");
			float param = default(float);
			bool flag6 = _coherenceSync.SendCommand(action, MessageTarget.All, num5, param);
		}
	}

	public unsafe void AddValue(int bonus, float bonusValue)
	{
		//IL_0064: Expected O, but got Ref
		AddValueToAttribute(this, (WeaponType)bonus, bonusValue);
		GameManager core = GM.Core;
		core._gizmoManager.DisplayLevelUp(this);
		GameManager core2 = GM.Core;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string value = System.Number.FormatSingle(bonusValue, null, currentInfo);
		object obj = default(object);
		CharacterController character = default(CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		core2._gizmoManager.DisplayWeaponIconOverhead((WeaponType)bonus, value, (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
	}
}
