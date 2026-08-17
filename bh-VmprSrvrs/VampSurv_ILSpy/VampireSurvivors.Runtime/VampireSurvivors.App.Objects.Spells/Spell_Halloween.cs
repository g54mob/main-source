using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells;

public class Spell_Halloween : SpellModifier
{
	private SignalBus _signalBus;

	private SpellsManager _spellsManager;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private StageType _saveStage;

	private CharacterType _saveCharacter;

	private BgmModType _saveBGMMod;

	private BgmType _saveBGM;

	public Spell_Halloween(SignalBus signalBus, SpellsManager spellsManager, DataManager data, PlayerOptions player)
	{
		_signalBus = signalBus;
		_spellsManager = spellsManager;
		_data = data;
		PlayerOptions playerOptions = default(PlayerOptions);
		_playerOptions = playerOptions;
	}

	public void Start()
	{
		//IL_0519: Expected O, but got I4
		//IL_0528: Expected O, but got I4
		//IL_0537: Expected O, but got I4
		//IL_0546: Expected O, but got I4
		//IL_00e8: Expected O, but got I
		//IL_00fd: Expected O, but got I
		//IL_01cd: Expected O, but got I
		//IL_0227: Expected O, but got I
		//IL_0583: Expected O, but got I
		//IL_0291: Expected O, but got I
		//IL_05ab: Expected O, but got I
		//IL_02fb: Expected O, but got I
		//IL_0366: Expected O, but got I
		//IL_061e: Expected O, but got I4
		//IL_038c: Expected O, but got I
		//IL_04b1: Expected O, but got I
		//IL_04c6: Expected O, but got I
		_spellsManager.AddSpell(this);
		PlayerOptionsData config = _playerOptions.Config;
		SpellsManager._003CCachedStageType_003Ek__BackingField = (StageType?)(object)1;
		PlayerOptionsData config2 = _playerOptions.Config;
		SpellsManager._003CCachedCharacterType_003Ek__BackingField = (CharacterType?)(object)1;
		PlayerOptionsData config3 = _playerOptions.Config;
		SpellsManager._003CCachedBgmMod_003Ek__BackingField = (BgmModType?)(object)1;
		PlayerOptionsData config4 = _playerOptions.Config;
		SpellsManager._003CCachedBgm_003Ek__BackingField = (BgmType?)(object)1;
		SoundManager.StopMusic(BgmType.BGM_Secret);
		Dictionary<StageType, List<StageData>> convertedStages = _data.GetConvertedStages();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)11);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v37 (System.Object)+18]");
		bool flag = (nint)0 <= (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v37 (System.Object)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v38+20]");
		object obj3 = 0;
		PlayerOptionsData config5 = _playerOptions.Config;
		config5._003CSelectedStage_003Ek__BackingField = StageType.BONEZONE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v7+70]");
		if ((nint)0 != 0)
		{
			PlayerOptionsData config6 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v7+70]");
			if ((nint)0 == 0)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				goto IL_0560;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v7+70]");
			BgmType bgmType = (BgmType)((nint)0 >> 32);
			config6._003CSelectedBGM_003Ek__BackingField = bgmType;
		}
		List<CharacterType> list = new List<CharacterType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v18+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)9);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj5 = (nint)0 + (nint)1;
			_ = 9;
		}
		goto IL_0560;
		IL_0560:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v20+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj7 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj9 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		System.Int32Enum int32Enum = (System.Int32Enum)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v24 (System.Int32Enum)+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 30;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		object obj11 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		bool flag2 = (nint)obj11 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rax_v41 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj12 = 0;
		PlayerOptionsData config7 = _playerOptions.Config;
		Dictionary<CharacterType, SkinType> dictionary = config7._003CSelectedSkinsV2_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v42+20+v135 @ rax_v50*4]");
		int num5 = dictionary.FindEntry(CharacterType.VOID);
		Dictionary<CharacterType, SkinType> dictionary2;
		System.Collections.Generic.InsertionBehavior behavior;
		if (num5 < 0)
		{
			PlayerOptionsData config8 = _playerOptions.Config;
			dictionary2 = config8._003CSelectedSkinsV2_003Ek__BackingField;
			behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
		}
		else
		{
			PlayerOptionsData config9 = _playerOptions.Config;
			dictionary2 = config9._003CSelectedSkinsV2_003Ek__BackingField;
			behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
		}
		Dictionary<CharacterType, SkinType> dictionary3 = dictionary2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v42+20+v135 @ rax_v50*4]");
		bool flag3 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)dictionary3).TryInsert((System.Int32Enum)0, (System.Int32Enum)4, behavior);
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v42+20+v135 @ rax_v50*4]");
		object obj13 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v59 (System.Object)+18]");
		bool flag4 = (nint)0 <= (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v59 (System.Object)+10]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v60+20]");
		object obj15 = 0;
		_ = 4;
		PlayerOptionsData config10 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v42+20+v135 @ rax_v50*4]");
		config10.SelectedCharacter = CharacterType.VOID;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B670");
	}

	public void Activate()
	{
		GameManager core = GM.Core;
		core._003CIsHalloween_003Ek__BackingField = true;
		GameManager core2 = GM.Core;
		core2._playerOptions.UnlockSkin(CharacterType.MORTACCIO, SkinType.HALLOWS);
		GameManager core3 = GM.Core;
		core3._playerOptions.UnlockSkin(CharacterType.CAVALLO, SkinType.HALLOWS);
		GameManager core4 = GM.Core;
		core4._playerOptions.UnlockSkin(CharacterType.TATANKA, SkinType.HALLOWS);
		GameManager core5 = GM.Core;
		core5._playerOptions.UnlockSkin(CharacterType.MARIA, SkinType.HALLOWS);
	}
}
