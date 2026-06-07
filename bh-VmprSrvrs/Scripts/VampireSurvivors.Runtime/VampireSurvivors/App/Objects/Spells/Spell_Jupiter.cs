using VampireSurvivors.Data;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells
{
	public class Spell_Jupiter : SpellModifier
	{
		private SignalBus _signalBus;

		private SpellsManager _spellsManager;

		private StageType _saveStage;

		private CharacterType _saveCharacter;

		private BgmModType _saveBGMMod;

		private BgmType _saveBGM;

		public Spell_Jupiter(SignalBus signalBus, SpellsManager spellsManager)
		{
		}

		public void Start()
		{
		}

		public void Activate()
		{
		}

		public void Deactivate()
		{
		}
	}
}
