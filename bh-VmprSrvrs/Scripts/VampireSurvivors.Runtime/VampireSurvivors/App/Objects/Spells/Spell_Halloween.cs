using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells
{
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
		}

		public void Start()
		{
		}

		public void Activate()
		{
		}
	}
}
