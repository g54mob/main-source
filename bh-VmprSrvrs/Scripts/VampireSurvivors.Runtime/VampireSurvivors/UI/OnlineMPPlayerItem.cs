using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class OnlineMPPlayerItem : MonoBehaviour
	{
		[SerializeField]
		private GameObject _CharacterSelectedGroup;

		[SerializeField]
		private GameObject _PlayerNotConnected;

		[SerializeField]
		private Image _Frame;

		[SerializeField]
		private Image _OuterFrame;

		[SerializeField]
		private TextMeshProUGUI _CharacterName;

		[SerializeField]
		private TextMeshProUGUI _PlayerName;

		[SerializeField]
		private Image _CharacterIcon;

		[SerializeField]
		private Image _WeaponIcon;

		[SerializeField]
		private Image _WeaponShadow;

		[SerializeField]
		private GameObject _selectionFrame;

		[SerializeField]
		private GameObject _selectionBox;

		[SerializeField]
		private GameObject _selectionTick;

		[SerializeField]
		private GameObject _aiSettingsButton;

		private DataManager _dataManager;

		private PlayerOptions _playerOptions;

		private PlayerInfo _onlinePlayerInfo;

		private CharacterData _data;

		private int _index;

		private bool _isMyPlayerButton;

		public PlayerInfo OnlinePlayerInfo => null;

		public event Action OnAiSettingsButtonClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		private void Construct(DataManager dataManager, PlayerOptions playerOptions)
		{
		}

		private void Awake()
		{
		}

		public void Init(PlayerInfo playerInfo, int seatNumber)
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void SetAIData(CharacterType type, int index)
		{
		}

		private void RefreshForSkin(SkinType skinType)
		{
		}

		private void SetData(CharacterType type)
		{
		}

		private void SetWeaponIconSprite(CharacterData characterData, Skin skinData)
		{
		}

		private void SetColor(float saturation = 1f)
		{
		}
	}
}
