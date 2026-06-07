using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using InputControl;
using Libs;
using SaveData;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

namespace OutGame
{
	public class LobbyController : SingletonMonoBehaviour<LobbyController>
	{
		[Serializable]
		public class MasterInfo
		{
			public eWriterId id;

			public Sprite unselectedSprite;

			public Sprite selectedSprite;

			public Sprite choiceSprite;

			public Sprite choiceSpriteOn;
		}

		private enum eMinionAnimationName
		{
			NodMinion = 0,
			JumpMinion = 1
		}

		[CompilerGenerated]
		private sealed class _003CDelayPadEnable_003Ed__121 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyController _003C_003E4__this;

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
			public _003CDelayPadEnable_003Ed__121(int _003C_003E1__state)
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

		public CanvasGroup lobbyCanvasGroup;

		[Header("OutGameShop")]
		public RectTransform outShopMaskTarget;

		public TMP_Text completedCountText;

		public TMP_Text knowledgePointText;

		[Header("Ascension")]
		public RectTransform ascensionGroup;

		public TMP_Text ascensionLevelText;

		public TMP_Text ascensionLevelMaxText;

		public CanvasGroup ascensionTalkGroup;

		public TMP_Text ascensionTalkAvatorText;

		public Transform ascensionCandleParent;

		public List<GameObject> ascensionCandleList;

		public AscensionDescWindowCtrl ascensionDescWindowCtrl;

		public Button ascensionButton;

		public SkeletonGraphicController ordealSpine;

		public SkeletonGraphicController avatorSpine;

		[Header("Challenge")]
		public RectTransform challengeMaskTarget;

		public Button selectChallengeButton;

		public Button disabledChallengeButton;

		public TMP_Text disabledChallengeUnlockConditionText;

		public GameObject challengeUnlockConditionTextObj;

		public GameObject challengeUnlockConditionCountTextObj;

		public GameObject challengeTrialLockTextObj;

		[Header("Master")]
		public MasterImageItem masterImageItemPrefab;

		public RectTransform masterListParent;

		public List<MasterInfo> masterInfoList;

		public Image choiceMasterImage;

		[Header("Video")]
		public VideoPlayerCtrl videoPlayer;

		public SimpleSpriteAnimator blinkSpriteMovie;

		[SerializeField]
		private VideoClip _startVideo;

		[SerializeField]
		private VideoClip _steamStartVideo;

		[Header("Tutorial")]
		public RectTransform tutorialGroup;

		[SerializeField]
		private UILookEmphasis tutorialEmphasis;

		public RectTransform tutorialUnmaskTarget;

		[Header("InGame")]
		public RectTransform inGameUnmaskTarget;

		public GameObject gameStartWindow;

		public RectTransform freeModeUnmaskTarget;

		public Toggle freeControllToggle;

		public CursorUIItem freeControllCursorUIItem;

		public Image freeControlFocusImage;

		public UIScaleController gameStartWindowScaleController;

		[Header("System UI Group")]
		[SerializeField]
		private List<GameObject> systemUIGroup;

		[SerializeField]
		private Image blindhold;

		[SerializeField]
		private SimpleSpriteAnimatorSwitcher spriteAnimatorSwitcher;

		public GameObject blindObj;

		[Header("ShowLogo")]
		public GameObject showLogoObj;

		[SerializeField]
		private PadInputConfigure defaultPadInputConfigure;

		[SerializeField]
		private PadInputConfigure gameStartWindoInputConfigure;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		[SerializeField]
		private PadInputConfigure sequencePadInputConfigure;

		[SerializeField]
		private CursorUIGroup gameStartCursor;

		[SerializeField]
		private CursorUIGroup tutorialCursor;

		[SerializeField]
		private CursorUIGroup outGameShopCursor;

		[SerializeField]
		private CursorUIGroup challengeCursor;

		[SerializeField]
		private CursorUIGroup webHookGroup;

		[SerializeField]
		private CursorUIBase settingButton;

		[SerializeField]
		private GameObject webHookGroupGameObject;

		public Action PadTipsAction;

		private Dictionary<eWriterId, MasterImageItem> _masterImageItemList;

		private InputActionController input;

		private Sequence _openingSequence;

		private Tween _openingMovieSoundTween;

		private Sequence _avatorTalkSequence;

		private bool _isIntroductionSequence;

		private bool _isAscensionSequence;

		private string _prevAvatorMessage;

		private bool _isIntroductionTutorialWait;

		private readonly string ORDEAL_FADEIN;

		private readonly string ORDEAL_LOOP;

		private readonly int trialAscensionMax;

		public bool IsOpenBattleStartWindow => false;

		public GameStartWindowCtrl gameStartWindowCtrl => null;

		public PadInputConfigure SequencePadInputConfigure => null;

		private int LimitAscension => 0;

		public bool IsAnySequence { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void Init()
		{
		}

		private void InitChallengeModeButton()
		{
		}

		private void AfterInit()
		{
		}

		private void InitIntroduction()
		{
		}

		private void StartIntroduction()
		{
		}

		private Sequence StartEliminatedLastBossBlink()
		{
			return null;
		}

		private void SwitchDisplaySystemUI(bool active)
		{
		}

		private void WinkSequence(ref Sequence sequence)
		{
		}

		private void SpotLightImages(ref Sequence sequence, RectTransform target, float duration, UnityAction fadeCallback = null, UnityAction onComplete = null)
		{
		}

		public void UpdateGreaterKnowledgeCount()
		{
		}

		public void OnClickGreaterKnowledge()
		{
		}

		public void OnStartGame()
		{
		}

		public void OnPushTutorial()
		{
		}

		private Sequence ShowAscensionEffect(bool isUpAscension, Action onComplete)
		{
			return null;
		}

		private Sequence ShowOpenLastStageEffect(ref bool isUpAscension)
		{
			return null;
		}

		public void OnStartTutorial(eTutorialSectionId sectionId)
		{
		}

		private void StartGame(eModeType modeType = eModeType.Normal)
		{
		}

		private void OpeningSequence()
		{
		}

		public void OnNextMaster()
		{
		}

		public void OnPrevMaster()
		{
		}

		public void SelectMaster(AuthorUnlockData authorData, bool isInitialize = false, bool isDialogSelect = false)
		{
		}

		public void SelectMaster(eWriterId writerId)
		{
		}

		public void OnPointerEnterSelectMaster()
		{
		}

		public void OnPointerExitSelectMaster()
		{
		}

		public void OnChangeLevel(int value)
		{
		}

		private void UpdateUI()
		{
		}

		private void SetAscensionCandle(int level)
		{
		}

		private void OnDisable()
		{
		}

		private void SetTalkAvator(string message, float displayDuration = 2.5f, Vector2? commentPos = null)
		{
		}

		private void SetTalkAvator(ref Sequence sequence, string message, float displayDuration = 2.5f, Vector2? commentPos = null)
		{
		}

		[Conditional("TRIAL")]
		private void DisplayTutorialMessage()
		{
		}

		public void BackToTitle()
		{
		}

		public void SetActiveForFreeControll(bool active)
		{
		}

		public void OpenGameStartWindow()
		{
		}

		private void MovieSkipAction()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayPadEnable_003Ed__121))]
		private IEnumerator DelayPadEnable()
		{
			return null;
		}

		public void OnPadClick()
		{
		}

		public void OnPadStart()
		{
		}

		public void SelectGameStart()
		{
		}

		public void SelectOutGameShop()
		{
		}

		public void SelectTutorial()
		{
		}

		public void SelectChallenge()
		{
		}
	}
}
