using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors
{
	public class PlayerInfo : MonoBehaviour
	{
		public Action<int, int, VampireSurvivors.Objects.Characters.CharacterController> OnLevelUpSuggestedCallback;

		public Action<CharacterType> OnCharacterSelectionChanged;

		public Action<SkinType> OnSkinSelectionChanged;

		private CharacterType _selectedCharacter;

		private SkinType _skinType;

		private bool _isReadyToPlay;

		private bool _sceneLoaded;

		private bool _gameplayLoaded;

		private bool _stageInitialized;

		private CoherenceSync _characterEntity;

		private VampireSurvivors.Objects.Characters.CharacterController _characterController;

		private CoherenceSync _coherenceSync;

		private int _averageLatencyMs;

		private int _suggestedLevelUp;

		private List<byte[]> _powerUpChunks;

		private Dictionary<PowerUpType, PlayerStat> _hostPowerUps;

		private bool _isInBanishMode;

		private bool _hasGameplayUiActive;

		[Sync]
		public bool IsReadyToStartCharacterSelect { get; set; }

		[Sync]
		[OnValueSynced("OnCharacterUpdate")]
		public int SelectedCharacter
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		[OnValueSynced("OnSkinUpdate")]
		public int SelectedSkin
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		public bool IsReadyToPlay
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool SceneLoaded
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool GameplayLoaded
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool StageInitialized
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public CoherenceSync CharacterEntity
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync]
		public int AverageLatencyMs
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		[OnValueSynced("OnLevelUpSuggested")]
		public int SuggestedLevelUp
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		public bool IsInBanishMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool HasGameplayUiActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public int UiPageId { get; set; }

		[Sync]
		public string UserName { get; set; }

		public VampireSurvivors.Objects.Characters.CharacterController CharacterController => null;

		public bool UpdateAverageLatency { get; set; }

		public bool HasStateAuthority => false;

		public void OnCharacterUpdate(int oldCharacter, int newCharacter)
		{
		}

		public void OnSkinUpdate(int oldSkin, int newSkin)
		{
		}

		public void OnLevelUpSuggested(int old, int newSuggestion)
		{
		}

		public void ResetGameSession()
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
