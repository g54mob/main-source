using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class OpenTreasurePage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CPlayMultiplayerRandomisation_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OpenTreasurePage _003C_003E4__this;

			private List<VampireSurvivors.Objects.Characters.CharacterController> _003Cplayers_003E5__2;

			private int _003Cindex_003E5__3;

			private int _003Cscrolls_003E5__4;

			private float _003Ctime_003E5__5;

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
			public _003CPlayMultiplayerRandomisation_003Ed__111(int _003C_003E1__state)
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
		private bool _PauseOnAnimIntro;

		[SerializeField]
		private List<TreasurePlaybackSettings> PlaybackLevels;

		[SerializeField]
		private UISpriteAnimation _IdleTreasureChest;

		[SerializeField]
		private UISpriteAnimation _OpenTreasureChest;

		[SerializeField]
		private UISpriteAnimation _OpenTreasureChestFront;

		[SerializeField]
		private Image _TreasureImage;

		[SerializeField]
		private Image _OpenTreasureFrontImage;

		[SerializeField]
		private Animator Animator;

		[SerializeField]
		private TreasureRibbonTrailGenerator _Ribbons;

		[SerializeField]
		private GameObject OpenButton;

		[SerializeField]
		private GameObject DoneButton;

		[SerializeField]
		private GameObject OpenButtonLeftArrow;

		[SerializeField]
		private GameObject OpenButtonRightArrow;

		[SerializeField]
		private GameObject DoneButtonLeftArrow;

		[SerializeField]
		private GameObject DoneButtonRightArrow;

		[SerializeField]
		private TextMeshProUGUI CoinsCount;

		[SerializeField]
		private TextMeshProUGUI FinalCoins;

		[SerializeField]
		private ParticleSystem PowerParticles;

		[SerializeField]
		private TreasureInfoPanel InfoPanel;

		[SerializeField]
		private TreasureFireworksManager Fireworks;

		[SerializeField]
		private UISpriteAnimation VFXAnimation;

		[SerializeField]
		private RectTransform Panel;

		[SerializeField]
		private GameObject _Title;

		[SerializeField]
		private Image _YellowBackground;

		[SerializeField]
		private Image _HeatBackground;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private Image _BGOverlay;

		[SerializeField]
		private RectTransform _FireworkContainer;

		[SerializeField]
		private RectTransform _GravityWellPosition;

		[SerializeField]
		private GameObject _CoopRandomPanel;

		[SerializeField]
		private Image _CoopRandomCharacter;

		[SerializeField]
		private ParticleSystem _CoopCharacterParticles;

		private SignalBus _signalBus;

		private TreasureFactory _treasureFactory;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private GameSessionData _session;

		private Treasure _currentTreasure;

		private TreasurePlaybackSettings _currentPlayback;

		private List<TreasurePrizeTypePair> _prizes;

		private List<string> _weaponFrameNames;

		private Dictionary<WeaponType, List<WeaponData>> _weaponData;

		private static readonly int Play1;

		private static readonly int Play2;

		private static readonly int Play3;

		private static readonly int NormalizedAnimationTimeParameter;

		private static readonly int BaseColorProperty;

		private int _currentTreasureLevel;

		private bool _openButtonPressed;

		private bool _doneButtonPressed;

		private bool _animationFinished;

		private bool _receivedClaimRequest;

		private float _outAnimationSpeed;

		private float _inAnimationSpeed;

		private float _animationTime;

		private float _normalizedAnimationTime;

		private float _audioClipLength;

		private bool _canSkip;

		private bool _isPlaying;

		private bool _animCanBeSkippedPastThisPoint;

		private bool _isSkipped;

		private Tween _heatTween;

		private Tween _yellowTween;

		private Tween _coinTween;

		private Tween _bgTween;

		private Tween _idleTimer;

		private Tween _animFinishedTimer;

		private Tween _coinSinTimer;

		private SfxType _treasure1SfxType;

		private SfxType _treasure2SfxType;

		private SfxType _treasure3SfxType;

		private Sequence _randomCharacterSequence;

		private Coroutine _winningPlayerRoutine;

		private int _fireworksSortingOrder;

		private Material _powerParticlesMaterial;

		private string _treasureCacheGroupName;

		[Inject]
		private void Construct(SignalBus signalBus, TreasureFactory treasureFactory, DataManager data, PlayerOptions playerOptions, GameSessionData session)
		{
		}

		private void OnDestroy()
		{
		}

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		public void DoReelTrailAnimation()
		{
		}

		public void OpenTreasure()
		{
		}

		public void StartPlaying()
		{
		}

		public void PlayFireworks()
		{
		}

		public void ClaimTreasure()
		{
		}

		public void ReceiveClaimTreasureRequest()
		{
		}

		public void TreasureCompleted()
		{
		}

		public void DoExtraFireworks()
		{
		}

		public void FinishHeat()
		{
		}

		public void AnimationFinished()
		{
		}

		public void OpenChest()
		{
		}

		public void StartPlayingCoins()
		{
		}

		public void StopCoins()
		{
		}

		public void StopScrollingReels()
		{
		}

		public void StartScrollingReels()
		{
		}

		public void HideBeams()
		{
		}

		public void StopReels()
		{
		}

		public void RevealReel1()
		{
		}

		public void RevealReel2()
		{
		}

		public void RevealReel3()
		{
		}

		public void RevealReel4()
		{
		}

		public void RevealReel5()
		{
		}

		private void CacheTreasure(GameplaySignals.OpenTreasureSignal sig)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		public void AnimateIn()
		{
		}

		public void AnimateOut()
		{
		}

		public void MakeRibbons()
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		private void FireTreasureFinishedEvents()
		{
		}

		[IteratorStateMachine(typeof(_003CPlayMultiplayerRandomisation_003Ed__111))]
		private IEnumerator PlayMultiplayerRandomisation()
		{
			return null;
		}

		private void Play(int level)
		{
		}

		private void TweenCoins()
		{
		}

		private void SkipCoins(float skipTime, float animationLength)
		{
		}

		private void SetSkip(int level)
		{
		}

		private bool CheckLevel1Skip(PlayerOptionsData config)
		{
			return false;
		}

		private bool CheckLevel2Skip(PlayerOptionsData config)
		{
			return false;
		}

		private bool CheckLevel3Skip(PlayerOptionsData config)
		{
			return false;
		}

		private void Reset()
		{
		}

		private void Skip()
		{
		}

		private void PerformSkip()
		{
		}
	}
}
