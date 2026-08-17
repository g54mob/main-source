using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells;

public class Spell_ForbiddenBox : SpellModifier
{
	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private DataManager _data;

	private SpellsManager _spellsManager;

	public Spell_ForbiddenBox(SignalBus signalBus, SpellsManager spellsManager, DataManager data, PlayerOptions player)
	{
		_signalBus = signalBus;
		_spellsManager = spellsManager;
		_data = data;
		PlayerOptions playerOptions = default(PlayerOptions);
		_playerOptions = playerOptions;
	}

	public void Start()
	{
		//IL_0113: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		//IL_0140: Expected O, but got I4
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
		PlayerOptionsData config5 = _playerOptions.Config;
		config5._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Devil;
		PlayerOptionsData config6 = _playerOptions.Config;
		config6._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		PlayerOptionsData config7 = _playerOptions.Config;
		config7._003CSelectedStage_003Ek__BackingField = StageType.DEVILROOM;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B670");
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}
}
