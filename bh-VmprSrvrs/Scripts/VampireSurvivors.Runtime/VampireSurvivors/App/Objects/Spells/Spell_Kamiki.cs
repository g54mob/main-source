using VampireSurvivors.Objects;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells
{
	public class Spell_Kamiki : SpellModifier
	{
		private PlayerOptions _playerOptions;

		private SignalBus _signalBus;

		private SpellsManager _spellsManager;

		public Spell_Kamiki(PlayerOptions player, SignalBus signalBus, SpellsManager spellsManager)
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
