using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells
{
	public class Spell_PopTheCorn : SpellModifier
	{
		private PlayerOptions _playerOptions;

		private SignalBus _signalBus;

		private SpellsManager _spellsManager;

		private DataManager _dataManager;

		public Spell_PopTheCorn(PlayerOptions player, SignalBus signalBus, SpellsManager spellsManager, DataManager dataManager)
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
