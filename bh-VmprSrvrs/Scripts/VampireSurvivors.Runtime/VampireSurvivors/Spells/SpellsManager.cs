using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Spells
{
	[UsedImplicitly]
	public class SpellsManager : IInitializable, IDisposable
	{
		private List<SpellModifier> _enabledSpells;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private DataManager _dataManager;

		public static StageType? CachedStageType { get; set; }

		public static CharacterType? CachedCharacterType { get; set; }

		public static BgmType? CachedBgm { get; set; }

		public static BgmModType? CachedBgmMod { get; set; }

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void StartSpell(SecretType secretType)
		{
		}

		public void ActivateSpells()
		{
		}

		public void AddSpell(SpellModifier spellModifier)
		{
		}

		public void ResetCachedValues()
		{
		}

		public void RestoreCachedPlayerSettings()
		{
		}
	}
}
