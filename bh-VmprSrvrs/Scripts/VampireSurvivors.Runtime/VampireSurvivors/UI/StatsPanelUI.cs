using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.UI
{
	public class StatsPanelUI : MonoBehaviour
	{
		[FormerlySerializedAs("StatPrefab")]
		[SerializeField]
		private StatItemUI _StatPrefab;

		[FormerlySerializedAs("Container")]
		[SerializeField]
		private RectTransform _Container;

		[FormerlySerializedAs("StatObjects")]
		[SerializeField]
		private List<StatItemUI> _StatObjects;

		private bool _hasLoaded;

		private PlayerStats _stats;

		private DataManager _dataManager;

		private PlayerOptions _playerOptions;

		private EggManager _eggManager;

		private MultiplayerManager _multiplayer;

		private AdventureManager _adventureManager;

		private Dictionary<PowerUpType, PlayerStat> _playerStats;

		private Dictionary<PowerUpType, List<PowerUpData>> _powerUps;

		private CharacterData _currentCharacter;

		private CharacterType _currentCharacterType;

		private VampireSurvivors.Objects.Characters.CharacterController _inGameCharacter;

		private List<TextMeshProUGUI> _statTextLines;

		private bool _isInGame;

		private bool _useEggs;

		[Inject]
		private void Construct(PlayerStats stats, DataManager data, PlayerOptions playerOptions, EggManager egg, MultiplayerManager multi, AdventureManager adventureManager)
		{
		}

		public void Initialize()
		{
		}

		public void SetCharacter(CharacterData character, CharacterType type, VampireSurvivors.Objects.Characters.CharacterController ingameCharacter = null)
		{
		}

		public void Refresh()
		{
		}

		public void EggsToggled()
		{
		}

		private void Populate()
		{
		}

		private void AddStat(PowerUpType type, PowerUpData data, float val)
		{
		}

		private void SetValues()
		{
		}

		private float GetPowerUpStatValue(PlayerStat playerStat)
		{
			return 0f;
		}

		private float CheckForOmni(Dictionary<PowerUpType, PlayerStat> playerStat, PowerUpType type)
		{
			return 0f;
		}

		private float GetPowerUpStatValueByType(PowerUpType powerUpType, ModifierStats modifierStats)
		{
			return 0f;
		}

		private float GetCharacterValueFromPowerUpType(PowerUpType type)
		{
			return 0f;
		}

		private float GetSkinStat(PowerUpType type)
		{
			return 0f;
		}
	}
}
