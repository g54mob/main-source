using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells
{
	public class Spell_ForbiddenBox : SpellModifier
	{
		private PlayerOptions _playerOptions;

		private SignalBus _signalBus;

		private DataManager _data;

		private SpellsManager _spellsManager;

		public Spell_ForbiddenBox(SignalBus signalBus, SpellsManager spellsManager, DataManager data, PlayerOptions player)
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
