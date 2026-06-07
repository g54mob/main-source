using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Toolkit;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class OnlineLobbyPage : BaseUIPage, ICharacterSelector
	{
		[CompilerGenerated]
		private sealed class _003CSelectAfterFrameDelay_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OnlineLobbyPage _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSelectAfterFrameDelay_003Ed__54(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitAndDo_003Ed__104 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action cb;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitAndDo_003Ed__104(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private GameObject CharacterPrefab;

		[SerializeField]
		private RectTransform Container;

		[SerializeField]
		private Button ConfirmButton;

		[SerializeField]
		private Button BuyButton;

		[SerializeField]
		private Button StartButton;

		[SerializeField]
		private Button _collectionsButton;

		[SerializeField]
		private Button _powerUpsButton;

		[SerializeField]
		private Button _achievementButton;

		[SerializeField]
		private Image PanelBackground;

		[SerializeField]
		private Sprite _SkinOffIcon;

		[SerializeField]
		private Sprite _SkinOnIcon;

		[SerializeField]
		private RectTransform _SkinIndexContainer;

		[SerializeField]
		private GameObject _SkinIndexPrefab;

		[SerializeField]
		private CharacterStageCompletionPanel _StageCompletionPanel;

		[FormerlySerializedAs("Name")]
		[SerializeField]
		private TextMeshProUGUI _Name;

		[SerializeField]
		private TextMeshProUGUI Description;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Image WeaponIcon;

		[SerializeField]
		private StatsPanelUI StatsPanel;

		[SerializeField]
		private PriceUI Price;

		[SerializeField]
		private Image _LockIcon;

		[SerializeField]
		private GameObject _WeaponFrame;

		[SerializeField]
		private List<OnlineMPPlayerItem> _players;

		[SerializeField]
		private StageItemUI _stageItem;

		[SerializeField]
		private GameObject _selectStageButton;

		[SerializeField]
		private TextMeshProUGUI _latencyText;

		private TextMeshProUGUI _buyButtonLabel;

		private bool _characterBoughtThisFrame;

		private Dictionary<CharacterType, CharacterItemUI> _characterItems;

		private CharacterItemUI _selectedCharacter;

		private SignalBus _signalBus;

		private DataManager _dataManager;

		private readonly List<GameObject> _spawned;

		private PlayerOptions _playerOptions;

		private AdventureManager _adventureManager;

		private LobbiesManager _lobbiesManager;

		private CharacterData _currentData;

		private CharacterType _currentType;

		private bool _characterConfirmed;

		private List<Image> _skinSlots;

		private List<int> _weirdCharacters;

		private List<CharacterType> _tempUnlockedCoopCharacters;

		private int _selectedPlayerSlotIndex;

		private bool _rnjSetup;

		private bool _missingNSetup;

		private bool _isUILocked;

		private bool _waitingForAllPlayersToBeReadyToStartCharacterSelect;

		private static float ICON_UI_SCALE;

		private bool _onlineInit;

		public static OnlineLobbyPage Instance { get; private set; }

		[Inject]
		private void Construct(SignalBus signalBus, PlayerOptions playerOptions, DataManager dataManager, AdventureManager adventureManager, LobbiesManager lobbiesManager)
		{
		}

		public void RefreshCharacters()
		{
		}

		[IteratorStateMachine(typeof(_003CSelectAfterFrameDelay_003Ed__54))]
		private IEnumerator SelectAfterFrameDelay()
		{
			return null;
		}

		public void StartGame()
		{
		}

		public void SelectCharacter(bool fromUnlock)
		{
		}

		public void SelectStage()
		{
		}

		private void UpdatePlayerInfoSelectedCharacter()
		{
		}

		public void BuyCharacter()
		{
		}

		private void WrapNavigation()
		{
		}

		private bool IsCharacterHighlightedByOtherPlayer(CharacterType cType)
		{
			return false;
		}

		private void DisableButtons()
		{
		}

		private bool ShouldSelectionChangesBeBlocked()
		{
			return false;
		}

		public void ShowCharacterInfo(CharacterData charData, CharacterType cType, CharacterItemUI character)
		{
		}

		private void SetVisualStatePurchasable()
		{
		}

		private void SetCharacterSprite(CharacterType cType, CharacterData cData)
		{
		}

		private void SetCharPanelDescription(string descText, bool isHidden = false, bool isSecret = false)
		{
		}

		private void SetIconSizes()
		{
		}

		public void NextSkin()
		{
		}

		public void SetSkinOnline(int character, int skinTypeAsInt)
		{
		}

		private void SetWeaponIconSprite(CharacterData characterData)
		{
		}

		private bool CanSeeSkins()
		{
			return false;
		}

		private void SetSkinSlots()
		{
		}

		public bool IsSecretAndNotUnlocked(CharacterData characterData, CharacterType characterType)
		{
			return false;
		}

		public bool IsSecretChar(CharacterType characterType)
		{
			return false;
		}

		protected override void Update()
		{
		}

		private void CheckUIInteraction()
		{
		}

		private void CheckUIInteractionWhenClient()
		{
		}

		private void CheckUIInteractionWhenHosting()
		{
		}

		private void EnableUIInteraction()
		{
		}

		private void LateUpdate()
		{
		}

		private void SetCharactersTaken()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void LockOnlineUI()
		{
		}

		private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
		{
		}

		private void ResetUi()
		{
		}

		private void OnBecomeAuthority()
		{
		}

		private void OnStageSelected(UISignals.ConfirmStageSelectionSignal startingStage)
		{
		}

		private void PopulatePlayerUis()
		{
		}

		private void OnSeatAssigned(int seatNumber, PlayerInfo playerInfo)
		{
		}

		protected override void OnEnterPressed()
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void Detune()
		{
		}

		private void OnDestroy()
		{
		}

		private void setupRNJ(CharacterData dat, CharacterType cType)
		{
		}

		private static void SetDefaultCharacterName(CharacterData dat)
		{
		}

		private void setupMIS(CharacterData ddata, CharacterType cType)
		{
		}

		private void InitMisValues(CharacterData ddata, CharacterType cType)
		{
		}

		private string CharCodeToString(int[] codes)
		{
			return null;
		}

		private void Populate()
		{
		}

		private void UpdateStatsPanelVisibility()
		{
		}

		private GameObject AddCharacter(CharacterItem cItem)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitAndDo_003Ed__104))]
		private IEnumerator WaitAndDo(Action cb)
		{
			return null;
		}

		public void GoBackOnline()
		{
		}

		public void ShowPowerUps()
		{
		}

		public void ShowAchievements()
		{
		}

		public void ShowCollections()
		{
		}
	}
}
