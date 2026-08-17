using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages;

public class Background3 : BackgroundManager
{
	private int _bossesDefeated;

	private bool _awarded;

	private const int BOSSES_TO_DEFEAT = 7;

	public override void Awake()
	{
		base.Awake();
	}

	public override void Create()
	{
		base.Create();
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 != -1)
		{
			_bossesDefeated = 0;
			_awarded = false;
			if (!GM.Core.IsStageHost && NetworkItems.IsNetworkItem(ItemType.ROAST))
			{
				throw new NullReferenceException();
			}
			Vector2 pos = default(Vector2);
			Pickup pickup = PickupManager.CreatePickup(pos, ItemType.ROAST);
			pickup.SetFrame("cheese");
			Action<Pickup> pickupCallback = OnPickupCallback;
			pickup.PickupCallback = pickupCallback;
		}
	}

	private void OnPickupCallback(Pickup item)
	{
		//IL_00a6->IL0060: Incompatible stack heights: 1 vs 0
		if ((object)item != null)
		{
			item._003CPickupCallback_003Ek__BackingField = null;
			Transform transform = item.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 154 Invalid \"Jump target not found in method: 0x186ECBC90\"");
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SpawnWerewolves(Vector2 pos)
	{
		//IL_016a: Expected O, but got I4
		//IL_0181: Expected I, but got O
		//IL_0197: Expected O, but got I
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_00e3: Expected I, but got O
		//IL_01e2: Expected I, but got I8
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_00cc: Expected I, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background3)+40]");
		float num = 0f * 2f;
		object obj = 0;
		Background3 background = this;
		object obj2 = default(object);
		Vector2 spawnPos = default(Vector2);
		bool forceSpawn = default(bool);
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num2 = 0.5f * 0.8975979f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num3 = 0.5f * 0.8975979f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num4 = num3 * num;
			float num5 = num4 * 0.5f;
			GameManager core = GM.Core;
			float num6 = (float)obj2 - num5;
			GameObject gameObject = core._stage.SpawnEnemy(EnemyType.BOSS_WEREWOLF2, spawnPos, asRemote: false, forceSpawn);
			EnemyOnDefeat component = gameObject.GetComponent<EnemyOnDefeat>();
			Action action = null;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(Background3.OnDefeated);
			((Delegate)action).m_target = this;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num8;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num8 = unchecked((nint)6447293664L);
					goto IL_01c2;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num8 = ((Delegate)action).method_ptr;
			goto IL_01c2;
			IL_01c2:
			nint num9 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			component._003COnDefeat_003Ek__BackingField = action;
			background = (Background3)(object)action;
			obj++;
			((EnemyController)component)._003CIsTeleportOnCull_003Ek__BackingField = true;
		}
		while ((nint)obj < 7);
	}

	private void OnDefeated()
	{
		//IL_00f5: Expected O, but got I8
		//IL_009d: Expected O, but got I
		if (++_bossesDefeated >= 7 && !_awarded)
		{
			_awarded = true;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				AwardGRAZIELLAUnlock();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
			Action<long> action = null;
			long num = default(long);
			((OnlineStageManager)(object)action).Background3GRAZIELLAUnlock(num);
			long startingOnlineClientFrame = ((OnlineStageManager)num).GetStartingOnlineClientFrame();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v10 (System.Int64)+78]");
			bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	public void AwardGRAZIELLAUnlock()
	{
		//IL_00c8: Expected O, but got I
		//IL_0122: Expected O, but got I
		//IL_01fa: Expected O, but got I
		//IL_0254: Expected O, but got I
		//IL_032c: Expected O, but got I
		//IL_0386: Expected O, but got I
		//IL_03cf: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptions playerOptions = core._playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		List<CharacterType> list = mainGameConfig._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r10_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_0137;
			}
		}
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)mainGameConfig._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v18+18]");
		if (num >= 0)
		{
			list2.AddWithResize((System.Int32Enum)26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = 26;
		}
		goto IL_0137;
		IL_0137:
		GameManager core2 = GM.Core;
		PlayerOptions playerOptions2 = core2._playerOptions;
		PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
		List<CharacterType> list3 = mainGameConfig2._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r10_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				goto IL_0269;
			}
		}
		List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)mainGameConfig2._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r8_v13+18]");
		if (num2 >= 0)
		{
			list4.AddWithResize((System.Int32Enum)26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 26;
		}
		goto IL_0269;
		IL_0269:
		GameManager core3 = GM.Core;
		PlayerOptions playerOptions3 = core3._playerOptions;
		PlayerOptionsData mainGameConfig3 = playerOptions3._mainGameConfig;
		List<CharacterType> list5 = mainGameConfig3._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj7 = default(object);
			if ((nint)obj7 != -1)
			{
				goto IL_0411;
			}
		}
		List<System.Int32Enum> list6 = (List<System.Int32Enum>)(object)mainGameConfig3._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r9_v9+18]");
		if (num3 >= 0)
		{
			list6.AddWithResize((System.Int32Enum)26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj9 = (nint)0 + (nint)1;
			_ = 26;
		}
		goto IL_0411;
		IL_0411:
		GameManager core4 = GM.Core;
		core4._playerOptions.Save();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = -1000f;
		soundConfig.Rate = 0.5f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
	}

	private void _003CAwake_003Eb__3_0()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Vector2 pos = default(Vector2);
					SpawnWerewolves(pos);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
