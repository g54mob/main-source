using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells;

public class Spell_Mars(SignalBus signalBus, SpellsManager spellsManager) : SpellModifier
{
	private SignalBus _signalBus = signalBus;

	private SpellsManager _spellsManager = spellsManager;

	public void Start()
	{
		_spellsManager.AddSpell(this);
		SoundManager.StopMusic(BgmType.BGM_Secret);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B670");
	}

	public void Activate()
	{
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		CharacterController activeCharacter = gameSessionData._activeCharacter;
		CharacterData currentCharacterData = activeCharacter._currentCharacterData;
		float num = currentCharacterData._003Cspeed_003Ek__BackingField - 0.4f;
		currentCharacterData._003Cspeed_003Ek__BackingField = num;
		GameManager core2 = GM.Core;
		GameSessionData gameSessionData2 = core2._gameSessionData;
		CharacterController activeCharacter2 = gameSessionData2._activeCharacter;
		CharacterData currentCharacterData2 = activeCharacter2._currentCharacterData;
		float num2 = currentCharacterData2._003CmoveSpeed_003Ek__BackingField + 0.25f;
		currentCharacterData2._003CmoveSpeed_003Ek__BackingField = num2;
		GameManager core3 = GM.Core;
		GameSessionData gameSessionData3 = core3._gameSessionData;
		CharacterController activeCharacter3 = gameSessionData3._activeCharacter;
		MagnetZone magnet = activeCharacter3._magnet;
		EggFloat radius = magnet.Radius;
		GameManager core4 = GM.Core;
		GameSessionData gameSessionData4 = core4._gameSessionData;
		CharacterController activeCharacter4 = gameSessionData4._activeCharacter;
		MagnetZone magnet2 = activeCharacter4._magnet;
		EggFloat radius2 = magnet2.Radius;
		EggFloat eggFloat = new EggFloat(radius2._val, radius2._eggVal);
		float eggValue = default(float);
		float value = default(float);
		EggFloat radius3 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal + radius._eggVal;
		value = eggFloat._val + radius._val;
		magnet.Radius = radius3;
		GameManager core5 = GM.Core;
		GameSessionData gameSessionData5 = core5._gameSessionData;
		CharacterController activeCharacter5 = gameSessionData5._activeCharacter;
		activeCharacter5._magnet.RefreshSize();
	}

	public void Deactivate()
	{
	}
}
