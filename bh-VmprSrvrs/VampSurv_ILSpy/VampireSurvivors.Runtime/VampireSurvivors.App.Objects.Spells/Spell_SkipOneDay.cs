using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells;

public class Spell_SkipOneDay : SpellModifier
{
	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private SpellsManager _spellsManager;

	private DataManager _dataManager;

	public Spell_SkipOneDay(PlayerOptions player, SignalBus signalBus, SpellsManager spellsManager, DataManager dataManager)
	{
		_playerOptions = player;
		_signalBus = signalBus;
		_spellsManager = spellsManager;
		DataManager dataManager2 = default(DataManager);
		_dataManager = dataManager2;
	}

	public void Start()
	{
		//IL_01a1: Expected O, but got I4
		//IL_01b0: Expected O, but got I4
		//IL_01bf: Expected O, but got I4
		//IL_01ce: Expected O, but got I4
		//IL_0127: Expected O, but got I
		//IL_013c: Expected O, but got I
		_spellsManager.AddSpell(this);
		SoundManager.StopMusic(BgmType.BGM_Secret);
		PlayerOptionsData config = _playerOptions.Config;
		SpellsManager._003CCachedStageType_003Ek__BackingField = (StageType?)(object)1;
		PlayerOptionsData config2 = _playerOptions.Config;
		SpellsManager._003CCachedCharacterType_003Ek__BackingField = (CharacterType?)(object)1;
		PlayerOptionsData config3 = _playerOptions.Config;
		SpellsManager._003CCachedBgmMod_003Ek__BackingField = (BgmModType?)(object)1;
		PlayerOptionsData config4 = _playerOptions.Config;
		SpellsManager._003CCachedBgm_003Ek__BackingField = (BgmType?)(object)1;
		PlayerOptionsData config5 = _playerOptions.Config;
		config5._003CSelectedStage_003Ek__BackingField = StageType.MOLISE;
		PlayerOptionsData config6 = _playerOptions.Config;
		Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)9);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v34 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v34 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v35+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v36+6C]");
			config6._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Forest;
			PlayerOptionsData config7 = _playerOptions.Config;
			config7._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
			List<StageData> list = ((Dictionary<StageType, List<StageData>>)(object)_signalBus).get_Item(StageType.FOREST);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void Activate()
	{
		//IL_000e: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		GameManager core = GM.Core;
		object obj = 0;
		do
		{
			float num = core._003CSurvivedSeconds_003Ek__BackingField + 60f;
			core._003CSurvivedSeconds_003Ek__BackingField = num;
			core._stage.CheckMinute();
			obj++;
		}
		while ((nint)obj < 1440);
	}

	public void Deactivate()
	{
	}
}
