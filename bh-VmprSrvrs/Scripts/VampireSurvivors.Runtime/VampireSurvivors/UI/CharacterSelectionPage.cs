using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cheats;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class CharacterSelectionPage : BaseUIPage, ICharacterSelector
	{
		private enum State
		{
			SINGLEPLAYER = 0,
			MULTIPLAYER = 1
		}

		private class AIPopupChoice
		{
			public Rewired.Player _player;

			public AIType _aiType;
		}

		[CompilerGenerated]
		private sealed class _003CSelectAfterFrameDelay_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterSelectionPage _003C_003E4__this;

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
			public _003CSelectAfterFrameDelay_003Ed__76(int _003C_003E1__state)
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
		private sealed class _003CWaitAndDo_003Ed__124 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CWaitAndDo_003Ed__124(int _003C_003E1__state)
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
		private Image PanelBackground;

		[SerializeField]
		private TextMeshProUGUI _EggCount;

		[SerializeField]
		private TextMeshProUGUI _EggCountTitle;

		[SerializeField]
		private TickBoxUI _EggBox;

		[SerializeField]
		private TextMeshProUGUI _MaxWeaponsText;

		[SerializeField]
		private GameObject _EggWeaponBox;

		[SerializeField]
		private GameObject _EggContainer;

		[SerializeField]
		private GameObject _WeaponCountContainer;

		[SerializeField]
		private Sprite _SkinOffIcon;

		[SerializeField]
		private Sprite _SkinOnIcon;

		[SerializeField]
		private RectTransform _SkinIndexContainer;

		[SerializeField]
		private GameObject _SkinIndexPrefab;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private GameObject _MultiplayerTextPanel;

		[SerializeField]
		private GameObject MPPlayerItemPrefab;

		[SerializeField]
		private RectTransform MPPlayerContainer;

		[SerializeField]
		private FakeSliderHandleController _StageCompletionScroller;

		[SerializeField]
		private RectTransform _DoilieMask;

		[SerializeField]
		private List<Sprite> _Doilies;

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
		private Image _LockIcon;

		[SerializeField]
		private StatsPanelUI StatsPanel;

		[SerializeField]
		private PriceUI Price;

		[SerializeField]
		private GameObject _WeaponFrame;

		[SerializeField]
		private EnterCoopButton _EnterCoopButton;

		[SerializeField]
		private GameObject _SwitchReassignControllersButton;

		private GameObject _lastBonusButton;

		private bool _wasAllowingMultiplayerJoining;

		private bool _characterBoughtThisFrame;

		private TextMeshProUGUI _buyButtonLabel;

		private State state;

		private Dictionary<CharacterType, CharacterItemUI> _characterItemUIs;

		private List<MPPlayerItem> _playerSlots;

		private CharacterItemUI _selectedCharacterItemUI;

		private SignalBus _signalBus;

		private DataManager _dataManager;

		private DiContainer _diContainer;

		private readonly List<GameObject> _spawned;

		private PlayerOptions _playerOptions;

		private MultiplayerManager _multiplayer;

		private AdventureManager _adventureManager;

		private CharacterData _currentData;

		private CharacterType _currentType;

		private LargeMultiOptionPopup _AISelectionPopup;

		private LargeMultiOptionPopup _PartySizeSelectionPopup;

		private CharSelectionCheatCodeManager _cheats;

		private bool _characterConfirmed;

		private List<Image> _skinSlots;

		private List<int> _weirdCharacters;

		private List<CharacterType> _tempUnlockedCoopCharacters;

		private readonly float _iconUIScale;

		private int _partySize;

		private bool _partyModeEnabled => false;

		private int _selectedPlayerSlotIndex => 0;

		[Inject]
		private void Construct(SignalBus signalBus, PlayerOptions playerOptions, DataManager dataManager, DiContainer diContainer, MultiplayerManager multi, AdventureManager adventureManager)
		{
		}

		private void Start()
		{
		}

		private void HandlePlayersPressingB()
		{
		}

		private void HandleBackButton()
		{
		}

		protected override void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void EnterCoopMode()
		{
		}

		private void ClearPlayers()
		{
		}

		private void OnDestroy()
		{
		}

		public void RefreshCharacters()
		{
		}

		[IteratorStateMachine(typeof(_003CSelectAfterFrameDelay_003Ed__76))]
		private IEnumerator SelectAfterFrameDelay()
		{
			return null;
		}

		public void ConfirmCharacter()
		{
		}

		private bool DoesSlotNeedCharacterChoice(int slotIndex)
		{
			return false;
		}

		private void GoToNextCharacterOrContinue()
		{
		}

		public void SetEggs(bool b)
		{
		}

		public void SelectCharacter(bool fromUnlock)
		{
		}

		public void BuyCharacter()
		{
		}

		public void IncreaseMaxWeapons()
		{
		}

		private GameObject GetBonusButton()
		{
			return null;
		}

		private void WrapNavigation()
		{
		}

		private bool HasCharUnlock(string characterToUnlock, List<CharacterType> charactersToUnlock = null)
		{
			return false;
		}

		private bool HasSkinUnlock(List<SkinToUnlock> skinsToUnlock = null)
		{
			return false;
		}

		private void SetVisualStateUnlockable()
		{
		}

		private void SetVisualStatePurchasable()
		{
		}

		private void SetVisualStateAvailable()
		{
		}

		public void ShowCharacterInfo(CharacterData charData, CharacterType cType, CharacterItemUI character)
		{
		}

		private void SetPanelVisualState()
		{
		}

		private void UpdateNavigationOnCharSelected()
		{
		}

		private void UpdateEggCount()
		{
		}

		private void SetCharPanelDescription(string descText, bool isHidden = false, bool isSecret = false)
		{
		}

		private void SetUnlockableDescription()
		{
		}

		private void SetIconSizes()
		{
		}

		private void ResetDisplay(bool playerLeftGame)
		{
		}

		private bool CanSeeSkins()
		{
			return false;
		}

		public void NextSkin()
		{
		}

		private void SetSkinSlots()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void OnPlayerButtonClicked(int index)
		{
		}

		private LargeMultiOptionPopup ShowAISettingsPopup(int playerSlotIndex)
		{
			return null;
		}

		private void PlayerSlotSelection(int index, int choiceIndex, List<AIPopupChoice> choices)
		{
		}

		private void SetVisibility(UISignals.SetCharacterSelectionPageVisibility sig)
		{
		}

		private void ForceSelectCharacter(UISignals.ForceSelectionOnCharacterSelectionPageSignal sig)
		{
		}

		private void AddCharactersFromSignal(UISignals.AddNewCharactersToSelectionPageSignal sig)
		{
		}

		private void RebuildNavigationAfterCreditsReveal()
		{
		}

		public void SpawnDoilie(CharacterItemUI c)
		{
		}

		public void SpawnMinorDoilie()
		{
		}

		private void SetDisplayType()
		{
		}

		protected override void OnEnterPressed()
		{
		}

		private LargeMultiOptionPopup ShowPartySizePopup()
		{
			return null;
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void Detune()
		{
		}

		private void setupRNJ(CharacterData dat, CharacterType cType)
		{
		}

		private void setupMIS(CharacterData ddata, CharacterType cType)
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

		[IteratorStateMachine(typeof(_003CWaitAndDo_003Ed__124))]
		private IEnumerator WaitAndDo(Action cb)
		{
			return null;
		}

		private void SetCharacterSprite(CharacterType cType, CharacterData cData)
		{
		}

		private void SetCharacterName(CharacterType cType, CharacterData cData)
		{
		}

		private void SetWeaponIconSprite(CharacterData characterData)
		{
		}

		private void MakeDisplayMultiplayer()
		{
		}

		private void MakeDisplaySingleplayer()
		{
		}

		private void RefreshMaxWeaponsAndEggsDisplay()
		{
		}

		private void SpawnPlayerItem(int index)
		{
		}
	}
}
