using System;
using Coherence;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnRevive_TimeFreeze : CharacterSkillCard_Base
{
	public SubSkillCard_OnRevive_TimeFreeze(ArcanaType type)
		: base(type)
	{
	}

	public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
	{
		//IL_004a: Expected I8, but got O
		base.OnOwnerRevived(percentage, instantRevival);
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			TimeStop();
			return;
		}
		CharacterController linkedCharacter = LinkedCharacter;
		Action<long> action = null;
		((SubSkillCard_OnRevive_TimeFreeze)(object)action).TriggerTimeStop((long)this);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		bool flag = linkedCharacter._coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void TriggerTimeStop(long startingSimFrame)
	{
		Action onSyncedTimer = TimeStop;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void TimeStop()
	{
		//IL_005c: Expected I, but got O
		//IL_006a: Expected I, but got O
		//IL_007a: Expected O, but got I
		//IL_00fa: Expected O, but got I4
		//IL_00b6: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_0160: Expected O, but got I4
		CharacterController linkedCharacter = LinkedCharacter;
		Weapon weaponByType = linkedCharacter._weaponsManager.GetWeaponByType(WeaponType.ICELANCE2);
		GlassFandango2Weapon glassFandango2Weapon;
		bool flag;
		if ((object)weaponByType == null)
		{
			flag = false;
			glassFandango2Weapon = null;
			goto IL_01c1;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(GlassFandango2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandango2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandango2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v25+FFFFFFF8+v170 @ rax_v21*8]");
			if (0 == (nint)typeof(GlassFandango2Weapon))
			{
				obj3 = 1;
				goto IL_0192;
			}
		}
		obj3 = 0;
		goto IL_0192;
		IL_0192:
		bool flag2 = obj3 == null;
		flag = (byte)num != 0;
		glassFandango2Weapon = null;
		if (!flag2)
		{
			flag = (byte)num != 0;
			glassFandango2Weapon = (GlassFandango2Weapon)weaponByType;
		}
		goto IL_01c1;
		IL_01c1:
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
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD650");
	}
}
