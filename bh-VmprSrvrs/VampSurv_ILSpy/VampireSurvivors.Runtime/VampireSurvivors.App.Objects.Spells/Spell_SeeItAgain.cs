using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells;

public class Spell_SeeItAgain(PlayerOptions player, SignalBus signalBus, SpellsManager spellsManager) : SpellModifier
{
	private PlayerOptions _playerOptions = player;

	private SignalBus _signalBus = signalBus;

	private SpellsManager _spellsManager = spellsManager;

	public void Start()
	{
		//IL_005e: Expected O, but got I4
		//IL_0067: Expected O, but got I4
		//IL_00d9: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		//IL_0189: Expected O, but got I4
		//IL_01fb: Expected O, but got I
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		_spellsManager.AddSpell(this);
		SoundManager.StopMusic(BgmType.BGM_Secret);
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedStage_003Ek__BackingField = StageType.STAGEX;
		bool flag = Stage.HasValidStageXCharacters();
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			List<CharacterType> validStageCharacters = Stage._validStageCharacters;
			PlayerOptionsData config2 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_025e;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v9+20]");
			config2.SelectedCharacter = CharacterType.VOID;
			int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
			if (playerCount <= 1)
			{
				bool isOnlineMultiplayer = MultiplayerManager.s_instance.IsOnlineMultiplayer;
				bool flag2 = !isOnlineMultiplayer;
				obj = 0;
				obj2 = 0;
				if (flag2)
				{
					goto IL_024e;
				}
			}
			MultiplayerManager s_instance = MultiplayerManager.s_instance;
			List<CoopSlotData> slotsSelections = s_instance._slotsSelections;
			obj = 0;
			obj2 = 0;
			object obj4 = 0;
			while ((nint)obj4 < slotsSelections._size)
			{
				if ((nint)obj < slotsSelections._size)
				{
					CoopSlotData[] items = slotsSelections._items;
					object obj5 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					if ((nint)obj5 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
						obj2 = 0;
						CoopSlotData coopSlotData = items[obj];
						object obj6 = obj + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v5+20+v74 @ rdx_v7*4]");
						coopSlotData.SelectedCharacter = CharacterType.VOID;
						obj = obj6;
						obj4 = obj6;
						continue;
					}
				}
				goto IL_025e;
			}
		}
		goto IL_024e;
		IL_024e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B670");
		return;
		IL_025e:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}
}
