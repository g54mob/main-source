using System;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerSheMoonIta : CharacterController
{
	protected override void OnStop()
	{
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		base._isCriticalHPEnabled = true;
		Action onCriticalHP = CriticalHP;
		base._onCriticalHP = onCriticalHP;
	}

	private void CriticalHP()
	{
		//IL_023a: Expected I8, but got O
		//IL_006f: Expected O, but got I
		//IL_0112: Expected I, but got O
		//IL_0120: Expected I, but got O
		//IL_0130: Expected O, but got I
		//IL_01b0: Expected O, but got I4
		//IL_016c: Expected O, but got I
		//IL_01a2: Expected O, but got I4
		//IL_031b: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_0216: Expected O, but got I4
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v34 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v34 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v34 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		GameManager core = GM.Core;
		Weapon weaponByType;
		GlassFandango2Weapon glassFandango2Weapon;
		nint num;
		object obj4;
		bool flag3;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.ICELANCE2);
			if ((object)weaponByType == null)
			{
				glassFandango2Weapon = null;
				flag3 = false;
				goto IL_0303;
			}
			num = (nint)weaponByType;
			nint num2 = (nint)typeof(GlassFandango2Weapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandango2Weapon>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandango2Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rax_v38+FFFFFFF8+v400 @ rax_v34*8]");
				if (0 == (nint)typeof(GlassFandango2Weapon))
				{
					obj4 = 1;
					goto IL_02d4;
				}
			}
			obj4 = 0;
			goto IL_02d4;
		}
		Action<long> action = null;
		((CharacterControllerSheMoonIta)(object)action).TriggerTimeStop((long)this);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		bool flag4 = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		return;
		IL_0303:
		bool flag5 = (object)glassFandango2Weapon == null;
		object obj5 = 0;
		if (!flag5)
		{
			bool flag6 = ((UnityEngine.Object)glassFandango2Weapon).m_CachedPtr == (IntPtr)0;
			obj5 = 0;
			if (!flag6)
			{
				glassFandango2Weapon.StartStarryHeavens();
				obj5 = 1;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD650");
		return;
		IL_02d4:
		bool flag7 = obj4 == null;
		glassFandango2Weapon = null;
		flag3 = (byte)num != 0;
		if (!flag7)
		{
			glassFandango2Weapon = (GlassFandango2Weapon)weaponByType;
			flag3 = (byte)num != 0;
		}
		goto IL_0303;
	}

	public void TriggerTimeStop(long startingSimFrame)
	{
		Action onSyncedTimer = TimeStop;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void TimeStop()
	{
		//IL_0059: Expected I, but got O
		//IL_0067: Expected I, but got O
		//IL_0077: Expected O, but got I
		//IL_00f7: Expected O, but got I4
		//IL_00b3: Expected O, but got I
		//IL_00e9: Expected O, but got I4
		//IL_01b9: Expected O, but got I4
		//IL_013d: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.ICELANCE2);
		GlassFandango2Weapon glassFandango2Weapon;
		bool flag;
		if ((object)weaponByType == null)
		{
			glassFandango2Weapon = null;
			flag = false;
			goto IL_01a1;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(GlassFandango2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandango2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandango2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v23+FFFFFFF8+v122 @ rax_v19*8]");
			if (0 == (nint)typeof(GlassFandango2Weapon))
			{
				obj3 = 1;
				goto IL_0172;
			}
		}
		obj3 = 0;
		goto IL_0172;
		IL_0172:
		bool flag2 = obj3 == null;
		glassFandango2Weapon = null;
		flag = (byte)num != 0;
		if (!flag2)
		{
			glassFandango2Weapon = (GlassFandango2Weapon)weaponByType;
			flag = (byte)num != 0;
		}
		goto IL_01a1;
		IL_01a1:
		bool flag3 = (object)glassFandango2Weapon == null;
		object obj4 = 0;
		if (!flag3)
		{
			bool flag4 = ((UnityEngine.Object)glassFandango2Weapon).m_CachedPtr == (IntPtr)0;
			obj4 = 0;
			if (!flag4)
			{
				glassFandango2Weapon.StartStarryHeavens();
				obj4 = 1;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD650");
	}
}
