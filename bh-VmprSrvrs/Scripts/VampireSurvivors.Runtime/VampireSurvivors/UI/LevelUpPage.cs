using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Log;
using DG.Tweening;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.UI.Twitch;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class LevelUpPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CDelaySetFooter_003Ed__86 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LevelUpPage _003C_003E4__this;

			public bool enabled;

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
			public _003CDelaySetFooter_003Ed__86(int _003C_003E1__state)
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
		private sealed class _003CForceLeftLayoutDelayed_003Ed__122 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LevelUpPage _003C_003E4__this;

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
			public _003CForceLeftLayoutDelayed_003Ed__122(int _003C_003E1__state)
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
		private sealed class _003CSelectElementLater_003Ed__107 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Selectable s;

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
			public _003CSelectElementLater_003Ed__107(int _003C_003E1__state)
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
		private sealed class _003CTweenButtonsNextFrame_003Ed__128 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LevelUpPage _003C_003E4__this;

			private float _003CskipButtonScale_003E5__2;

			private float _003CbanishButtonScale_003E5__3;

			private float _003CrerollButtonScale_003E5__4;

			private float _003CpassButtonScale_003E5__5;

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
			public _003CTweenButtonsNextFrame_003Ed__128(int _003C_003E1__state)
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
		private sealed class _003CWaitSelectBanish_003Ed__87 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool isOn;

			public LevelUpPage _003C_003E4__this;

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
			public _003CWaitSelectBanish_003Ed__87(int _003C_003E1__state)
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
		private GameObject _luck;

		[SerializeField]
		private RectTransform Container;

		[SerializeField]
		private GameObject LevelUpItemPrefab;

		[SerializeField]
		private Image ProgressBar;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private UISpriteAnimation _ExplosionVFX;

		[SerializeField]
		private GameObject _SkipButton;

		[SerializeField]
		private TextMeshProUGUI _SkipRemainingText;

		[SerializeField]
		private GameObject _RerollButton;

		[SerializeField]
		private TextMeshProUGUI _RerollRemainingText;

		[SerializeField]
		private GameObject _BanishButton;

		[SerializeField]
		private TextMeshProUGUI _BanishRemainingText;

		[SerializeField]
		private GameObject _PassButton;

		[SerializeField]
		private TextMeshProUGUI _PassRemainingText;

		[SerializeField]
		private ParticleSystem _Gems;

		[SerializeField]
		private GameObject _CancelButton;

		[SerializeField]
		private Image _RedFadey;

		[SerializeField]
		private Localize _Title;

		[SerializeField]
		private UISpriteAnimation _BanishVFX;

		[SerializeField]
		private GameObject _Equipment;

		[SerializeField]
		private List<PauseEquipmentPanel> _EquipmentPanels;

		[SerializeField]
		private GameObject _CharacterStatsPanel;

		[SerializeField]
		private GameObject _LimitBreakRandomOnce;

		[SerializeField]
		private GameObject _LimitBreakRandomAlways;

		[SerializeField]
		private RectTransform _BanishedWeaponsContainer;

		[SerializeField]
		private GameObject _BanishedWeaponPrefab;

		[SerializeField]
		private ParticleEmitterManager _GemManager;

		[SerializeField]
		private SpriteReel _LeftBanner;

		[SerializeField]
		private SpriteReel _RightBanner;

		[SerializeField]
		private VerticalLayoutGroup _LeftStatsLayoutGroup;

		[SerializeField]
		private TwitchLevelUpPanel _TwitchLevelUpPanel;

		[SerializeField]
		private GameObject _SuggestText;

		private SignalBus _signalBus;

		private LevelUpFactory _levelUpFactory;

		private DataManager _data;

		private GameSessionData _gameSession;

		private PlayerOptions _playerOptions;

		private LimitBreakManager _limitBreakManager;

		private bool _isBanishMode;

		private readonly List<LevelUpItemUI> _spawnedItems;

		private Dictionary<WeaponType, List<WeaponData>> _weaponData;

		private List<WeaponType> _currentWeapons;

		private List<GameObject> _banishedWeaponList;

		private Sequence _colorTween;

		private ParticleSystem _Cats;

		private bool _hasReRolls;

		private bool _hasSkips;

		private bool _hasBanish;

		private bool _canPass;

		private bool _canLimitBreak;

		private bool _isDoingALimitBreak;

		private bool _particlesBuilt;

		private List<Tween> _activeTweens;

		private bool _hasPassed;

		private bool _hasSelected;

		private Coherence.Log.Logger _logger;

		public List<LevelUpItemUI> LevelUpItems => null;

		public bool HasReRolls
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool HasSkips
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool HasBanish
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CanPass
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public GameObject RerollButton => null;

		public GameObject SkipButton => null;

		public GameObject BanishButton => null;

		public GameObject CancelButton => null;

		public GameObject PassButton => null;

		[Inject]
		private void Construct(SignalBus signalBus, LevelUpFactory levelUpFactory, DataManager data, GameSessionData session, PlayerOptions playerOptions, LimitBreakManager limitBreak)
		{
		}

		private void OnDestroy()
		{
		}

		public void Reroll()
		{
		}

		public void SetBanishMode()
		{
		}

		private void UpdateFriendshipAmuletForBanishState(bool isInBanishMode)
		{
		}

		public void CancelBanishMode()
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySetFooter_003Ed__86))]
		private IEnumerator DelaySetFooter(bool enabled)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitSelectBanish_003Ed__87))]
		private IEnumerator WaitSelectBanish(bool isOn)
		{
			return null;
		}

		public void SelectWeapon(WeaponType type, LevelUpItemUI ui)
		{
		}

		private void BlockAllSelectables()
		{
		}

		private void BlockAllButtons()
		{
		}

		private void EnableLevelupOptions()
		{
		}

		private void DisableLevelupOptions()
		{
		}

		public void SelectLimitBreak(WeightedLimitBreak wl, int index)
		{
		}

		private void HandleLimitBreakLevelUp(WeightedLimitBreak wl, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
		{
		}

		public void BanishWeapon(WeaponType type, LevelUpItemUI ui)
		{
		}

		public void SelectItem(ItemData item, ItemType type)
		{
		}

		private void ProcessItemLevelUp(ItemType type, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
		{
		}

		private void ProcessFriendshipAmuletLevelup()
		{
		}

		public void Skip()
		{
		}

		public void LevelUpSkip()
		{
		}

		private void CheckIfPassAvailable()
		{
		}

		private bool CanCharacterReceivePass(VampireSurvivors.Objects.Characters.CharacterController chara)
		{
			return false;
		}

		public void Pass()
		{
		}

		private bool FindViablePassPlayer()
		{
			return false;
		}

		private void PerformPass(bool showStats)
		{
		}

		private void ShowMultiplayerBanners()
		{
		}

		[IteratorStateMachine(typeof(_003CSelectElementLater_003Ed__107))]
		private IEnumerator SelectElementLater(Selectable s)
		{
			return null;
		}

		public void LimitBreakRandomOnce()
		{
		}

		public void LimitBreakRandomAlways()
		{
		}

		protected override void Awake()
		{
		}

		private void OnLevelUpWithLimitBreak(OnlineSignals.OnlineLevelUpWithLimitBreak levelUpWithLimitBreak)
		{
		}

		private void OnLevelUpWithItem(OnlineSignals.OnlineLevelUpWithItem levelUpWithItem)
		{
		}

		private void OnLevelUpWithFriendshipAmulet(OnlineSignals.OnlineLevelUpWithFriendshipAmulet levelUpWithAmulet)
		{
		}

		private void OnLevelUpPassRequested()
		{
		}

		private void OnLevelUpPass(OnlineSignals.OnlineLevelUpPass pass)
		{
		}

		private void OnLevelUpReRoll(OnlineSignals.OnlineLevelUpReRoll reRoll)
		{
		}

		private void OnLevelUpReRollRequest()
		{
		}

		private void OnWeaponBanishedRemotely(UISignals.BanishWeaponLevelUpSignal banishedSignal)
		{
		}

		protected override void Update()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CForceLeftLayoutDelayed_003Ed__122))]
		private IEnumerator ForceLeftLayoutDelayed()
		{
			return null;
		}

		private void BuildParticles()
		{
		}

		private void BuildBanishedWeaponsList()
		{
		}

		private void UpdateButtonsUI()
		{
		}

		private void ValidateButtonStates()
		{
		}

		private void DoIntroEffects()
		{
		}

		[IteratorStateMachine(typeof(_003CTweenButtonsNextFrame_003Ed__128))]
		private IEnumerator TweenButtonsNextFrame()
		{
			return null;
		}

		private Sequence TweenButtonIn(GameObject g, float baseScale = 1f)
		{
			return null;
		}

		private void Animate()
		{
		}

		private void OnLevelUpPageIntroAnimComplete()
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void Populate()
		{
		}

		private void PickRandomLimitBreaks()
		{
		}

		private void PickRandomLevelUps()
		{
		}

		private void ResetLevelUpViewsAfterReRoll()
		{
		}

		private void PickItemLevelUps()
		{
		}

		private void SpawnItem(ItemType type, ItemData data, int index, List<VampireSurvivors.Objects.Characters.CharacterController> affectedCharacters = null)
		{
		}

		private void SpawnLimitBreak(WeightedLimitBreak d, int index)
		{
		}

		private List<Sprite> AddEvoSpritesForPlayer(WeaponData data, WeaponType type, VampireSurvivors.Objects.Characters.CharacterController player, bool checkSlotLimits = false)
		{
			return null;
		}

		private bool IsEvolutionUnlocked(WeaponData data)
		{
			return false;
		}

		private void SpawnWeapon(WeaponData data, WeaponType type, int index)
		{
		}

		private void ChooseRandomLimitBreak()
		{
		}

		private void EditorSkipLevelUp()
		{
		}
	}
}
